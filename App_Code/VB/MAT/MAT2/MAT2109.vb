Imports Microsoft.VisualBasic
Imports System.Data

Namespace MAT.Logic
    Public Class MAT2109
        Public DAO As MAT2109DAO

        Public Sub New()
            DAO = New MAT2109DAO()
        End Sub
        Public Function MAT2109Select(ByVal Material_detS As String, _
                                          ByVal Material_detE As String, _
                                          ByVal ReceiveDayS As String, _
                                          ByVal ReceiveDayE As String) As DataTable
            Dim dt As DataTable

            dt = DAO.MAT2109Select(Material_detS, Material_detE, ReceiveDayS, ReceiveDayE)

            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace