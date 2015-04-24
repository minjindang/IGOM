Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class NoticePersonDAO
        Inherits BaseDAO

        Public Sub New()
        End Sub

        Public Function getDataByLeaveType(ByVal Orgcode As String, ByVal Leave_type As String) As DataTable
            Dim sql As String = String.Empty
            sql &= " select n.* , p.User_name, p.Email from FSC_Notice_person n "
            sql &= " inner join FSC_Personnel p on p.id_card = n.id_card "
            sql &= " where 1=1 "

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql &= " and n.Orgcode = @Orgcode "
            End If
            If Not String.IsNullOrEmpty(Leave_type) Then
                sql &= " and n.Leave_type = @Leave_type "
            End If

            Dim paras(1) As SqlParameter
            paras(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            paras(0).Value = Orgcode
            paras(1) = New SqlParameter("@Leave_type", SqlDbType.VarChar)
            paras(1).Value = Leave_type

            Return Query(sql, paras)
        End Function
    End Class
End Namespace
