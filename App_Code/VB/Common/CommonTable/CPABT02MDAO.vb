Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSCPLM.Logic
    Public Class CPABT02MDAO
        Inherits BaseDAO

        Public Sub New()

        End Sub

        Public Sub New(ByVal connstring As String)
            MyBase.New(connstring)
        End Sub

        Public Function GetDataByB02IDNO(ByVal B02IDNO As String) As DataTable
            Dim sql As String = String.Empty
            sql = "SELECT * FROM CPABT02M WHERE B02IDNO=@B02IDNO"
            Dim param As SqlParameter = New SqlParameter("@B02IDNO", SqlDbType.VarChar)
            param.Value = B02IDNO

            Return Query(sql, param)
        End Function
    End Class

End Namespace