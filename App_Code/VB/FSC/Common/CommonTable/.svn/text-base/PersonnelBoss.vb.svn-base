Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class PersonnelBoss
        Dim DAO As PersonnelBossDAO

        Public Sub New()
            DAO = New PersonnelBossDAO()
        End Sub
#Region "Property"
        Private _Orgcode As String
        Private _Depart_id As String
        Private _Id_card As String
        Private _Service_type As String
        Private _Boss_orgcode As String
        Private _Boss_departid As String
        Private _Boss_posid As String
        Private _Boss_idcard As String
        Private _Boss_stype As String
        Private _Change_userid As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property IdCard() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property
        Public Property Service_type() As String
            Get
                Return _Service_type
            End Get
            Set(ByVal value As String)
                _Service_type = value
            End Set
        End Property
        Public Property Boss_orgcode() As String
            Get
                Return _Boss_orgcode
            End Get
            Set(ByVal value As String)
                _Boss_orgcode = value
            End Set
        End Property
        Public Property Boss_departid() As String
            Get
                Return _Boss_departid
            End Get
            Set(ByVal value As String)
                _Boss_departid = value
            End Set
        End Property
        Public Property Boss_posid() As String
            Get
                Return _Boss_posid
            End Get
            Set(ByVal value As String)
                _Boss_posid = value
            End Set
        End Property
        Public Property Boss_idcard() As String
            Get
                Return _Boss_idcard
            End Get
            Set(ByVal value As String)
                _Boss_idcard = value
            End Set
        End Property
        Public Property Boss_stype() As String
            Get
                Return _Boss_stype
            End Get
            Set(ByVal value As String)
                _Boss_stype = value
            End Set
        End Property
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
#End Region

        Public Function GetData(orgcode As String, departId As String, idCard As String, serviceType As String) As DataTable
            Return DAO.GetData(orgcode, departId, idCard, serviceType)
        End Function

        Public Function GetData(orgcode As String, departId As String, idCard As String, serviceType As String, level As Integer) As DataTable
            Dim dt As New DataTable()
            For i As Integer = 0 To level - 1
                dt = GetData(orgcode, departId, idCard, serviceType)
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    Return Nothing
                End If
                orgcode = dt.Rows(0)("Boss_orgcode").ToString()
                departId = dt.Rows(0)("Boss_departid").ToString()
                idCard = dt.Rows(0)("Boss_idcard").ToString()
                serviceType = dt.Rows(0)("Boss_stype").ToString()
            Next
            Return dt
        End Function

        Public Function Insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Id_card", IdCard)
            d.Add("Service_type", Service_type)
            d.Add("Boss_orgcode", Boss_orgcode)
            d.Add("Boss_departid", Boss_departid)
            d.Add("Boss_posid", Boss_posid)
            d.Add("Boss_idcard", Boss_idcard)
            d.Add("Boss_stype", Boss_stype)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Date.Now)

            Return DAO.InsertByExample("FSC_Personnel_Boss", d) >= 1
        End Function

        Public Function Update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Boss_orgcode", Boss_orgcode)
            d.Add("Boss_departid", Boss_departid)
            d.Add("Boss_posid", Boss_posid)
            d.Add("Boss_idcard", Boss_idcard)
            d.Add("Boss_stype", Boss_stype)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Date.Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Depart_id", Depart_id)
            cd.Add("Id_card", IdCard)
            cd.Add("Service_type", Service_type)

            Return DAO.UpdateByExample("FSC_Personnel_Boss", d, cd) >= 1
        End Function
    End Class
End Namespace