Imports Microsoft.VisualBasic
Imports NLog
Imports System.Data

Namespace FSC.Logic
    Public Class BatchTransferPHToPKBll

        Public Sub RunBatch()
            Dim orgs As String = ConfigurationManager.AppSettings("PHtoPKOrgs").ToString()
            Dim days As String = ConfigurationManager.AppSettings("PHtoPKDays").ToString()

            Dim sdate As String = DateTimeInfo.GetRocDate(Now.AddDays(0 - CommonFun.ConvertToInt(days)))
            Dim edate As String = DateTimeInfo.GetRocDate(Now)

            Dim bll As New FSC4202()

            For Each orgcode As String In orgs.Split(",")
                bll.Transfer(orgcode, "", "", "", sdate, edate, True)
            Next

        End Sub
    End Class
End Namespace