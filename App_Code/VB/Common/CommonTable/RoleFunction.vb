Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class RoleFunction
        Public DAO As RoleFunctionDAO
        Public Sub New()
            DAO = New RoleFunctionDAO()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Role_id As String, ByVal Func_id As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode, Role_id, Func_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

    End Class
End Namespace
