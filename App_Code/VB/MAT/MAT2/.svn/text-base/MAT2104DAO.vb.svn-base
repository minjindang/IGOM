Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class MAT2104DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        Public Function MAT2104SelectData(ByVal In_dateS As String, ByVal In_dateE As String, ByVal Material_idS As String, ByVal Material_idE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT MAT_MaterialIn_det.In_date, MAT_MaterialIn_det.Material_id, MAT_Material_main.Material_name, MAT_MaterialIn_det.Unit, MAT_MaterialIn_det.In_cnt, MAT_MaterialIn_det.TotalPrice_amt, MAT_MaterialIn_det.Company_name from MAT_MaterialIn_det CROSS JOIN  MAT_Material_main where MAT_MaterialIn_det.Material_id=MAT_Material_main.Material_id"
            If Not String.IsNullOrEmpty(In_dateS) Then
                StrSQL &= " and In_date>=@In_dateS"
            End If
            If Not String.IsNullOrEmpty(In_dateE) Then
                StrSQL &= " and In_date<=@In_dateE"
            End If
            If Not String.IsNullOrEmpty(Material_idS) Then
                StrSQL &= " and MAT_MaterialIn_det.Material_id>=@Material_idS"
            End If
            If Not String.IsNullOrEmpty(Material_idE) Then
                StrSQL &= " and MAT_MaterialIn_det.Material_id<=@Material_idE"
            End If
            StrSQL &= " ORDER BY In_date "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@In_dateS", In_dateS), _
            New SqlParameter("@In_dateE", In_dateE), _
            New SqlParameter("@Material_idS", Material_idS), _
            New SqlParameter("@Material_idE", Material_idE)}
            Return Query(StrSQL, ps)
        End Function
    End Class
End Namespace