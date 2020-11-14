Option Strict Off
Option Explicit On 

Imports Qwert.nfrpg.mdlDef


Public Class formMain
    Inherits System.Windows.Forms.Form

    Private m_bgm As MidPlay
    Private m_easyMes() As ShortMessage

    Private chrMonster() As Character
    Private intWhoIsOnTurn As Integer
    Private eqpDatas() As Equipment

    Private eqpShopItem(5) As Equipment
    Private intShopItemPrice(5) As Integer
    Private atpAttackPat() As RpgPerformAttack
    Private intEnemyCommand(5) As Integer
    Private stdEnv As StageDats

    Private m_myName As String

    Private m_isContinue As Boolean = False

    Private m_paramPoint(5) As Integer

    Private Enum enmUpParam
        HpMax
        Str
        Def
        Speed
        MpMax
    End Enum


    'Private m_nodeList As SortedList = New SortedList()
    Public Property MyName() As String
        Get
            MyName = m_myName
        End Get
        Set(ByVal Value As String)
            m_myName = Value
        End Set
    End Property

    Public Property IsContinue() As Boolean
        Get
            IsContinue = m_isContinue
        End Get
        Set(ByVal Value As Boolean)
            m_isContinue = Value
        End Set
    End Property

    Public Property Param(ByVal id As Integer) As Integer
        Get
            Param = m_paramPoint(id)
        End Get
        Set(ByVal Value As Integer)
            m_paramPoint(id) = Value
        End Set
    End Property

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
    Public WithEvents pctBack As System.Windows.Forms.PictureBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Public WithEvents lblStageName As System.Windows.Forms.Label
    Public WithEvents pctLooks1 As System.Windows.Forms.PictureBox
    Public WithEvents lblName1 As System.Windows.Forms.Label
    Public WithEvents lblName0 As System.Windows.Forms.Label
    Public WithEvents lblDecStr_12 As System.Windows.Forms.Label
    Public WithEvents fraParamTable As System.Windows.Forms.GroupBox
    Public WithEvents _linBorder_1 As System.Windows.Forms.Label
    Public WithEvents _linBorder_0 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_14 As System.Windows.Forms.Label
    Public WithEvents lblMpMax0 As System.Windows.Forms.Label
    Public WithEvents lblMp0 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_13 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_10 As System.Windows.Forms.Label
    Public WithEvents lblShield0 As System.Windows.Forms.Label
    Public WithEvents lblArm0 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_11 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_9 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_8 As System.Windows.Forms.Label
    Public WithEvents lblExpMax0 As System.Windows.Forms.Label
    Public WithEvents lblMoney0 As System.Windows.Forms.Label
    Public WithEvents lblExp0 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_7 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_6 As System.Windows.Forms.Label
    Public WithEvents lblHp0 As System.Windows.Forms.Label
    Public WithEvents lblHpMax0 As System.Windows.Forms.Label
    Public WithEvents lblAttack0 As System.Windows.Forms.Label
    Public WithEvents lblDeffence0 As System.Windows.Forms.Label
    Public WithEvents lblSpeed0 As System.Windows.Forms.Label
    Public WithEvents lblLevel0 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_0 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_1 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_2 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_3 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_4 As System.Windows.Forms.Label
    Public WithEvents _lblDecStr_5 As System.Windows.Forms.Label
    Public WithEvents cmdDown As System.Windows.Forms.Button
    Public WithEvents cmdUp As System.Windows.Forms.Button
    Public WithEvents cmdCall As System.Windows.Forms.Button
    Public WithEvents cmdHotel As System.Windows.Forms.Button
    Public WithEvents cmdShop As System.Windows.Forms.Button
    Public WithEvents cmdBoss As System.Windows.Forms.Button
    Public WithEvents pctLooks0 As System.Windows.Forms.PictureBox
    Friend WithEvents trvCommand As System.Windows.Forms.TreeView
    Public WithEvents fraDebug As System.Windows.Forms.GroupBox
    Public WithEvents cmdDebug As System.Windows.Forms.Button
    Public WithEvents txtFilename As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents fraShop As System.Windows.Forms.GroupBox
    Public WithEvents cmdBuy As System.Windows.Forms.Button
    Public WithEvents cmdDebugPrint As System.Windows.Forms.Button
    Public WithEvents optItem0 As System.Windows.Forms.RadioButton
    Public WithEvents optItem1 As System.Windows.Forms.RadioButton
    Public WithEvents optItem2 As System.Windows.Forms.RadioButton
    Public WithEvents optItem3 As System.Windows.Forms.RadioButton
    Public WithEvents optItem4 As System.Windows.Forms.RadioButton
    Friend WithEvents menuLoad As System.Windows.Forms.MenuItem
    Friend WithEvents menuSave As System.Windows.Forms.MenuItem
    Friend WithEvents menuEnd As System.Windows.Forms.MenuItem
    Public WithEvents lblHp1 As System.Windows.Forms.Label
    Public WithEvents lblAttack1 As System.Windows.Forms.Label
    Public WithEvents lblDeffence1 As System.Windows.Forms.Label
    Public WithEvents lblSpeed1 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents GraphicalMeter1 As Qwert.nfrpg.GraphicalMeter
    Friend WithEvents GraphicalMeter0 As Qwert.nfrpg.GraphicalMeter
    Public WithEvents cmdCloseShop As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(formMain))
        Me.pctBack = New System.Windows.Forms.PictureBox()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.menuLoad = New System.Windows.Forms.MenuItem()
        Me.menuSave = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.menuEnd = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.trvCommand = New System.Windows.Forms.TreeView()
        Me.lblDecStr_12 = New System.Windows.Forms.Label()
        Me.lblStageName = New System.Windows.Forms.Label()
        Me.pctLooks1 = New System.Windows.Forms.PictureBox()
        Me.lblName1 = New System.Windows.Forms.Label()
        Me.lblName0 = New System.Windows.Forms.Label()
        Me.fraParamTable = New System.Windows.Forms.GroupBox()
        Me._linBorder_1 = New System.Windows.Forms.Label()
        Me._linBorder_0 = New System.Windows.Forms.Label()
        Me._lblDecStr_14 = New System.Windows.Forms.Label()
        Me.lblMpMax0 = New System.Windows.Forms.Label()
        Me.lblMp0 = New System.Windows.Forms.Label()
        Me._lblDecStr_13 = New System.Windows.Forms.Label()
        Me._lblDecStr_10 = New System.Windows.Forms.Label()
        Me.lblShield0 = New System.Windows.Forms.Label()
        Me.lblArm0 = New System.Windows.Forms.Label()
        Me._lblDecStr_11 = New System.Windows.Forms.Label()
        Me._lblDecStr_9 = New System.Windows.Forms.Label()
        Me._lblDecStr_8 = New System.Windows.Forms.Label()
        Me.lblExpMax0 = New System.Windows.Forms.Label()
        Me.lblMoney0 = New System.Windows.Forms.Label()
        Me.lblExp0 = New System.Windows.Forms.Label()
        Me._lblDecStr_7 = New System.Windows.Forms.Label()
        Me._lblDecStr_6 = New System.Windows.Forms.Label()
        Me.lblHp0 = New System.Windows.Forms.Label()
        Me.lblHpMax0 = New System.Windows.Forms.Label()
        Me.lblAttack0 = New System.Windows.Forms.Label()
        Me.lblDeffence0 = New System.Windows.Forms.Label()
        Me.lblSpeed0 = New System.Windows.Forms.Label()
        Me.lblLevel0 = New System.Windows.Forms.Label()
        Me._lblDecStr_0 = New System.Windows.Forms.Label()
        Me._lblDecStr_1 = New System.Windows.Forms.Label()
        Me._lblDecStr_2 = New System.Windows.Forms.Label()
        Me._lblDecStr_3 = New System.Windows.Forms.Label()
        Me._lblDecStr_4 = New System.Windows.Forms.Label()
        Me._lblDecStr_5 = New System.Windows.Forms.Label()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdCall = New System.Windows.Forms.Button()
        Me.cmdHotel = New System.Windows.Forms.Button()
        Me.cmdShop = New System.Windows.Forms.Button()
        Me.cmdBoss = New System.Windows.Forms.Button()
        Me.pctLooks0 = New System.Windows.Forms.PictureBox()
        Me.fraDebug = New System.Windows.Forms.GroupBox()
        Me.cmdDebug = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblHp1 = New System.Windows.Forms.Label()
        Me.lblAttack1 = New System.Windows.Forms.Label()
        Me.lblDeffence1 = New System.Windows.Forms.Label()
        Me.lblSpeed1 = New System.Windows.Forms.Label()
        Me.fraShop = New System.Windows.Forms.GroupBox()
        Me.cmdCloseShop = New System.Windows.Forms.Button()
        Me.cmdBuy = New System.Windows.Forms.Button()
        Me.optItem0 = New System.Windows.Forms.RadioButton()
        Me.optItem1 = New System.Windows.Forms.RadioButton()
        Me.optItem2 = New System.Windows.Forms.RadioButton()
        Me.optItem3 = New System.Windows.Forms.RadioButton()
        Me.optItem4 = New System.Windows.Forms.RadioButton()
        Me.cmdDebugPrint = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.GraphicalMeter1 = New Qwert.nfrpg.GraphicalMeter()
        Me.GraphicalMeter0 = New Qwert.nfrpg.GraphicalMeter()
        Me.fraParamTable.SuspendLayout()
        Me.fraDebug.SuspendLayout()
        Me.fraShop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pctBack
        '
        Me.pctBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctBack.Location = New System.Drawing.Point(8, 8)
        Me.pctBack.Name = "pctBack"
        Me.pctBack.Size = New System.Drawing.Size(416, 392)
        Me.pctBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctBack.TabIndex = 73
        Me.pctBack.TabStop = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem6})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuLoad, Me.menuSave, Me.MenuItem4, Me.menuEnd})
        Me.MenuItem1.Text = "ファイル"
        '
        'menuLoad
        '
        Me.menuLoad.Index = 0
        Me.menuLoad.Text = "ロード"
        '
        'menuSave
        '
        Me.menuSave.Index = 1
        Me.menuSave.Text = "セーブ"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'menuEnd
        '
        Me.menuEnd.Index = 3
        Me.menuEnd.Text = "終了"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 1
        Me.MenuItem6.Text = "バージョン情報"
        '
        'trvCommand
        '
        Me.trvCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvCommand.Font = New System.Drawing.Font("MS UI Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.trvCommand.ImageIndex = -1
        Me.trvCommand.Location = New System.Drawing.Point(240, 32)
        Me.trvCommand.Name = "trvCommand"
        Me.trvCommand.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("ノード0", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("ノード3")}), New System.Windows.Forms.TreeNode("ノード1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("ノード4"), New System.Windows.Forms.TreeNode("ノード6")}), New System.Windows.Forms.TreeNode("ノード2")})
        Me.trvCommand.SelectedImageIndex = -1
        Me.trvCommand.ShowRootLines = False
        Me.trvCommand.Size = New System.Drawing.Size(176, 152)
        Me.trvCommand.TabIndex = 0
        '
        'lblDecStr_12
        '
        Me.lblDecStr_12.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.lblDecStr_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDecStr_12.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDecStr_12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDecStr_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDecStr_12.Location = New System.Drawing.Point(240, 16)
        Me.lblDecStr_12.Name = "lblDecStr_12"
        Me.lblDecStr_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDecStr_12.Size = New System.Drawing.Size(177, 17)
        Me.lblDecStr_12.TabIndex = 76
        Me.lblDecStr_12.Text = "戦闘コマンド一覧"
        Me.lblDecStr_12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStageName
        '
        Me.lblStageName.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.lblStageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStageName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStageName.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStageName.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.lblStageName.Location = New System.Drawing.Point(16, 16)
        Me.lblStageName.Name = "lblStageName"
        Me.lblStageName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStageName.Size = New System.Drawing.Size(209, 21)
        Me.lblStageName.TabIndex = 75
        Me.lblStageName.Text = "STAGE NAME"
        '
        'pctLooks1
        '
        Me.pctLooks1.BackColor = System.Drawing.Color.Transparent
        Me.pctLooks1.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctLooks1.Location = New System.Drawing.Point(16, 40)
        Me.pctLooks1.Name = "pctLooks1"
        Me.pctLooks1.Size = New System.Drawing.Size(208, 321)
        Me.pctLooks1.TabIndex = 82
        Me.pctLooks1.TabStop = False
        '
        'lblName1
        '
        Me.lblName1.BackColor = System.Drawing.SystemColors.WindowText
        Me.lblName1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblName1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblName1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblName1.Location = New System.Drawing.Point(16, 360)
        Me.lblName1.Name = "lblName1"
        Me.lblName1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblName1.Size = New System.Drawing.Size(209, 17)
        Me.lblName1.TabIndex = 88
        '
        'lblName0
        '
        Me.lblName0.BackColor = System.Drawing.SystemColors.WindowText
        Me.lblName0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblName0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblName0.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblName0.Location = New System.Drawing.Point(240, 360)
        Me.lblName0.Name = "lblName0"
        Me.lblName0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblName0.Size = New System.Drawing.Size(177, 17)
        Me.lblName0.TabIndex = 87
        '
        'fraParamTable
        '
        Me.fraParamTable.BackColor = System.Drawing.Color.Black
        Me.fraParamTable.Controls.AddRange(New System.Windows.Forms.Control() {Me._linBorder_1, Me._linBorder_0, Me._lblDecStr_14, Me.lblMpMax0, Me.lblMp0, Me._lblDecStr_13, Me._lblDecStr_10, Me.lblShield0, Me.lblArm0, Me._lblDecStr_11, Me._lblDecStr_9, Me._lblDecStr_8, Me.lblExpMax0, Me.lblMoney0, Me.lblExp0, Me._lblDecStr_7, Me._lblDecStr_6, Me.lblHp0, Me.lblHpMax0, Me.lblAttack0, Me.lblDeffence0, Me.lblSpeed0, Me.lblLevel0, Me._lblDecStr_0, Me._lblDecStr_1, Me._lblDecStr_2, Me._lblDecStr_3, Me._lblDecStr_4, Me._lblDecStr_5})
        Me.fraParamTable.ForeColor = System.Drawing.Color.White
        Me.fraParamTable.Location = New System.Drawing.Point(432, 8)
        Me.fraParamTable.Name = "fraParamTable"
        Me.fraParamTable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraParamTable.Size = New System.Drawing.Size(177, 225)
        Me.fraParamTable.TabIndex = 89
        Me.fraParamTable.TabStop = False
        Me.fraParamTable.Text = " Status "
        '
        '_linBorder_1
        '
        Me._linBorder_1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte))
        Me._linBorder_1.Location = New System.Drawing.Point(120, 2400)
        Me._linBorder_1.Name = "_linBorder_1"
        Me._linBorder_1.Size = New System.Drawing.Size(2400, 1)
        Me._linBorder_1.TabIndex = 0
        '
        '_linBorder_0
        '
        Me._linBorder_0.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte))
        Me._linBorder_0.Location = New System.Drawing.Point(120, 1800)
        Me._linBorder_0.Name = "_linBorder_0"
        Me._linBorder_0.Size = New System.Drawing.Size(2400, 1)
        Me._linBorder_0.TabIndex = 1
        '
        '_lblDecStr_14
        '
        Me._lblDecStr_14.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_14.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_14.Location = New System.Drawing.Point(104, 56)
        Me._lblDecStr_14.Name = "_lblDecStr_14"
        Me._lblDecStr_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_14.Size = New System.Drawing.Size(9, 17)
        Me._lblDecStr_14.TabIndex = 73
        Me._lblDecStr_14.Text = "/"
        Me._lblDecStr_14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMpMax0
        '
        Me.lblMpMax0.BackColor = System.Drawing.Color.Transparent
        Me.lblMpMax0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMpMax0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMpMax0.ForeColor = System.Drawing.Color.White
        Me.lblMpMax0.Location = New System.Drawing.Point(120, 56)
        Me.lblMpMax0.Name = "lblMpMax0"
        Me.lblMpMax0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMpMax0.Size = New System.Drawing.Size(41, 17)
        Me.lblMpMax0.TabIndex = 72
        Me.lblMpMax0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMp0
        '
        Me.lblMp0.BackColor = System.Drawing.Color.Transparent
        Me.lblMp0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMp0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMp0.ForeColor = System.Drawing.Color.White
        Me.lblMp0.Location = New System.Drawing.Point(64, 56)
        Me.lblMp0.Name = "lblMp0"
        Me.lblMp0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMp0.Size = New System.Drawing.Size(41, 17)
        Me.lblMp0.TabIndex = 71
        Me.lblMp0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_13
        '
        Me._lblDecStr_13.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_13.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_13.Location = New System.Drawing.Point(1, 56)
        Me._lblDecStr_13.Name = "_lblDecStr_13"
        Me._lblDecStr_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_13.Size = New System.Drawing.Size(56, 17)
        Me._lblDecStr_13.TabIndex = 70
        Me._lblDecStr_13.Text = "精神力："
        Me._lblDecStr_13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_10
        '
        Me._lblDecStr_10.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_10.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_10.Location = New System.Drawing.Point(8, 168)
        Me._lblDecStr_10.Name = "_lblDecStr_10"
        Me._lblDecStr_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_10.Size = New System.Drawing.Size(49, 17)
        Me._lblDecStr_10.TabIndex = 61
        Me._lblDecStr_10.Text = "武器："
        Me._lblDecStr_10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblShield0
        '
        Me.lblShield0.BackColor = System.Drawing.Color.Transparent
        Me.lblShield0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShield0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblShield0.ForeColor = System.Drawing.Color.White
        Me.lblShield0.Location = New System.Drawing.Point(64, 184)
        Me.lblShield0.Name = "lblShield0"
        Me.lblShield0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShield0.Size = New System.Drawing.Size(105, 17)
        Me.lblShield0.TabIndex = 38
        '
        'lblArm0
        '
        Me.lblArm0.BackColor = System.Drawing.Color.Transparent
        Me.lblArm0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblArm0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblArm0.ForeColor = System.Drawing.Color.White
        Me.lblArm0.Location = New System.Drawing.Point(64, 168)
        Me.lblArm0.Name = "lblArm0"
        Me.lblArm0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblArm0.Size = New System.Drawing.Size(105, 17)
        Me.lblArm0.TabIndex = 37
        '
        '_lblDecStr_11
        '
        Me._lblDecStr_11.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_11.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_11.Location = New System.Drawing.Point(8, 184)
        Me._lblDecStr_11.Name = "_lblDecStr_11"
        Me._lblDecStr_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_11.Size = New System.Drawing.Size(49, 17)
        Me._lblDecStr_11.TabIndex = 36
        Me._lblDecStr_11.Text = "防具："
        Me._lblDecStr_11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_9
        '
        Me._lblDecStr_9.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_9.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_9.Location = New System.Drawing.Point(160, 128)
        Me._lblDecStr_9.Name = "_lblDecStr_9"
        Me._lblDecStr_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_9.Size = New System.Drawing.Size(9, 17)
        Me._lblDecStr_9.TabIndex = 33
        Me._lblDecStr_9.Text = ")"
        Me._lblDecStr_9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_8
        '
        Me._lblDecStr_8.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_8.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_8.Location = New System.Drawing.Point(104, 128)
        Me._lblDecStr_8.Name = "_lblDecStr_8"
        Me._lblDecStr_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_8.Size = New System.Drawing.Size(9, 17)
        Me._lblDecStr_8.TabIndex = 32
        Me._lblDecStr_8.Text = "("
        Me._lblDecStr_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblExpMax0
        '
        Me.lblExpMax0.BackColor = System.Drawing.Color.Transparent
        Me.lblExpMax0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExpMax0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblExpMax0.ForeColor = System.Drawing.Color.White
        Me.lblExpMax0.Location = New System.Drawing.Point(120, 128)
        Me.lblExpMax0.Name = "lblExpMax0"
        Me.lblExpMax0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExpMax0.Size = New System.Drawing.Size(41, 17)
        Me.lblExpMax0.TabIndex = 31
        Me.lblExpMax0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMoney0
        '
        Me.lblMoney0.BackColor = System.Drawing.Color.Transparent
        Me.lblMoney0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMoney0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMoney0.ForeColor = System.Drawing.Color.White
        Me.lblMoney0.Location = New System.Drawing.Point(64, 144)
        Me.lblMoney0.Name = "lblMoney0"
        Me.lblMoney0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMoney0.Size = New System.Drawing.Size(57, 17)
        Me.lblMoney0.TabIndex = 30
        Me.lblMoney0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblExp0
        '
        Me.lblExp0.BackColor = System.Drawing.Color.Transparent
        Me.lblExp0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExp0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblExp0.ForeColor = System.Drawing.Color.White
        Me.lblExp0.Location = New System.Drawing.Point(64, 128)
        Me.lblExp0.Name = "lblExp0"
        Me.lblExp0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExp0.Size = New System.Drawing.Size(41, 17)
        Me.lblExp0.TabIndex = 29
        Me.lblExp0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_7
        '
        Me._lblDecStr_7.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_7.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_7.Location = New System.Drawing.Point(8, 144)
        Me._lblDecStr_7.Name = "_lblDecStr_7"
        Me._lblDecStr_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_7.Size = New System.Drawing.Size(49, 17)
        Me._lblDecStr_7.TabIndex = 28
        Me._lblDecStr_7.Text = "金："
        Me._lblDecStr_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_6
        '
        Me._lblDecStr_6.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_6.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_6.Location = New System.Drawing.Point(1, 128)
        Me._lblDecStr_6.Name = "_lblDecStr_6"
        Me._lblDecStr_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_6.Size = New System.Drawing.Size(56, 17)
        Me._lblDecStr_6.TabIndex = 27
        Me._lblDecStr_6.Text = "経験値："
        Me._lblDecStr_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHp0
        '
        Me.lblHp0.BackColor = System.Drawing.Color.Transparent
        Me.lblHp0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHp0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHp0.ForeColor = System.Drawing.Color.White
        Me.lblHp0.Location = New System.Drawing.Point(64, 40)
        Me.lblHp0.Name = "lblHp0"
        Me.lblHp0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHp0.Size = New System.Drawing.Size(41, 17)
        Me.lblHp0.TabIndex = 26
        Me.lblHp0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHpMax0
        '
        Me.lblHpMax0.BackColor = System.Drawing.Color.Transparent
        Me.lblHpMax0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHpMax0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHpMax0.ForeColor = System.Drawing.Color.White
        Me.lblHpMax0.Location = New System.Drawing.Point(120, 40)
        Me.lblHpMax0.Name = "lblHpMax0"
        Me.lblHpMax0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHpMax0.Size = New System.Drawing.Size(41, 17)
        Me.lblHpMax0.TabIndex = 25
        Me.lblHpMax0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblAttack0
        '
        Me.lblAttack0.BackColor = System.Drawing.Color.Transparent
        Me.lblAttack0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAttack0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAttack0.ForeColor = System.Drawing.Color.White
        Me.lblAttack0.Location = New System.Drawing.Point(64, 72)
        Me.lblAttack0.Name = "lblAttack0"
        Me.lblAttack0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAttack0.Size = New System.Drawing.Size(41, 17)
        Me.lblAttack0.TabIndex = 24
        Me.lblAttack0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDeffence0
        '
        Me.lblDeffence0.BackColor = System.Drawing.Color.Transparent
        Me.lblDeffence0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeffence0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDeffence0.ForeColor = System.Drawing.Color.White
        Me.lblDeffence0.Location = New System.Drawing.Point(64, 88)
        Me.lblDeffence0.Name = "lblDeffence0"
        Me.lblDeffence0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeffence0.Size = New System.Drawing.Size(41, 17)
        Me.lblDeffence0.TabIndex = 23
        Me.lblDeffence0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSpeed0
        '
        Me.lblSpeed0.BackColor = System.Drawing.Color.Transparent
        Me.lblSpeed0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpeed0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSpeed0.ForeColor = System.Drawing.Color.White
        Me.lblSpeed0.Location = New System.Drawing.Point(64, 104)
        Me.lblSpeed0.Name = "lblSpeed0"
        Me.lblSpeed0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpeed0.Size = New System.Drawing.Size(41, 17)
        Me.lblSpeed0.TabIndex = 22
        Me.lblSpeed0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLevel0
        '
        Me.lblLevel0.BackColor = System.Drawing.Color.Transparent
        Me.lblLevel0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLevel0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLevel0.ForeColor = System.Drawing.Color.White
        Me.lblLevel0.Location = New System.Drawing.Point(64, 24)
        Me.lblLevel0.Name = "lblLevel0"
        Me.lblLevel0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLevel0.Size = New System.Drawing.Size(41, 17)
        Me.lblLevel0.TabIndex = 21
        Me.lblLevel0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_0
        '
        Me._lblDecStr_0.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_0.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_0.Location = New System.Drawing.Point(8, 24)
        Me._lblDecStr_0.Name = "_lblDecStr_0"
        Me._lblDecStr_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_0.Size = New System.Drawing.Size(49, 17)
        Me._lblDecStr_0.TabIndex = 20
        Me._lblDecStr_0.Text = "レベル："
        Me._lblDecStr_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_1
        '
        Me._lblDecStr_1.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_1.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_1.Location = New System.Drawing.Point(8, 40)
        Me._lblDecStr_1.Name = "_lblDecStr_1"
        Me._lblDecStr_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_1.Size = New System.Drawing.Size(49, 17)
        Me._lblDecStr_1.TabIndex = 19
        Me._lblDecStr_1.Text = "HP："
        Me._lblDecStr_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_2
        '
        Me._lblDecStr_2.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_2.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_2.Location = New System.Drawing.Point(1, 72)
        Me._lblDecStr_2.Name = "_lblDecStr_2"
        Me._lblDecStr_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_2.Size = New System.Drawing.Size(56, 17)
        Me._lblDecStr_2.TabIndex = 18
        Me._lblDecStr_2.Text = "攻撃力："
        Me._lblDecStr_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_3
        '
        Me._lblDecStr_3.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_3.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_3.Location = New System.Drawing.Point(1, 88)
        Me._lblDecStr_3.Name = "_lblDecStr_3"
        Me._lblDecStr_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_3.Size = New System.Drawing.Size(56, 17)
        Me._lblDecStr_3.TabIndex = 17
        Me._lblDecStr_3.Text = "防御力："
        Me._lblDecStr_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_4
        '
        Me._lblDecStr_4.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_4.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_4.Location = New System.Drawing.Point(1, 104)
        Me._lblDecStr_4.Name = "_lblDecStr_4"
        Me._lblDecStr_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_4.Size = New System.Drawing.Size(56, 17)
        Me._lblDecStr_4.TabIndex = 16
        Me._lblDecStr_4.Text = "瞬発力："
        Me._lblDecStr_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDecStr_5
        '
        Me._lblDecStr_5.BackColor = System.Drawing.Color.Transparent
        Me._lblDecStr_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDecStr_5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDecStr_5.ForeColor = System.Drawing.Color.White
        Me._lblDecStr_5.Location = New System.Drawing.Point(104, 40)
        Me._lblDecStr_5.Name = "_lblDecStr_5"
        Me._lblDecStr_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDecStr_5.Size = New System.Drawing.Size(9, 17)
        Me._lblDecStr_5.TabIndex = 15
        Me._lblDecStr_5.Text = "/"
        Me._lblDecStr_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdDown
        '
        Me.cmdDown.BackColor = System.Drawing.Color.Transparent
        Me.cmdDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDown.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDown.ForeColor = System.Drawing.Color.Transparent
        Me.cmdDown.Image = CType(resources.GetObject("cmdDown.Image"), System.Drawing.Bitmap)
        Me.cmdDown.Location = New System.Drawing.Point(48, 296)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDown.Size = New System.Drawing.Size(32, 32)
        Me.cmdDown.TabIndex = 95
        '
        'cmdUp
        '
        Me.cmdUp.BackColor = System.Drawing.Color.Transparent
        Me.cmdUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUp.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUp.ForeColor = System.Drawing.Color.Transparent
        Me.cmdUp.Image = CType(resources.GetObject("cmdUp.Image"), System.Drawing.Bitmap)
        Me.cmdUp.Location = New System.Drawing.Point(48, 200)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUp.Size = New System.Drawing.Size(32, 32)
        Me.cmdUp.TabIndex = 94
        '
        'cmdCall
        '
        Me.cmdCall.BackColor = System.Drawing.Color.Transparent
        Me.cmdCall.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCall.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCall.ForeColor = System.Drawing.Color.Transparent
        Me.cmdCall.Image = CType(resources.GetObject("cmdCall.Image"), System.Drawing.Bitmap)
        Me.cmdCall.Location = New System.Drawing.Point(136, 216)
        Me.cmdCall.Name = "cmdCall"
        Me.cmdCall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCall.Size = New System.Drawing.Size(32, 32)
        Me.cmdCall.TabIndex = 90
        '
        'cmdHotel
        '
        Me.cmdHotel.BackColor = System.Drawing.Color.Transparent
        Me.cmdHotel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdHotel.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdHotel.ForeColor = System.Drawing.Color.Transparent
        Me.cmdHotel.Image = CType(resources.GetObject("cmdHotel.Image"), System.Drawing.Bitmap)
        Me.cmdHotel.Location = New System.Drawing.Point(144, 256)
        Me.cmdHotel.Name = "cmdHotel"
        Me.cmdHotel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHotel.Size = New System.Drawing.Size(32, 32)
        Me.cmdHotel.TabIndex = 91
        '
        'cmdShop
        '
        Me.cmdShop.BackColor = System.Drawing.Color.Transparent
        Me.cmdShop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShop.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdShop.ForeColor = System.Drawing.Color.Transparent
        Me.cmdShop.Image = CType(resources.GetObject("cmdShop.Image"), System.Drawing.Bitmap)
        Me.cmdShop.Location = New System.Drawing.Point(80, 232)
        Me.cmdShop.Name = "cmdShop"
        Me.cmdShop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShop.Size = New System.Drawing.Size(32, 32)
        Me.cmdShop.TabIndex = 93
        '
        'cmdBoss
        '
        Me.cmdBoss.BackColor = System.Drawing.Color.Transparent
        Me.cmdBoss.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBoss.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdBoss.ForeColor = System.Drawing.Color.Transparent
        Me.cmdBoss.Image = CType(resources.GetObject("cmdBoss.Image"), System.Drawing.Bitmap)
        Me.cmdBoss.Location = New System.Drawing.Point(64, 264)
        Me.cmdBoss.Name = "cmdBoss"
        Me.cmdBoss.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBoss.Size = New System.Drawing.Size(32, 32)
        Me.cmdBoss.TabIndex = 92
        '
        'pctLooks0
        '
        Me.pctLooks0.BackColor = System.Drawing.Color.Transparent
        Me.pctLooks0.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctLooks0.Location = New System.Drawing.Point(240, 184)
        Me.pctLooks0.Name = "pctLooks0"
        Me.pctLooks0.Size = New System.Drawing.Size(173, 177)
        Me.pctLooks0.TabIndex = 96
        Me.pctLooks0.TabStop = False
        '
        'fraDebug
        '
        Me.fraDebug.BackColor = System.Drawing.SystemColors.Control
        Me.fraDebug.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDebug, Me.txtFilename, Me.Label1, Me.lblHp1, Me.lblAttack1, Me.lblDeffence1, Me.lblSpeed1})
        Me.fraDebug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDebug.Location = New System.Drawing.Point(16, 32)
        Me.fraDebug.Name = "fraDebug"
        Me.fraDebug.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraDebug.Size = New System.Drawing.Size(209, 97)
        Me.fraDebug.TabIndex = 98
        Me.fraDebug.TabStop = False
        Me.fraDebug.Text = "デバッグ用各種パラメータ"
        Me.fraDebug.Visible = False
        '
        'cmdDebug
        '
        Me.cmdDebug.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDebug.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDebug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDebug.Location = New System.Drawing.Point(40, 64)
        Me.cmdDebug.Name = "cmdDebug"
        Me.cmdDebug.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDebug.Size = New System.Drawing.Size(49, 25)
        Me.cmdDebug.TabIndex = 56
        Me.cmdDebug.Text = "Action"
        '
        'txtFilename
        '
        Me.txtFilename.AcceptsReturn = True
        Me.txtFilename.AutoSize = False
        Me.txtFilename.BackColor = System.Drawing.SystemColors.Window
        Me.txtFilename.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFilename.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFilename.Location = New System.Drawing.Point(8, 40)
        Me.txtFilename.MaxLength = 0
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFilename.Size = New System.Drawing.Size(81, 18)
        Me.txtFilename.TabIndex = 54
        Me.txtFilename.Text = "level"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "保存ファイル名"
        '
        'lblHp1
        '
        Me.lblHp1.BackColor = System.Drawing.SystemColors.Window
        Me.lblHp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHp1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHp1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHp1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHp1.Location = New System.Drawing.Point(136, 24)
        Me.lblHp1.Name = "lblHp1"
        Me.lblHp1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHp1.Size = New System.Drawing.Size(57, 17)
        Me.lblHp1.TabIndex = 53
        Me.lblHp1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblAttack1
        '
        Me.lblAttack1.BackColor = System.Drawing.SystemColors.Window
        Me.lblAttack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAttack1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAttack1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAttack1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAttack1.Location = New System.Drawing.Point(136, 40)
        Me.lblAttack1.Name = "lblAttack1"
        Me.lblAttack1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAttack1.Size = New System.Drawing.Size(57, 17)
        Me.lblAttack1.TabIndex = 52
        Me.lblAttack1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDeffence1
        '
        Me.lblDeffence1.BackColor = System.Drawing.SystemColors.Window
        Me.lblDeffence1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDeffence1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeffence1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDeffence1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDeffence1.Location = New System.Drawing.Point(136, 56)
        Me.lblDeffence1.Name = "lblDeffence1"
        Me.lblDeffence1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeffence1.Size = New System.Drawing.Size(57, 17)
        Me.lblDeffence1.TabIndex = 51
        Me.lblDeffence1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSpeed1
        '
        Me.lblSpeed1.BackColor = System.Drawing.SystemColors.Window
        Me.lblSpeed1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpeed1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpeed1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSpeed1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSpeed1.Location = New System.Drawing.Point(136, 72)
        Me.lblSpeed1.Name = "lblSpeed1"
        Me.lblSpeed1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpeed1.Size = New System.Drawing.Size(57, 17)
        Me.lblSpeed1.TabIndex = 50
        Me.lblSpeed1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fraShop
        '
        Me.fraShop.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.fraShop.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCloseShop, Me.cmdBuy, Me.optItem0, Me.optItem1, Me.optItem2, Me.optItem3, Me.optItem4})
        Me.fraShop.ForeColor = System.Drawing.Color.White
        Me.fraShop.Location = New System.Drawing.Point(16, 424)
        Me.fraShop.Name = "fraShop"
        Me.fraShop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraShop.Size = New System.Drawing.Size(209, 176)
        Me.fraShop.TabIndex = 99
        Me.fraShop.TabStop = False
        Me.fraShop.Text = " 商品一覧 "
        '
        'cmdCloseShop
        '
        Me.cmdCloseShop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCloseShop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCloseShop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCloseShop.Location = New System.Drawing.Point(112, 144)
        Me.cmdCloseShop.Name = "cmdCloseShop"
        Me.cmdCloseShop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCloseShop.Size = New System.Drawing.Size(64, 24)
        Me.cmdCloseShop.TabIndex = 47
        Me.cmdCloseShop.Text = "キャンセル"
        '
        'cmdBuy
        '
        Me.cmdBuy.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuy.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuy.Location = New System.Drawing.Point(40, 144)
        Me.cmdBuy.Name = "cmdBuy"
        Me.cmdBuy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuy.Size = New System.Drawing.Size(64, 24)
        Me.cmdBuy.TabIndex = 46
        Me.cmdBuy.Text = "購入する"
        '
        'optItem0
        '
        Me.optItem0.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.optItem0.Checked = True
        Me.optItem0.Cursor = System.Windows.Forms.Cursors.Default
        Me.optItem0.ForeColor = System.Drawing.Color.White
        Me.optItem0.Location = New System.Drawing.Point(8, 16)
        Me.optItem0.Name = "optItem0"
        Me.optItem0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optItem0.Size = New System.Drawing.Size(193, 25)
        Me.optItem0.TabIndex = 45
        Me.optItem0.TabStop = True
        Me.optItem0.Text = "Option1"
        '
        'optItem1
        '
        Me.optItem1.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.optItem1.Cursor = System.Windows.Forms.Cursors.Default
        Me.optItem1.ForeColor = System.Drawing.Color.White
        Me.optItem1.Location = New System.Drawing.Point(8, 40)
        Me.optItem1.Name = "optItem1"
        Me.optItem1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optItem1.Size = New System.Drawing.Size(193, 25)
        Me.optItem1.TabIndex = 44
        Me.optItem1.TabStop = True
        Me.optItem1.Text = "Option1"
        '
        'optItem2
        '
        Me.optItem2.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.optItem2.Cursor = System.Windows.Forms.Cursors.Default
        Me.optItem2.ForeColor = System.Drawing.Color.White
        Me.optItem2.Location = New System.Drawing.Point(8, 64)
        Me.optItem2.Name = "optItem2"
        Me.optItem2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optItem2.Size = New System.Drawing.Size(193, 25)
        Me.optItem2.TabIndex = 43
        Me.optItem2.TabStop = True
        Me.optItem2.Text = "Option1"
        '
        'optItem3
        '
        Me.optItem3.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.optItem3.Cursor = System.Windows.Forms.Cursors.Default
        Me.optItem3.ForeColor = System.Drawing.Color.White
        Me.optItem3.Location = New System.Drawing.Point(8, 88)
        Me.optItem3.Name = "optItem3"
        Me.optItem3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optItem3.Size = New System.Drawing.Size(193, 25)
        Me.optItem3.TabIndex = 42
        Me.optItem3.TabStop = True
        Me.optItem3.Text = "Option1"
        '
        'optItem4
        '
        Me.optItem4.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))
        Me.optItem4.Cursor = System.Windows.Forms.Cursors.Default
        Me.optItem4.ForeColor = System.Drawing.Color.White
        Me.optItem4.Location = New System.Drawing.Point(8, 112)
        Me.optItem4.Name = "optItem4"
        Me.optItem4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optItem4.Size = New System.Drawing.Size(193, 25)
        Me.optItem4.TabIndex = 41
        Me.optItem4.TabStop = True
        Me.optItem4.Text = "Option1"
        '
        'cmdDebugPrint
        '
        Me.cmdDebugPrint.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDebugPrint.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDebugPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDebugPrint.Location = New System.Drawing.Point(528, 240)
        Me.cmdDebugPrint.Name = "cmdDebugPrint"
        Me.cmdDebugPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDebugPrint.Size = New System.Drawing.Size(81, 25)
        Me.cmdDebugPrint.TabIndex = 100
        Me.cmdDebugPrint.Text = "デバッグ表示"
        Me.cmdDebugPrint.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMessage.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(432, 264)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(176, 136)
        Me.lblMessage.TabIndex = 101
        '
        'GraphicalMeter1
        '
        Me.GraphicalMeter1.Location = New System.Drawing.Point(16, 376)
        Me.GraphicalMeter1.MaxValue = 0
        Me.GraphicalMeter1.Name = "GraphicalMeter1"
        Me.GraphicalMeter1.RestValue = 0
        Me.GraphicalMeter1.Size = New System.Drawing.Size(208, 16)
        Me.GraphicalMeter1.TabIndex = 102
        '
        'GraphicalMeter0
        '
        Me.GraphicalMeter0.Location = New System.Drawing.Point(240, 376)
        Me.GraphicalMeter0.MaxValue = 0
        Me.GraphicalMeter0.Name = "GraphicalMeter0"
        Me.GraphicalMeter0.RestValue = 0
        Me.GraphicalMeter0.Size = New System.Drawing.Size(176, 16)
        Me.GraphicalMeter0.TabIndex = 103
        '
        'formMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(618, 411)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GraphicalMeter0, Me.GraphicalMeter1, Me.lblMessage, Me.cmdDebugPrint, Me.fraShop, Me.fraDebug, Me.pctLooks0, Me.cmdDown, Me.cmdUp, Me.cmdCall, Me.cmdHotel, Me.cmdShop, Me.cmdBoss, Me.fraParamTable, Me.lblName1, Me.lblName0, Me.pctLooks1, Me.lblDecStr_12, Me.lblStageName, Me.trvCommand, Me.pctBack})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "formMain"
        Me.Text = "main2"
        Me.fraParamTable.ResumeLayout(False)
        Me.fraDebug.ResumeLayout(False)
        Me.fraShop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub subAttackClick(ByRef intAtkType As Integer, ByVal Node As TreeNode)
        On Error GoTo Err_cmdAttack_Click
        Dim intRet As Integer
        Dim intCounter As Integer
        Dim intUpParam As Integer
        Dim intCommand As Integer
        'ボタンのロック
        'cmdAttack.Enabled = False
        Select Case intWhoIsOnTurn
            Case cstChrMain
                'プレイヤーの攻撃
                lblMessage.Text = "" '改頁処理
                intRet = fncAttack(intAtkType, Node, chrMonster(cstChrMain), chrMonster(cstChrEnemy), lblMessage)
                If (intRet) Then
                    '効果音(miss)
                    Dim soundplayer As WavPlay = New WavPlay("sounds\at003.wav")
                    '相手死亡
                    With chrMonster(cstChrEnemy)
                        'Call subVibeAnim(chrMonster(cstChrEnemy), 15)
                        Call subEraseAnim(chrMonster(cstChrEnemy))
                        Call subSetMessage(lblMessage, .ChrName & "を倒した。", cstOverWrite)
                        Call subSetMessage(lblMessage, "経験値" & CStr(.Exp) & "と金" & CStr(.Money) & "をゲット。", cstUpdate)
                        chrMonster(cstChrMain).Money = chrMonster(cstChrMain).Money + .Money
                        intRet = chrMonster(cstChrMain).AddExp(.Exp)
                        intKillCounter += 1
                        'テキスト初期化
                        '.ClearDamageInfo()
                        '.subClearParam()
                        If (intRet) Then
                            'レベルアップ！
                            Call LevelUpChr(chrMonster(cstChrMain))
                            Call subSetMessage(lblMessage, chrMonster(cstChrMain).ChrName & "はレベルアップ！", cstUpdate)
                        End If
                        'chrMonster(cstChrMain).ClearDamageInfo()
                        chrMonster(cstChrMain).Refresh()
                        'アイテム取得処理
                        Call subGetItem(chrMonster(cstChrEnemy), chrMonster(cstChrMain))
                        Call subPrintStage(stdEnv, RpgScreenMode.Normal, pctBack, lblStageName)

                        'アニメーション初期化
                        'dipAnimation.fncEraseAll

                    End With
                    chrMonster(cstChrEnemy) = Nothing   '敵オブジェクトの破棄
                    'ボスを倒した場合の処理
                    If (stdEnv.Screen = RpgScreenMode.Boss) Then
                        chrMonster(cstChrMain).Perform.Enabled = 31 '「火炎」を使用可能
                        intRet = fncSetCommandTree()
                    End If

                    '通常画面へ復帰
                    '画面モード設定
                    Call subScreenMode(RpgScreenMode.Normal)
                    'intRet = fncSetCommandTree()
                    m_bgm.StopNow()
                Else
                    'ターン交代
                    Call subChangeTurn(cstChrEnemy)
                    Call subAttackClick(-1, Nothing) '続けて敵の攻撃
                End If
            Case cstChrEnemy
                '相手の攻撃
                '攻撃パターン選択
                Dim rGen As System.Random = New System.Random()
                intCommand = rGen.Next(0, 4) '    Fix(Rnd() * 5)
                'If (intCommand >= 5) Then intCommand = 0
                '
                intRet = fncAttack(intEnemyCommand(intCommand), Nothing, chrMonster(cstChrEnemy), chrMonster(cstChrMain), lblMessage)
                If (intRet) Then
                    'プレイヤー死亡
                    Call subVibeAnim(chrMonster(cstChrMain), 15)
                    Call subSetMessage(lblMessage, "=== GAME OVER ===", cstOverWrite)
                    intDeadCounter = intDeadCounter + 1
                    'Character初期化
                    'chrMonster(cstChrMain).ClearDamageInfo()
                    'アニメーション初期化
                    'dipAnimation.fncEraseAll
                    'chrMonster(cstChrMain).subClearParam()
                    'ゲームオーバー画面に移動
                    intRet = fncCallMessage("ゲームオーバー。", MsgBoxStyle.OKOnly, "Game Over")
                    'chrMonster(cstChrEnemy).subClearDamageInfo()
                    'chrMonster(cstChrEnemy).subClearParam()
                    'Call subInitMyParam(chrMonster(cstChrMain))
                    '画面モード設定
                    Call subScreenMode(RpgScreenMode.Normal)
                    m_bgm.StopNow()
                    chrMonster(cstChrEnemy) = Nothing '敵オブジェクトの破棄
                    chrMonster(cstChrMain) = Nothing '主人公オブジェクトの破棄
                    Me.Close()
                Else
                    'ターン交代
                    Call subChangeTurn(cstChrMain)
                End If
            Case Else
                'ターン交代
                Call subChangeTurn(cstChrMain)
        End Select

