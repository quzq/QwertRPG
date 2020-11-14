Option Strict Off
Option Explicit On 

Module mdlCommon
	'API
    'Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	'�����_�ł̑Ή�-BMP�AGIF�AJPEG�APNG
	
    '==============================================
    '�덷���H
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
    '�G���[�n���h���p���b�Z�[�W
    Public Sub subErrHandle(ByRef strFunctionName As String, ByRef sglErrorNum As Single, ByRef strErrorMessage As String)
        On Error GoTo Err_subErrHandle
        Dim intRet As Integer
        intRet = fncCallMessage(strFunctionName & ":[" & Str(sglErrorNum) & "]" & strErrorMessage, MsgBoxStyle.Critical, "�v���I�ȃG���[")

Exit_subErrHandle:
        Exit Sub
Err_subErrHandle:
        'Call subErrHandle("subErrHandle", Err.Number, Err.Description)
        Resume Exit_subErrHandle
    End Sub

    '===========================================================
    '
    '���b�Z�[�W�{�b�N�X�R�[��
    '
    '===========================================================
    '       strMessage As String    �\�����b�Z�[�W�i���b�Z�[�W�{�b�N�X�����j
    '       lngParam As Long                �p�����[�^�i���b�Z�[�W�{�b�N�X�����j
    '       strTitle As String              �^�C�g���i���b�Z�[�W�{�b�N�X�����j
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
    '�t�@�C�����݃`�F�b�N�֐�
    Public Function fncFileExists(ByRef strFilename As String) As Integer
        On Error GoTo Err_fncFileExists
        Dim lngRet As Integer

        fncFileExists = cstOK

        'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"' ���N���b�N���Ă��������B
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
    '���@���@�@pdblX�F�؂�グ�Ώ�
    '�@�@�@�@�@pintN�F�؂�グ���錅�ʒu�i�����_�ȉ��͐����A1�̈ʈȏ�͕����œn���j
    '�߂�l�@�@�؂�グ����
    '******************************************************************************
    Public Function fncRoundUp(ByRef pdblX As Double, ByRef pintN As Integer) As Double
        Dim dblS As Double

        '�����_�ȉ��Ő؂�グ�鎞
        If pintN > 0 Then
            dblS = 10 ^ (pintN - 1)

            '1�̈ʈȏ�Ő؂�グ�鎞
        ElseIf pintN < 0 Then
            dblS = 10 ^ pintN

            '�؂�グ���錅�ʒu��0�̎��i�G���[�Ƃ���j
        Else
            Exit Function
        End If

        fncRoundUp = Int(pdblX * dblS + 0.9) / dblS
    End Function
End Module