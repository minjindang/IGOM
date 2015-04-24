Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic

    Public Class RewordMain
        Public DAO As RewordMainDAO

#Region "property"
        Private _flow_id As String
        Public Property flow_id() As String
            Get
                Return _flow_id
            End Get
            Set(ByVal value As String)
                _flow_id = value
            End Set
        End Property

        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

        Private _Depart_id As String
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property

        Private _Id_card As String
        Public Property Id_card() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property

        Private _Apply_name As String
        Public Property Apply_name() As String
            Get
                Return _Apply_name
            End Get
            Set(ByVal value As String)
                _Apply_name = value
            End Set
        End Property

        Private _Apply_date As String
        Public Property Apply_date() As String
            Get
                Return _Apply_date
            End Get
            Set(ByVal value As String)
                _Apply_date = value
            End Set
        End Property

        Private _Reason As String
        Public Property Reason() As String
            Get
                Return _Reason
            End Get
            Set(ByVal value As String)
                _Reason = value
            End Set
        End Property

        Private _Reason_type As String
        Public Property Reason_type() As String
            Get
                Return _Reason_type
            End Get
            Set(ByVal value As String)
                _Reason_type = value
            End Set
        End Property

        Private _Reason_point As String
        Public Property Reason_point() As String
            Get
                Return _Reason_point
            End Get
            Set(ByVal value As String)
                _Reason_point = value
            End Set
        End Property

        Private _Reason_section As String
        Public Property Reason_section() As String
            Get
                Return _Reason_section
            End Get
            Set(ByVal value As String)
                _Reason_section = value
            End Set
        End Property

        Private _Reason_item As String
        Public Property Reason_item() As String
            Get
                Return _Reason_item
            End Get
            Set(ByVal value As String)
                _Reason_item = value
            End Set
        End Property

        Private _Reason_list As String
        Public Property Reason_list() As String
            Get
                Return _Reason_list
            End Get
            Set(ByVal value As String)
                _Reason_list = value
            End Set
        End Property

        Private _Self_ssessment_point As String
        Public Property Self_ssessment_point() As String
            Get
                Return _Self_ssessment_point
            End Get
            Set(ByVal value As String)
                _Self_ssessment_point = value
            End Set
        End Property

        Private _Last_point As String
        Public Property Last_point() As String
            Get
                Return _Last_point
            End Get
            Set(ByVal value As String)
                _Last_point = value
            End Set
        End Property

        Private _Last_datereason As String
        Public Property Last_datereason() As String
            Get
                Return _Last_datereason
            End Get
            Set(ByVal value As String)
                _Last_datereason = value
            End Set
        End Property

        Private _Input_manpower As String
        Public Property Input_manpower() As String
            Get
                Return _Input_manpower
            End Get
            Set(ByVal value As String)
                _Input_manpower = value
            End Set
        End Property

        Private _Input_manpower_type As String
        Public Property Input_manpower_type() As String
            Get
                Return _Input_manpower_type
            End Get
            Set(ByVal value As String)
                _Input_manpower_type = value
            End Set
        End Property

        Private _Input_manpower_note As String
        Public Property Input_manpower_note() As String
            Get
                Return _Input_manpower_note
            End Get
            Set(ByVal value As String)
                _Input_manpower_note = value
            End Set
        End Property

        Private _Input_sdate As String
        Public Property Input_sdate() As String
            Get
                Return _Input_sdate
            End Get
            Set(ByVal value As String)
                _Input_sdate = value
            End Set
        End Property

        Private _Input_edate As String
        Public Property Input_edate() As String
            Get
                Return _Input_edate
            End Get
            Set(ByVal value As String)
                _Input_edate = value
            End Set
        End Property

        Private _input_conform As String
        Public Property input_conform() As String
            Get
                Return _input_conform
            End Get
            Set(ByVal value As String)
                _input_conform = value
            End Set
        End Property

        Private _input_notconform_reason As String
        Public Property input_notconform_reason() As String
            Get
                Return _input_notconform_reason
            End Get
            Set(ByVal value As String)
                _input_notconform_reason = value
            End Set
        End Property

        Private _Innovative_desc As String
        Public Property Innovative_desc() As String
            Get
                Return _Innovative_desc
            End Get
            Set(ByVal value As String)
                _Innovative_desc = value
            End Set
        End Property

        Private _Difficulty_desc As String
        Public Property Difficulty_desc() As String
            Get
                Return _Difficulty_desc
            End Get
            Set(ByVal value As String)
                _Difficulty_desc = value
            End Set
        End Property

        Private _Contribution_desc As String
        Public Property Contribution_desc() As String
            Get
                Return _Contribution_desc
            End Get
            Set(ByVal value As String)
                _Contribution_desc = value
            End Set
        End Property

        Private _Council_name As String
        Public Property Council_name() As String
            Get
                Return _Council_name
            End Get
            Set(ByVal value As String)
                _Council_name = value
            End Set
        End Property

        Private _Council_date As String
        Public Property Council_date() As String
            Get
                Return _Council_date
            End Get
            Set(ByVal value As String)
                _Council_date = value
            End Set
        End Property

        Private _Council_approve As String
        Public Property Council_approve() As String
            Get
                Return _Council_approve
            End Get
            Set(ByVal value As String)
                _Council_approve = value
            End Set
        End Property

        Private _Reword_date As String
        Public Property Reword_date() As String
            Get
                Return _Reword_date
            End Get
            Set(ByVal value As String)
                _Reword_date = value
            End Set
        End Property

        Private _Reword_Doc As String
        Public Property Reword_Doc() As String
            Get
                Return _Reword_Doc
            End Get
            Set(ByVal value As String)
                _Reword_Doc = value
            End Set
        End Property

        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New RewordMainDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Id_card", Id_card)
            d.Add("Apply_name", Apply_name)
            d.Add("Apply_date", Apply_date)
            d.Add("Reason", Reason)
            d.Add("Reason_type", Reason_type)
            d.Add("Reason_point", Reason_point)
            d.Add("Reason_section", Reason_section)
            d.Add("Reason_item", Reason_item)
            d.Add("Reason_list", Reason_list)
            d.Add("Self_ssessment_point", Self_ssessment_point)
            d.Add("Last_point", Last_point)
            d.Add("Last_datereason", Last_datereason)
            d.Add("Input_manpower", Input_manpower)
            d.Add("Input_manpower_type", Input_manpower_type)
            d.Add("Input_manpower_note", Input_manpower_note)
            d.Add("Input_sdate", Input_sdate)
            d.Add("Input_edate", Input_edate)
            d.Add("input_conform", input_conform)
            d.Add("input_notconform_reason", input_notconform_reason)
            d.Add("Innovative_desc", Innovative_desc)
            d.Add("Difficulty_desc", Difficulty_desc)
            d.Add("Contribution_desc", Contribution_desc)
            d.Add("Council_name", Council_name)
            d.Add("Council_date", Council_date)
            d.Add("Council_approve", Council_approve)
            d.Add("Reword_date", Reword_date)
            d.Add("Reword_Doc", Reword_Doc)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Reword_main", d)
        End Function

        Public Function getDataByFid(ByVal flow_id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)

            Return DAO.GetDataByExample("FSC_Reword_main", d)
        End Function

        Public Function updateReword() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Council_name", Council_name)
            d.Add("Council_date", Council_date)
            d.Add("Council_approve", Council_approve)
            d.Add("Reword_date", Reword_date)
            d.Add("Reword_Doc", Reword_Doc)
            d.Add("Change_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("flow_id", flow_id)

            Return DAO.UpdateByExample("FSC_Reword_main", d, cd)
        End Function

        Public Function DeletTempData(orgcode As String, id_card As String) As Boolean
            Return DAO.DeletTempData(orgcode, id_card) > 0
        End Function

        Public Function GetTempData(orgcode As String, id_card As String) As DataTable
            Return DAO.GetTempData(orgcode, id_card)
        End Function

    End Class

End Namespace
