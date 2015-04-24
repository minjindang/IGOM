Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web
Imports System.Transactions


Namespace FSCPLM.Logic
    Public Class CarDispatchMain

        Public DAO As CarDispatchMainDAO

        Public Sub New()
            DAO = New CarDispatchMainDAO()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            DAO = New CarDispatchMainDAO(conn)
        End Sub

        Public Function GetData(ByVal OrgCode As String, ByVal Start_date As String) As DataTable
            Return DAO.GetData(OrgCode, Start_date)
        End Function

        Public Function GetDataByFlowId(orgcode As String, flowId As String) As DataTable
            Return DAO.GetDataByFlowId(orgcode, flowId)
        End Function

        Public Sub Insert(ByVal Car_type As String, ByVal Car_name As String, ByVal Passenger_cnt As Integer, _
                          ByVal Start_date As String, ByVal End_date As String, ByVal Start_time As String, ByVal End_time As String, ByVal Departure_time As String, _
                          ByVal Reason_desc As String, ByVal Use_type As String, ByVal Urgent_type As String, ByVal Unit_code As String, _
                          ByVal Phone_nos As String, ByVal Destination_desc As String, ByVal Location As String)
            Dim flowID As String = String.Empty
            Using trans As New TransactionScope
                Dim f As New SYS.Logic.Flow()
                f.Orgcode = LoginManager.OrgCode
                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                f.FormId = "003006"
                f.FlowId = New SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId)
                SYS.Logic.CommonFlow.AddFlow(f)

                flowID = f.FlowId
                DAO.Insert(LoginManager.OrgCode, flowID, Car_type, Car_name, Passenger_cnt, _
                      Start_date, End_date, Start_time, End_time, Departure_time, _
                      Reason_desc, Use_type, Urgent_type, Unit_code, LoginManager.OrgCode, _
                      Phone_nos, Destination_desc, LoginManager.OrgCode, Now, Location)

                trans.Complete()
            End Using

        End Sub

    End Class
End Namespace

