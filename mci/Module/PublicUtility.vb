Option Explicit

Imports System
Imports System.IO.Directory
Imports Microsoft.VisualBasic

Public Module PublicUtility
    'API関数と定数はとりあえずここに書く
    '構造体は Structure.vb に書く
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Long) As Integer
    Private Declare Function ReleaseCapture Lib "user32" Alias "ReleaseCapture" () As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As System.IntPtr
    Private Declare Function SetForegroundWindow Lib "user32" Alias "SetForegroundWindow" (ByVal hwnd As System.IntPtr) As Integer

    Private Declare Function GetSystemMetrics Lib "user32" (ByVal nIndex As Integer) As Integer 
    Private Declare Function GetWindowRect Lib "user32" (ByVal hwnd As System.IntPtr, ByRef lpRect As RECT) As Integer 
    Private Declare Function MoveWindow Lib "user32" (ByVal hwnd As System.IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Integer) As Integer 

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1 
    Private Const HTCAPTION As Integer = 2
    
    Public Const MM_MCINOTIFY = &H3B9
    Public Const MCI_NOTIFY_SUCCESSFUL = &H1

    Private Const SM_CXSCREEN = 0
    Private Const SM_CYSCREEN = 1
    Private Const SM_CXFULLSCREEN = 16
    Private Const SM_CYFULLSCREEN = 17

    'メニュー最大アイテム数
    Public Const MAX_PLAY_LIST_NUM As Long = 20

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： IsPreInstance
    ' 機  能： 二重起動チェックを行う
    ' 引  数： (i)AppTitle  … ウィンドウタイトル
    '          (i)ClassName … クラス名
    '          (i)IsActive  … True：既に起動済みであればそのウィンドウを
    '                               最前面に表示する
    ' 返り値： True：二重起動      False：二重起動ではない
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function IsPreInstance(ByVal AppTitle As String, _
                                  Optional ByVal ClassName As String = vbNullString, _
                                  Optional ByVal IsActive As Boolean = True)
        Dim hWnd As System.IntPtr = FindWindow(ClassName, AppTitle)
        If hWnd.ToInt32 > 0 Then
            IsPreInstance = True
            If IsActive Then Call SetForegroundWindow(hWnd)
        End If
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： WindowDragOn
    ' 機  能： ウィンドウごとドラッグする
    ' 引  数： (i)hWnd …  ウィンドウハンドル
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub WindowDragOn(ByVal hWnd As System.IntPtr)
        Call ReleaseCapture
        Call SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： IsExistPlaylist
    ' 機  能： Playlist\*.playlist が存在するか判定する
    ' 引  数： なし
    ' 返り値： 存在する：True  存在しない：False
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function IsExistPlaylist As Boolean
        Dim PlaylistFiles() As String

        Try
            PlaylistFiles = GetFiles(GetPlaylistDir, "*.playlist")
            IsExistPlaylist = (PlaylistFiles.length > 0)
        Catch ex As Exception
            'なにもしない
        End Try
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetCurrentDir
    ' 機  能： カレントディレクトリを取得する
    ' 引  数： なし
    ' 返り値： カレントディレクトリ
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function GetCurrentDir As String
        Dim FilePath As String
        FilePath = System.IO.Directory.GetCurrentDirectory()
        If Right$(FilePath, 1) <> "\" Then FilePath = FilePath & "\"
        GetCurrentDir = FilePath
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetPlaylistDir
    ' 機  能： Playlist ディレクトリを取得する
    ' 引  数： なし
    ' 返り値： Playlist ディレクトリ
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function GetPlaylistDir As String
        GetPlaylistDir = GetCurrentDir & "Playlist\"
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： ReadSubMenuCaption
    ' 機  能： サブメニューに表示するテキストを *.Playlist より取得する
    ' 引  数： (o)udtPlaylist … PlaylistMenuInfo 構造体
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub ReadSubMenuCaption(ByRef udtPlaylist() As PlaylistMenuInfo)
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim PlaylistDir As String
        Dim PlaylistFile As String
        Dim MenuCaption As String
        Dim MenuCounter As Long
        Dim PlaylistFiles() As String
        Dim udtTempPlaylist As PlaylistMenuInfo
        
        'プレイリストディレクトリを取得
        PlaylistDir = GetPlaylistDir

        'プレイリストディレクトリ以下の *.Playlist ファイルを取得する
        PlaylistFiles = GetFiles(PlaylistDir, "*.playlist")
        For Each PlaylistFile In PlaylistFiles
            'メニューキャプションを取得する
            MenuCaption = GetMenuCaption(PlaylistFile)
            If MenuCaption <> "" Then
                If MenuCounter = 0 Then
                    ReDim udtPlaylist(MenuCounter)
                    With udtPlaylist(0)
                        .Title = MenuCaption
                        .FileName = Dir$(PlaylistFile)
                    End With
                Else
                    ReDim Preserve udtPlaylist(MenuCounter)
                    With udtPlaylist(MenuCounter)
                        .Title = MenuCaption
                        .FileName = Dir$(PlaylistFile)
                    End With
                End If  
                
                MenuCounter = MenuCounter + 1
            End If
        Next

        'ソート
        If MenuCounter > 1 Then
            '構造体のファイル名でソート
            For i = UBound(udtPlaylist) To 0 Step -1
                For j = 1 To i
                    k = j - 1
                    If StrComp(udtPlaylist(k).FileName, udtPlaylist(j).FileName, vbBinaryCompare) >= 0 Then
                        '構造体メンバをごっそり入れ替え
                        udtTempPlaylist.Title = udtPlaylist(j).Title
                        udtTempPlaylist.FileName = udtPlaylist(j).FileName

                        udtPlaylist(j).FileName = udtPlaylist(k).FileName
                        udtPlaylist(j).Title = udtPlaylist(k).Title

                        udtPlaylist(k).FileName = udtTempPlaylist.Title
                        udtPlaylist(k).Title = udtTempPlaylist.FileName
                    End If
                Next j
            Next i

            'メニューは 20 まで
            If UBound(udtPlaylist) >= MAX_PLAY_LIST_NUM Then
                ReDim Preserve udtPlaylist(MAX_PLAY_LIST_NUM - 1) 
            End If
        End If
    End Sub


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetMenuCaption
    ' 機  能： プレイリストよりメニューキャプションを取得する
    ' 引  数： (i)PlaylistFile … プレイリストファイル
    ' 返り値： メニューキャプション
    ' 備  考：  ReadSubMenuCaption の下位ファンクション
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Function GetMenuCaption(ByVal PlaylistFile As String) As String
        Dim FileNum As Integer = FreeFile
        Dim LineBuff As String
        Dim ReadLine As String

        Try
            FileOpen(FileNum, PlaylistFile, OpenMode.Input)
            LineBuff = LineInput(FileNum)
            LineBuff = Trim$(LineBuff)
            If Mid$(LineBuff, 1, 1) = "#" Then
                ReadLine = Mid$(Trim$(Mid$(LineBuff, 2)), 1, 20)
            End If
        Catch ex As Exception
            Call MsgBox(ex.ToString())
            ReadLine = ""
        Finally
            Try
                FileClose(FileNum)
            Finally
            
            End Try
        End Try
        
        GetMenuCaption = ReadLine
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： ReadMIDIFileInfo
    ' 機  能： MIDIタイトル、ファイル名を取得する
    ' 引  数： (o)udtMidiInfo … MidiInfo 構造体
    ' 返り値： 正常時：True  異常時：False
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function ReadMIDIFileInfo(ByRef udtMidiInfo() As MidiInfo) As Boolean
        'クラス
        Dim clsCBFUtil As New CbfFileUtility
        Dim FuncRet As Integer
        Dim i As Integer
        Try
            Dim MIDIFileNum As Integer = clsCBFUtil.MIDINum()

            ReDim udtMidiInfo(MIDIFileNum - 1)
            FuncRet = clsCBFUtil.GetMidiHeaderInfo(udtMidiInfo, MIDIFileNum)   
            If FuncRet < 0 Then
                Call MsgBox(clsCBFUtil.GetErrorMessage(FuncRet), APP_TITLE, vbOkOnly + vbExclamation)
            Else
                ReadMIDIFileInfo = True
            End If
        Catch ex As Exception
            Call MsgBox(ex.ToString(), APP_TITLE, vbOkOnly + vbExclamation)
        End Try
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名：ReadPlaylist
    ' 機  能：*.playlist を読み込み、プレイリスト配列を作成する
    ' 引  数：(i) PlaylistFile … *.playlist ファイル
    '         (o) UserPlayList … ユーザー定義プレイリスト
    ' 戻り値  clsStringList クラス
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function ReadPlaylist(ByVal PlaylistFile As String, ByRef UserPlayList As System.Collections.ArrayList) As Boolean
        Dim FileNum As Integer = FreeFile
        Dim ReadLine As String
        Dim SharpPos As Integer

        Try
            FileOpen(FileNum, PlaylistFile, OpenMode.Input)
            
            Do While Not EOF(FileNum)
                ReadLine = LineInput(FileNum)
                ReadLine = Trim$(ReadLine)

                '空行、コメントでなければ処理
                If ReadLine <> "" And Left$(ReadLine, 1) <> "#" Then
                    '#より後ろを読み飛ばす
                    SharpPos = InStr(ReadLine, "#")
                    If SharpPos <> 0 Then
                        ReadLine = Trim$(Left$(ReadLine, SharpPos - 1))
                    End If

                    '追加
                    Call UserPlayList.Add(ReadLine)
                End If
            Loop

            ReadPlaylist = True
        Catch ex As Exception
        
        Finally
            Try
                FileClose (FileNum)
            Catch ex As Exception
            End Try
        End Try
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： MoveWindowCenter
    ' 機  能： 指定ウインドウを画面の中央に表示する
    ' 引  数： (i)hWnd       … 中央に表示するウインドウのハンドル
    '          (i)yPosDivide … Y位置の割合
    ' 返り値： なし
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub MoveWindowCenter(ByVal hWnd As System.IntPtr, _
                                Optional ByVal yPosDivide As Integer = 2)
        Dim udtRect As RECT
        Dim DesktopWidth As Integer, DesktopHeight As Integer
        Dim WindowWidth  As Integer, WindowHeight  As Integer

        'デスクトップの幅、高さを取得する(単位：Pixel)
        DesktopWidth = GetSystemMetrics(SM_CXFULLSCREEN)
        DesktopHeight = GetSystemMetrics(SM_CYFULLSCREEN)

        '指定ウインドウ領域サイズを取得する
        Call GetWindowRect(hWnd, udtRect)

        '指定ウインドウの幅、高さを取得する(単位：Pixel)
        WindowWidth = udtRect.Right - udtRect.Left
        WindowHeight = udtRect.Bottom - udtRect.Top

        Call MoveWindow(hwnd, (DesktopWidth - WindowWidth) / 2, _
                              (DesktopHeight - WindowHeight) / yPosDivide, _
                               WindowWidth, WindowHeight, 1)
    End Sub
End Module