Exit_cmdAttack_Click:
        'ボタンのロック
        'cmdAttack.Enabled = True
        Exit Sub
Err_cmdAttack_Click:
        Call subErrHandle("cmdAttack_Click", Err.Number, Err.Description)
        Resume Exit_cmdAttack_Click
    End Sub
    '
    Public Function fncAttack(ByRef intAtkType As Integer, ByVal Node As TreeNode, ByRef chrMe As Character, ByRef chrTarget As Character, ByRef objDisplay As Object) As Integer
        On Error GoTo Err_fncAttack
        Dim intAttackPt As Integer
        Dim intRet As Integer
        'プレーヤー
        With chrMe
            Call subSetMessage(objDisplay, .ChrName & "の攻撃！", cstUpdate)
            If (intAtkType <> -1) Then
                Call subSetMessage(objDisplay, "『" & .Perform.Name(intAtkType) & "』を使った。", cstUpdate)
            End If
            Call .Perform.Animation(pctBack, intAtkType, chrTarget)

            If (intAtkType <> -1) Then
                intRet = .Perform.AddExp(intAtkType)
                'If (Not Node Is Nothing) Then
                'Node.Text = .Perform.Caption(intAtkType)
                'End If
            End If
            '命中したか？
            If (chrMe.CanIHit(chrTarget)) Then
                intAttackPt = .UseAttack(intAtkType, chrTarget)
                If (intAttackPt = 0) Then
                    '効果音(miss)
                    Dim soundplayer As WavPlay = New WavPlay("sounds\at002.wav")
                    Call subSetMessage(objDisplay, "攻撃は効かなかった。", cstUpdate)
                    With chrTarget.Printer.Looks
                        Call subPrintChrMessage(chrTarget, .Left, .Top + .Height / 4, "miss", Color.White)
                    End With
                Else
                    Call subSetMessage(objDisplay, chrTarget.ChrName & "に" & Str(intAttackPt) & "ポイントのダメージ！", cstUpdate)
                    '効果音(hit)
                    Dim soundplayer As WavPlay = New WavPlay("sounds\at001.wav")

                    With chrTarget.Printer.Looks
                        Call subVibeAnim(chrTarget, 1)
                        Call subPrintChrMessage(chrTarget, .Left, .Top + .Height / 4, "-" & CStr(intAttackPt), Color.Red)
                    End With
                End If
                Call chrTarget.AddHp(intAttackPt * -1)
                If (chrTarget.IsAlive) Then
                    fncAttack = 0
                Else
                    fncAttack = -1
                End If
            Else
                '効果音(miss)
                Dim soundplayer As WavPlay = New WavPlay("sounds\at002.wav")
                Call subSetMessage(objDisplay, "攻撃はかわされた。", cstUpdate)
                With chrTarget.Printer.Looks
                    Call subPrintChrMessage(chrTarget, .Left, .Top + .Height / 4, "miss", Color.White)
                End With
                fncAttack = 0
            End If
            .Refresh()
            chrTarget.Refresh()
        End With
