Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class SACode
        Public DAO As SaCodeDAO

        Public Sub New()
            DAO = New SaCodeDAO
        End Sub

#Region "property"
        Private _codeSys As String
        Private _codeKind As String
        Private _codeType As String
        Private _codeNo As String
        Private _codeDesc1 As String
        Private _codeDesc2 As String
        Private _codeMuserid As String
        Private _codeMdate As Date
        Private _codeOrgid As String

        Public Property CodeSys() As String
            Get
                Return _codeSys
            End Get
            Set(ByVal value As String)
                _codeSys = value
            End Set
        End Property

        Public Property CodeKind() As String
            Get
                Return _codeKind
            End Get
            Set(ByVal value As String)
                _codeKind = value
            End Set
        End Property

        Public Property CodeType() As String
            Get
                Return _codeType
            End Get
            Set(ByVal value As String)
                _codeType = value
            End Set
        End Property

        Public Property CodeNo() As String
            Get
                Return _codeNo
            End Get
            Set(ByVal value As String)
                _codeNo = value
            End Set
        End Property

        Public Property CodeDesc1() As String
            Get
                Return _codeDesc1
            End Get
            Set(ByVal value As String)
                _codeDesc1 = value
            End Set
        End Property

        Public Property CodeDesc2() As String
            Get
                Return _codeDesc2
            End Get
            Set(ByVal value As String)
                _codeDesc2 = value
            End Set
        End Property

        Public Property CodeMuserid() As String
            Get
                Return _codeMuserid
            End Get
            Set(ByVal value As String)
                _codeMuserid = value
            End Set
        End Property

        Public Property CodeMdate() As Date
            Get
                Return _codeMdate
            End Get
            Set(ByVal value As Date)
                _codeMdate = value
            End Set
        End Property

        Public Property CodeOrgid() As String
            Get
                Return _codeOrgid
            End Get
            Set(ByVal value As String)
                _codeOrgid = value
            End Set
        End Property
#End Region

        Public Function GetCodeDesc(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal CODE_NO As String) As String
            Dim desc As String = ""
            Dim dr As DataRow = GetRow(CODE_SYS, CODE_TYPE, CODE_NO)
            If Not dr Is Nothing Then
                desc = dr("CODE_DESC1")
            End If
            Return desc
        End Function

        Public Function GetRow(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal CODE_NO As String) As DataRow
            If String.IsNullOrEmpty(CODE_NO) Then
                Return Nothing
            End If

            Return DAO.GetRow(CODE_SYS, CODE_TYPE, CODE_NO)
        End Function

        Public Function GetData(ByVal CODE_SYS As String, Optional CODE_TYPE As String = "") As DataTable
            Dim ds As DataSet = DAO.GetData(CODE_SYS, CODE_TYPE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData(ByVal ORG_ID As String, ByVal CODE_SYS As String, CODE_TYPE As String) As DataTable
            Dim ds As DataSet = DAO.GetData(ORG_ID, CODE_SYS, CODE_TYPE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData(ByVal CODE_REMARK1 As String, ByVal ORG_ID As String, ByVal CODE_SYS As String, CODE_TYPE As String) As DataTable
            Dim ds As DataSet = DAO.GetData(CODE_REMARK1, ORG_ID, CODE_SYS, CODE_TYPE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData2(ByVal CODE_SYS As String, ByVal CODE_KIND As String, ByVal CODE_TYPE As String) As DataTable
            Dim ds As DataSet = DAO.GetData2(CODE_SYS, CODE_KIND, CODE_TYPE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData2(ByVal ORG_ID As String, ByVal CODE_SYS As String, ByVal CODE_KIND As String, ByVal CODE_TYPE As String) As DataTable
            Dim ds As DataSet = DAO.GetData2(ORG_ID, CODE_SYS, CODE_KIND, CODE_TYPE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData2(ByVal CODE_REMARK1 As String, ByVal ORG_ID As String, ByVal CODE_SYS As String, ByVal CODE_KIND As String, ByVal CODE_TYPE As String) As DataTable
            Dim ds As DataSet = DAO.GetData2(CODE_REMARK1, ORG_ID, CODE_SYS, CODE_KIND, CODE_TYPE)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetTYPEData(ByVal CODE_SYS As String) As DataTable
            Dim ds As DataSet = DAO.GetTYPEData(CODE_SYS)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function updateCodeDesc2(codeSys As String, codeKind As String, codeType As String, codeNo As String, codeDesc2 As String) As Boolean
            Return DAO.updateCodeDesc2(codeSys, codeKind, codeType, codeNo, codeDesc2) = 1
        End Function
    End Class
End Namespace
