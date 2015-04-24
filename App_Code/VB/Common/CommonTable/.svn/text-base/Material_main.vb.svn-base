Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class Material_main
        Public DAO As Material_mainDAO

        Public Sub New()
            DAO = New Material_mainDAO()
        End Sub

        Public Function GetDataByIds(ids As String) As DataTable
            If String.IsNullOrEmpty(ids) Then
                Return Nothing
            Else
                Dim ps As String = ""
                For Each id As String In ids.Split(",")
                    ps &= String.Format("'{0}',", id)
                Next
                ps &= "''"
                Return DAO.GetDataByIds(ps)
            End If

        End Function

        Public Function GetAll(ByVal Material_id As String, ByVal location As String, ByVal orgcode As String) As DataTable
            Dim dt As DataTable

            dt = DAO.GetMaterialByCondition(Material_id, location, orgcode)

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
            Return dt
        End Function

        Public Function GetOne(ByVal Material_id As String) As DataRow
            Dim dt As DataTable

            dt = DAO.GetMaterialByID(Material_id)

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
            Return dt.Rows(0)
        End Function

        Public Function GetMatData(ByVal item As String, ByVal code As String) As DataTable
            Dim dt As DataTable

            dt = DAO.GetMatData(item, code)

            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetMaterial(ByVal item As String, ByVal code As String) As DataTable
            Dim dt As DataTable

            dt = DAO.GetMaterial(item, code)

            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
        Public Function GetDataMaterial(ByVal Orgcode As String, ByVal UserId As String, ByVal Material_id As String) As DataTable
            Dim dt As DataTable

            dt = DAO.GetDataMaterial(Orgcode, UserId, Material_id)

            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function MAT1105SelectData(ByVal Index As String) As Boolean
            'MAT0305
            Dim dt As DataTable
            Dim memo As String = ""
            dt = DAO.MAT1105SelectData(Index)
            If dt.Rows.Count > 0 Then
                '查詢結果大於0代表物料明細中該編號已被使用，不可做刪除。
                memo = False
            Else
                '代表該編號沒被使用，可刪除。
                memo = True
            End If
            'dt = DAO.GetData(item, code)
            If dt Is Nothing Then Return Nothing
            Return memo
        End Function
        Public Function MAT2105SelectData() As DataTable
            'MAT0305
            Dim dt As DataTable
            dt = DAO.MAT2105SelectData()
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
        Public Function MAT2201SelectData(ByVal Material_idS As String, ByVal Material_idE As String) As DataTable
            Dim dt As DataTable
            dt = DAO.MAT2201SelectData(Material_idS, Material_idE)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataByClassId(ByVal MaterialClass_id As String) As DataTable
            Dim dt As DataTable
            dt = DAO.GetData(MaterialClass_id)
            Return dt
        End Function

        Public Function GetDataByClassId(ByVal MaterialClass_id As String, isPersonLimit As Boolean) As DataTable
            Dim dt As DataTable
            dt = DAO.GetData(MaterialClass_id, isPersonLimit)
            Return dt
        End Function

        Public Function GetOtherData(ByVal isPersonLimit As Boolean) As DataTable
            Dim dt As DataTable
            dt = DAO.GetOtherData(isPersonLimit)
            Return dt
        End Function

        Public Function CheckInvMainExist(ByVal orgcode As String, ByVal Material_id As String, ByVal InventoryId As String) As DataTable
            Dim dt As DataTable
            dt = DAO.CheckInvMainExist(orgcode, Material_id, InventoryId)
            Return dt
        End Function
        Public Function GetDataByClassId2(ByVal orgcode As String, ByVal MaterialClass_id As String) As DataTable
            Dim dt As DataTable
            dt = DAO.GetDataByClassId2(orgcode, MaterialClass_id)
            Return dt
        End Function
        Public Function GetData(ByVal Index As String) As String
            Dim dt As DataTable
            Dim memo As String = ""
            dt = DAO.GetData(Index)
            If dt.Rows.Count > 0 Then
                '查詢結果大於0代表物料明細中該編號已被使用，不可做刪除。
                memo = "0"
            Else
                '代表該編號沒被使用，可刪除。
                memo = "1"
            End If
            'dt = DAO.GetData(item, code)
            If dt Is Nothing Then Return Nothing
            Return memo
        End Function

        Public Sub Update(ByVal Material_id As String, ByVal Material_name As String, ByVal MaterialClass_id As String, ByVal Unit As String, ByVal Safe_cnt As Integer, _
                       ByVal Reserve_cnt As Integer, ByVal Available_cnt As Integer, ByVal Location As String, ByVal PersonLimitMM_cnt As Integer, ByVal PersonLimit_cnt As Integer, _
                       ByVal UnitLimitMM_cnt As Integer, ByVal UnitLimit_cnt As Integer, ByVal MaterialIcon As String, ByVal Memo As String, ByVal ModUser_id As String, _
                       ByVal OrgCode As String, ByVal Mod_date As DateTime)

            DAO.Update(Material_id, Material_name, MaterialClass_id, Unit, Safe_cnt, _
                Reserve_cnt, Available_cnt, Location, PersonLimitMM_cnt, PersonLimit_cnt, _
                UnitLimitMM_cnt, UnitLimit_cnt, MaterialIcon, Memo, _
                ModUser_id, OrgCode, Mod_date)



        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                      ByVal OrgCode As String, ByVal Mod_date As DateTime)
            DAO.Update(Material_id, newMaterial_id, ModUser_id, OrgCode, Mod_date)
        End Sub

        Public Function Insert(ByVal Material_id As String, ByVal Material_name As String, ByVal MaterialClass_id As String, ByVal Unit As String, ByVal Safe_cnt As Integer, _
                       ByVal Reserve_cnt As Integer, ByVal Available_cnt As Integer, ByVal Location As String, ByVal PersonLimitMM_cnt As Integer, ByVal PersonLimit_cnt As Integer, _
                       ByVal UnitLimitMM_cnt As Integer, ByVal UnitLimit_cnt As Integer, ByVal MaterialIcon As String, ByVal Memo As String, ByVal ModUser_id As String, _
                       ByVal OrgCode As String, ByVal Mod_date As DateTime) As String
            Dim result As String = ""
            Try
                If String.IsNullOrEmpty(Material_id) Then
                    result += "請輸入物料編號"
                End If

                If String.IsNullOrEmpty(result) Then
                    DAO.Insert(Material_id, Material_name, MaterialClass_id, Unit, Safe_cnt, _
                          Reserve_cnt, Available_cnt, Location, PersonLimitMM_cnt, PersonLimit_cnt, _
                          UnitLimitMM_cnt, UnitLimit_cnt, MaterialIcon, Memo, _
                          ModUser_id, OrgCode, Mod_date)
                End If
            Catch ex As Exception
                result = ex.Message
            End Try
            Return result

        End Function

        Public Function Delete(ByVal MaterialId As String) As String
            'TODO : MAT_MaterialMStat_det , MAT_ApplyMaterial_det,MAT_Inventory_det 有用到此MaterialID  則不給刪除
            Dim amdDAO As New ApplyMaterialDet
            Dim miDAO As New MaterialInDet
            Dim mmsDAO As New MaterialMStatDet
            Dim itDAO As New InventoryDet

            Dim miCount As Integer = amdDAO.GetMaterialCnt(MaterialId) + miDAO.GetMaterialCnt(MaterialId) + mmsDAO.GetMaterialCnt(MaterialId) + itDAO.GetMaterialCnt(MaterialId)
            Dim reulst As String = ""
            If miCount > 0 Then
                reulst += "其它資訊關聯此筆資料,不可刪除"
            End If

            If String.IsNullOrEmpty(reulst) Then
                Try
                    DAO.Delete(MaterialId)
                Catch ex As Exception
                    reulst = ex.Message
                End Try
            End If
            Return reulst
        End Function

        Public Function GetReserve_cnt(orgCode As String) As DataTable
            Return DAO.GetReserveCnt(orgCode)
        End Function

        Public Function GetReserve_cnt(orgCode As String, materialID As String) As Integer
            Dim dt As DataTable = GetReserve_cnt(orgCode)
            Dim dtRows() As DataRow = dt.Select(String.Format(" Material_id = '{0}' ", materialID))
            If Not dtRows Is Nothing AndAlso dtRows.Length > 0 Then
                dt = dtRows.CopyToDataTable()
                Return dt.Rows(0)("Reserve_cnt")
            Else
                Return 0
            End If
        End Function
        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return DAO.GetMaterialCnt(Material_id)
        End Function
        Public Function updateReserveCnt(ByVal Orgcode As String, ByVal Material_id As String, ByVal oriInCnt As Integer, ByVal InCnt As Integer) As Boolean
            Return DAO.updateReserveCnt(Orgcode, Material_id, oriInCnt, InCnt)
        End Function
        Public Function updateAvailableCnt(ByVal applyCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Boolean
            Return DAO.updateAvailableCnt(applyCnt, materialID, Orgcode)
        End Function
        Public Function updateAvailableCntReserveCnt(ByVal applyCnt As String, ByVal outCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Integer
            Return DAO.updateAvailableCntReserveCnt(applyCnt, outCnt, materialID, Orgcode)
        End Function
        Public Function update3102AvailableCnt(ByVal applyCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Boolean
            Return DAO.update3102AvailableCnt(applyCnt, materialID, Orgcode)
        End Function
        Public Function update310203AvailableCnt(ByVal oriInCnt As String, ByVal InCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Boolean
            Return DAO.update310203AvailableCnt(oriInCnt, InCnt, materialID, Orgcode)
        End Function
        '1030609
        Public Function UpdateAvaiable(ByVal OrgCode As String, ByVal Material_id As String, ByVal InvBefore_cnt As String, _
                                       ByVal InvAfter_cnt As String) As Boolean
            Return DAO.UpdateAvaiable(OrgCode, Material_id, InvBefore_cnt, InvAfter_cnt)
        End Function
    End Class
End Namespace