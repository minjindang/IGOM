Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class QueryFunction
        Dim DAO As QueryFunctionDAO

#Region "fields"
        Private _id As Integer

        Private _orgcode As String

        Private _depart_id As String

        Private _sub_depart_id As String

        Private _id_card As String

        Private _personnel_id As String

        Private _func_id As String

        Private _create_userid As String

        Private _create_date As Date

        Private _change_userid As String

        Private _change_date As System.Nullable(Of Date)
#End Region

#Region "Property"
        Public Property id() As Integer
            Get
                Return Me._id
            End Get
            Set(ByVal value As Integer)
                If ((Me._id = value) = False) Then
                    Me._id = value
                End If
            End Set
        End Property

        Public Property orgcode() As String
            Get
                Return Me._orgcode
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._orgcode, value) = False) Then
                    Me._orgcode = value
                End If
            End Set
        End Property

        Public Property depart_id() As String
            Get
                Return Me._depart_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._depart_id, value) = False) Then
                    Me._depart_id = value
                End If
            End Set
        End Property

        Public Property sub_depart_id() As String
            Get
                Return Me._sub_depart_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._sub_depart_id, value) = False) Then
                    Me._sub_depart_id = value
                End If
            End Set
        End Property

        Public Property id_card() As String
            Get
                Return Me._id_card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._id_card, value) = False) Then
                    Me._id_card = value
                End If
            End Set
        End Property

        Public Property personnel_id() As String
            Get
                Return Me._personnel_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._personnel_id, value) = False) Then
                    Me._personnel_id = value
                End If
            End Set
        End Property

        Public Property func_id() As String
            Get
                Return Me._func_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._func_id, value) = False) Then
                    Me._func_id = value
                End If
            End Set
        End Property

        Public Property create_userid() As String
            Get
                Return Me._create_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._create_userid, value) = False) Then
                    Me._create_userid = value
                End If
            End Set
        End Property

        Public Property create_date() As Date
            Get
                Return Me._create_date
            End Get
            Set(ByVal value As Date)
                If ((Me._create_date = value) _
                   = False) Then
                    Me._create_date = value
                End If
            End Set
        End Property

        Public Property change_userid() As String
            Get
                Return Me._change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._change_userid, value) = False) Then
                    Me._change_userid = value
                End If
            End Set
        End Property

        Public Property change_date() As System.Nullable(Of Date)
            Get
                Return Me._change_date
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                If (Me._change_date.Equals(value) = False) Then
                    Me._change_date = value
                End If
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New QueryFunctionDAO()
        End Sub


        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("depart_id", depart_id)
            d.Add("sub_depart_id", sub_depart_id)
            d.Add("id_card", id_card)
            d.Add("personnel_id", personnel_id)
            d.Add("func_id", func_id)
            Return DAO.insertByExample("Query_function", d) > 0
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("depart_id", depart_id)
            d.Add("sub_depart_id", sub_depart_id)
            d.Add("id_card", id_card)
            d.Add("personnel_id", personnel_id)
            d.Add("func_id", func_id)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)
            Return DAO.updateByExample("Query_function", d, cd) > 0
        End Function


        Public Function getData() As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("depart_id", depart_id)
            d.Add("sub_depart_id", sub_depart_id)
            d.Add("func_id", func_id)
            Return DAO.GetDataByExample("Query_function", d)
        End Function


        Public Function deleteById(ByVal id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.deleteByExample("Query_function", d) > 0
        End Function


        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("depart_id", depart_id)
            d.Add("sub_depart_id", sub_depart_id)
            d.Add("id_card", id_card)
            d.Add("personnel_id", personnel_id)

            Return DAO.deleteByExample("Query_function", d) > 0
        End Function

    End Class
End Namespace