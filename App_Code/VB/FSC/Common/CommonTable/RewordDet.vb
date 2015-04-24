Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic

    Public Class RewordDet
        Public DAO As RewordDetDAO

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

        Private _Reword_Orgcode As String
        Public Property Reword_Orgcode() As String
            Get
                Return _Reword_Orgcode
            End Get
            Set(ByVal value As String)
                _Reword_Orgcode = value
            End Set
        End Property

        Private _Reword_departid As String
        Public Property Reword_departid() As String
            Get
                Return _Reword_departid
            End Get
            Set(ByVal value As String)
                _Reword_departid = value
            End Set
        End Property

        Private _Reword_Idcard As String
        Public Property Reword_Idcard() As String
            Get
                Return _Reword_Idcard
            End Get
            Set(ByVal value As String)
                _Reword_Idcard = value
            End Set
        End Property

        Private _Reword_username As String
        Public Property Reword_username() As String
            Get
                Return _Reword_username
            End Get
            Set(ByVal value As String)
                _Reword_username = value
            End Set
        End Property

        Private _Reword_Title_no As String
        Public Property Reword_Title_no() As String
            Get
                Return _Reword_Title_no
            End Get
            Set(ByVal value As String)
                _Reword_Title_no = value
            End Set
        End Property

        Private _Reword_Employee_type As String
        Public Property Reword_Employee_type() As String
            Get
                Return _Reword_Employee_type
            End Get
            Set(ByVal value As String)
                _Reword_Employee_type = value
            End Set
        End Property

        Private _Reword_Level As String
        Public Property Reword_Level() As String
            Get
                Return _Reword_Level
            End Get
            Set(ByVal value As String)
                _Reword_Level = value
            End Set
        End Property

        Private _Specific_facts As String
        Public Property Specific_facts() As String
            Get
                Return _Specific_facts
            End Get
            Set(ByVal value As String)
                _Specific_facts = value
            End Set
        End Property

        Private _According_Clause As String
        Public Property According_Clause() As String
            Get
                Return _According_Clause
            End Get
            Set(ByVal value As String)
                _According_Clause = value
            End Set
        End Property

        Private _Reword_type As String
        Public Property Reword_type() As String
            Get
                Return _Reword_type
            End Get
            Set(ByVal value As String)
                _Reword_type = value
            End Set
        End Property

        Private _Reword_note As String
        Public Property Reword_note() As String
            Get
                Return _Reword_note
            End Get
            Set(ByVal value As String)
                _Reword_note = value
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
            DAO = New RewordDetDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)
            d.Add("Reword_Orgcode", Reword_Orgcode)
            d.Add("Reword_departid", Reword_departid)
            d.Add("Reword_Idcard", Reword_Idcard)
            d.Add("Reword_username", Reword_username)
            d.Add("Reword_Title_no", Reword_Title_no)
            d.Add("Reword_Employee_type", Reword_Employee_type)
            d.Add("Reword_Level", Reword_Level)
            d.Add("Specific_facts", Specific_facts)
            d.Add("According_Clause", According_Clause)
            d.Add("Reword_type", Reword_type)
            d.Add("Reword_note", Reword_note)
            d.Add("Reword_date", Reword_date)
            d.Add("Reword_Doc", Reword_Doc)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Reword_det", d)
        End Function


        Public Function DeletTempData(orgcode As String, id_card As String) As Boolean
            Return DAO.DeletTempData(orgcode, id_card) > 0
        End Function

        Public Function GetTempData(orgcode As String, id_card As String) As DataTable
            Return DAO.GetTempData(orgcode, id_card)
        End Function
    End Class

End Namespace