Exit_fncAttack:
        Exit Function
Err_fncAttack:
        Call subErrHandle("fncAttack", Err.Number, Err.Description)
        Resume Exit_fncAttack
    End Function

    '
    Private Sub subGetItem(ByRef chrFrom As Character, ByRef chrTo As Character)
        On Error GoTo Err_subGetItem
        Dim intRet As Integer
        Dim intCounter As Integer
        With chrFrom
            For intCounter = 0 To cstBodyPartsMax - 1
                If (chrTo.Luck > (.Luck + chrTo.Luck) * Rnd() And .EquipID(intCounter) >= 0) Then
                    'アイテム取得
                    intRet = MsgBox(.ChrName & "から『" & eqpDatas(.EquipID(intCounter)).ItemName & "』を奪い取りますか？", MsgBoxStyle.YesNo)
                    If (intRet = MsgBoxResult.Yes) Then
                        intRet = chrTo.ChangeEquipment(intCounter, eqpDatas(.EquipID(intCounter)))
                        chrTo.Refresh()
                    End If
                End If
            Next intCounter
        End With

Exit_subGetItem:
        Exit Sub
Err_subGetItem:
        Call subErrHandle("subGetItem", Err.Number, Err.Description)
        Resume Exit_subGetItem
    End Sub
    '
    Private Sub subChangeTurn(ByRef intOnTurn As Integer)
        On Error GoTo Err_subChangeTurn

        intWhoIsOnTurn = intOnTurn

