Option Strict Off
Option Explicit On 

Public Class WavPlay

    Private Declare Function sndPlaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal lpszSoundName As String, ByVal uFlags As Integer) As Integer

    Private Const SND_SYNC As Integer = &H0S '�T�E���h���I������܂Ő����Ԃ��Ȃ�
    Private Const SND_ASYNC As Integer = &H1S '�T�E���h�J�n�Ɠ����ɐ����Ԃ�
    Private Const SND_NODEFAULT As Integer = &H2S '�T�E���h�t�@�C����������Ȃ��Ƃ��A�f�t�H���g�̃T�E���h���Đ����Ȃ�
    Private Const SND_MEMORY As Integer = &H4S '�������[�o�b�t�@����T�E���h���Đ�����
    Private Const SND_LOOP As Integer = &H8S '�T�E���h��A���I�Ƀ��[�v����iSND_ASYNC�ƕ��p����)
    Private Const SND_NOSTOP As Integer = &H10S '�ʂ̃T�E���h���Đ����邽�߂Ɍ��݂̃T�E���h���~���Ȃ�

    Public Sub New(ByVal filename As String)
        Dim result As Integer
        result = sndPlaySound(filename, SND_ASYNC Or SND_NODEFAULT)
    End Sub
End Class
