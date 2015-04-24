Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class PAY1101DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        Public Function PAY1101DAOInsertPurchase_detData(ByVal Flow_id As String, _
                                                         ByVal db As DataTable, _
                                                          ByVal OrgCode As String, _
                                                          ByVal ModUser_id As String, _
                                                          ByVal ModDate As Date) As Integer
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Puchase_detSqlData As String = ""
            StrSQL = "INSERT INTO MAT_Purchase_det (Flow_id,Item_name, Specification_desc, Unit, Apply_cnt,OrgCode,ModUser_id,Mod_date) "
            StrSQL &= "VALUES "
            For i As Integer = 0 To db.Rows.Count - 1
                If i = db.Rows.Count - 1 Then
                    Puchase_detSqlData = Puchase_detSqlData + "(@Flow_id, '" + db.Rows(i).Item("Item_name").ToString + "', '" + db.Rows(i).Item("Specification_desc").ToString + "', '" + db.Rows(i).Item("Unit").ToString + "', '" + db.Rows(i).Item("Apply_cnt").ToString + "', @OrgCode,@ModUser_id, @Mod_date) "
                Else
                    Puchase_detSqlData = Puchase_detSqlData + "(@Flow_id, '" + db.Rows(i).Item("Item_name").ToString + "', '" + db.Rows(i).Item("Specification_desc").ToString + "', '" + db.Rows(i).Item("Unit").ToString + "', '" + db.Rows(i).Item("Apply_cnt").ToString + "', @OrgCode,@ModUser_id, @Mod_date), "
                End If
            Next
            StrSQL &= Puchase_detSqlData
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), _
                                        New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@Mod_date", ModDate)}
            Return Execute(StrSQL, ps)
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
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO MAT_Purchase_main (Flow_id, User_id, Unit_code, Apply_date, Use_desc, Purchase_type, Attachment,OrgCode,ModUser_id,Mod_date) "
            StrSQL &= "VALUES(@Flow_id, @User_id, @Unit_code, @Apply_date, @Use_desc, @Purchase_type, @Attachment, @OrgCode, @ModUser_id, @Mod_date) "
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), _
                                        New SqlParameter("@User_id", User_id), _
                                        New SqlParameter("@Unit_code", Unit_code), _
                                        New SqlParameter("@Apply_date", Apply_date), _
                                        New SqlParameter("@Use_desc", Use_desc), _
                                        New SqlParameter("@Purchase_type", Purchase_type), _
                                        New SqlParameter("@Attachment", Attachment), _
                                        New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@Mod_date", ModDate)}
            Return Execute(StrSQL, ps)
        End Function
    End Class
End Namespace