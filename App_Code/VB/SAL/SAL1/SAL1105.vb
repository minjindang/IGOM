Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class SAL1105
        Public DAO As SAL1105DAO
        Public Sub New()
            DAO = New SAL1105DAO()
        End Sub
#Region "Field"
        Private _Flow_id As String = String.Empty                   ' 1.�y�{�s��
        Private _Merge_flow_id As String = String.Empty              ' 2.�y�{�帹
        Private _User_id As String = String.Empty                   ' 3.�H���s��
        Private _Apply_yy As String = String.Empty                  ' 4.�ӽЦ~��
        Private _Check_date As String = String.Empty                ' 5.���ˤ��
        Private _Apply_amt As String = String.Empty                 ' 6.�ӽЪ��B
        Private _Pay_date As String = String.Empty                  ' 7.�o����
        Private _Org_code As String = String.Empty                  ' 8.���s��
        Private _ModUser_id As String = String.Empty                ' 9.���ʤH���s��
        Private _Mod_date As String = String.Empty                  '10.���ʮɶ�

#End Region

#Region "Property"
        ''' <summary>
        ''' �y�{�s��
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
        ''' �y�{�帹
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
        ''' �H���s��
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
        ''' �ӽЦ~��
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_yy() As String
            Get
                Return _Apply_yy
            End Get
            Set(ByVal value As String)
                _Apply_yy = value
            End Set
        End Property
        ''' <summary>
        ''' ���ˤ��
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Check_date() As String
            Get
                Return _Check_date
            End Get
            Set(ByVal value As String)
                _Check_date = value
            End Set
        End Property
        ''' <summary>
        ''' �ӽЪ��B
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
        ''' �o����
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
        ''' ���s��
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
        ''' ���ʤH���s��
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
        ''' ���ʮɶ�
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
            d.Add("Apply_yy", Apply_yy)
            d.Add("Check_date", Check_date)
            d.Add("Apply_amt", Apply_amt)
            d.Add("Pay_date", Pay_date)
            d.Add("Org_code", Org_code)
            d.Add("ModUser_id", ModUser_id)
            d.Add("Mod_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("SAL_HealthSubsidy_fee", d) > 0
        End Function

        Public Function deleteData(ByVal Org_code As String, ByVal Flow_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)
            d.Add("Org_code", Org_code)
            Return DAO.deleteByExample("SAL_HealthSubsidy_fee", d) > 0
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetValiDataByUserId(ByVal Orgcode As String, ByVal UserId As String) As DataTable
            Dim ds As DataSet = DAO.GetValiDataByUserId(Orgcode, UserId)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_yy As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByUserId(Orgcode, UserId, Apply_yy)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function CheckInsert(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_yy As String) As Integer
            Dim ds As DataSet = DAO.CheckInsert(Orgcode, UserId, Apply_yy)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0).Rows.Count
        End Function


    End Class
End Namespace