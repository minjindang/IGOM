Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class ApplyMaterialMain

        Public DAO As ApplyMaterialMainDAO

        Public Sub New()
            DAO = New ApplyMaterialMainDAO()
        End Sub

        Public Sub Insert(ByVal Flow_id As String, ByVal Form_type As String, ByVal Apply_date As String, ByVal Unit_Code As String, ByVal User_id As String, _
                                ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal Orgcode As String)
            DAO.Insert(Flow_id, Form_type, Apply_date, Unit_Code, User_id, ModUser_id, Mod_date, Orgcode)
        End Sub

        Public Function GetOne(flow_id As String, orgCode As String) As DataRow
            Dim dt As DataTable = DAO.GetOne(flow_id, orgCode)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt.Rows(0)
        End Function


        Public Function DeleteByOrgFid(flow_id As String, orgCode As String) As Boolean
            Return DAO.DeleteByOrgFid(flow_id, orgCode)
        End Function

    End Class
End Namespace
