Option Strict Off
Option Explicit On 

Public Class WavPlay

    Private Declare Function sndPlaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal lpszSoundName As String, ByVal uFlags As Integer) As Integer

    Private Const SND_SYNC As Integer = &H0S 'サウンドが終了するまで制御を返さない
    Private Const SND_ASYNC As Integer = &H1S 'サウンド開始と同時に制御を返す
    Private Const SND_NODEFAULT As Integer = &H2S 'サウンドファイルが見つからないとき、デフォルトのサウンドを再生しない
    Private Const SND_MEMORY As Integer = &H4S 'メモリーバッファからサウンドを再生する
    Private Const SND_LOOP As Integer = &H8S 'サウンドを連続的にループする（SND_ASYNCと併用する)
    Private Const SND_NOSTOP As Integer = &H10S '別のサウンドを再生するために現在のサウンドを停止しない

    Public Sub New(ByVal filename As String)
        Dim result As Integer
        result = sndPlaySound(filename, SND_ASYNC Or SND_NODEFAULT)
    End Sub
End Class
