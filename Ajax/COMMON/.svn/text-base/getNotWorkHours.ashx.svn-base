<%@ WebHandler Language="VB" Class="getNotWorkHours" %>

Imports System
Imports System.Web

Public Class getNotWorkHours : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Dim dateb As String = context.Request.QueryString("dateb")
        Dim datee As String = context.Request.QueryString("datee")
        Dim timeb As String = context.Request.QueryString("timeb")
        Dim timee As String = context.Request.QueryString("timee")
        Dim idcard As String = context.Request.QueryString("idcard")

        dateb = dateb.Replace("/", "")
        datee = datee.Replace("/", "")

        Dim hours As String = FSC.Logic.Content.computeNotWorkHour(dateb, datee, timeb, timee, idcard)
        context.Response.Write(hours)
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class