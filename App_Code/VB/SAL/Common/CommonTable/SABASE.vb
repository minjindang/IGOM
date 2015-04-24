Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    Public Class SABASE
        Private DAO As SABASEDAO

        Public Sub New()
            DAO = New SABASEDAO()
        End Sub

        Public Function GetColumnValue(columnName As String, seqno As String) As String
            Dim dt As DataTable = DAO.GetDataBySEQNO(seqno)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columnName).ToString()
            End If
            Return ""
        End Function

    End Class
End Namespace