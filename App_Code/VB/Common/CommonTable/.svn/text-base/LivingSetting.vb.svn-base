Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class LivingSetting

        Private _Orgcode As String
        Private _Master_code As String
        Private _Detail_code As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Master_code() As String
            Get
                Return _Master_code
            End Get
            Set(ByVal value As String)
                _Master_code = value
            End Set
        End Property
        Public Property Detail_code() As String
            Get
                Return _Detail_code
            End Get
            Set(ByVal value As String)
                _Detail_code = value
            End Set
        End Property

        Public DAO As LivingSettingDAO
        Public Sub New()
            DAO = New LivingSettingDAO
        End Sub


        Public Function Insert() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function GetDataByMasterCode(ByVal Orgcode As String, ByVal Master_code As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByMasterCode(Orgcode, Master_code)
            Return ds.Tables(0)
        End Function

        Public Function GetDataByDetailCode(ByVal Orgcode As String, ByVal Master_code As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByDetailCode(Orgcode, Master_code)
            Return ds.Tables(0)
        End Function

        Public Function DeleteById(ByVal id As String) As Boolean
            Return DAO.DeleteById(id) = 1
        End Function
    End Class
End Namespace
