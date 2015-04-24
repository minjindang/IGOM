Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OldMember
        Public DAO As OldMemberDAO

        Public Sub New()
            DAO = New OldMemberDAO()
        End Sub

        Public Sub New(ByVal conn As SqlClient.SqlConnection)
            DAO = New OldMemberDAO(conn)
        End Sub

#Region "Field"
        Private _Id_card As String
        Private _Personnel_id As String
        Private _Title_no As String
        Private _Orgcode As String
        Private _Depart_id As String
        Private _Sub_depart_id As String
        Private _Dupety_active As System.Nullable(Of Integer)
        Private _User_name As String
        Private _User_password As String
        Private _Email As String
        Private _Employee_type As String
        Private _Role_id As String
        Private _Login_status As System.Nullable(Of Integer)
        Private _Login_id As String
        Private _Login_type As String
        Private _Privelege As System.Nullable(Of Integer)
        Private _Peo_type As System.Nullable(Of Integer)
        Private _Metadb_id As System.Nullable(Of Integer)
        Private _Abnormalqut As System.Nullable(Of Integer)
        Private _Boss_orgcode As String
        Private _Boss_departid As String
        Private _Boss_posid As String
        Private _Boss_idcard As String
        Private _Budget_type As String
        Private _Delete_flag As String
        Private _Quit_job_flag As String
        Private _Change_userid As String
        Private _Change_date As System.Nullable(Of Date)
        Private _Message_YN As System.Nullable(Of Char)
        Private _Email_YN As System.Nullable(Of Char)
        Private _Frequency As System.Nullable(Of Char)
        Private _Send_time1 As String
        Private _Send_time2 As String
        Private _Send_time3 As String
        Private _Send_time4 As String
        Private _Send_time5 As String
        Private _Send_time6 As String
        Private _Deputy_active As System.Nullable(Of Char)
        Private _Emp_no As String
        Private _AD_idno As String
        Private _Office_tel As String
        Private _Office_ext As String
        Private _Indigenous_flag As String
        Private _Join_sdate As String
        Private _Cold_dates As String
        Private _Cold_datee As String
        'CPAPE05M
        Private _Checkin_sdate As String
        Private _Join_edate As String
        Private _Reser_sdate As String
        Private _Return_date As String
        Private _PER_SERIL_NO As String
        Private _Deputy_active_idcard As String
        Private _Old_login_type As String
        Private _Elected_officials_flag As String
        Private _PEHYEAR As String
        Private _PEHDAY As String
        Private _PEKIND As System.Nullable(Of Char)
        Private _PEWKTYPE As System.Nullable(Of Char)
        Private _PESEX As System.Nullable(Of Char)
        Private _PEBIRTHD As String
        Private _PECRKCOD As String
        Private _PEMEMCOD As System.Nullable(Of Char)
        Private _PEOVERHFEE As System.Nullable(Of Integer)
        Private _PEOVERDATE As String
        Private _PEOLDFEE As System.Nullable(Of Integer)
        Private _PEACTDATE As String
        Private _PELEVDATE As String
        Private _PEPOINT As String
        Private _PEPROFESS As System.Nullable(Of Integer)
        Private _PECHIEF As System.Nullable(Of Integer)
        Private _PEYKIND As System.Nullable(Of Char)
        Private _PERDAY As System.Nullable(Of Double)
        Private _PERDAY1 As System.Nullable(Of Double)
        Private _PERDAY2 As System.Nullable(Of Double)
        Private _PEALIMT As System.Nullable(Of Double)
        Private _PEBLIMT As System.Nullable(Of Double)
        Private _PEPAYDAYA As System.Nullable(Of Double)
        Private _PEPAYDAYB As System.Nullable(Of Double)
        Private _PEPAYHDAY As System.Nullable(Of Integer)
        Private _PERDAYK As String
        Private _PETITSEQ As String
        Private _PEDUSEQ As String
        Private _PECARDVER As String
        Private _PEUSERID As String
        Private _PEUPDATE As String
        Private _PEHMON As String
        Private _PEHDAY2 As System.Nullable(Of Double)


        
