Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace FSCPLM.Logic
    Public Class SubDeptemp
        Public DAO As SubDeptempDAO

#Region "fields"
        Private _id As Integer
        Private _Id_card As String
        Private _Orgcode As String
        Private _Personnel_id As String
        Private _Title_no As String
        Private _Depart_id As String
        Private _Sub_depart_id As String
        Private _isContact As Integer
        Private _Position As String
        Private _Member_id As Integer
#End Region

#Region "Property"
        Public Property id() As Integer
            Get
                Return Me._id
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._id, value) = False) Then
                    Me._id = value
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

        Public Property Personnel_id() As String
            Get
                Return Me._Personnel_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Personnel_id, value) = False) Then
                    Me._Personnel_id = value
                End If
            End Set
        End Property

        Public Property Title_no() As String
            Get
                Return Me._Title_no
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Title_no, value) = False) Then
                    Me._Title_no = value
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

        Public Property Sub_depart_id() As String
            Get
                Return Me._Sub_depart_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Sub_depart_id, value) = False) Then
                    Me._Sub_depart_id = value
                End If
            End Set
        End Property

        Public Property isContact() As Integer
            Get
                Return Me._isContact
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._isContact, value) = False) Then
                    Me._isContact = value
                End If
            End Set
        End Property

        Public Property Position() As String
            Get
                Return Me._Position
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Position, value) = False) Then
                    Me._Position = value
                End If
            End Set
        End Property
        Public Property Member_id() As Integer
            Get
                Return Me._Member_id
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Member_id, value) = False) Then
                    Me._Member_id = value
                End If
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New SubDeptempDAO
        End Sub

        Public Function Insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Title_no", Title_no)
            d.Add("Depart_id", Depart_id)
            d.Add("Sub_depart_id", Sub_depart_id)
            d.Add("isContact", isContact)
            d.Add("Position", Position)
            d.Add("Member_id", Member_id)

            Return DAO.insertByExample("Sub_deptemp", d) >= 1
        End Function

        Public Function Update() As Boolean
            Dim d As New Dictionary(Of String, Object)
             d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Title_no", Title_no)
            d.Add("Depart_id", Depart_id)
            d.Add("Sub_depart_id", Sub_depart_id)
            d.Add("isContact", isContact)
            d.Add("Position", Position)
            d.Add("Member_id", Member_id)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.updateByExample("Sub_deptemp", d, cd) >= 1
        End Function

        Public Function DeleteDataByMember_id(ByVal Member_id As Integer) As String
            Return DAO.DeleteDataByMember_id(Member_id)
        End Function

        Public Function GetDataByMember_id(ByVal Member_id As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataByMember_id(Member_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Id_card As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode, Id_card)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetOrgcode(ByVal Orgcode As String, ByVal Id_card As String) As DataTable
            Dim ds As DataSet = DAO.GetOrgcode(Orgcode, Id_card)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByOrgcode(ByVal Orgcode As String, ByVal Id_card As String, ByVal Depart_id As String, ByVal ddlOrgcode As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByOrgcode(Orgcode, Id_card, Depart_id, ddlOrgcode)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetSub_depart(ByVal Orgcode As String, ByVal Id_card As String, ByVal Depart_id As String, ByVal Sub_Depart_id As String, ByVal ddlOrgcode As String, ByVal ddlDepart_id As String) As DataTable
            Dim ds As DataSet = DAO.GetSub_depart(Orgcode, Id_card, Depart_id, Sub_Depart_id, ddlOrgcode, ddlDepart_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function
    End Class
End Namespace
