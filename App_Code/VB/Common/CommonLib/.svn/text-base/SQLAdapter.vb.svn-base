Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Text


Namespace Pemis2009.SQLAdapter

#Region "SQLAdapter"

    Public Class SQLAdapter

        ' Fields
        Private mCommand As SqlCommand
        Private mConn As SqlConnection
        Private mTrans As SqlTransaction

        ' Methods
        Public Sub New()
            Me.mConn = New SqlConnection(ConnectDB.GetDBString())
            Me.mCommand = New SqlCommand
            Me.mCommand.Connection = Me.mConn
        End Sub

        Public Sub New(ByVal connectionString As String)
            Me.mConn = New SqlConnection(connectionString)
            Me.mCommand = New SqlCommand
            Me.mCommand.Connection = Me.mConn
        End Sub

        ''' <summary>
        ''' 0980911 jen li add
        ''' </summary>
        ''' <param name="connection">SqlConnection</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal connection As SqlConnection)
            Me.mConn = connection
            Me.mCommand = New SqlCommand
            Me.mCommand.Connection = Me.mConn
        End Sub

        Public Sub BeginTrain()
            Me.mTrans = Me.mConn.BeginTransaction
            Me.mCommand.Transaction = Me.mTrans
        End Sub

        Public Sub CloseConn()
            Try
                If (Me.mConn.State <> ConnectionState.Closed) Then
                    Me.mConn.Close()
                End If
            Catch exception1 As Exception
                'ProjectData.SetProjectError(exception1)
                Dim ex As Exception = exception1
                Throw ex
            End Try
        End Sub

        Public Sub CommitTrain()
            Me.mTrans.Commit()
        End Sub

        Public Function ExecNoQueryCmd(ByVal sSQL As String) As Integer
            Try
                Me.mCommand.CommandText = sSQL
                ExecNoQueryCmd = Me.mCommand.ExecuteNonQuery
            Catch exception1 As Exception
                'ProjectData.SetProjectError(exception1)
                Dim ex As Exception = exception1
                Throw ex
            Finally
                Me.mConn.Close()
            End Try
            Return ExecNoQueryCmd
        End Function

        Public Function ExecNoQueryCmd(ByVal sSQL As String, ByVal cmdType As CommandType, ByVal ParamArray Parms As SqlParameter()) As Integer
            Try
                Me.mCommand.CommandText = sSQL
                Me.mCommand.CommandType = cmdType
                Me.mCommand.Parameters.Clear()
                Dim Parm As SqlParameter
                For Each Parm In Parms
                    Me.mCommand.Parameters.Add(Parm)
                Next
                If Me.mConn.State <> ConnectionState.Open Then
                    Me.mConn.Open()
                End If
                ExecNoQueryCmd = Me.mCommand.ExecuteNonQuery
            Catch exception1 As Exception
                'ProjectData.SetProjectError(exception1)
                Dim ex As Exception = exception1
                Throw ex
            Finally
                Me.mConn.Close()
            End Try
            Return ExecNoQueryCmd
        End Function

        Public Function ExecQueryCmd(ByVal sSQL As String) As SqlDataReader
            Me.mCommand.CommandText = sSQL
            Return Me.mCommand.ExecuteReader
        End Function

        Public Function ExecQueryCmd(ByVal sSQL As String, ByVal cmdType As CommandType, ByVal ParamArray Parms As SqlParameter()) As SqlDataReader
            Try
                Me.mCommand.CommandText = sSQL
                Me.mCommand.Parameters.Clear()
                Me.mCommand.CommandType = cmdType
                Dim Parm As SqlParameter
                For Each Parm In Parms
                    Me.mCommand.Parameters.Add(Parm)
                Next
                ExecQueryCmd = Me.mCommand.ExecuteReader
            Catch exception1 As Exception
                'ProjectData.SetProjectError(exception1)
                Dim ex As Exception = exception1
                Throw ex
            Finally
                Me.mConn.Close()
            End Try
            Return ExecQueryCmd
        End Function

        Public Function GetSQLAdapter(ByVal sSQL As String) As SqlDataAdapter
            Me.mCommand.CommandText = sSQL
            Return New SqlDataAdapter(Me.mCommand)
        End Function

        Public Function GetSQLAdapter(ByVal sSQL As String, ByVal Parms As SqlParameter()) As SqlDataAdapter
            Me.mCommand.CommandText = sSQL
            Me.mCommand.Parameters.Clear()
            Dim Parm As SqlParameter
            For Each Parm In Parms
                Me.mCommand.Parameters.Add(Parm)
            Next
            Return New SqlDataAdapter(Me.mCommand)
        End Function

        Public Function GetSQLAdapter(ByVal sSQL As String, ByVal cmdType As CommandType, ByVal ParamArray Parms As SqlParameter()) As SqlDataAdapter
            Me.mCommand.CommandText = sSQL
            Me.mCommand.CommandType = cmdType
            Me.mCommand.Parameters.Clear()
            Dim Parm As SqlParameter
            For Each Parm In Parms
                Me.mCommand.Parameters.Add(Parm)
            Next
            Return New SqlDataAdapter(Me.mCommand)
        End Function

        Public Function ExecQueryCmd(ByVal sSQL As String, ByVal Parms As SqlParameter()) As DataTable
            Dim dt As DataTable
            Try
                Me.mCommand.CommandText = sSQL
                Me.mCommand.Parameters.Clear()
                Dim Parm As SqlParameter
                For Each Parm In Parms
                    Me.mCommand.Parameters.Add(Parm)
                Next
                If Me.mConn.State <> ConnectionState.Open Then
                    Me.mConn.Open()
                End If
                dt = New DataTable()
                Dim adpter As SqlDataAdapter = New SqlDataAdapter(Me.mCommand)
                adpter.Fill(dt)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                Me.mConn.Close()
            End Try

            Return dt
        End Function

        Public Sub OpenConn()
            If (Me.mConn.State <> ConnectionState.Open) Then
                Me.mConn.Close()
            End If
            Me.mConn.Open()
        End Sub

        Public Sub RollbackTrain()
            Me.mTrans.Rollback()
        End Sub

    End Class
