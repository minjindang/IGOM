Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class FSC_WorkProof_rpt
        Public DAO As FSC_WorkProof_rptDAO
        Public Sub New()
            DAO = New FSC_WorkProof_rptDAO()
        End Sub
#Region "Field"
        Private _Flow_id As String = String.Empty       ''1.�ӽЮץ�ID
        Private _BatchFlow_id As String = String.Empty  ''2.�ӽЮץ�帹
        Private _User_id As String = String.Empty       ''3.�ӽФH�������s��
        Private _Apply_yy As String = String.Empty      ''4.�ӽЦ~��
        Private _Apply_date As String = String.Empty    ''5.�ӽФ�
        Private _Apply_type As String = String.Empty    ''6.�ӽФ������
        Private _Apply_cnt As String = String.Empty     ''7.�ӽФ����
        Private _Apply_lang As String = String.Empty    ''8.����^��
        Private _Apply_use As String = String.Empty     ''9.�γ~
        Private _Org_code As String = String.Empty      ''10.���ݾ���
        Private _ModUser_id As String = String.Empty    ''11.���ʤH��
        Private _Mod_date As String = String.Empty      ''12.���ʮɶ�


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
        Public Property BatchFlow_id() As String
            Get
                Return _BatchFlow_id
            End Get
            Set(ByVal value As String)
                _BatchFlow_id = value
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
        ''' �ӽФ�
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
        ''' �ӽФ������
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_type() As String
            Get
                Return _Apply_type
            End Get
            Set(ByVal value As String)
                _Apply_type = value
            End Set
        End Property
        ''' <summary>
        ''' �ӽФ����
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_cnt() As String
            Get
                Return _Apply_cnt
            End Get
            Set(ByVal value As String)
                _Apply_cnt = value
            End Set
        End Property
        ''' <summary>
        ''' ����^��
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_lang() As String
            Get
                Return _Apply_lang
            End Get
            Set(ByVal value As String)
                _Apply_lang = value
            End Set
        End Property

        ''' <summary>
        ''' �γ~
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Apply_use() As String
            Get
                Return _Apply_use
            End Get
            Set(ByVal value As String)
                _Apply_use = value
            End Set
        End Property
        ''' <summary>
        ''' ���ݾ���
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
            d.Add("BatchFlow_id", BatchFlow_id)
            d.Add("User_id", User_id)
            d.Add("Apply_yy", Apply_yy)
            d.Add("Apply_date", Apply_date)
            d.Add("Apply_type", Apply_type)
            d.Add("Apply_cnt", Apply_cnt)
            d.Add("Apply_lang", Apply_lang)
            d.Add("Apply_use", Apply_use)
            d.Add("Org_code", Org_code)
            d.Add("ModUser_id", ModUser_id)
            d.Add("Mod_date", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            Return DAO.insertByExample("FSC_WorkProof_rpt", d) > 0
        End Function

        Public Function deleteData(ByVal Org_code As String, ByVal Flow_id As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)
            d.Add("Org_code", Org_code)
            Return DAO.deleteByExample("FSC_WorkProof_rpt", d) > 0
        End Function

        ''<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        'Public Function GetDataByUserId(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As DataTable
        '    Dim ds As DataSet = DAO.GetDataByUserId(Orgcode, UserId, Apply_ym)
        '    If ds Is Nothing Then Return Nothing
        '    Return ds.Tables(0)
        'End Function

        ''<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        'Public Function CheckInsert(ByVal Orgcode As String, ByVal UserId As String, ByVal Apply_ym As String) As Integer
        '    Dim ds As DataSet = DAO.CheckInsert(Orgcode, UserId, Apply_ym)
        '    If ds Is Nothing Then Return Nothing
        '    Return ds.Tables(0).Rows.Count
        'End Function


    End Class
End Namespace