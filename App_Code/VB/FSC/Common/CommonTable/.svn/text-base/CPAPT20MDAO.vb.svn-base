Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic
    Public Class CPAPT20MDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal connstr As String)
            MyBase.New(connstr)
            ConnectionString = connstr
        End Sub

        Public Function GetDataByPRADDD(ByVal PTIDNO As String, ByVal PRADDD As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM CPAPT20M WHERE PTIDNO=@PTIDNO AND PTBDATE<=@PRADDD AND PTEDATE>=@PRADDD ")
            Dim params() As SqlParameter = {New SqlParameter("@PTIDNO", SqlDbType.VarChar), New SqlParameter("@PRADDD", SqlDbType.VarChar)}
            params(0).Value = PTIDNO
            params(1).Value = PRADDD
            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetCountByPRADDD(ByVal PTIDNO As String, ByVal PRADDD As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT COUNT(*) FROM CPAPT20M WHERE PTIDNO=@PTIDNO AND PTBDATE<=@PRADDD AND PTEDATE>=@PRADDD ")
            Dim params() As SqlParameter = {New SqlParameter("@PTIDNO", SqlDbType.VarChar), New SqlParameter("@PRADDD", SqlDbType.VarChar)}
            params(0).Value = PTIDNO
            params(1).Value = PRADDD
            Return Scalar(StrSQL.ToString(), params)
        End Function

        Public Function GetApplyCountByPRADDD(ByVal PTIDNO As String, ByVal PRADDD As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT COUNT(*) FROM CPAPT20M WHERE PTIDNO=@PTIDNO AND PTEDATE>=@PRADDD ")
            Dim params() As SqlParameter = {New SqlParameter("@PTIDNO", SqlDbType.VarChar), New SqlParameter("@PRADDD", SqlDbType.VarChar)}
            params(0).Value = PTIDNO
            params(1).Value = PRADDD
            Return Scalar(StrSQL.ToString(), params)
        End Function

        Public Function GetCountByPTCARD(ByVal PTCARD As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine("SELECT COUNT(*) FROM CPAPT20M WHERE PTIDNO=@PTCARD ")
            Dim param As SqlParameter = New SqlParameter("@PTCARD", SqlDbType.VarChar)
            param.Value = PTCARD
            Return Scalar(StrSQL.ToString(), param)
        End Function

        Public Function GetPTHOUR(ByVal PTIDNO As String, ByVal ym As String) As Object
            Dim StrSQL As String = "Select TOP 1 PTHOUR as X from CPAPT20M where " & _
                                    "PTIDNO = @PTIDNO and Substring(PTBDATE,1,5) <= @ym and Substring(PTEDATE,1,5) >= @ym " & _
                                    "ORDER BY PTBDATE DESC"

            Dim params() As SqlParameter = {New SqlParameter("@PTIDNO", SqlDbType.VarChar), New SqlParameter("@ym", SqlDbType.VarChar)}
            params(0).Value = PTIDNO
            params(1).Value = ym
            Return Scalar(StrSQL, params)
        End Function

        Public Function updateData(ByVal pt20m As CPAPT20M, ByVal PTCARD As String, ByVal PTBDATE As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" UPDATE CPAPT20M ")
            sql.AppendLine(" SET PTBDATE=@PTBDATE, PTEDATE=@PTEDATE, PTPNAME=@PTPNAME, PTHOUR=@PTHOUR, PTHOUR2=@PTHOUR2, PTFLAG=@PTFLAG, PTFLAG2=@PTFLAG2 ")
            sql.AppendLine(" WHERE PTCARD=@PTCARD AND PTBDATE=@UPTBDATE ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PTBDATE", SqlDbType.VarChar), _
            New SqlParameter("@PTEDATE", SqlDbType.VarChar), _
            New SqlParameter("@PTPNAME", SqlDbType.VarChar), _
            New SqlParameter("@PTHOUR", SqlDbType.VarChar), _
            New SqlParameter("@PTHOUR2", SqlDbType.VarChar), _
            New SqlParameter("@PTFLAG", SqlDbType.VarChar), _
            New SqlParameter("@PTFLAG2", SqlDbType.VarChar), _
            New SqlParameter("@PTCARD", SqlDbType.VarChar), _
            New SqlParameter("@UPTBDATE", SqlDbType.VarChar)}
            params(0).Value = pt20m.PTBDATE
            params(1).Value = pt20m.PTEDATE
            params(2).Value = pt20m.PTPNAME
            params(3).Value = pt20m.PTHOUR
            params(4).Value = pt20m.PTHOUR2
            params(5).Value = pt20m.PTFLAG
            params(6).Value = pt20m.PTFLAG2
            params(7).Value = PTCARD
            params(8).Value = PTBDATE
            Return Execute(sql.ToString(), params)
        End Function

        Public Function Getdatebydate(ByVal PTNAME As String, ByVal PTIDNO As String, ByVal PTCARD As String, _
                                      ByVal PTBDATE As String, ByVal PTEDATE As String) As DataSet
            Dim StrSQL As String = "Select * from CPAPT20M where PTNAME=@PTNAME and PTIDNO=@PTIDNO and PTCARD=@PTCARD and "
            StrSQL &= "((@PTBDATE between PTBDATE and PTEDATE) or (@PTEDATE between PTBDATE and PTEDATE))"

            Dim params() As SqlParameter = {New SqlParameter("@PTNAME", SqlDbType.VarChar), New SqlParameter("@PTIDNO", SqlDbType.VarChar), _
                                            New SqlParameter("@PTCARD", SqlDbType.VarChar), New SqlParameter("@PTBDATE", SqlDbType.VarChar), _
                                            New SqlParameter("@PTEDATE", SqlDbType.VarChar)}
            params(0).Value = PTNAME
            params(1).Value = PTIDNO
            params(2).Value = PTCARD
            params(3).Value = PTBDATE
            params(4).Value = PTEDATE
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, params)
        End Function
    End Class
End Namespace