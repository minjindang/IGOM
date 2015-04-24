Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class ApplyMaterialDet
        Public DAO As ApplyMaterialDetDAO
        Dim mmDAO As Material_main
        Public Sub New()
            DAO = New ApplyMaterialDetDAO()
            mmDAO = New Material_main()
        End Sub

        Public Sub Insert(ByVal Flow_id As String, ByVal Material_id As String, ByVal Apply_cnt As Integer, ByVal Out_cnt As Integer, ByVal Out_date As String, _
                          ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal Orgcode As String)
            DAO.Insert(Flow_id, Material_id, Apply_cnt, Out_cnt, Out_date, Memo, ModUser_id, Mod_date, Orgcode)
        End Sub

        Public Function GetApplyCnt(Material_id As String, User_id As String, Apply_dateS As String, Apply_dateE As String) As Integer
            Return DAO.GetApplyCnt(Material_id, User_id, Apply_dateS, Apply_dateE)
        End Function

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return DAO.GetMaterialCnt(Material_id)
        End Function

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                    ByVal OrgCode As String, ByVal Mod_date As DateTime)
            DAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

        Public Function GetSumOutCnt(OrgCode As String, YearMonth As String) As DataTable
            Return DAO.GetSumOutCnt(OrgCode, YearMonth)
        End Function

        Public Function GetOut_cnt(orgCode As String, yearMonth As String) As DataTable
            Return DAO.GetOut_cnt(orgCode, yearMonth)
        End Function

        Public Function GetOut_cnt(orgCode As String, yearMonth As String, materialID As String) As Integer
            Dim dt As DataTable = GetOut_cnt(orgCode, yearMonth)
            Dim dtRows() As DataRow = dt.Select(String.Format(" Material_id = '{0}' ", materialID))
            If Not dtRows Is Nothing AndAlso dtRows.Length > 0 Then
                dt = dtRows.CopyToDataTable()
                Return dt.Rows(0)("Out_cnt")
            Else
                Return 0
            End If
        End Function

        Public Function GetByFlow(flow_id As String, orgCode As String) As DataTable
            Dim dt As DataTable = DAO.GetByFlow(flow_id, orgCode)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt
        End Function

        Public Function GetOne(flow_id As String, orgCode As String, detail_id As String) As DataRow
            Dim dt As DataTable = DAO.GetOne(flow_id, orgCode, detail_id)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Return dt.Rows(0)
        End Function

        Public Function SelectDepartName(ByVal Orgcode As String) As DataTable
            Return DAO.SelectDepartName(Orgcode)
        End Function

        Public Function SelectUerName(ByVal Orgcode As String) As DataTable
            Return DAO.SelectUerName(Orgcode)
        End Function

        Public Function MAT2106_Print(ByVal ucType As String, ByVal Depart_id As String, ByVal User_id As String, ByVal OrgCode As String) As DataTable
            Return DAO.MAT2106_Print(ucType, Depart_id, User_id, OrgCode)
        End Function

        Public Function GetMaterialName(ByVal tbMaterial_id As String) As DataRow
            Dim dt As DataTable = DAO.SelectMaterialName(tbMaterial_id)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If
            'Dim dt As DataTable = mmDAO.GetMatData(tbMaterial_id, tbMaterial_id)
            'If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            '    Return Nothing
            'Else
            '    Return dt.Rows(0)
            'End If
        End Function

        Public Function MAT2107_Print(ByVal tbMaterial_id As String, ByVal ddlUser_name As String, ByVal UcDateS As String, _
                  ByVal UcDateE As String, ByVal ddlDepart_id As String, ByVal OrgCode As String) As DataTable
            Return DAO.MAT2107_Print(tbMaterial_id, ddlUser_name, UcDateS, UcDateE, ddlDepart_id, LoginManager.OrgCode)
        End Function

        Public Function DeleteByOrgFid(flow_id As String, orgCode As String) As Boolean
            Return DAO.DeleteByOrgFid(flow_id, orgCode)
        End Function


        Public Function GetApplyCnt(Material_id As String, Flow_id As String, Orgcode As String) As Integer
            Return DAO.GetApplyCnt(Material_id, Flow_id, Orgcode)
        End Function

        Public Function UpdateOutCnt(orgcode As String, flowId As String, outCnt As String, materialId As String) As Integer
            Return DAO.UpdateOutCnt(orgcode, flowId, outCnt, materialId)
        End Function
    End Class
End Namespace