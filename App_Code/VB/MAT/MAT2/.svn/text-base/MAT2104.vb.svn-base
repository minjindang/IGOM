Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT2104
        Public DAO As MAT2104DAO

        Public Sub New()
            DAO = New MAT2104DAO()
        End Sub

        Public Function MAT2104SelectData(ByVal In_dateS As String, ByVal In_dateE As String, ByVal Material_idS As String, ByVal Material_idE As String) As DataTable
            Dim dt As DataTable
            dt = DAO.MAT2104SelectData(In_dateS, In_dateE, Material_idS, Material_idE)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace