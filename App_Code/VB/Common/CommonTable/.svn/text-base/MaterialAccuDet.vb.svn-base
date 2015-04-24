Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MaterialAccuDet
        Public DAO As MaterialAccuDetDAO

        Public Sub New()
            DAO = New MaterialAccuDetDAO()
        End Sub

        Public Function GetOne(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String) As DataRow
            Dim dt As DataTable = DAO.GetOne(orgCode, MAccu_yyymm, MAccu_mtrid)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt.Rows(0)
        End Function

        Public Function GetMAccu_store(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String) As Double
            Dim dr As DataRow = GetOne(orgCode, MAccu_yyymm, MAccu_mtrid)
            If dr Is Nothing Then
                Return 0
            End If
            Return CommonFun.SetDataRow(dr, "MAccu_store")
        End Function

        Public Sub Insert(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String, MAccu_remain As Double, MAccu_in As Double, _
                               MAccu_out As Double, MAccu_modify As Double, MAccu_store As Double, MAccu_date As String, ModUser_id As String, Mod_date As DateTime)
            DAO.Insert(orgCode, MAccu_yyymm, MAccu_mtrid, MAccu_remain, MAccu_in, MAccu_out, MAccu_modify, MAccu_store, MAccu_date, ModUser_id, Mod_date)
        End Sub

        Public Sub Update(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String, MAccu_remain As Double, MAccu_in As Double, _
                               MAccu_out As Double, MAccu_modify As Double, MAccu_store As Double, MAccu_date As String, ModUser_id As String, Mod_date As DateTime)
            DAO.Update(orgCode, MAccu_yyymm, MAccu_mtrid, MAccu_remain, MAccu_in, MAccu_out, MAccu_modify, MAccu_store, MAccu_date, ModUser_id, Mod_date)
        End Sub

        Public Function InsertOrUpdate(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String, MAccu_remain As Double, MAccu_in As Double, _
                               MAccu_out As Double, MAccu_modify As Double, MAccu_store As Double, MAccu_date As String, ModUser_id As String, Mod_date As DateTime, isOverwirte As Boolean) As String
            Dim dt As DataTable = DAO.GetOne(orgCode, MAccu_yyymm, MAccu_mtrid)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                If isOverwirte Then 
                    Update(orgCode, MAccu_yyymm, MAccu_mtrid, MAccu_remain, MAccu_in, MAccu_out, MAccu_modify, MAccu_store, MAccu_date, ModUser_id, Mod_date)
                    Return ""
                Else
                    Return "該月底結算資料已存在，是否重新計算"
                End If
            Else
                Insert(orgCode, MAccu_yyymm, MAccu_mtrid, MAccu_remain, MAccu_in, MAccu_out, MAccu_modify, MAccu_store, MAccu_date, ModUser_id, Mod_date)
                Update(orgCode, MAccu_yyymm, MAccu_mtrid, MAccu_remain, MAccu_in, MAccu_out, MAccu_modify, MAccu_store, MAccu_date, ModUser_id, Mod_date)
                Return ""
            End If
        End Function


        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            DAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

    End Class
End Namespace
