Option Explicit

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.IO.Directory

Public Class JukeboxFormMain
    Inherits Form

    Private Const ICON_FILE  As String = "Jukebox.ico"
    
    Private Const FORM_WIDTH  As Integer = 360
    Private Const FORM_HEIGHT As Integer = 108
    Private Const ITEM_FONT_SIZE    As Integer = 12
    Private Const COMBO_ITEM_HEIGHT As Integer = 20

    Private Const MIDI_PLAY  As String = "再 生"
    Private Const MIDI_STOP  As String = "中 止"
    Private Const MIDI_PAUSE As String = "停 止"

    'Zez ConfreyのMIDI位置
    Private Const CONFREY_MIDI_POS As Integer = 142

    '構造体
    Private udtPlaylist() As PlaylistMenuInfo 'ユーザープレイリスト
    Private udtMidiInfo() As MidiInfo         'MIDIファイル情報

    'フォント
    Private FontToControl As Font

    'コントロール
    Private WithEvents cboTitle  As ComboBox  'コンボボックス
    Private btnMIDIOp(2) As Button            'コマンドボタン
    Private chkAutoPlay  As CheckBox          'チェックボックス
    Private mnuMain As New MainMenu           'メインメニュー
    Private PouUpMenu As New ContextMenu      'ポップアップメニュー

    'クラス
    Private clsMIDIUtil As MIDIUtility
    Private clsMIDIPlayIndexList As New MIDIPlayIndexList
    Private clsCBFUtil As New CbfFileUtility

    '再生MIDIファイルリスト
    Private PlayMidiList As New ArrayList

    'ユーザー定義MIDIプレイリスト
    Private udtUserMidiList As UserMidiList

    '起動時エラー判定フラグ
    Private IsNotStartError As Boolean

    'コンストラクタ
    Public Sub New()
        MyBase.New()
        
        'MIDIタイトル・ファイル名を読み込む
        IsNotStartError = ReadMIDIFileInfo(udtMidiInfo)
        If IsNotStartError = False Then Exit Sub

        'レイアウト変更の抑止
        Me.SuspendLayout()

        '自分自身の設定
        With Me
            .Size = New Size(.FORM_WIDTH, .FORM_HEIGHT)
            .MaximizeBox = False 
            .SizeGripStyle = SizeGripStyle.Hide
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .Text = APP_TITLE
        End With

        'アイコン設定
        If Dir$(GetCurrentDir + ICON_FILE) <> "" Then Me.icon = New Icon(ICON_FILE)

        'フォント生成
        FontToControl = New Font(Me.Font.Name, 11)  'MS UI Gothic

        'コンボボックス設定
        cboTitle = SetCboTitle(Me, New ComboBox(), udtMidiInfo)

        'コマンドボタン設定
        Call SetMIDIButton()

        'メニュー設定
        Call SetPopUpMenu(mnuMain)

        '自動演奏用チェックボックス設定
        chkAutoPlay = SetChkAutoPlay(New CheckBox())

        'ユーザーMIDIプレイリスト管理構造体をとりあえず初期化
        udtUserMidiList.init

        'コントロールをフォームに追加
        Me.Controls.AddRange(New Control(){cboTitle})
        Me.Controls.AddRange(New Control(){chkAutoPlay})
        Me.Controls.AddRange(New Control(){btnMIDIOp(0), btnMIDIOp(1), btnMIDIOp(2)})

        'ウィンドウ表示位置を中央やや上に表示
        Call MoveWindowCenter(Me.Handle, 3)

        'レイアウト変更を反映
        Me.ResumeLayout()

        'MIDIデバイスチェック
        clsMIDIUtil = New MIDIUtility(Me.Handle)
        If clsMIDIUtil.IsUserMIDIDevice = False Then
            Call MsgBox("ご使用のパソコンではMIDIデバイスは使用出来ません。", vbOkOnly + vbExclamation, APP_TITLE)
            btnMIDIOp(0).Enabled = False
        End If
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名：MIDIPlayStart
    ' 機  能：MIDIファイルを再生する
    ' 引  数：(in) PlayEnabled  … 再生ボタン利用可能・不可
    '         (in) StopEnabled  … 中止ボタン利用可能・不可
    '         (in) PauseEnabled … 停止ボタン利用可能・不可
    ' 返り値：正常：True  異常：False
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function MIDIPlayStart(Optional ByVal PlayEnabled As Boolean = False, _
                                  Optional ByVal StopEnabled As Boolean = True, _
                                  Optional ByVal PauseEnabled As Boolean = True) As Boolean
        Dim FuncRet As Integer
        Dim MIDIFileName As String

        'MIDIファイル抽出
        FuncRet = clsCBFUtil.Extract(cboTitle.SelectedIndex)
        If FuncRet < 0 Then
            Call MsgBox(clsCBFUtil.GetErrorMessage(FuncRet), vbOkOnly + vbExclamation, APP_TITLE)
            Exit Function
        End If

        'MIDI再生
        FuncRet = clsMIDIUtil.midiPlay(udtMidiInfo(cboTitle.SelectedIndex).MIDIFileName)
        If FuncRet <> 0 Then
            'エラー処理
            Call MsgBox(clsMIDIUtil.mciError, vbOkOnly + vbExclamation, APP_TITLE)

            'MIDIを閉じる
            clsMIDIUtil.midiClose

            Exit Function
        End If

        'リストに追加
        PlayMidiList.Add(udtMidiInfo(cboTitle.SelectedIndex).MIDIFileName) 'MIDIファイル
        clsMIDIPlayIndexList.AddIndex(cboTitle.SelectedIndex)              'MIDIインデックス  

        'コントロール制御
        cboTitle.Enabled = False
        btnMIDIOp(0).Enabled = False
        btnMIDIOp(1).Enabled = True
        btnMIDIOp(2).Enabled = True
        
        MIDIPlayStart = True
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名：MIDIPlayStop
    ' 機  能：MIDIファイルを中止する
    ' 引  数：(in) PlayEnabled  … 再生ボタン利用可能・不可
    '         (in) StopEnabled  … 中止ボタン利用可能・不可
    '         (in) PauseEnabled … 停止ボタン利用可能・不可
    '         (in) IsMCINotify … MM_MCINOTIFY から呼ばれたか
    '                               True …呼ばれた
    '                               False…以外から呼ばれた
    ' 返り値：正常：True  異常：False
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function MIDIPlayStop(Optional ByVal PlayEnabled As Boolean = True, _
                                 Optional ByVal StopEnabled As Boolean = False, _
                                 Optional ByVal PauseEnabled As Boolean = False, _
                                 Optional ByVal IsMCINotify As Boolean = False) As Boolean
        Dim FuncRet As Long

        'MM_MCINOTIFY 以外から呼ばれた
        If IsMCINotify = False Then
            'MIDI再生中止
            FuncRet = clsMIDIUtil.midiStop
            If FuncRet <> 0 Then
                Call MsgBox("MIDIファイル再生中止に失敗しました" & vbCrLf & _
                               clsMIDIUtil.mciError, vbOKOnly + vbExclamation, APP_TITLE)
                clsMIDIUtil.midiClose
                Exit Function
            End If
            
            'ユーザープレイリスト再生中であった場合
            If udtUserMidiList.IsPlayList Then
                chkAutoPlay.Enabled = True
                udtUserMidiList.IsPlayList = False
            End If
        End If

        'コントロール制御
        cboTitle.Enabled = True
        btnMIDIOp(0).Enabled = PlayEnabled
        btnMIDIOp(1).Enabled = StopEnabled
        btnMIDIOp(2).Enabled = PauseEnabled

        MIDIPlayStop = True
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名：MIDIPlayPause
    ' 機  能：MIDIファイルを停止・停止解除する
    ' 引  数：(in) PlayEnabled  … 再生ボタン利用可能・不可
    '         (in) StopEnabled  … 中止ボタン利用可能・不可
    '         (in) PauseEnabled … 停止ボタン利用可能・不可
    ' 返り値：正常：True  異常：False
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function MIDIPlayPause(Optional ByVal PlayEnabled As Boolean = False, _
                                  Optional ByVal StopEnabled As Boolean = False, _
                                  Optional ByVal PauseEnabled As Boolean = True) As Boolean
        Dim FuncRet As Long
        Static IsPaiseOn As Boolean

        '再生中に押された 再生→停止
        If IsPaiseOn = False Then
            FuncRet = clsMIDIUtil.midiPause
            If FuncRet <> 0 Then
                Call MsgBox("MIDIファイル再生停止に失敗しました" & vbCrLf & _
                             clsMIDIUtil.mciError, vbOKOnly + vbExclamation, APP_TITLE)
                GoTo ErrHandler
            End If
            IsPaiseOn = True
            btnMIDIOp(1).Enabled = False
        '停止中に押された 停止→再生
        Else
            FuncRet = clsMIDIUtil.midiResume
            If FuncRet <> 0 Then
                Call MsgBox("MIDIファイル停止解除に失敗しました" & vbCrLf & _
                             clsMIDIUtil.mciError, vbOKOnly + vbExclamation, APP_TITLE)
                GoTo ErrHandler
            End If
            IsPaiseOn = False
            btnMIDIOp(1).Enabled = True
        End If

        MIDIPlayPause = True

        Exit Function

    ErrHandler:
        'エラー時はMIDIを閉じ、コントロールの状態を(とりあえず)元に戻す
        'ここを通ることはないはず...
        clsMIDIUtil.midiClose
        cboTitle.Enabled = True
        btnMIDIOp(0).Enabled = True
        btnMIDIOp(1).Enabled = False
        btnMIDIOp(2).Enabled = False
    End Function



    '*******************************************
    '     コントロール設定ファンクション
    '*******************************************
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： SetCboTitle
    ' 機  能： コンボボックスを生成・設定する
    ' 引  数： (i)SrcForm  … メインフォーム
    '          (i)cboTitle … コンボボックスオブジェクト
    '          (i)udtMI    … MidiInfo 構造体
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Function SetCboTitle(ByVal SrcForm As Form, ByVal cboTitle As ComboBox, _
                                 ByVal udtMI() As MidiInfo) As ComboBox
        Dim udtClientRect As Rectangle = SrcForm.ClientRectangle
        Dim xPos As Integer = 4
        Dim yPos As Integer = 10
        Dim i As Integer

        With cboTitle
            .Location  = New Point(xPos, yPos)
            .Size      = New Size(udtClientRect.Width - xPos, .Height)
            .DropDownStyle = ComboBoxStyle.DropDownList   '選択のみ、入力不可の指定
            .ItemHeight    = COMBO_ITEM_HEIGHT
            .DrawMode  = DrawMode.OwnerDrawFixed
            
            'アイテム追加
            For i= 0 To UBound(udtMI)
                .Items.Add(" " & udtMI(i).MIDITitle)
            Next i
            .Text = " " & udtMI(0).MIDITitle
        End With 

        SetCboTitle = cboTitle
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： SetMIDIButton
    ' 機  能： コマンドボタン(再生・中止・停止)を生成・設定する
    ' 引  数： (i) コンボボックスの高さ
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Sub SetMIDIButton()
        Dim ButtonCaption() As String = {MIDI_PLAY, MIDI_STOP, MIDI_PAUSE}
        Dim i As Integer

        For i = 0 To UBound(btnMIDIOp)
            btnMIDIOp(i) = New Button()
            With btnMIDIOp(i)
                .Text = ButtonCaption(i)
                .Size = New Size(78, 30)
                .Location = New Point(114 + i * 78, 12 + COMBO_ITEM_HEIGHT + 14)  '14は気持ち
                .Font = FontToControl
            End With    
            'イベントハンドラに登録、これで  btnMIDIOp_Click  がコールバックされるわけね
            AddHandler btnMIDIOp(i).Click, AddressOf Me.btnMIDIOp_Click
        Next i
        
        '初期状態
        btnMIDIOp(0).Enabled = True
        btnMIDIOp(1).Enabled = False
        btnMIDIOp(2).Enabled = False
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： SetChkAutoPlay
    ' 機  能： チェックボックスを生成・設定する
    ' 引  数： (i)chkAutoPlay …  チェックボックスオブジェクト
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Function SetChkAutoPlay(ByVal chkAutoPlay As Checkbox) As Checkbox
        With chkAutoPlay
            .Location  = New Point(8, 48)
            .Size      = New Size(86, .Height)
            .Text      = "自動演奏"
            .Checked   = False
            .Font      = FontToControl
        End With
        
        SetChkAutoPlay = chkAutoPlay
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： SetPopUpMenu
    ' 機  能： メニューを生成・設定する
    ' 引  数： (i)SrcMainMenu …  メニューの大元
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Function SetPopUpMenu(ByVal SrcMainMenu As MainMenu)
        Dim i As Integer
        'メニュー生成
        Dim mnuUserList As MenuItem = mnuMain.MenuItems.Add("PlayList")
        mnuUserList.Visible = True

        'メインウィンドウにメニューを設定
        Me.Menu = mnuMain

        'サブメニューを動的に作成
        'Playlist\*.playlist が存在するか判定する
        If IsExistPlaylist Then
            'サブメニューに表示するテキストを取得する
            Call ReadSubMenuCaption(udtPlaylist)

            'サブメニュー設定
            For i = 0 To UBound(udtPlaylist)
                'メニュータイトルとイベントハンドリング関数名を設定
                mnuUserList.MenuItems.Add(New MenuItem(udtPlaylist(i).Title, New EventHandler(AddressOf Me.UserListMenu_Clicked)))
            Next i

            'ポップアップメニューに動的に作成したサブメニューを割り当てる
            PouUpMenu.MenuItems.Add(mnuUserList)

            'ポップアップメニューをメインウィンドウに登録
            Me.ContextMenu = PouUpMenu 
        Else
            mnuUserList.Visible = False
        End If

    End Function



    '*******************************************
    '        コ ン ト ロ ー ル イ ベ ン ト
    '*******************************************
    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' フォーム Load イベント
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        'cbf 読み込みエラー時は終了
        If IsNotStartError = False Then Application.Exit()
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' Query_Unload イベント
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        Dim MIDIFile As String
        Dim FuncRet As Integer

        'MIDI再生中、もしくは停止中の時はファイルを閉じる
        If clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_PLAY Or _
           clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_PAUSE Then
            'MIDIストップ
            FuncRet = clsMIDIUtil.midiStop
            'エラーでも一応クローズ
            If FuncRet <> 0 Then
                 clsMIDIUtil.midiClose
            End If
        End If
        
        'MIDIファイル削除
        For Each MIDIFile In PlayMidiList
            System.IO.File.Delete(GetCurrentDir & MIDIFile)
        Next
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' コマンドボタン Click イベント
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Private Sub btnMIDIOp_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        'マウスポインタを砂時計にする
        Cursor.Current = Cursors.WaitCursor

        If sender.Text = MIDI_PLAY Then         '再生
           Call MIDIPlayStart
        Else If sender.Text = MIDI_STOP Then    '中止
           Call MIDIPlayStop
        Else If sender.Text = MIDI_PAUSE Then   '停止
           Call MIDIPlayPause
        End If

        'マウスポインタを元に戻す
        Cursor.Current = Cursors.Default
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' ポップアップメニュー Click イベント
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Private Sub UserListMenu_Clicked(ByVal sender As Object, ByVal e As System.EventArgs)
        'MIDIデバイスが利用できない場合は無視
        If clsMIDIUtil.IsUserMIDIDevice = False Then Exit Sub

        Dim PlaylistFile As String
        Dim i As Integer
        Dim ComboMIDIIndex As Integer
 
        For i = 0 To UBound(udtPlaylist)
            If udtPlaylist(i).Title = sender.text Then Exit For
        Next

        '*.playlist のフルパス
        PlaylistFile = GetPlaylistDir & udtPlaylist(i).FileName

        'ファイルが存在していたら再生
        If Dir$(PlaylistFile) <> "" Then
            'マウスポインタを砂時計にする
            Cursor.Current = Cursors.WaitCursor
            System.Windows.Forms.Application.DoEvents()  '気休め

            'MIDI再生中、もしくは中止中・停止中の時はファイルを閉じる
            If clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_PLAY Then
                'MIDIストップ
                Call MIDIPlayStop
            ElseIf clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_STOP Or _
                   clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_PAUSE Then
                'MIDIクローズ
                Call clsMIDIUtil.midiClose

                'ボタン制御
                btnMIDIOp(1).Enabled = False
                btnMIDIOp(2).Enabled = False
            End If

            'ユーザーMIDIプレイリスト管理構造体を初期化
            Call udtUserMidiList.init
            Dim FuncRetBool = ReadPlaylist(PlaylistFile, udtUserMidiList.PlayList)
            udtUserMidiList.IsPlayList = (udtUserMidiList.PlayList.Count > 0)
            If FuncRetBool AndAlso udtUserMidiList.IsPlayList Then
                For i = 0 To udtUserMidiList.PlayList.Count - 1
                    'MIDIファイル名よりインデックスを取得
                    ComboMIDIIndex = clsCBFUtil.GetMIDIHeaderIndex(udtUserMidiList.PlayList(i))
                    If ComboMIDIIndex < 0 Then
                        Call MsgBox(udtUserMidiList.PlayList(i) & " ファイルが " & clsCBFUtil.CBFFILE_NAME & _
                                    "に見つかりません。", vbOKOnly + vbExclamation, APP_TITLE)
                        udtUserMidiList.IsPlayList = False
                        Exit For
                    End If
                Next i
            End If

            'ユーザープレイリスト再生
            If FuncRetBool AndAlso udtUserMidiList.IsPlayList Then
                With chkAutoPlay
                    .Checked = True
                    .Enabled = False
                End With
                btnMIDIOp(1).Enabled = False
                udtUserMidiList.PlayIndex = 0
                cboTitle.SelectedIndex = clsCBFUtil.GetMIDIHeaderIndex(udtUserMidiList.PlayList.Item(0))
                Call MIDIPlayStart
            End If

            'マウスポインタを元に戻す
            Cursor.Current = Cursors.Default
        End If

    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ' LBUTTON_DOWN、RBUTTON_DOWN イベント？
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    Overrides Protected Sub OnMouseDown(ByVal e As MouseEventArgs)
        '左クリックの場合はフォームごとドラッグ
        if e.Button = System.Windows.Forms.MouseButtons.Left Then
            Call WindowDragOn(Me.Handle)
        End If
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： cboTitle_DrawItem
    ' 機  能： コンボボックスオーナードローイベント(コールバック)
    ' 引  数： (i)sender … オブジェクト
    '          (i)e      … イベントクラス
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Sub cboTitle_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) _
    Handles cboTitle.DrawItem
        If e.Index = (-1) Then Exit Sub

        '文字色用ブラシ
        Dim ItemForeColorBrush As Brush

        'アイテム描画領域
        Dim ClientRect As Rectangle = New Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height)
        Dim EdgeRect As Rectangle   = New Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1)
        Dim Location As PointF = New PointF(ClientRect.X , ClientRect.Y )

        '描画ビットマップ(１アイテム毎に背景設定や文字装飾をする)
        Dim objBitmap  As Bitmap   = New Bitmap(e.Bounds.Width, e.Bounds.Height)
        Dim objGraphic As Graphics = Graphics.FromImage(objBitmap)

        'フォント設定
        Dim fFamily  As FontFamily = New FontFamily(e.Font.Name)
        Dim ItemFont As Font = New Font(fFamily, ITEM_FONT_SIZE, FontStyle.Regular)  

        'アイテムの背景色設定
        'エディットボックス
        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            objGraphic.FillRectangle(Brushes.Black, ClientRect)    
        '選択されているアイテム
        Else If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            '青で塗りつぶし
            objGraphic.FillRectangle(Brushes.Blue, ClientRect)

            '枠を水色で囲む
            Dim framePen As Pen = New Pen(Color.Aqua)
            objGraphic.DrawRectangle(framePen, EdgeRect)
            framePen.Dispose()
        '選択されていないアイテム
        Else
            '黒で塗りつぶし
            objGraphic.FillRectangle(Brushes.Black, ClientRect)
        End If

        'アイテム文字色設定
        'エディットボックス
        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            If e.Index >= CONFREY_MIDI_POS Then
                ItemForeColorBrush = Brushes.Yellow
            Else
                ItemForeColorBrush = Brushes.White
            End If
        '選択されているアイテム
        Else If (e.State And DrawItemState.Selected) = DrawItemState.Selected  Then
            If e.Index >= CONFREY_MIDI_POS Then
                ItemForeColorBrush = Brushes.Yellow
            Else
                ItemForeColorBrush = Brushes.White
            End If
        '選択されていないアイテム
        Else
            If e.Index >= CONFREY_MIDI_POS Then
                ItemForeColorBrush = Brushes.Yellow
            Else
                ItemForeColorBrush = Brushes.White
            End If
        End If
        
        '文字描画
        objGraphic.DrawString(cboTitle.Items.Item(e.Index).ToString, _
                     ItemFont, ItemForeColorBrush, Location)

        'アイテム矩形設定反映
        e.Graphics.DrawImage(objBitmap, e.Bounds) 
        
        'アイテム枠を表示
        'e.DrawFocusRectangle()

        'フォントの破棄
        ItemFont.Dispose()
        fFamily.Dispose()
        objGraphic.Dispose()
        objBitmap.Dispose()
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' ウィンドウプロシージャ(簡単になったねぇ)
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Protected Overloads Overrides Sub WndProc(ByRef msg As Message)
        Select msg.Msg 
            Case MM_MCINOTIFY
                If msg.wParam.toInt32 = MCI_NOTIFY_SUCCESSFUL Then
                    If clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_STOP Or _
                       clsMIDIUtil.midiStatus = clsMIDIUtil.STATUS_PAUSE Then
                        'マウスポインタを砂時計にする
                        Cursor.Current = Cursors.WaitCursor

                        'MIDI操作
                        Call MIDIAutoProc

                        'マウスポインタを元に戻す
                        Cursor.Current = Cursors.Default
                    End If
                End If
        End Select
        
        MyBase.WndProc(msg)
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名：MIDIAutoProc
    ' 機  能：MIDIファイル中止＆再生の処理
    ' 引  数：なし
    ' 返り値：なし
    ' 備  考：MM_MCINOTIFY を拾った際に呼ばれる
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Sub MIDIAutoProc()
        Dim FuncRet As Integer
        Dim NextPlayIndex As Integer
        
        Dim CBFMidiNum As Integer

        FuncRet = clsMIDIUtil.midiClose
        If FuncRet <> 0 Then
            'とりあえずエラーを表示しておく
            Call MsgBox("MIDIファイルクローズに失敗しました" & vbCrLf & _
                          clsMIDIUtil.mciError, vbOKOnly + vbExclamation, APP_TITLE)
        End If
         
        'コントロール制御
        Call MIDIPlayStop(, , , True)

        'ちょっと待つ
        System.Threading.Thread.Sleep(500) 
        System.Windows.Forms.Application.DoEvents()

        '自動演奏がチェックされている
        If chkAutoPlay.Checked Then
            'ユーザープレイリスト再生
            If udtUserMidiList.IsPlayList Then
                '再生回数(0-Base)を加算
                udtUserMidiList.PlayIndex = udtUserMidiList.PlayIndex + 1

                '再生回数(0-Base)が総再生回数(1-Base)内である → 次のユーザー定義MIDIを再生
                If udtUserMidiList.PlayList.Count > udtUserMidiList.PlayIndex Then
                    '次に再生するMIDIファイルインデックスを取得
                    NextPlayIndex = clsCBFUtil.GetMIDIHeaderIndex(udtUserMidiList.PlayList.Item(udtUserMidiList.PlayIndex))

                    'コンボボックス選択
                    cboTitle.SelectedIndex = NextPlayIndex

                    '再生
                    Call MIDIPlayStart
                '再生回数(0-Base)が総再生回数(1-Base)を越えた → 次のMIDIをランダムで選出して再生
                Else
                    chkAutoPlay.Enabled = True
                    udtUserMidiList.IsPlayList = False

                    '次に再生するMIDIファイルインデックスを取得
                    CBFMidiNum = clsCBFUtil.MIDINum()
                    If CBFMidiNum < 0 Then
                        Call MsgBox(clsCBFUtil.GetErrorMessage(), vbOkOnly + vbExclamation, APP_TITLE)
                        Exit Sub
                    End If    
                    NextPlayIndex = clsMIDIPlayIndexList.GetNextPlayMIDIIndex(CBFMidiNum - 1)

                    'コンボボックス選択
                    cboTitle.SelectedIndex = NextPlayIndex

                    '再生
                    Call MIDIPlayStart
                End If
 
            '通常の自動再生
            Else
                '次に再生するMIDIファイルインデックスを取得
                CBFMidiNum = clsCBFUtil.MIDINum()
                If CBFMidiNum < 0 Then
                    Call MsgBox(clsCBFUtil.GetErrorMessage(), vbOkOnly + vbExclamation, APP_TITLE)
                    Exit Sub
                End If    
                NextPlayIndex = clsMIDIPlayIndexList.GetNextPlayMIDIIndex(CBFMidiNum - 1)

                'コンボボックス選択
                cboTitle.SelectedIndex = NextPlayIndex

                '再生
                Call MIDIPlayStart
            End If
        End If
    End Sub
    
End Class
