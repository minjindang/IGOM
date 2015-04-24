Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class PAYITEM
        Public DAO As PAYITEMDAO
        Public Sub New()
            DAO = New PAYITEMDAO()
        End Sub
#Region "Field"
        Private _Org_Code As String = String.Empty      '機關代號
        Private _User_id As String = String.Empty       '人員識別碼
        Private _Flow_id As String = String.Empty       '申請案件ID
        Private _Merge_flow_id As String = String.Empty  '申請案件批號
        Private _CodeSys As String = String.Empty       '發放項目代號(1)
        Private _CodeKind As String = String.Empty      '發放項目代號(2)
        Private _CodeType As String = String.Empty      '發放項目代號(3)
        Private _CodeNo As String = String.Empty        '發放項目代號(4)
        Private _Code As String = String.Empty          '發放項目代號(5)
        Private _Pay_ym As String = String.Empty        '發放年月
        Private _Pay_date As String = String.Empty      '發放日期
        Private _Budget_code As String = String.Empty   '預算來源
        Private _Pay_amt As String = String.Empty       '發放金額
        Private _ModUser_id As String = String.Empty    '異動人員
        Private _Mod_date As String = String.Empty      '異動時間


#End Region

#Region "Property"
        ''' <summary>
        ''' 單位編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Org_code() As String
            Get
                Return _Org_Code
            End Get
            Set(ByVal value As String)
                _Org_Code = value
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
        ''' 發放項目代號(1)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CodeSys() As String
            Get
                Return _CodeSys
            End Get
            Set(ByVal value As String)
                _CodeSys = value
            End Set
        End Property
        ''' <summary>
        ''' 發放項目代號(2)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CodeKind() As String
            Get
                Return _CodeKind
            End Get
            Set(ByVal value As String)
                _CodeKind = value
            End Set
        End Property
        ''' <summary>
        ''' 發放項目代號(3)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CodeType() As String
            Get
                Return _CodeType
            End Get
            Set(ByVal value As String)
                _CodeType = value
            End Set
        End Property
        ''' <summary>
        ''' 發放項目代號(4)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CodeNo() As String
            Get
                Return _CodeNo
            End Get
            Set(ByVal value As String)
                _CodeNo = value
            End Set
        End Property
        ''' <summary>
        ''' 發放項目代號(5)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        ''' <summary>
        ''' 發放年月
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Pay_ym() As String
            Get
                Return _Pay_ym
            End Get
            Set(ByVal value As String)
                _Pay_ym = value
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
        ''' 發放金額
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Pay_amt() As String
            Get
                Return _Pay_amt
            End Get
            Set(ByVal value As String)
                _Pay_amt = value
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
            d.Add("PAYITEM_Org_code", Org_code)
            d.Add("PAYITEM_User_id", User_id)
            d.Add("PAYITEM_Flow_id", Flow_id)
            d.Add("PAYITEM_Merge_flow_id", Merge_flow_id)
            d.Add("PAYITEM_CodeSys", CodeSys)
            d.Add("PAYITEM_CodeKind", CodeKind)
            d.Add("PAYITEM_CodeType", CodeType)
            d.Add("PAYITEM_CodeNo", CodeNo)
            d.Add("PAYITEM_Code", Code)
            d.Add("PAYITEM_Pay_ym", Pay_ym)
            d.Add("PAYITEM_Pay_date", Pay_date)
            d.Add("PAYITEM_Budget_code", Budget_code)
            d.Add("PAYITEM_Pay_amt", Pay_amt)
            d.Add("PAYITEM_ModUser_id", ModUser_id)
            d.Add("PAYITEM_Mod_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("SAL_PAYITEM", d) > 0
        End Function

        Public Function deleteData(ByVal Org_code As String, ByVal Flow_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("PAYITEM_Flow_id", Flow_id)
            d.Add("PAYITEM_Org_code", Org_code)
            Return DAO.deleteByExample("SAL_PAYITEM", d) > 0
        End Function

    End Class
End Namespace