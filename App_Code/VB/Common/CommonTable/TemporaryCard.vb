Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class TemporaryCard
        Dim DAO As TemporaryCardDAO

#Region "fields"
        Private _id As Integer

        Private _orgcode As String

        Private _depart_id As String

        Private _sub_depart_id As String

        Private _id_card As String

        Private _personnel_id As String

        Private _temporary_card As String

        Private _borrow_date As String

        Private _borrow_reason As String

        Private _return_date As String

        Private _remarks As String

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

        Public Property temporary_card() As String
            Get
                Return Me._temporary_card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._temporary_card, value) = False) Then
                    Me._temporary_card = value
                End If
            End Set
        End Property

        Public Property borrow_date() As String
            Get
                Return Me._borrow_date
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._borrow_date, value) = False) Then
                    Me._borrow_date = value
                End If
            End Set
        End Property

        Public Property borrow_reason() As String
            Get
                Return Me._borrow_reason
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._borrow_reason, value) = False) Then
                    Me._borrow_reason = value
                End If
            End Set
        End Property

        Public Property return_date() As String
            Get
                Return Me._return_date
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._return_date, value) = False) Then
                    Me._return_date = value
                End If
            End Set
        End Property

        Public Property remarks() As String
            Get
                Return Me._remarks
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._remarks, value) = False) Then
                    Me._remarks = value
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
            DAO = New TemporaryCardDAO()
        End Sub


        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("depart_id", depart_id)
            d.Add("sub_depart_id", sub_depart_id)
            d.Add("id_card", id_card)
            d.Add("personnel_id", personnel_id)
            d.Add("borrow_date", borrow_date)
            d.Add("temporary_card", temporary_card)
            d.Add("return_date", return_date)
            d.Add("borrow_reason", borrow_reason)
            d.Add("remarks", remarks)
            d.Add("create_userid", create_userid)
            d.Add("create_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("Temporary_card", d) > 0
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("depart_id", depart_id)
            d.Add("sub_depart_id", sub_depart_id)
            d.Add("id_card", id_card)
            d.Add("personnel_id", personnel_id)
            d.Add("borrow_date", borrow_date)
            d.Add("temporary_card", temporary_card)
            d.Add("return_date", return_date)
            d.Add("borrow_reason", borrow_reason)
            d.Add("remarks", remarks)
            d.Add("change_userid", change_userid)
            d.Add("change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)
            Return DAO.updateByExample("Temporary_card", d, cd) > 0
        End Function


        Public Function getDataById(ByVal id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.GetDataByExample("Temporary_card", d)
        End Function


        Public Function deleteById(ByVal id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.deleteByExample("Temporary_card", d) > 0
        End Function

        Public Function getQueryData(ByVal orgcode As String, ByVal depart_id As String, ByVal sub_depart_id As String, ByVal id_card As String, ByVal personnel_id As String, _
                                     ByVal borrow_sdate As String, ByVal borrow_edate As String, ByVal roleid As String) As DataTable
            Return getQueryData(orgcode, depart_id, sub_depart_id, id_card, personnel_id, borrow_sdate, borrow_edate, roleid, False)
            'Dim metadb_id As String = "1"
            'If "TWDAdmin".Equals(roleid) Then
            '    metadb_id = "2"
            'End If

            'Dim dt As DataTable = DAO.getQueryData(orgcode, depart_id, sub_depart_id, id_card, personnel_id, borrow_sdate, borrow_edate, metadb_id)

            'dt.Columns.Add("depart_name", GetType(String))
            'dt.Columns.Add("sub_depart_name", GetType(String))

            'Dim org As New FSCorg()

            'Dim ndt As New DataTable()
            'ndt = dt.Clone()

            'For Each dr As DataRow In dt.Rows
            '    dr("depart_name") = org.GetDepartName(dr("orgcode").ToString(), dr("depart_id").ToString())
            '    dr("sub_depart_name") = org.GetSubDepartName(dr("orgcode").ToString(), dr("depart_id").ToString(), dr("Sub_depart_id").ToString())
            '    ndt.ImportRow(dr)
            'Next

            'Return ndt
        End Function

        Public Function getQueryData(ByVal orgcode As String, ByVal depart_id As String, ByVal sub_depart_id As String, ByVal id_card As String, ByVal personnel_id As String, _
                                     ByVal borrow_sdate As String, ByVal borrow_edate As String, ByVal roleid As String, ByVal isInUseOnly As Boolean) As DataTable

            Dim metadb_id As String = "1"
            If "TWDAdmin".Equals(roleid) Then
                metadb_id = "2"
            ElseIf "GenServAdmin".Equals(roleid) Then
                metadb_id = "2"
            End If

            Dim dt As DataTable = DAO.getQueryData(orgcode, depart_id, sub_depart_id, id_card, personnel_id, borrow_sdate, borrow_edate, isInUseOnly, metadb_id)

            dt.Columns.Add("depart_name", GetType(String))
            dt.Columns.Add("sub_depart_name", GetType(String))

            Dim org As New FSCorg()

            Dim ndt As New DataTable()
            ndt = dt.Clone()

            For Each dr As DataRow In dt.Rows
                dr("depart_name") = org.GetDepartName(dr("orgcode").ToString(), dr("depart_id").ToString())
                dr("sub_depart_name") = org.GetSubDepartName(dr("orgcode").ToString(), dr("depart_id").ToString(), dr("Sub_depart_id").ToString())
                ndt.ImportRow(dr)
            Next

            Return ndt
        End Function
    End Class
End Namespace