Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic

    Public Class LeaveNGroup
        Dim DAO As LeaveNGroupDAO

        Public Sub New()
            DAO = New LeaveNGroupDAO()
        End Sub

        Public Function GetLeaveNGroup(ByVal Leave_type As String) As DataTable
            Dim ndt As DataTable
            'Elbert20130522 如果登入者是一級機關首長則群組請假、群組公差不要出現
            If Not LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).Equals("LevelOne") Then
                ndt = DAO.GetLeaveNGroup(Leave_type, False)
            Else
                ndt = DAO.GetLeaveNGroup(Leave_type, True)
            End If
            Return ndt
        End Function


        Public Function GetLeaveOtherData(ByVal Leave_type As String) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("Value", GetType(String))
            dt.Columns.Add("Text", GetType(String))

            Dim dr As DataRow

            Select Case Leave_type
                Case "3"
                    '「休假」
                    dr = dt.NewRow
                    dr("Value") = "Travel"
                    dr("Text") = "國民旅遊卡"
                    dt.Rows.Add(dr)

                Case "6"
                    '「公假」
                    dr = dt.NewRow
                    dr("Value") = "Health"
                    dr("Text") = "健康檢查"
                    dt.Rows.Add(dr)

                    dr = dt.NewRow
                    dr("Value") = "Class"
                    dr("Text") = "奉（指）派上課"
                    dt.Rows.Add(dr)

            End Select

            Return dt
        End Function


    End Class
End Namespace