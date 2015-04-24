Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPB02M
        Public DAO As CPAPB02MDAO

#Region "property"
        Private _Orgcode As String
        Private _DepartId As String
        Private _PBDDATE As String
        Private _PBDWEEK As String
        Private _PBDTYPE As String
        Private _PBDDESC As String
        Private _ChangeUserid As String

        Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Property DepartId() As String
            Get
                Return _DepartId
            End Get
            Set(ByVal value As String)
                _DepartId = value
            End Set
        End Property
        Property PBDDATE() As String
            Get
                Return _PBDDATE
            End Get
            Set(ByVal value As String)
                _PBDDATE = value
            End Set
        End Property
        Property PBDWEEK() As String
            Get
                Return _PBDWEEK
            End Get
            Set(ByVal value As String)
                _PBDWEEK = value
            End Set
        End Property
        Property PBDTYPE() As String
            Get
                Return _PBDTYPE
            End Get
            Set(ByVal value As String)
                _PBDTYPE = value
            End Set
        End Property
        Property PBDDESC() As String
            Get
                Return _PBDDESC
            End Get
            Set(ByVal value As String)
                _PBDDESC = value
            End Set
        End Property
        Property ChangeUserid() As String
            Get
                Return _ChangeUserid
            End Get
            Set(ByVal value As String)
                _ChangeUserid = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New CPAPB02MDAO()
        End Sub

        Public Sub New(ByVal conn As System.Data.SqlClient.SqlConnection)
            DAO = New CPAPB02MDAO(conn)
        End Sub

        Public Function insert() As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", DepartId)
            d.Add("PBDDATE", PBDDATE)
            d.Add("PBDWEEK", PBDWEEK)
            d.Add("PBDTYPE", PBDTYPE)
            d.Add("PBDDESC", PBDDESC)
            d.Add("Change_userid", ChangeUserid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_CPAPB02M", d)
        End Function

        Public Function update() As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("PBDTYPE", PBDTYPE)
            d.Add("PBDDESC", PBDDESC)
            d.Add("Change_userid", ChangeUserid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("PBDDATE", PBDDATE)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Depart_id", DepartId)

            Return DAO.UpdateByExample("FSC_CPAPB02M", d, cd)
        End Function

        Public Function getDataByPBDDATE(ByVal PBDDATE As String) As DataTable

            Dim d As New Dictionary(Of String, Object)
            d.Add("PBDDATE", PBDDATE)

            Return DAO.GetDataByExample("FSC_CPAPB02M", d)
        End Function

        Public Function getData(ByVal yyymm As String) As DataTable
            Return DAO.GetDataByYYYMM(yyymm)
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal yyymm As String) As DataTable
            Return DAO.GetDataByYYYMM(Orgcode, "", yyymm)
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal yyymm As String) As DataTable
            Return DAO.GetDataByYYYMM(Orgcode, Depart_id, yyymm)
        End Function

        Public Function getDataByYYY(ByVal yyy As String) As DataTable
            Return DAO.GetDataByYYY(yyy)
        End Function

        Public Function GetOffDateByPBDDATE(ByVal Start_date As String, ByVal End_date As String) As DataTable
            Return DAO.GetOffDateByPBDDATE(Start_date, End_date)
        End Function

        Public Function IsHoliday(ByVal PBDDATE As String) As Boolean
            Dim dt As DataTable = DAO.getPBDTypeByPBDDate(PBDDATE)
            If dt.Rows.Count <= 0 Then
                Return False
            End If
            If dt.Rows(0)("PBDTYPE").ToString() = "2" Then
                Return True
            End If
            Return False
        End Function

        Public Function GetLimitDate(ByVal OccurDate As String, ByVal days As Integer, Optional ByVal isworkday As Boolean = False) As String
            Dim dt As DataTable = DAO.GetDataByOccurDate(OccurDate, days, isworkday)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Return ""
            End If
            If dt.Rows.Count < days Then
                Return "日曆檔資料不足，無法正確計算"
            End If
            Return dt.Rows(dt.Rows.Count - 1)(0).ToString()
        End Function

        Public Function getWorkDaysCount(ByVal yyymm As String) As Integer
            Dim dt As DataTable = DAO.getWorkDays(yyymm)
            If dt Is Nothing Then
                Return 0
            End If
            Return dt.Rows.Count
        End Function

        Public Function getWorkDaysCount(ByVal yyymm As String, ByVal quitDate As String) As Integer
            Dim dt As DataTable = DAO.getWorkDays(yyymm, quitDate)
            If dt Is Nothing Then
                Return 0
            End If
            Return dt.Rows.Count
        End Function

        Public Function GetDayByDate(ByVal Start_date As String, ByVal End_date As String) As DataTable
            Return DAO.GetDayByDate(Start_date, End_date)
        End Function

        Public Function GetDataByUserID(ByVal UserID As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByUserID(UserID, StartDate, EndDate)
            Return dt
        End Function

        ''' <summary>
        ''' for匯入年度行事曆，做批次更新
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Sub Batch_Insert(dt As DataTable)
            DAO.Batch_Insert(dt)
        End Sub

    End Class
End Namespace