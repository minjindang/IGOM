Imports Microsoft.VisualBasic
Imports System.Data
Imports Quartz
Imports Quartz.Impl
Imports FSCPLM.Logic
Imports Pemis2009.SQLAdapter
Imports NLog
Imports System.Text

Namespace FSC.Logic
    Public Class BatchCntYearDaysJob
        Implements IJob

        Private Shared logger As Logger = LogManager.GetLogger("BatchCntYearDaysJob")

        Public Sub Execute(context As Quartz.IJobExecutionContext) Implements Quartz.IJob.Execute
            Try
                logger.Info("===== Start Execute BatchCntYearDaysJob =====")

                Dim bll As New BatchCntYearDaysBll()
                bll.runBatch()

            Catch ex As Exception
                logger.Info("Exception Error : " & ex.Message)
            Finally
                logger.Info("=====  End Execute BatchCntYearDaysJob  =====")
            End Try
        End Sub
    End Class
End Namespace