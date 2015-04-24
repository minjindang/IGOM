Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class CPAPX24M
        Private DAO As CPAPX24MDAO

#Region "Property"
        Private _Orgcode As String
        Private _PXIDNO As String
        Private _PXCARD As String
        Private _PXBREAKD As String
        Private _PXBREAKDE As String
        Private _PXBREAKH As Double
        Private _PXSTIME As String
        Private _PXETIME As String
        Private _PXADDD As String
        Private _PXADDE As String
        Private _PXTIMEB As String
        Private _PXTIMEE As String
        Private _PXUSERID As String
        Private _PXUPDATE As String
        Private _PXBIG As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

        ''' <summary>
        ''' 身分證字號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXIDNO() As String
            Get
                Return _PXIDNO
            End Get
            Set(ByVal value As String)
                _PXIDNO = value
            End Set
        End Property
        ''' <summary>
        ''' 員工代號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXCARD() As String
            Get
                Return _PXCARD
            End Get
            Set(ByVal value As String)
                _PXCARD = value
            End Set
        End Property
        ''' <summary>
        ''' 補休日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXBREAKD() As String
            Get
                Return _PXBREAKD
            End Get
            Set(ByVal value As String)
                _PXBREAKD = value
            End Set
        End Property
        ''' <summary>
        ''' 補休時數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXBREAKH() As Double
            Get
                Return _PXBREAKH
            End Get
            Set(ByVal value As Double)
                _PXBREAKH = value
            End Set
        End Property
        ''' <summary>
        ''' 出差起日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXADDD() As String
            Get
                Return _PXADDD
            End Get
            Set(ByVal value As String)
                _PXADDD = value
            End Set
        End Property
        Public Property PXADDE() As String
            Get
                Return _PXADDE
            End Get
            Set(ByVal value As String)
                _PXADDE = value
            End Set
        End Property

        Public Property PXTIMEB() As String
            Get
                Return _PXTIMEB
            End Get
            Set(ByVal value As String)
                _PXTIMEB = value
            End Set
        End Property
        Public Property PXTIMEE() As String
            Get
                Return _PXTIMEE
            End Get
            Set(ByVal value As String)
                _PXTIMEE = value
            End Set
        End Property

        ''' <summary>
        ''' Flow_id
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXUSERID() As String
            Get
                Return _PXUSERID
            End Get
            Set(ByVal value As String)
                _PXUSERID = value
            End Set
        End Property
        ''' <summary>
        ''' 異動日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXUPDATE() As String
            Get
                Return _PXUPDATE
            End Get
            Set(ByVal value As String)
                _PXUPDATE = value
            End Set
        End Property
        ''' <summary>
        ''' 事由
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PXBIG() As String
            Get
                Return _PXBIG
            End Get
            Set(ByVal value As String)
                _PXBIG = value
            End Set
        End Property


        Public Property PXBREAKDE() As String
            Get
                Return _PXBREAKDE
            End Get
            Set(ByVal value As String)
                _PXBREAKDE = value
            End Set
        End Property
        Public Property PXSTIME() As String
            Get
                Return _PXSTIME
            End Get
            Set(ByVal value As String)
                _PXSTIME = value
            End Set
        End Property
        Public Property PXETIME() As String
            Get
                Return _PXETIME
            End Get
            Set(ByVal value As String)
                _PXETIME = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPX24MDAO()
        End Sub

        Public Function GetCPAPX24MByFlow_Id(ByVal Flow_Id As String) As DataTable
            Return DAO.GetDataByFlow_Id(Flow_Id)
        End Function

        Public Function GetPXBREAKD(ByVal PXADDD As String, ByVal PXIDNO As String) As DataTable
            Return DAO.GetPXBREAKD(PXADDD, PXIDNO)
        End Function

        Public Function GetData(ByVal PXIDNO As String, ByVal PXADDD As String) As DataTable
            Return DAO.GetData(PXIDNO, PXADDD)
        End Function

        Public Function GetCPAPX24MByDate(ByVal pxidno As String, ByVal pxaddd As String, ByVal pxadde As String, ByVal pxtimeb As String, ByVal pxtimee As String) As DataTable
            Return DAO.GetDataByDate(pxidno, pxaddd, pxadde, pxtimeb, pxtimee)
        End Function

        Public Function CheckInsertData() As String
            If String.IsNullOrEmpty(Me.PXBIG) Then
                Return "事由為必填欄位!"
            End If
            If DateTimeInfo.GetPublicDate(Me.PXBREAKD) > DateTimeInfo.GetPublicDate(Me.PXADDD).AddMonths(6).AddDays(1) Then
                Return "補休日期已超過公差日期六個月，請重新申請!"
            End If

            ''申請者的Metadb_id, 用來判斷連線的資料庫
            'Dim Metadb_id As String = New Member().GetColumnValue("Metadb_id", Me.PXIDNO)
            'Dim p2kConnstring As String = ConnectDB.GetCPADBString(Metadb_id)
            'Dim plmConnstring As String = ConnectDB.GetDBString()

            'Dim cpaDAO As New CPAPX24MDAO(p2kConnstring)

            ''一筆公差日期是否有申請同個公差補休日期!
            'Dim cpacount As Integer = cpaDAO.GetCountByPK(Me.PXIDNO, Me.PXBREAKD, Me.PXADDD, True)
            'If cpacount > 0 Then
            '    Return "該公差日期已有相同補休日期的資料!"
            'End If

            'Dim count As Integer = DAO.GetCountByPK(Me.PXIDNO, Me.PXBREAKD, Me.PXADDD, False)
            'If count > 0 Then
            '    Return "該公差日期已有申請相同補休日期的資料!"
            'End If

            'Dim Total_Hours As Double = 0
            ''p2k
            'Dim cpadt As DataTable = cpaDAO.GetDataByDateTime(Me.PXIDNO, Me.PXADDD, Me.Old_Flow_id, True)
            'For Each dr As DataRow In cpadt.Rows
            '    Total_Hours += Integer.Parse(dr("PXBREAKH").ToString())     '已存在p2k資料庫的時數
            'Next
            ''plm
            'Dim dt As DataTable = DAO.GetDataByDateTime(Me.PXIDNO, PXADDD, Me.Old_Flow_id, False)
            'For Each dr As DataRow In dt.Rows
            '    Total_Hours += Integer.Parse(dr("PXBREAKH").ToString())     '已存在plm資料庫的時數
            'Next

            ''加上這次請領的時數
            'Total_Hours += Me.PXBREAKH

            'If Total_Hours > LeftHour Then
            '    Return "出差日" & Me.PXADDD & "已超過可補休上限(" & Content.ConvertDayHours(LeftHour) & "天)!"
            'End If

            'Dim pp16DAO As New CPAPP16MDAO(p2kConnstring)
            'Dim p2kdt As DataTable = pp16DAO.GetDataByDateTime(Me.PXBREAKD & Me.PXSTIME, Me.PXBREAKDE & Me.PXETIME, Me.PXIDNO, True)
            ''p2k
            'If p2kdt.Rows.Count > 0 Then
            '    Dim ss As String = String.Empty
            '    For Each dr As DataRow In p2kdt.Rows
            '        ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ","
            '    Next
            '    ss = ss.TrimEnd(",")
            '    Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重覆申請!"
            'End If

            'Dim plmDAO As New CPAPP16MDAO(plmConnstring)
            'Dim plmdt As DataTable = plmDAO.GetDataByDateTime(Me.PXBREAKD & Me.PXSTIME, Me.PXBREAKDE & Me.PXETIME, Me.PXIDNO, False)
            ''p2k
            'If plmdt.Rows.Count > 0 Then
            '    Dim ss As String = String.Empty
            '    For Each dr As DataRow In plmdt.Rows
            '        ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ","
            '    Next
            '    ss = ss.TrimEnd(",")
            '    Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重覆申請!"
            'End If

            Return String.Empty
        End Function

        Public Function InsertCPAPX24M() As Boolean
            Return DAO.InsertData(Me)
        End Function

        '人立新增0710 for FSC3104_01
        Function GetDataByPxuserid(ByVal flow_id As String, Optional ByVal Orgcode As String = Nothing) As DataTable
            Return DAO.GetDataByPxuserid(flow_id, Orgcode)
        End Function

        Public Function DeleteCPAPX24MByGUID(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As Boolean
            Return DAO.DeleteDataByGUID(Flow_id, Orgcode) = 1
        End Function


        Public Function UpdateFlag(ByVal PXUSER As String, ByVal STATUS As String) As Boolean
            Return DAO.UpdateFlag(PXUSER, STATUS) >= 1
        End Function

        Public Function UpdateCPAPX24M() As Boolean
            Return DAO.UpdateData(Me)
        End Function
    End Class
End Namespace