Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient 

Namespace FSC.Logic
    Public Class FSC3102
        Dim DAO As FSC3102DAO

        Const row_cnt As Integer = 3

#Region "Field"
        Dim conn As SqlClient.SqlConnection
        Dim train As SqlClient.SqlTransaction
#End Region

        Public Sub New()
            DAO = New FSC3102DAO
        End Sub


#Region "取得人員資料"
        Public Function Get_Member(ByVal Orgcode As String, _
                                   ByVal DepartID As String, _
                                   ByVal IDCard As String) As DataTable
            Return DAO.Get_Member(Orgcode, DepartID, IDCard)

        End Function
#End Region

#Region "取得代理人清單"

        Public Function Get_Deputy(ByVal Orgcode As String, ByVal IDCard As String) As DataTable
            Return DAO.Get_Deputy(Orgcode, IDCard)
        End Function

#End Region

#Region " 取得職稱代碼"
        Public Function Get_Title_no(ByVal ID_Card As String) As String
            Dim rv As String = ""

            Dim dt As DataTable = New Personnel().GetDataByIdCard(ID_Card)
            If dt.Rows.Count > 0 Then
            rv = dt.Rows(0)("title_no").ToString
            End If

            Return rv
        End Function
#End Region

#Region " 取得機關代碼"
        Public Function Get_Orgcode(ByVal ID_Card As String) As String
            Dim rv As String = ""

            Dim dt As DataTable = New DepartEmp().GetDataByIdcard(ID_Card)
            If dt.Rows.Count > 0 Then
                rv = dt.Rows(0)("Orgcode").ToString
            End If

            Return rv
        End Function
#End Region

#Region " 取得部門代碼"
        Public Function Get_Depart_id(ByVal ID_Card As String) As String
            Dim rv As String = ""

            Dim dt As DataTable = New DepartEmp().GetDataByIdcard(ID_Card)
            If dt.Rows.Count > 0 Then
                rv = dt.Rows(0)("Depart_id").ToString
            End If

            Return rv
        End Function
#End Region


        ''' <summary>
        ''' 回傳 順序最大值
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="ID_Card">人員編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMaxDeputySeq(ByVal Orgcode As String, ByVal ID_Card As String) As DataTable
            Return DAO.GetMaxDeputySeq(Orgcode, ID_Card)
        End Function

        ''' <summary>
        ''' 回傳 輸入的順序是否存在
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="ID_Card">人員編號</param>
        ''' <param name="Deputy_seq">順序</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataExist(ByVal Orgcode As String, ByVal ID_Card As String, ByVal Deputy_seq As String) As DataTable
            Return DAO.GetDataExist(Orgcode, ID_Card, Deputy_seq)
        End Function

        Public Function updateDefaultToMax(ByVal id As String, ByVal Deputy_seq As String) As Boolean
            Return DAO.updateDefaultToMax(id, Deputy_seq) > 0
        End Function

    End Class
End Namespace