Imports Microsoft.VisualBasic
Imports System.Data
Imports Quartz
Imports Quartz.Impl
Imports Common.Logging
Imports FSCPLM.Logic
Imports Pemis2009.SQLAdapter
Imports System.Data.SqlClient
Public Class BatchOvertimeJob
    Implements IJob

    Private Shared _log As ILog = LogManager.GetLogger(GetType(BatchOvertimeJob))

    Public Sub Execute(context As Quartz.IJobExecutionContext) Implements Quartz.IJob.Execute
        Try
            _log.Info("===== Start Execute BatchOvertimeJob =====")

            Dim bll As New BatchOvertimeBll()
            bll.runBatch()

        Catch ex As Exception
            _log.Info("Exception Error : " & ex.Message)
        Finally
            _log.Info("=====  End Execute BatchOvertimeJob  =====")
        End Try

    End Sub
End Class
