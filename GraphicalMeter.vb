Option Strict Off
Option Explicit On 

Public Class GraphicalMeter
    Inherits System.Windows.Forms.UserControl

    Private m_maxValue As Integer = 0
    Private m_value As Integer = 0

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    'UserControl はコンポーネント一覧を消去するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    ' Windows フォーム デザイナを使って変更してください。  
    ' コード エディタは使用しないでください。
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
        Dim brsh As Brush '普通のプラン
        Dim gbrsh As Drawing.Drawing2D.LinearGradientBrush 'グラデーション
        Dim p1 As New Point(0, 0), p2 As New Point(Me.Width, Me.Height)
        Dim grph As Graphics = Me.CreateGraphics
        ' 描画ツールを準備します
        brsh = New SolidBrush(Color.DarkBlue)
        gbrsh = New Drawing2D.LinearGradientBrush(p1, p2, Color.Red, Color.Yellow)
        ' 描画します
        grph.FillRectangle(brsh, 0, 0, Me.Width, Me.Height)
        If (m_maxValue > 0) Then
            Dim intWidth As Integer = Me.Width * (m_value / m_maxValue)
            grph.FillRectangle(gbrsh, 0, 0, intWidth, Me.Height)
        Else
            grph.FillRectangle(brsh, 0, 0, Me.Width, Me.Height)
        End If
    End Sub

End Class
