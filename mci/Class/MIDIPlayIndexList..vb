Option Explicit

Imports Microsoft.VisualBasic

Public Class MIDIPlayIndexList
    Const ListSize As Long = 15
    Private PlayIndexList() As Integer

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' コンストラクタ
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Sub New()
        Dim i As Integer

        'PlayIndexList を -1 で初期化
        ReDim PlayIndexList(ListSize)
        For i = 0 To UBound(PlayIndexList)
            PlayIndexList(i) = (-1)
        Next i
    End Sub

    '---------------------------------------------------------------------------
    ' 関数名： AddIndex
    ' 機  能： インデックスを追加する
    ' 引  数： (in)Index … インデックス
    ' 返り値： なし
    '---------------------------------------------------------------------------
    Public Sub AddIndex(ByVal Index As Integer)
        Dim i As Long

        'インデックスをずらす
        For i = UBound(PlayIndexList) To 1 Step (-1)
            PlayIndexList(i) = PlayIndexList(i - 1)
        Next i
        
        PlayIndexList(0) = Index
    End Sub

    '---------------------------------------------------------------------------
    ' 関数名： GetNextPlayMIDIIndex
    ' 機  能： 次に再生するMIDIファイルインデックスを取得
    ' 引  数： (in)MaxNum … インデックス最大値
    ' 返り値： 次に再生するMIDIファイルインデックス
    '---------------------------------------------------------------------------
    Public Function GetNextPlayMIDIIndex(ByVal MaxNum As Long) As Long
        Dim NextNum As Long
        Dim i As Long

        '0～MaxNum-1 までの数字をランダムで取得
        Randomize   'ジェネレータ初期化
        NextNum = Int(Rnd(1) * MaxNum)

        '過去15件のインデックスと重複しない数字を取得する
        For i = 0 To UBound(PlayIndexList)
            If NextNum = PlayIndexList(i) Then
                NextNum = GetNextPlayMIDIIndex(MaxNum) '再帰
                Exit For
            End If
        Next i
        
        GetNextPlayMIDIIndex = NextNum
    End Function


End Class
