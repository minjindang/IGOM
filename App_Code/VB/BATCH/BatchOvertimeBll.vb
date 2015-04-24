Imports Microsoft.VisualBasic
Imports System.Diagnostics

Public Class BatchOvertimeBll
    Public Sub runBatch()
        '需將此執行檔的資料夾設定到系統變數Path中
        Process.Start("BatchOvertime.exe")
    End Sub
End Class