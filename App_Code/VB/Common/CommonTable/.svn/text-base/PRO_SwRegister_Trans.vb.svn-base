Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace PRO.Logic
    Public Class PRO_SwRegister_Trans
        Public DAO As PRO_SwRegister_TransDAO

        Public Sub New()
            DAO = New PRO_SwRegister_TransDAO()
        End Sub

#Region "property"
        Private _OrgCode As String
        Public Property OrgCode() As String
            Get
                Return _OrgCode
            End Get
            Set(ByVal value As String)
                _OrgCode = value
            End Set
        End Property

        Private _Flow_id As String
        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property

        Private _SR_Flow_id As String
        Public Property SR_Flow_id() As String
            Get
                Return _SR_Flow_id
            End Get
            Set(ByVal value As String)
                _SR_Flow_id = value
            End Set
        End Property

        Private _OldUnit_code As String
        Public Property OldUnit_code() As String
            Get
                Return _OldUnit_code
            End Get
            Set(ByVal value As String)
                _OldUnit_code = value
            End Set
        End Property

        Private _OldKeeper_id As String
        Public Property OldKeeper_id() As String
            Get
                Return _OldKeeper_id
            End Get
            Set(ByVal value As String)
                _OldKeeper_id = value
            End Set
        End Property

        Private _NewUnit_code As String
        Public Property NewUnit_code() As String
            Get
                Return _NewUnit_code
            End Get
            Set(ByVal value As String)
                _NewUnit_code = value
            End Set
        End Property

        Private _NewKeeper_id As String
        Public Property NewKeeper_id() As String
            Get
                Return _NewKeeper_id
            End Get
            Set(ByVal value As String)
                _NewKeeper_id = value
            End Set
        End Property

        Private _Trans_Apply_date As String
        Public Property Trans_Apply_date() As String
            Get
                Return _Trans_Apply_date
            End Get
            Set(ByVal value As String)
                _Trans_Apply_date = value
            End Set
        End Property

        Private _Trans_Allow_date As String
        Public Property Trans_Allow_date() As String
            Get
                Return _Trans_Allow_date
            End Get
            Set(ByVal value As String)
                _Trans_Allow_date = value
            End Set
        End Property

        Private _ModUser_id As String
        Public Property ModUser_id() As String
            Get
                Return _ModUser_id
            End Get
            Set(ByVal value As String)
                _ModUser_id = value
            End Set
        End Property
#End Region

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("OrgCode", OrgCode)
            d.Add("Flow_id", Flow_id)
            d.Add("SR_Flow_id", SR_Flow_id)
            d.Add("OldUnit_code", OldUnit_code)
            d.Add("OldKeeper_id", OldKeeper_id)
            d.Add("NewUnit_code", NewUnit_code)
            d.Add("NewKeeper_id", NewKeeper_id)
            d.Add("Trans_Apply_date", Trans_Apply_date)
            d.Add("Trans_Allow_date", Trans_Allow_date)
            d.Add("ModUser_id", ModUser_id)
            d.Add("Mod_date", Now)

            Return DAO.InsertByExample("PRO_SwRegister_Trans", d)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("OrgCode", OrgCode)
            d.Add("Flow_id", Flow_id)

            Return DAO.DeleteByExample("PRO_SwRegister_Trans", d)
        End Function

        Public Function updateAllow_date() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Trans_Allow_date", Trans_Allow_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("OrgCode", OrgCode)
            cd.Add("Flow_id", Flow_id)

            Return DAO.UpdateByExample("PRO_SwRegister_Trans", d, cd)
        End Function

        Public Function updateSWMain(ByVal Orgcode As String, ByVal Flow_id As String, ByVal NewUnit_code As String, ByVal NewKeeper_id As String) As Boolean
            Return DAO.updateSWMain(Orgcode, Flow_id, NewUnit_code, NewKeeper_id) >= 1
        End Function

        Public Function getDataByOrgFid(ByVal OrgCode As String, ByVal Flow_id As String) As DataTable
            Return DAO.getDataByOrgFid(OrgCode, Flow_id)
        End Function
    End Class
End Namespace
