Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class LeaveKindDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()

        End Sub

        Public Sub New(ByVal connstr As String)
            MyBase.New(connstr)
        End Sub

        Public Function DeleteById(ByVal id As String) As Integer
            Dim params() As SqlParameter = {New SqlParameter("@id", id)}
            Return Execute("delete from SYS_Leave_kind where id=@id", params)
        End Function
    End Class
End Namespace
