Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC3107
        Private DAO As FSC3107DAO

        Public Sub New()
            DAO = New FSC3107DAO()
        End Sub


        Function GetSettlementAnnual(ByVal Orgcode As String, ByVal DepartID As String, ByVal employeeType As String, ByVal Year As String) As DataTable
            Return DAO.GetSettlementAnnual(Orgcode, DepartID, employeeType, Year)
        End Function

        Public Function GetMustHours() As Integer
            Dim mustDays As Integer = 0
            Dim code As New FSCPLM.Logic.SACode()
            Dim dr1 As DataRow = code.GetRow("023", "**", "035")
            If dr1 IsNot Nothing Then
                mustDays = CommonFun.getInt(dr1("code_desc2").ToString())
            End If
            Dim mustHours As Integer = mustDays * 8
            Return mustHours
        End Function

        Public Function GetData(orgcode As String, Depart_id As String, employeeType As String, yyy As String) As DataTable
            Dim rdt As New DataTable
            rdt.Columns.Add("yyy")
            rdt.Columns.Add("Orgcode")
            rdt.Columns.Add("Depart_id")
            rdt.Columns.Add("Depart_name")
            rdt.Columns.Add("User_name")
            rdt.Columns.Add("Id_card")
            rdt.Columns.Add("Holidays")
            rdt.Columns.Add("Leave_days")
            rdt.Columns.Add("Can_pay_days")

            Dim mustHours As Integer = GetMustHours()
            Dim pdt As DataTable = DAO.GetUnApplyData(orgcode, Depart_id, employeeType, yyy)

            For Each pdr As DataRow In pdt.Rows
                Dim Id_card As String = pdr("Id_card").ToString()
                Dim leaveHours As Integer = pdr("Leave_hours").ToString()
                Dim usablePayHours As Integer = 0
                Dim annualHours As Integer = Content.ConvertToHours(pdr("PEHDAY").ToString())

                If leaveHours > mustHours Then
                    usablePayHours = annualHours - leaveHours
                Else
                    usablePayHours = annualHours - mustHours
                End If
                usablePayHours = IIf(usablePayHours < 0, 0, usablePayHours)


                Dim rdr As DataRow = rdt.NewRow()
                rdr("yyy") = yyy
                rdr("Orgcode") = orgcode
                rdr("Depart_id") = pdr("Depart_id").ToString()
                rdr("Depart_name") = New Org().GetDepartName(orgcode, pdr("Depart_id").ToString())
                rdr("User_name") = pdr("User_name").ToString()
                rdr("Id_card") = Id_card
                rdr("Holidays") = pdr("PEHDAY").ToString()
                rdr("Leave_days") = Content.ConvertDayHours(leaveHours)
                rdr("Can_pay_days") = Content.ConvertDayHours(usablePayHours)

                rdt.Rows.Add(rdr)
            Next

            Return rdt
        End Function
    End Class
End Namespace

