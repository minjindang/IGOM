Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Public Class ApplyOtherMtrMainDAO
    Inherits BaseDAO

    Dim Connection As SqlConnection
    Dim ConnectionString As String = String.Empty

    Public Sub New()
        ConnectionString = ConnectDB.GetDBString()
    End Sub

    Public Sub New(ByVal conn As SqlConnection)
        Me.Connection = conn
    End Sub

    Public Function GetOne(ByVal Form_id As Integer) As DataTable
        Return Query("select * from MAT_ApplyOtherMtr_main where Form_id = @Form_id", New SqlParameter("@Form_id", Form_id))
    End Function

    Public Sub Update(ByVal Form_id As String, ByVal Flow_id As String, ByVal Apply_date As String, ByVal Unit_Code As String, ByVal User_id As String, ByVal TotalPrice_amt As Integer _
                      , ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String)
        Dim sql As New System.Text.StringBuilder
        sql.Append("UPDATE MAT_ApplyOtherMtr_main " & vbCrLf)
        sql.Append("          SET  [Flow_id]=@Flow_id, " & vbCrLf)
        sql.Append("             [Apply_date]=@Apply_date, " & vbCrLf)
        sql.Append("             [Unit_Code]=@Unit_Code, " & vbCrLf)
        sql.Append("             [User_id]=@User_id, " & vbCrLf)
        sql.Append("             [TotalPrice_amt]=@TotalPrice_amt, " & vbCrLf)
        sql.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
        sql.Append("             [Mod_date]=@Mod_date, " & vbCrLf)
        sql.Append("             [OrgCode]=@OrgCode WHERE Form_id = @Form_id " & vbCrLf)

        Dim ps() As SqlParameter = {New SqlParameter("@Form_id", Form_id), _
                                    New SqlParameter("@Flow_id", Flow_id), _
                                    New SqlParameter("@Apply_date", Apply_date), _
                                    New SqlParameter("@Unit_Code", Unit_Code), _
                                    New SqlParameter("@User_id", User_id), _
                                    New SqlParameter("@TotalPrice_amt", TotalPrice_amt), _
                                    New SqlParameter("@ModUser_id", ModUser_id), _
                                    New SqlParameter("@Mod_date", Mod_date), _
                                    New SqlParameter("@OrgCode", OrgCode)}


        Execute(sql.ToString(), ps)

    End Sub

    Public Function Insert(ByVal Flow_id As String, ByVal Apply_date As String, ByVal Unit_Code As String, ByVal User_id As String, ByVal TotalPrice_amt As Integer _
                      , ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String) As Integer
        Dim sql As New System.Text.StringBuilder
        sql.Append("INSERT INTO MAT_ApplyOtherMtr_main " & vbCrLf)
        sql.Append("            ([Flow_id], " & vbCrLf)
        sql.Append("             [Apply_date], " & vbCrLf)
        sql.Append("             [Unit_Code], " & vbCrLf)
        sql.Append("             [User_id], " & vbCrLf)
        sql.Append("             [TotalPrice_amt], " & vbCrLf)
        sql.Append("             [ModUser_id], " & vbCrLf)
        sql.Append("             [Mod_date], " & vbCrLf)
        sql.Append("             [OrgCode]) " & vbCrLf)
        sql.Append("VALUES      (@Flow_id, " & vbCrLf)
        sql.Append("             @Apply_date, " & vbCrLf)
        sql.Append("             @Unit_Code, " & vbCrLf)
        sql.Append("             @User_id, " & vbCrLf)
        sql.Append("             @TotalPrice_amt, " & vbCrLf)
        sql.Append("             @ModUser_id, " & vbCrLf)
        sql.Append("             @Mod_date, " & vbCrLf)
        sql.Append("             @OrgCode) ")
        Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), _
                                    New SqlParameter("@Apply_date", Apply_date), _
                                    New SqlParameter("@Unit_Code", Unit_Code), _
                                    New SqlParameter("@User_id", User_id), _
                                    New SqlParameter("@TotalPrice_amt", TotalPrice_amt), _
                                    New SqlParameter("@ModUser_id", ModUser_id), _
                                    New SqlParameter("@Mod_date", Mod_date), _
                                    New SqlParameter("@OrgCode", OrgCode)}

        sql.Append("; SELECT SCOPE_IDENTITY(); ")
        'Execute(sql.ToString(), ps)
        Return Scalar(sql.ToString(), ps)
        'Return 1

    End Function

    Public Function GetData(ByVal Apply_DateS As String, ByVal Apply_DateE As String, ByVal User_id As String) As DataTable
        Dim StrSQL As String = String.Empty
        StrSQL = " SELECT a.Details_id,b.Flow_id,a.Material_name,a.Out_cnt,a.Unit,a.TotalPrice_amt, " + _
            " a.Company_name,a.Memo,b.Apply_date,d.User_name " + _
            " FROM MAT_ApplyOtherMtr_det a  " + _
            " left join MAT_ApplyOtherMtr_main b on a.form_id = b.form_id " + _
            " left join EMP_Member d on b.User_id = d.id_card " + _
            " where 1= 1 "
        If Not String.IsNullOrEmpty(Apply_DateS) Then
            StrSQL += " and b.Apply_date >= @Apply_DateS "
        End If

        If Not String.IsNullOrEmpty(Apply_DateE) Then
            StrSQL += " and b.Apply_date <= @Apply_DateE "
        End If

        If Not String.IsNullOrEmpty(User_id) Then
            StrSQL += " and b.User_id = @User_id "
        End If

        Dim ps() As SqlParameter = {New SqlParameter("@Apply_DateS", Apply_DateS), New SqlParameter("@Apply_DateE", Apply_DateE), New SqlParameter("@User_id", User_id)}
        Return Query(StrSQL, ps)
    End Function


    Public Sub Delete(ByVal Form_Id As Integer)
        Dim sql As New System.Text.StringBuilder
        sql.Append("DELETE FROM MAT_ApplyOtherMtr_main WHERE Form_Id = @Form_Id ")

        Dim ps() As SqlParameter = {New SqlParameter("@Form_Id", Form_Id)}
        Execute(sql.ToString(), ps)

    End Sub

End Class
