Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SAL.Logic
    Public Class SABASEDAO
        Inherits BaseDAO


        Public Function GetDataBySEQNO(seqno As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("BASE_SEQNO", seqno)

            Return GetDataByExample("SAL_SABASE", d)
        End Function

    End Class
End Namespace