Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class ErrorLog
        Public DAO As ErrorLogDAO

        Public Sub New()
            DAO = New ErrorLogDAO()
        End Sub

        Public Function insert(ByVal Message As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Message", Message)
            d.Add("create_date", Now)

            Return DAO.InsertByExample("SYS_Errorlog", d)
        End Function
    End Class
End Namespace
