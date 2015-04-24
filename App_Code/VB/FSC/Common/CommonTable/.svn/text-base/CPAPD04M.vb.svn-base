Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPD04M
        Private DAO As CPAPD04MDAO

        Public Sub New()
            DAO = New CPAPD04MDAO()
        End Sub

#Region "fields"
        Private _Orgcode As String
        Private _Depart_id As String
        Private _PDKIND As String
        Private _PDMEMCODE As String
        Private _PDVTYPE As String
        Private _PDYEARB As String
        Private _PDYEARE As String
        Private _PDDAYS As String
        Private _Change_userid As String
#End Region

#Region "property"
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property PDKIND() As String
            Get
                Return _PDKIND
            End Get
            Set(ByVal value As String)
                _PDKIND = value
            End Set
        End Property
        Public Property PDMEMCOD() As String
            Get
                Return _PDMEMCODE
            End Get
            Set(ByVal value As String)
                _PDMEMCODE = value
            End Set
        End Property
        Public Property PDVTYPE() As String
            Get
                Return _PDVTYPE
            End Get
            Set(ByVal value As String)
                _PDVTYPE = value
            End Set
        End Property
        Public Property PDYEARB() As String
            Get
                Return _PDYEARB
            End Get
            Set(ByVal value As String)
                _PDYEARB = value
            End Set
        End Property
        Public Property PDYEARE() As String
            Get
                Return _PDYEARE
            End Get
            Set(ByVal value As String)
                _PDYEARE = value
            End Set
        End Property
        Public Property PDDAYS() As String
            Get
                Return _PDDAYS
            End Get
            Set(ByVal value As String)
                _PDDAYS = value
            End Set
        End Property
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
            d.Add("PDKIND", PDKIND)
            d.Add("PDMEMCOD", PDMEMCOD)
            d.Add("PDVTYPE", PDVTYPE)
            d.Add("PDYEARB", PDYEARB)
            d.Add("PDYEARE", PDYEARE)
            d.Add("PDDAYS", PDDAYS)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_CPAPD04M", d)
        End Function

        Public Function update(ByVal CPDKIND As String, ByVal CPDMEMCOD As String, ByVal CPDVTYPE As String, ByVal CPDYEARB As String) As Boolean

            Return DAO.update(Orgcode, Depart_id, PDYEARB, PDYEARE, PDDAYS, Change_userid, CPDKIND, CPDMEMCOD, CPDVTYPE, CPDYEARB)
        End Function

        Public Function delete() As Integer

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("PDKIND", PDKIND)
            cd.Add("PDMEMCOD", PDMEMCOD)
            cd.Add("PDVTYPE", PDVTYPE)
            cd.Add("PDYEARB", PDYEARB)

            Return DAO.DeleteByExample("FSC_CPAPD04M", cd)
        End Function

        Public Function GetDataByQuery(ByVal PDKIND As String, ByVal PDMEMCOD As String, ByVal PDVTYPE As String, ByVal PDYEARB As String) As DataTable
            Return DAO.GetDataByQuery(PDKIND, PDMEMCOD, PDVTYPE, PDYEARB)
        End Function

        Public Function GetDataByQuery(ByVal PDKIND As String, ByVal PDMEMCOD As String, ByVal PDVTYPE As String) As DataTable
            Return DAO.GetDataByQuery(PDKIND, PDMEMCOD, PDVTYPE)
        End Function
    End Class
End Namespace