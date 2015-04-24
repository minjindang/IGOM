Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic

    Public Class Org
        Public DAO As OrgDAO


        Public Sub New()
            DAO = New OrgDAO()
        End Sub


#Region "Field"
        Private _Orgcode As String                  ' 1.機關代碼
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Private _OrgcodeName As String              ' 2.機關名稱 
        Public Property OrgcodeName() As String
            Get
                Return _OrgcodeName
            End Get
            Set(ByVal value As String)
                _OrgcodeName = value
            End Set
        End Property
        Private _OrgcodeShortname As String         ' 3.機關簡稱 
        Public Property OrgcodeShortname() As String
            Get
                Return _OrgcodeShortname
            End Get
            Set(ByVal value As String)
                _OrgcodeShortname = value
            End Set
        End Property
        Private _LogoFile As String
        Public Property LogoFile() As String
            Get
                Return _LogoFile
            End Get
            Set(ByVal value As String)
                _LogoFile = value
            End Set
        End Property
        Private _ChangeDate As Date = Now
        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal value As Date)
                _changeDate = value
            End Set
        End Property
        Private _ChangeUserid As String
        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(ByVal value As String)
                _changeUserid = value
            End Set
        End Property


#End Region

        Public Function insertData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Orgcode_name", OrgcodeName)
            d.Add("Orgcode_shortname", OrgcodeShortname)
            d.Add("Logo_file", LogoFile)
            d.Add("Change_userid", ChangeUserid)
            d.Add("Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.InsertByExample("SYS_org", d) > 0
        End Function

        Public Function updateData(ByVal UOrgcode As String) As Boolean
            Return DAO.updateData(Me, UOrgcode) > 0
        End Function


        Public Function GetColumnValue(columnName As String, orgcode As String) As String
            Dim dt As DataTable = DAO.GetDataByQuery(orgcode, "")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columnName).ToString()
            End If
            Return ""
        End Function


        Public Function GetDataByQuery(orgcode As String, orgcodeName As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByQuery(orgcode, orgcodeName)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function deleteByOrgcode(orgcode As String) As Boolean
            Return DAO.deleteByOrgcode(orgcode)
        End Function
    End Class
End Namespace