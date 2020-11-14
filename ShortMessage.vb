Option Strict Off
Option Explicit On 

Public Class ShortMessage

    Private m_labels As System.Collections.ArrayList
    Private m_label As Windows.Forms.Label
    Private m_timer As Windows.Forms.Timer

    Public Property Text() As String
        Get
            Text = m_label.Text
        End Get
        Set(ByVal Value As String)
            With m_label
                .Text = Value
                If (.Text.Length = 0) Then
                    .Width = 0
                Else
                    .Width = .Font.SizeInPoints * .Text.Length + 5
                End If
                .Height = .Font.SizeInPoints + 3
                .Visible = True
            End With

            With m_timer
                .Stop()
                .Interval = 1000
                .Start()
            End With

        End Set
    End Property
    Public Property Width() As Integer
        Get
            Width = m_label.Width
        End Get
        Set(ByVal Value As Integer)
            m_label.Width = Value
        End Set
    End Property
    Public Property Height() As Integer
        Get
            Height = m_label.Width
        End Get
        Set(ByVal Value As Integer)
            m_label.Height = Value
        End Set
    End Property
    Public Property Top() As Integer
        Get
            Top = m_label.Top
        End Get
        Set(ByVal Value As Integer)
            m_label.Top = Value
        End Set
    End Property
    Public Property Left() As Integer
        Get
            Left = m_label.Left
        End Get
        Set(ByVal Value As Integer)
            m_label.Left = Value
        End Set
    End Property
    Public Property ForeColor() As System.Drawing.Color
        Get
            ForeColor = m_label.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            m_label.ForeColor = Value
        End Set
    End Property
    Public Property BackColor() As System.Drawing.Color
        Get
            BackColor = m_label.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            m_label.BackColor = Value
        End Set
    End Property
    Public Property Font() As Font
        Get
            Font = m_label.Font
        End Get
        Set(ByVal Value As Font)
            m_label.Font = Value
        End Set
    End Property

    Public Sub New(ByVal backPictBox As PictureBox)
        Dim aFont As New Font("Arial Black", 30, Drawing.FontStyle.Bold)
        'ラベル側の設定
        m_label = New Label()
        With m_label
            .BackColor = Color.Red
            .Width = 0
            .Height = 0
            .Top = 0
            .Left = 0
            .Text = ""
            .TextAlign = ContentAlignment.MiddleRight
            .Font = aFont
            .ForeColor = Color.Black
            .Visible = False
        End With
        backPictBox.Controls.Add(m_label)
        'm_labels.Add(aLabel)
        m_timer = New Windows.Forms.Timer()
        With m_timer
            .Interval = 300
            .Enabled = True
            .Start()
        End With
        AddHandler m_timer.Tick, AddressOf TickTimer
    End Sub
    'Public Sub New(ByVal aForm As Windows.Forms.Form)
    '    Dim aFont As New Font("Arial Black", 30, Drawing.FontStyle.Bold)
    '    'ラベル側の設定
    '    m_label = New Label()
    '    With m_label
    '        .BackColor = Color.Red
    '        .Width = 300
    '        .Height = 34
    '        .Top = 0
    '        .Left = 0
    '        .Text = ""
    '        .TextAlign = ContentAlignment.MiddleRight
    '        .Font = aFont
    '        .ForeColor = Color.Black
    '        .Visible = False
    '    End With
    '    aForm.Controls.Add(m_label)

    '    m_timer = New Windows.Forms.Timer()
    '    With m_timer
    '        .Enabled = True
    '        .Stop()
    '    End With
    '    AddHandler m_timer.Tick, AddressOf TickTimer

    'End Sub

    Private Sub TickTimer(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '再生中かどうかをチェック
        m_timer.Stop()
        m_label.Visible = False
        Me.Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
