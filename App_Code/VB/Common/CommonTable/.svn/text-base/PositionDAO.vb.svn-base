Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

' ################################################
' ################## 層級關係檔 ##################
' ############### DataAccessObject ###############
' ################################################
Namespace FSCPLM.Logic
    Public Class PositionDAO
        Dim ConnectionString As String = ""
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' 查詢 層級關係檔的 代理人ID, Name, PosCodeID
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDeputyID(ByVal ObjEntity As Position) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = " Select b.ID, (Select Name from Member where id = b.id) as Name, b.Deputy_posid as PosID, b.Depart_id as DepartID from position a left join position b on a.Deputy_posid = b.Posid where"
            If ObjEntity.Orgcode <> "" Then
                StrSQL = StrSQL + " a.Orgcode = '{0}' and  a.Depart_id = '{1}' and a.ID = '{2}' "
            End If

            StrSQL = String.Format(StrSQL, ObjEntity.Orgcode, ObjEntity.Depart_id, ObjEntity.ID)

            StrSQL = StrSQL + " order by b.posid"

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "Position_DeputyID_QueryByID")
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
        ''' 查詢 層級關係檔的 上一層直屬長官ID, Name, PosCodeID
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMasterID(ByVal ObjEntity As Position) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = " Select b.ID, (Select Name from Member where id = b.id) as Name, b.posid as PosID, b.Depart_id as DepartID from position a left join position b on a.fid = b.Posid where"
            If ObjEntity.Orgcode <> "" Then
                StrSQL = StrSQL + " a.Orgcode = '{0}' and a.ID = '{1}' and a.Depart_id = '{2}'"
            End If

            StrSQL = String.Format(StrSQL, ObjEntity.Orgcode, ObjEntity.ID, ObjEntity.Depart_id)

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "Position_MasterID_QueryByID")
                End Using

            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try

            Return Ds
        End Function


        ' ########## 取得某職稱的ID, Name, PosCodeID ########## 


        ' ########## 取得某個人的ID, Name, PosCodeID ########## 

    End Class
End Namespace