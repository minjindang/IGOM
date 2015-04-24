Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class Favorite
        Private DAO As FavoriteDAO

        Public Sub New()
            DAO = New FavoriteDAO()
        End Sub

#Region "Property"
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Private _Id_card As String
        Public Property Id_card() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property
        Private _Func_id As String
        Public Property Func_id() As String
            Get
                Return _Func_id
            End Get
            Set(ByVal value As String)
                _Func_id = value
            End Set
        End Property
        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Private _Change_date As Date = Now
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Function Insert() As Boolean
            Return DAO.Insert(Me) > 0
        End Function

        Public Function Delete() As Boolean
            Return DAO.Delete(Me) > 0
        End Function

        Public Function GetData(orgcode As String, idCard As String) As DataTable
            Return DAO.GetData(orgcode, idCard)
        End Function
    End Class
End Namespace