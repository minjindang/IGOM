Imports Microsoft.VisualBasic
Imports System.Data
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPO15M
        Public DAO As CPAPO15MDAO

#Region "Property"
        Private _Orgcode As String
        Private _Depart_id As String
        Private _POIDNO As String
        Private _PONAME As String
        Private _POCARD As String
        Private _POVTYPE As String
        Private _POVDATEB As String
        Private _POVDATEE As String
        Private _POVTIMEB As String
        Private _POVTIMEE As String
        Private _POVDAYS As Double
        Private _POHOLIDAY As String
        Private _POTDATE As String
        Private _POREMARK As String
        Private _POGUID As String
        Private _POREMARK_TYPE As String
        Private _POUPDATE As String
        Private _POUSERID As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property DepartId() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property POIDNO() As String
            Get
                Return _POIDNO
            End Get
            Set(ByVal value As String)
                _POIDNO = value
            End Set
        End Property
        Public Property PONAME() As String
            Get
                Return _PONAME
            End Get
            Set(ByVal value As String)
                _PONAME = value
            End Set
        End Property
        Public Property POCARD() As String
            Get
                Return _POCARD
            End Get
            Set(ByVal value As String)
                _POCARD = value
            End Set
        End Property
        Public Property POVTYPE() As String
            Get
                Return _POVTYPE
            End Get
            Set(ByVal value As String)
                _POVTYPE = value
            End Set
        End Property
        Public Property POVDATEB() As String
            Get
                Return _POVDATEB
            End Get
            Set(ByVal value As String)
                _POVDATEB = value
            End Set
        End Property
        Public Property POVDATEE() As String
            Get
                Return _POVDATEE
            End Get
            Set(ByVal value As String)
                _POVDATEE = value
            End Set
        End Property
        Public Property POVTIMEB() As String
            Get
                Return _POVTIMEB
            End Get
            Set(ByVal value As String)
                _POVTIMEB = value
            End Set
        End Property
        Public Property POVTIMEE() As String
            Get
                Return _POVTIMEE
            End Get
            Set(ByVal value As String)
                _POVTIMEE = value
            End Set
        End Property
        Public Property POVDAYS() As Double
            Get
                Return _POVDAYS
            End Get
            Set(ByVal value As Double)
                _POVDAYS = value
            End Set
        End Property
        Public Property POHOLIDAY() As String
            Get
                Return _POHOLIDAY
            End Get
            Set(ByVal value As String)
                _POHOLIDAY = value
            End Set
        End Property
        Public Property POTDATE() As String
            Get
                Return _POTDATE
            End Get
            Set(ByVal value As String)
                _POTDATE = value
            End Set
        End Property
        Public Property POREMARK() As String
            Get
                Return _POREMARK
            End Get
            Set(ByVal value As String)
                _POREMARK = value
            End Set
        End Property
        Public Property POGUID() As String
            Get
                Return _POGUID
            End Get
            Set(ByVal value As String)
                _POGUID = value
            End Set
        End Property
        Public Property POREMARK_TYPE() As String
            Get
                Return _POREMARK_TYPE
            End Get
            Set(ByVal value As String)
                _POREMARK_TYPE = value
            End Set
        End Property
        Public Property POUPDATE() As String
            Get
                Return _POUPDATE
            End Get
            Set(ByVal value As String)
                _POUPDATE = value
            End Set
        End Property
        Public Property POUSERID() As String
            Get
                Return _POUSERID
            End Get
            Set(ByVal value As String)
                _POUSERID = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPO15MDAO()
        End Sub

        Public Function GetAllYearData(ByVal POIDNO As String, ByVal YYY As String) As DataTable
            Return DAO.GetAllYearData(POIDNO, YYY)
        End Function

        Public Function GetQueryData(ByVal POIDNO As String, ByVal POVTYPE As String, ByVal YYYMM As String) As DataTable
            Return DAO.GetDataByYM(POIDNO, POVTYPE, YYYMM)
        End Function

        Function getData(ByVal idNo As String, ByVal startDate As String, ByVal endDate As String) As DataTable
            Return DAO.GetData(idNo, startDate, endDate)
        End Function


        Public Function GetCPAPO15MByFlow_id(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As DataTable
            Dim dt As DataTable = DAO.GetDataByFlow_id(Flow_id, Orgcode)
            Return dt
        End Function

        'Public Function getHaveHoursByDate(ByVal POIDNO As String, ByVal POVTYPE As String, ByVal POVDATEB As String, _
        '                                   Optional ByVal cpaDAO As CPAPO15MDAO = Nothing, Optional ByVal DAO As CPAPO15MDAO = Nothing) As Integer

        '    If cpaDAO Is Nothing Or DAO Is Nothing Then
        '        '申請者的Metadb_id, 用來判斷連線的資料庫
        '        DAO = New CPAPO15MDAO()
        '    End If

        '    Dim hours As Integer = 0
        '    Dim YM As String = POVDATEB.Substring(0, 3).ToString()

        '    If Me.POVTYPE = "24" Then   '生理假
        '        YM = POVDATEB.Substring(0, 5).ToString()
        '    End If

        '    'If Me.TOTAL_HOURS = 0 Then
        '    'p2k
        '    Dim cpadt As DataTable = cpaDAO.GetDataByYM(POIDNO, POVTYPE, YM, True)
        '    For Each dr As DataRow In cpadt.Rows
        '        hours += Content.ConvertToHours(CType(dr("POVDAYS").ToString, Double))
        '    Next
        '    'plm
        '    Dim dt As DataTable = DAO.GetDataByYM(POIDNO, POVTYPE, YM)
        '    For Each dr As DataRow In dt.Rows
        '        hours += Content.ConvertToHours(CType(dr("POVDAYS").ToString, Double))
        '    Next
        '    'End If

        '    Return hours
        'End Function


        'Public Function getHaveHoursByTDate(ByVal POIDNO As String, ByVal POVTYPE As String, ByVal POTDATE As String, _
        '                                  Optional ByVal cpaDAO As CPAPO15MDAO = Nothing, Optional ByVal DAO As CPAPO15MDAO = Nothing) As Integer

        '    If cpaDAO Is Nothing Or DAO Is Nothing Then
        '        '申請者的Metadb_id, 用來判斷連線的資料庫
        '        Dim Metadb_id As String = New Member().GetColumnValue("Metadb_id", POIDNO)
        '        Dim p2kConnstring As String = ConnectDB.GetCPADBString(Metadb_id)
        '        Dim plmConnstring As String = ConnectDB.GetDBString()

        '        cpaDAO = New CPAPO15MDAO()
        '        DAO = New CPAPO15MDAO()
        '    End If

        '    Dim hours As Integer = 0

        '    'If Me.TOTAL_HOURS = 0 Then
        '    'p2k
        '    Dim cpadt As DataTable = cpaDAO.GetDataByPOTDATE(POIDNO, POVTYPE, POTDATE, , True)
        '    For Each dr As DataRow In cpadt.Rows
        '        hours += Content.ConvertToHours(Double.Parse(dr("POVDAYS").ToString()))     '已存在資料庫的時數
        '    Next
        '    'plm
        '    Dim dt As DataTable = DAO.GetDataByPOTDATE(POIDNO, POVTYPE, POTDATE)
        '    For Each dr As DataRow In dt.Rows
        '        hours += Content.ConvertToHours(Double.Parse(dr("POVDAYS").ToString()))     '已存在資料庫的時數
        '    Next
        '    'End If

        '    Return hours
        'End Function


        Public Function InsertCPAPO15M() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        ''' <summary>
        ''' for修改重送 jessica add
        ''' </summary>
        ''' <param name="isP2K"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateCPAPO15M(Optional ByVal isP2K As Boolean = False) As Boolean
            Return DAO.UpdateCPAPO15M(Me, isP2K)
        End Function

        Public Function GetCountByDateTime(ByVal Start_datetime As String, ByVal End_datetime As String, ByVal Apply_id As String, Optional ByVal isP2K As Boolean = False) As Integer
            Dim count As Integer = 0
            Dim dt As DataTable = DAO.GetDataByDateTime(Start_datetime, End_datetime, Apply_id, isP2K)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                count = dt.Rows.Count
            End If
            Return count
        End Function

        '人立新增0710 for FSC3104_01
        Public Function GetDataByPoguid(ByVal flow_id As String) As DataTable
            Return DAO.GetDataByPoguid(flow_id)
        End Function

        Public Function DeleteCPAPO15MByGUID(ByVal flow_id As String, Optional ByVal Orgcode As String = Nothing) As Boolean
            Return DAO.DeleteDataByGUID(flow_id, Orgcode) = 1
        End Function

        Public Function GetleaveData(ByVal POIDNO As String, ByVal VDATE As String) As DataTable
            Return DAO.GetLeaveData(POIDNO, VDATE)
        End Function


        Public Function GetDataByPK(ByVal POIDNO As String, ByVal POVTYPE As String, ByVal POVDATEB As String, ByVal POVTIMEB As String) As DataTable
            Return DAO.GetDataByPK(POIDNO, POVTYPE, POVDATEB, POVTIMEB)
        End Function

    End Class
End Namespace