Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SALARY.Logic
    Public Class SAL3203DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
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
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO Flow (Flow_id, OrgCode, Depart_id, Apply_posid, Apply_id, personnel_id, Apply_name, Leave_group, Leave_ngroup, Leave_type, Writer_id, Write_time, Last_pass, Case_status) "
            StrSQL &= "VALUES (@Flow_id, @OrgCode, @Depart_id, @Apply_posid, @Apply_id, @personnel_id, @Apply_name, @Leave_group, @Leave_ngroup, @Leave_type, @Writer_id, @Write_time, @Last_pass, @Case_status) "
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), _
                                        New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Depart_id", Depart_id), _
                                        New SqlParameter("@Apply_posid", Apply_posid), _
                                        New SqlParameter("@Apply_id", Apply_id), _
                                        New SqlParameter("@personnel_id", personnel_id), _
                                        New SqlParameter("@Apply_name", Apply_name), _
                                        New SqlParameter("@Leave_group", Leave_group), _
                                        New SqlParameter("@Leave_ngroup", Leave_ngroup), _
                                        New SqlParameter("@Leave_type", Leave_type), _
                                        New SqlParameter("@Writer_id", Writer_id), _
                                        New SqlParameter("@Write_time", Write_time), _
                                        New SqlParameter("@Last_pass", Last_pass), _
                                        New SqlParameter("@Case_status", Case_status)}
            Return Execute(StrSQL, ps)
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
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO SAL_TRAFFIC_FEE (Flow_id, Merge_flow_id, User_id, Apply_ym, Cost_date, Apply_amt, Apply_desc, Pay_date, Org_code, ModUser_id, Mod_date) "
            Dim TRAFFIC_FEEInsertSQL As String = ""
            For i As Integer = 0 To db.Rows.Count - 1
                If i = db.Rows.Count - 1 Then '最後一筆
                    TRAFFIC_FEEInsertSQL = TRAFFIC_FEEInsertSQL + "(@Flow_id" & _
                                        ", " & "@Merge_flow_id " & _
                                        ", " & "@User_id " & _
                                        ", " & "@Apply_ym " & _
                                        ", '" & db.Rows(i).Item("Cost_date").ToString & _
                                        "', '" & db.Rows(i).Item("Apply_amt").ToString & _
                                        "', '" & db.Rows(i).Item("Apply_desc").ToString & _
                                        "', " & "@Pay_date " & _
                                        ", " & "@Org_code " & _
                                        ", " & "@ModUser_id " & _
                                        ", " & "@Mod_date " & ") "
                Else
                    TRAFFIC_FEEInsertSQL = TRAFFIC_FEEInsertSQL + "(@Flow_id" & _
                                        ", " & "@Merge_flow_id " & _
                                        ", " & "@User_id " & _
                                        ", " & "@Apply_ym " & _
                                        ", '" & db.Rows(i).Item("Cost_date").ToString & _
                                        "', '" & db.Rows(i).Item("Apply_amt").ToString & _
                                        "', '" & db.Rows(i).Item("Apply_desc").ToString & _
                                        "', " & "@Pay_date " & _
                                        ", " & "@Org_code " & _
                                        ", " & "@ModUser_id " & _
                                        ", " & "@Mod_date " & "), "
                End If
            Next
            StrSQL &= "VALUES " + TRAFFIC_FEEInsertSQL
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), _
                                        New SqlParameter("@Merge_flow_id", Merge_flow_id), _
                                        New SqlParameter("@User_id", User_id), _
                                        New SqlParameter("@Apply_ym", Apply_ym), _
                                        New SqlParameter("@Pay_date", Pay_date), _
                                        New SqlParameter("@Org_code", Org_code), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@Mod_date", Mod_date)}
            Return Execute(StrSQL, ps)
        End Function
        Public Function SAL3203DAOSelectTRAFFIC_FEEData(ByVal User_id As String, ByVal Cost_date As String, ByVal Flow_id As String, ByVal db As DataTable) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            
            StrSQL = "Select Flow_id "
            StrSQL &= "From SAL_TRAFFIC_FEE Where User_id=@User_id "
            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL &= "and Flow_id=@Flow_id "
            Else
                If Not String.IsNullOrEmpty(Cost_date) Then
                    StrSQL &= "and Cost_date=@Cost_date "
                    StrSQL &= "group by Flow_id "
                End If
            End If

            If db.Rows.Count > 0 Then
                StrSQL = "Select Id, Flow_id, Apply_desc, Cost_date, Apply_amt "
                StrSQL &= "From SAL_TRAFFIC_FEE Where User_id=@User_id "
                If Not String.IsNullOrEmpty(Flow_id) Then
                    StrSQL &= "and Flow_id=@Flow_id "
                Else
                    For i As Integer = 0 To db.Rows.Count - 1
                        If i = 0 Then
                            StrSQL &= "and Flow_id='" & db.Rows(i).Item("Flow_id").ToString & "' "
                        Else
                            StrSQL &= "or Flow_id='" & db.Rows(i).Item("Flow_id").ToString & "' "
                        End If
                    Next
                    StrSQL &= "Order by Flow_id "
                End If
            End If
            

            Dim ps() As SqlParameter = {New SqlParameter("@User_id", User_id), _
                                        New SqlParameter("@Cost_date", Cost_date), _
                                        New SqlParameter("@Flow_id", Flow_id)}
            Return Query(StrSQL, ps)
        End Function
        Public Function SAL3203DAOPrintTRAFFIC_FEEData(ByVal User_id As String, ByVal db As DataTable) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            For i As Integer = 0 To db.Rows.Count - 1
                If i = 0 Then
                    StrSQL &= "select Flow_id,SUM(Apply_amt) as Apply_amt, Apply_desc, substring(Cost_date,1,3)as Cost_date "
                    StrSQL &= "from "
                    StrSQL &= "(Select Id, Flow_id, Apply_desc, Cost_date, Apply_amt "
                    StrSQL &= "From SAL_TRAFFIC_FEE Where 1=1 and User_id=@User_id and  "
                    StrSQL &= "Flow_id='" + db.Rows(i).Item("Flow_id").ToString + "' ) as temptable_det "
                    StrSQL &= "group by Flow_id,Apply_desc, substring(Cost_date,1,3) "
                Else
                    StrSQL &= "union "
                    StrSQL &= "select Flow_id,SUM(Apply_amt),Apply_desc, substring(Cost_date,1,3)as Cost_date "
                    StrSQL &= "from "
                    StrSQL &= "(Select Id, Flow_id, Apply_desc, Cost_date, Apply_amt "
                    StrSQL &= "From SAL_TRAFFIC_FEE Where 1=1 and User_id=@User_id and  "
                    StrSQL &= "Flow_id='" + db.Rows(i).Item("Flow_id").ToString + "' ) as temptable_det "
                    StrSQL &= "group by Flow_id, Apply_desc, substring(Cost_date,1,3) "
                End If
            Next
            StrSQL &= "order by Flow_id "
            Dim ps() As SqlParameter = {New SqlParameter("@User_id", User_id)}
            Return Query(StrSQL, ps)
        End Function
    End Class
End Namespace