Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class Func
        Private DAO As FuncDAO
        Public Sub New()
            DAO = New FuncDAO()
        End Sub

#Region "Property"
        Private _Func_id As String
        Private _Func_name As String
        Private _Parent_func_id As String
        Private _Func_type As System.Nullable(Of Char)
        Private _Func_sort As System.Nullable(Of Integer)
        Private _Visable_type As System.Nullable(Of Char)
        Private _Func_url As String
        Private _Func_Memo As String
        Private _Change_userid As String
        Private _Change_date As Date

        Public Property Func_id() As String
            Get
                Return Me._Func_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Func_id, value) = False) Then
                    Me._Func_id = value
                End If
            End Set
        End Property

        Public Property Func_name() As String
            Get
                Return Me._Func_name
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Func_name, value) = False) Then
                    Me._Func_name = value
                End If
            End Set
        End Property

        Public Property Parent_func_id() As String
            Get
                Return Me._Parent_func_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Parent_func_id, value) = False) Then
                    Me._Parent_func_id = value
                End If
            End Set
        End Property

        Public Property Func_type() As System.Nullable(Of Char)
            Get
                Return Me._Func_type
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._Func_type.Equals(value) = False) Then
                    Me._Func_type = value
                End If
            End Set
        End Property

        Public Property Func_sort() As System.Nullable(Of Integer)
            Get
                Return Me._Func_sort
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                If (Me._Func_sort.Equals(value) = False) Then
                    Me._Func_sort = value
                End If
            End Set
        End Property

        Public Property Visable_type() As System.Nullable(Of Char)
            Get
                Return Me._Visable_type
            End Get
            Set(ByVal value As System.Nullable(Of Char))
                If (Me._Visable_type.Equals(value) = False) Then
                    Me._Visable_type = value
                End If
            End Set
        End Property

        Public Property Func_url() As String
            Get
                Return Me._Func_url
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Func_url, value) = False) Then
                    Me._Func_url = value
                End If
            End Set
        End Property

        Public Property Func_Memo() As String
            Get
                Return _Func_Memo
            End Get
            Set(ByVal value As String)
                _Func_Memo = value
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

        Public Property Change_date() As Date
            Get
                Return Me._Change_date
            End Get
            Set(ByVal value As Date)
                If ((Me._Change_date = value) _
                   = False) Then
                    Me._Change_date = value
                End If
            End Set
        End Property
#End Region


        Public Function GetFunc() As DataTable
            Return DAO.GetFunc()
        End Function

        Public Function getDataByPid(ByVal pid As String) As DataTable
            Dim dt As DataTable = DAO.getDataMenuByParentFuncId(pid)
            Return dt
        End Function

        Public Function getDataByFid(ByVal Func_id As String) As DataTable
            Dim dt As DataTable = DAO.getDataMenuByFuncId(Func_id)
            Return dt
        End Function

        Public Function insertData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Func_id", Func_id)
            d.Add("Func_name", Func_name)
            d.Add("Parent_func_id", Parent_func_id)
            d.Add("Func_type", Func_type)
            d.Add("Func_sort", Func_sort)
            d.Add("Visable_type", Visable_type)
            d.Add("Func_url", Func_url)
            d.Add("Func_Memo", Func_Memo)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("SYS_Func", d) > 0
        End Function

        Public Function updateData() As Boolean

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Func_id", Func_id)

            Dim d As New Dictionary(Of String, Object)
            d.Add("Func_name", Func_name)
            d.Add("Func_type", Func_type)
            d.Add("Func_sort", Func_sort)
            d.Add("Func_url", Func_url)
            d.Add("Func_Memo", Func_Memo)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.updateByExample("SYS_Func", d, cd) > 0
        End Function

        Public Function deleteData(ByVal Func_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Func_id", Func_id)
            Return DAO.deleteByExample("SYS_Func", d) > 0
        End Function

        Public Function getDataByUrl(ByVal Func_url As String) As DataTable
            Return DAO.getDataByUrl(Func_url)
        End Function
    End Class
End Namespace
