Public Class FlexPicture
    Inherits PictureBox

    Public Enum PicturePosition
        TopLeft
        TopCenter
        TopRight
        MiddleLeft
        MiddleCenter
        MiddleRight
        BottomLeft
        BottomCenter
        BottomRight
    End Enum

    Private Structure PosRect
        Dim Left As Single
        Dim Top As Single
        Dim Width As Single
        Dim Height As Single
    End Structure

    Private m_position As PicturePosition = PicturePosition.TopRight
    Private m_image As Image
    Private m_imageRect As PosRect

    Public Property Position() As PicturePosition
        Get
            Return m_position
        End Get
        Set(ByVal Value As PicturePosition)
            m_position = Value
        End Set
    End Property

    Public Property Picture() As Image
        Get
            Picture = m_image
        End Get
        Set(ByVal Value As Image)
            m_image = Value
            With m_imageRect
                .Width = m_image.Width
                .Height = m_image.Height
                Select Case m_position
                    Case PicturePosition.TopLeft
                        .Top = 0
                        .Left = 0
                    Case PicturePosition.TopRight
                        .Top = 0
                        .Left = Me.Width - .Width
                    Case PicturePosition.TopCenter
                        .Top = 0
                        .Left = (Me.Width - .Width) / 2
                    Case PicturePosition.MiddleLeft
                        .Top = (Me.Height - .Height) / 2
                        .Left = 0
                    Case PicturePosition.MiddleRight
                        .Top = (Me.Height - .Height) / 2
                        .Left = Me.Width - .Width
                    Case PicturePosition.MiddleCenter
                        .Top = (Me.Height - .Height) / 2
                        .Left = (Me.Width - .Width) / 2
                    Case PicturePosition.BottomLeft
                        .Top = (Me.Height - .Height)
                        .Left = 0
                    Case PicturePosition.BottomRight
                        .Top = (Me.Height - .Height)
                        .Left = Me.Width - .Width
                    Case PicturePosition.BottomCenter
                        .Top = (Me.Height - .Height)
                        .Left = (Me.Width - .Width) / 2
                End Select
            End With
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        Dim brsh As Brush '普通のプラン
        Dim gbrsh As Drawing.Drawing2D.LinearGradientBrush 'グラデーション
        Dim p1 As New Point(0, 0), p2 As New Point(Me.Width, Me.Height)
        Dim grph As Graphics = Me.CreateGraphics
        Dim aPoint As System.Drawing.PointF = New System.Drawing.PointF()
        aPoint.X = m_imageRect.Left
        aPoint.Y = m_imageRect.Top

        ' 描画ツールを準備します
        'brsh = New SolidBrush(Color.Green)
        'gbrsh = New Drawing2D.LinearGradientBrush(p1, p2, Color.Red, Color.Yellow)
        ' 描画します
        'grph.FillRectangle(brsh, 0, 0, Me.Width, Me.Height)
        grph.DrawImage(m_image, aPoint.X, aPoint.Y)

    End Sub

    Public Sub New()
        'Me.Picture = System.Drawing.Image.FromFile("E:\user\Develop\image_back\death.gif")
    End Sub
End Class
