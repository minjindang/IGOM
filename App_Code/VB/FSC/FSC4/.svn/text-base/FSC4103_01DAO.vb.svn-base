Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

' ################################################
' ############### DataAccessObject ###############
' ################################################
Namespace FSC.Logic
    Public Class FSC4103_01DAO
        Dim ConnectionString As String = ""
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' 查詢個人密碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal Orgcode As String) As DataSet
            If Orgcode = "" Then Return Nothing
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "select Orgcode, Unlimited_time as Times, (case Year_time when '0' then '' else Year_time end ) as YearTimes, (case Month_time when '0' then '' else Month_time end ) as MonthTimes from FSC_Forget_clock_setting where Orgcode = '{0}'"
            StrSQL = String.Format(StrSQL, Orgcode)

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd
            'str = StrSQL
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "Forget_brush_card_ref_QueryByOrgcode")
                End Using

            Catch ex As Exception
                'str &= "<br><br>" & ex.ToString
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try

            Return Ds
            'Return str
        End Function

        ''' <summary>
        ''' 新增一筆資料到表格[忘刷卡次數設定檔]
        ''' </summary>
        ''' <returns>成功或是失敗訊息</returns>
        ''' <remarks></remarks>
        Public Function InsertForgetBrushCardRef(ByVal ObjEntity As FSC4103_01) As String
            Dim InsertMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "insert into FSC_Forget_clock_setting(Orgcode,Unlimited_time, Year_time, Month_time, Change_userid, Change_date, Depart_id) values "
            StrSQL = StrSQL & "('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, ObjEntity.Orgcode, ObjEntity.Unlimited_time, ObjEntity.Year_time, ObjEntity.Month_time, ObjEntity.Change_userid, Convert.ToDateTime(ObjEntity.Change_date.ToString()).ToString("yyyy/MM/dd HH:mm:ss"), ObjEntity.DepartId)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text
                    SqlCmd.ExecuteNonQuery()
                    If Me.IsInsertDataExist(ObjEntity.Orgcode) = 1 Then
                        InsertMessage = "新增至表格[忘刷卡次數設定檔]成功!"
                    End If
                End Using
            Catch ex As Exception
                InsertMessage = "新增至表格[忘刷卡次數設定檔]失敗!" & ex.ToString
            Finally
                SqlCmd.Connection.Close()
            End Try

            Return InsertMessage
        End Function

        ''' <summary>
        ''' 查詢資料是否存在
        ''' </summary>
        ''' <returns>傳回存在與否的代碼</returns>
        ''' <remarks></remarks>
        Public Function IsInsertDataExist(ByVal StrOrgcode As String) As Integer
            Dim IFlag As Integer = 0
            Dim SqlDR As New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = String.Format("select top 1 * from FSC_Forget_brush_card_ref where Orgcode = '{0}'", StrOrgcode)
            SqlCmd.CommandText = StrSQL
            SqlDR.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    SqlDR.Fill(Ds, "Forget_brush_card_ref_SelectOneOrgcode")
                    If Ds.Tables(0).Rows.Count > 0 Then
                        IFlag = 1
                    End If
                End Using
            Catch ex As Exception
                IFlag = 0
            Finally
                SqlDR.Dispose()
                SqlCmd.Connection.Close()
            End Try

            Return IFlag
        End Function

        ''' <summary>
        ''' 更新一筆資料到表格[忘刷卡次數設定檔]
        ''' </summary>
        ''' <returns>成功或是失敗訊息</returns>
        ''' <remarks></remarks>
        Public Function UpdateForgetBrushCardRef(ByVal ObjEntity As FSC4103_01) As String
            Dim UpdateMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "update FSC_Forget_clock_setting set Unlimited_time = '{0}', Year_time = '{1}', Month_time = '{2}', Change_userid = '{3}', Change_date = '{4}' where Orgcode = '{5}' "
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, ObjEntity.Unlimited_time, ObjEntity.Year_time, ObjEntity.Month_time, ObjEntity.Change_userid, Convert.ToDateTime(ObjEntity.Change_date.ToString()).ToString("yyyy/MM/dd HH:mm:ss"), ObjEntity.Orgcode)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    If SqlCmd.ExecuteNonQuery() = 1 Then
                        UpdateMessage = "更新至表格[忘刷卡次數設定檔]成功!"
                    Else
                        UpdateMessage = "更新至表格[忘刷卡次數設定檔]失敗!"
                    End If
                End Using
            Catch ex As Exception
                UpdateMessage = "更新至表格[忘刷卡次數設定檔]失敗!"
            Finally
                SqlCmd.Connection.Close()
            End Try

            Return UpdateMessage
        End Function
    End Class
End Namespace