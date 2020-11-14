Option Strict Off
Option Explicit On 

Public Class formTitle
    Inherits System.Windows.Forms.Form
    Public m_mainForm As formMain
    Private m_bgm As MidPlay = New MidPlay()

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は dispose をオーバーライドしてコンポーネント一覧を消去します。
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
    Public WithEvents imgBack As System.Windows.Forms.PictureBox
    Public WithEvents lblStuff4 As System.Windows.Forms.Label
    Public WithEvents lblStuff3 As System.Windows.Forms.Label
    Public WithEvents lblStuff2 As System.Windows.Forms.Label
    Public WithEvents lblStuff1 As System.Windows.Forms.Label
    Public WithEvents cmdEnd As System.Windows.Forms.Button
    Public WithEvents cmdContinue As System.Windows.Forms.Button
    Public WithEvents cmdStart As System.Windows.Forms.Button
    Public WithEvents lblTitle As System.Windows.Forms.Label
    Public WithEvents pctContena As System.Windows.Forms.Panel
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents _lblPrnDec_0 As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_1 As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_2 As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_3 As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_4 As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_5 As System.Windows.Forms.Label
    Public WithEvents lblRest As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_6 As System.Windows.Forms.Label
    Public WithEvents _lblPrnDec_7 As System.Windows.Forms.Label
    Public WithEvents imgIcon As System.Windows.Forms.PictureBox
    Public WithEvents imgArrow As System.Windows.Forms.PictureBox
    Public WithEvents _lblPrnDec_8 As System.Windows.Forms.Label
    Public WithEvents linBorder1 As System.Windows.Forms.Label
    Public WithEvents linBorder0 As System.Windows.Forms.Label
    Friend WithEvents nudCfgParam0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCfgParam1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCfgParam2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCfgParam3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCfgParam4 As System.Windows.Forms.NumericUpDown
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlexPicture1 As Qwert.nfrpg.FlexPicture
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(formTitle))
        Me.imgBack = New System.Windows.Forms.PictureBox()
        Me.lblStuff4 = New System.Windows.Forms.Label()
        Me.lblStuff3 = New System.Windows.Forms.Label()
        Me.lblStuff2 = New System.Windows.Forms.Label()
        Me.lblStuff1 = New System.Windows.Forms.Label()
        Me.cmdEnd = New System.Windows.Forms.Button()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pctContena = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudCfgParam4 = New System.Windows.Forms.NumericUpDown()
        Me.nudCfgParam3 = New System.Windows.Forms.NumericUpDown()
        Me.nudCfgParam2 = New System.Windows.Forms.NumericUpDown()
        Me.nudCfgParam1 = New System.Windows.Forms.NumericUpDown()
        Me.nudCfgParam0 = New System.Windows.Forms.NumericUpDown()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me._lblPrnDec_0 = New System.Windows.Forms.Label()
        Me._lblPrnDec_1 = New System.Windows.Forms.Label()
        Me._lblPrnDec_2 = New System.Windows.Forms.Label()
        Me._lblPrnDec_3 = New System.Windows.Forms.Label()
        Me._lblPrnDec_4 = New System.Windows.Forms.Label()
        Me._lblPrnDec_5 = New System.Windows.Forms.Label()
        Me.lblRest = New System.Windows.Forms.Label()
        Me._lblPrnDec_6 = New System.Windows.Forms.Label()
        Me._lblPrnDec_7 = New System.Windows.Forms.Label()
        Me.linBorder1 = New System.Windows.Forms.Label()
        Me.imgIcon = New System.Windows.Forms.PictureBox()
        Me.imgArrow = New System.Windows.Forms.PictureBox()
        Me._lblPrnDec_8 = New System.Windows.Forms.Label()
        Me.linBorder0 = New System.Windows.Forms.Label()
        Me.FlexPicture1 = New Qwert.nfrpg.FlexPicture()
        Me.pctContena.SuspendLayout()
        CType(Me.nudCfgParam4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCfgParam3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCfgParam2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCfgParam1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCfgParam0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgBack
        '
        Me.imgBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgBack.Image = CType(resources.GetObject("imgBack.Image"), System.Drawing.Bitmap)
        Me.imgBack.Location = New System.Drawing.Point(8, 8)
        Me.imgBack.Name = "imgBack"
        Me.imgBack.Size = New System.Drawing.Size(600, 408)
        Me.imgBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgBack.TabIndex = 35
        Me.imgBack.TabStop = False
        '
        'lblStuff4
        '
        Me.lblStuff4.BackColor = System.Drawing.Color.Transparent
        Me.lblStuff4.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStuff4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStuff4.ForeColor = System.Drawing.Color.White
        Me.lblStuff4.Location = New System.Drawing.Point(352, 288)
        Me.lblStuff4.Name = "lblStuff4"
        Me.lblStuff4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStuff4.Size = New System.Drawing.Size(113, 25)
        Me.lblStuff4.TabIndex = 63
        Me.lblStuff4.Text = "2ch-blog"
        Me.lblStuff4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStuff3
        '
        Me.lblStuff3.BackColor = System.Drawing.Color.Transparent
        Me.lblStuff3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStuff3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStuff3.ForeColor = System.Drawing.Color.White
        Me.lblStuff3.Location = New System.Drawing.Point(352, 272)
        Me.lblStuff3.Name = "lblStuff3"
        Me.lblStuff3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStuff3.Size = New System.Drawing.Size(113, 17)
        Me.lblStuff3.TabIndex = 62
        Me.lblStuff3.Text = "With"
        Me.lblStuff3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStuff2
        '
        Me.lblStuff2.BackColor = System.Drawing.Color.Transparent
        Me.lblStuff2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStuff2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStuff2.ForeColor = System.Drawing.Color.White
        Me.lblStuff2.Location = New System.Drawing.Point(352, 248)
        Me.lblStuff2.Name = "lblStuff2"
        Me.lblStuff2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStuff2.Size = New System.Drawing.Size(113, 25)
        Me.lblStuff2.TabIndex = 61
        Me.lblStuff2.Text = "QWERT"
        Me.lblStuff2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStuff1
        '
        Me.lblStuff1.BackColor = System.Drawing.Color.Transparent
        Me.lblStuff1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStuff1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStuff1.ForeColor = System.Drawing.Color.White
        Me.lblStuff1.Location = New System.Drawing.Point(352, 232)
        Me.lblStuff1.Name = "lblStuff1"
        Me.lblStuff1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStuff1.Size = New System.Drawing.Size(113, 17)
        Me.lblStuff1.TabIndex = 60
        Me.lblStuff1.Text = "Produced by"
        Me.lblStuff1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdEnd
        '
        Me.cmdEnd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnd.Location = New System.Drawing.Point(248, 296)
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnd.Size = New System.Drawing.Size(89, 25)
        Me.cmdEnd.TabIndex = 58
        Me.cmdEnd.Text = "バイバイ"
        '
        'cmdContinue
        '
        Me.cmdContinue.BackColor = System.Drawing.SystemColors.Control
        Me.cmdContinue.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdContinue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdContinue.Location = New System.Drawing.Point(200, 232)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdContinue.Size = New System.Drawing.Size(89, 25)
        Me.cmdContinue.TabIndex = 57
        Me.cmdContinue.Text = "続きから"
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart.Location = New System.Drawing.Point(224, 264)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart.Size = New System.Drawing.Size(89, 25)
        Me.cmdStart.TabIndex = 56
        Me.cmdStart.Text = "最初から"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte), True)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(64, 112)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.Size = New System.Drawing.Size(489, 105)
        Me.lblTitle.TabIndex = 59
        Me.lblTitle.Text = "QwertRPG"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pctContena
        '
        Me.pctContena.BackColor = System.Drawing.SystemColors.Control
        Me.pctContena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctContena.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.nudCfgParam4, Me.nudCfgParam3, Me.nudCfgParam2, Me.nudCfgParam1, Me.nudCfgParam0, Me.cmdCancel, Me.txtName, Me.cmdOK, Me._lblPrnDec_0, Me._lblPrnDec_1, Me._lblPrnDec_2, Me._lblPrnDec_3, Me._lblPrnDec_4, Me._lblPrnDec_5, Me.lblRest, Me._lblPrnDec_6, Me._lblPrnDec_7, Me.linBorder1, Me.imgIcon, Me.imgArrow, Me._lblPrnDec_8, Me.linBorder0})
        Me.pctContena.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctContena.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pctContena.Location = New System.Drawing.Point(640, 32)
        Me.pctContena.Name = "pctContena"
        Me.pctContena.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctContena.Size = New System.Drawing.Size(257, 352)
        Me.pctContena.TabIndex = 64
        Me.pctContena.TabStop = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(112, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "精神力："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'nudCfgParam4
        '
        Me.nudCfgParam4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nudCfgParam4.Location = New System.Drawing.Point(200, 272)
        Me.nudCfgParam4.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudCfgParam4.Name = "nudCfgParam4"
        Me.nudCfgParam4.ReadOnly = True
        Me.nudCfgParam4.Size = New System.Drawing.Size(40, 20)
        Me.nudCfgParam4.TabIndex = 37
        Me.nudCfgParam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCfgParam4.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'nudCfgParam3
        '
        Me.nudCfgParam3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nudCfgParam3.Location = New System.Drawing.Point(200, 248)
        Me.nudCfgParam3.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudCfgParam3.Name = "nudCfgParam3"
        Me.nudCfgParam3.ReadOnly = True
        Me.nudCfgParam3.Size = New System.Drawing.Size(40, 20)
        Me.nudCfgParam3.TabIndex = 36
        Me.nudCfgParam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCfgParam3.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'nudCfgParam2
        '
        Me.nudCfgParam2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nudCfgParam2.Location = New System.Drawing.Point(200, 224)
        Me.nudCfgParam2.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudCfgParam2.Name = "nudCfgParam2"
        Me.nudCfgParam2.ReadOnly = True
        Me.nudCfgParam2.Size = New System.Drawing.Size(40, 20)
        Me.nudCfgParam2.TabIndex = 35
        Me.nudCfgParam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCfgParam2.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'nudCfgParam1
        '
        Me.nudCfgParam1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nudCfgParam1.Location = New System.Drawing.Point(200, 200)
        Me.nudCfgParam1.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudCfgParam1.Name = "nudCfgParam1"
        Me.nudCfgParam1.ReadOnly = True
        Me.nudCfgParam1.Size = New System.Drawing.Size(40, 20)
        Me.nudCfgParam1.TabIndex = 34
        Me.nudCfgParam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCfgParam1.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'nudCfgParam0
        '
        Me.nudCfgParam0.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nudCfgParam0.Location = New System.Drawing.Point(200, 176)
        Me.nudCfgParam0.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nudCfgParam0.Name = "nudCfgParam0"
        Me.nudCfgParam0.ReadOnly = True
        Me.nudCfgParam0.Size = New System.Drawing.Size(40, 20)
        Me.nudCfgParam0.TabIndex = 33
        Me.nudCfgParam0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCfgParam0.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(176, 312)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(65, 25)
        Me.cmdCancel.TabIndex = 28
        Me.cmdCancel.Text = "Cancel"
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.AutoSize = False
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(8, 112)
        Me.txtName.MaxLength = 10
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(233, 25)
        Me.txtName.TabIndex = 13
        Me.txtName.Text = "オレ"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(104, 312)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(65, 25)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        '
        '_lblPrnDec_0
        '
        Me._lblPrnDec_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_0.Location = New System.Drawing.Point(8, 96)
        Me._lblPrnDec_0.Name = "_lblPrnDec_0"
        Me._lblPrnDec_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_0.Size = New System.Drawing.Size(41, 17)
        Me._lblPrnDec_0.TabIndex = 27
        Me._lblPrnDec_0.Text = "名前："
        '
        '_lblPrnDec_1
        '
        Me._lblPrnDec_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_1.Location = New System.Drawing.Point(112, 176)
        Me._lblPrnDec_1.Name = "_lblPrnDec_1"
        Me._lblPrnDec_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_1.Size = New System.Drawing.Size(80, 17)
        Me._lblPrnDec_1.TabIndex = 25
        Me._lblPrnDec_1.Text = "持久力："
        Me._lblPrnDec_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPrnDec_2
        '
        Me._lblPrnDec_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_2.Location = New System.Drawing.Point(112, 200)
        Me._lblPrnDec_2.Name = "_lblPrnDec_2"
        Me._lblPrnDec_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_2.Size = New System.Drawing.Size(80, 17)
        Me._lblPrnDec_2.TabIndex = 24
        Me._lblPrnDec_2.Text = "攻撃力："
        Me._lblPrnDec_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPrnDec_3
        '
        Me._lblPrnDec_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_3.Location = New System.Drawing.Point(112, 224)
        Me._lblPrnDec_3.Name = "_lblPrnDec_3"
        Me._lblPrnDec_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_3.Size = New System.Drawing.Size(80, 17)
        Me._lblPrnDec_3.TabIndex = 23
        Me._lblPrnDec_3.Text = "防御力："
        Me._lblPrnDec_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPrnDec_4
        '
        Me._lblPrnDec_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_4.Location = New System.Drawing.Point(112, 248)
        Me._lblPrnDec_4.Name = "_lblPrnDec_4"
        Me._lblPrnDec_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_4.Size = New System.Drawing.Size(80, 17)
        Me._lblPrnDec_4.TabIndex = 22
        Me._lblPrnDec_4.Text = "瞬発力："
        Me._lblPrnDec_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPrnDec_5
        '
        Me._lblPrnDec_5.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_5.Location = New System.Drawing.Point(24, 176)
        Me._lblPrnDec_5.Name = "_lblPrnDec_5"
        Me._lblPrnDec_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_5.Size = New System.Drawing.Size(73, 17)
        Me._lblPrnDec_5.TabIndex = 18
        Me._lblPrnDec_5.Text = "残りポイント"
        Me._lblPrnDec_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRest
        '
        Me.lblRest.BackColor = System.Drawing.SystemColors.Window
        Me.lblRest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRest.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRest.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblRest.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRest.Location = New System.Drawing.Point(32, 192)
        Me.lblRest.Name = "lblRest"
        Me.lblRest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRest.Size = New System.Drawing.Size(33, 33)
        Me.lblRest.TabIndex = 17
        Me.lblRest.Text = "0"
        Me.lblRest.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPrnDec_6
        '
        Me._lblPrnDec_6.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_6.Location = New System.Drawing.Point(8, 24)
        Me._lblPrnDec_6.Name = "_lblPrnDec_6"
        Me._lblPrnDec_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_6.Size = New System.Drawing.Size(177, 24)
        Me._lblPrnDec_6.TabIndex = 16
        Me._lblPrnDec_6.Text = "主人公の設定"
        Me._lblPrnDec_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblPrnDec_7
        '
        Me._lblPrnDec_7.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_7.Location = New System.Drawing.Point(8, 56)
        Me._lblPrnDec_7.Name = "_lblPrnDec_7"
        Me._lblPrnDec_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_7.Size = New System.Drawing.Size(177, 17)
        Me._lblPrnDec_7.TabIndex = 15
        Me._lblPrnDec_7.Text = "※主人公の初期レベルは5。"
        Me._lblPrnDec_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'linBorder1
        '
        Me.linBorder1.BackColor = System.Drawing.SystemColors.WindowText
        Me.linBorder1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.linBorder1.Location = New System.Drawing.Point(8, 80)
        Me.linBorder1.Name = "linBorder1"
        Me.linBorder1.Size = New System.Drawing.Size(232, 3)
        Me.linBorder1.TabIndex = 29
        '
        'imgIcon
        '
        Me.imgIcon.BackColor = System.Drawing.Color.Transparent
        Me.imgIcon.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgIcon.Image = CType(resources.GetObject("imgIcon.Image"), System.Drawing.Bitmap)
        Me.imgIcon.Location = New System.Drawing.Point(184, 16)
        Me.imgIcon.Name = "imgIcon"
        Me.imgIcon.Size = New System.Drawing.Size(57, 57)
        Me.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgIcon.TabIndex = 30
        Me.imgIcon.TabStop = False
        '
        'imgArrow
        '
        Me.imgArrow.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgArrow.Image = CType(resources.GetObject("imgArrow.Image"), System.Drawing.Bitmap)
        Me.imgArrow.Location = New System.Drawing.Point(72, 200)
        Me.imgArrow.Name = "imgArrow"
        Me.imgArrow.Size = New System.Drawing.Size(32, 32)
        Me.imgArrow.TabIndex = 31
        Me.imgArrow.TabStop = False
        '
        '_lblPrnDec_8
        '
        Me._lblPrnDec_8.BackColor = System.Drawing.SystemColors.Control
        Me._lblPrnDec_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPrnDec_8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblPrnDec_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPrnDec_8.Location = New System.Drawing.Point(8, 152)
        Me._lblPrnDec_8.Name = "_lblPrnDec_8"
        Me._lblPrnDec_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPrnDec_8.Size = New System.Drawing.Size(201, 17)
        Me._lblPrnDec_8.TabIndex = 14
        Me._lblPrnDec_8.Text = ">>ポイントを振り分けてください。"
        '
        'linBorder0
        '
        Me.linBorder0.BackColor = System.Drawing.SystemColors.WindowText
        Me.linBorder0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.linBorder0.Location = New System.Drawing.Point(8, 8)
        Me.linBorder0.Name = "linBorder0"
        Me.linBorder0.Size = New System.Drawing.Size(232, 3)
        Me.linBorder0.TabIndex = 32
        '
        'FlexPicture1
        '
        Me.FlexPicture1.Location = New System.Drawing.Point(232, 440)
        Me.FlexPicture1.Name = "FlexPicture1"
        Me.FlexPicture1.Picture = CType(resources.GetObject("FlexPicture1.Picture"), System.Drawing.Bitmap)
        Me.FlexPicture1.Position = Qwert.nfrpg.FlexPicture.PicturePosition.TopLeft
        Me.FlexPicture1.Size = New System.Drawing.Size(128, 72)
        Me.FlexPicture1.TabIndex = 65
        Me.FlexPicture1.TabStop = False
        '
        'formTitle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(618, 535)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.FlexPicture1, Me.pctContena, Me.lblStuff4, Me.lblStuff3, Me.lblStuff2, Me.lblStuff1, Me.cmdEnd, Me.cmdContinue, Me.cmdStart, Me.lblTitle, Me.imgBack})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formTitle"
        Me.Text = "Start"
        Me.pctContena.ResumeLayout(False)
        CType(Me.nudCfgParam4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCfgParam3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCfgParam2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCfgParam1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCfgParam0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intCounter As Integer

        MessageBox.Show("はじまるよ！")

        lblRest.Text = "0"
        'pctContena.Top = Me.Height + 10
        '各ラベルをimgBackのchildにする
        Dim lblWork(4) As Label
        lblWork(0) = lblTitle
        lblWork(1) = lblStuff1
        lblWork(2) = lblStuff2
        lblWork(3) = lblStuff3
        lblWork(4) = lblStuff4
        Dim aLabel As Label
        With imgBack
            For intCounter = 0 To lblWork.Length - 1
                .Controls.Add(lblWork(intCounter))
                lblWork(intCounter).Top = lblWork(intCounter).Top - .Top
                lblWork(intCounter).Left = lblWork(intCounter).Left - .Left
            Next
        End With

        '全ての「nudCfgParam」ハンドラを同一にする
        AddHandler nudCfgParam0.ValueChanged, AddressOf nudCfgParam_ValueChanged
        AddHandler nudCfgParam1.ValueChanged, AddressOf nudCfgParam_ValueChanged
        AddHandler nudCfgParam2.ValueChanged, AddressOf nudCfgParam_ValueChanged
        AddHandler nudCfgParam3.ValueChanged, AddressOf nudCfgParam_ValueChanged
        AddHandler nudCfgParam4.ValueChanged, AddressOf nudCfgParam_ValueChanged

        'BGM再生
        'm_bgm = New MidPlay(Me.Handle, "sounds\slow01.mid")
        Call setBGM()
    End Sub

    Private Sub setBGM()
        'm_bgm.Open("sounds\title.mid")
        m_bgm.Play("sounds\title.mid")
    End Sub

    Private Sub nudCfgParam_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim totalPoint As Integer = nudCfgParam0.Value + nudCfgParam1.Value + nudCfgParam2.Value + nudCfgParam3.Value + nudCfgParam4.Value
        Dim rest As Integer = 20 - totalPoint
        lblRest.Text = rest.ToString.Trim
        If (rest > 0) Then
            nudCfgParam0.Maximum = nudCfgParam0.Value + 1
            nudCfgParam1.Maximum = nudCfgParam1.Value + 1
            nudCfgParam2.Maximum = nudCfgParam2.Value + 1
            nudCfgParam3.Maximum = nudCfgParam3.Value + 1
            nudCfgParam4.Maximum = nudCfgParam4.Value + 1
        Else
            nudCfgParam0.Maximum = nudCfgParam0.Value
            nudCfgParam1.Maximum = nudCfgParam1.Value
            nudCfgParam2.Maximum = nudCfgParam2.Value
            nudCfgParam3.Maximum = nudCfgParam3.Value
            nudCfgParam4.Maximum = nudCfgParam4.Value
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Dim intCounter As Integer
        Call subButtonEnabled(False)
        With pctContena
            .Top = 32
            For intCounter = 168 To Me.Width + 10 Step 4
                .Left = intCounter
                'System.Windows.Forms.Application.DoEvents()
            Next intCounter
        End With
        Call subButtonEnabled(True)

    End Sub


    Private Sub subButtonEnabled(ByRef blnValue As Boolean)
        cmdCancel.Enabled = blnValue
        cmdOK.Enabled = blnValue
        cmdContinue.Enabled = blnValue
        cmdStart.Enabled = blnValue
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Dim intCounter As Integer
        Call subButtonEnabled(False)
        With pctContena
            .Top = 32
            For intCounter = -.Width To 168 Step 4
                .Left = intCounter
                'System.Windows.Forms.Application.DoEvents()
            Next intCounter
        End With
        txtName.Focus()
        Call subButtonEnabled(True)

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim mainDialog As formMain = New formMain()
            Dim intRet As Integer

            Call subButtonEnabled(False)
            If (Convert.ToInt32(lblRest.Text) = 0) Then
                If (Not m_bgm Is Nothing) Then
                    m_bgm.StopNow()
                    m_bgm.Close()
                End If
                Me.Hide()
                mainDialog.MyName = txtName.Text.Trim
                mainDialog.IsContinue = False
                mainDialog.Param(0) = nudCfgParam0.Value
                mainDialog.Param(1) = nudCfgParam1.Value
                mainDialog.Param(2) = nudCfgParam2.Value
                mainDialog.Param(3) = nudCfgParam3.Value
                mainDialog.Param(4) = nudCfgParam4.Value
                mainDialog.ShowDialog()
                Me.Show()
                m_bgm.Close()
                Call setBGM()
            Else
                intRet = fncCallMessage("ポイントが残っています", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "警告")
            End If
            Call subButtonEnabled(True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinue.Click
        Try
            Dim mainDialog As formMain = New formMain()
            Call subButtonEnabled(False)
            If (Not m_bgm Is Nothing) Then
                m_bgm.StopNow()
                m_bgm.Close()
            End If
            Me.Hide()
            mainDialog.MyName = txtName.Text.Trim
            mainDialog.IsContinue = True
            'mainDialog.MenuItem2_Click(sender, e)
            mainDialog.ShowDialog()
            Me.Show()
            Call subButtonEnabled(True)
            m_bgm.Close()
            Call setBGM()
        Catch ex As Exception
            'MsgBox("")
        End Try
    End Sub

    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        m_bgm.Close()
        Me.Close()
    End Sub


End Class
