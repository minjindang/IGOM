Imports Microsoft.VisualBasic
Imports System.Data
Imports Quartz
Imports Quartz.Impl
Imports FSCPLM.Logic
Imports Pemis2009.SQLAdapter
Imports NLog
Imports System.Text

Namespace FSC.Logic
    Public Class BatchTransferPHToPKJob
        Implements IJob

        Private Shared logger As Logger = LogManager.GetLogger("BatchTransferPHToPKJob")

        Public Sub Execute(context As Quartz.IJobExecutionContext) Implements Quartz.IJob.Execute
            Try
                logger.Info("===== Start BatchTransferPHToPKJob =====")

                Dim bll As New FSC.Logic.BatchTransferPHToPKBll()
                bll.RunBatch()

            Catch ex As Exception
                logger.Info("Exception Error:" & ex.Message)
            Finally
                logger.Info("=====  End BatchTransferPHToPKJob  =====")
            End Try
        End Sub
    End Class
End Namespace