Exit_subChangeTurn:
        Exit Sub
Err_subChangeTurn:
        Call subErrHandle("subChangeTurn", Err.Number, Err.Description)
        Resume Exit_subChangeTurn
    End Sub

    Private Sub cmdBoss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBoss.Click
        Dim strBossParam As String
        Dim strValues() As String
        Dim intValue As Integer
        Dim intCounter As Integer
        Dim intRet As Integer
        Dim strComList() As String
        m_bgm.Play("sounds\boss.mid")

        '敵オブジェクト生成
        Dim aParamPrinter As ParamPrinter = New ParamPrinter()
        With aParamPrinter
            .Name = lblName1
            .HpMax = Nothing
            .Hp = lblHp1
            .Attack = lblAttack1
            .Deffence = lblDeffence1
            .Speed = lblSpeed1
            .Exp = Nothing
            .ExpMax = Nothing
            .Money = Nothing
            .HpMeter = GraphicalMeter0
            .Looks = pctLooks1
        End With
        chrMonster(cstChrEnemy) = New RPG1Character(aParamPrinter)
        With chrMonster(cstChrEnemy)
            .SetPerformance(New RpgPerformAttack()) '攻撃技の装着
            'Call .SetDamageInfo(New ShortMessage(.Printer.Looks), Nothing, Nothing)
        End With

        '店のフレームを移動
        fraShop.Top = 432
        '画面モード設定
        Call subScreenMode(RpgScreenMode.Boss)
        '背景表示
        Call subPrintStage(stdEnv, RpgScreenMode.Boss, pctBack, lblStageName)
        'ボスパラメータのセット
        With chrMonster(cstChrEnemy)
            .SetParam(stdEnv.BossDat(cstEnemyBaseDat))
            strComList = Split(stdEnv.BossDat(cstEnemyPerformDat), ",")
            For intCounter = 0 To 4
                intEnemyCommand(intCounter) = Val(strComList(intCounter))
            Next intCounter
            strValues = Split(stdEnv.BossDat(cstEnemyBaseDat), ",")
            For intCounter = 0 To cstBodyPartsMax - 1
                intValue = Val(strValues(16 + intCounter))
                If (intValue <> -1) Then
                    intRet = .ChangeEquipment(intCounter, eqpDatas(intValue))
                End If
            Next intCounter
            '.fncLoadPicture (stdEnv.BossPic)
            .Refresh()
            Call subSetMessage(lblMessage, .ChrName & "が現れた。", cstOverWrite)
            .ShowMyImage()
        End With
        '遭遇人数を増加
        intBattleCounter = intBattleCounter + 1
        '相手から攻撃する
        Call subChangeTurn(cstChrEnemy)
        Call subAttackClick(-1, Nothing)

    End Sub

    Private Sub cmdBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuy.Click
        On Error GoTo Err_cmdBuy_Click
        Dim intBuyNo As Integer = 0
        Dim optMe As System.Windows.Forms.RadioButton
        Dim intRet As Integer
        Dim blnReserved As Boolean
        Dim intCounter As Integer
        Dim optButtons() As Windows.Forms.RadioButton = {optItem0, optItem1, optItem2, optItem3, optItem4}

        For intCounter = 0 To 4
            If (optButtons(intCounter).Checked = True) Then
                'UPGRADE_ISSUE: OptionButton プロパティ optMe.Index はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2064"' をクリックしてください。
                blnReserved = True
            ElseIf (Not blnReserved) Then
                intBuyNo = intBuyNo + 1
            End If
        Next intCounter
        '

        If (blnReserved) Then
            With eqpShopItem(intBuyNo)
                If (intShopItemPrice(intBuyNo) <= chrMonster(cstChrMain).Money) Then
                    '
                    chrMonster(cstChrMain).Money = chrMonster(cstChrMain).Money - intShopItemPrice(intBuyNo)

                    Call subSetMessage(lblMessage, "『" & .ItemName & "』を買って、装備した。", cstOverWrite)
                    intRet = chrMonster(cstChrMain).ChangeEquipment(.Part, eqpShopItem(intBuyNo))
                    chrMonster(cstChrMain).Refresh()
                Else
                    '
                    Call subSetMessage(lblMessage, "金が足りない！", cstOverWrite)
                End If
            End With
        Else
            '
            Call subSetMessage(lblMessage, "商品が選ばれてない！", cstOverWrite)
        End If

