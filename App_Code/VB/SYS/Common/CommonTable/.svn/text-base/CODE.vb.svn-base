Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace SYS.Logic
    Public Class CODE
        Public DAO As CODEDAO

#Region "property"
        Private _CODE_SYS As String
        Public Property CODE_SYS() As String
            Get
                Return _CODE_SYS
            End Get
            Set(ByVal value As String)
                _CODE_SYS = value
            End Set
        End Property

        Private _CODE_KIND As String
        Public Property CODE_KIND() As String
            Get
                Return _CODE_KIND
            End Get
            Set(ByVal value As String)
                _CODE_KIND = value
            End Set
        End Property

        Private _CODE_TYPE As String
        Public Property CODE_TYPE() As String
            Get
                Return _CODE_TYPE
            End Get
            Set(ByVal value As String)
                _CODE_TYPE = value
            End Set
        End Property

        Private _CODE_NO As String
        Public Property CODE_NO() As String
            Get
                Return _CODE_NO
            End Get
            Set(ByVal value As String)
                _CODE_NO = value
            End Set
        End Property

        Private _CODE_DESC1 As String
        Public Property CODE_DESC1() As String
            Get
                Return _CODE_DESC1
            End Get
            Set(ByVal value As String)
                _CODE_DESC1 = value
            End Set
        End Property

        Private _CODE_DESC2 As String
        Public Property CODE_DESC2() As String
            Get
                Return _CODE_DESC2
            End Get
            Set(ByVal value As String)
                _CODE_DESC2 = value
            End Set
        End Property

        Private _CODE_REMARK1 As String
        Public Property CODE_REMARK1() As String
            Get
                Return _CODE_REMARK1
            End Get
            Set(ByVal value As String)
                _CODE_REMARK1 = value
            End Set
        End Property

        Private _CODE_REMARK2 As String
        Public Property CODE_REMARK2() As String
            Get
                Return _CODE_REMARK2
            End Get
            Set(ByVal value As String)
                _CODE_REMARK2 = value
            End Set
        End Property

        Private _CODE_SORT As Integer
        Public Property CODE_SORT() As Integer
            Get
                Return _CODE_SORT
            End Get
            Set(ByVal value As Integer)
                _CODE_SORT = value
            End Set
        End Property

        Private _CODE_MUSERID As String
        Public Property CODE_MUSERID() As String
            Get
                Return _CODE_MUSERID
            End Get
            Set(ByVal value As String)
                _CODE_MUSERID = value
            End Set
        End Property

        Private _CODE_ORGID As String
        Public Property CODE_ORGID() As String
            Get
                Return _CODE_ORGID
            End Get
            Set(ByVal value As String)
                _CODE_ORGID = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New CODEDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("CODE_SYS", CODE_SYS)
            d.Add("CODE_KIND", CODE_KIND)
            d.Add("CODE_TYPE", CODE_TYPE)
            d.Add("CODE_NO", CODE_NO)
            d.Add("CODE_DESC1", CODE_DESC1)
            d.Add("CODE_DESC2", CODE_DESC2)
            d.Add("CODE_REMARK1", CODE_REMARK1)
            d.Add("CODE_REMARK2", CODE_REMARK2)
            d.Add("CODE_SORT", CODE_SORT)
            d.Add("CODE_MUSERID", CODE_MUSERID)
            d.Add("CODE_MDATE", Now.ToString("yyyyMMddhhmmss"))
            d.Add("CODE_ORGID", CODE_ORGID)

            Return DAO.InsertByExample("SYS_CODE", d)
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("CODE_KIND", CODE_KIND)
            d.Add("CODE_DESC1", CODE_DESC1)
            d.Add("CODE_DESC2", CODE_DESC2)
            d.Add("CODE_REMARK1", CODE_REMARK1)
            d.Add("CODE_REMARK2", CODE_REMARK2)
            d.Add("CODE_SORT", CODE_SORT)
            d.Add("CODE_MUSERID", CODE_MUSERID)
            d.Add("CODE_MDATE", Now.ToString("yyyyMMddhhmmss"))

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("CODE_SYS", CODE_SYS)
            cd.Add("CODE_TYPE", CODE_TYPE)
            cd.Add("CODE_NO", CODE_NO)
            cd.Add("CODE_ORGID", CODE_ORGID)

            Return DAO.UpdateByExample("SYS_CODE", d, cd)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("CODE_SYS", CODE_SYS)
            d.Add("CODE_TYPE", CODE_TYPE)
            d.Add("CODE_NO", CODE_NO)
            d.Add("CODE_ORGID", CODE_ORGID)

            Return DAO.DeleteByExample("SYS_CODE", d)
        End Function

        Public Function GetData(ByVal CODE_Sys As String, ByVal CODE_Type As String) As DataTable
            Dim dt As DataTable
            dt = DAO.GetData(CODE_Sys, CODE_Type)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataDESC(ByVal CODE_Sys As String, ByVal CODE_Type As String, ByVal CODE_NO As String) As String
            Dim dt As DataTable = DAO.GetData(CODE_Sys, CODE_Type, CODE_NO)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("CODE_DESC1").ToString()
            Else
                Return ""
            End If
        End Function

        Public Function GetFSCTitleName(ByVal CODE_NO As String) As String
            Dim dt As DataTable = DAO.GetData("023", "012", CODE_NO)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("CODE_DESC1").ToString()
            Else
                Return ""
            End If
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal CODE_NO As String) As DataTable
            Return DAO.GetData(Orgcode, CODE_SYS, CODE_TYPE, CODE_NO)
        End Function
    End Class
End Namespace