#End Region

#Region "Property"
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

        Public Property Dupety_active() As System.Nullable(Of Integer)
            Get
                Return Me._Dupety_active
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Dupety_active.Equals(value) = False) Then
                    Me._Dupety_active = value
                End If
            End Set
        End Property

        Public Property User_name() As String
            Get
                Return Me._User_name
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._User_name, value) = False) Then
                    Me._User_name = value
                End If
            End Set
        End Property

        Public Property User_password() As String
            Get
                Return Me._User_password
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._User_password, value) = False) Then
                    Me._User_password = value
                End If
            End Set
        End Property

        Public Property Email() As String
            Get
                Return Me._Email
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Email, value) = False) Then
                    Me._Email = value
                End If
            End Set
        End Property

        Public Property Employee_type() As String
            Get
                Return Me._Employee_type
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Employee_type, value) = False) Then
                    Me._Employee_type = value
                End If
            End Set
        End Property

        Public Property Role_id() As String
            Get
                Return Me._Role_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Role_id, value) = False) Then
                    Me._Role_id = value
                End If
            End Set
        End Property

        Public Property Login_status() As System.Nullable(Of Integer)
            Get
                Return Me._Login_status
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Login_status.Equals(value) = False) Then
                    Me._Login_status = value
                End If
            End Set
        End Property

        Public Property Login_id() As String
            Get
                Return Me._Login_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Login_id, value) = False) Then
                    Me._Login_id = value
                End If
            End Set
        End Property

        Public Property Login_type() As String
            Get
                Return Me._Login_type
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Login_type, value) = False) Then
                    Me._Login_type = value
                End If
            End Set
        End Property

        Public Property Privelege() As System.Nullable(Of Integer)
            Get
                Return Me._Privelege
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Privelege.Equals(value) = False) Then
                    Me._Privelege = value
                End If
            End Set
        End Property

        Public Property Peo_type() As System.Nullable(Of Integer)
            Get
                Return Me._Peo_type
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Peo_type.Equals(value) = False) Then
                    Me._Peo_type = value
                End If
            End Set
        End Property

        Public Property Metadb_id() As System.Nullable(Of Integer)
            Get
                Return Me._Metadb_id
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Metadb_id.Equals(value) = False) Then
                    Me._Metadb_id = value
                End If
            End Set
        End Property

        Public Property Abnormalqut() As System.Nullable(Of Integer)
            Get
                Return Me._Abnormalqut
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Abnormalqut.Equals(value) = False) Then
                    Me._Abnormalqut = value
                End If
            End Set
        End Property

        Public Property Boss_orgcode() As String
            Get
                Return Me._Boss_orgcode
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Boss_orgcode, value) = False) Then
                    Me._Boss_orgcode = value
                End If
            End Set
        End Property

        Public Property Boss_departid() As String
            Get
                Return Me._Boss_departid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Boss_departid, value) = False) Then
                    Me._Boss_departid = value
                End If
            End Set
        End Property

        Public Property Boss_posid() As String
            Get
                Return Me._Boss_posid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Boss_posid, value) = False) Then
                    Me._Boss_posid = value
                End If
            End Set
        End Property

        Public Property Boss_idcard() As String
            Get
                Return Me._Boss_idcard
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Boss_idcard, value) = False) Then
                    Me._Boss_idcard = value
                End If
            End Set
        End Property

        Public Property Budget_type() As String
            Get
                Return Me._Budget_type
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Budget_type, value) = False) Then
                    Me._Budget_type = value
                End If
            End Set
        End Property

        Public Property Delete_flag() As String
            Get
                Return Me._Delete_flag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Delete_flag, value) = False) Then
                    Me._Delete_flag = value
                End If
            End Set
        End Property

        Public Property Quit_job_flag() As String
            Get
                Return Me._Quit_job_flag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Quit_job_flag, value) = False) Then
                    Me._Quit_job_flag = value
                End If
            End Set
        End Property

        Public Property Change_userid() As String
            Get
                Return Me._Change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Change_userid, value) = False) Then
                    Me._Change_userid = value
                End If
            End Set
        End Property

        Public Property Change_date() As System.Nullable(Of Date)
            Get
                Return Me._Change_date
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                If (Me._Change_date.Equals(value) = False) Then
                    Me._Change_date = value
                End If
            End Set
        End Property

        Public Property Message_YN() As System.Nullable(Of Char)
            Get
                Return Me._Message_YN
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._Message_YN.Equals(value) = False) Then
                    Me._Message_YN = value
                End If
            End Set
        End Property

        Public Property Email_YN() As System.Nullable(Of Char)
            Get
                Return Me._Email_YN
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._Email_YN.Equals(value) = False) Then
                    Me._Email_YN = value
                End If
            End Set
        End Property

        Public Property Frequency() As System.Nullable(Of Char)
            Get
                Return Me._Frequency
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._Frequency.Equals(value) = False) Then
                    Me._Frequency = value
                End If
            End Set
        End Property

        Public Property Send_time1() As String
            Get
                Return Me._Send_time1
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Send_time1, value) = False) Then
                    Me._Send_time1 = value
                End If
            End Set
        End Property

        Public Property Send_time2() As String
            Get
                Return Me._Send_time2
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Send_time2, value) = False) Then
                    Me._Send_time2 = value
                End If
            End Set
        End Property

        Public Property Send_time3() As String
            Get
                Return Me._Send_time3
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Send_time3, value) = False) Then
                    Me._Send_time3 = value
                End If
            End Set
        End Property

        Public Property Send_time4() As String
            Get
                Return Me._Send_time4
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Send_time4, value) = False) Then
                    Me._Send_time4 = value
                End If
            End Set
        End Property

        Public Property Send_time5() As String
            Get
                Return Me._Send_time5
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Send_time5, value) = False) Then
                    Me._Send_time5 = value
                End If
            End Set
        End Property

        Public Property Send_time6() As String
            Get
                Return Me._Send_time6
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Send_time6, value) = False) Then
                    Me._Send_time6 = value
                End If
            End Set
        End Property

        Public Property Deputy_active() As System.Nullable(Of Char)
            Get
                Return Me._Deputy_active
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._Deputy_active.Equals(value) = False) Then
                    Me._Deputy_active = value
                End If
            End Set
        End Property

        Public Property Emp_no() As String
            Get
                Return Me._Emp_no
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Emp_no, value) = False) Then
                    Me._Emp_no = value
                End If
            End Set
        End Property

        Public Property AD_idno() As String
            Get
                Return Me._AD_idno
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._AD_idno, value) = False) Then
                    Me._AD_idno = value
                End If
            End Set
        End Property

        Public Property PEHYEAR() As String
            Get
                Return Me._PEHYEAR
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PEHYEAR, value) = False) Then
                    Me._PEHYEAR = value
                End If
            End Set
        End Property


        Public Property PEHDAY() As String
            Get
                Return Me._PEHDAY
            End Get
            Set(ByVal value As String)
                Me._PEHDAY = value
            End Set
        End Property

        Public Property PEKIND() As System.Nullable(Of Char)
            Get
                Return Me._PEKIND
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._PEKIND.Equals(value) = False) Then
                    Me._PEKIND = value
                End If
            End Set
        End Property

        Public Property PESEX() As System.Nullable(Of Char)
            Get
                Return Me._PESEX
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._PESEX.Equals(value) = False) Then
                    Me._PESEX = value
                End If
            End Set
        End Property

        Public Property PEBIRTHD() As String
            Get
                Return Me._PEBIRTHD
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PEBIRTHD, value) = False) Then
                    Me._PEBIRTHD = value
                End If
            End Set
        End Property

        Public Property PECRKCOD() As String
            Get
                Return Me._PECRKCOD
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PECRKCOD, value) = False) Then
                    Me._PECRKCOD = value
                End If
            End Set
        End Property

        Public Property PEMEMCOD() As System.Nullable(Of Char)
            Get
                Return Me._PEMEMCOD
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._PEMEMCOD.Equals(value) = False) Then
                    Me._PEMEMCOD = value
                End If
            End Set
        End Property

        Public Property PEACTDATE() As String
            Get
                Return Me._PEACTDATE
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PEACTDATE, value) = False) Then
                    Me._PEACTDATE = value
                End If
            End Set
        End Property

        Public Property PELEVDATE() As String
            Get
                Return Me._PELEVDATE
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PELEVDATE, value) = False) Then
                    Me._PELEVDATE = value
                End If
            End Set
        End Property

        Public Property PEPOINT() As String
            Get
                Return Me._PEPOINT
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._PEPOINT, value) = False) Then
                    Me._PEPOINT = value
                End If
            End Set
        End Property

        Public Property PEPROFESS() As System.Nullable(Of Integer)
            Get
                Return Me._PEPROFESS
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._PEPROFESS.Equals(value) = False) Then
                    Me._PEPROFESS = value
                End If
            End Set
        End Property

        Public Property PECHIEF() As System.Nullable(Of Integer)
            Get
                Return Me._PECHIEF
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._PECHIEF.Equals(value) = False) Then
                    Me._PECHIEF = value
                End If
            End Set
        End Property

        Public Property PEHDAY2() As System.Nullable(Of Double)
            Get
                Return Me._PEHDAY2
            End Get
            Set(ByVal value As System.Nullable(Of Double))
                If (Me._PEHDAY2.Equals(value) = False) Then
                    Me._PEHDAY2 = value
                End If
            End Set
        End Property

        Public Property PEWKTYPE() As System.Nullable(Of Char)
            Get
                Return Me._PEWKTYPE
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._PEWKTYPE.Equals(value) = False) Then
                    Me._PEWKTYPE = value
                End If
            End Set
        End Property

        Public Property Office_tel() As String
            Get
                Return Me._Office_tel
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Office_tel, value) = False) Then
                    Me._Office_tel = value
                End If
            End Set
        End Property

        Public Property Office_ext() As String
            Get
                Return Me._Office_ext
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Office_ext, value) = False) Then
                    Me._Office_ext = value
                End If
            End Set
        End Property

        Public Property Indigenous_flag() As String
            Get
                Return Me._Indigenous_flag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Indigenous_flag, value) = False) Then
                    Me._Indigenous_flag = value
                End If
            End Set
        End Property
        Public Property Join_sdate() As String
            Get
                Return _Join_sdate
            End Get
            Set(ByVal value As String)
                _Join_sdate = value
            End Set
        End Property
        Public Property Elected_officials_flag() As String
            Get
                Return _Elected_officials_flag
            End Get
            Set(ByVal value As String)
                _Elected_officials_flag = value
            End Set
        End Property
        Public Property Cold_dates() As String
            Get
                Return _Cold_dates
            End Get
            Set(ByVal value As String)
                _Cold_dates = value
            End Set
        End Property
        Public Property Cold_datee() As String
            Get
                Return _Cold_datee
            End Get
            Set(ByVal value As String)
                _Cold_datee = value
            End Set
        End Property