#End Region

#Region "SqlAccessHelper"

    Public NotInheritable Class SqlAccessHelper

#Region "private utility methods & constructors"

        '建構子
        Private Sub New()
        End Sub 'New

        '這個方法用來將SqlParameters陣列內的SqlParameter參數物件，附加到SqlCommand
        '參數說明：
        '-command：要被附加參數的SqlCommand
        '-commandParameters：要附加到SqlCommand的SqlParameters參數陣列
        Private Shared Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
            Dim p As SqlParameter
            For Each p In commandParameters
                command.Parameters.Add(p)
            Next p
        End Sub 'AttachParameters

        '這個方法會設定SqlCommand物件在執行時的所需設定相關東西例如：connection,transaction, command type and parameters 
        '呼叫它可以將SqlComman物件設定準備好，以便使用
        '參數說明：
        ' -command - 要設定的SqlCommand
        ' -connection - SqlConnection物件
        ' -transaction - SqlTransaction, or 'null'
        ' -commandType - CommandType (stored procedure, text, etc.)
        ' -commandText - 預存程序的名稱或T-SQL語法
        ' -commandParameters - 要指定要SqlComman的SqlParameters陣列，或沒有參數時傳入Nothing
        Private Shared Sub PrepareCommand(ByVal command As SqlCommand, _
                                          ByVal connection As SqlConnection, _
                                          ByVal transaction As SqlTransaction, _
                                          ByVal commandType As CommandType, _
                                          ByVal commandText As String, _
                                          ByVal commandParameters() As SqlParameter)
            If IsNothing(connection) Then
                connection = New SqlConnection(ConnectDB.GetDBString())
            End If
            '如果connection的狀態沒有開啟時，則開啟它
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            '指定command物件的Connection
            command.Connection = connection

            '設定command text (stored procedure name or SQL statement)
            command.CommandText = commandText

            '如果有提供transaction,則指定command物件的transaction
            If Not (transaction Is Nothing) Then
                command.Transaction = transaction
            End If

            '設定command type
            command.CommandType = commandType

            '附加SqlParameters陣列裡的參數到command物件
            If Not (commandParameters Is Nothing) Then
                AttachParameters(command, commandParameters)
            End If

            Return
        End Sub 'PrepareCommand

