Option Strict Off
Option Explicit On 

Module mdlCommon
	'API
    'Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	'現時点での対応-BMP、GIF、JPEG、PNG
	
    '==============================================
    '誤差加工
    Public Function fncAddRandam(ByRef Value As Integer, ByRef Per As Integer) As Integer
        On Error GoTo Err_fncAddRandam
        fncAddRandam = Value + (Value * (Rnd() * Per * 2 - Per) / 100)

Exit_fncAddRandam:
        Exit Function
Err_fncAddRandam:
        Call subErrHandle("fncAddRandam", Err.Number, Err.Description)
        Resume Exit_fncAddRandam
    End Function
    '
    Public Sub subSetMessage(ByRef txtTarget As System.Windows.Forms.Label, ByRef strMes As String, ByRef intMode As Integer)
        On Error GoTo Err_subSetMessage
        If (intMode = cstOverWrite) Then
            txtTarget.Text = strMes & vbCr & vbLf
        ElseIf (intMode = cstUpdate) Then
            txtTarget.Text = txtTarget.Text & strMes & vbCr & vbLf
        End If
Exit_subSetMessage:
        Exit Sub
Err_subSetMessage:
        Call subErrHandle("subSetMessage", Err.Number, Err.Description)
        Resume Exit_subSetMessage
    End Sub

    '======================================================================
    'エラーハンドル用メッセージ
    Public Sub subErrHandle(ByRef strFunctionName As String, ByRef sglErrorNum As Single, ByRef strErrorMessage As String)
        On Error GoTo Err_subErrHandle
        Dim intRet As Integer
        intRet = fncCallMessage(strFunctionName & ":[" & Str(sglErrorNum) & "]" & strErrorMessage, MsgBoxStyle.Critical, "致命的なエラー")

Exit_subErrHandle:
        Exit Sub
Err_subErrHandle:
        'Call subErrHandle("subErrHandle", Err.Number, Err.Description)
        Resume Exit_subErrHandle
    End Sub

    '===========================================================
    '
    'メッセージボックスコール
    '
    '===========================================================
    '       strMessage As String    表示メッセージ（メッセージボックス引数）
    '       lngParam As Long                パラメータ（メッセージボックス引数）
    '       strTitle As String              タイトル（メッセージボックス引数）
    Public Function fncCallMessage(ByRef strMessage As String, ByRef lngParam As Integer, ByRef strTitle As String) As Integer
        On Error GoTo Err_fncCallMessage

        Dim intRet As Integer

        fncCallMessage = MsgBox(strMessage, lngParam, strTitle)

Exit_fncCallMessage:
        Exit Function

Err_fncCallMessage:
        Call subErrHandle("fncCallMessage", Err.Number, Err.Description)
        Resume Exit_fncCallMessage
    End Function
    '
    Public Function fncLoadPictureToImage(ByRef imgTarget As System.Windows.Forms.PictureBox, ByRef strFilename As String) As Integer
        On Error GoTo Err_fncLoadPictureToImage
        imgTarget.Visible = False
        imgTarget.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\" & strFilename)
        'System.Windows.Forms.Application.DoEvents()
        imgTarget.Visible = True
Exit_fncLoadPictureToImage:
        Exit Function
Err_fncLoadPictureToImage:
        Call subErrHandle("fncLoadPictureToImage", Err.Number, Err.Description)
        Resume Exit_fncLoadPictureToImage
    End Function
    '============================================
    'ファイル存在チェック関数
    Public Function fncFileExists(ByRef strFilename As String) As Integer
        On Error GoTo Err_fncFileExists
        Dim lngRet As Integer

        fncFileExists = cstOK

        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"' をクリックしてください。
        If Dir(strFilename, FileAttribute.Normal) <> "" Then
        Else
            fncFileExists = cstNG
        End If

        lngRet = FileLen(strFilename) - 1
        If lngRet <= 0 Then
            fncFileExists = cstNG
        End If
Exit_fncFileExists:
        Exit Function

Err_fncFileExists:
        Call subErrHandle("fncFileExists", Err.Number, Err.Description)
        Resume Exit_fncFileExists
    End Function

    '******************************************************************************
    '引　数　　pdblX：切り上げ対象
    '　　　　　pintN：切り上げする桁位置（小数点以下は正数、1の位以上は負数で渡す）
    '戻り値　　切り上げ結果
    '******************************************************************************
    Public Function fncRoundUp(ByRef pdblX As Double, ByRef pintN As Integer) As Double
        Dim dblS As Double

        '小数点以下で切り上げる時
        If pintN > 0 Then
            dblS = 10 ^ (pintN - 1)

            '1の位以上で切り上げる時
        ElseIf pintN < 0 Then
            dblS = 10 ^ pintN

            '切り上げする桁位置が0の時（エラーとする）
        Else
            Exit Function
        End If

        fncRoundUp = Int(pdblX * dblS + 0.9) / dblS
    End Function
End Module