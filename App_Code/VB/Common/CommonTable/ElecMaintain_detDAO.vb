Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class ElecMaintain_detDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO MAI_ElecMaintain_det ( ")
            StrSQL.Append(" OrgCode,Flow_id,MtItem_type,MtClass_type,ElecExpect_type, ")
            StrSQL.Append(" MtItemOther_desc,Problem_desc,MtStartTime,MtEndTime,MtTime, ")
            StrSQL.Append(" MaintainerPhone_nos,Maintainer_name,MtStatus_type,MtStatus_desc,Satisfaction_type, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@MtItem_type,@MtClass_type,@ElecExpect_type, ")
            StrSQL.Append(" @MtItemOther_desc,@Problem_desc,@MtStartTime,@MtEndTime,@MtTime, ")
            StrSQL.Append(" @MaintainerPhone_nos,@Maintainer_name,@MtStatus_type,@MtStatus_desc,@Satisfaction_type, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE MAI_ElecMaintain_det SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,MtItem_type=@MtItem_type,MtClass_type=@MtClass_type,ElecExpect_type=@ElecExpect_type, ")
            StrSQL.Append(" MtItemOther_desc=@MtItemOther_desc,Problem_desc=@Problem_desc,MtStartTime=@MtStartTime,MtEndTime=@MtEndTime,MtTime=@MtTime, ")
            StrSQL.Append(" MaintainerPhone_nos=@MaintainerPhone_nos,Maintainer_name=@Maintainer_name,MtStatus_type=@MtStatus_type,MtStatus_desc=@MtStatus_desc,Satisfaction_type=@Satisfaction_type, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND MtClass_type=@MtClass_type  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional OrgCode As String = "", Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,MtItem_type,MtClass_type,ElecExpect_type, ")
            StrSQL.Append(" MtItemOther_desc,Problem_desc,MtStartTime,MtEndTime,MtTime, ")
            StrSQL.Append(" MaintainerPhone_nos,Maintainer_name,MtStatus_type,MtStatus_desc,Satisfaction_type ")
            StrSQL.Append("  FROM MAI_ElecMaintain_det  ")
            StrSQL.Append("  WHERE 1=1  ")

            If Not String.IsNullOrEmpty(OrgCode) Then
                StrSQL.Append("  AND  OrgCode=@OrgCode ")
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND  Flow_id=@Flow_id ")
            End If


            Dim ps() As SqlParameter = { _
                  New SqlParameter("@OrgCode", OrgCode), _
                  New SqlParameter("@Flow_id", Flow_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Flow_id As String, MtClass_type As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,MtItem_type,MtClass_type,ElecExpect_type, ")
            StrSQL.Append(" MtItemOther_desc,Problem_desc,MtStartTime,MtEndTime,MtTime, ")
            StrSQL.Append(" MaintainerPhone_nos,Maintainer_name,MtStatus_type,MtStatus_desc,Satisfaction_type ")
            StrSQL.Append("  FROM MAI_ElecMaintain_det  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND MtClass_type=@MtClass_type  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@MtClass_type", MtClass_type), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Flow_id As String, MtClass_type As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM MAI_ElecMaintain_det WHERE  Flow_id=@Flow_id AND MtClass_type=@MtClass_type AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@MtClass_type", MtClass_type), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace