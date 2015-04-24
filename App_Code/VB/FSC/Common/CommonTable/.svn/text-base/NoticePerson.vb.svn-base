Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic
    Public Class NoticePerson
        Public DAO As NoticePersonDAO

#Region "property"
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

        Private _Leave_type As String
        Public Property Leave_type() As String
            Get
                Return _Leave_type
            End Get
            Set(ByVal value As String)
                _Leave_type = value
            End Set
        End Property

        Private _id_card As String
        Public Property Id_card() As String
            Get
                Return _id_card
            End Get
            Set(ByVal value As String)
                _id_card = value
            End Set
        End Property

        Private _change_userid As String
        Public Property change_userid() As String
            Get
                Return _change_userid
            End Get
            Set(ByVal value As String)
                _change_userid = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New NoticePersonDAO()
        End Sub

        Public Function getDataByLeaveType(ByVal Orgcode As String, ByVal Leave_type As String) As DataTable
            Return DAO.getDataByLeaveType(Orgcode, Leave_type)
        End Function

        Public Function insert() As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Leave_type", Leave_type)
            d.Add("id_card", Id_card)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Notice_person", d)
        End Function

        Public Function delete() As Boolean
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Leave_type", Leave_type)
            cd.Add("id_card", Id_card)

            Return DAO.DeleteByExample("FSC_Notice_person", cd)
        End Function
    End Class
End Namespace
