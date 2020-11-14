Option Explicit

Imports Microsoft.VisualBasic

Public Class MIDIUtility
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As System.IntPtr) As Integer
    Private Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Integer, ByVal lpstrBuffer As String, ByVal uLength As Integer) As Integer
    Private Declare Function midiOutGetNumDevs Lib "winmm" () As Integer
    
    Public STATUS_PLAY  As String = "PLAYING"
    Public STATUS_PAUSE As String = "PAUSED"
    Public STATUS_STOP  As String = "STOPPED"

    Private hParentWnd As System.IntPtr
    Private MCIMessage As String
    Private IsMIDIOpen As Boolean

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' コンストラクタ
    ' 引  数： hWnd  …  親ウインドウのハンドル
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub New(ByVal hWnd As System.IntPtr)
        hParentWnd = hWnd
        IsMIDIOpen = False
    End Sub

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： IsUserMIDIDevice
    ' 機  能： MIDIデバイスを使用できるか判定する
    ' 引  数： なし
    ' 返り値： True … 使用可能  False … 使用不可
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ReadOnly Property IsUserMIDIDevice As Boolean
        Get
            IsUserMIDIDevice = (midiOutGetNumDevs > 0)
        End Get
    End Property

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： mciError
    ' 機  能： mciSendString エラーメッセージを取得する
    ' 引  数： なし
    ' 返り値： エラーメッセージ
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ReadOnly Property mciError() As String
        Get
           mciError = MCIMessage
        End Get
    End Property

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： isOpen
    ' 機  能： MIDIファイルが開いているか取得する
    ' 引  数： なし
    ' 返り値： 開いている … True  閉じている … False
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ReadOnly Property isOpen() As Boolean
        Get
           isOpen = IsMIDIOpen
        End Get
    End Property

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： CallMCISendString
    ' 機  能： API mciSendString で MIDIファイルを操作する
    ' 引  数： (i)MIDICmd … 命令文字列
    ' 返り値： 正常時 …  0   異常時  …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Private Function CallMCISendString(Byval MIDICmd As String) As Integer
        Dim MCIRet As Integer
        Dim MIDICmdRet As String
        Dim MCIError   As String
        
        MIDICmdRet = Space$(256)
        MCIError   = Space$(512)
        
        MCIRet = mciSendString(MIDICmd, MIDICmdRet, Len(MIDICmdRet), hParentWnd)
        If MCIRet <> 0 Then
            Call  mciGetErrorString(MCIRet, MCIError, Len(MCIError))
            MCIMessage = Split(MCIError, Chr(0))(0)
        Else
            MCIMessage = Split(MIDICmdRet, Chr(0))(0)
        End If
        
        CallMCISendString = MCIRet
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiOpen
    ' 機  能： MIDIファイルを開く
    ' 引  数： (i)MIDIFile … MIDIファイル
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiOpen(ByVal MIDIFile As String) As Integer
        IsMIDIOpen = True
        midiOpen = CallmciSendString("Open " & Chr(34) & MIDIFile & Chr(34) _
                            & " Alias X1 NOTIFY")
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiPlay
    ' 機  能： MIDIファイルを再生する
    ' 引  数： (i)MIDIFile … MIDIファイル
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiPlay(ByVal MIDIFile As String) As Integer
        midiPlay = midiOpen(MIDIFile)
        If midiPlay <> 0 Then Exit Function
    
        midiPlay = CallmciSendString("Play X1 NOTIFY")
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiPlay
    ' 機  能： MIDIファイルを再生する
    ' 引  数： なし
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Public Function midiPlay() As Integer
    '    midiPlay = CallmciSendString("Play X1 NOTIFY")
    'End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiStop
    ' 機  能： MIDIファイルの再生を中止する
    ' 引  数： なし
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiStop() As Integer
        
        '↓これ入れたら分ちっと切れなくなるかなと思ったけど駄目だった
        'System.Threading.Thread.Sleep(500)
        midIsTOP = CallmciSendString("Stop X1 NOTIFY")
        If midIsTOP <> 0 Then Exit Function
        
        '中止したらクローズ、返り値は見なくても大丈夫でしょ
        Call midiClose()
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiPause
    ' 機  能： MIDIファイルの再生を停止する
    ' 引  数： なし
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiPause() As Integer
        midiPause = CallmciSendString("Pause X1")
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiResume
    ' 機  能： MIDIファイルの再生停止を解除する
    ' 引  数： なし
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiResume() As Integer
        'Windows XPだと Resume 命令を MCISendString に送ると以下のようなエラーとなる
        '「使用中の MCI デバイスは指定されたコマンドをサポートしません」
        'ということで Play 命令を使用する。
        'Resume は Windows 95, Windows 98 で利用可能
        'midiResume = CallMCISendString("Resume X1 NOTIFY")
        midiResume = CallmciSendString("Play X1 NOTIFY")
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiClose
    ' 機  能： MIDIファイルを閉じる
    ' 引  数： なし
    ' 返り値： 正常時 … 0   異常時 …  0以外
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiClose() As Integer
        Dim FuncRet As Integer = (-1)
        If IsMIDIOpen Then
            FuncRet = CallmciSendString("Close X1")
            IsMIDIOpen = False
        End If  
        midiClose = FuncRet
    End Function

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： midiStatus
    ' 機  能： MIDIファイルの状態を取得する
    ' 引  数： なし
    ' 返り値：  MIDIファイルの状態を表す文字列
    '                 再生中 …  PLAYING   
    '                 停止中 …  PAUSED    
    '                 中止中 …  STOPPE
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function midiStatus() As String
        Dim MCIRet As Integer 
        MCIRet = CallmciSendString("Status X1 Mode")
        If MCIRet <> 0 Then Return ""
        midiStatus = UCase$(MCIMessage)
    End Function
End Class