#End Region
        Public Function insert() As Boolean
            Return DAO.insert(Me) > 0
        End Function

        Public Function update() As Boolean
            Return DAO.update(Me) > 0
        End Function

        Public Function update(ByVal d As Dictionary(Of String, Object), ByVal cd As Dictionary(Of String, Object)) As Boolean

            Return DAO.updateByExample("Old_Member", d, cd) > 0
        End Function

        ''' <summary>
        ''' 取得主管資料
        ''' </summary>
        ''' <param name="Id_card">人員ID</param>
        ''' <param name="level">主管層級</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBoss(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal level As Integer) As DataTable
            Dim dt As DataTable = Nothing
            For i As Integer = 0 To level
                dt = GetDataByIDcard(Orgcode, Depart_id, Id_card)
                If dt.Rows.Count <= 0 Then Return Nothing
                Orgcode = dt.Rows(0)("Boss_orgcode").ToString()
                Depart_id = dt.Rows(0)("Boss_departid").ToString()
                Id_card = dt.Rows(0)("Boss_idcard").ToString()
            Next
            Return dt
        End Function

        Public Function GetTitle(ByVal Orgcode As String, ByVal DepartID As String, Optional ByVal Sub_departid As String = Nothing) As DataTable

            If DepartID.IndexOf(",") > 0 Then
                Dim deps() As String = DepartID.Split(",")
                DepartID = ""
                For Each dep As String In deps
                    DepartID &= "'" & dep & "',"
                Next
                DepartID = DepartID.TrimEnd(",")
            End If

            Dim ds As DataSet = DAO.GetTitle(Orgcode, DepartID, Sub_departid)
            If ds Is Nothing Then Return Nothing
            Dim dt As DataTable = ds.Tables(0)
            Return dt
        End Function

        Public Function GetDLLDataByODS(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Role_id As String, Optional ByVal Sub_depart_id As String = Nothing, Optional ByVal Title_no As String = Nothing, Optional ByVal Quit_job_Flag As String = "N", Optional ByVal Metadb_id As String = Nothing) As DataTable

            Dim ds As DataSet = DAO.GetDLLDataByODSTQM(Orgcode, Depart_id, Role_id, Sub_depart_id, Title_no, Quit_job_Flag, Metadb_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByIdcard(ByVal Id_card As String, Optional ByVal Include_Quit_job As Boolean = False) As DataTable
            If String.IsNullOrEmpty(Id_card) Then
                Return Nothing
            End If
            Dim ds As DataSet = DAO.GetDataByIDcard("", "", "", Id_card, "", Include_Quit_job)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataById(ByVal Id_card As String) As DataTable
            If String.IsNullOrEmpty(Id_card) Then
                Return Nothing
            End If
            Dim ds As DataSet = DAO.GetDataAll(Id_card)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDataByIDcard(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ID_card As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByIDcard(Orgcode, Depart_id, "", ID_card, "", True)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByIDcard(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String, ByVal ID_card As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByIDcard(Orgcode, Depart_id, Sub_depart_id, ID_card, "", True)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByIDcard(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String, ByVal ID_card As String, ByVal Include_Quit_job As Boolean) As DataTable
            Dim ds As DataSet = DAO.GetDataByIDcard(Orgcode, Depart_id, Sub_depart_id, ID_card, "", Include_Quit_job)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByIDcard(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String, ByVal ID_card As String, ByVal Personnel_id As String, ByVal Include_Quit_job As Boolean) As DataTable
            Dim ds As DataSet = DAO.GetDataByIDcard(Orgcode, Depart_id, Sub_depart_id, ID_card, Personnel_id, Include_Quit_job)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDLLDataByODR(ByVal Orgcode As String, ByVal DepartID As String, ByVal Role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDLLDataByODR(Orgcode, DepartID, Role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDLLDataByODR2(ByVal Orgcode As String, ByVal DepartID As String, ByVal Role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDLLDataByODR2(Orgcode, DepartID, "", Role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDLLDataByODR2(ByVal Orgcode As String, ByVal DepartID As String, ByVal Sub_depart_id As String, ByVal Role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDLLDataByODR2(Orgcode, DepartID, Sub_depart_id, Role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


        Public Function GetDLLDataByODRR(ByVal Orgcode As String, ByVal DepartID As String, ByVal Subdepid As String, ByVal Old_roleid As String, ByVal Role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDLLDataByODRR(Orgcode, DepartID, Subdepid, Old_roleid, Role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByTitle_no(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Title_no As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByTitle_no(Orgcode, Depart_id, "", Title_no)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


        Public Function GetDataByTitle_no(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String, ByVal Title_no As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByTitle_no(Orgcode, Depart_id, Sub_depart_id, Title_no)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDLLDataByODT2(ByVal Orgcode As String, ByVal DepartID As String, ByVal TitleNo As String) As DataTable
            Dim ds As DataSet = DAO.GetDLLDataByODT2(Orgcode, DepartID, TitleNo, "")
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetColumnValue(ByVal Column_name As String, ByVal Id_card As String)
            If String.IsNullOrEmpty(Id_card) Then
                Return String.Empty
            End If
            Dim dt As DataTable = GetDataByIdcard(Id_card, True)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)(Column_name).ToString
        End Function

        Public Function GetColumnValue(ByVal Column_name As String, ByVal Orgocde As String, ByVal Depart_id As String, ByVal Id_card As String)
            Dim dt As DataTable = GetDataByIdcard(Orgocde, Depart_id, Id_card)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)(Column_name).ToString
        End Function

        Public Function UpdateBOSS(ByVal Orgcode As String, ByVal DepartID As String, ByVal Id_Card As String, ByVal Boss_orgcode As String, ByVal Boss_departid As String, ByVal Boss_posid As String, ByVal Boss_idcard As String) As Boolean
            Return DAO.UpdateBOSS(Orgcode, DepartID, Id_Card, Boss_orgcode, Boss_departid, Boss_posid, Boss_idcard) = 1
        End Function

        Public Function DeleteIdcard(ByVal Orgcode As String, ByVal Id_card As String) As Boolean
            Return DAO.DeleteIdcard(Orgcode, Id_card) = 1
        End Function

        Public Function DeletePersonId(ByVal Orgcode As String, ByVal PersonnalID As String) As Boolean
            Return DAO.DeletePersonId(Orgcode, PersonnalID) = 1
        End Function

        Public Function UpdateQuit_job_flag(ByVal Quit_job_flag As String, ByVal Id_card As String) As Boolean
            Return DAO.UpdateQuit_job_flag(Quit_job_flag, Id_card) = 1
        End Function

        Public Function UpdateUserPassword(ByVal ID_card As String, ByVal User_password As String, ByVal Orgcode As String, ByVal DepartID As String, ByVal Change_userid As String) As Boolean
            Return DAO.UpdateUserPassword(ID_card, User_password, Orgcode, DepartID, Change_userid) > 0
        End Function

        Public Function UpdateBudgetType(ByVal ID_card As String, ByVal Budget_type As String, ByVal Change_userid As String, ByVal Orgcode As String) As Boolean
            Return DAO.UpdateBudgetType(ID_card, Budget_type, Change_userid, Orgcode) = 1
        End Function

        Public Function GetMemberByBudgetType(ByVal Orgcode As String, ByVal depart_id As String, ByVal Budget_type As String)
            Dim ds As DataSet = DAO.GetDataByBudgetType(Orgcode, depart_id, Budget_type)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetMemberByBudgetType(ByVal Orgcode As String, ByVal Budget_type As String)
            Dim ds As DataSet = DAO.GetDataByBudgetType(Orgcode, "", Budget_type)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        'Public Function GetUserSub_depart_id(ByVal Orgcode As String, ByVal User_id As String) As DataTable
        '    Return DAO.GetUserSub_depart_id(Orgcode, User_id).Tables(0)
        'End Function

        'Public Function GetDataBySub_depart_id(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As DataTable
        '    Return DAO.GetDataBySub_depart_id(Orgcode, Depart_id, Sub_depart_id).Tables(0)
        'End Function

        Public Function GetDetailCodeBymcIDdcID(ByVal Orgcode As String, ByVal MasterCodeID As String, ByVal Idno As String) As DataTable
            Dim ds As DataSet = DAO.GetDataBymcIDdcID(Orgcode, MasterCodeID, Idno)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDLLDataByODSR(ByVal Orgcode As String, ByVal DepartID As String, ByVal Sub_Depart_id As String, ByVal Role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDLLDataByODSR(Orgcode, DepartID, Sub_Depart_id, Role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetColumnByPersonnelId(ByVal Column_name As String, ByVal Personnel_id As String)
            If String.IsNullOrEmpty(Personnel_id) Then
                Return String.Empty
            End If
            Dim ds As DataSet = DAO.GetDataByPId(Personnel_id)
            If Not ds Is Nothing And ds.Tables.Count > 0 Then
                Dim dt As DataTable = ds.Tables(0)
                If Not dt Is Nothing And dt.Rows.Count > 0 Then
                    Return dt.Rows(0)(Column_name).ToString()
                End If
            End If
            Return ""
        End Function

    End Class
End Namespace