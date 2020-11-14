Option Strict Off
Option Explicit On 

Public Class GraphicalMeter
    Inherits System.Windows.Forms.UserControl

    Private m_maxValue As Integer = 0
    Private m_value As Integer = 0

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    'UserControl �̓R���|�[�l���g�ꗗ���������邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    ' Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^�͎g�p���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'GraphicalMeter
        '
        Me.Name = "GraphicalMeter"
        Me.Size = New System.Drawing.Size(150, 24)

    End Sub

#End Region

    Public Property MaxValue() As Integer
        Get
            MaxValue = m_maxValue
        End Get
        Set(ByVal value As Integer)
            m_maxValue = value
            Me.Refresh()
        End Set
    End Property

    Public Property RestValue() As Integer
        Get
            RestValue = m_value
        End Get
        Set(ByVal value As Integer)
            m_value = value
            Me.Refresh()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        Dim brsh As Brush '���ʂ̃v����
        Dim gbrsh As Drawing.Drawing2D.LinearGradientBrush '�O���f�[�V����
        Dim p1 As New Point(0, 0), p2 As New Point(Me.Width, Me.Height)
        Dim grph As Graphics = Me.CreateGraphics
        ' �`��c�[�����������܂�
        brsh = New SolidBrush(Color.DarkBlue)
        gbrsh = New Drawing2D.LinearGradientBrush(p1, p2, Color.Red, Color.Yellow)
        ' �`�悵�܂�
        grph.FillRectangle(brsh, 0, 0, Me.Width, Me.Height)
        If (m_maxValue > 0) Then
            Dim intWidth As Integer = Me.Width * (m_value / m_maxValue)
            grph.FillRectangle(gbrsh, 0, 0, intWidth, Me.Height)
        Else
            grph.FillRectangle(brsh, 0, 0, Me.Width, Me.Height)
        End If
    End Sub

End Class
