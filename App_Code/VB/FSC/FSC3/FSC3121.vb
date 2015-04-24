Imports Microsoft.VisualBasic
Imports System.Data
Imports FSC.Logic

Namespace SAL.Logic
    Public Class FSC3121
        Dim DAO As FSC3121DAO

        Public Sub New()
            DAO = New FSC3121DAO()
        End Sub

        Public Function GetDepart(orgcode As String) As DataTable
            Return DAO.GetDepart(orgcode)
        End Function


        Public Function GetData(orgcode As String, Depart_id As String, Id_card As String, yyy As String, Employee_type As String) As DataTable
            Dim rdt As New DataTable
            rdt.Columns.Add("yyy")
            rdt.Columns.Add("Orgcode")
            rdt.Columns.Add("Depart_name")
            rdt.Columns.Add("User_name")
            rdt.Columns.Add("Id_card")
            rdt.Columns.Add("Holidays")
            rdt.Columns.Add("Must_days")
            rdt.Columns.Add("Leave_days")
            rdt.Columns.Add("Left_days")

            rdt.Columns.Add("Inter_days")
            rdt.Columns.Add("Inter_days_card")
            rdt.Columns.Add("Outer_days")
            rdt.Columns.Add("Pay_days")
            rdt.Columns.Add("Total_fee")

            Dim fee As Integer = 0
            Dim must_days As Integer = 0
            Dim code As New FSCPLM.Logic.SACode()

            Dim dr1 As DataRow = code.GetRow("023", "**", "034")
            Dim dr2 As DataRow = code.GetRow("023", "**", "035")
            If dr1 IsNot Nothing Then
                fee = CommonFun.getInt(dr1("code_desc2").ToString())
            End If
            If dr2 IsNot Nothing Then
                must_days = CommonFun.getInt(dr2("code_desc2").ToString())
            End If
            Dim must_hours As Integer = must_days * 8

            Dim pdt As DataTable = DAO.GetPersonelData(Depart_id, Employee_type)

            For Each pdr As DataRow In pdt.Rows
                Id_card = pdr("Id_card").ToString()

                Dim dt As DataTable = DAO.GetData(orgcode, Id_card, yyy)
                Dim Inter_hours As Integer = 0
                Dim Inter_hours_card As Integer = 0
                Dim Outer_hours As Integer = 0
                Dim Pay_hours As Integer = 0
                Dim pay_days As Double = 0


                Dim drs() As DataRow = dt.Select("Location_flag='0'")
                For Each dr As DataRow In drs
                    Inter_hours += CommonFun.ConvertToInt(dr("Leave_hours").ToString())
                    If dr("Inter_travel_flag").ToString() = "1" Then
                        Inter_hours_card += CommonFun.ConvertToInt(dr("Leave_hours").ToString())
                    End If
                Next
                Dim drs2() As DataRow = dt.Select("Location_flag='1'")
                For Each dr As DataRow In drs2
                    Outer_hours += CommonFun.ConvertToInt(dr("Leave_hours").ToString())
                Next

                Dim x As Integer = must_hours - Inter_hours_card - Outer_hours
                x = IIf(x < 0, 0, x)
                Pay_hours = Inter_hours - Inter_hours_card - x
                Pay_hours = IIf(Pay_hours < 0, 0, Pay_hours)

                If Pay_hours <= 0 Then
                    Continue For
                End If

                pay_days = Content.ConvertDayHours(Pay_hours)

                Dim rdr As DataRow = rdt.NewRow()
                rdr("yyy") = yyy
                rdr("Orgcode") = orgcode
                rdr("Depart_name") = New Org().GetDepartName(orgcode, Depart_id)
                rdr("User_name") = pdr("User_name").ToString()
                rdr("Id_card") = Id_card
                rdr("Holidays") = pdr("Pehday").ToString()
                rdr("Must_days") = 14
                rdr("Leave_days") = Content.ConvertDayHours(Inter_hours + Outer_hours)
                rdr("Left_days") = Content.ConvertDayHours(Content.ConvertToHours(pdr("Pehday").ToString()) - (Inter_hours + Outer_hours))

                rdr("Inter_days") = Content.ConvertDayHours(Inter_hours)
                rdr("Inter_days_card") = Content.ConvertDayHours(Inter_hours_card)
                rdr("Outer_days") = Content.ConvertDayHours(Outer_hours)
                rdr("Pay_days") = pay_days

                Dim Total_fee As Integer = Fix(pay_days) * fee
                If FormatNumber(pay_days - Fix(pay_days), 1) > 0 Then
                    Total_fee += (fee / 2)
                End If

                rdr("Total_fee") = Total_fee

                rdt.Rows.Add(rdr)
            Next

            Return rdt
        End Function

    End Class
End Namespace
