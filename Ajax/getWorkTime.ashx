<%@ WebHandler Language="VB" Class="getWorkTime" %>

Imports System
Imports System.Web

Public Class getWorkTime : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
                
        Dim curdate As String = context.Request.QueryString("curdate")
        Dim idcard As String = context.Request.QueryString("idcard")

        curdate = curdate.Replace("/", "")

        Dim ht As Hashtable = FSC.Logic.Content.getWorkTime(idcard, curdate)
        If ht IsNot Nothing Then
            context.Response.Write(ht.Item("WORKTIMEB").ToString() & "," & ht.Item("WORKTIMEE").ToString())
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class