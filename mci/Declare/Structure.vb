
'ユーザープレイリスト構造体
Public Structure PlaylistMenuInfo
    Public Title As String
    Public FileName As String
End Structure


'MIDI情報構造体
Public Structure MidiInfo
    Public MIDITitle    As String
    Public MIDIFileName As String
End Structure

'ユーザー定義MIDIリプレイリスト
Public Structure UserMidiList
    Public PlayList As System.Collections.ArrayList
    Public IsPlayList As Boolean
    Public PlayIndex As Integer

    '初期化
    Public Sub init()
        PlayList = New System.Collections.ArrayList
        IsPlayList = False
        PlayIndex = (-1)
    End Sub
End Structure

'-=-=-=-=-=-=-=-=-=-=-=-=-=
'     API関連構造体
'=-=-=-=-=-=-=-=-=-=-=-=-=-
Public Structure RECT
    Public Left As Integer
    Public Top As Integer
    Public Right As Integer
    Public Bottom As Integer
End Structure
