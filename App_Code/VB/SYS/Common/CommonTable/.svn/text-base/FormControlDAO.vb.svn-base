Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FormControlDAO
        Inherits BaseDAO

        Public Function getDataByFormId(ByVal Form_id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Form_id", Form_id)

            Return GetDataByExample("SYS_Form_Control", d)
        End Function
    End Class
End Namespace
