Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class DeputyVacancy
        Dim DAO As DeputyVacancyDAO

        Public Sub New()
            DAO = New DeputyVacancyDAO
        End Sub

#Region "property"
        Private _id As Integer
        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
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

        Private _Title_no As String
        Public Property Title_no() As String
            Get
                Return _Title_no
            End Get
            Set(ByVal value As String)
                _Title_no = value
            End Set
        End Property

        Private _Boss_level_id As String
        Public Property Boss_level_id() As String
            Get
                Return _Boss_level_id
            End Get
            Set(ByVal value As String)
                _Boss_level_id = value
            End Set
        End Property

        Private _Deputy_Orgcode As String
        Public Property Deputy_Orgcode() As String
            Get
                Return _Deputy_Orgcode
            End Get
            Set(ByVal value As String)
                _Deputy_Orgcode = value
            End Set
        End Property

        Private _Deputy_Depart_id As String
        Public Property Deputy_Depart_id() As String
            Get
                Return _Deputy_Depart_id
            End Get
            Set(ByVal value As String)
                _Deputy_Depart_id = value
            End Set
        End Property

        Private _Deputy_id_card As String
        Public Property Deputy_id_card() As String
            Get
                Return _Deputy_id_card
            End Get
            Set(ByVal value As String)
                _Deputy_id_card = value
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

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Title_no", Title_no)
            d.Add("Boss_level_id", Boss_level_id)
            d.Add("Deputy_Orgcode", Deputy_Orgcode)
            d.Add("Deputy_Depart_id", Deputy_Depart_id)
            d.Add("Deputy_id_card", Deputy_id_card)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Deputy_vacancy", d)
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Title_no", Title_no)
            d.Add("Boss_level_id", Boss_level_id)
            d.Add("Deputy_Orgcode", Deputy_Orgcode)
            d.Add("Deputy_Depart_id", Deputy_Depart_id)
            d.Add("Deputy_id_card", Deputy_id_card)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("FSC_Deputy_vacancy", d, cd)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return DAO.DeleteByExample("FSC_Deputy_vacancy", d)
        End Function

        Public Function getDataByid(ByVal id As String) As DataTable
            Return DAO.getDataByid(id)
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Boss_level_id As String, ByVal Title_no As String) As DataTable
            Dim tmp As DataTable = DAO.getData(Orgcode, Depart_id, Boss_level_id, Title_no)

            Dim dt As DataTable = New DataTable
            If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                dt.Columns.Add("orgcode")
                dt.Columns.Add("depart_id")
                dt.Columns.Add("id_card")
                dt.Columns.Add("title_no")
                dt.Columns.Add("user_name")

                For Each tdr As DataRow In tmp.Rows
                    Dim dr As DataRow = dt.NewRow
                    dr("orgcode") = tdr("Deputy_Orgcode").ToString()
                    dr("depart_id") = tdr("Deputy_Depart_id").ToString()
                    dr("id_card") = tdr("Deputy_id_card").ToString()
                    dr("title_no") = New FSC.Logic.Personnel().GetColumnValue("title_no", tdr("Deputy_id_card").ToString())
                    dr("user_name") = New FSC.Logic.Personnel().GetColumnValue("user_name", tdr("Deputy_id_card").ToString())

                    dt.Rows.Add(dr)
                Next
            End If

            Return dt
        End Function
    End Class
End Namespace