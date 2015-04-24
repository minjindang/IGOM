Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2102
        Private DAO As FSC2102DAO

        Public Sub New()
            DAO = New FSC2102DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Apply_name As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal Start_date As String, _
                                     ByVal End_date As String, _
                                     ByVal Quit_job_flag As String, _
                                     ByVal PESEX As String, _
                                     ByVal Employee_type As String, _
                                     ByVal type As String) As DataTable
            Dim yyymm As String = ""
            Dim rdt As New DataTable()

            If Mid(Start_date, 1, 5) = Mid(End_date, 1, 5) Then
                yyymm = Mid(Start_date, 1, 5)
                Return DAO.getQueryData(orgcode, Depart_id, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, yyymm, type)
            Else
                Dim DateS As String = Start_date.Substring(0, 3) + "/" + Start_date.Substring(3, 2) + "/" + "01"
                Dim DateE As String = End_date.Substring(0, 3) + "/" + End_date.Substring(3, 2) + "/" + "01"

                Dim S As Date = Date.Parse(DateS)
                Dim E As Date = Date.Parse(DateE)

                rdt = DAO.getQueryData(orgcode, Depart_id, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, S.Year.ToString() + S.Month.ToString().PadLeft(2, "0"), type)
                While S < E
                    S = S.AddMonths(1)
                    Dim tmpdt As DataTable = DAO.getQueryData(orgcode, Depart_id, Apply_name, Apply_idcard, Start_date, End_date, Quit_job_flag, PESEX, Employee_type, S.Year.ToString() + S.Month.ToString().PadLeft(2, "0"), type)
                    rdt.Merge(tmpdt)
                End While
            End If

            Return rdt

        End Function

        Public Function getQueryData2(ByVal Apply_idcard As String, _
                                      ByVal PKWDATE As String) As DataTable
            Return DAO.getQueryData2(LoginManager.OrgCode, Apply_idcard, PKWDATE)
        End Function

        Public Function getQueryData2(ByVal Orgcode As String, _
                                      ByVal Apply_idcard As String, _
                                      ByVal PKWDATE As String) As DataTable
            Return DAO.getQueryData2(Orgcode, Apply_idcard, PKWDATE)
        End Function
    End Class
End Namespace