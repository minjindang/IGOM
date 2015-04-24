Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class InformationDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal Inf_type As String, ByVal Inf_flag As String) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM Information WHERE Orgcode=@Orgcode AND Inf_type=@Inf_type AND Inf_type=@Inf_type AND Inf_flag=@Inf_flag"

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode), _
                                            New SqlParameter("@Inf_type", Inf_type), _
                                            New SqlParameter("@Inf_flag", Inf_flag)}
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlCmd.Parameters.AddRange(params)

                    SqlDA.Fill(Ds, "Information_Query")
                    If Ds.Tables(0).Rows.Count > 0 Then
                    Else
                        Ds = Nothing
                    End If
                End Using

            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function

        Public Function GetDataBySerail_nos(ByVal Serial_nos As Integer) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM Information WHERE Serial_nos=@Serial_nos"

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Dim param As SqlParameter = New SqlParameter("@Serial_nos", Serial_nos)
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlCmd.Parameters.Add(param)

                    SqlDA.Fill(Ds, "Information_Query")
                    If Ds.Tables(0).Rows.Count > 0 Then
                    Else
                        Ds = Nothing
                    End If
                End Using

            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function


        Public Function GetDataByInf_orgcode(ByVal Inf_type As String, ByVal Inf_orgcode As String) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM Information WHERE Inf_type=@Inf_type AND Inf_orgcode like '%'+ @Inf_orgcode +'%' AND Inf_flag='Y'"

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Dim params() As SqlParameter = {New SqlParameter("@Inf_type", Inf_type), New SqlParameter("@Inf_orgcode", Inf_orgcode)}
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlCmd.Parameters.AddRange(params)

                    SqlDA.Fill(Ds, "Information_Query")
                    If Ds.Tables(0).Rows.Count > 0 Then
                    Else
                        Ds = Nothing
                    End If
                End Using

            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function


        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Post_idcard As String, _
                                    ByVal Inf_type As String, ByVal Inf_title As String, ByVal Inf_content As String, ByVal Inf_link As String, _
                                    ByVal Inf_orgcode As String, ByVal Inf_flag As String, ByVal Change_userid As String) As Integer
            Dim InsertMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO Information(Orgcode, Depart_id, Post_idcard, Post_date, Inf_type, Inf_title, Inf_content, Inf_link, Inf_flag, Inf_orgcode, Change_userid, Change_date) " & _
                    "VALUES " & _
                    "(@Orgcode, @Depart_id, @Post_idcard, @Post_date, @Inf_type, @Inf_title, @Inf_content, @Inf_link, @Inf_flag, @Inf_orgcode, @Change_user, @Change_date)"

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    Dim params() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode), _
                                                    New SqlParameter("@Depart_id", Depart_id), _
                                                    New SqlParameter("@Post_idcard", Post_idcard), _
                                                    New SqlParameter("@Post_date", Now.ToString("yyyy/MM/dd HH:mm:ss")), _
                                                    New SqlParameter("@Inf_type", Inf_type), _
                                                    New SqlParameter("@Inf_title", Inf_title), _
                                                    New SqlParameter("@Inf_content", Inf_content), _
                                                    New SqlParameter("@Inf_link", Inf_link), _
                                                    New SqlParameter("@Inf_flag", Inf_flag), _
                                                    New SqlParameter("@Inf_orgcode", Inf_orgcode), _
                                                    New SqlParameter("@Change_user", Change_userid), _
                                                    New SqlParameter("@Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))}
                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text
                    SqlCmd.Parameters.AddRange(params)
                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function

        Public Function UpdateData(ByVal Inf_type As String, ByVal Inf_title As String, ByVal Inf_content As String, ByVal Inf_link As String, _
                                    ByVal Inf_flag As String, ByVal Inf_orgcode As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Integer
            Dim InsertMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = String.Empty
            StrSQL = "UPDATE Information SET Inf_type=@Inf_type, Inf_title=@Inf_title, Inf_content=@Inf_content, Inf_link=@Inf_link, Inf_flag=@Inf_flag, Inf_Orgcode=@Inf_Orgcode, Change_userid=@Change_userid, Change_date=@Change_date  " & _
                    "WHERE Serial_nos=@Serial_nos"

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    Dim params() As SqlParameter = {New SqlParameter("@Inf_type", Inf_type), _
                                                    New SqlParameter("@Inf_title", Inf_title), _
                                                    New SqlParameter("@Inf_content", Inf_content), _
                                                    New SqlParameter("@Inf_link", Inf_link), _
                                                    New SqlParameter("@Inf_flag", Inf_flag), _
                                                    New SqlParameter("@Inf_orgcode", Inf_orgcode), _
                                                    New SqlParameter("@Change_userid", Change_userid), _
                                                    New SqlParameter("@Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss")), _
                                                    New SqlParameter("@Serial_nos", Serial_nos)}
                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text
                    SqlCmd.Parameters.AddRange(params)
                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function


        Public Function UpdateInf_flag(ByVal Inf_flag As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Integer
            Dim InsertMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = String.Empty
            StrSQL = "UPDATE Information SET Inf_flag=@Inf_flag, Change_userid=@Change_userid, Change_date=@Change_date " & _
                        "WHERE Serial_nos=@Serial_nos"

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    Dim params() As SqlParameter = {New SqlParameter("@Inf_flag", Inf_flag), _
                                                    New SqlParameter("@Change_userid", Change_userid), _
                                                    New SqlParameter("@Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss")), _
                                                    New SqlParameter("@Serial_nos", Serial_nos)}
                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text
                    SqlCmd.Parameters.AddRange(params)
                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function


        Public Function DeleteData(ByVal Serial_nos As Integer) As Integer
            Dim InsertMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = String.Empty
            StrSQL = "DELETE FROM Information WHERE Serial_nos=@Serial_nos"

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    Dim param As SqlParameter = New SqlParameter("@Serial_nos", Serial_nos)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text
                    SqlCmd.Parameters.Add(param)
                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function
    End Class
End Namespace