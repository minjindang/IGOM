Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class DUTY_fee
        Public DAO As DUTY_feeDAO
        Public Sub New()
            DAO = New DUTY_feeDAO()
        End Sub
#Region "Field"
        Private _Flow_id As String = String.Empty                   ' 1.流程編號
        Private _Merge_flow_id As String = String.Empty              ' 2.流程批號
        Private _User_id As String = String.Empty                   ' 3.人員編號
        Private _Apply_ym As String = String.Empty                  ' 4.值班年月
        Private _Duty_date As String = String.Empty                 ' 5.值班日期
        Private _ApplyHour_cnt As String = String.Empty             ' 6.值班時數
        Private _Apply_amt As String = String.Empty                 ' 7.值班費金額
        Private _Pay_date As String = String.Empty                  ' 8.發放日期
        Private _Org_code As String = String.Empty                  ' 9.單位編號
        Private _MEMO As String = String.Empty                      '10.備註
        Private _ModUser_id As String = String.Empty                '11.異動人員編號
        Private _Mod_date As String = String.Empty                  '12.異動時間

#End Region

#Region "Property"
        ''' <summary>
        ''' 流程編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property
        ''' <summary>
        ''' 流程批號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Merge_flow_id() As String
            Get
                Return _Merge_flow_id
            End Get
            Set(ByVal value As String)
                _Merge_flow_id = value
            End Set
        End Property
        ''' <summary>
        ''' 人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property User_id() As String
            Get
                Return _User_id
            End Get
            Set(ByVal value As String)
                _User_id = value
            End Set
        End Property
        ''' <summary>
        ''' 值班年月
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_ym() As String
            Get
                Return _Apply_ym
            End Get
            Set(ByVal value As String)
                _Apply_ym = value
            End Set
        End Property
        ''' <summary>
        ''' 值班日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Duty_date() As String
            Get
                Return _Duty_date
            End Get
            Set(ByVal value As String)
                _Duty_date = value
            End Set
        End Property
        ''' <summary>
        ''' 值班時數
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ApplyHour_cnt() As String
            Get
                Return _ApplyHour_cnt
            End Get
            Set(ByVal value As String)
                _ApplyHour_cnt = value
            End Set
        End Property
        ''' <summary>
        ''' 值班費金額
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_amt() As String
            Get
                Return _Apply_amt
            End Get
            Set(ByVal value As String)
                _Apply_amt = value
            End Set
        End Property
        ''' <summary>
        ''' 發放日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Pay_date() As String
            Get
                Return _Pay_date
            End Get
            Set(ByVal value As String)
                _Pay_date = value
            End Set
        End Property

        ''' <summary>
        ''' 單位編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Org_code() As String
            Get
                Return _Org_code
            End Get
            Set(ByVal value As String)
                _Org_code = value
            End Set
        End Property
        ''' <summary>
        ''' 備註
        ''' </summary>
        ''' <remarks></remarks>
        Public Property MEMO() As String
            Get
                Return _MEMO
            End Get
            Set(ByVal value As String)
                _MEMO = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ModUser_id() As String
            Get
                Return _ModUser_id
            End Get
            Set(ByVal value As String)
                _ModUser_id = value
            End Set
        End Property
        ''' <summary>
        ''' 異動時間
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Mod_date() As String
            Get
                Return _Mod_date
            End Get
            Set(ByVal value As String)
                _Mod_date = value
            End Set
        End Property

#End Region

        Public Function insertData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)
            d.Add("Merge_flow_id", Merge_flow_id)
            d.Add("User_id", User_id)
            d.Add("Apply_ym", Apply_ym)
            d.Add("Duty_date", Duty_date)
            d.Add("ApplyHour_cnt", ApplyHour_cnt)
            d.Add("Apply_amt", Apply_amt)
            d.Add("Pay_date", Pay_date)
            d.Add("Org_code", Org_code)
            d.Add("MEMO", MEMO)
            d.Add("ModUser_id", ModUser_id)
            d.Add("Mod_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("SAL_DUTY_fee", d) > 0
        End Function

        Public Function deleteData(ByVal Org_code As String, ByVal Flow_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)
            d.Add("Org_code", Org_code)
            Return DAO.deleteByExample("SAL_DUTY_fee", d) > 0
        End Function

        Public Function updatehours(ByVal Orgcode As String, ByVal Id_card As String, ByVal Sche_date As String, ByVal Pay_hours As String) As Boolean
            Dim upd As New Dictionary(Of String, Object)
            Dim d As New Dictionary(Of String, Object)
            upd.Add("Pay_hours", Pay_hours)
            d.Add("Sche_date", Sche_date)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)

            Return DAO.UpdateByExample("FSC_Schedule_setting", upd, d) > 0
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByUserId(Orgcode, UserId, Apply_ym)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function CheckInsert(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As Integer
            Dim ds As DataSet = DAO.CheckInsert(Orgcode, UserId, Apply_ym)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0).Rows.Count
        End Function


    End Class
End Namespace