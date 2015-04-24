Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class SAPAYO
        Public DAO As SAPAYODAO
        Public Sub New()
            DAO = New SAPAYODAO()
        End Sub
#Region "Field"
        Private _Orgcode As String = String.Empty                   ' 1.單位代碼
        Private _Payo_yymm As String = String.Empty                 ' 2.發放年月
        Private _Type As String = String.Empty                      ' 3.不含的人員類別
#End Region

#Region "Property"
        ''' <summary>
        ''' 單位代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        ''' <summary>
        ''' 發放年月
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Payo_yymm() As String
            Get
                Return _Payo_yymm
            End Get
            Set(ByVal value As String)
                _Payo_yymm = value
            End Set
        End Property
        ''' <summary>
        ''' 不含的人員類別
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Type() As String
            Get
                Return _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property

#End Region


        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        ''' <summary>
        ''' [取得]取得調整薪差發放資料 依人員類別(臨時人員，非臨時人員),發放年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByOption(ByVal Orgcode As String, ByVal Type As String, ByVal PAYO_YYMM As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByOption(Orgcode, Type, PAYO_YYMM)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

    End Class
End Namespace