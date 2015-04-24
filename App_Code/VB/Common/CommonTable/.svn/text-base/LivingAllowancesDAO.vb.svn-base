Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class LivingAllowancesDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetDataBySerialNos(ByVal Serial_nos As Integer) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM Living_allowances WHERE Serial_nos={0}"
            StrSQL = String.Format(StrSQL, Serial_nos)

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "Living_allowances_Query")
                End Using
            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function


        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ID_card As String, ByVal personnel_id As String, _
                ByVal Title_name As String, ByVal Salary_level_id As String, ByVal Apply_type As String, ByVal Persons_name As String, ByVal Relationship As String, _
                ByVal Occur_date As String, ByVal Apply_money As String, ByVal Testimonial_type As String, ByVal Change_userid As String, ByVal Salary As String) As Integer
            Dim InsertMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "INSERT INTO Living_allowances(Orgcode, Depart_id, ID_card, Personnel_id, Title_code, Salary_level_id, Apply_type, Persons_name, Relationship, Occur_date, Apply_money, Testimonial_type, Change_userid, Change_date,Salary) VALUES "
            StrSQL = StrSQL & "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14});SELECT @@IDENTITY AS 'Serial_nos';"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, Orgcode, Depart_id, ID_card, personnel_id, Title_name, Salary_level_id, Apply_type, _
                          Persons_name, Relationship, Occur_date, Apply_money, Testimonial_type, Change_userid, Now.ToString("yyyy/MM/dd HH:mm:ss"), Salary)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text
                    Return SqlCmd.ExecuteScalar

                End Using
            Catch ex As Exception
                Throw ex
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function
    End Class
End Namespace
