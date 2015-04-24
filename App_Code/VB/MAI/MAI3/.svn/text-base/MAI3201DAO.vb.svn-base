Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MAI3201DAO 
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function SelectUnitCode() As DataTable
            Return Query("SELECT DISTINCT Unit_Code FROM MAI_ElecMaintain_main ")
        End Function

        Public Function SelectStatusNot003Count(OrgCode As String, Flow_id As String) As Integer
            Dim StrSQL As String = "SELECT COUNT(*) FROM MAI_ElecMaintain_det WHERE OrgCode=@OrgCode AND Flow_id=@Flow_id AND (MtStatus_type <> '003' or MtStatus_type is null) "

            Dim ps() As SqlParameter = { _
                 New SqlParameter("@OrgCode", OrgCode), _
                 New SqlParameter("@Flow_id", Flow_id)}

            Return Scalar(StrSQL, ps)
        End Function

        Public Function SelectBy(MtClass_type As String, MtItemOther_desc As String, ApplyTimeS As DateTime, ApplyTimeE As DateTime, _
                                 Unit_code As String, Phone_nos As String, MtStatus_type As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT b.Flow_id, " & vbCrLf)
            StrSQL.Append("       b.User_name, " & vbCrLf)
            StrSQL.Append("       b.ApplyTime, " & vbCrLf)
            StrSQL.Append("       a.MtClass_type, " & vbCrLf)
            StrSQL.Append("       a.Problem_desc, " & vbCrLf)
            StrSQL.Append("       a.MaintainerPhone_nos, " & vbCrLf)
            StrSQL.Append("       a.Maintainer_name, " & vbCrLf)
            StrSQL.Append("       a.MtStatus_type, " & vbCrLf)
            StrSQL.Append("       b.CaseClose_type " & vbCrLf)
            StrSQL.Append("FROM   MAI_ElecMaintain_det a " & vbCrLf)
            StrSQL.Append("       LEFT JOIN MAI_ElecMaintain_main b " & vbCrLf)
            StrSQL.Append("              ON a.OrgCode = b.OrgCode " & vbCrLf)
            StrSQL.Append("                 AND a.Flow_id = b.Flow_id WHERE 1=1 ")

            If Not String.IsNullOrEmpty(MtClass_type) Then

                If Not String.IsNullOrEmpty(MtItemOther_desc) Then
                    StrSQL.Append(" AND ( a.MtClass_type IN (" + MtClass_type + ") OR a.MtItemOther_desc = @MtItemOther_desc) ")
                Else
                    StrSQL.Append(" AND a.MtClass_type IN (" + MtClass_type + ") ")
                End If
            Else
                If Not String.IsNullOrEmpty(MtItemOther_desc) Then
                    StrSQL.Append(" AND a.MtItemOther_desc = @MtItemOther_desc ")
                End If
            End If



            If ApplyTimeS <> DateTime.MinValue Then
                StrSQL.Append(" AND b.ApplyTime >= @ApplyTimeS ")
            Else
                ApplyTimeS = Now
            End If

            If ApplyTimeE <> DateTime.MinValue Then
                StrSQL.Append(" AND b.ApplyTime <= @ApplyTimeE ")
            Else
                ApplyTimeE = Now
            End If

            If Not String.IsNullOrEmpty(Unit_code) Then
                StrSQL.Append(" AND b.Unit_code = @Unit_code ")
            End If

            If Not String.IsNullOrEmpty(Phone_nos) Then
                StrSQL.Append(" AND b.Phone_nos = @Phone_nos ")
            End If

            If Not String.IsNullOrEmpty(MtStatus_type) Then
                StrSQL.Append(" AND a.MtStatus_type IN (" + MtStatus_type + ") ")
            End If


            Dim ps() As SqlParameter = { _
                  New SqlParameter("@MtClass_type", MtClass_type), _
                  New SqlParameter("@MtItemOther_desc", MtItemOther_desc), _
                  New SqlParameter("@ApplyTimeE", ApplyTimeE), _
                  New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                  New SqlParameter("@Unit_code", Unit_code), _
                  New SqlParameter("@Phone_nos", Phone_nos), _
                  New SqlParameter("@MtStatus_type", MtStatus_type)}

            Return Query(StrSQL.ToString(), ps)

        End Function

    End Class
End Namespace
