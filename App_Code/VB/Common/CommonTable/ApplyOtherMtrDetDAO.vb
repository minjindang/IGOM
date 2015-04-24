Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Public Class ApplyOtherMtrDetDAO
    Inherits BaseDAO

    Dim Connection As SqlConnection
    Dim ConnectionString As String = String.Empty

    Public Sub New()
        ConnectionString = ConnectDB.GetDBString()
    End Sub

    Public Sub New(ByVal conn As SqlConnection)
        Me.Connection = conn
    End Sub 

    Public Function GetCountByFomID(ByVal Form_Id As Integer) As Integer
        Return Scalar("select count(*) from MAT_ApplyOtherMtr_det where Form_Id = @Form_Id", New SqlParameter("@Form_Id", Form_Id))
    End Function

    Public Function GetOne(ByVal details_id As Integer) As DataTable
        Return Query("select * from MAT_ApplyOtherMtr_det where Details_id = @Details_id", New SqlParameter("@Details_id", details_id))
    End Function

    Public Sub Update(ByVal Details_id As Integer, ByVal Form_id As Integer, ByVal Material_name As String, ByVal Unit As String, ByVal Out_cnt As Double, ByVal TotalPrice_amt As Double _
                      , ByVal Company_name As String, ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String)
        Dim sql As New System.Text.StringBuilder
        sql.Append("UPDATE MAT_ApplyOtherMtr_det " & vbCrLf)
        sql.Append("            set [Form_id]=@Form_id, " & vbCrLf)
        sql.Append("             [Material_name]=@Material_name, " & vbCrLf)
        sql.Append("             [Unit]=@Unit, " & vbCrLf)
        sql.Append("             [Out_cnt]=@Out_cnt, " & vbCrLf)
        sql.Append("             [TotalPrice_amt]=@TotalPrice_amt, " & vbCrLf)
        sql.Append("             [Company_name]=@Company_name, " & vbCrLf)
        sql.Append("             [Memo]=@Memo, " & vbCrLf)
        sql.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
        sql.Append("             [Mod_date]=@Mod_date, " & vbCrLf)
        sql.Append("             [OrgCode]=@OrgCode WHERE Details_id =@Details_id " & vbCrLf)

        Dim ps() As SqlParameter = {New SqlParameter("@Details_id", Details_id), _
                                    New SqlParameter("@Form_id", Form_id), _
                                    New SqlParameter("@Material_name", Material_name), _
                                    New SqlParameter("@Unit", Unit), _
                                    New SqlParameter("@Out_cnt", Out_cnt), _
                                    New SqlParameter("@TotalPrice_amt", TotalPrice_amt), _
                                    New SqlParameter("@Company_name", Company_name), _
                                    New SqlParameter("@Memo", Memo), _
                                    New SqlParameter("@ModUser_id", ModUser_id), _
                                    New SqlParameter("@Mod_date", Mod_date), _
                                    New SqlParameter("@OrgCode", OrgCode)}


        Execute(sql.ToString(), ps)
    End Sub

    Public Sub Insert(ByVal Form_id As Integer, ByVal Material_name As String, ByVal Unit As String, ByVal Out_cnt As Double, ByVal TotalPrice_amt As Double _
                      , ByVal Company_name As String, ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String)
        Dim sql As New System.Text.StringBuilder
        sql.Append("INSERT INTO MAT_ApplyOtherMtr_det " & vbCrLf)
        sql.Append("            ([Form_id], " & vbCrLf)
        sql.Append("             [Material_name], " & vbCrLf)
        sql.Append("             [Unit], " & vbCrLf)
        sql.Append("             [Out_cnt], " & vbCrLf)
        sql.Append("             [TotalPrice_amt], " & vbCrLf)
        sql.Append("             [Company_name], " & vbCrLf)
        sql.Append("             [Memo], " & vbCrLf)
        sql.Append("             [ModUser_id], " & vbCrLf)
        sql.Append("             [Mod_date], " & vbCrLf)
        sql.Append("             [OrgCode]) " & vbCrLf)
        sql.Append("VALUES      (@Form_id, " & vbCrLf)
        sql.Append("             @Material_name, " & vbCrLf)
        sql.Append("             @Unit, " & vbCrLf)
        sql.Append("             @Out_cnt, " & vbCrLf)
        sql.Append("             @TotalPrice_amt, " & vbCrLf)
        sql.Append("             @Company_name, " & vbCrLf)
        sql.Append("             @Memo, " & vbCrLf)
        sql.Append("             @ModUser_id, " & vbCrLf)
        sql.Append("             @Mod_date, " & vbCrLf)
        sql.Append("             @OrgCode) ")

        Dim ps() As SqlParameter = {New SqlParameter("@Form_id", Form_id), _
                                    New SqlParameter("@Material_name", Material_name), _
                                    New SqlParameter("@Unit", Unit), _
                                    New SqlParameter("@Out_cnt", Out_cnt), _
                                    New SqlParameter("@TotalPrice_amt", TotalPrice_amt), _
                                    New SqlParameter("@Company_name", Company_name), _
                                    New SqlParameter("@Memo", Memo), _
                                    New SqlParameter("@ModUser_id", ModUser_id), _
                                    New SqlParameter("@Mod_date", Mod_date), _
                                    New SqlParameter("@OrgCode", OrgCode)}


        Execute(sql.ToString(), ps)

    End Sub

    Public Sub Delete(ByVal Details_id As Integer)
        Dim sql As New System.Text.StringBuilder
        sql.Append("DELETE FROM MAT_ApplyOtherMtr_det WHERE Details_id = @Details_id ")

        Dim ps() As SqlParameter = {New SqlParameter("@Details_id", Details_id)}


        Execute(sql.ToString(), ps)

    End Sub

End Class
