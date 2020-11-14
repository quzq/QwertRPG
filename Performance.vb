Option Strict Off
Option Explicit On 

Public Class RpgPerformAttack
    Inherits RpgPerformance

    Private m_hellTurn As Boolean = False
    Private m_hellTurnCount As Integer = 0
    Private m_treeNode(AtkPatMax) As TreeNode

    Public Function GetNode(ByVal intNum As Integer) As TreeNode
        Dim aNodeText As String
        m_treeNode(intNum).Text = GetTextForNode(intNum)
        Return m_treeNode(intNum)
    End Function

    Private Function GetTextForNode(ByVal intNum As Integer) As String
        Dim strResult As String = ""
        If (intNum <= AtkPatMax) Then
            strResult = strName(intNum)
            If (intLevel(intNum) < intLevelMax(intNum)) Then
                strResult = strResult & " ( " & CStr(intExp(intNum)) & "%)"
            Else
                strResult = strResult & " (Master)"
            End If
        End If
        Return strResult
    End Function

    Private Sub Class_Initialize_Renamed()
        'No.0
        strName(0) = "�a��"
        strAnimImg(0) = "at001.gif"
        intLevelMax(0) = 9
        intLossMp(0) = 0
        strHelp(0) = "���ɓ����̂Ȃ��U���B�B��A���_�͂�����Ȃ��B"
        'No.
        strName(1) = "�˂�"
        strAnimImg(1) = "at003.gif"
        intLevelMax(1) = 9
        intLossMp(1) = 2
        strHelp(1) = "�u�a��i�؂�j�v��肿����Ƃ��������B"
        '�n���˂�()
        strName(2) = "�n���˂�"
        strAnimImg(2) = "at005.gif"
        intLevelMax(2) = 9
        intLossMp(2) = 3
        strHelp(2) = "���m��4��Ɉ�x�A�G�ɒn����������B����ȊO�́A50%�̍U���́B"
        '
        strName(3) = "�]�V���Ƃ�"
        strAnimImg(3) = "at002.gif"
        intLevelMax(3) = 9
        intLossMp(3) = 0
        strHelp(3) = "�]�V�ɏՌ��������A���W�����ӂ��B"
        '
        strName(4) = "�Ռ��g"
        strAnimImg(4) = "at004.gif"
        intLevelMax(4) = 9
        intLossMp(4) = 2
        strHelp(4) = "�Ռ��g��^���A��������̑g�D��j�󂷂�B"
        '
        strName(5) = "�^��g"
        strAnimImg(5) = "at011.gif"
        intLevelMax(5) = 9
        intLossMp(5) = 2
        strHelp(5) = "�^��g�ɂ��A�ْf����B"
        '
        strName(6) = "�n����"
        strAnimImg(6) = "at012.gif"
        intLevelMax(6) = 9
        intLossMp(6) = 2
        strHelp(6) = "�G�̑������������A�G�́B"
        '�Ή�
        strName(31) = "�Ή�"
        strAnimImg(31) = "mg001.gif"
        intLevelMax(31) = 7
        intLossMp(31) = 10
        strHelp(31) = "�f��������D��������Ή��B���M�̉��͊�����n�����Ƃ����B"
        '�j�[�h��
        strName(32) = "�j�[�h��"
        strAnimImg(32) = "mg004.gif"
        intLevelMax(32) = 7
        intLossMp(32) = 10
        strHelp(32) = "�f��������D��������Ή��B���M�̉��͊�����n�����Ƃ����B"
        '�f�X
        strName(33) = "�f�X"
        strAnimImg(33) = "at009.gif"
        intLevelMax(33) = 9
        intLossMp(33) = 8
        strHelp(33) = "���_�̗͂��؂�ēG�𑦎�������B�������̓��x���ɔ�Ⴗ��B"
        '���_����
        strName(34) = "���_"
        strAnimImg(34) = "at010.gif"
        intLevelMax(34) = 9
        intLossMp(34) = 8
        strHelp(34) = "���_�����҂��ēG�𑦎�������B�������̓��x���ɔ�Ⴗ��B"
        '�Ɖ�
        strName(35) = "�Ɖ�"
        strAnimImg(35) = "mg002.gif"
        intLevelMax(35) = 7
        intLossMp(35) = 10
        strHelp(35) = "���������Ă��s�����Ƃ�����Ή��B"

        '�ΎR�e
        strName(36) = "�ΎR�e"
        strAnimImg(36) = "mg005.gif"
        intLevelMax(36) = 7
        intLossMp(36) = 10
        strHelp(36) = "�ΎR�e�B"

        '�֌Â̋��l
        strName(37) = "�֌Â̋��l"
        strAnimImg(37) = "mg006.gif"
        intLevelMax(37) = 7
        intLossMp(37) = 10
        strHelp(37) = "�֌Â̋��l�B"

    End Sub

    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
        Dim intCounter As Integer
        For intCounter = 0 To AtkPatMax
            m_treeNode(intCounter) = New TreeNode()
        Next intCounter
    End Sub

    Public Overrides Function UseAttack(ByRef intPattern As Integer, ByRef intPoint As Integer, ByVal target As Character) As Integer
        Select Case intPattern
            Case 0
                UseAttack = intPoint * (100 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 1
                UseAttack = intPoint * (130 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 2
                If (m_hellTurn) Then
                    UseAttack *= (1 + intLevel(intPattern) / 3)
                Else
                    UseAttack /= 2
                End If
                UseAttack = intPoint * (130 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 3
                UseAttack = intPoint * (100 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 4
                UseAttack = intPoint * (130 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 5
                UseAttack = intPoint * (100 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 6
                UseAttack = intPoint * (130 + ((intLevel(intPattern) - 9) * 3)) / 100
            Case 31
                UseAttack = fncAddRandam(15 + intLevel(intPattern) * 3, 20)
            Case 32
                UseAttack = fncAddRandam(15 + intLevel(intPattern) * 3, 20)
            Case 33
                UseAttack = target.Hp
            Case 34
                UseAttack = target.Hp
            Case 35
                UseAttack = fncAddRandam(15 + intLevel(intPattern) * 3, 20)
            Case 36	'�ΎR�e
                UseAttack = fncAddRandam(15 + intLevel(intPattern) * 3, 20)
            Case 37	'�֌Â̋��l
                UseAttack = fncAddRandam(15 + intLevel(intPattern) * 3, 20)
        End Select

    End Function

    Public Overrides Sub Animation(ByRef background As System.Windows.Forms.PictureBox, ByVal intNum As Integer, ByRef chrTarget As Character)
        Dim intRet As Integer
        Dim intCounter As Integer
        Dim intHeight As Integer
        Dim intWidth As Integer
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim intCountMax As Integer

        Dim animCellBack As PictureBox = New PictureBox()
        Dim animCellFront As PictureBox = New PictureBox()
        Dim atkSound As WavPlay

        If (intNum = -1) Then intNum = 0

        If (intNum = 2) Then
            m_hellTurnCount += 1
            If (m_hellTurnCount = 4) Then
                m_hellTurnCount = 0
                m_hellTurn = True
            Else
                m_hellTurn = False
            End If
        End If
        With animCellFront
            'If (intNum = 2 And m_hellTurn = False) Then
            '    intRet = fncLoadPictureToImage(animCellFront, "image\at006.gif")
            'Else
            intRet = fncLoadPictureToImage(animCellFront, "image\" & strAnimImg(intNum))
            'End If
            .Width = .Image.Width
            .Height = .Image.Height
            .BackColor = Color.Transparent
        End With
        With animCellBack
            'If (intNum = 2 And m_hellTurn = False) Then
            '    intRet = fncLoadPictureToImage(animCellBack, "image\at006.gif")
            'Else
            intRet = fncLoadPictureToImage(animCellBack, "image\" & strAnimImg(intNum))
            'End If
            .Width = .Image.Width
            .Height = .Image.Height
            .BackColor = Color.Transparent
        End With
        '
        chrTarget.Printer.Looks.Controls.Add(animCellFront)
        background.Controls.Add(animCellBack)

        With chrTarget.Printer.Looks
            intLeft = .Left
            intTop = .Top
            intWidth = .Width
            intHeight = .Height
        End With

        'intTop = 0
        'intLeft = 0
        Select Case intNum
            Case 0 '�a��
                animCellBack.Left = intLeft + intWidth / 2
                animCellFront.Left = intWidth / 2
                For intCounter = 0 To intHeight Step 16
                    animCellFront.Top = intCounter - animCellBack.Height
                    animCellBack.Top = (intTop - animCellBack.Height) + intCounter
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(10)
                Next
            Case 1 '�˂�
                animCellBack.Top = intTop + intHeight / 2
                animCellFront.Top = intHeight / 2
                For intCounter = intWidth To 0 Step -16
                    animCellBack.Left = intLeft + intCounter
                    animCellFront.Left = intCounter
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
            Case 2 '�n���˂�
                animCellBack.Top = intTop + intHeight / 2
                animCellFront.Top = intHeight / 2
                For intCounter = intWidth To 0 Step -16
                    animCellBack.Left = intLeft + intCounter
                    animCellFront.Left = intCounter
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
                If (m_hellTurn) Then
                    intRet = fncLoadPictureToImage(animCellFront, "image\at008.gif")
                    intRet = fncLoadPictureToImage(animCellBack, "image\at008.gif")
                    animCellBack.Left = intLeft + intWidth / 2 - animCellBack.Image.Width / 2
                    animCellFront.Left = intWidth / 2 - animCellFront.Image.Width / 2
                    animCellBack.Width = animCellBack.Image.Width
                    animCellBack.Height = animCellBack.Image.Height
                    animCellFront.Width = animCellFront.Image.Width
                    animCellFront.Height = animCellFront.Image.Height
                    For intCounter = 0 To 16
                        animCellFront.Top = -intCounter
                        animCellBack.Top = intTop - intCounter
                        animCellBack.Refresh()
                        animCellFront.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                        System.Threading.Thread.Sleep(30)
                    Next
                End If
            Case 3 '�a��
                animCellBack.Left = intLeft + intWidth / 2
                animCellFront.Left = intWidth / 2
                For intCounter = 0 To intHeight Step 16
                    animCellFront.Top = intCounter - animCellBack.Height
                    animCellBack.Top = (intTop - animCellBack.Height) + intCounter
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(10)
                Next
            Case 4 '�˂�
                animCellBack.Top = intTop + intHeight / 2
                animCellFront.Top = intHeight / 2
                For intCounter = intWidth To 0 Step -16
                    animCellBack.Left = intLeft + intCounter
                    animCellFront.Left = intCounter
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
            Case 5, 6 '�X���C�f�B���O
                animCellBack.Top = intTop + intHeight - animCellBack.Image.Height
                animCellFront.Top = intHeight - animCellBack.Image.Height
                For intCounter = intWidth To 0 Step -16
                    animCellBack.Left = intLeft + intCounter
                    animCellFront.Left = intCounter
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
            Case 31 '�Ή�
                atkSound = New WavPlay("sounds\at004.wav")
                animCellBack.Top = intTop + intHeight
                animCellBack.Left = intLeft + intWidth / 4
                animCellFront.Top = intHeight
                animCellFront.Left = 0 'intWidth / 4
                intCountMax = animCellFront.Height
                For intCounter = 0 To intCountMax Step intCountMax / 5
                    animCellBack.Top = intTop + intHeight - intCounter
                    animCellBack.Height = intCounter
                    animCellFront.Top = intHeight - intCounter
                    animCellFront.Height = intCounter
                    'chrTarget.PrinterLooks.Refresh()
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
                System.Threading.Thread.Sleep(500)

            Case 32 '�j�[�h��
                atkSound = New WavPlay("sounds\at004.wav")
                animCellBack.Top = intTop + intHeight
                animCellBack.Left = intLeft + intWidth / 4
                animCellFront.Top = intHeight
                animCellFront.Left = intWidth / 4
                intCountMax = animCellFront.Height
                For intCounter = 0 To intCountMax Step intCountMax / 10
                    animCellBack.Top = intTop + intHeight - intCounter
                    animCellBack.Height = intCounter
                    animCellFront.Top = intHeight - intCounter
                    animCellFront.Height = intCounter
                    'chrTarget.PrinterLooks.Refresh()
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
                System.Threading.Thread.Sleep(800)
            Case 33
                Dim rndParam As System.Random = New System.Random()
                animCellBack.Top = intTop
                animCellFront.Top = 0
                For intCounter = 0 To 20
                    animCellBack.Left = intLeft + rndParam.Next(-5, 5)
                    animCellFront.Left = rndParam.Next(-5, 5)
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next
            Case 34
                animCellBack.Top = 0
                animCellFront.Top = -intTop
                animCellBack.Left = 0
                animCellFront.Left = -intLeft
                For intCounter = 0 To 20
                    animCellBack.Top += intCounter / 2
                    animCellFront.Top += intCounter / 2
                    animCellFront.Refresh()
                    animCellBack.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next

            Case 36 '�ΎR�e
                Dim posX As Integer
                Dim posY As Integer
                Dim animCnt As Integer
                animCnt = animCellFront.Image.Height * 2 + intHeight
                posY = animCellFront.Image.Height
                posX = animCellFront.Image.Width
                For intCounter = animCnt To 0 Step -8
                    animCellBack.Left = intLeft - posX + intCounter
                    animCellBack.Top = intTop + posY - intCounter + intWidth
                    animCellBack.Refresh()
                    animCellFront.Left = -posX + intCounter
                    animCellFront.Top = posY - intCounter + intWidth
                    animCellFront.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next

            Case 37 '�֌Â̋��l
                animCellBack.Top = intTop + intHeight
                animCellBack.Left = intLeft
                animCellFront.Top = intHeight
                animCellFront.Left = 0
                For intCounter = 0 To 50
                    animCellBack.Top -= intCounter / 2
                    animCellBack.Refresh()
                    animCellFront.Top -= intCounter / 2
                    animCellFront.Refresh()
                    System.Threading.Thread.Sleep(10)
                    System.Windows.Forms.Application.DoEvents()
                Next

            Case Else
        End Select

        '�A�j���[�V�����p�s�N�`���[�{�b�N�X��e����؂藣���A����
        chrTarget.Printer.Looks.Controls.Remove(animCellFront)
        background.Controls.Remove(animCellBack)
        animCellFront = Nothing
        animCellBack = Nothing
    End Sub

    Public Overrides Function AddExp(ByRef intPattern As Integer) As Integer
        If (intLevel(intPattern) < intLevelMax(intPattern)) Then
            intExp(intPattern) = intExp(intPattern) + 5
            If (intExp(intPattern) >= 100) Then
                intLevel(intPattern) = intLevel(intPattern) + 1
                intExp(intPattern) = 0
            End If
        End If
        m_treeNode(intPattern).Text = GetTextForNode(intPattern)
    End Function

End Class


Public MustInherit Class RpgPerformance

    Friend strName(AtkPatMax) As String
    Friend strAnimImg(AtkPatMax) As String
    Friend intLevel(AtkPatMax) As Integer
    Friend intLevelMax(AtkPatMax) As Integer
    Friend intExp(AtkPatMax) As Integer
    Friend intLossMp(AtkPatMax) As Integer
    Friend strHelp(AtkPatMax) As String

    '***********************�v���p�e�B�錾��***********************
    Public ReadOnly Property Name(ByVal intNum As Integer) As String
        Get
            If (intNum <= AtkPatMax) Then
                Name = strName(intNum)
            End If
        End Get
    End Property

    Public ReadOnly Property Level(ByVal intNum As Integer) As Integer
        Get
            If (intNum <= AtkPatMax) Then
                Level = intLevel(intNum)
            End If
        End Get
    End Property
    Public ReadOnly Property Exp(ByVal intNum As Integer) As Integer
        Get
            If (intNum <= AtkPatMax) Then
                Exp = intExp(intNum)
            End If
        End Get
    End Property
    Public ReadOnly Property Help(ByVal intNum As Integer) As String
        Get
            If (intNum <= AtkPatMax) Then
                Help = strHelp(intNum)
            End If
        End Get
    End Property
    Public ReadOnly Property LossMp(ByVal intNum As Integer) As Integer
        Get
            If (intNum <= AtkPatMax) Then
                LossMp = intLossMp(intNum)
            End If
        End Get
    End Property

    Public WriteOnly Property Enabled() As Integer
        Set(ByVal Value As Integer)
            If (Value <= AtkPatMax) Then
                intLevel(Value) = 1
            End If
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub Init()
        Dim intCounter As Integer

        For intCounter = 0 To UBound(intLevel)
            intLevel(intCounter) = 0
            intExp(intCounter) = 0
        Next intCounter
        'intLevel(0) = 1 '�u�a��v��L��
        'intLevel(1) = 1 '�u�����v��L��

    End Sub

    Public MustOverride Function UseAttack(ByRef intPattern As Integer, ByRef intPoint As Integer, ByVal target As Character) As Integer

    Public MustOverride Function AddExp(ByRef intPattern As Integer) As Integer

    Public MustOverride Sub Animation(ByRef background As System.Windows.Forms.PictureBox, ByVal intNum As Integer, ByRef chrTarget As Character)

    Public Function GetParam() As String
        Try
            Dim strTemp(AtkPatMax * 2 + 1) As String
            Dim intCounter As Integer
            '�p�����[�^�擾

            For intCounter = 0 To AtkPatMax
                strTemp(intCounter * 2) = Trim(CStr(intLevel(intCounter)))
                strTemp(intCounter * 2 + 1) = Trim(CStr(intExp(intCounter)))
            Next intCounter
            GetParam = Join(strTemp, ",")
        Catch ex As Exception
            Call subErrHandle("SetParam", Err.Number, Err.Description)
        End Try
    End Function

    'CSV�f�[�^���擾
    Public Function SetParam(ByRef strData As String) As Integer
        Try
            Dim intRet As Integer
            Dim strTemp() As String
            Dim intCounter As Integer
            '�p�����[�^�擾

            strTemp = Split(strData, ",")

            For intCounter = 0 To AtkPatMax
                intLevel(intCounter) = CInt(strTemp(intCounter * 2))
                intExp(intCounter) = CInt(strTemp(intCounter * 2 + 1))
            Next intCounter
        Catch ex As Exception
            Call subErrHandle("SetParam", Err.Number, Err.Description)
        End Try
    End Function
End Class
