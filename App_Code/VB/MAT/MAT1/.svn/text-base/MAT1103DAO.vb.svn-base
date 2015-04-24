Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSCPLM.Logic
    Public Class MAT1103DAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Function queryFlowOne(flowID As String, orgCode As String) As DataTable

            Dim strSQL As String = "SELECT * FROM SYS_Flow where Flow_id = @flowID and orgCode =@orgCode "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@flowID", flowID), _
            New SqlParameter("@orgCode", orgCode)}
            Return Query(strSQL, ps)

        End Function

        Public Function getFlowByMergeFlowID(flowID As String) As DataTable

            Dim strSQL As String = "SELECT * FROM SYS_Flow where Merge_Flowid = @Merge_Flowid"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Merge_Flowid", flowID)}
            Return Query(strSQL, ps)

        End Function

        Public Sub UpdateOutCnt(flow_id As String, orgCode As String, details_id As String, Out_cnt As Integer)
            Dim strSQL As String = "UPDATE MAT_ApplyMaterial_det SET Out_cnt = @Out_cnt where Flow_id = @Flow_id and orgCode=@orgCode and details_id=@details_id "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Out_cnt", Out_cnt), _
            New SqlParameter("@details_id", details_id), _
            New SqlParameter("@Flow_id", flow_id), _
            New SqlParameter("@orgCode", orgCode)}
            Execute(strSQL, ps)
        End Sub


        Public Function GetByFlow(flow_id As String, orgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT * " & vbCrLf)
            StrSQL.Append("FROM   MAT_ApplyMaterial_det a " & vbCrLf)
            StrSQL.Append("       LEFT JOIN MAT_ApplyMaterial_main b " & vbCrLf)
            StrSQL.Append("              ON a.flow_id = b.flow_id " & vbCrLf)
            StrSQL.Append("                 AND a.orgcode = b.orgcode " & vbCrLf)
            StrSQL.Append("       LEFT JOIN EMP_Member d " & vbCrLf)
            StrSQL.Append("              ON b.User_id = d.id_card " & vbCrLf)
            StrSQL.Append("       LEFT JOIN MAT_Material_main c " & vbCrLf)
            StrSQL.Append("              ON a.material_id = c.material_id " & vbCrLf)
            StrSQL.Append("WHERE  a.flow_id IN (SELECT Flow_id " & vbCrLf)
            StrSQL.Append("                     FROM   SYS_Flow " & vbCrLf)
            StrSQL.Append("                     WHERE  flow_id = @flow_id " & vbCrLf)
            StrSQL.Append("                     UNION " & vbCrLf)
            StrSQL.Append("                     SELECT Flow_id " & vbCrLf)
            StrSQL.Append("                     FROM   SYS_Flow " & vbCrLf)
            StrSQL.Append("                     WHERE  merge_flowid = @flow_id) and a.OrgCode = @orgCode ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@orgCode", orgCode)}
            Return Query(StrSQL.ToString(), ps)
        End Function



    End Class
End Namespace

