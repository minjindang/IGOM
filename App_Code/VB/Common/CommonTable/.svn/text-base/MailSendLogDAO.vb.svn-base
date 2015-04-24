Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Namespace FSCPLM.Logic

    Public Class MailSendLogDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetData(Optional ByVal Flow_id As String = "", _
                                Optional ByVal Orgcode As String = "", _
                                Optional ByVal Id_card As String = "", _
                                Optional ByVal Change_date As DateTime = Nothing, _
                                Optional ByVal ID As Integer = Nothing) As DataTable

            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT     Flow_id, Orgcode, Id_card, Change_date, ID    FROM    SYS_Mail_send_log  WHERE 1=1  "
            Dim params As New System.Collections.Generic.List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL &= " AND  Flow_id=@Flow_id "
                Dim param As SqlParameter = New SqlParameter("@Flow_id", SqlDbType.VarChar)
                param.Value = Flow_id
                params.Add(param)
            End If


            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= " AND  Orgcode=@Orgcode "
                Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
                param.Value = Orgcode
                params.Add(param)
            End If


            If Not String.IsNullOrEmpty(Id_card) Then
                StrSQL &= " AND  Id_card=@Id_card "
                Dim param As SqlParameter = New SqlParameter("@Id_card", SqlDbType.VarChar)
                param.Value = Id_card
                params.Add(param)
            End If


            If Not IsNothing(Change_date) Then
                StrSQL &= " AND  Change_date=@Change_date "
                Dim param As SqlParameter = New SqlParameter("@Change_date", SqlDbType.DateTime)
                param.Value = Change_date
                params.Add(param)
            End If


            If Not IsNothing(ID) AndAlso ID <> 0 Then
                StrSQL &= " AND  ID=@ID "
                Dim param As SqlParameter = New SqlParameter("@ID", SqlDbType.Int)
                param.Value = ID
                params.Add(param)
            End If

            Return Query(StrSQL, params.ToArray)
        End Function

        Public Function UpdateData(ByVal ID As Integer, _
                                   Optional ByVal Flow_id As String = "", _
                                   Optional ByVal Orgcode As String = "", _
                                   Optional ByVal Id_card As String = "", _
                                   Optional ByVal Change_date As DateTime = Nothing) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE SET  SYS_Mail_send_log   "
            Dim params As New System.Collections.Generic.List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL &= "   Flow_id=@Flow_id ,"
                Dim param As SqlParameter = New SqlParameter("@Flow_id", SqlDbType.VarChar)
                param.Value = Flow_id
                params.Add(param)
            End If


            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "  Orgcode=@Orgcode ,"
                Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
                param.Value = Orgcode
                params.Add(param)
            End If


            If Not String.IsNullOrEmpty(Id_card) Then
                StrSQL &= "   Id_card=@Id_card ,"
                Dim param As SqlParameter = New SqlParameter("@Id_card", SqlDbType.VarChar)
                param.Value = Id_card
                params.Add(param)
            End If


            If Not IsNothing(Change_date) Then
                StrSQL &= "  Change_date=@Change_date ,"
                Dim param As SqlParameter = New SqlParameter("@Change_date", SqlDbType.DateTime)
                param.Value = Change_date
                params.Add(param)
            End If

            StrSQL = StrSQL.TrimEnd(",")
            If Not IsNothing(ID) Then
                StrSQL &= " WHERE  ID=@ID "
                Dim param As SqlParameter = New SqlParameter("@ID", SqlDbType.Int)
                param.Value = ID
                params.Add(param)
            End If
            Return Execute(StrSQL, params.ToArray)
        End Function

        Public Function InsertData(ByVal Flow_id As String, _
                                   ByVal Orgcode As String, _
                                   ByVal Id_card As String, _
                                   ByVal Change_date As DateTime) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = " INSERT INTO  SYS_Mail_send_log(  Flow_id, Orgcode, Id_card, Change_date)  values( "
            Dim params As New System.Collections.Generic.List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL &= " @Flow_id ,"
                Dim param As SqlParameter = New SqlParameter("@Flow_id", SqlDbType.VarChar)
                param.Value = Flow_id
                params.Add(param)
            End If

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= " @Orgcode ,"
                Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
                param.Value = Orgcode
                params.Add(param)
            End If

            If Not String.IsNullOrEmpty(Id_card) Then
                StrSQL &= " @Id_card ,"
                Dim param As SqlParameter = New SqlParameter("@Id_card", SqlDbType.VarChar)
                param.Value = Id_card
                params.Add(param)
            End If

            If Not IsNothing(Change_date) Then
                StrSQL &= "@Change_date ,"
                Dim param As SqlParameter = New SqlParameter("@Change_date", SqlDbType.DateTime)
                param.Value = Change_date
                params.Add(param)
            End If
            StrSQL = StrSQL.TrimEnd(",")
            StrSQL += ")"
            Return Execute(StrSQL, params.ToArray)

        End Function


    End Class

End Namespace
