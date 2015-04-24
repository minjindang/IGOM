Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    <System.ComponentModel.DataObject()> _
    Public Class Org
        Public DAO As OrgDAO

        Public Sub New()
            DAO = New OrgDAO()
        End Sub


        Public Sub New(ByVal conn As System.Data.SqlClient.SqlConnection)
            DAO = New OrgDAO(conn)
        End Sub

#Region "Field"
        Private _Orgcode As String                  ' 1.機關代碼
        Private _OrgcodeName As String              ' 2.機關名稱 
        Private _OrgcodeShortname As String         ' 3.機關簡稱 
        Private _departId As String                 ' 4.單位代碼 
        Private _departName As String               ' 5.單位名稱 
        Private _departSname As String              ' 6.次級單位代碼 
        Private _parentDepartId As String           ' 7.次級單位名稱
        Private _Seq As Integer
        Private _visableFlag As String
        Private _departLevel As String
        Private _ChangeCode As String
        Private _changeUserid As String             ' 8.異動人員 
        Private _changeDate As Date                 ' 10.異動日期

        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal value As Date)
                _changeDate = value
            End Set
        End Property

        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(ByVal value As String)
                _changeUserid = value
            End Set
        End Property

        Public Property ChangeCode() As String
            Get
                Return _ChangeCode
            End Get
            Set(ByVal value As String)
                _ChangeCode = value
            End Set
        End Property

        Public Property DepartLevel() As String
            Get
                Return _departLevel
            End Get
            Set(ByVal value As String)
                _departLevel = value
            End Set
        End Property

        Public Property VisableFlag() As String
            Get
                Return _visableFlag
            End Get
            Set(ByVal value As String)
                _visableFlag = value
            End Set
        End Property

        Public Property Seq() As Integer
            Get
                Return _Seq
            End Get
            Set(ByVal value As Integer)
                _Seq = value
            End Set
        End Property

        Public Property ParentDepartId() As String
            Get
                Return _parentDepartId
            End Get
            Set(ByVal value As String)
                _parentDepartId = value
            End Set
        End Property

        Public Property DepartSname() As String
            Get
                Return _departSname
            End Get
            Set(ByVal value As String)
                _departSname = value
            End Set
        End Property

        Public Property DepartName() As String
            Get
                Return _departName
            End Get
            Set(ByVal value As String)
                _departName = value
            End Set
        End Property

        Public Property DepartId() As String
            Get
                Return _departId
            End Get
            Set(ByVal value As String)
                _departId = value
            End Set
        End Property

        Public Property OrgcodeShortname() As String
            Get
                Return _OrgcodeShortname
            End Get
            Set(ByVal value As String)
                _OrgcodeShortname = value
            End Set
        End Property

        Public Property OrgcodeName() As String
            Get
                Return _OrgcodeName
            End Get
            Set(ByVal value As String)
                _OrgcodeName = value
            End Set
        End Property

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

#End Region

        Public Function insertData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Orgcode_name", OrgcodeName)
            d.Add("Orgcode_shortname", OrgcodeShortname)
            d.Add("Depart_id", DepartId)
            d.Add("Depart_name", DepartName)
            d.Add("Depart_sname", DepartSname)
            d.Add("Parent_depart_id", ParentDepartId)
            d.Add("Seq", Seq)
            d.Add("Visable_flag", VisableFlag)
            d.Add("Depart_Level", DepartLevel)
            d.Add("ChangeCode", ChangeCode)
            d.Add("Change_userid", ChangeUserid)
            d.Add("Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.InsertByExample("FSC_org", d) > 0
        End Function

        Public Function updateData(ByVal UOrgcode As String, ByVal UDepart_id As String) As Boolean
            Return DAO.updateData(Me, UOrgcode, UDepart_id) > 0
        End Function

        Public Function deleteData(ByVal Orgcode As String, ByVal Depart_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            Return DAO.DeleteByExample("FSC_org", d) > 0
        End Function

        Public Function GetOrgcode() As DataTable
            Dim dt As DataTable = DAO.GetOrgocde()
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataByDepartid(ByVal orgcode As String, ByVal DepartId As String) As DataRow
            Dim dt As DataTable = DAO.GetDataByDid(orgcode, DepartId)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return Nothing
            Return dt.Rows(0)
        End Function

        Public Function GetDataByParentDepartid(ByVal orgcode As String, ByVal parentDepartId As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByPdid(orgcode, parentDepartId)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetOrgcodeName(ByVal orgcode As String) As String
            Dim name As String = ""
            Dim dt As DataTable = DAO.GetData(orgcode)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                name = dt.Rows(0)("Orgcode_name").ToString()
            End If
            Return name
        End Function

        Public Function GetOrgcodeSName(ByVal orgcode As String) As String
            Dim name As String = ""
            Dim dt As DataTable = DAO.GetData(orgcode)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                name = dt.Rows(0)("Orgcode_shortname").ToString()
            End If
            Return name
        End Function

        Public Function GetDepartName(ByVal orgcode As String, ByVal departId As String) As String
            Dim name As String = ""
            Dim dt As DataTable = DAO.GetData(orgcode, departId)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                name = dt.Rows(0)("Depart_name").ToString()
            End If
            Return name
        End Function

        Public Function GetDepartNameWithoutSubDepart(ByVal orgcode As String, ByVal departId As String) As String
            Dim name As String = ""
            Dim dt As DataTable = DAO.getDataWithoutParentId(orgcode, departId)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                name = dt.Rows(0)("Depart_name").ToString()
            End If
            Return name
        End Function

        Public Function GetData(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim dt As DataTable = DAO.GetData(orgcode, departId)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataWithSubDepart(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim dt As DataTable = DAO.GetDataWithSubDepart(orgcode, departId)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataWithSubDepart(ByVal orgcode As String, ByVal departId As String, ByVal Depart_Level As String) As DataTable
            Dim dt As DataTable = DAO.GetDataWithSubDepart(orgcode, departId, Depart_Level)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataByOrg(ByVal orgcode As String) As DataTable
            Dim dt As DataTable = DAO.GetData(orgcode, "")
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
        Public Function GetDataByOrgAndParentId(ByVal orgcode As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByOrgAndParentId(orgcode)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace