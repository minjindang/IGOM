Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Newtonsoft.Json

Namespace FSC.Logic
    Public Class MemberDAO
        Dim memberService As EmpMemberService.EmpMemberSoapClient

        Public Sub New()
            memberService = New EmpMemberService.EmpMemberSoapClient()
        End Sub

        Public Function GetDataByIdCard(ByVal idCard As String) As DataTable
            Dim json As String = memberService.GetMemberByIdCard(idCard)
            Dim ds As DataSet = JsonConvert.DeserializeObject(Of DataSet)(json)
            Return ds.Tables(0)
        End Function

        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim json As String = memberService.GetMember(orgcode, departId)
            Dim ds As DataSet = JsonConvert.DeserializeObject(Of DataSet)(json)
            Return ds.Tables(0)
        End Function

    End Class

End Namespace