Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports Newtonsoft.Json

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://IGOM.Emp.Member/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class EmpMember
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetMember(ByVal orgcode As String, ByVal departId As String) As String
        'Dim xml As New StringBuilder()
        Dim mem As New EMP.Logic.Member()
        Dim dt As DataTable = mem.GetDataByOrgDep(orgcode, departId, 2)
        Dim ds As DataSet = dt.DataSet()
        Dim json As String = JsonConvert.SerializeObject(ds, Formatting.Indented)
        Return json
    End Function

    <WebMethod()> _
    Public Function GetMemberByIdCard(ByVal idCard As String) As String
        Dim xml As New StringBuilder()
        Dim mem As New EMP.Logic.Member()
        Dim dt As DataTable = mem.GetDataByIdCard(idCard)
        Dim ds As DataSet = dt.DataSet()
        Dim json As String = JsonConvert.SerializeObject(ds, Formatting.Indented)
        Return json
    End Function

End Class