Public Module pDebug
    'SharpDevelop でのデバッグ方法が良く分からない。
    'デバッグ文字列はメモ帳に出す。
    Private Declare Sub pDebug Lib "pDebug.dll" Alias "#1" (ByVal DispText As String)
    Private Declare Function SetNotModify Lib "pDebug.dll" Alias "#5" () As Integer
    Private Declare Function CloseNotePad Lib "pDebug.dll" Alias "#8" () As Integer

    Public Sub out(ByVal SrcText As String)
        Call pDebug(SrcText)
        Call SetNotModify()
    End Sub

    Public Sub goodbye()
        Call CloseNotePad()
    End Sub
End Module

'クラス化する場合
'Public Class pDebug
'
'    Private Declare Sub pDebug Lib "pDebug.dll" Alias "#1" (ByVal DispText As String)
'    Private Declare Function SetNotModify Lib "pDebug.dll" Alias "#5" () As Long
'    Private Declare Function CloseNotePad Lib "pDebug.dll" Alias "#8" () As Long
'
'    Public Shared Sub out(ByVal SrcText As String)
'        Call pDebug(SrcText)
'        Call SetNotModify()
'    End Sub
'    
'    Public Shared Sub goodbye()
'        Call CloseNotePad()
'    End Sub
'End Class