Exit_cmdBuy_Click:
        Exit Sub
Err_cmdBuy_Click:
        Call subErrHandle("cmdBuy_Click", Err.Number, Err.Description)
        Resume Exit_cmdBuy_Click
    End Sub

    Private Sub cmdCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCall.Click
        On Error GoTo Err_cmdCall_Click
        '敵オブジェクト生成
        Dim aParamPrinter As ParamPrinter = New ParamPrinter()
        With aParamPrinter
            .Name = lblName1
            .HpMax = Nothing
            .Hp = lblHp1
            .Attack = lblAttack1
            .Deffence = lblDeffence1
            .Speed = lblSpeed1
            .Exp = Nothing
            .ExpMax = Nothing
            .Money = Nothing
            .HpMeter = GraphicalMeter1
            .Looks = pctLooks1
        End With
        chrMonster(cstChrEnemy) = New RPG1Character(aParamPrinter)
        With chrMonster(cstChrEnemy)
            .SetPerformance(New RpgPerformAttack()) '攻撃技の装着
            'Call .SetDamageInfo(New ShortMessage(.Printer.Looks), Nothing, Nothing)
        End With

        '店のフレームを移動
        fraShop.Top = 432
        '画面モード設定
        Call subScreenMode(RpgScreenMode.Battle)
        Call subLoadChrParam(chrMonster(cstChrEnemy), (chrMonster(cstChrMain).Level), Me)
        Call subSetMessage(lblMessage, chrMonster(cstChrEnemy).ChrName & "が現れた。", cstOverWrite)
        m_bgm.Play("sounds\battle.mid")
        '遭遇人数を増加
        intBattleCounter = intBattleCounter + 1
        '相手から攻撃する？
        If (Rnd() * 10 < 1) Then
            'ターン交代
            Call subChangeTurn(cstChrEnemy)
        Else
            'ターン交代
            Call subChangeTurn(cstChrMain)
        End If
        chrMonster(cstChrEnemy).Refresh()

Exit_cmdCall_Click:
        Exit Sub
Err_cmdCall_Click:
        Call subErrHandle("cmdCall_Click", Err.Number, Err.Description)
        Resume Exit_cmdCall_Click
    End Sub
    Public Sub subVibeAnim(ByRef chrTarget As Character, ByRef intTime As Integer)
        On Error GoTo Err_subVibeAnim
        Dim intRet As Integer
        Dim intX As Integer
        Dim intY As Integer
        Dim intCounter As Integer
        'intRet = dipAnimation.fncSetVibe(chrTarget.PrinterLooks, 1)
        With chrTarget.Printer.Looks
            intX = .Left
            intY = .Top
            For intCounter = 0 To intTime * 3
                .Left = intX + Fix(Rnd() * 5) * 4 - 8
                .Top = intY + Fix(Rnd() * 5) * 4 - 8
                .Refresh()
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(10)
            Next intCounter
            .Left = intX
            .Top = intY
        End With
Exit_subVibeAnim:
        Exit Sub
Err_subVibeAnim:
        Call subErrHandle("subVibeAnim", Err.Number, Err.Description)
        Resume Exit_subVibeAnim
    End Sub

    Public Sub subEraseAnim(ByRef chrTarget As Character)
        On Error GoTo Err_subEraseAnim
        Dim intRet As Integer
        Dim intX As Integer
        Dim intWidth As Integer
        Dim intCounter As Integer

        With chrTarget.Printer.Looks
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            intX = .Left
            intWidth = .Width
            For intCounter = 0 To intWidth / 2 Step 2
                .Left = intX + intCounter
                .Width = intWidth - intCounter * 2
                '.Top = intY + Fix(Rnd() * 5) * 4 - 8
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(10)
            Next intCounter
            .Width = 0
            .Image = Nothing
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
            .Left = intX
        End With
Exit_subEraseAnim:
        Exit Sub
Err_subEraseAnim:
        Call subErrHandle("subEraseAnim", Err.Number, Err.Description)
        Resume Exit_subEraseAnim
    End Sub

    Private Sub cmdDebugPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDebugPrint.Click
        On Error GoTo Err_cmdDebugPrint_Click
        With fraDebug
            If (.Visible) Then
                .Visible = False
            Else
                .Visible = True
            End If
        End With

Exit_cmdDebugPrint_Click:
        Exit Sub
