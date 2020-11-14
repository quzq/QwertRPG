Option Strict Off
Option Explicit On 

Public Class Equipment

    Private Structure EquipmentDats
        Dim AlivingNow As Boolean '現在使われているか？
        Dim intPart As Integer
        Dim strName As String
        Dim intHpMax As Integer
        Dim intHp As Integer
        Dim intAttack As Integer
        Dim intDeffence As Integer
        Dim intSpeed As Integer
        Dim intWisdom As Integer
        Dim intLevel As Integer
        Dim intExp As Integer
        Dim intExpMax As Integer
        Dim intMoney As Integer
        Dim intPrice As Integer
        Dim intNumber As Integer '管理番号
    End Structure

    Private eqdData As Equipment.EquipmentDats


    '***********************プロパティ宣言部***********************
    '最大HP
    'Str
    Public Property Strength() As Integer
        Get
            Strength = eqdData.intAttack
        End Get
        Set(ByVal Value As Integer)
            eqdData.intAttack = Value
        End Set
    End Property
    'Def
    Public Property Deffence() As Integer
        Get
            Deffence = eqdData.intDeffence
        End Get
        Set(ByVal Value As Integer)
            eqdData.intDeffence = Value
        End Set
    End Property
    '
    Public Property ItemName() As String
        Get
            ItemName = eqdData.strName
        End Get
        Set(ByVal Value As String)
            eqdData.strName = Value
        End Set
    End Property
    '
    Public Property Price() As Integer
        Get
            Price = eqdData.intPrice
        End Get
        Set(ByVal Value As Integer)
            eqdData.intPrice = Value
        End Set
    End Property
    'Def
    Public Property Speed() As Integer
        Get
            Speed = eqdData.intSpeed
        End Get
        Set(ByVal Value As Integer)
            eqdData.intSpeed = Value
        End Set
    End Property
    '
    Public Property Part() As Integer
        Get
            Part = eqdData.intPart
        End Get
        Set(ByVal Value As Integer)
            eqdData.intPart = Value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            ID = eqdData.intNumber
        End Get
        Set(ByVal Value As Integer)
            eqdData.intNumber = Value
        End Set
    End Property

    'CSVデータより取得
    Public Function SetParam(ByRef strData As String) As Integer
        On Error GoTo Err_SetParam
        'パラメータ取得
        Dim strTemp() As String
        strTemp = Split(strData, ",")
        With eqdData
            .intPart = CInt(strTemp(0))
            .strName = strTemp(1)
            .intPrice = CInt(strTemp(2))
            .intAttack = CInt(strTemp(3))
            .intDeffence = CInt(strTemp(4))
        End With
Exit_SetParam:
        Exit Function
Err_SetParam:
        Call subErrHandle("SetParam", Err.Number, Err.Description)
        Resume Exit_SetParam
    End Function
End Class