#End Region

#Region "ExecuteNonQuery"

        ' Execute a SqlCommand (that returns no resultset and takes no parameters) against the database specified in 
        ' the connection string. 
        ' e.g.:  
        '  Dim result as Integer =  ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders")
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' Returns: an int representing the number of rows affected by the command
        Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As Integer
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteNonQuery(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteNonQuery

        ' Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim result as Integer = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' -commandParameters - an array of SqlParamters used to execute the command
        ' Returns: an int representing the number of rows affected by the command
        Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                         ByVal commandType As CommandType, _
                                                         ByVal commandText As String, _
                                                         ByVal ParamArray commandParameters() As SqlParameter) As Integer
            'create & open a SqlConnection, and dispose of it after we are done.
            Dim cn As New SqlConnection(connectionString)
            Try
                cn.Open()

                'call the overload that takes a connection in place of the connection string
                Return ExecuteNonQuery(cn, commandType, commandText, commandParameters)
            Finally
                cn.Dispose()
            End Try
        End Function 'ExecuteNonQuery

        ' Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlConnection. 
        ' e.g.:  
        ' Dim result as Integer = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders")
        ' Parameters:
        ' -connection - a valid SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command 
        ' ##Returns: an int representing the number of rows affected by the command
        Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                         ByVal commandType As CommandType, _
                                                         ByVal commandText As String) As Integer
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteNonQuery(connection, commandType, commandText, CType(Nothing, SqlParameter()))

        End Function 'ExecuteNonQuery

        ' Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
        ' using the provided parameters.
        ' e.g.:  
        '  Dim result as Integer = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -connection - a valid SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: an int representing the number of rows affected by the command (受影響的資料列筆數)
        Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                         ByVal commandType As CommandType, _
                                                         ByVal commandText As String, _
                                                         ByVal ParamArray commandParameters() As SqlParameter) As Integer

            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim retval As Integer

            '將所有的SQL的訊息，記錄在RecordSelect裡
            RecordSQL(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

            PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

            'finally, execute the command.
            retval = cmd.ExecuteNonQuery()

            'detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            Return retval

        End Function 'ExecuteNonQuery

        ' Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlTransaction.
        ' e.g.:  
        '  Dim result as Integer = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders")
        ' Parameters:
        ' -transaction - a valid SqlTransaction associated with the connection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: an int representing the number of rows affected by the command 
        Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                         ByVal commandType As CommandType, _
                                                         ByVal commandText As String) As Integer
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteNonQuery(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteNonQuery

        ' Execute a SqlCommand (that returns no resultset) against the specified SqlTransaction
        ' using the provided parameters.
        ' e.g.:  
        ' Dim result as Integer = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -transaction - a valid SqlTransaction 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: an int representing the number of rows affected by the command 
        Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                         ByVal commandType As CommandType, _
                                                         ByVal commandText As String, _
                                                         ByVal ParamArray commandParameters() As SqlParameter) As Integer
            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim retval As Integer

            '將所有的SQL的訊息，記錄在RecordSelect裡
            RecordSQL(cmd, CType(Nothing, SqlConnection), transaction, commandType, commandText, commandParameters)

            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

            'finally, execute the command.
            retval = cmd.ExecuteNonQuery()

            'detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            Return retval

        End Function 'ExecuteNonQuery

#End Region

