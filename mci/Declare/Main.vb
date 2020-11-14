Option Explicit

Imports Microsoft.VisualBasic

Public Module Main
    Public Const APP_TITLE  As String = "Jukebox - Version Minus 0.004"

    '*******************************************
    '       一番最初に呼ばれる関数、基点
    '*******************************************
    Public Sub Main()
        '二重起動チェック
        If IsPreInstance(APP_TITLE) Then Exit Sub

        If Dir$(GetCurrentDir & CbfFileUtility.CBFFILE_NAME) = "" Then
            Call MsgBox(GetCurrentDir & " に " & _
                        CbfFileUtility.CBFFILE_NAME & " ファイルが見つかりません")
            Exit Sub
        End If

        System.Windows.Forms.Application.Run(New JukeboxFormMain())
    End Sub
End Module