Err_cmdDebugPrint_Click:
        Call subErrHandle("cmdDebugPrint_Click", Err.Number, Err.Description)
        Resume Exit_cmdDebugPrint_Click

    End Sub

    Private Sub subHelpMe()
        On Error GoTo Err_subHelpMe
        Dim intRet As Integer
        Dim intPayValue As Integer
        '
        intEscapeCounter = intEscapeCounter + 1
        '逃避
        With chrMonster(cstChrMain)
            intPayValue = fncRoundUp(.Money / 2, 1)
            .Money = .Money - intPayValue
            .Refresh()
            If (intPayValue = 0) Then
                Call subSetMessage(lblMessage, "金がないので、財布丸ごと渡して命乞いをした。", cstOverWrite)
            Else
                Call subSetMessage(lblMessage, "金" & CStr(intPayValue) & "を出して、命乞いをした。", cstOverWrite)
            End If
            If (Rnd() * 100 < 50) Then
                Call subSetMessage(lblMessage, "許してもらった。", cstUpdate)
                '成功
                '画面モード設定
                'chrMonster(cstChrEnemy).subClearParam()
                chrMonster(cstChrEnemy) = Nothing '敵オブジェクトの破棄
                Call subScreenMode(RpgScreenMode.Normal)
            Else
                Call subSetMessage(lblMessage, "…" & chrMonster(cstChrEnemy).ChrName & "はニヤニヤしている。", cstUpdate)
                'ターン交代
                Call subChangeTurn(cstChrEnemy)
                Call subAttackClick(-1, Nothing) '続けて敵の攻撃
            End If
        End With

Exit_subHelpMe:
        Exit Sub
Err_subHelpMe:
        Call subErrHandle("subHelpMe", Err.Number, Err.Description)
        Resume Exit_subHelpMe
    End Sub



    Private Sub cmdHotel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHotel.Click
        On Error GoTo Err_cmdHotel_Click
        Dim intRet As Integer
        Dim intCost As Integer

        With chrMonster(cstChrMain)
            intCost = Fix(.HpMax)
            If (.Money >= intCost) Then
                If (fncCallMessage("宿泊には、金" & CStr(intCost) & "が必要です。休みますか？", MsgBoxStyle.OKCancel, "宿") = MsgBoxResult.OK) Then
                    intRet = fncHeal(chrMonster(cstChrMain), lblMessage)
                End If
            Else
                intRet = fncCallMessage("宿泊には、金" & CStr(intCost) & "が必要です。", MsgBoxStyle.OKOnly, "宿")
            End If
        End With
Exit_cmdHotel_Click:
        Exit Sub
