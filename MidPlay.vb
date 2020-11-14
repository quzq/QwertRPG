Option Strict Off
Option Explicit On 

Public Class MidPlay

    Private m_filename As String = ""
    Private m_loop As Boolean = True
    Private m_enabled As Boolean = True
    Private m_parentHwnd As System.IntPtr = Nothing
    Private m_timer As Windows.Forms.Timer

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrcCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

    Public Property FileName() As String
        Get
            FileName = m_filename
        End Get
        Set(ByVal Value As String)
            m_filename = Value
        End Set
    End Property

    Public Sub New()
        Me.initTimer()
    End Sub

    Public Sub New(ByVal parentHwnd As System.IntPtr)
        m_parentHwnd = parentHwnd
        Me.initTimer()
        Me.Play(FileName)
    End Sub

    Public Sub New(ByVal parentHwnd As System.IntPtr, ByVal filename As String)
        m_parentHwnd = parentHwnd
        Me.initTimer()
        Me.Play(filename)
    End Sub

    '公開プロシージャ
    Public Sub Replay()
        Me.Rewind()
        Me.Play()
    End Sub

    '公開プロシージャ
    Public Sub Play()
        Dim lngRet As Long
        '再生
        If (m_enabled) Then
            'lngRet = mciSendString("play midi NOTIFY", "", 0, 0)
        End If
    End Sub

    '公開プロシージャ
    Public Sub Play(ByVal strFile As String)
        Dim lngRet As Long

        If (strFile.Trim <> "") Then
            m_filename = strFile.Trim
            Me.Open(m_filename)
            '最初に書き戻し
            Me.Rewind()
        End If
        '再生
        Me.Play()

    End Sub

    Public Sub Open(ByVal strFile As String)
        Dim lngRet As Long
        'lngRet = mciSendString("open " & strFile & " type sequencer alias midi", "", 0, 0)
    End Sub
    '最初に書き戻し
    Public Sub Rewind()
        Dim lngRet As Long
        'lngRet = mciSendString("seek midi to 0", "", 15, 0)
    End Sub

    Public Sub StopNow()
        Dim lngRet As Long
        '停止
        'lngRet = mciSendString("stop midi ", "", 0, 0)
        Me.Close()
    End Sub
    Public Sub Close()
        Dim lngRet As Long
        '停止
        'lngRet = mciSendString("close midi", vbNullString, 0, 0)
    End Sub

    Private Sub initTimer()
        m_timer = New Windows.Forms.Timer()
        With m_timer
            .Interval = 300
            .Enabled = True
            .Start()
        End With
        AddHandler m_timer.Tick, AddressOf TickTimer
    End Sub

    Private Sub TickTimer(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '再生中かどうかをチェック
        If (Not Me.PlayingNow()) Then
            '再生
            Me.Replay()
        End If
    End Sub

    Private Function PlayingNow() As Boolean
        Dim strRts As String
        Dim lngRet As Long
        Dim strWork As String
        Dim intPos As Integer
        strWork = Space(260)
        'lngRet = mciSendString("status midi mode", strWork, 260, 0)
        intPos = strWork.IndexOf(ControlChars.NullChar) '- 1
        'strRts = Microsoft.VisualBasic.Left(strWork, intPos)
        '再生中の曲が終了したか、チェック
        If (strRts = "seeking") Then
            'System.Threading.Thread.Sleep(300)
            PlayingNow = True
        ElseIf (strRts = "playing") Then
            PlayingNow = True
        Else
            PlayingNow = False
        End If

    End Function

    Protected Overrides Sub Finalize()

        'タイマーオブジェクトの削除
        m_timer = Nothing
        Me.StopNow()
        MyBase.Finalize()
    End Sub

End Class
