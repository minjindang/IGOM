Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    Public Class PaySalChgNoticSendListDAO
        Inherits BaseDAO

        Public Sub New()

        End Sub

        Public Function delete() As Integer
            Dim sql As String = " delete from SAL_PaySalChgNotic_SendList "

            Return Execute(sql)
        End Function
    End Class
End Namespace
