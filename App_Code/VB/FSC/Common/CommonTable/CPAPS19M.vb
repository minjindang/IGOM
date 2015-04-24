Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class CPAPS19M
        Private DAO As CPAPS19MDAO

#Region "Property"
        Private _id As Integer
        Private _Orgcode As String
        Private _PSIDNO As String
        Private _PSCARD As String
        Private _PSBREAKD As String
        Private _PSBREAKH As Double
        Private _PSADDD As String
        Private _PSADDE As String
        Private _PSSTIME As String
        Private _PSETIME As String
        Private _PSUSERID As String
        Private _PSUPDATE As String
        Private _PSBIG As String
        Private _PSBREAKDE As String
        Private _PSOVSTIME As String
        Private _PSOVETIME As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

        Public Property PSIDNO() As String
            Get
                Return _PSIDNO
            End Get
            Set(ByVal value As String)
                _PSIDNO = value
            End Set
        End Property
        Public Property PSCARD() As String
            Get
                Return _PSCARD
            End Get
            Set(ByVal value As String)
                _PSCARD = value
            End Set
        End Property
        Public Property PSBREAKD() As String
            Get
                Return _PSBREAKD
            End Get
            Set(ByVal value As String)
                _PSBREAKD = value
            End Set
        End Property
        Public Property PSBREAKH() As Double
            Get
                Return _PSBREAKH
            End Get
            Set(ByVal value As Double)
                _PSBREAKH = value
            End Set
        End Property
        Public Property PSADDD() As String
            Get
                Return _PSADDD
            End Get
            Set(ByVal value As String)
                _PSADDD = value
            End Set
        End Property
        Public Property PSADDE() As String
            Get
                Return _PSADDE
            End Get
            Set(ByVal value As String)
                _PSADDE = value
            End Set
        End Property
        Public Property PSSTIME() As String
            Get
                Return _PSSTIME
            End Get
            Set(ByVal value As String)
                _PSSTIME = value
            End Set
        End Property
        Public Property PSETIME() As String
            Get
                Return _PSETIME
            End Get
            Set(ByVal value As String)
                _PSETIME = value
            End Set
        End Property
        Public Property PSUSERID() As String
            Get
                Return _PSUSERID
            End Get
            Set(ByVal value As String)
                _PSUSERID = value
            End Set
        End Property
        Public Property PSUPDATE() As String
            Get
                Return _PSUPDATE
            End Get
            Set(ByVal value As String)
                _PSUPDATE = value
            End Set
        End Property
        Public Property PSBIG() As String
            Get
                Return _PSBIG
            End Get
            Set(ByVal value As String)
                _PSBIG = value
            End Set
        End Property
        Public Property PSBREAKDE() As String
            Get
                Return _PSBREAKDE
            End Get
            Set(ByVal value As String)
                _PSBREAKDE = value
            End Set
        End Property
        Public Property PSOVSTIME() As String
            Get
                Return _PSOVSTIME
            End Get
            Set(ByVal value As String)
                _PSOVSTIME = value
            End Set
        End Property
        Public Property PSOVETIME() As String
            Get
                Return _PSOVETIME
            End Get
            Set(ByVal value As String)
                _PSOVETIME = value
            End Set
        End Property

        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPS19MDAO()
        End Sub

        Public Function GetData(ByVal idno As String, ByVal YearMonth As String) As DataTable
            Return DAO.GetQueryData(idno, YearMonth)
        End Function

        Public Function GetCPAPS19MByFlow_Id(ByVal Flow_Id As String) As DataTable
            Return DAO.GetDataByFlow_id(Flow_Id)
        End Function

        Public Function GetCPAPS19MByDate(ByVal psidno As String, ByVal psaddd As String, ByVal psadde As String, psovstime As String, psovetime As String) As DataTable
            Return DAO.GetDataByDate(psidno, psaddd, psadde, psovstime, psovetime)
        End Function


        Public Function CheckInsertData() As String

            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim Flow_id As String = String.Empty

            If String.IsNullOrEmpty(Me.PSBIG) Then
                Return "事由為必填欄位!"
            End If
            If DateTimeInfo.GetPublicDate(Me.PSBREAKD) > DateTimeInfo.GetPublicDate(Me.PSADDD).AddMonths(6).AddDays(1) Then
                Return "補休日期已超過加班日期六個月，請重新申請!"
            End If

            'Dim dt As DataTable = GetCPAPS19MByPSADDD(Me.PSIDNO, Me.PSADDD)

            'Dim f As New Flow
            'For Each dr As DataRow In dt.Rows
            '    Flow_id = dr("PSUSERID").ToString()
            '    Dim fdt As DataTable = f.GetFlowByFlow_id(Flow_id, Orgcode)
            '    For Each fdr As DataRow In fdt.Rows
            '        If fdr("Last_pass").ToString() = "0" Then
            '            Return Me.PSADDD & "的加班資料已經正在申請補休，須待批核完畢後再行申請!"
            '        End If
            '    Next
            'Next

            '取得申請者的Metadb_id, 用來判斷連線的資料庫
            'Dim Metadb_id As String = New Member().GetColumnValue("Metadb_id", Me.PSIDNO)
            'Dim p2kConnstring As String = ConnectDB.GetCPADBString(Metadb_id)
            'Dim plmConnstring As String = ConnectDB.GetDBString()

            'Dim cpaDAO As New CPAPP16MDAO(p2kConnstring)
            'Dim p2kdt As DataTable = cpaDAO.GetDataByDateTime(Me.PSBREAKD & Me.PSSTIME, Me.PSBREAKDE & Me.PSETIME, Me.PSIDNO, True)
            ''p2k
            'If p2kdt.Rows.Count > 0 Then
            '    Dim ss As String = String.Empty
            '    For Each dr As DataRow In p2kdt.Rows
            '        ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ",\n"
            '    Next
            '    ss = Mid(ss, 1, ss.Length - 3)
            '    Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重覆申請!"
            'End If

            'Dim plmDAO As New CPAPP16MDAO(plmConnstring)
            'Dim plmdt As DataTable = plmDAO.GetDataByDateTime(Me.PSBREAKD & Me.PSSTIME, Me.PSBREAKDE & Me.PSETIME, Me.PSIDNO, False)
            ''plm
            'If plmdt.Rows.Count > 0 Then
            '    Dim ss As String = String.Empty
            '    For Each dr As DataRow In plmdt.Rows
            '        ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ",\n"
            '    Next
            '    ss = Mid(ss, 1, ss.Length - 3)
            '    Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重覆申請!"
            'End If

            Return String.Empty
        End Function

        Public Function InsertCPAPS19M() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function


        '人立新增0710 for FSC3104_01
        Public Function GetDataByPsuserid(ByVal Flow_Id As String, Optional ByVal Orgcode As String = Nothing) As DataTable
            Return DAO.GetDataByPsuserid(Flow_Id, Orgcode)
        End Function

        Public Function DeleteCPAPS19MByGUID(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As Boolean
            Return DAO.DeleteDataByGUID(Flow_id, Orgcode) = 1
        End Function


        Public Function UpdateFlag(ByVal PSUSERID As String, ByVal STATUS As String) As Boolean
            Return DAO.UpdateFlag(PSUSERID, STATUS) >= 1
        End Function

        Public Function UpdateCPAPS19M() As Boolean
            Return DAO.UpdateData(Me)
        End Function
    End Class
End Namespace