#Region "ExecuteDataset"

        ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
        ' the connection string. 
        ' e.g.:  
        ' Dim ds As DataSet = SqlHelper.ExecuteDataset("", commandType.StoredProcedure, "GetOrders")
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' Returns: a dataset containing the resultset generated by the command
        Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String) As DataSet
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteDataset(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteDataset

        ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim ds as Dataset = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' -commandParameters - an array of SqlParamters used to execute the command
        ' Returns: a dataset containing the resultset generated by the command
        Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String, _
                                                        ByVal ParamArray commandParameters() As SqlParameter) As DataSet
            'create & open a SqlConnection, and dispose of it after we are done.
            Dim cn As New SqlConnection(connectionString)
            Try
                cn.Open()

                'call the overload that takes a connection in place of the connection string
                Return ExecuteDataset(cn, commandType, commandText, commandParameters)
            Finally
                cn.Close()
                cn.Dispose()
            End Try
        End Function 'ExecuteDataset

        ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
        ' e.g.:  
        ' Dim ds as Dataset = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders")
        ' Parameters:
        ' -connection - a valid SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' Returns: a dataset containing the resultset generated by the command
        Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String) As DataSet

            'pass through the call providing null for the set of SqlParameters
            Return ExecuteDataset(connection, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteDataset

        ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim ds as Dataset = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -connection - a valid SqlConnection
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' -commandParameters - an array of SqlParamters used to execute the command
        ' ##@Returns: a dataset containing the resultset generated by the command
        Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String, _
                                                        ByVal ParamArray commandParameters() As SqlParameter) As DataSet



            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            Dim da As SqlDataAdapter

            ''連線逾時時間，設定為120秒
            cmd.CommandTimeout = "120"


            '將所有的SQL的訊息，記錄在RecordSelect裡
            RecordSQL(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)
            PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

            'create the DataAdapter & DataSet
            da = New SqlDataAdapter(cmd)

            'fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds)

            'detach the SqlParameters from the command object, so they can be used again
            da.Dispose()
            cmd.Parameters.Clear()
            '如果connection的狀態開啟時，則將連線關閉
            If connection.State = ConnectionState.Open Then
                connection.Close()
                ' connection.Dispose()
            End If


            'return the dataset
            Return ds

        End Function 'ExecuteDataset

        ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
        ' e.g.:  
        ' Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders")
        ' Parameters
        ' -transaction - a valid SqlTransaction
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' Returns: a dataset containing the resultset generated by the command
        Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String) As DataSet
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteDataset(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteDataset

        ' Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
        ' using the provided parameters.
        ' e.g.:  
        ' Dim ds As Dataset = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters
        ' -transaction - a valid SqlTransaction 
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command
        ' -commandParameters - an array of SqlParamters used to execute the command
        ' Returns: a dataset containing the resultset generated by the command
        Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String, _
                                                        ByVal ParamArray commandParameters() As SqlParameter) As DataSet
            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            Dim da As SqlDataAdapter


            '將所有的SQL的訊息，記錄在RecordSelect裡
            RecordSQL(cmd, CType(Nothing, SqlConnection), transaction, commandType, commandText, commandParameters)

            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

            'create the DataAdapter & DataSet
            da = New SqlDataAdapter(cmd)

            'fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds)

            'detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            'return the dataset
            Return ds
        End Function 'ExecuteDataset

#End Region

