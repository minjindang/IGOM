Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic

    Public Class ReportDetail

        Public department As String = String.Empty
        Public pename As String = String.Empty
        Public pecard As String = String.Empty
        Public peidno As String = String.Empty
        Public pekind As String = String.Empty
        Public pewktype As String = String.Empty
        Public pkstime As String = String.Empty
        Public pkntime As String = String.Empty
        Public pketime As String = String.Empty
        Public needNoonCard As String = String.Empty
        Public workHour As Integer = 0
        Public actualWorkHour As Integer = 0
        Public pkwktpe As String = String.Empty
        Public list As New Collection


        Public Sub setNeedNoonCard(ByVal card As String)
            If card = "1" Then
                needNoonCard = "需要"
            Else
                needNoonCard = "不需"
            End If
        End Sub

        Public Sub setPkwktpe(ByVal pk As Integer)
            'Select Case pk
            '    Case 0
            '        pkwktpe = "刷卡不一致"
            '    Case 1
            '        pkwktpe = "遲到"
            '    Case 2
            '        pkwktpe = "早退"
            '    Case 3
            '        pkwktpe = "曠職"
            '    Case 4
            '        pkwktpe = "遲到早退"
            '    Case 5
            '        pkwktpe = "已處理"
            '    Case 6
            '        pkwktpe = "正常"
            '    Case 7
            '        pkwktpe = "卡片版本不一致"
            '    Case 8
            '        pkwktpe = "無刷卡資料"
            'End Select

            pkwktpe = New FSCPLM.Logic.SACode().GetCodeDesc("023", "009", pk)
        End Sub

        Public Sub setPewkType(ByVal type As String)
            If type = "0" Then
                pewktype = "正常班"
            ElseIf (type.Equals("1")) Then
                pewktype = "彈性班"
            ElseIf (type.Equals("2")) Then
                pewktype = "輪班"
            ElseIf (type.Equals("3")) Then
                pewktype = "免刷卡"
            End If
        End Sub

    End Class

End Namespace