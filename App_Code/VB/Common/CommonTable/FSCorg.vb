Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class FSCorg
        Public DAO As FSCorgDAO
        Public Sub New()
            DAO = New FSCorgDAO()
        End Sub
#Region "Field"
        Private _Orgcode As String = String.Empty                   ' 1.機關代碼
        Private _Orgcode_name As String = String.Empty              ' 2.機關名稱 
        Private _Orgcode_shortname As String = String.Empty         ' 3.機關簡稱 
        Private _Depart_id As String = String.Empty                 ' 4.單位代碼 
        Private _Depart_name As String = String.Empty               ' 5.單位名稱 

        Private _Sub_depart_id As String = String.Empty             ' 6.次級單位代碼 
        Private _Sub_depart_name As String = String.Empty           ' 7.次級單位名稱
        Private _Seq As String = String.Empty
        Private _Visable_flag As String = String.Empty
        Private _Change_userid As String = String.Empty             ' 8.異動人員 
        Private _Change_date As Date = Date.MinValue        ' 10.異動日期
#End Region

#Region "Property"
        ''' <summary>
        ''' 機關代碼:組織架構檔,pk
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        ''' <summary>
        ''' 機關名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode_name() As String
            Get
                Return _Orgcode_name
            End Get
            Set(ByVal value As String)
                _Orgcode_name = value
            End Set
        End Property
        ''' <summary>
        ''' 機關簡稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode_shortname() As String
            Get
                Return _Orgcode_shortname
            End Get
            Set(ByVal value As String)
                _Orgcode_shortname = value
            End Set
        End Property
        ''' <summary>
        ''' 單位代碼:組織架構檔,pk
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        ''' <summary>
        ''' 單位名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Depart_name() As String
            Get
                Return _Depart_name
            End Get
            Set(ByVal value As String)
                _Depart_name = value
            End Set
        End Property

        ''' <summary>
        ''' 次級單位代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Sub_depart_id() As String
            Get
                Return _Sub_depart_id
            End Get
            Set(ByVal value As String)
                _Sub_depart_id = value
            End Set
        End Property
        ''' <summary>
        ''' 次級單位名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Sub_depart_name() As String
            Get
                Return _Sub_depart_name
            End Get
            Set(ByVal value As String)
                _Sub_depart_name = value
            End Set
        End Property
        Public Property Seq() As String
            Get
                Return _Seq
            End Get
            Set(ByVal value As String)
                _Seq = value
            End Set
        End Property
        Public Property Visable_flag() As String
            Get
                Return _Visable_flag
            End Get
            Set(ByVal value As String)
                _Visable_flag = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        ''' <summary>
        ''' 異動日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Function insertData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Orgcode_name", Orgcode_name)
            d.Add("Orgcode_shortname", Orgcode_shortname)
            d.Add("Depart_id", Depart_id)
            d.Add("Depart_name", Depart_name)
            d.Add("Sub_depart_id", Sub_depart_id)
            d.Add("Sub_depart_name", Sub_depart_name)
            d.Add("Seq", Seq)
            d.Add("Visable_flag", Visable_flag)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("FSCorg", d) > 0
        End Function


        Public Function updateData(ByVal UOrgcode As String, ByVal UDepart_id As String, ByVal USub_depart_id As String) As Boolean

            Return DAO.updateData(Me, UOrgcode, UDepart_id, USub_depart_id) > 0
        End Function

        Public Function deleteData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Sub_depart_id", Sub_depart_id)
            Return DAO.deleteByExample("FSCorg", d) > 0
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetOrgcode() As DataTable
            Dim ds As DataSet = DAO.GetData("")
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetOrgcode(ByVal Orgcode As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDepartByOrgcodeDepartID(ByVal Orgcode As String, ByVal DepartID As String) As DataTable
            Dim ds As DataSet = DAO.GetDepartNameByOrgcodeDepartID(Orgcode, DepartID)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByODS(Orgcode, Depart_id, Sub_depart_id)
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetOrgcodeByOrgcode(ByVal Orgcode As String) As DataTable
            Return DAO.GetDataByOrgcode(Orgcode).Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDepartByNotLikeDepartId(ByVal DepartID As String) As DataTable
            Return DAO.GetDepartByNotLikeDepartId(DepartID).Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDepart(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode, Depart_id, Role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetSub_depart(ByVal Orgcode As String, ByVal Depart_id As String) As DataTable
            Dim ds As DataSet = DAO.GetSub_depart(Orgcode, Depart_id, "")
            Return ds.Tables(0)
        End Function

        Public Function GetSub_depart(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As DataTable
            Dim ds As DataSet = DAO.GetSub_depart(Orgcode, Depart_id, Sub_depart_id)
            Return ds.Tables(0)
        End Function

        Public Function GetOrgcodeName(ByVal Orgcode As String) As String
            Dim dt As DataTable = GetOrgcodeByOrgcode(Orgcode)
            If dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)("OrgcodeName").ToString()
        End Function

        Public Function GetLongOrgcodeName(ByVal Orgcode As String) As String
            Dim dt As DataTable = GetOrgcodeByOrgcode(Orgcode)
            If dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)("Orgcode_name").ToString()
        End Function

        Public Function GetDepartName(ByVal Orgcode As String, ByVal DepartID As String) As String
            Dim dt As DataTable = GetDepartByOrgcodeDepartID(Orgcode, DepartID)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)("Depart_name").ToString()
        End Function

        Public Function GetSubDepartName(ByVal Orgcode As String, ByVal DepartID As String, ByVal SubDepartId As String) As String
            Dim dt As DataTable = GetDepartByOrgcodeDepartID(Orgcode, DepartID)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return String.Empty
            For Each dr As DataRow In dt.Rows
                If dr("Sub_depart_id").Equals(SubDepartId) Then
                    Return dr("Sub_depart_name").ToString()
                End If
            Next
            Return String.Empty
        End Function

        Public Function GetDataByCondition(ByVal Orgcode As String, ByVal DepartID As String, ByVal SubDepartID As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByCondition(Orgcode, DepartID, SubDepartID)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDepartByRole_id(ByVal Orgcode As String, ByVal Role_id As String) As DataTable
            Return DAO.GetDepartByRole_id(Orgcode, Role_id).Tables(0)
        End Function

        Public Function GetDepartIdAndNameByOrgcodeDepartID(ByVal Orgcode As String, ByVal DepartID As String) As DataTable
            Dim ds As DataSet = DAO.GetDepartIdAndNameByOrgcodeDepartID(Orgcode, DepartID)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

    End Class
End Namespace