#Region "ExecuteReader"
        ' this enum is used to indicate whether the connection was provided by the caller, or created by SqlHelper, so that
        ' we can set the appropriate CommandBehavior when calling ExecuteReader()
        Private Enum SqlConnectionOwnership
            'Connection is owned and managed by SqlHelper
            Internal
            'Connection is owned and managed by the caller
            [External]
        End Enum 'SqlConnectionOwnership

        ' Create and prepare a SqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
        ' If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
        ' If the caller provided the connection, we want to leave it to them to manage.
        ' Parameters:
        ' -connection - a valid SqlConnection, on which to execute this command 
        ' -transaction - a valid SqlTransaction, or 'null' 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParameters to be associated with the command or 'null' if no parameters are required 
        ' -connectionOwnership - indicates whether the connection parameter was provided by the caller, or created by SqlHelper 
        ' Returns: SqlDataReader containing the results of the command 
        Private Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                        ByVal transaction As SqlTransaction, _
                                                        ByVal commandType As CommandType, _
                                                        ByVal commandText As String, _
                                                        ByVal commandParameters() As SqlParameter, _
                                                        ByVal connectionOwnership As SqlConnectionOwnership) As SqlDataReader
            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            'create a reader
            Dim dr As SqlDataReader

            '將所有的SQL的訊息，記錄在RecordSelect裡
            'RecordSQL(cmd, connection, transaction, commandType, commandText, commandParameters)

            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters)

            '若為External，表示是直接傳入Connection物件，則使用完不要自動關閉，因為外部可能還要用到
            '若為Internal，表示是傳入ConnectionString，再建立Connection，則使用完要自動關閉

            '如果為External(外部)，則執行完ExecuteReader不自動關閉Connection
            If connectionOwnership = SqlConnectionOwnership.External Then
                dr = cmd.ExecuteReader()
            Else '若為Internal(內部)，則執行完ExecuteReader要自動關閉Connection
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            End If

            'detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            Return dr
        End Function 'ExecuteReader

        ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
        ' the connection string. 
        ' e.g.:  
        ' Dim dr As SqlDataReader = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders")
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: a SqlDataReader containing the resultset generated by the command 
        Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As SqlDataReader
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteReader(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteReader

        ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim dr As SqlDataReader = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: a SqlDataReader containing the resultset generated by the command 
        Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String, _
                                                       ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
            'create & open a SqlConnection
            Dim cn As New SqlConnection(connectionString)
            cn.Open()

            Try
                'call the private overload that takes an internally owned connection in place of the connection string
                Return ExecuteReader(cn, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.Internal)
            Catch
                'if we fail to return the SqlDatReader, we need to close the connection ourselves

                cn.Dispose()
            End Try
        End Function 'ExecuteReader


        ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
        ' e.g.:  
        ' Dim dr As SqlDataReader = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders")
        ' Parameters:
        ' -connection - a valid SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: a SqlDataReader containing the resultset generated by the command 
        Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As SqlDataReader

            Return ExecuteReader(connection, commandType, commandText, CType(Nothing, SqlParameter()))

        End Function 'ExecuteReader

        ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim dr As SqlDataReader = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -connection - a valid SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: a SqlDataReader containing the resultset generated by the command 
        Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String, _
                                                       ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
            'pass through the call to private overload using a null transaction value
            Return ExecuteReader(connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.External)

        End Function 'ExecuteReader

        ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction.
        ' e.g.:  
        ' Dim dr As SqlDataReader = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders")
        ' Parameters:
        ' -transaction - a valid SqlTransaction  
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: a SqlDataReader containing the resultset generated by the command 
        Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As SqlDataReader
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteReader(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteReader

        ' Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
        ' using the provided parameters.
        ' e.g.:  
        ' Dim dr As SqlDataReader = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
        ' Parameters:
        ' -transaction - a valid SqlTransaction 
        ' -commandType - the CommandType (stored procedure, text, etc.)
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: a SqlDataReader containing the resultset generated by the command 
        Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String, _
                                                       ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
            'pass through to private overload, indicating that the connection is owned by the caller
            Return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External)
        End Function 'ExecuteReader

#End Region

#Region "ExecuteScalar"

        ' Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
        ' the connection string. 
        ' e.g.:  
        ' Dim orderCount As Integer = CInt(ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount"))
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: an object containing the value in the 1x1 resultset generated by the command
        Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As Object
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteScalar(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteScalar

        ' Execute a SqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim orderCount As Integer = Cint(ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
        ' Parameters:
        ' -connectionString - a valid connection string for a SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: an object containing the value in the 1x1 resultset generated by the command 
        Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String, _
                                                       ByVal ParamArray commandParameters() As SqlParameter) As Object
            'create & open a SqlConnection, and dispose of it after we are done.
            Dim cn As New SqlConnection(connectionString)
            Try
                cn.Open()

                'call the overload that takes a connection in place of the connection string
                Return ExecuteScalar(cn, commandType, commandText, commandParameters)
            Finally
                cn.Dispose()
            End Try
        End Function 'ExecuteScalar

        ' Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlConnection. 
        ' e.g.:  
        ' Dim orderCount As Integer = CInt(ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount"))
        ' Parameters:
        ' -connection - a valid SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: an object containing the value in the 1x1 resultset generated by the command 
        Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As Object
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteScalar(connection, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteScalar

        ' Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
        ' using the provided parameters.
        ' e.g.:  
        ' Dim orderCount As Integer = CInt(ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
        ' Parameters:
        ' -connection - a valid SqlConnection 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: an object containing the value in the 1x1 resultset generated by the command 
        Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String, _
                                                       ByVal ParamArray commandParameters() As SqlParameter) As Object
            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim retval As Object

            '將所有的SQL的訊息，記錄在RecordSelect裡
            RecordSQL(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

            PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

            'execute the command & return the results
            retval = cmd.ExecuteScalar()

            'detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()


            Return retval

        End Function 'ExecuteScalar

        ' Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlTransaction.
        ' e.g.:  
        ' Dim orderCount As Integer  = CInt(ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount"))
        ' Parameters:
        ' -transaction - a valid SqlTransaction 
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' Returns: an object containing the value in the 1x1 resultset generated by the command 
        Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String) As Object
            'pass through the call providing null for the set of SqlParameters
            Return ExecuteScalar(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
        End Function 'ExecuteScalar

        ' Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction
        ' using the provided parameters.
        ' e.g.:  
        ' Dim orderCount As Integer = CInt(ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24)))
        ' Parameters:
        ' -transaction - a valid SqlTransaction  
        ' -commandType - the CommandType (stored procedure, text, etc.) 
        ' -commandText - the stored procedure name or T-SQL command 
        ' -commandParameters - an array of SqlParamters used to execute the command 
        ' Returns: an object containing the value in the 1x1 resultset generated by the command 
        Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                       ByVal commandType As CommandType, _
                                                       ByVal commandText As String, _
                                                       ByVal ParamArray commandParameters() As SqlParameter) As Object
            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim retval As Object

            '將所有的SQL的訊息，記錄在RecordSelect裡
            RecordSQL(cmd, CType(Nothing, SqlConnection), transaction, commandType, commandText, commandParameters)

            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

            'execute the command & return the results
            retval = cmd.ExecuteScalar()

            'detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()


            Return retval

        End Function 'ExecuteScalar

#End Region

#Region "ExecDatasetInsideMuiltTable"
        Public Overloads Shared Function ExecDatasetInsideMuiltTable(ByVal transaction As SqlTransaction, _
                                                           ByVal commandType As CommandType, _
                                                           ByVal commandText() As String, _
                                                           ByVal TableName() As String, _
                                                           ByVal ParamArray commandParameters() As SqlParameter) As DataSet
            'PORIN更改，日期:02007-8-20
            ' commandText =>所執行 預存程序的名稱
            ' select出來的table，放在同一個dataSet時，所預設的table名稱

            'create a command and prepare it for execution
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            Dim da As SqlDataAdapter

            For i As Integer = 0 To commandText.Length - 1

                '將所有的SQL的訊息，記錄在RecordSelect裡
                'RecordSQL(cmd, CType(Nothing, SqlConnection), transaction, commandType, commandText(i), commandParameters)

                PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText(i), commandParameters)

                'create the DataAdapter & DataSet
                da = New SqlDataAdapter(cmd)

                'fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds, TableName(i))
                cmd.Parameters.Clear()
            Next

            'detach the SqlParameters from the command object, so they can be used again
            da.Dispose()
            '如果connection的狀態開啟時，則將連線關閉

            'return the dataset
            Return ds

        End Function 'ExecuteDataset
