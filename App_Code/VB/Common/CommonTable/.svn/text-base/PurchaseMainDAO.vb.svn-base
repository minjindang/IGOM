Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Public Class PurchaseMainDAO
    Inherits BaseDAO

    Dim Connection As SqlConnection
    Dim ConnectionString As String = String.Empty

    Public Sub New()
        ConnectionString = ConnectDB.GetDBString()
    End Sub

    Public Sub New(ByVal conn As SqlConnection)
        Me.Connection = conn
    End Sub

    Public Function GetCountByFlowId(ByVal flow_Id As Integer) As Integer 
        Return Scalar("select count(*) from MAT_Purchase_main where Flow_id=@Flow_id", New SqlParameter("@Flow_id", flow_Id))
    End Function

    Public Function GetDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As DataTable
        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", orgcode), _
        New SqlParameter("@Flow_id", flow_Id)}
        Return Query("select * from MAT_Purchase_main where Orgcode=@orgcode and Flow_id=@Flow_id", params)
    End Function

    Public Function GetImporrtOtMtrNOTYData(orgcode As String) As DataTable
        Dim StrSQL As String = String.Empty
        StrSQL = " select a.Flow_id, " _
             & " (select depart_name from FSC_ORG where depart_id=a.Unit_code) as depart_name,  " _
             & " (select top 1 user_name from FSC_Personnel where User_id=a.User_id) as User_name,  " _
             & " a.apply_date " _
             & " from MAT_Purchase_main a inner join SYS_Flow b on a.Flow_id = b.Flow_id where (ImportOtMtr <> 'Y' OR ImportOtMtr is null OR ImportOtMtr = '') " _
             & " and b.Last_pass='1' and b.Case_status='1' and a.orgCode=@orgcode "

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", orgcode)}
        Return Query(StrSQL, params)
    End Function

    Public Sub UpdateImportOtMtr(ByVal ImportOtMtr As String, ByVal flow_id As String)
        Dim ps() As SqlParameter = {New SqlParameter("@flow_id", flow_id), _
                                   New SqlParameter("@ImportOtMtr", ImportOtMtr)}
        Execute("update MAT_Purchase_main set ImportOtMtr = @ImportOtMtr where flow_id = @flow_id", ps)
    End Sub


    Public Function DeleteDataByFlowId(ByVal orgcode As String, ByVal flow_Id As String) As Integer
        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", orgcode), _
        New SqlParameter("@Flow_id", flow_Id)}
        Return Execute("Delete from MAT_Purchase_main where Orgcode=@orgcode and Flow_id=@Flow_id", params)
    End Function
End Class
