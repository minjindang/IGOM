Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class CPAPT20M
        Private DAO As CPAPT20MDAO

#Region "fields"
        Private _PTNAME As String
        Private _PTIDNO As String
        Private _PTCARD As String
        Private _PTBDATE As String
        Private _PTEDATE As String
        Private _PTSTIME As String
        Private _PTETIME As String
        Private _PTPNAME As String
        Private _PTHOUR As String
        Private _PTUSERID As String
        Private _PTUPDATE As String
        Private _PTHOUR2 As String
        Private _PTFLAG As String
        Private _PTFLAG2 As String
#End Region
#Region "property"
        Public Property PTNAME() As String
            Get
                Return _PTNAME
            End Get
            Set(value As String)
                _PTNAME = value
            End Set
        End Property
        Public Property PTIDNO() As String
            Get
                Return _PTIDNO
            End Get
            Set(value As String)
                _PTIDNO = value
            End Set
        End Property
        Public Property PTCARD() As String
            Get
                Return _PTCARD
            End Get
            Set(value As String)
                _PTCARD = value
            End Set
        End Property
        Public Property PTBDATE() As String
            Get
                Return _PTBDATE
            End Get
            Set(value As String)
                _PTBDATE = value
            End Set
        End Property
        Public Property PTEDATE() As String
            Get
                Return _PTEDATE
            End Get
            Set(value As String)
                _PTEDATE = value
            End Set
        End Property
        Public Property PTSTIME() As String
            Get
                Return _PTSTIME
            End Get
            Set(value As String)
                _PTSTIME = value
            End Set
        End Property
        Public Property PTETIME() As String
            Get
                Return _PTETIME
            End Get
            Set(value As String)
                _PTETIME = value
            End Set
        End Property
        Public Property PTPNAME() As String
            Get
                Return _PTPNAME
            End Get
            Set(value As String)
                _PTPNAME = value
            End Set
        End Property
        Public Property PTHOUR() As String
            Get
                Return _PTHOUR
            End Get
            Set(value As String)
                _PTHOUR = value
            End Set
        End Property
        Public Property PTUSERID() As String
            Get
                Return _PTUSERID
            End Get
            Set(value As String)
                _PTUSERID = value
            End Set
        End Property
        Public Property PTUPDATE() As String
            Get
                Return _PTUPDATE
            End Get
            Set(value As String)
                _PTUPDATE = value
            End Set
        End Property
        Public Property PTHOUR2() As String
            Get
                Return _PTHOUR2
            End Get
            Set(value As String)
                _PTHOUR2 = value
            End Set
        End Property
        Public Property PTFLAG() As String
            Get
                Return _PTFLAG
            End Get
            Set(value As String)
                _PTFLAG = value
            End Set
        End Property
        Public Property PTFLAG2() As String
            Get
                Return _PTFLAG2
            End Get
            Set(value As String)
                _PTFLAG2 = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPT20MDAO()
        End Sub

        Public Sub New(ByVal connstr As String)
            DAO = New CPAPT20MDAO(connstr)
        End Sub

        Public Function GetDataByPRADDD(ByVal PTIDNO As String, ByVal PRADDD As String) As DataTable
            Return DAO.GetDataByPRADDD(PTIDNO, PRADDD)
        End Function

        Public Function GetCountByPRADDD(ByVal PTIDNO As String, ByVal PRADDD As String) As Integer
            Dim obj As Object = DAO.GetCountByPRADDD(PTIDNO, PRADDD)
            If obj Is Nothing OrElse IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetApplyCountByPRADDD(ByVal PTIDNO As String, ByVal PRADDD As String) As Integer
            Dim obj As Object = DAO.GetApplyCountByPRADDD(PTIDNO, PRADDD)
            If obj Is Nothing OrElse IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetCountByPTCARD(ByVal PTCARD As String) As Integer
            Dim obj As Object = DAO.GetCountByPTCARD(PTCARD)
            If obj Is Nothing OrElse IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetPTHOUR(ByVal PTIDNO As String, ByVal ym As String) As String
            Dim obj As Object = DAO.GetPTHOUR(PTIDNO, ym)
            If obj Is Nothing OrElse IsDBNull(obj) Then Return String.Empty
            Return CType(obj, String)
        End Function

        Public Function deleteData(ByVal PTCARD As String, ByVal PTBDATE As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("PTCARD", PTCARD)
            d.Add("PTBDATE", PTBDATE)
            Return DAO.deleteByExample("CPAPT20M", d) > 0
        End Function


        Public Function getData(ByVal PTCARD As String, ByVal PTBDATE As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("PTCARD", PTCARD)
            d.Add("PTBDATE", PTBDATE)
            Return DAO.GetDataByExample("CPAPT20M", d)
        End Function

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("PTNAME", PTNAME)
            d.Add("PTIDNO", PTIDNO)
            d.Add("PTCARD", PTCARD)
            d.Add("PTBDATE", PTBDATE)
            d.Add("PTEDATE", PTEDATE)
            d.Add("PTPNAME", PTPNAME)
            d.Add("PTHOUR", PTHOUR)
            d.Add("PTHOUR2", PTHOUR2)
            d.Add("PTUSERID", PTUSERID)
            d.Add("PTUPDATE", PTUPDATE)
            d.Add("PTFLAG", PTFLAG)
            d.Add("PTFLAG2", PTFLAG2)
            Return DAO.insertByExample("CPAPT20M", d)
        End Function

        Public Function update(ByVal PTCARD As String, ByVal PTBDATE As String) As Boolean

            Return DAO.updateData(Me, PTCARD, PTBDATE) > 0
        End Function

        Public Function Getdatebydate(ByVal PTNAME As String, ByVal PTIDNO As String, ByVal PTCARD As String, _
                                      ByVal PTBDATE As String, ByVal PTEDATE As String) As DataTable
            Dim ds As DataSet = DAO.Getdatebydate(PTNAME, PTIDNO, PTCARD, PTBDATE, PTEDATE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function
    End Class
End Namespace