Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class EXAMINE_fee
        Public DAO As EXAMINE_feeDAO
        Public Sub New()
            DAO = New EXAMINE_feeDAO()
        End Sub
#Region "Field"
        Private _Flow_id As String = String.Empty                   ' 1.流程編號
        Private _Merge_flow_id As String = String.Empty              ' 2.流程批號
        Private _User_id As String = String.Empty                   ' 3.人員編號
        Private _Meeting_date As String = String.Empty              ' 4.會議日期
        Private _Meeting_content As String = String.Empty           ' 5.會議說明
        Private _Apply_date As String = String.Empty                ' 7.申請日期
        Private _Meeting_pos As String = String.Empty               ' 6.出席人員身分別 審查委員/講師,SACODE.CODE_NO
        Private _Item_code As String = String.Empty                 ' 8.薪資項目        出席費/審查費/鐘點費,SAITEM.ITEM_CODE
        Private _Apply_amt As Integer = 0                           ' 9.申請金額
        Private _Pay_type As String = String.Empty                  '10.發放方式        付現/匯款,SACODE.CODE_NO
        Private _Pay_date As String = String.Empty                  '11.發放日期
        Private _Budget_code As String = String.Empty               '12.預算來源
        Private _Org_code As String = String.Empty                  '13.單位編號
        Private _BASE_IDNO As String = String.Empty
        Private _BASE_NAME As String = String.Empty
        Private _BASE_SERVICE_PLACE_DESC As String = String.Empty
        Private _BASE_DCODE_NAME As String = String.Empty
        Private _BASE_ADDR As String = String.Empty
        Private _BASE_BANK_CODE As String = String.Empty
        Private _BASE_BANK_NO As String = String.Empty
        Private _BANK_TDPF_SEQNO As String = String.Empty
        Private _ModUser_id As String = String.Empty
        Private _Mod_date As String = String.Empty

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
        ''' 會議日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Meeting_date() As String
            Get
                Return _Meeting_date
            End Get
            Set(ByVal value As String)
                _Meeting_date = value
            End Set
        End Property
        ''' <summary>
        ''' 會議說明
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Meeting_content() As String
            Get
                Return _Meeting_content
            End Get
            Set(ByVal value As String)
                _Meeting_content = value
            End Set
        End Property
        ''' <summary>
        ''' 申請日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_date() As String
            Get
                Return _Apply_date
            End Get
            Set(ByVal value As String)
                _Apply_date = value
            End Set
        End Property
        ''' <summary>
        ''' 出席人員身分別
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Meeting_pos() As String
            Get
                Return _Meeting_pos
            End Get
            Set(ByVal value As String)
                _Meeting_pos = value
            End Set
        End Property
        ''' <summary>
        ''' 薪資項目
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Item_code() As String
            Get
                Return _Item_code
            End Get
            Set(ByVal value As String)
                _Item_code = value
            End Set
        End Property
        ''' <summary>
        ''' 申請金額
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_amt() As Integer
            Get
                Return _Apply_amt
            End Get
            Set(ByVal value As Integer)
                _Apply_amt = value
            End Set
        End Property
        ''' <summary>
        ''' 發放方式
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Pay_type() As String
            Get
                Return _Pay_type
            End Get
            Set(ByVal value As String)
                _Pay_type = value
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
        ''' 預算來源
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Budget_code() As String
            Get
                Return _Budget_code
            End Get
            Set(ByVal value As String)
                _Budget_code = value
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
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_IDNO() As String
            Get
                Return _BASE_IDNO
            End Get
            Set(ByVal value As String)
                _BASE_IDNO = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_NAME() As String
            Get
                Return _BASE_NAME
            End Get
            Set(ByVal value As String)
                _BASE_NAME = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_SERVICE_PLACE_DESC() As String
            Get
                Return _BASE_SERVICE_PLACE_DESC
            End Get
            Set(ByVal value As String)
                _BASE_SERVICE_PLACE_DESC = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_DCODE_NAME() As String
            Get
                Return _BASE_DCODE_NAME
            End Get
            Set(ByVal value As String)
                _BASE_DCODE_NAME = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_ADDR() As String
            Get
                Return _BASE_ADDR
            End Get
            Set(ByVal value As String)
                _BASE_ADDR = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_BANK_CODE() As String
            Get
                Return _BASE_BANK_CODE
            End Get
            Set(ByVal value As String)
                _BASE_BANK_CODE = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BASE_BANK_NO() As String
            Get
                Return _BASE_BANK_NO
            End Get
            Set(ByVal value As String)
                _BASE_BANK_NO = value
            End Set
        End Property
        ''' <summary>
        ''' 異動人員編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BANK_TDPF_SEQNO() As String
            Get
                Return _BANK_TDPF_SEQNO
            End Get
            Set(ByVal value As String)
                _BANK_TDPF_SEQNO = value
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
            d.Add("Meeting_date", Meeting_date)
            d.Add("Meeting_content", Meeting_content)
            d.Add("Meeting_pos", Meeting_pos)
            d.Add("Apply_date", Apply_date)
            d.Add("Item_code", Item_code)
            d.Add("Apply_amt", Apply_amt)
            d.Add("Pay_type", Pay_type)
            d.Add("Pay_date", Pay_date)
            d.Add("Budget_code", Budget_code)
            d.Add("Org_code", Org_code)
            d.Add("BASE_IDNO", BASE_IDNO)
            d.Add("BASE_NAME", BASE_NAME)
            d.Add("BASE_SERVICE_PLACE_DESC", BASE_SERVICE_PLACE_DESC)
            d.Add("BASE_DCODE_NAME", BASE_DCODE_NAME)
            d.Add("BASE_ADDR", BASE_ADDR)
            d.Add("BASE_BANK_CODE", BASE_BANK_CODE)
            d.Add("BASE_BANK_NO", BASE_BANK_NO)
            d.Add("BANK_TDPF_SEQNO", BANK_TDPF_SEQNO)
            d.Add("ModUser_id", ModUser_id)
            d.Add("Mod_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("SAL_EXAMINE_fee", d) > 0
        End Function

        Public Function deleteData(ByVal BASE_IDNO As String, ByVal Meeting_date As String, ByVal Meeting_content As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("BASE_IDNO", BASE_IDNO)
            d.Add("Meeting_date", Meeting_date)
            d.Add("Meeting_content", Meeting_content)
            Return DAO.DeleteByExample("SAL_EXAMINE_fee", d) > 0
        End Function

        Public Function UpdateAmt(ByVal BASE_IDNO As String, ByVal Meeting_date As String, ByVal Meeting_content As String, ByVal Apply_amt As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            Dim d2 As New Dictionary(Of String, Object)
            d2.Add("Apply_amt", Apply_amt)
            d.Add("BASE_IDNO", BASE_IDNO)
            d.Add("Meeting_date", Meeting_date)
            d.Add("Meeting_content", Meeting_content)
            Return DAO.UpdateByExample("SAL_EXAMINE_fee", d2, d) > 0
        End Function

        Public Function Updateflowid(ByVal BASE_IDNO As String, ByVal Meeting_date As String, ByVal Meeting_content As String, ByVal Flow_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            Dim d2 As New Dictionary(Of String, Object)
            d2.Add("Flow_id", Flow_id)
            d.Add("BASE_IDNO", BASE_IDNO)
            d.Add("Meeting_date", Meeting_date)
            d.Add("Meeting_content", Meeting_content)
            Return DAO.UpdateByExample("SAL_EXAMINE_fee", d2, d) > 0
        End Function


        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        'Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As DataTable
        '    Dim ds As DataSet = DAO.GetDataByUserId(Orgcode, UserId, Apply_ym)
        '    If ds Is Nothing Then Return Nothing
        '    Return ds.Tables(0)
        'End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        'Public Function CheckInsert(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As Integer
        '    Dim ds As DataSet = DAO.CheckInsert(Orgcode, UserId, Apply_ym)
        '    If ds Is Nothing Then Return Nothing
        '    Return ds.Tables(0).Rows.Count
        'End Function


    End Class
End Namespace