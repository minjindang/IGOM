Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Collections
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPC03M
        Public DAO As CPAPC03MDAO

#Region "fields"
        Private _Orgcode As String
        Private _DepartId As String
        Private _PCKIND As String
        Private _PCITEM As String
        Private _PCCODE As System.Nullable(Of Integer)
        Private _PCDESC As String
        Private _PCPARM1 As String
        Private _PCPARM2 As String
        Private _ChangeUserid As String
#End Region

#Region "property"
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
        Public Property DepartId() As String
            Get
                Return Me._DepartId
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._DepartId, value) = False) Then
                    Me._DepartId = value
                End If
            End Set
        End Property
        Public Property PCKIND() As String
            Get
                Return Me._PCKIND
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PCKIND, value) = False) Then
                    Me._PCKIND = value
                End If
            End Set
        End Property
        Public Property PCITEM() As String
            Get
                Return Me._PCITEM
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PCITEM, value) = False) Then
                    Me._PCITEM = value
                End If
            End Set
        End Property
        Public Property PCCODE() As System.Nullable(Of Integer)
            Get
                Return Me._PCCODE
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._PCCODE.Equals(value) = False) Then
                    Me._PCCODE = value
                End If
            End Set
        End Property
        Public Property PCDESC() As String
            Get
                Return Me._PCDESC
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PCDESC, value) = False) Then
                    Me._PCDESC = value
                End If
            End Set
        End Property
        Public Property PCPARM1() As String
            Get
                Return Me._PCPARM1
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PCPARM1, value) = False) Then
                    Me._PCPARM1 = value
                End If
            End Set
        End Property
        Public Property PCPARM2() As String
            Get
                Return Me._PCPARM2
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PCPARM2, value) = False) Then
                    Me._PCPARM2 = value
                End If
            End Set
        End Property
        Public Property ChangeUserid() As String
            Get
                Return Me._ChangeUserid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._ChangeUserid, value) = False) Then
                    Me._ChangeUserid = value
                End If
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPC03MDAO()
        End Sub

        Public Sub New(ByVal conn As System.Data.SqlClient.SqlConnection)
            DAO = New CPAPC03MDAO(conn)
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal PCKIND As String, ByVal PCITEM As String) As DataTable
            Return DAO.GetData(Orgcode, Depart_id, PCKIND, PCITEM)
        End Function

        Public Function GetHashTableData() As Hashtable
            Return DAO.GetHashTableData()
        End Function

        Public Function GetHashTableData(PCKIND As String) As Hashtable
            Return DAO.GetHashTableData(PCKIND)
        End Function

        Public Function updateData() As Boolean
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("PCKIND", PCKIND)
            cd.Add("PCITEM", PCITEM)
            cd.Add("PCCODE", PCCODE)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Depart_id", DepartId)

            Dim d As New Dictionary(Of String, Object)
            d.Add("PCPARM1", PCPARM1)
            d.Add("PCPARM2", PCPARM2)
            d.Add("Change_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
            d.Add("Change_date", Date.Now)

            Return DAO.UpdateByExample("FSC_CPAPC03M", d, cd) >= 1
        End Function

        Public Function GetCPAPC03M(ByVal PEKIND As String, ByVal Param As String) As String
            Dim reValue As Double
            '2.取得限制參數，至機關制度參數資料檔
            Dim dtCPAPC03M As DataTable = DAO.GetDataByKind(PEKIND)
            If Not dtCPAPC03M Is Nothing Then
                For Each rowCPAPC03M As DataRow In dtCPAPC03M.Rows
                    'PCCODE = 15 : 加班前二小時倍數()
                    'PCCODE = 16 : 加班後二小時後倍數()
                    'PCCODE = 17 : 加班每日請領上限時數()
                    'PCCODE = 18 : 加班每月請領上限時數(男)
                    'PCCODE = 19 : 加班每月請領上限時數(女)
                    If rowCPAPC03M("PCCODE") = Param Then
                        reValue = rowCPAPC03M("PCPARM1")
                    End If
                Next
            End If
            Return reValue
        End Function

        Public Function GetPCPARM1(ByVal PCKIND As String, ByVal PCITEM As String, ByVal PCCODE As String) As String
            Dim dt As DataTable = DAO.GetDataByQuery(PCKIND, PCITEM, PCCODE)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Return ""
            End If
            Return dt.Rows(0)("PCPARM1").ToString()
        End Function

        Public Function GetWorkNoonDataByPCKIND(ByVal PCKIND As String) As Hashtable
            Dim dt As DataTable = DAO.GetWorktimeDataByPCKIND(PCKIND)
            Dim ht As New Hashtable

            'PCCODE=0 正常班, PCCODE=11 中午午休

            For Each dr As DataRow In dt.Rows
                If dr("PCCODE").ToString() = "0" Then
                    ht.Add("WORKTIMEB", dr("PCPARM1").ToString())
                    ht.Add("WORKTIMEE", dr("PCPARM2").ToString())
                End If
                If dr("PCCODE").ToString() = "2" Then
                    ht.Add("FLEXSTIMEB", dr("PCPARM1").ToString())
                    ht.Add("FLEXSTIMEE", dr("PCPARM2").ToString())
                End If
                If dr("PCCODE").ToString() = "3" Then
                    ht.Add("FLEXETIMEB", dr("PCPARM1").ToString())
                    ht.Add("FLEXETIMEE", dr("PCPARM2").ToString())
                End If
                If dr("PCCODE").ToString() = "4" Then
                    ht.Add("FLEXNOONTIMEB", dr("PCPARM1").ToString())
                    ht.Add("FLEXNOONTIMEE", dr("PCPARM2").ToString())
                End If
                If dr("PCCODE").ToString() = "11" Then
                    ht.Add("NOONTIMEB", dr("PCPARM1").ToString())
                    ht.Add("NOONTIMEE", dr("PCPARM2").ToString())
                End If

            Next

            Return ht
        End Function

        'by jessica add 1030102
        Public Function GetPCPARM2(ByVal PCKIND As String, ByVal PCITEM As String, ByVal PCCODE As String) As String
            Dim dt As DataTable = DAO.GetDataByQuery(PCKIND, PCITEM, PCCODE)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Return ""
            End If
            Return dt.Rows(0)("PCPARM2").ToString()
        End Function

        Public Function insertNewData(ByVal PCKIND As String) As Boolean
            Return DAO.insertNewData(PCKIND)
        End Function
    End Class
End Namespace