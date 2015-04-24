Imports Microsoft.VisualBasic
Imports System.Data
Imports FSC.Logic

Namespace SAL.Logic
    Public Class SAL1111
        Dim DAO As SAL1111DAO

        Public Sub New()
            DAO = New SAL1111DAO()
        End Sub

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByOrgFid(orgcode, flowId)

            If dt Is Nothing OrElse dt.Rows.Count < 0 Then Return Nothing
            dt.Columns.Add("Start_time", GetType(String))
            dt.Columns.Add("End_time", GetType(String))
            dt.Columns.Add("PRADDD_name", GetType(String))
            dt.Columns.Add("PRADDE_name", GetType(String))
            dt.Columns.Add("PRSTIME_name", GetType(String))
            dt.Columns.Add("PRETIME_name", GetType(String))

            Dim l As New FSC.Logic.LeaveMain
            Dim dti As New DateTimeInfo()

            For Each dr As DataRow In dt.Rows
                Dim Depart_id As String = dr("Depart_id").ToString()
                Dim Id_card As String = dr("PRIDNO").ToString()
                Dim ym As String = dr("Fee_ym").ToString()

                dr("PRADDD_name") = DateTimeInfo.ConvertToDisplay(dr("PRADDD").ToString())
                dr("PRADDE_name") = DateTimeInfo.ConvertToDisplay(dr("PRADDE").ToString())
                dr("PRSTIME_name") = dti.ConvertToDisplayTime(dr("PRSTIME").ToString())
                dr("PRETIME_name") = dti.ConvertToDisplayTime(dr("PRETIME").ToString())
                dr("PRMNYH") = IIf(String.IsNullOrEmpty(dr("PRMNYH").ToString().Trim()), "0", dr("PRMNYH").ToString())

                Dim fdt As DataTable = l.GetDataByOrgFid(orgcode, dr("PRGUID").ToString().Trim())
                If fdt.Rows.Count > 0 AndAlso fdt IsNot Nothing Then
                    dr("Start_time") = dti.ConvertToDisplayTime(fdt.Rows(0)("Start_time").ToString().Trim())
                    dr("End_time") = dti.ConvertToDisplayTime(fdt.Rows(0)("End_time").ToString().Trim())
                End If

                ''取刷卡最後時間做為加班迄時
                'Dim cpaph As New FSC.Logic.CPAPHYYMM(ym)
                'Dim phdt As DataTable = cpaph.GetData(idCard, dr("PRADDD").ToString(), "E")
                'If phdt IsNot Nothing AndAlso phdt.Rows.Count > 0 Then
                '    For Each phdr As DataRow In phdt.Rows
                '        dr("PRETIME_name") = dti.ConvertToDisplayTime(phdr("PHITIME").ToString())
                '    Next
                'End If

                dr("PRMNYH") = CommonFun.getInt(dr("PRMNYH").ToString()) - CommonFun.getInt(dr("apply_hour").ToString())
            Next
            Return dt
        End Function

        Public Function GetSAL1111Data(orgcode As String, Depart_id As String, ByVal Id_card As String, ByVal ym As String, ByVal ymd As String) As DataTable
            DAO = New SAL1111DAO()
            Dim dt As DataTable = DAO.GetData(Id_card, Depart_id, ym, ymd)

            Dim l As New FSC.Logic.LeaveMain
            Dim dti As New DateTimeInfo
            If dt Is Nothing OrElse dt.Rows.Count < 0 Then Return Nothing
            dt.Columns.Add("Start_time", GetType(String))
            dt.Columns.Add("End_time", GetType(String))
            dt.Columns.Add("PRADDD_name", GetType(String))
            dt.Columns.Add("PRADDE_name", GetType(String))
            dt.Columns.Add("PRSTIME_name", GetType(String))
            dt.Columns.Add("PRETIME_name", GetType(String))

            For Each dr As DataRow In dt.Rows

                dr("PRADDD_name") = DateTimeInfo.ConvertToDisplay(dr("PRADDD").ToString())
                dr("PRADDE_name") = DateTimeInfo.ConvertToDisplay(dr("PRADDE").ToString())
                dr("PRSTIME_name") = dti.ConvertToDisplayTime(dr("PRSTIME").ToString())
                dr("PRETIME_name") = dti.ConvertToDisplayTime(dr("PRETIME").ToString())
                dr("PRMNYH") = IIf(String.IsNullOrEmpty(dr("PRMNYH").ToString().Trim()), "0", dr("PRMNYH").ToString())

                Dim fdt As DataTable = l.GetDataByOrgFid(orgcode, dr("PRGUID").ToString().Trim())
                If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
                    dr("Start_time") = dti.ConvertToDisplayTime(fdt.Rows(0)("Start_time").ToString().Trim())
                    dr("End_time") = dti.ConvertToDisplayTime(fdt.Rows(0)("End_time").ToString().Trim())
                End If


                ''取刷卡最後時間做為加班迄時
                'Dim cpaph As New FSC.Logic.CPAPHYYMM(ym)
                'Dim phdt As DataTable = cpaph.GetData(idCard, dr("PRADDD").ToString(), "E")
                'If phdt IsNot Nothing AndAlso phdt.Rows.Count > 0 Then
                '    For Each phdr As DataRow In phdt.Rows
                '        dr("PRETIME_name") = dti.ConvertToDisplayTime(phdr("PHITIME").ToString())
                '    Next
                'End If

                dr("PRMNYH") = CommonFun.getInt(dr("PRMNYH").ToString()) - CommonFun.getInt(dr("apply_hour").ToString())
            Next
            Return dt
        End Function


        Public Function GetSAL1111_02Data(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As DataTable
            DAO = New SAL1111DAO()
            Dim dt As DataTable = DAO.GetSAL1111_02Data(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq)
            Return dt
        End Function

        Public Function GetFeeMasterPrintMark(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As String
            'Dim dao As New LabOvertimeFeeMaster
            'Dim dt As DataTable = dao.GetOvertimeFeeMasterByQuery(Orgcode, Depart_id, Id_card, Fee_ym)
            'If Not dt Is Nothing And dt.Rows.Count > 0 Then
            '    Return dt.Rows(0)("Print_Mark").ToString()
            'Else
            '    Return ""
            'End If
            Return ""
        End Function

        Public Function GetLastBudget(ByVal id_card As String) As String
            Return DAO.GetLastBudget(id_card)
        End Function

        Public Function getSALData(ByVal Orgcode As String, ByVal Id_card As String, ByVal yyyymm As String) As DataTable
            Return DAO.getSALData(Orgcode, Id_card, yyyymm)
        End Function
    End Class
End Namespace
