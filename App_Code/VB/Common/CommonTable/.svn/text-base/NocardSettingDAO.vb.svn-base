Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class NocardSettingDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getDataByQuery(ByVal Orgcode As String, _
                                       ByVal Id_card As String, _
                                       ByVal sdate As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from Nocard_setting ")
            sql.AppendLine(" where Orgcode=@Orgcode ")
            sql.AppendLine(" and Id_card=@Id_card ")
            sql.AppendLine(" and Start_date<=@sdate ")
            sql.AppendLine(" and End_date>=@sdate ")

            Dim sp() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@sdate", sdate)}

            Return Query(sql.ToString(), sp)
        End Function

    End Class
End Namespace