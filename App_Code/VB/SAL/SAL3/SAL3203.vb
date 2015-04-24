Imports Microsoft.VisualBasic
Imports System.Data

Namespace SALARY.Logic
    Public Class SAL3203
        Public DAO As SAL3203DAO

        Public Sub New()
            DAO = New SAL3203DAO()
        End Sub
        Public Function SAL3203DAOInsertFlowData(ByVal Flow_id As String, _
                                                         ByVal OrgCode As String, _
                                                          ByVal Depart_id As String, _
                                                          ByVal Apply_posid As String, _
                                                          ByVal Apply_id As String, _
                                                         ByVal personnel_id As String, _
                                                          ByVal Apply_name As String, _
                                                          ByVal Leave_group As String, _
                                                          ByVal Leave_ngroup As String, _
                                                         ByVal Leave_type As String, _
                                                          ByVal Writer_id As String, _
                                                          ByVal Write_time As Date, _
                                                          ByVal Last_pass As Integer, _
                                                          ByVal Case_status As String) As Integer
            Dim i As Integer '受影響資料列
            i = DAO.SAL3203DAOInsertFlowData(Flow_id, _
                                             OrgCode, _
                                             Depart_id, _
                                             Apply_posid, _
                                             Apply_id, _
                                             personnel_id, _
                                             Apply_name, _
                                             Leave_group, _
                                             Leave_ngroup, _
                                             Leave_type, _
                                             Writer_id, _
                                             Write_time, _
                                             Last_pass, _
                                             Case_status)
            Return i
        End Function
        Public Function SAL3203DAOInsertTRAFFIC_FEEData(ByVal Flow_id As String, _
                                                         ByVal Merge_flow_id As String, _
                                                          ByVal User_id As String, _
                                                          ByVal Apply_ym As String, _
                                                          ByVal db As DataTable, _
                                                          ByVal Pay_date As String, _
                                                          ByVal Org_code As String, _
                                                         ByVal ModUser_id As String, _
                                                          ByVal Mod_date As Date) As Integer
            Dim i As Integer '受影響資料列
            i = DAO.SAL3203DAOInsertTRAFFIC_FEEData(Flow_id, _
                                             Merge_flow_id, _
                                             User_id, _
                                             Apply_ym, _
                                             db, _
                                             Pay_date, _
                                             Org_code, _
                                             ModUser_id, _
                                             Mod_date)
            Return i
        End Function
        Public Function SAL3203DAOSelectTRAFFIC_FEEData(ByVal User_id As String, ByVal Cost_date As String, ByVal Flow_id As String, ByVal db As DataTable) As DataTable
            Return DAO.SAL3203DAOSelectTRAFFIC_FEEData(User_id, Cost_date, Flow_id, db)
        End Function
        Public Function SAL3203DAOPrintTRAFFIC_FEEData(ByVal User_id As String, ByVal db As DataTable) As DataTable
            Return DAO.SAL3203DAOPrintTRAFFIC_FEEData(User_id, db)
        End Function
    End Class
End Namespace