Err_cmdHotel_Click:
        Call subErrHandle("cmdHotel_Click", Err.Number, Err.Description)
        Resume Exit_cmdHotel_Click

    End Sub

    'ロード
    Public Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLoad.Click
        Dim intRet As Integer
        Dim strFilename As String

        strFilename = txtFilename.Text & ".dat"
        If (fncFileExists(strFilename) = cstOK) Then
            intRet = fncLoadCharacter(strFilename, chrMonster(cstChrMain))
            chrMonster(cstChrMain).Refresh()
            stdEnv.Stage = 1
            Call subGetStageEnv(stdEnv, stdEnv.Stage)
        Else
            intRet = fncCallMessage("データが存在しません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, "データの読み込み")
        End If

    End Sub
    'セーブ
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSave.Click
        Dim intRet As Integer
        Dim strFilename As String
        strFilename = txtFilename.Text & ".dat"

        intRet = fncSaveCharacter(strFilename, chrMonster(cstChrMain))
    End Sub

    '終了
    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEnd.Click
        Me.Close()
    End Sub

    Private Function fncSaveCharacter(ByRef strFilename As String, ByRef chrMe As Character) As Integer
        On Error GoTo Err_fncSaveCharacter
        Dim strTemp As String
        Dim strTemp2 As String
        Dim intCounter As Integer
        With chrMe
            strTemp = .GetParam
            For intCounter = 0 To cstBodyPartsMax - 1
                strTemp = strTemp & "," & CStr(.EquipID(intCounter))
            Next intCounter
            strTemp2 = .Perform.GetParam
        End With
        'ファイルオープン
        FileOpen(1, strFilename, OpenMode.Output)
        '一行読込み
        PrintLine(1, strTemp)
        PrintLine(1, strTemp2)
        'ファイルクローズ
        FileClose(1)
Exit_fncSaveCharacter:
        Exit Function
Err_fncSaveCharacter:
        Call subErrHandle("fncSaveCharacter", Err.Number, Err.Description)
        Resume Exit_fncSaveCharacter
    End Function

    Private Function fncLoadCharacter(ByRef strFilename As String, ByRef chrMe As Character) As Integer
        On Error GoTo Err_fncLoadCharacter
        Dim strTemp As String
        Dim strTemp2 As String
        Dim strValues() As String
        Dim intCounter As Integer
        Dim intValue As Integer
        Dim intRet As Integer
        'ファイルオープン
        FileOpen(1, strFilename, OpenMode.Input)
        '基礎データ読込み
        strTemp = LineInput(1) '項目読込み
        '技データ読込み
        strTemp2 = LineInput(1) '項目読込み
        'ファイルクローズ
        FileClose(1)
        With chrMe
            .SetParam(strTemp)
            .ShowMyImage()
            strValues = Split(strTemp, ",")
            For intCounter = 0 To cstBodyPartsMax - 1
                intValue = Val(strValues(16 + intCounter))
                If (intValue <> -1) Then
                    intRet = .ChangeEquipment(intCounter, eqpDatas(intValue))
                End If
            Next intCounter
            .Perform.SetParam(strTemp2)
        End With
        intRet = fncSetCommandTree()
Exit_fncLoadCharacter:
        Exit Function
Err_fncLoadCharacter:
        Call subErrHandle("fncLoadCharacter", Err.Number, Err.Description)
        Resume Exit_fncLoadCharacter
    End Function

    Private Sub cmdShop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShop.Click
        On Error GoTo Err_cmdShop_Click
        Dim intCounter As Integer
        Dim strItemName As String
        Dim optButtons() As Windows.Forms.RadioButton = {optItem0, optItem1, optItem2, optItem3, optItem4}

        '店のフレームを移動
        fraShop.Top = 37
        For intCounter = 0 To 4
            '商品の決定
            eqpShopItem(intCounter) = eqpDatas(Rnd() * 9)
            With eqpShopItem(intCounter)
                '価格決定
                intShopItemPrice(intCounter) = .Price + Rnd() * .Price / 2
                'アイテム名をセット
                optButtons(intCounter).Text = .ItemName & " -- 金" & CStr(intShopItemPrice(intCounter))
                optButtons(intCounter).Refresh()
            End With
        Next intCounter

Exit_cmdShop_Click:
        Exit Sub
Err_cmdShop_Click:
        Call subErrHandle("cmdShop_Click", Err.Number, Err.Description)
        Resume Exit_cmdShop_Click
    End Sub

    '===================================================
    'コマンドツリーの表示
    Private Function fncSetCommandTree() As Integer

        Dim aNodeEscape As TreeNode = New TreeNode("戦闘拒否")
        Dim aNodeAttack As TreeNode = New TreeNode("物理攻撃")
        Dim aNodeMagic As TreeNode = New TreeNode("魔術")
        Dim aNodeDevil As TreeNode = New TreeNode("魔神召還")
        Dim aChildNode As TreeNode

        With trvCommand
            .Nodes.Clear()
            aNodeEscape.Tag = "_100"
            .Nodes.Add(aNodeEscape)
            aNodeAttack.Tag = "_200"
            .Nodes.Add(aNodeAttack)
            aNodeMagic.Tag = "_300"
            .Nodes.Add(aNodeMagic)
            aNodeDevil.Tag = "_400"
            .Nodes.Add(aNodeDevil)
            aChildNode = New TreeNode("とんずら")
            aChildNode.Tag = "_110"
            aNodeEscape.Nodes.Add(aChildNode)
            aChildNode = New TreeNode("命乞い")
            aChildNode.Tag = "_120"
            aNodeEscape.Nodes.Add(aChildNode)
            '
            If (chrMonster(cstChrMain).Perform.Level(0) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(0)
                aChildNode.Tag = "_2100"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(1) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(1)
                aChildNode.Tag = "_2101"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(2) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(2)
                aChildNode.Tag = "_2102"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(3) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(3)
                aChildNode.Tag = "_2103"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(4) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(4)
                aChildNode.Tag = "_2104"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(5) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(5)
                aChildNode.Tag = "_2105"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(6) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(6)
                aChildNode.Tag = "_2106"
                aNodeAttack.Nodes.Add(aChildNode)
            End If
            '魔法
            If (chrMonster(cstChrMain).Perform.Level(31) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(31)
                aChildNode.Tag = "_3101"
                aNodeMagic.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(35) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(35)
                aChildNode.Tag = "_3105"
                aNodeMagic.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(32) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(32)
                aChildNode.Tag = "_3102"
                aNodeMagic.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(33) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(33)
                aChildNode.Tag = "_3103"
                aNodeMagic.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(36) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(36)
                aChildNode.Tag = "_3106"
                aNodeMagic.Nodes.Add(aChildNode)
            End If
            '召還
            If (chrMonster(cstChrMain).Perform.Level(34) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(34)
                aChildNode.Tag = "_4104"
                aNodeDevil.Nodes.Add(aChildNode)
            End If
            If (chrMonster(cstChrMain).Perform.Level(37) > 0) Then
                aChildNode = chrMonster(cstChrMain).Perform.GetNode(37)
                aChildNode.Tag = "_4107"
                aNodeDevil.Nodes.Add(aChildNode)
            End If

        End With
    End Function

    Public Sub subPrintChrMessage(ByRef chrMe As Character, ByVal intX As Integer, ByVal intY As Integer, ByRef strMessage As String, ByVal clrColor As Color)
        Dim intCounter As Integer
        Dim intFontSize As Integer
        Dim intWidth As Integer
        'フォントサイズの決定

        intY = 304
        intX = 0
        intY = 0

        '
        With chrMe.Printer.Looks.Image
            intFontSize = .Width / 8
        End With
        intWidth = ((intFontSize + 3) * strMessage.Length + 5)
        'If (Not chrMe.DamageInfo(0) Is Nothing) Then
        '    With chrMe.DamageInfo(0)
        '        '.Width = intWidth
        '        '.Height = intFontSize + 5
        '        .ForeColor = clrColor 'lngColor
        '        .BackColor = Color.FromArgb(&H66, 0, 0)
        '        'RGB(0, 0, 0)
        '        .Font = New Font("Arial Black", intFontSize, Drawing.FontStyle.Regular)
        '        .Text = strMessage  'テキストによりwidth＆heightは自動調整
        '        .Top = intY
        '        .Left = chrMe.Printer.Looks.Width - .Width
        '    End With
        'End If
        Dim newMessage As ShortMessage = New ShortMessage(chrMe.Printer.Looks)

        With newMessage
            .ForeColor = clrColor 'lngColor
            .BackColor = Color.FromArgb(&H66, 0, 0)
            .Font = New Font("Arial Black", intFontSize, Drawing.FontStyle.Regular)
            .Text = strMessage  'テキストによりwidth＆heightは自動調整
            .Top = intY
            .Left = chrMe.Printer.Looks.Width - .Width
        End With
    End Sub

    '================================================================
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Form_Load
        Dim intRet As Integer
        Dim intCounter As Integer
        Dim pctList() As System.Windows.Forms.PictureBox

        m_bgm = New MidPlay(Me.Handle)
        ReDim pctList(3)
        pctList(0) = pctLooks0
        pctList(1) = pctLooks1
        '画面設定
        With pctBack
            For intCounter = 0 To 1
                .Controls.Add(pctList(intCounter))
                pctList(intCounter).Top = pctList(intCounter).Top - .Top
                pctList(intCounter).Left = pctList(intCounter).Left - .Left
            Next intCounter
        End With
        With pctLooks1
            .Controls.Add(cmdUp)
            .Controls.Add(cmdDown)
            .Controls.Add(cmdShop)
            .Controls.Add(cmdBoss)
            .Controls.Add(cmdCall)
            .Controls.Add(cmdHotel)
            cmdUp.Top -= 160
            cmdUp.Left -= (.Left + pctBack.Left)
            cmdDown.Top -= 160
            cmdDown.Left -= (.Left + pctBack.Left)

            cmdShop.Top -= 160
            cmdShop.Left -= (.Left + pctBack.Left)
            cmdBoss.Top -= 160
            cmdBoss.Left -= (.Left + pctBack.Left)
            cmdCall.Top -= 160
            cmdCall.Left -= (.Left + pctBack.Left)
            cmdHotel.Top -= 160
            cmdHotel.Left -= (.Left + pctBack.Left)
        End With

        'インスタンス作成
        ReDim m_easyMes(1)
        m_easyMes(cstChrMain) = New ShortMessage(pctLooks0)
        m_easyMes(cstChrEnemy) = New ShortMessage(pctLooks1)
        '主人公パラメータ画面を作成
        Dim aParamPrinter As ParamPrinter = New ParamPrinter()
        With aParamPrinter
            .HpMeter = GraphicalMeter0
            .Level = lblLevel0
            .Name = lblName0
            .HpMax = lblHpMax0
            .Hp = lblHp0
            .Attack = lblAttack0
            .Deffence = lblDeffence0
            .Speed = lblSpeed0
            .Exp = lblExp0
            .ExpMax = lblExpMax0
            .Mp = lblMp0
            .MpMax = lblMpMax0
            .Money = lblMoney0
            .Looks = pctLooks0
        End With
        ReDim chrMonster(1)
        chrMonster(cstChrMain) = New RPG1Character(aParamPrinter)
        With chrMonster(cstChrMain)
            intRet = .SetPerformance(New RpgPerformAttack()) '攻撃技の装着
            intRet = .SetEquipment(BodyParts.RightHand, Nothing, lblArm0)
            intRet = .SetEquipment(BodyParts.Body, Nothing, lblShield0)
            'Call .SetDamageInfo(New ShortMessage(.Printer.Looks), Nothing, Nothing)
        End With
        stdEnv = New StageDats()
        intRet = fncLoadEquipment("weapon.dat")

        intExecMode = cstGameMode
        '
        intWhoIsOnTurn = 0
        '死亡回数カウンタ
        intDeadCounter = 0
        '宿屋の利用回数
        intHotelPoint = 0
        '遭遇人数
        intBattleCounter = 0
        '殺傷人数
        intKillCounter = 0
        '逃亡カウンタ
        intEscapeCounter = 0

        'Character初期化(パラメータのセット)
        If (Me.IsContinue) Then
            Call MenuItem2_Click(sender, e)
        Else
            Call subInitMyParam(chrMonster(cstChrMain))
        End If

        '画面モード設定
        Call subScreenMode(RpgScreenMode.Normal)

        intEnemyStrength = 18
        intExpBonus = 132
        intMoneyBonus = 11
        intNextLevelUp = 145

        '店のフレームを移動
        fraShop.Top = 432
        fraParamTable.Text = Me.MyName & "の状態"
        chrMonster(cstChrEnemy) = New RPG1Character(aParamPrinter)
        Call subPrintStage(stdEnv, RpgScreenMode.Normal, pctBack, lblStageName)

Exit_Form_Load:
        Exit Sub
Err_Form_Load:
        Call subErrHandle("Form_Load", Err.Number, Err.Description)
        Resume Exit_Form_Load
    End Sub

    Private Sub subScreenMode(ByRef mode As RpgScreenMode)
        On Error GoTo Err_subScreenMode
        Dim intCounter As Integer
        Dim intRet As Integer
        Dim intHeight As Integer

        stdEnv.Screen = mode
        Select Case mode
            Case RpgScreenMode.Battle
                '戦闘時
                cmdUp.Visible = False
                cmdDown.Visible = False
                cmdCall.Visible = False
                'cmdAttack.Enabled = True
                'cmdEscape.Enabled = True
                cmdHotel.Visible = False
                cmdShop.Visible = False
                cmdBoss.Visible = False
                menuSave.Enabled = False
                menuLoad.Enabled = False
            Case RpgScreenMode.Normal
                'Midi Stop
                '通常時
                If (chrMonster(cstChrMain).Stage > stdEnv.Stage) Then
                    cmdUp.Visible = True
                Else
                    cmdUp.Visible = False
                End If
                If (stdEnv.Stage > 1) Then
                    cmdDown.Visible = True
                Else
                    cmdDown.Visible = False
                End If
                cmdCall.Visible = True
                'cmdAttack.Enabled = False
                'cmdEscape.Enabled = False
                cmdHotel.Visible = True
                cmdShop.Visible = True
                cmdBoss.Visible = True
                menuSave.Enabled = True
                menuLoad.Enabled = True
                With pctLooks1
                    intHeight = .Top + .Height
                    intRet = fncLoadPictureToImage(pctLooks1, "image\map.gif")
                    .Width = .Image.Width
                    .Height = .Image.Height
                    .Top = intHeight - .Height
                End With
            Case RpgScreenMode.Boss
                cmdUp.Visible = False
                cmdDown.Visible = False
                cmdCall.Visible = False
                'cmdAttack.Enabled = True
                'cmdEscape.Enabled = False
                cmdHotel.Visible = False
                cmdShop.Visible = False
                cmdBoss.Visible = False
                menuSave.Enabled = False
                menuLoad.Enabled = False
            Case Else
        End Select

Exit_subScreenMode:
        Exit Sub
Err_subScreenMode:
        Call subErrHandle("subScreenMode", Err.Number, Err.Description)
        Resume Exit_subScreenMode
    End Sub

    Private Sub subInitMyParam(ByRef chrMe As Character)
        On Error GoTo Err_subInitMyParam
        Dim intRet As Integer
        Dim intCounter As Integer
        Dim intCounter2 As Integer

        With chrMe
            .ChrName = Trim(Me.MyName)
            'level1
            .Level = 5
            .HpMax = 20 '+ 1000
            .Strength = 40
            .Deffence = 25
            .Speed = 25
            .MpMax = 12 '+ 1000

            For intCounter = 1 To Me.Param(0)
                If (Me.Param(0) < intCounter) Then Exit For
                Call subParamUp(chrMe, enmUpParam.HpMax)
            Next intCounter
            For intCounter = 1 To Me.Param(1)
                If (Me.Param(1) < intCounter) Then Exit For
                Call subParamUp(chrMe, enmUpParam.Str)
            Next intCounter
            For intCounter = 1 To Me.Param(2)
                If (Me.Param(2) < intCounter) Then Exit For
                Call subParamUp(chrMe, enmUpParam.Def)
            Next intCounter
            For intCounter = 1 To Me.Param(3)
                If (Me.Param(3) < intCounter) Then Exit For
                Call subParamUp(chrMe, enmUpParam.Speed)
            Next intCounter
            For intCounter = 1 To Me.Param(4)
                If (Me.Param(4) < intCounter) Then Exit For
                Call subParamUp(chrMe, enmUpParam.MpMax)
            Next intCounter

            .HpMax = .HpMax '* 1.8
            .Mp = .MpMax '* 1.8
            .Exp = 0 '+ 45
            .Hp = .HpMax
            .ExpMax = 46
            .Money = 100
            .Luck = 1
            .LoadPicture("image\me.gif")
            .Printer.Looks.Top = 350 - .Printer.Looks.Height
            'intRet = .fncSetPerformance(atpAttackPat(cstChrMain))
            .Refresh()
            .Stage = 1
            stdEnv.Stage = 1
            Call subGetStageEnv(stdEnv, stdEnv.Stage)
            Call subPrintStage(stdEnv, RpgScreenMode.Normal, pctBack, lblStageName)
            .Perform.Init()
            .Perform.Enabled = 0 '「斬る」を使用可能
            .Perform.Enabled = 1 '「突く」を使用可能
            .Perform.Enabled = 2 '「地獄突き」を使用可能
            .Perform.Enabled = 3 '「突く」を使用可能
            .Perform.Enabled = 4 '「地獄突き」を使用可能
            .Perform.Enabled = 5 '「真空波」を使用可能
            .Perform.Enabled = 6 '「地走り」を使用可能
            .Perform.Enabled = 31 '「火炎」を使用可能
            .Perform.Enabled = 32 '「ニードル」を使用可能
            .Perform.Enabled = 33 '「デス」を使用可能
            .Perform.Enabled = 34 '「死神召還」を使用可能
            .Perform.Enabled = 35 '「業火」を使用可能
            .Perform.Enabled = 36 '「」を使用可能
            .Perform.Enabled = 37 '「」を使用可能
        End With
        intRet = fncSetCommandTree()

Exit_subInitMyParam:
        Exit Sub
Err_subInitMyParam:
        Call subErrHandle("subInitMyParam", Err.Number, Err.Description)
        Resume Exit_subInitMyParam
    End Sub
    Private Function fncLoadEquipment(ByRef strFilename As String) As Object
        On Error GoTo Err_fncLoadEquipment
        Dim intCounter As Integer
        Dim intDataLen As Integer
        Dim strWork As String
        Dim intRet As Integer

        'ファイルオープン
        FileOpen(1, strFilename, OpenMode.Input, , , 32000)
        'ヘッダ読込み
        Input(1, strWork) 'ヘッダ
        intDataLen = Val(strWork)
        ReDim eqpDatas(intDataLen - 1)
        '一行読込み
        For intCounter = 0 To intDataLen - 1
            strWork = LineInput(1) '項目読込み
            eqpDatas(intCounter) = New Equipment()
            intRet = eqpDatas(intCounter).SetParam(strWork)
            '管理番号を添付
            eqpDatas(intCounter).ID = intCounter
        Next intCounter
        'ファイルクローズ
        FileClose(1)

Exit_fncLoadEquipment:
        Exit Function
Err_fncLoadEquipment:
        Call subErrHandle("fncLoadEquipment", Err.Number, Err.Description)
        Resume Exit_fncLoadEquipment
    End Function

    '
    Public Sub subLoadChrParam(ByRef chrMe As Character, ByRef intLevel As Integer, ByRef frmTarget As System.Windows.Forms.Form)
        On Error GoTo Err_subLoadChrParam
        Dim intCounter As Integer
        Dim intCounter2 As Integer
        Dim strDataList As String
        Dim intRet As Integer
        Dim strParam() As String
        Dim intEnemyNum As Integer
        Dim intUpValue As Integer
        Dim strComList() As String
        Dim blnTest As Boolean

        'Character初期化
        intEnemyNum = Fix(Rnd() * stdEnv.EnemyCnt)
        If (intEnemyNum >= stdEnv.EnemyCnt) Then intEnemyNum = 0
        strDataList = stdEnv.EnemyDat(intEnemyNum, cstEnemyBaseDat)
        strParam = Split(strDataList, ",")
        strComList = Split(stdEnv.EnemyDat(intEnemyNum, cstEnemyPerformDat), ",")
        For intCounter = 0 To 4
            intEnemyCommand(intCounter) = Val(strComList(intCounter))
        Next intCounter

        With chrMe
            '
            .SetParam(strDataList)
            blnTest = pctLooks1.Visible
            '.Name = "お前"
            .Level = intLevel - 4 'Fix(Rnd() * 3 + 1)
            'ベース作成
            .HpMax = 20
            .Strength = 40
            .Deffence = 25
            .Speed = 25
            '補正値定義
            '===============================================
            '標準パラメータ取得
            For intCounter2 = 1 To .Level
                For intCounter = 0 To 4
                    Select Case intCounter 'intUpParam
                        Case 0
                            '.HpMax = .HpMax + 2
                            intUpValue = Fix(.HpMax / cstLevelUpWait)
                            If (intUpValue = 0) Then intUpValue = 1
                            .HpMax += intUpValue / 2
                        Case 1
                            '.Strength = .Strength + 1
                            intUpValue = Fix(.Strength / cstLevelUpWait)
                            If (intUpValue = 0) Then intUpValue = 1
                            .Strength += intUpValue / 2
                        Case 2
                            intUpValue = Fix(.Deffence / cstLevelUpWait)
                            If (intUpValue = 0) Then intUpValue = 1
                            .Deffence += intUpValue / 2
                            '.Deffence = .Deffence + 1
                        Case 3
                            intUpValue = Fix(.Speed / cstLevelUpWait)
                            If (intUpValue = 0) Then intUpValue = 1
                            .Speed += intUpValue / 2
                            '.Speed = .Speed + 1
                        Case 4
                            '.HpMax = .HpMax + 2
                            intUpValue = Fix(.MpMax / cstLevelUpWait)
                            If (intUpValue = 0) Then intUpValue = 1
                            .MpMax += intUpValue / 2
                    End Select
                Next intCounter
            Next intCounter2

            .Exp = 5 + .Level
            .ExpMax = 0
            .Money = 7 + .Level / 2
            '性格付け
            .HpMax = Fix(.HpMax * (Val(strParam(3)) / 100))
            .Strength = Fix(.Strength * (Val(strParam(5)) / 100))
            .Deffence = Fix(.Deffence * (Val(strParam(6)) / 100))
            .Speed = Fix(.Speed * (Val(strParam(7)) / 100))
            .Exp = Fix(.Exp * (Val(strParam(9)) / 100))
            .Money = Fix(.Money * (Val(strParam(11)) / 100))
            .Hp = .HpMax

            .ShowMyImage()
        End With
Exit_subLoadChrParam:
        Exit Sub
Err_subLoadChrParam:
        Call subErrHandle("subLoadChrParam", Err.Number, Err.Description)
        Resume Exit_subLoadChrParam
    End Sub

    Private Sub cmdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUp.Click
        stdEnv.Stage += 1
        Call stageClose()
        Call subGetStageEnv(stdEnv, stdEnv.Stage)
        Call subPrintStage(stdEnv, RpgScreenMode.Normal, pctBack, lblStageName)
        subScreenMode(RpgScreenMode.Normal)
        Call stageOpen()
    End Sub

    Private Sub cmdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDown.Click
        stdEnv.Stage -= 1
        Call stageClose()
        Call subGetStageEnv(stdEnv, stdEnv.Stage)
        Call subPrintStage(stdEnv, RpgScreenMode.Normal, pctBack, lblStageName)
        subScreenMode(RpgScreenMode.Normal)
        Call stageOpen()

    End Sub

    Private Sub stageClose()
        Dim intCounter As Integer
        Dim intLoopEnd As Integer = 416
        For intCounter = 0 To intLoopEnd Step 32
            pctBack.Width = intLoopEnd - intCounter
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(10)
        Next
    End Sub
    Private Sub stageOpen()
        Dim intCounter As Integer
        Dim intLoopEnd As Integer = 416
        For intCounter = 0 To intLoopEnd Step 32
            pctBack.Width = intCounter
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(10)
        Next
    End Sub
    '
    Private Sub subEscape()
        Dim intRet As Integer
        '
        intEscapeCounter = intEscapeCounter + 1
        '逃避
        intRet = fncEscape(chrMonster(cstChrMain), chrMonster(cstChrEnemy), lblMessage)
        If (intRet) Then
            'ターン交代
            Call subChangeTurn(cstChrEnemy)
            Call subAttackClick(-1, Nothing) '続けて敵の攻撃
        Else
            '逃亡成功
            '画面モード設定
            chrMonster(cstChrEnemy) = Nothing '敵オブジェクトの破棄
            Call subScreenMode(RpgScreenMode.Normal)
        End If

    End Sub

    Public Function fncEscape(ByRef chrMe As Character, ByRef chrTarget As Character, ByRef objDisplay As Object) As Integer
        On Error GoTo Err_fncEscape
        Call subSetMessage(objDisplay, chrMe.ChrName & "は逃げ出した…", cstOverWrite)
        If (chrMe.CanIEscape(chrTarget)) Then
            Call subSetMessage(objDisplay, "…上手く逃げのびた。", cstUpdate)
            fncEscape = 0
        Else
            Call subSetMessage(objDisplay, "…逃げられない！", cstUpdate)
            fncEscape = -1
        End If
Exit_fncEscape:
        Exit Function
Err_fncEscape:
        Call subErrHandle("fncEscape", Err.Number, Err.Description)
        Resume Exit_fncEscape
    End Function
    '
    Public Sub LevelUpChr(ByRef clsTarget As Character)
        Dim intCounter As Integer
        With clsTarget
            'レベルを増加
            .Level += 1
            'レベルアップメッセージの表示
            If (Not .Printer.Looks Is Nothing) Then
                For intCounter = 1 To 255 Step 2
                    Call subPrintChrMessage(clsTarget, .Printer.Looks.Left, .Printer.Looks.Top + .Printer.Looks.Height / 4, "LevelUp", Color.FromArgb(intCounter, intCounter, 0))
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(20)
                Next intCounter
            End If
            '次のレベルアップ経験値の決定
            .ExpMax = .ExpMax + Fix((5 + .Level) * (8 + .Level / 2)) '1.45 'intNextLevelUp / 100

            subParamUp(clsTarget, enmUpParam.HpMax)
            subParamUp(clsTarget, enmUpParam.Str)
            subParamUp(clsTarget, enmUpParam.Def)
            subParamUp(clsTarget, enmUpParam.Speed)
            subParamUp(clsTarget, enmUpParam.MpMax)

        End With
    End Sub
    Public Sub subParamUp(ByRef clsTarget As Character, ByRef intUpParam As Integer)
        Try
            Dim intUpValue As Integer

            With clsTarget

                Select Case intUpParam
                    Case enmUpParam.HpMax
                        '最大HP
                        intUpValue = Fix(.HpMax / cstLevelUpWait)
                        If (intUpValue = 0) Then intUpValue = 1
                        .HpMax += intUpValue / 2
                    Case enmUpParam.Str
                        '攻撃力
                        intUpValue = Fix(.Strength / cstLevelUpWait)
                        If (intUpValue = 0) Then intUpValue = 1
                        .Strength += intUpValue / 2
                    Case enmUpParam.Def
                        '防御力
                        intUpValue = Fix(.Deffence / cstLevelUpWait)
                        If (intUpValue = 0) Then intUpValue = 1
                        .Deffence += intUpValue / 2
                    Case enmUpParam.Speed
                        '瞬発力
                        intUpValue = Fix(.Speed / cstLevelUpWait)
                        If (intUpValue = 0) Then intUpValue = 1
                        .Speed += intUpValue / 2
                    Case enmUpParam.MpMax
                        '精神力
                        intUpValue = Fix(.MpMax / cstLevelUpWait)
                        If (intUpValue = 0) Then intUpValue = 1
                        .MpMax += Fix(intUpValue / 2)
                End Select
            End With
        Catch ex As Exception
            Call subErrHandle(ex.TargetSite.Name, Err.Number, ex.Message)
        End Try
    End Sub
    '
    Public Function fncHeal(ByRef chrMe As Character, ByRef objDisplay As Object) As Integer
        On Error GoTo Err_fncHeal
        fncHeal = 0
        With chrMe
            .Money = .Money - Fix(.HpMax / 4)
            .Hp = .HpMax
            .Mp = .MpMax
            .Refresh()

            Call subSetMessage(objDisplay, "HPが回復した。", cstOverWrite)
            intHotelPoint = intHotelPoint + 1
        End With
Exit_fncHeal:
        Exit Function
Err_fncHeal:
        Call subErrHandle("fncHeal", Err.Number, Err.Description)
        Resume Exit_fncHeal
    End Function

    Private Sub trvCommand_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvCommand.AfterSelect
        Dim intTypeNum As Integer

        Dim myNode As TreeNode = e.Node

        If (Not myNode Is Nothing) Then
            trvCommand.Enabled = False
            With chrMonster(cstChrMain)
                Select Case myNode.Tag
                    Case "_110"
                        If (stdEnv.Screen = RpgScreenMode.Normal) Then
                            'MsgBox ("とんづら")
                            Call subSetMessage(lblMessage, "[" & "とんずら" & "]" & vbCr & vbLf & "瞬発力が成功率に影響する。", cstOverWrite)
                        ElseIf (stdEnv.Screen = RpgScreenMode.Boss) Then
                            Call subSetMessage(lblMessage, "ここで逃げるわけにはいきません。", cstOverWrite)
                        Else
                            Call subEscape()
                        End If
                    Case "_120"
                        If (stdEnv.Screen = RpgScreenMode.Normal) Then
                            Call subSetMessage(lblMessage, "[" & "命乞い" & "]" & vbCr & vbLf & "有り金の1/2を渡し、すごい勢いで命乞いをする。成功率は1/2。", cstOverWrite)
                        ElseIf (stdEnv.Screen = RpgScreenMode.Boss) Then
                            Call subSetMessage(lblMessage, "買収できる相手ではありません。", cstOverWrite)
                        Else
                            Call subHelpMe()
                        End If
                    Case Else
                        Dim aPartOfTag As String = CType(myNode.Tag, String).Substring(0, 3)
                        If (aPartOfTag = "_21" Or aPartOfTag = "_31" Or aPartOfTag = "_41") Then
                            intTypeNum = Val(CType(myNode.Tag, String).Substring(3, 2))
                            If (aPartOfTag = "_31" Or aPartOfTag = "_41") Then
                                intTypeNum = intTypeNum + 30
                            End If
                            If (stdEnv.Screen <> RpgScreenMode.Normal) Then
                                'MsgBox ("通常攻撃")
                                If (.Perform.LossMp(intTypeNum) <= .Mp) Then
                                    .Mp = chrMonster(cstChrMain).Mp - .Perform.LossMp(intTypeNum)
                                    .Refresh()
                                    Call subAttackClick(intTypeNum, myNode)
                                Else
                                    Call subSetMessage(lblMessage, "精神力が足りない。", cstOverWrite)
                                End If
                            Else
                                Call subSetMessage(lblMessage, "[" & .Perform.Name(intTypeNum) & "]" & vbCr & vbLf & "消費する精神力は" & CStr(.Perform.LossMp(intTypeNum)) & "。" & vbCr & vbLf & .Perform.Help(intTypeNum), cstOverWrite)
                            End If
                        End If
                End Select
            End With
            trvCommand.Enabled = True
        End If
        '同じノードを選択するとイベントが発生しない問題への対策
        trvCommand.SelectedNode = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        If (Not m_bgm Is Nothing) Then
            m_bgm.StopNow()
        End If
        m_bgm = Nothing
        MyBase.Finalize()
    End Sub

    Public Sub subPrintStage(ByRef stdValue As StageDats, ByRef mode As RpgScreenMode, ByRef imgBack As System.Windows.Forms.PictureBox, ByRef lblTitle As System.Windows.Forms.Label)
        On Error GoTo Err_subPrintStage
        Dim intRet As Integer

        Select Case mode
            Case RpgScreenMode.Normal
                With stdValue
                    lblTitle.Text = .Title
                    intRet = fncLoadPictureToImage(imgBack, .NormalBack)
                    'マップアイコンの設定
                    cmdCall.Left = stdValue.mapIcon(enmButtonIcon.CallEnemy).X
                    cmdCall.Top = stdValue.mapIcon(enmButtonIcon.CallEnemy).Y
                    cmdHotel.Left = stdValue.mapIcon(enmButtonIcon.Hotel).X
                    cmdHotel.Top = stdValue.mapIcon(enmButtonIcon.Hotel).Y
                    cmdShop.Left = stdValue.mapIcon(enmButtonIcon.Shop).X
                    cmdShop.Top = stdValue.mapIcon(enmButtonIcon.Shop).Y
                    cmdBoss.Left = stdValue.mapIcon(enmButtonIcon.Boss).X
                    cmdBoss.Top = stdValue.mapIcon(enmButtonIcon.Boss).Y
                End With
            Case RpgScreenMode.Boss
                With stdValue
                    lblTitle.Text = .Title
                    intRet = fncLoadPictureToImage(imgBack, .BossBack)
                End With
            Case Else
        End Select
Exit_subPrintStage:
        Exit Sub
Err_subPrintStage:
        Call subErrHandle("subPrintStage", Err.Number, Err.Description)
        Resume Exit_subPrintStage
    End Sub

    Private Sub cmdCloseShop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseShop.Click
        '店のフレームを移動
        fraShop.Top = 432
    End Sub

End Class
