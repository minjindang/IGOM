Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class CPABT02M
        Dim DAO As CPABT02MDAO

        Public Sub New()
            DAO = New CPABT02MDAO
        End Sub
        Public Sub New(ByVal connstring As String)
            DAO = New CPABT02MDAO(connstring)
        End Sub

        Public Function GetBT02MByB02IDNO(ByVal B02IDNO As String) As DataTable
            Return DAO.GetDataByB02IDNO(B02IDNO)
        End Function

    End Class
End Namespace