#End Region

#Region "將所有的SQL的訊息，記錄在RecordSelect裡"
        Public Shared Sub RecordSQL(ByVal command As SqlCommand, _
                                       ByVal connection As SqlConnection, _
                                       ByVal transaction As SqlTransaction, _
                                       ByVal commandType As CommandType, _
                                       ByVal commandText As String, _
                                       ByVal ParamArray commandParameters() As SqlParameter)
            Try

                If HttpContext.Current.User.Identity.IsAuthenticated Then '若使用者有成功登入系統，則開始記錄查詢的SQL訊息 

                    Dim strNotes As New StringBuilder '記錄執行的sql語法
                    '串出sql的查詢語法
                    If Not (commandParameters Is Nothing) Then
                        If commandParameters.Length >= 1 Then
                            For i As Integer = 0 To commandParameters.Length - 1
                                Select Case commandParameters(i).SqlDbType
                                    Case SqlDbType.NChar, SqlDbType.NText, SqlDbType.NVarChar
                                        strNotes.Append("," & commandParameters(i).ToString & "=N'" & Convert.ToString(commandParameters(i).Value).Replace("'", "''") & "'")
                                    Case SqlDbType.BigInt, SqlDbType.Int, SqlDbType.SmallInt, SqlDbType.Binary
                                        strNotes.Append("," & commandParameters(i).ToString & "=" & Convert.ToString(commandParameters(i).Value).Replace("'", "''") & "")
                                    Case Else
                                        strNotes.Append("," & commandParameters(i).ToString & "='" & Convert.ToString(commandParameters(i).Value).Replace("'", "''") & "'")
                                End Select
                            Next
                        End If
                    End If

                    Dim TmpStr As New StringBuilder
                    Select Case commandType
                        Case commandType.StoredProcedure
                            If strNotes.Length > 0 Then
                                TmpStr.Append(Right(strNotes.ToString, strNotes.ToString.Length - 1))
                            Else
                                TmpStr.Append("")
                            End If
                            strNotes.Remove(0, strNotes.Length)
                            strNotes.Append("exec " & Convert.ToString(commandText) & " " & TmpStr.ToString)

                        Case commandType.Text
                            TmpStr.Append(strNotes.ToString)
                            strNotes.Remove(0, strNotes.Length)
                            strNotes.Append("exec sp_executesql N'" & Convert.ToString(commandText).Replace("'", "''") & "'" & TmpStr.ToString)
                    End Select

                    'strNotes = Left(strNotes, 4000) '只取4000個字
                    If strNotes.Length > 0 Then
                        If connection IsNot Nothing Then
                            '如果connection的狀態沒有開啟時，則開啟它
                            If connection.State <> ConnectionState.Open Then
                                connection.Open()
                            End If

                            '指定command物件的Connection
                            command.Connection = connection
                        ElseIf transaction IsNot Nothing Then
                            connection = transaction.Connection
                            '如果connection的狀態沒有開啟時，則開啟它
                            If connection.State <> ConnectionState.Open Then
                                connection.Open()
                            End If

                            '指定command物件的Connection
                            command.Connection = transaction.Connection
                        End If


                        '設定command text (stored procedure name or SQL statement)
                        command.CommandText = commandText

                        '如果有提供transaction,則指定command物件的transaction
                        If Not (transaction Is Nothing) Then
                            command.Transaction = transaction
                        End If

                        '設定command text
                        '將select的訊息，記錄在RecordSelect裡
                        command.CommandText = "INSERT INTO SYS_RecordSQL (Account, Notes,Mod_date,URL) VALUES  (@Account, @Notes,'" & Now.ToString("yyyyMMddhhmmss") & "',@URL)"

                        '設定command type
                        command.CommandType = Data.CommandType.Text

                        '附加SqlParameters陣列裡的參數到command物件
                        command.Parameters.Add("@Account", SqlDbType.NVarChar)
                        command.Parameters.Add("@Notes", SqlDbType.NText)
                        command.Parameters.Add("@URL", SqlDbType.NVarChar)
                        Dim account As String = ""
                        Try
                            account = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                        Catch ex As Exception

                        End Try
                        command.Parameters.Item("@Account").Value = account
                        command.Parameters.Item("@Notes").Value = strNotes.ToString
                        command.Parameters.Item("@URL").Value = HttpContext.Current.Request.CurrentExecutionFilePath

                        'command.ExecuteNonQuery()
                        command.Parameters.Clear()


                    End If

                End If
            Catch ex As Exception

            End Try
        End Sub
#End Region

    End Class
#End Region

End Namespace
