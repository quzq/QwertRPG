Option Explicit

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.UnmanagedType

Public Class CbfFileUtility

    Public Const SIZE_FILENAME As Integer = 24
    Public Const SIZE_TITLE    As Integer = 76
    Public Const SIZE_MUSICAL  As Integer = 40
    Public Const SIZE_LYRICIST As Integer = 40
   
'    自力で MidiFile.cbf からデータを取得する場合、以下の構造体を使用する
'    Public Structure CBFPreHeader
'        Public TotalNum As Integer               'MIDIファイル総数
'    End Structure
    
    '旧VB：FileName As String * 48 の意
    '      <VBFixedStringAttribute(48)> Public FileName As String

'    Public Structure CBFHeader
'        <VBFixedStringAttribute(SIZE_FILENAME)> Public FileName As String 'MIDIファイル名
'        <VBFixedStringAttribute(SIZE_TITLE)>    Public Title As String    'MIDIタイトル
'        Public MadeYear As Integer                                        '作成年
'        <VBFixedStringAttribute(SIZE_MUSICAL)>  Public Musical As String  'ミュージカル
'        <VBFixedStringAttribute(SIZE_LYRICIST)> Public Lyricist As String '作詞者
'        Public FileLength As Integer                                      'MIDIファイルのサイズ
'        Public ReadPos As Integer                                         'ファイル読み込み位置
'    End Structure  

    'API 以下のを使用する場合、利用する構造体はこちら
    '固定長文字列の場合、変数の前に以下のような定義を宣言しないといけないみたい、すごいなこりゃ...
    ' <VBFixedString(100), _
    '      System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, _
    '        SizeConst:=100)> Public xxxx As String
    Private Structure CBFHeaderAPI
        <VBFixedString(SIZE_FILENAME), _
          MarshalAs(ByValTStr, SizeConst:=SIZE_FILENAME)> Public FileName As String 'MIDIファイル名
        <VBFixedString(SIZE_TITLE), _
          MarshalAs(ByValTStr, SizeConst:=SIZE_TITLE)>    Public Title As String    'MIDIタイトル
        Public MadeYear As Integer                                                  '作成年
        <VBFixedString(SIZE_MUSICAL), _
          MarshalAs(ByValTStr, SizeConst:=SIZE_MUSICAL)>  Public Musical As String  'ミュージカル
        <VBFixedString(SIZE_MUSICAL), _
          MarshalAs(ByValTStr, SizeConst:=SIZE_MUSICAL)>  Public Lyricist As String '作詞者
        Public FileLength As Integer                                                'MIDIファイルのサイズ
        Public ReadPos As Integer                                                   'ファイル読み込み位置
    End Structure  

    Private Declare Function CBF_IsExistFile Lib "CBFUtil.dll" Alias "#1" () As Boolean

    Private Declare Function CBF_GetMIDINum Lib "CBFUtil.dll" Alias "#2" () As Integer

    Private Declare Function CBF_GetMIDIHeaderFromIndex Lib "CBFUtil.dll" Alias "#3" (ByVal Index As Integer, ByRef header As CBFHeaderAPI) As Integer

    Private Declare Function CBF_GetMIDIHeaderFromMIDI Lib "CBFUtil.dll" Alias "#4" (ByVal MIDIFile As String, ByRef header As CBFHeaderAPI) As Integer

    Private Declare Function CBF_GetMIDIHeaderIndex Lib "CBFUtil.dll" Alias "#5" (ByVal MIDIFile As String) As Integer
        
    Private Declare Function CBF_MIDIExcract Lib "CBFUtil.dll" Alias "#6" (ByVal Index As Integer) As Integer
        
    'Public Declare Function CBF_GetMIDIHeaderAll Lib "CBFUtil.dll" Alias "#7" (ByRef head As CBFHeaderAPI()) As Integer
    '↑これは使えるかどうか不明

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

    Public Const CBFFILE_NAME As String = "MidiFile.cbf" 
    Private MIDITotalNum As Integer
    Private LastCBFUtilError As Integer

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： CBFUtilErrorValue(プロパティ)
    ' 機  能： 最後に実行したAPI関数の返り値を取得する
    ' 引  数： なし
    ' 返り値： 最後に実行したAPI関数の返り値
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ReadOnly Property CBFUtilErrorValue() As Integer
        Get
            Return LastCBFUtilError
        End Get
    End Property

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetMIDINum(プロパティ)
    ' 機  能： MidiFile.cbf に格納されている MIDI ファイル数を取得する
    ' 引  数： なし
    ' 返り値： MidiFile.cbf に格納されている MIDI ファイル数
    '          エラー時は０より小さい値が返る
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    ReadOnly Property MIDINum() As Integer
        Get
            If MIDITotalNum = 0 Then
                LastCBFUtilError = CBF_GetMIDINum()
                If LastCBFUtilError <> 0 Then
                    MIDITotalNum = LastCBFUtilError
                End If
            End If
            Return MIDITotalNum
        End Get
    End Property

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetMIDINum
    ' 機  能： MidiFile.cbf に格納されている MIDI ファイル数を取得する
    ' 引  数： なし
    ' 返り値： MidiFile.cbf に格納されている MIDI ファイル数
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    'Private Function GetMIDINum() As Integer
    '    GetMIDINum = MIDINum()
    'End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetMIDIHeaderIndex
    ' 機  能： Midiファイル名からインデックスを取得する
    ' 引  数： (o)udtMidiInfo() … MidiInfo 構造体配列
    '          (i)Length        … udtMidiInfo() 配列数
    ' 返り値： 正常時：0  異常時：０より小さい値が返る
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function GetMIDIHeaderIndex(ByVal MIDIFileName As String) As Integer
        LastCBFUtilError = CBF_GetMIDIHeaderIndex(MIDIFileName)
        GetMIDIHeaderIndex = LastCBFUtilError
    End Function    

    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetMidiHeaderInfo
    ' 機  能： MidiFile.cbf に格納されている MIDIヘッダ情報を取得する
    ' 引  数： (o)udtMidiInfo() … MidiInfo 構造体配列
    '          (i)Length        … udtMidiInfo() 配列数
    ' 返り値： 正常時：0  異常時：０より小さい値が返る
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function GetMidiHeaderInfo(ByRef udtMidiInfo() As MidiInfo, ByVal Length As Integer) As Integer
        Dim i as Integer
        Dim udtCBFHeaderAPI As CBFHeaderAPI

        For i = 0 To Length - 1
            LastCBFUtilError = CBF_GetMIDIHeaderFromIndex(i, udtCBFHeaderAPI)
            If LastCBFUtilError < 0 Then Exit For

            With udtMidiInfo(i)
                .MIDITitle    = Trim$(udtCBFHeaderAPI.Title)
                .MIDIFileName = Trim$(udtCBFHeaderAPI.FileName)
            End With
        Next i

        GetMidiHeaderInfo = LastCBFUtilError
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： extract
    ' 機  能： MidiFile.cbf ファイルより MIDI ファイルを抽出する
    ' 引  数： (i)MIDIIndex  … Midiインデックス
    ' 返り値： 正常時：0  異常時：０より小さい値が返る
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function Extract(ByVal MIDIIndex As Integer) As Integer
        Dim FuncRet As Integer
        LastCBFUtilError = CBF_MIDIExcract(MIDIIndex)
    End Function


    '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    ' 関数名： GetErrorMessage
    ' 機  能： エラーコードに対応するメッセージを返す
    ' 引  数： (i)ErrorCode … エラーコード
    ' 返り値： エラーコードに対応するメッセージ
    '=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    Public Function GetErrorMessage() As String
        Return GetErrorMessage(CBFUtilErrorValue)
    End Function
    Public Function GetErrorMessage(ByVal ErrorCode As Integer) As String
        Dim ErrorMsg As String = "想定外のエラーが発生しました"

        Select Case ErrorCode
            Case 0
                ErrorMsg = "正常に処理されました。"
            Case (-1)
                ErrorMsg = CBFFILE_NAME & " ファイルが存在しません。"
            Case (-2)
                ErrorMsg = CBFFILE_NAME & " ファイルを開けません。"
            Case (-3)
                ErrorMsg = "データ取得に失敗しました。"
            Case (-4)
                ErrorMsg = "不正なインデックスを受け取りました。"
            Case (-5)
                ErrorMsg = "MIDIファイル名が見つかりませんでした。"
            Case (-6)
                ErrorMsg = "メモリー確保に失敗しました。"
            Case (-7)
                ErrorMsg = "MIDIデータ読み込みに失敗しました。"
            Case (-8)
                ErrorMsg = "MIDIデータ書き込みに失敗しました。"
        End Select
        
        GetErrorMessage = ErrorMsg
    End Function
End Class

