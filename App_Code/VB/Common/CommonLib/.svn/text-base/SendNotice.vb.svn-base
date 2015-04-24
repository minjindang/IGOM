Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Namespace CommonLib

    Public Class SendNotice

        Public Shared Function sendAll(ByVal orgcode As String, ByVal flow_id As String) As Boolean

            SendFlowMail(orgcode, flow_id, "1")

        End Function

        Public Shared Function sendAll(ByVal orgcode As String, ByVal flow_id As String, ByVal Comment As String) As Boolean

            SendFlowMail(orgcode, flow_id, "1", Comment)

        End Function

        Public Shared Function send(ByVal orgcode As String, ByVal flow_id As String) As Boolean


            SendFlowMail(orgcode, flow_id, "1")

        End Function


        Public Shared Function SendFlowMail(ByVal Orgcode As String, ByVal Flow_id As String, ByVal frequency As String, Optional ByVal Comment As String = "") As Boolean
            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(Orgcode, Flow_id)
            Dim list As List(Of SYS.Logic.FlowNext) = New SYS.Logic.FlowNext().GetObjects(Orgcode, Flow_id)
            Dim isSend As Boolean = False
            Dim code As New FSCPLM.Logic.SACode()
            Dim org As New FSC.Logic.Org()
            Dim psn As New FSC.Logic.Personnel()

            If f IsNot Nothing AndAlso (f.LastPass = 0 And (f.CaseStatus = 0 Or f.CaseStatus = 1)) Then
                Dim departName As String = org.GetDepartName(f.Orgcode, f.DepartId)
                Dim formName As String = code.GetCodeDesc("024", f.FormId.Substring(0, 3), f.FormId.Substring(3))

                For Each fn As SYS.Logic.FlowNext In list

                    Dim p As FSC.Logic.Personnel = psn.GetObject(fn.NextIdcard)

                    If p IsNot Nothing AndAlso (fn.MailFlag = "1" And p.EmailYN = "Y" And p.Frequency = frequency) Then
                        Dim MailContent As New StringBuilder
                        MailContent.AppendLine(fn.NextName & "先生/小姐 您好：<br />")
                        MailContent.AppendLine("您有一份新表單需批核：<br />")
                        MailContent.AppendLine("<table border='1' cellpadding='1' cellspacing='1'>")
                        MailContent.AppendLine("    <tr>")
                        MailContent.AppendLine("        <td>單位名稱</td>")
                        MailContent.AppendLine("        <td>" & departName & "</td>")
                        MailContent.AppendLine("    </tr>")
                        MailContent.AppendLine("    <tr>")
                        MailContent.AppendLine("        <td>送件人</td>")
                        MailContent.AppendLine("        <td>" & f.ApplyName & "</td>")
                        MailContent.AppendLine("    </tr>")
                        MailContent.AppendLine("    <tr>")
                        MailContent.AppendLine("        <td>表單名稱</td>")
                        MailContent.AppendLine("        <td>" & formName & "</td>")
                        MailContent.AppendLine("    </tr>")
                        MailContent.AppendLine("</table>")

                        Dim ToMail As String = p.Email
                        Dim ToName As String = p.UserName

                        Dim SendMail As String = ConfigurationManager.AppSettings("SysMail").ToString()
                        Dim SendName As String = ConfigurationManager.AppSettings("SysName").ToString()

                        isSend = CommonFun.SendMail(SendMail, ToMail, SendName, ToName, "您有表單需批核", MailContent.ToString())

                        If isSend Then 'log to /*寄送成功的紀錄*/   
                            Dim log As New FSCPLM.Logic.MailSendLogDAO()
                            log.InsertData(Flow_id, fn.NextOrgcode, fn.NextIdcard, DateTime.Now)
                        End If
                    End If

                Next
            ElseIf f IsNot Nothing AndAlso f.CaseStatus = "2" Then '退件
                Dim p As FSC.Logic.Personnel = psn.GetObject(f.ApplyIdcard)

                Dim MailContent As New StringBuilder
                MailContent.AppendLine(p.UserName & "先生/小姐 您好：<br />")
                MailContent.AppendLine("您有表單(表單編號：" + Flow_id + ")被退件，<br />不准原因：" + Comment)

                Dim ToMail As String = p.Email
                Dim ToName As String = p.UserName

                Dim SendMail As String = ConfigurationManager.AppSettings("SysMail").ToString()
                Dim SendName As String = ConfigurationManager.AppSettings("SysName").ToString()

                isSend = CommonFun.SendMail(SendMail, ToMail, SendName, ToName, "您有表單被退件", MailContent.ToString())

                If isSend Then 'log to /*寄送成功的紀錄*/   
                    Dim log As New FSCPLM.Logic.MailSendLogDAO()
                    log.InsertData(Flow_id, f.Orgcode, f.ApplyIdcard, DateTime.Now)
                End If
            End If

        End Function

    End Class



End Namespace
