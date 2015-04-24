Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class ScheduleSetting

#Region "property"
        Private _id As Integer
        Private _Orgcode As String
        Private _Depart_id As String
        Private _Sub_depart_id As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _User_name As String
        Private _Sche_date As String
        Private _Sche_type As String
        Private _Schedule_id As String
        Private _Change_userid As String
        Private _Change_date As Date = Now
        Public Property id() As Integer
            Get
                Return Me._id
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Orgcode, value) = False) Then
                    Me._id = value
                End If
            End Set
        End Property
        Public Property Orgcode() As String
            Get
                Return Me._Orgcode
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Orgcode, value) = False) Then
                    Me._Orgcode = value
                End If
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return Me._Depart_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Depart_id, value) = False) Then
                    Me._Depart_id = value
                End If
            End Set
        End Property
        Public Property Id_card() As String
            Get
                Return Me._Id_card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Id_card, value) = False) Then
                    Me._Id_card = value
                End If
            End Set
        End Property
        Property User_name() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property
        Property Sche_date() As String
            Get
                Return _Sche_date
            End Get
            Set(ByVal value As String)
                _Sche_date = value
            End Set
        End Property
        Property Sche_type() As String
            Get
                Return _Sche_type
            End Get
            Set(ByVal value As String)
                _Sche_type = value
            End Set
        End Property
        Property Schedule_id() As String
            Get
                Return _Schedule_id
            End Get
            Set(ByVal value As String)
                _Schedule_id = value
            End Set
        End Property
        Private _schedule_hours As Integer
        Public Property Schedule_hours() As String
            Get
                Return _schedule_hours
            End Get
            Set(ByVal value As String)
                _schedule_hours = value
            End Set
        End Property
        Private _pay_hours As Integer
        Public Property Pay_hours() As Integer
            Get
                Return _pay_hours
            End Get
            Set(ByVal value As Integer)
                _pay_hours = value
            End Set
        End Property
        Private _rest_hours As Integer
        Public Property Rest_hours() As Integer
            Get
                Return _rest_hours
            End Get
            Set(ByVal value As Integer)
                _rest_hours = value
            End Set
        End Property
        Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Private DAO As ScheduleSettingDAO

        Public Sub New()
            DAO = New ScheduleSettingDAO()
        End Sub

        Public Function GetData(ByVal orgcode As String, ByVal id_card As String, ByVal sche_date As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Id_card", id_card)
            d.Add("Sche_date", sche_date)
            Return DAO.GetDataByExample("FSC_Schedule_setting", d)
        End Function

        Public Function GetDataByid(ByVal id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.GetDataByExample("FSC_Schedule_setting", d)
        End Function

        Public Function GetDataByQuery(ByVal orgcode As String, ByVal id_card As String, ByVal sche_date As String) As DataTable
            Return DAO.getDataByQuery(orgcode, id_card, sche_date)
        End Function


        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Me.Orgcode)
            d.Add("Depart_id", Me.Depart_id)
            d.Add("Id_card", Me.Id_card)
            d.Add("User_name", Me.User_name)
            d.Add("Sche_date", Me.Sche_date)
            d.Add("Sche_type", Me.Sche_type)
            d.Add("Schedule_id", Me.Schedule_id)
            d.Add("Schedule_hours", Me.Schedule_hours)
            d.Add("Change_userid", Me.Change_userid)
            d.Add("Change_date", Me.Change_date)
            Return DAO.InsertByExample("FSC_Schedule_setting", d) > 0
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Sche_date", Sche_date)
            d.Add("Sche_type", Me.Sche_type)
            d.Add("Schedule_id", Me.Schedule_id)
            d.Add("Schedule_hours", Me.Schedule_hours)
            d.Add("Pay_hours", Me.Pay_hours)
            d.Add("Rest_hours", Me.Rest_hours)
            d.Add("Change_userid", Me.Change_userid)
            d.Add("Change_date", Me.Change_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", Me.id)

            Return DAO.UpdateByExample("FSC_Schedule_setting", d, cd) > 0
        End Function

        Public Function delete(ByVal orgcode As String, ByVal id_card As String, ByVal sche_date As String) As Boolean
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", orgcode)
            cd.Add("Id_card", id_card)
            cd.Add("Sche_date", sche_date)
            Return DAO.DeleteByExample("FSC_Schedule_setting", cd) > 0
        End Function

        Public Function GetMaxDataByScheId(ByVal orgcode As String, ByVal yymm As String, ByVal scheduleId As String) As DataTable
            Return DAO.GetMaxDataByScheId(orgcode, yymm, scheduleId)
        End Function

        Public Function updateByid() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Id_card", Id_card)
            d.Add("User_name", User_name)
            d.Add("Change_userid", Me.Change_userid)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)
            Return DAO.UpdateByExample("FSC_Schedule_setting", d, cd)
        End Function


        Public Function UpdateRestHours(ByVal orgcode As String, ByVal id_card As String, ByVal sche_date As String, ByVal rest_hours As Integer) As Boolean
            Dim v As New Dictionary(Of String, Object)
            v.Add("Rest_hours", rest_hours)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", orgcode)
            cd.Add("Id_card", id_card)
            cd.Add("Sche_date", sche_date)

            Return DAO.UpdateByExample("FSC_Schedule_setting", v, cd) > 0
        End Function


        Public Function DeleteData(ByVal orgcode As String, ByVal yyymm As String, ByVal scheduleId As String) As Boolean
            Return DAO.DeleteData(orgcode, yyymm, scheduleId) > 0
        End Function

        Public Function getCheckData(ByVal Orgcode As String, ByVal Schedule_id As String, ByVal Sche_date As String, ByVal id As String) As DataTable
            Return DAO.getCheckData(Orgcode, Schedule_id, Sche_date, id)
        End Function

        Public Function updateByDutyChange(ByVal dt As DataTable, ByVal isPlus As Boolean) As Boolean
            Dim dclist As List(Of DutyChange) = CommonFun.ConvertToList(Of DutyChange)(dt)

            Try
                If Not isPlus Then '撤銷
                    For Each dc As DutyChange In dclist
                        Dim ssdt As DataTable = Me.GetData(dc.Shift_Orgcode, dc.Shift_Idcard, dc.Shift_Dutydate)
                        Dim ssdt2 As DataTable = Me.GetData(dc.Apply_Orgcode, dc.Apply_Idcard, dc.Original_Dutydate)

                        If ssdt IsNot Nothing AndAlso ssdt.Rows.Count > 0 Then
                            Me.id = ssdt.Rows(0)("id")
                            Me.Orgcode = dc.Apply_Orgcode
                            Me.Depart_id = dc.Apply_Depart_id
                            Me.Id_card = dc.Apply_Idcard
                            Me.User_name = dc.Apply_Username
                            Me.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                            Me.updateByid()
                        End If
                        If dc.Duty_type = "2" Then '換值
                            If ssdt2 IsNot Nothing AndAlso ssdt2.Rows.Count > 0 Then
                                Me.id = ssdt2.Rows(0)("id")
                                Me.Orgcode = dc.Shift_Orgcode
                                Me.Depart_id = dc.Shift_Depart_id
                                Me.Id_card = dc.Shift_Idcard
                                Me.User_name = dc.Shift_Username
                                Me.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                                Me.updateByid()
                            End If
                        End If
                    Next
                Else
                    For Each dc As DutyChange In dclist
                        Dim ssdt As DataTable = Me.GetData(dc.Apply_Orgcode, dc.Apply_Idcard, IIf(dc.Duty_type = "1", dc.Shift_Dutydate, dc.Original_Dutydate))
                        Dim ssdt2 As DataTable = Me.GetData(dc.Shift_Orgcode, dc.Shift_Idcard, dc.Shift_Dutydate)

                        If ssdt IsNot Nothing AndAlso ssdt.Rows.Count > 0 Then
                            Me.id = ssdt.Rows(0)("id")
                            Me.Orgcode = dc.Shift_Orgcode
                            Me.Depart_id = dc.Shift_Depart_id
                            Me.Id_card = dc.Shift_Idcard
                            Me.User_name = dc.Shift_Username
                            Me.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                            Me.updateByid()
                        End If
                        If dc.Duty_type = "2" Then '換值
                            If ssdt2 IsNot Nothing AndAlso ssdt2.Rows.Count > 0 Then
                                Me.id = ssdt2.Rows(0)("id")
                                Me.Orgcode = dc.Apply_Orgcode
                                Me.Depart_id = dc.Apply_Depart_id
                                Me.Id_card = dc.Apply_Idcard
                                Me.User_name = dc.Apply_Username
                                Me.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                                Me.updateByid()
                            End If
                        End If
                    Next
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function updateSchedulehours(ByVal schedule_hours As Integer, ByVal Sche_date As String, ByVal id_card As String) As Boolean
            Return DAO.updateSchedulehours(schedule_hours, Sche_date, id_card)
        End Function
    End Class
End Namespace