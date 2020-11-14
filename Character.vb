Option Strict Off
Option Explicit On 

'==========================================================
Public Class RPG1Character : Inherits Character

    Private m_paramPrinter As ParamPrinter

    Private atpPerform As RpgPerformAttack '技

    Private eqpBodyEquip(cstBodyPartsMax) As Equipment
    Private ctlDamageInfo(3) As ShortMessage

    'プロパティー宣言
    Public Overrides ReadOnly Property TotalStrength() As Integer
        Get
            TotalStrength = Me.Strength
            If (Not eqpBodyEquip(BodyParts.RightHand) Is Nothing) Then
                With eqpBodyEquip(BodyParts.RightHand)
                    TotalStrength = TotalStrength + .Strength
                End With
            End If
            If (Not eqpBodyEquip(BodyParts.Body) Is Nothing) Then
                With eqpBodyEquip(BodyParts.Body)
                    TotalStrength = TotalStrength + .Strength
                End With
            End If
        End Get
    End Property
    'Def
    Public Overrides ReadOnly Property TotalDeffence() As Integer
        Get
            TotalDeffence = Me.Deffence
            If (Not eqpBodyEquip(BodyParts.RightHand) Is Nothing) Then
                With eqpBodyEquip(BodyParts.RightHand)
                    TotalDeffence = TotalDeffence + .Deffence
                End With
            End If
            If (Not eqpBodyEquip(BodyParts.Body) Is Nothing) Then
                With eqpBodyEquip(BodyParts.Body)
                    TotalDeffence = TotalDeffence + .Deffence
                End With
            End If

        End Get
    End Property

    Public Overrides ReadOnly Property TotalSpeed() As Integer
        Get
            TotalSpeed = Me.Speed
            If (Not eqpBodyEquip(BodyParts.RightHand) Is Nothing) Then
                With eqpBodyEquip(BodyParts.RightHand)
                    TotalSpeed = TotalSpeed + .Speed
                End With
            End If
            If (Not eqpBodyEquip(BodyParts.Body) Is Nothing) Then
                With eqpBodyEquip(BodyParts.Body)
                    TotalSpeed = TotalSpeed + .Speed
                End With
            End If
        End Get
    End Property

    Public Overrides ReadOnly Property Printer() As ParamPrinter
        Get
            Return m_paramPrinter
        End Get
    End Property

    Public Overrides ReadOnly Property Perform() As RpgPerformAttack
        Get
            Perform = atpPerform
        End Get
    End Property

    Public Overrides ReadOnly Property EquipID(ByVal intPart As Integer) As Integer
        Get
            If (intPart >= cstBodyPartsMax) Then
                EquipID = -2
            ElseIf (Not eqpBodyEquip(intPart) Is Nothing) Then
                EquipID = eqpBodyEquip(intPart).ID
            Else
                EquipID = -1
            End If
        End Get
    End Property

    'Public Overrides ReadOnly Property DamageInfo(ByVal ID As Integer) As ShortMessage
    '    Get
    '        If (ID >= 3) Then
    '            DamageInfo = Nothing
    '        Else
    '            DamageInfo = ctlDamageInfo(ID)
    '        End If
    '    End Get
    'End Property

    '
    Public Overrides Function SetEquipment(ByRef intType As Integer, ByRef eqpValue As Equipment, ByRef lblPrinter As System.Windows.Forms.Label) As Integer
        Me.Printer.Equip(intType) = lblPrinter
        SetEquipment = ChangeEquipment(intType, eqpValue)
    End Function
    '
    Public Overrides Function SetPerformance(ByVal atpValue As RpgPerformAttack) As Integer
        atpPerform = atpValue
    End Function

    '
    Public Overrides Function ChangeEquipment(ByRef intType As Integer, ByRef eqpValue As Equipment) As Integer
        eqpBodyEquip(intType) = eqpValue
    End Function

    'Public Overrides Sub SetDamageInfo(ByRef Value1 As ShortMessage, ByRef Value2 As ShortMessage, ByRef Value3 As ShortMessage)
    '    '
    '    ctlDamageInfo(0) = Value1
    '    ctlDamageInfo(1) = Value2
    '    ctlDamageInfo(2) = Value3
    'End Sub

    'Public Overrides Sub ClearDamageInfo()
    '    Dim intCounter As Integer
    '    '
    '    For intCounter = 0 To 2
    '        If (Not ctlDamageInfo(intCounter) Is Nothing) Then
    '            ctlDamageInfo(intCounter).Text = ""
    '        End If
    '    Next intCounter
    'End Sub

    Public Overrides Sub Refresh()
        Dim intCounter As Integer

        If (Not Me.Printer.Name Is Nothing) Then
            Me.Printer.Name.Text = Me.ChrName
        End If
        If (Not Me.Printer.Level Is Nothing) Then
            Me.Printer.Level.Text = Me.Level.ToString.Trim
        End If
        If (Not Me.Printer.HpMax Is Nothing) Then
            Me.Printer.HpMax.Text = Me.HpMax.ToString.Trim
        End If
        If (Not Me.Printer.Hp Is Nothing) Then
            Me.Printer.Hp.Text = Me.Hp.ToString.Trim
        End If
        If (Not Me.Printer.Speed Is Nothing) Then
            Me.Printer.Speed.Text = Me.TotalSpeed.ToString.Trim
        End If
        If (Not Me.Printer.Attack Is Nothing) Then
            Me.Printer.Attack.Text = Me.TotalStrength.ToString.Trim
        End If
        If (Not Me.Printer.Deffence Is Nothing) Then
            Me.Printer.Deffence.Text = Me.TotalDeffence.ToString.Trim
        End If
        If (Not Me.Printer.Exp Is Nothing) Then
            Me.Printer.Exp.Text = Me.Exp.ToString.Trim
        End If
        If (Not Me.Printer.ExpMax Is Nothing) Then
            Me.Printer.ExpMax.Text = Me.ExpMax.ToString.Trim
        End If
        If (Not Me.Printer.Mp Is Nothing) Then
            Me.Printer.Mp.Text = Me.Mp.ToString.Trim
        End If
        If (Not Me.Printer.MpMax Is Nothing) Then
            Me.Printer.MpMax.Text = Me.MpMax.ToString.Trim
        End If
        If (Not Me.Printer.Money Is Nothing) Then
            Me.Printer.Money.Text = Me.Money.ToString.Trim
        End If
        If (Not Me.Printer.HpMeter Is Nothing) Then
            Me.Printer.HpMeter.MaxValue = Me.HpMax
            Me.Printer.HpMeter.RestValue = Me.Hp
        End If
        '装備の表示
        For intCounter = 0 To UBound(eqpBodyEquip) - 1
            If (Not eqpBodyEquip(intCounter) Is Nothing) Then
                If (Not Me.Printer.Equip(intCounter) Is Nothing) Then
                    Me.Printer.Equip(intCounter).Text = eqpBodyEquip(intCounter).ItemName
                End If
            Else
                If (Not Me.Printer.Equip(intCounter) Is Nothing) Then
                    Me.Printer.Equip(intCounter).Text = "なし"
                End If
            End If
        Next intCounter

    End Sub

    '==============================================
    'ダメージセット
    Public Overrides Sub AddHp(ByRef intShoot As Integer)
        Me.Hp += intShoot
        If (Not Me.Printer.HpMeter Is Nothing) Then
            Me.Printer.HpMeter.MaxValue = Me.HpMax
            Me.Printer.HpMeter.RestValue = Me.Hp
        End If
    End Sub

    '==============================================
    '粗攻撃力取得
    Public Overrides Function UseAttack(ByVal intAttackType As Integer, ByVal chrTarget As Character) As Integer
        Dim intArmDef As Integer
        Dim intArmAttack As Integer
        Dim aRandomMaker As System.Random = New System.Random()
        Dim intTotalEnemyDef As Integer = chrTarget.TotalDeffence
        Dim intEnemyDef As Integer = chrTarget.Deffence

        '甲.STR － 乙.DEF
        'ミニマムダメージ
        'ダメージが0以下の場合は､
        '甲.STR ／ (乙.DEF ＋ 1)
        'の確率で1ダメージ
        'fncGetAttack = fncAddRandam(getRealStrength() - intEnemyDef, cstRandBace)
        'If (fncGetAttack < 1) Then
        '    If (getRealStrength() <= (Rnd() * (intEnemyDef + 1))) Then
        '        '強制的にダメージ1
        '        fncGetAttack = 1
        '    Else
        '        fncGetAttack = 0
        '    End If
        'End If
        intArmDef = intTotalEnemyDef - intEnemyDef
        intArmAttack = Me.TotalStrength - Me.Strength

        UseAttack = fncGetBattlePoint(Me.Strength, intEnemyDef)
        If (UseAttack < 1) Then
            If (Me.Strength <= (aRandomMaker.Next(0, intTotalEnemyDef))) Then
                '強制的にダメージ1
                'fncGetAttack = 1
                '再計算
                UseAttack = fncGetBattlePoint(Me.Strength, intTotalEnemyDef)
                If (UseAttack = 0) Then
                    UseAttack = fncGetBattlePoint(Me.Strength, intTotalEnemyDef)
                End If
            Else
                UseAttack = 0
            End If
        End If
        '攻撃技による補正
        If (intAttackType <> -1) Then
            UseAttack = Me.Perform.UseAttack(intAttackType, UseAttack, CType(chrTarget, Character))
        End If
    End Function

    Private Function fncGetBattlePoint(ByRef intStr As Integer, ByRef intDef As Integer) As Integer
        Dim aRandomMaker As System.Random = New System.Random()
        'fncGetAttack = Fix((Rnd() * 0.5 + 0.5) * intAttack + intArmAttack - (Rnd() * 0.5 + 0.5) * intEnemyRealDef - intArmDef)
        fncGetBattlePoint = (Fix((Rnd() * 0.5 + 0.5) * intStr - (Rnd() * 0.5 + 0.5) * intDef)) / 5
        If (fncGetBattlePoint < 1) Then
            fncGetBattlePoint = 0
        End If
    End Function

    '==============================================
    '逃亡可否
    Public Overrides Function CanIEscape(ByVal target As Character) As Boolean
        '先制確率､逃亡確率
        '甲.SPD ／ (甲.SPD ＋ 乙.SPD)
        'つまり､両者のスピードの比が､先制を取る確率の比｡
        '例）主人公のSPD = 3、敵のSPD = 2なら、主人公が先制を取る確率は５分の３
        '例）主人公のSPD = 3、敵のSPD = 2なら、主人公が逃げ切れる確率は５分の３
        If (Me.TotalSpeed <= (Rnd() * (target.Speed + Me.TotalSpeed))) Then
            Return True
        Else
            Return False
        End If
    End Function

    '==============================================
    '命中可否
    Public Overrides Function CanIHit(ByVal target As Character) As Boolean
        '命中判定
        '0.5 × {甲.SPD ／ (甲.SPD ＋ 乙.SPD)} ＋ 0.5
        'つまり､2回に一回は当たる｡
        'その一回で当たらなければ､先制確率と同じ式で判定ということ｡
        If (Rnd() < 0.5 Or Me.TotalSpeed >= Rnd() * (target.Speed + Me.TotalSpeed)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Overrides Sub Finalize()
        atpPerform = Nothing
        MyBase.Finalize()
    End Sub

    '==============================================
    Public Overrides Function LoadPicture(ByRef strFile As String) As Integer
        On Error GoTo Err_fncLoadPicture
        Dim intRet As Integer
        Me.ChrPicFile = strFile
        intRet = ShowMyImage()
Exit_fncLoadPicture:
        Exit Function
Err_fncLoadPicture:
        Call subErrHandle("fncLoadPicture", Err.Number, Err.Description)
        Resume Exit_fncLoadPicture
    End Function

    Public Overrides Function ShowMyImage() As Integer
        Dim intHeight As Integer
        Dim intRet As Integer
        Dim intCounter As Integer
        'Dim imsCharaGif As ImageSize

        If (Not Me.Printer.Looks Is Nothing) Then
            With Me.Printer.Looks
                intHeight = .Top + .Height
                intRet = fncLoadPictureToImage(Me.Printer.Looks, Me.ChrPicFile)

                .Height = .Image.Height '.Height
                .Width = .Image.Width
                .Height = 0
                For intCounter = 0 To .Image.Height Step 8
                    .Height = intCounter
                    '.Height = .Image.Height
                    .Top = intHeight - intCounter
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(5)
                Next intCounter
                .Height = .Image.Height
                .Top = intHeight - .Height
            End With
        End If
    End Function

    Public Sub New(ByVal value As ParamPrinter)
        MyBase.new()
        If (value Is Nothing) Then  '指定なしの場合、表示オブジェクトを自動作成
            m_paramPrinter = New ParamPrinter()
        Else
            m_paramPrinter = value
        End If
    End Sub

End Class
'==================================================================
'ベースクラス
'==================================================================
Public MustInherit Class Character

    Private m_hpMax As Integer = 0
    Private m_hp As Integer = 0
    Private m_attack As Integer = 0
    Private m_deffence As Integer = 0
    Private m_speed As Integer = 0
    Private m_wisdom As Integer = 0
    Private m_luck As Integer = 0
    Private m_level As Integer = 0
    Private m_mp As Integer = 0
    Private m_mpMax As Integer = 0
    Private m_exp As Integer = 0
    Private m_expMax As Integer = 0
    Private m_money As Integer = 0
    Private m_stage As Integer = 0
    Private m_name As String = ""

    Private m_pctFilename As String = ""

    Public MustOverride ReadOnly Property TotalDeffence() As Integer
    Public MustOverride ReadOnly Property TotalStrength() As Integer
    Public MustOverride ReadOnly Property TotalSpeed() As Integer
    Public MustOverride ReadOnly Property Printer() As ParamPrinter
    Public MustOverride ReadOnly Property Perform() As RpgPerformAttack
    Public MustOverride ReadOnly Property EquipID(ByVal intPart As Integer) As Integer
    'Public MustOverride ReadOnly Property DamageInfo(ByVal ID As Integer) As ShortMessage

    Public MustOverride Sub Refresh()
    Public MustOverride Sub AddHp(ByRef intShoot As Integer)
    Public MustOverride Function UseAttack(ByVal intAttackType As Integer, ByVal chrTarget As Character) As Integer
    Public MustOverride Function CanIEscape(ByVal target As Character) As Boolean
    Public MustOverride Function CanIHit(ByVal target As Character) As Boolean
    Public MustOverride Function LoadPicture(ByRef strFile As String) As Integer
    Public MustOverride Function ShowMyImage() As Integer
    'Public MustOverride Sub SetDamageInfo(ByRef Value1 As ShortMessage, ByRef Value2 As ShortMessage, ByRef Value3 As ShortMessage)
    'Public MustOverride Sub ClearDamageInfo()
    Public MustOverride Function ChangeEquipment(ByRef intType As Integer, ByRef eqpValue As Equipment) As Integer
    Public MustOverride Function SetPerformance(ByVal atpValue As RpgPerformAttack) As Integer
    Public MustOverride Function SetEquipment(ByRef intType As Integer, ByRef eqpValue As Equipment, ByRef lblPrinter As System.Windows.Forms.Label) As Integer

    '***********************プロパティ宣言部***********************
    '最大HP
    Public Property HpMax() As Integer
        Get
            HpMax = m_hpMax
        End Get
        Set(ByVal Value As Integer)
            m_hpMax = Value
        End Set
    End Property
    'HP
    Public Property Hp() As Integer
        Get
            Hp = m_hp
        End Get
        Set(ByVal Value As Integer)
            m_hp = Value
            If (m_hp < 1) Then m_hp = 0
            If (m_hp > m_hpMax) Then m_hp = m_hpMax
        End Set
    End Property
    Public Property Strength() As Integer
        Get
            Strength = m_attack
        End Get
        Set(ByVal Value As Integer)
            m_attack = Value
        End Set
    End Property
    'Str
    Public Property Deffence() As Integer
        Get
            Deffence = m_deffence
        End Get
        Set(ByVal Value As Integer)
            m_deffence = Value
        End Set
    End Property
    'Speed
    Public Property Speed() As Integer
        Get
            Speed = m_speed
        End Get
        Set(ByVal Value As Integer)
            m_speed = Value
        End Set
    End Property
    'Level
    Public Property Level() As Integer
        Get
            Level = m_level
            '    PropertyChanged "Level"
        End Get
        Set(ByVal Value As Integer)
            m_level = Value
        End Set
    End Property
    'Name
    Public Property ChrName() As String
        Get
            ChrName = m_name
        End Get
        Set(ByVal Value As String)
            m_name = Value
        End Set
    End Property
    'exp
    Public Property Exp() As Integer
        Get
            Exp = m_exp
        End Get
        Set(ByVal Value As Integer)
            m_exp = Value
        End Set
    End Property
    'expMax
    Public Property ExpMax() As Integer
        Get
            ExpMax = m_expMax
        End Get
        Set(ByVal Value As Integer)
            m_expMax = Value
        End Set
    End Property
    'Mp
    Public Property Mp() As Integer
        Get
            Mp = m_mp
        End Get
        Set(ByVal Value As Integer)
            m_mp = Value
        End Set
    End Property
    'MpMax
    Public Property MpMax() As Integer
        Get
            MpMax = m_mpMax
        End Get
        Set(ByVal Value As Integer)
            m_mpMax = Value
        End Set
    End Property
    'expMax
    Public Property Stage() As Integer
        Get
            Stage = m_stage
        End Get
        Set(ByVal Value As Integer)
            m_stage = Value
        End Set
    End Property
    'Name
    Public Property Money() As Integer
        Get
            Money = m_money
        End Get
        Set(ByVal Value As Integer)
            m_money = Value
        End Set
    End Property
    'Name
    Public Property Luck() As Integer
        Get
            Luck = m_luck
        End Get
        Set(ByVal Value As Integer)
            m_luck = Value
        End Set
    End Property
    'Name
    Public Property Wisdom() As Integer
        Get
            Wisdom = m_wisdom
        End Get
        Set(ByVal Value As Integer)
            m_wisdom = Value
        End Set
    End Property
    'Name
    Public Property ChrPicFile() As String
        Get
            ChrPicFile = m_pctFilename
        End Get
        Set(ByVal Value As String)
            m_pctFilename = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub
    '==============================================
    '生死取得
    Public Function IsAlive() As Boolean
        If (Me.Hp <= 0) Then
            IsAlive = False
        Else
            IsAlive = True
        End If
    End Function
    '==============================================
    '経験値獲得
    Public Function AddExp(ByRef intValue As Integer) As Integer
        Dim intRet As Integer = 0

        Me.Exp = Me.Exp + intValue
        If (Me.Exp >= Me.ExpMax) Then
            'レベルアップイベント発生
            'RaiseEvent LevelUp()
            intRet = -1
            '次レベルを設定
            'intExp = 0
            'intExpMax = intExpMax * 1.3
        End If
        Return intRet
    End Function

    'CSVデータより取得
    Public Function SetParam(ByRef strData As String) As Integer
        'パラメータ取得
        Dim intRet As Integer
        Dim strTemp() As String
        strTemp = Split(strData, ",")
        Me.ChrName = strTemp(0)
        m_pctFilename = strTemp(1)
        Me.Level = Val(strTemp(2))
        Me.HpMax = Val(strTemp(3))
        Me.Hp = Val(strTemp(4))
        Me.Strength = Val(strTemp(5))
        Me.Deffence = Val(strTemp(6))
        Me.Speed = Val(strTemp(7))
        Me.Wisdom = Val(strTemp(8))
        Me.Exp = Val(strTemp(9))
        Me.ExpMax = Val(strTemp(10))
        Me.Money = Val(strTemp(11))
        Me.Luck = Val(strTemp(12))
        Me.Stage = Val(strTemp(13))
        Me.Mp = Val(strTemp(14))
        Me.MpMax = Val(strTemp(15))
        ' DUMMY intRet = fncReload()
        Return 0
    End Function

    Public Function GetParam() As String
        'パラメータ取得
        Dim strTemp(15) As String
        strTemp(0) = Me.ChrName
        strTemp(1) = m_pctFilename
        strTemp(2) = Me.Level.ToString.Trim
        strTemp(3) = Me.HpMax.ToString.Trim
        strTemp(4) = Me.Hp.ToString.Trim
        strTemp(5) = Me.Strength.ToString.Trim
        strTemp(6) = Me.Deffence.ToString.Trim
        strTemp(7) = Me.Speed.ToString.Trim
        strTemp(8) = Me.Wisdom.ToString.Trim
        strTemp(9) = Me.Exp.ToString.Trim
        strTemp(10) = Me.ExpMax.ToString.Trim
        strTemp(11) = Me.Money.ToString.Trim
        strTemp(12) = Me.Luck.ToString.Trim
        strTemp(13) = Me.Stage.ToString.Trim
        strTemp(14) = Me.Mp.ToString.Trim
        strTemp(15) = Me.MpMax.ToString.Trim
        Return Join(strTemp, ",")
    End Function

End Class


Public Class ParamPrinter
    Public Hp As System.Windows.Forms.Label = Nothing
    Public HpMax As System.Windows.Forms.Label = Nothing
    Public Name As System.Windows.Forms.Label = Nothing
    Public Deffence As System.Windows.Forms.Label = Nothing
    Public Attack As System.Windows.Forms.Label = Nothing
    Public Speed As System.Windows.Forms.Label = Nothing
    Public Level As System.Windows.Forms.Label = Nothing
    Public Looks As System.Windows.Forms.PictureBox = Nothing
    Public Money As System.Windows.Forms.Label = Nothing
    Public Exp As System.Windows.Forms.Label = Nothing
    Public ExpMax As System.Windows.Forms.Label = Nothing
    Public Mp As System.Windows.Forms.Label = Nothing
    Public MpMax As System.Windows.Forms.Label = Nothing

    Public HpMeter As GraphicalMeter = Nothing
    Public Equip() As System.Windows.Forms.Label = Nothing

    Public Sub New()
        ReDim Equip(cstBodyPartsMax)
    End Sub

    Public Sub Clear()
        If (Not Hp Is Nothing) Then
            Hp.Text = ""
        End If
        If (Not Name Is Nothing) Then
            Name.Text = ""
        End If

    End Sub

    Protected Overrides Sub Finalize()
        Me.Clear()
        MyBase.Finalize()
    End Sub

End Class
