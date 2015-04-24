Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class PaperFile
        Private DAO As PaperFileDAO
#Region "Properity"
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Private _DepartId As String
        Public Property DepartId() As String
            Get
                Return _DepartId
            End Get
            Set(ByVal value As String)
                _DepartId = value
            End Set
        End Property
        Private _FileName As String
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property
        Private _RealName As String
        Public Property RealName() As String
            Get
                Return _RealName
            End Get
            Set(ByVal value As String)
                _RealName = value
            End Set
        End Property
        Private _Path As String
        Public Property Path() As String
            Get
                Return _Path
            End Get
            Set(ByVal value As String)
                _Path = value
            End Set
        End Property
        Private _ChangeUserid As String
        Public Property ChangeUserid() As String
            Get
                Return _ChangeUserid
            End Get
            Set(ByVal value As String)
                _ChangeUserid = value
            End Set
        End Property
        Private _ChangeDate As Date = Now
        Public Property ChangeDate() As Date
            Get
                Return _ChangeDate
            End Get
            Set(ByVal value As Date)
                _ChangeDate = value
            End Set
        End Property
        Private _Start_date As String
        Public Property Start_date() As String
            Get
                Return _Start_date
            End Get
            Set(ByVal value As String)
                _Start_date = value
            End Set
        End Property
        Private _End_date As String
        Public Property End_date() As String
            Get
                Return _End_date
            End Get
            Set(ByVal value As String)
                _End_date = value
            End Set
        End Property
        Private _removed_flag As String
        Public Property removed_flag() As String
            Get
                Return _removed_flag
            End Get
            Set(ByVal value As String)
                _removed_flag = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New PaperFileDAO()
        End Sub

        Public Function InsertData() As Boolean
            Return DAO.InsertData(Me) > 0
        End Function

        Public Function UpdateData(ByVal id As Integer) As Integer
            Return DAO.UpdateData(Me, id) > 0
        End Function

        Public Function GetDataByOuery(orgcode As String, departId As String) As DataTable
            Return DAO.GetDataByOuery(orgcode, departId)
        End Function

        Public Function DeleteById(id As Integer) As Boolean
            Return DAO.DeleteById(id) > 0
        End Function

        Public Function GetDataById(id As Integer) As DataTable
            Return DAO.GetDataById(id)
        End Function

        Public Function GetData(orgcode As String, departId As String) As DataTable
            Return DAO.GetData(orgcode, departId)
        End Function
    End Class
End Namespace