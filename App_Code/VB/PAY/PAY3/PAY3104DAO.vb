Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3104DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function SelectCCMember(depart_id As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select * from EMP_Member a ,emp_depart_emp b where a.id_card=b.id_card and b.depart_id=@depart_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@depart_id", depart_id)}
            Return Query(strSQL, ps)
        End Function

    End Class
End Namespace
