Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class OvertimepaySettingDAO
        Dim ConnectionString As String = String.Empty
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' 查詢加班費關帳設定檔
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByOrgcode(ByVal Orgcode As String) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM Overtimepay_setting WHERE Orgcode='{0}'"
            StrSQL = String.Format(StrSQL, Orgcode)

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "Overtimepay_setting_Query")
                End Using
            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function

        ''' <summary>
        ''' 查詢一筆加班費關帳設定檔
        ''' </summary>
        ''' <param name="Serial_nos"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataBySerial_nos(ByVal Serial_nos As Integer) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM Overtimepay_setting WHERE Serial_nos={0}"

            StrSQL = String.Format(StrSQL, Serial_nos)

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "Overtimepay_setting_Query")
                End Using
            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function

        ''' <summary>
        ''' 新增一筆加班費關帳設定檔
        ''' </summary>
        ''' <param name="Year"></param>
        ''' <param name="Month"></param>
        ''' <param name="Close_day"></param>
        ''' <param name="Start_flag"></param>
        ''' <param name="Change_userid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertData(ByVal Orgcode As String, ByVal Year As String, ByVal Month As String, ByVal Close_day As String, ByVal Start_flag As String, ByVal Change_userid As String) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "INSERT INTO Overtimepay_setting (Orgcode, Year, Month, Close_day, Start_flag, Change_userid, Change_date) " & _
                        "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, Year, Month, Close_day, Start_flag, Change_userid, Now.ToString("yyyy/MM/dd HH:mm:ss"))

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function

        ''' <summary>
        ''' 更新一筆加班費關帳設定檔
        ''' </summary>
        ''' <param name="Year"></param>
        ''' <param name="Month"></param>
        ''' <param name="Close_day"></param>
        ''' <param name="Start_flag"></param>
        ''' <param name="Change_userid"></param>
        ''' <param name="Serial_nos"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateData(ByVal Orgcode As String, ByVal Year As String, ByVal Month As String, ByVal Close_day As String, ByVal Start_flag As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "UPDATE Overtimepay_setting SET Orgcode='{0}', Year='{1}', Month='{2}', Close_day='{3}', Start_flag='{4}', Change_userid='{5}', Change_date='{6}' " & _
                        "WHERE Serial_nos={7}"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, Orgcode, Year, Month, Close_day, Start_flag, Change_userid, Now.ToString("yyyy/MM/dd HH:mm:ss"), Serial_nos)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
        End Function

        ''' <summary>
        ''' 刪除一筆加班費關帳設定檔
        ''' </summary>
        ''' <param name="original_Serial_nos"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteData(ByVal original_Serial_nos As Integer) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "DELETE FROM Overtimepay_setting WHERE Serial_nos={0}"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, original_Serial_nos)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

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