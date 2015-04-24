Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    Public Class PaySalChgNoticSendList
        Private DAO As PaySalChgNoticSendListDAO

        Public Sub New()
            DAO = New PaySalChgNoticSendListDAO
        End Sub

#Region "Property"
        Private _Send_orgcode As String
        Public Property Send_orgcode() As String
            Get
                Return _Send_orgcode
            End Get
            Set(ByVal value As String)
                _Send_orgcode = value
            End Set
        End Property

        Private _Send_departid As String
        Public Property Send_departid() As String
            Get
                Return _Send_departid
            End Get
            Set(ByVal value As String)
                _Send_departid = value
            End Set
        End Property

        Private _Send_idcard As String
        Public Property Send_idcard() As String
            Get
                Return _Send_idcard
            End Get
            Set(ByVal value As String)
                _Send_idcard = value
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
#End Region
        
        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Send_orgcode", Send_orgcode)
            d.Add("Send_departid", Send_departid)
            d.Add("Send_idcard", Send_idcard)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("SAL_PaySalChgNotic_SendList", d)
        End Function

        Public Function delete() As Boolean
            Return DAO.delete() = 1
        End Function

        Public Function getDataByOrg() As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Send_orgcode", Send_orgcode)

            Return DAO.GetDataByExample("SAL_PaySalChgNotic_SendList", d)
        End Function
    End Class
End Namespace
