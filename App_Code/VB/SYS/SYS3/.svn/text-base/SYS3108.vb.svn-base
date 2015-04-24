Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic

    Public Class SYS3108
        Private DAO As SYS3108DAO

        Public Sub New()
            DAO = New SYS3108DAO()
        End Sub

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal departId As String, ByVal target() As String, ByVal targetType() As String, ByVal formId As String) As DataTable
            '抓出流程
            Dim dt As DataTable = DAO.GetData(Orgcode, departId, target, targetType, formId)
            If dt Is Nothing Then Return Nothing

            dt.Columns.Add("Form_name", GetType(String))
            dt.Columns.Add("Outpost_id", GetType(String))
            dt.Columns.Add("Depart_name", GetType(String))
            dt.Columns.Add("Target_name", GetType(String))
            dt.Columns.Add("seq", GetType(String))

            'Dim fot As New FlowOutpostTarget()
            'Dim fom As New FlowOutpostForm()
            'Dim code As New SACode()

            'For Each dr As DataRow In dt.Rows

            '    '表單類型
            '    Dim ffdt As DataTable = fom.GetFormIdByQuery(dr("Flow_outpost_id").ToString(), Orgcode, departId)
            '    For Each ffdr As DataRow In ffdt.Rows
            '        Dim codeType As String = ffdr("Form_id").Substring(0, 3)
            '        Dim codeNo As String = ffdr("Form_id").Substring(3)
            '        Dim desc As String = code.GetCodeDesc("024", codeType, codeNo)

            '        If Not "".Equals(dr("Form_name").ToString()) Then
            '            dr("Form_name") &= "<br/>"
            '        End If
            '        dr("Form_name") &= desc
            '    Next

            '    dr("Outpost_id") = Outpost.GetDisplayOutpost(Orgcode, "", "", dr("Flow_outpost_id").ToString(), True)

            '    '適用對像
            '    Dim fodt As DataTable = fot.GetTargetByQuery(dr("Flow_outpost_id").ToString(), Orgcode, departId)
            '    For Each fodr As DataRow In fodt.Rows

            '        '單位
            '        Dim depName As String = New FSC.Logic.Org().GetDepartName(fodr("Orgcode").ToString(), fodr("Depart_id").ToString())

            '        '適用人員
            '        If Not "".Equals(dr("Target_name").ToString()) Then
            '            dr("Target_name") &= "<br/>"
            '        End If
            '        dr("Target_name") &= depName & "/" & Outpost.GetTargetName(fodr("Target").ToString(), fodr("Target_type").ToString())
            '    Next
            'Next

            Return dt
        End Function

        Public Function GetSettingData(ByVal Orgcode As String, ByVal FlowOutpostID As String) As DataTable
            Dim dt As DataTable = New SYS.Logic.FlowOutpostMaster().GetDataByFlowOutpostID(Orgcode, FlowOutpostID)

            If dt Is Nothing Or dt.Rows.Count <= 0 Then
                Return Nothing
            End If
            dt.Columns.Add("text", GetType(String))

            Dim outpost As New Outpost()
            For Each fo_dr As DataRow In dt.Rows
                fo_dr("text") = outpost.GetOutpostIdName(Orgcode, fo_dr("Outpost_id").ToString(), fo_dr("Outpost_orgcode").ToString(), fo_dr("Outpost_departid").ToString(), fo_dr("Outpost_posid").ToString(), fo_dr("Relate_flag").ToString(), fo_dr("Unit_flag").ToString())
            Next

            Return dt
        End Function


        Public Function GetSettingData(ByVal Orgcode As String, ByVal flowOutpostMasterList As List(Of SYS.Logic.FlowOutpostMaster)) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("Orgcode", GetType(String))
            dt.Columns.Add("Flow_outpost_id", GetType(String))
            dt.Columns.Add("Outpost_id", GetType(String))
            dt.Columns.Add("Outpost_orgcode", GetType(String))
            dt.Columns.Add("Outpost_departid", GetType(String))
            dt.Columns.Add("Outpost_posid", GetType(String))
            dt.Columns.Add("Relate_flag", GetType(String))
            dt.Columns.Add("Outpost_seq", GetType(Integer))
            dt.Columns.Add("Hoursetting_id", GetType(String))
            dt.Columns.Add("Group_id", GetType(String))
            dt.Columns.Add("Group_seq", GetType(String))
            dt.Columns.Add("Group_type", GetType(String))
            dt.Columns.Add("text", GetType(String))
            dt.Columns.Add("Mail_flag", GetType(String))
            dt.Columns.Add("Unit_flag", GetType(String))

            For i As Integer = 0 To flowOutpostMasterList.Count - 1
                Dim fom As SYS.Logic.FlowOutpostMaster = flowOutpostMasterList(i)
                Dim dr As DataRow = dt.NewRow
                dr("Orgcode") = fom.Orgcode
                dr("Outpost_id") = fom.Outpost_id
                dr("Outpost_orgcode") = fom.Outpost_orgcode
                dr("Outpost_departid") = fom.Outpost_departid
                dr("Outpost_posid") = fom.Outpost_posid
                dr("Relate_flag") = fom.Relate_flag
                dr("Outpost_seq") = fom.Outpost_seq
                dr("Hoursetting_id") = fom.Hoursetting_id
                dr("Group_id") = fom.Group_id
                dr("Group_seq") = fom.Group_seq
                dr("Group_type") = fom.Group_type
                dr("text") = Outpost.GetOutpostIdName(Orgcode, fom.Outpost_id, fom.Outpost_orgcode, fom.Outpost_departid, fom.Outpost_posid, fom.Relate_flag, fom.Unit_flag)
                dr("mail_flag") = fom.Mail_flag
                dr("Unit_flag") = fom.Unit_flag
                dt.Rows.Add(dr)
            Next

            Return dt
        End Function

        Public Function GetListBoxData(ByVal Orgcode As String, ByVal flowOutpostMasterList As List(Of SYS.Logic.FlowOutpostMaster)) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("Flow_outpost_id", GetType(String))
            dt.Columns.Add("Outpost_id", GetType(String))
            dt.Columns.Add("Outpost_orgcode", GetType(String))
            dt.Columns.Add("Outpost_departid", GetType(String))
            dt.Columns.Add("Outpost_posid", GetType(String))
            dt.Columns.Add("Relate_flag", GetType(String))
            dt.Columns.Add("Outpost_seq", GetType(Integer))
            dt.Columns.Add("Hoursetting_id", GetType(String))
            dt.Columns.Add("text", GetType(String))
            dt.Columns.Add("value", GetType(String))

            If flowOutpostMasterList IsNot Nothing Then
                For i As Integer = 0 To flowOutpostMasterList.Count - 1
                    Dim fom As SYS.Logic.FlowOutpostMaster = flowOutpostMasterList(i)
                    Dim dr As DataRow = dt.NewRow
                    dr("value") = Outpost.GetJoinOutpost(fom.Outpost_id, fom.Outpost_orgcode, fom.Outpost_departid, fom.Outpost_posid, fom.Relate_flag, fom.Unit_flag)
                    dr("text") = Outpost.GetOutpostIdName(Orgcode, fom.Outpost_id, fom.Outpost_orgcode, fom.Outpost_departid, fom.Outpost_posid, fom.Relate_flag, fom.Unit_flag)
                    dt.Rows.Add(dr)
                Next
            End If

            Return dt
        End Function

        Public Function GetListBoxData(ByVal Orgcode As String, ByVal FlowOutpostID As String) As DataTable
            Dim fomdt As DataTable = New SYS.Logic.FlowOutpostMaster().GetDataByFlowOutpostID(Orgcode, FlowOutpostID)
            Dim dt As New DataTable
            Dim outpost As New Outpost

            If fomdt IsNot Nothing AndAlso fomdt.Rows.Count > 0 Then
                dt.Columns.Add("value", GetType(String))
                dt.Columns.Add("text", GetType(String))

                Dim dr As DataRow
                For Each fomdr As DataRow In fomdt.Rows
                    dr = dt.NewRow
                    dr("value") = outpost.GetJoinOutpost(fomdr("Outpost_id").ToString(), fomdr("Outpost_orgcode").ToString(), fomdr("Outpost_departid").ToString(), fomdr("Outpost_posid").ToString(), fomdr("Relate_flag").ToString(), fomdr("unit_flag").ToString())
                    dr("text") = outpost.GetOutpostIdName(Orgcode, fomdr("Outpost_id").ToString(), fomdr("Outpost_orgcode").ToString(), fomdr("Outpost_departid").ToString(), fomdr("Outpost_posid").ToString(), fomdr("Relate_flag").ToString(), fomdr("unit_flag").ToString())
                    dt.Rows.Add(dr)
                Next
            End If

            Return dt
        End Function


        Public Function GetDataByQuery2(ByVal Orgcode As String, ByVal departId As String, ByVal titleNo As String, ByVal idCard As String, ByVal employeeType As String, ByVal formId As String) As DataTable
            Dim ndt1 As DataTable = DAO.GetData2(Orgcode, departId, titleNo, "1", formId)
            Dim ndt2 As DataTable = DAO.GetData2(Orgcode, departId, idCard, "2", formId)
            Dim ndt3 As DataTable = DAO.GetData2(Orgcode, departId, "022" & employeeType.PadLeft(3, "0"), "3", formId)
            Dim ndt4 As DataTable = DAO.GetData2(Orgcode, departId, "023" & employeeType.PadLeft(3, "0"), "3", formId)

            ndt1.Merge(ndt2)
            ndt1.Merge(ndt3)
            ndt1.Merge(ndt4)

            Dim dt As DataTable = ndt1.DefaultView.ToTable(True, New String() {"flow_outpost_id", "form_id"})

            Dim outpostName As String = ""
            Dim formName As String = ""
            Dim flowOutpostId As String = ""

            Dim rdt As New DataTable()
            rdt.Columns.Add("form_name", GetType(String))
            rdt.Columns.Add("outpost_name", GetType(String))

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)

                If i <> 0 And flowOutpostId <> dr("flow_outpost_id").ToString() Then
                    outpostName = Outpost.GetDisplayOutpost(Orgcode, departId, idCard, flowOutpostId, True)
                    Dim rdr As DataRow = rdt.NewRow
                    rdr("form_name") = formName
                    rdr("outpost_name") = outpostName
                    rdt.Rows.Add(rdr)
                    formName = ""
                End If

                flowOutpostId = dr("flow_outpost_id").ToString()
                formName &= Outpost.GetFormName(dr("form_id").ToString()) & "<br/>"
            Next

            If Not String.IsNullOrEmpty(formName) Then
                outpostName = Outpost.GetDisplayOutpost(Orgcode, departId, idCard, flowOutpostId, True)
                Dim rdr1 As DataRow = rdt.NewRow
                rdr1("form_name") = formName
                rdr1("outpost_name") = outpostName
                rdt.Rows.Add(rdr1)
            End If

            Return rdt
        End Function


        Public Function GetData3(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal formId As String) As DataTable
            Dim dt As DataTable = DAO.GetData3(orgcode, departId, idCard, formId)
            dt.Columns.Add("Outpost_id", GetType(String))
            dt.Columns.Add("Target_name", GetType(String))
            dt.Columns.Add("Form_name", GetType(String))
            dt.Columns.Add("seq", GetType(String))

            Dim fot As New FlowOutpostTarget()
            Dim fom As New FlowOutpostForm()
            Dim code As New SACode()

            For Each dr As DataRow In dt.Rows
                dr("Outpost_id") = Outpost.GetDisplayOutpost(orgcode, dr("Depart_id").ToString(), "", dr("Flow_outpost_id").ToString(), True)

                Dim fodt As DataTable = fot.GetTargetByQuery(dr("Flow_outpost_id").ToString(), orgcode, dr("Depart_id").ToString())
                For Each fodr As DataRow In fodt.Rows
                    If Not "".Equals(dr("Target_name").ToString()) Then
                        dr("Target_name") &= "<br/>"
                    End If

                    dr("Target_name") &= Outpost.GetTargetName(fodr("Target").ToString(), fodr("Target_type").ToString())
                Next

                Dim fodt2 As DataTable = fom.GetFormIdByQuery(dr("Flow_outpost_id").ToString(), orgcode, dr("Depart_id").ToString())
                For Each fodr As DataRow In fodt2.Rows
                    If Not "".Equals(dr("Form_name").ToString()) Then
                        dr("Form_name") &= "<br/>"
                    End If

                    Dim codeType As String = fodr("Form_id").Substring(0, 3)
                    Dim codeNo As String = fodr("Form_id").Substring(3)
                    Dim desc As String = CODE.GetCodeDesc("024", codeType, codeNo)

                    dr("Form_name") &= desc
                Next
            Next

            Return dt
        End Function
    End Class

End Namespace
