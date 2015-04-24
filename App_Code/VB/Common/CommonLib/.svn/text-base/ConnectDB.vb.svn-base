Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System

Public Class ConnectDB

    Public Shared Function GetDBString() As String
        Return ConfigurationManager.ConnectionStrings("salaryConnectionString").ToString()
    End Function

    Public Shared Function GetMeggiDBString() As String
        Return ConfigurationManager.ConnectionStrings("meggiConnectionString").ToString()
    End Function

    Public Shared Function GetDianaDBString() As String
        Return ConfigurationManager.ConnectionStrings("dianaConnectionString").ToString()
    End Function
End Class
