Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAPAYODAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' [取得]取得調整薪差發放資料 依人員類別(臨時人員，非臨時人員),發放年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByOption(ByVal Orgcode As String, ByVal Type As String, ByVal PAYO_YYMM As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "select * " + _
                    "from member m " + _
                    "left join SAL_SAPAYO s on m.Personnel_id=s.PAYO_SEQNO " + _
                    "where 1=1 " + _
                    "-- 補發調整薪差額 （各項調整薪差發放) " + _
                    "and PAYO_KIND='007' " + _
                    "and PAYO_KIND_CODE='003' " + _
                    "and PAYO_KIND_CODE_TYPE='001' " + _
                    "and PAYO_KIND_CODE_NO='007' "


            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "AND m.Orgcode = @Orgcode "
            End If
            If Not String.IsNullOrEmpty(Type) Then
                If (Type = "4") Then
                    StrSQL &= "and m.Employee_type <> @Type	-- 非臨時人員 "
                End If
            End If
            If Not String.IsNullOrEmpty(PAYO_YYMM) Then
                StrSQL &= "and PAYO_YYMM= @PAYO_YYMM "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Type", SqlDbType.VarChar), _
            New SqlParameter("@PAYO_YYMM", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Type
            params(2).Value = PAYO_YYMM
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

    End Class
End Namespace