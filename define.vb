Option Strict Off
Option Explicit On 

Public Module mdlDef
    '
    Public Const cstOK As Integer = 0
    Public Const cstNG As Integer = -1
    '
    Public Const cstGameMode As Integer = 0
    Public Const cstSimulateMode As Integer = 1

    Public intNextLevelUp As Integer

    Public Const AtkPatMax As Integer = 99

    Public intExecMode As Integer
    Public intEnemyStrength As Integer
    Public intExpBonus As Integer
    Public intMoneyBonus As Integer

    Public Const cstChrMain As Integer = 0
    Public Const cstChrEnemy As Integer = 1

    Public Enum RpgScreenMode
        Battle
        Normal
        Shop
        Boss
    End Enum
    'Public Const cstScreenBattle As Integer = 1
    'Public Const cstScreenNormal As Integer = 2
    'Public Const cstScreenShop As Integer = 3
    'Public Const cstScreenBoss As Integer = 4

    'パラメータの上がりにくさ
    Public Const cstLevelUpWait As Integer = 6
    '
    Public Const cstEnemyHosei As Double = 1.8

    '死亡回数カウンタ
    Public intDeadCounter As Integer
    '宿屋の利用回数
    Public intHotelPoint As Integer
    '遭遇人数
    Public intBattleCounter As Integer
    '殺傷人数
    Public intKillCounter As Integer
    '逃亡カウンタ
    Public intEscapeCounter As Integer
    '
    Public Const cstBodyPartsMax As Integer = 4
    Public Enum BodyParts
        Body = 0
        Head = 1
        RightHand = 2
        LeftHand = 3
    End Enum
    'Public Const cstBody As Integer = 0
    'Public Const cstHead As Integer = 1
    'Public Const cstRightHand As Integer = 2
    'Public Const cstLeftHand As Integer = 3

    Public Const cstEquipMax As Integer = 20

    'Public Const cstCelMax As Integer = 10 'アニメーション・スプライト数

    Public Const cstXMeter As Integer = 1
    Public Const cstYMeter As Integer = 2
    Public Const cstOverWrite As Integer = 0
    Public Const cstUpdate As Integer = 1

    Public Const cstEnemyMax As Integer = 10
    Public Const cstEnemyBaseDat As Integer = 0
    Public Const cstEnemyPerformDat As Integer = 1

    Public Structure XYlocation
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure StageDats
        Dim Screen As RpgScreenMode
        Dim Stage As Integer
        Dim Title As String
        Dim NormalBack As String
        '    BossPic As String
        Dim BossBack As String
        Dim BossDat() As String
        Dim EnemyCnt As Integer
        Dim EnemyDat(,) As String
        Dim mapIcon() As XYlocation
        Public Sub Initialize()
            ReDim BossDat(2)
            ReDim EnemyDat(cstEnemyMax - 1, 2)
            Stage = 1
        End Sub
    End Structure

    Public Enum enmButtonIcon
        CallEnemy = 0
        Shop = 1
        Hotel = 2
        Boss = 3
    End Enum

    '
    Public Sub subGetStageEnv(ByRef stdTarget As StageDats, ByVal intValue As Integer)
        On Error GoTo Err_subGetStageEnv
        Dim intRet As Integer
        With stdTarget
            Select Case intValue
                Case 1
                    .Title = "STAGE 1:レダ・アトミカ"
                    .NormalBack = "image/back03.jpg"
                    'Name Filename Level HpMax Hp
                    'Attack Deffence Speed Wisdom Exp
                    'ExpMax Money Luck Stage Mp
                    'MpMax
                    ReDim .BossDat(2)
                    .BossDat(0) = "吐炎竜,image\boss02.gif,10,156,156,73,47,21,0,286,0,382,1,1,10,10,-1,-1,-1,-1"
                    .BossDat(1) = "-1,-1,-1,31,31"
                    '.BossPic = "image\boss01.gif"
                    ReDim .EnemyDat(5, 2)
                    .BossBack = "image\back02.jpg"
                    .EnemyCnt = 5
                    .EnemyDat(0, 0) = "木人形,image\e01.gif,1,80,1,90,60,70,1,100,1,100,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(0, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(1, 0) = "ちびロボ,image\e02.gif,1,80,1,110,110,120,1,130,1,100,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(1, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(2, 0) = "二面どろろ,image\e10.gif,1,80,1,90,80,80,1,90,1,90,10,10,10,1,-1,-1,-1,-1"
                    .EnemyDat(2, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(3, 0) = "オタフライ,image\e09.gif,1,80,1,80,100,50,1,100,1,100,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(3, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(4, 0) = "出歯ウサギ,image\e04.gif,1,80,1,100,100,100,1,100,1,120,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(4, 1) = "-1,-1,-1,-1,-1"
                    ReDim .mapIcon(4)
                    .mapIcon(enmButtonIcon.CallEnemy).X = 128 - 16
                    .mapIcon(enmButtonIcon.CallEnemy).Y = 200 - 160
                    .mapIcon(enmButtonIcon.Hotel).X = 144 - 16
                    .mapIcon(enmButtonIcon.Hotel).Y = 256 - 160
                    .mapIcon(enmButtonIcon.Shop).X = 80 - 16
                    .mapIcon(enmButtonIcon.Shop).Y = 232 - 160
                    .mapIcon(enmButtonIcon.Boss).X = 96 - 16
                    .mapIcon(enmButtonIcon.Boss).Y = 288 - 160
                    'Y-160,X-16

                Case 2
                    .Title = "STAGE 2:微粒子の聖母"
                    .NormalBack = "image/back01.jpg"
                    'Level,HpMax,Hp,Atk,Def,Spd,Wis,Exp,ExpMax,Money,Luck
                    ReDim .BossDat(2)
                    .BossDat(0) = "吐炎竜,image\boss02.gif,4,156,156,83,47,21,0,286,545,382,1,1,10,10,-1,-1,-1,-1"
                    .BossDat(1) = "-1,-1,-1,-1,31"
                    '.BossPic = "image\boss01.gif"
                    ReDim .EnemyDat(5, 2)
                    .BossBack = "image\back02.jpg"
                    .EnemyCnt = 5
                    .EnemyDat(0, 0) = "老人の木,image\e05.gif,1,80,1,90,60,70,1,100,1,100,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(0, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(1, 0) = "ほほえみ,image\e07.gif,1,80,1,110,110,60,1,120,1,100,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(1, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(2, 0) = "未確認飛行物体,image\e12.gif,1,80,1,90,80,80,1,90,1,90,10,10,10,1,-1,-1,-1,-1"
                    .EnemyDat(2, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(3, 0) = "ドリルクラブ,image\e13.gif,1,80,1,80,100,130,1,100,1,120,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(3, 1) = "-1,-1,-1,-1,-1"
                    .EnemyDat(4, 0) = "スラッグ,image\e14.gif,1,80,1,100,80,100,1,100,1,120,10,1,10,10,-1,-1,-1,-1"
                    .EnemyDat(4, 1) = "-1,-1,-1,-1,-1"
                    ReDim .mapIcon(4)
                    .mapIcon(enmButtonIcon.CallEnemy).X = 136 - 16
                    .mapIcon(enmButtonIcon.CallEnemy).Y = 216 - 160
                    .mapIcon(enmButtonIcon.Hotel).X = 160 - 16
                    .mapIcon(enmButtonIcon.Hotel).Y = 256 - 160
                    .mapIcon(enmButtonIcon.Shop).X = 0 - 16
                    .mapIcon(enmButtonIcon.Shop).Y = 400 - 160
                    .mapIcon(enmButtonIcon.Boss).X = 64 - 16
                    .mapIcon(enmButtonIcon.Boss).Y = 264 - 160
                Case 3
                Case 4
            End Select
        End With
Exit_subGetStageEnv:
        Exit Sub
Err_subGetStageEnv:
        Call subErrHandle("subGetStageEnv", Err.Number, Err.Description)
        Resume Exit_subGetStageEnv
    End Sub
    '
End Module
