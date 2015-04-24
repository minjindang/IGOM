Imports Microsoft.VisualBasic
Imports Quartz
Imports Quartz.Impl
Imports NLog
Imports System.Net
Imports System.Xml

Public Class SchedulerTrigger

    Public Shared Sub Run()

        Dim assemblyName As String = System.Reflection.Assembly.Load("App_SubCode_VB").GetName().ToString().Split(",")(0)
        Dim xmldoc As New System.Xml.XmlDocument()
        Dim realPath As String = HttpRuntime.AppDomainAppPath
        Dim folder As New System.IO.DirectoryInfo(realPath)
        xmldoc.Load(folder.FullName & "/quartz_jobs.xml")
        Dim nodeList As XmlNodeList = xmldoc.GetElementsByTagName("job")
        For Each node As XmlNode In nodeList
            Dim vs() As String = node.Item("job-type").InnerText.Split(",")
            node.Item("job-type").InnerText = vs(0) & ", " & assemblyName
        Next
        xmldoc.Save(folder.FullName & "/quartz_jobs.xml")

        Dim sf As ISchedulerFactory = New StdSchedulerFactory()
        Dim sched As IScheduler = sf.GetScheduler()
        sched.Start()
    End Sub

End Class
