Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT2110

        Public AMDAO As ApplyMaterialDet
        Public MMSAO As MaterialMStatDet
        Public MADO As MaterialAccuDet
        Public MIDO As MaterialInDet
        Public IDAO As InventoryDet
        Public MMDAO As Material_main


        Public Sub New()
            AMDAO = New ApplyMaterialDet()
            MMSAO = New MaterialMStatDet()
            MADO = New MaterialAccuDet()
            MIDO = New MaterialInDet()
            IDAO = New InventoryDet()
            MMDAO = New Material_main()
        End Sub

        Public Function Cal(orgCode As String, year As String, month As String, isOverwrite As Boolean) As String
            Dim dt As DataTable = AMDAO.GetSumOutCnt(orgCode, year & month)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim s As Date = Date.Parse(year & "/" & month & "/01")
                s = s.AddMonths(1)

                Dim tmp As DataTable = AMDAO.GetSumOutCnt(orgCode, s.Year.ToString.PadLeft(3, "0") & s.Month.ToString.PadLeft(2, "0"))
                If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                    Throw New FlowException("已有下個月的計算資料，此年月資料不可重複計算!")
                End If
            Else
                Throw New FlowException("本月無交易資料!")
            End If
            Dim msg As String = String.Empty
            For Each dr As DataRow In dt.Rows
                msg = MMSAO.InsertOrUpdate(orgCode, year, CommonFun.SetDataRow(dr, "Material_id"), CommonFun.SetDataRow(dr, "Unit_Code"), month, CommonFun.SetDataRow(dr, "Out_cnt"), isOverwrite, LoginManager.UserId)
                If Not isOverwrite AndAlso Not String.IsNullOrEmpty(msg) Then
                    GoTo RETURNLINE
                End If
            Next
            Dim thisDT As New DateTime(year + 1911, month, 1)
            Dim lastDT As DateTime = thisDT.AddMonths(-1)
            Dim thisYYYMM As String = year & month
            Dim lastYYYMM As String = CommonFun.getYYYMMDD(lastDT)
            For Each dr As DataRow In dt.Rows
                Dim materialID As String = CommonFun.SetDataRow(dr, "Material_id")
                Dim MAccu_remain As Double = MADO.GetMAccu_store(orgCode, lastYYYMM.Substring(0, 5), materialID)
                Dim MAccu_in As Double = MIDO.GetIn_cnt(orgCode, thisYYYMM, materialID)
                Dim MAccu_out As Double = AMDAO.GetOut_cnt(orgCode, thisYYYMM, materialID)
                Dim MAccu_modify As Double = IDAO.GetOut_cnt(orgCode, thisYYYMM, materialID)
                Dim MAccu_store As Double = MMDAO.GetReserve_cnt(orgCode, materialID)
                msg = MADO.InsertOrUpdate(orgCode, thisYYYMM, materialID, MAccu_remain, MAccu_in, MAccu_out, MAccu_modify, MAccu_store, CommonFun.getYYYMMDD, LoginManager.UserId, Now, isOverwrite)
                If Not isOverwrite AndAlso Not String.IsNullOrEmpty(msg) Then
                    GoTo RETURNLINE
                End If
            Next
RETURNLINE:
            Return msg
        End Function


    End Class
End Namespace
