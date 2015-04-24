Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY1101
        Public DAO As PAY1101DAO
        Private main As PurchaseMain
        Private det As MAT.Logic.PurchaseDet

        Public Sub New()
            DAO = New PAY1101DAO()
            main = New PurchaseMain()
            det = New MAT.Logic.PurchaseDet()
        End Sub
        Public Function PAY1101DAOInsertPurchase_detData(ByVal Flow_id As String, _
                                                         ByVal db As DataTable, _
                                                          ByVal OrgCode As String, _
                                                          ByVal ModUser_id As String, _
                                                          ByVal ModDate As Date) As Integer

            det.DeleteDataByFlowId(OrgCode, Flow_id)

            Dim i As Integer '受影響資料列
            i = DAO.PAY1101DAOInsertPurchase_detData(Flow_id, db, OrgCode, ModUser_id, ModDate)
            Return i
        End Function
        Public Function PAY1101DAOInsertPurchase_mainData(ByVal Flow_id As String, _
                                                          ByVal User_id As String, _
                                                          ByVal Unit_code As String, _
                                                          ByVal Apply_date As String, _
                                                          ByVal Use_desc As String, _
                                                          ByVal Purchase_type As String, _
                                                          ByVal Attachment As String, _
                                                          ByVal OrgCode As String, _
                                                          ByVal ModUser_id As String, _
                                                          ByVal ModDate As Date) As Integer

            main.DeleteDataByFlowId(OrgCode, Flow_id)

            Dim i As Integer '受影響資料列
            i = DAO.PAY1101DAOInsertPurchase_mainData(Flow_id, User_id, Unit_code, Apply_date, Use_desc, Purchase_type, Attachment, OrgCode, ModUser_id, ModDate)
            Return i
        End Function
    End Class
End Namespace