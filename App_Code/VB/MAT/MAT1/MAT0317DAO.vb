Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Namespace FSCPLM.Logic

    Public Class MAT0317DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetUnitID() As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select DISTINCT [Depart_name] as full_name, [Depart_id] as cols  from [FSC_org] order by [Depart_id]   "
            'If Not String.IsNullOrEmpty(item) Then
            '    strSQL &= "and Material_id  >= @item"
            'End If
            'If Not String.IsNullOrEmpty(code) Then
            '    strSQL &= "and Material_id <= @code"
            'End If
            'Dim ps() As SqlParameter = { _
            'New SqlParameter("@ITEM", item), _
            'New SqlParameter("@CODE", code)}
            Return Query(strSQL)
        End Function

        Public Function getApplyMAT(ByVal type As String, ByVal MatNo1 As String, ByVal MatNo2 As String, ByVal OutDate1 As String, _
                                    ByVal OutDate2 As String, ByVal Ucode As String, ByVal Uid As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select DISTINCT s.CODE_DESC1,"
            strSQL &= " (select distinct Depart_name from FSC_org f where a.Unit_Code = f.Depart_id)as Unit_Code,"
            strSQL &= " p.USER_NAME as User_id, "
            strSQL &= " a.Apply_date, b.Out_date, b.Material_id, c.Material_name, c.Unit, b.Apply_cnt, b.Out_cnt "
            strSQL &= " from MAT_ApplyMaterial_main a  left join MAT_ApplyMaterial_det  b  on a.Flow_id=b.Flow_id "
            strSQL &= " join MAT_Material_main c on b.Material_id=c.Material_id "
            strSQL &= " join SYS_CODE s on a.Form_type =s.CODE_NO and CODE_SYS='014' and CODE_TYPE='001' "
            strSQL &= " join FSC_Personnel p on p.id_card= a.User_id "
            strSQL &= " where 1=1 "
            If Not String.IsNullOrEmpty(type) Then
                strSQL &= "and a.Form_type = @type  "
            End If
            If Not String.IsNullOrEmpty(MatNo1) Then
                strSQL &= "and b.Material_id >= @MatNo1 "
            End If
            If Not String.IsNullOrEmpty(MatNo2) Then
                strSQL &= "and b.Material_id <= @MatNo2 "
            End If
            If Not String.IsNullOrEmpty(OutDate1) Then
                strSQL &= "and b.Out_date >= @OutDate1 "
            End If
            If Not String.IsNullOrEmpty(OutDate2) Then
                strSQL &= "and  b.Out_date <= @OutDate2 "
            End If
            If Not String.IsNullOrEmpty(Uid) Then
                strSQL &= "and p.id_card = @Uid "
            End If
            If Not String.IsNullOrEmpty(Ucode) Then
                strSQL &= "and a.Unit_Code = @Ucode "
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@type", type), _
            New SqlParameter("@MatNo1", MatNo1), _
            New SqlParameter("@MatNo2", MatNo2), _
            New SqlParameter("@OutDate1", OutDate1), _
            New SqlParameter("@OutDate2", OutDate2), _
            New SqlParameter("@Uid", Uid), _
            New SqlParameter("@Ucode", Ucode)}
            Return Query(strSQL, ps)

        End Function

        Public Function getApplyPrintMAT(ByVal type As String, ByVal Ucode As String, ByVal Uid As String, _
                                         ByVal MatNo1 As String, ByVal MatNo2 As String, ByVal OutDate1 As String, _
                                    ByVal OutDate2 As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select DISTINCT s.CODE_DESC1,"
            strSQL &= " (select distinct Depart_name from FSC_org f where a.Unit_Code = f.Depart_id)as Unit_Code,"
            strSQL &= " p.User_Name as User_id, "
            strSQL &= " a.Flow_id,  a.Apply_date, b.Material_id, c.Material_name,  b.Out_date, b.Out_cnt, c.Unit "
            strSQL &= "from MAT_ApplyMaterial_main a  left join MAT_ApplyMaterial_det  b  on a.Flow_id=b.Flow_id "
            strSQL &= " join MAT_Material_main c on b.Material_id=c.Material_id "
            strSQL &= " join SYS_CODE s on a.Form_type =s.CODE_NO and CODE_SYS='014' and CODE_TYPE='001' "
            strSQL &= " join FSC_Personnel p on p.id_card= a.User_id "
            strSQL &= " where 1=1 "
            If Not String.IsNullOrEmpty(type) Then
                strSQL &= "and a.Form_type = @type  "
            End If
            If Not String.IsNullOrEmpty(MatNo1) Then
                strSQL &= "and b.Material_id >= @MatNo1 "
            End If
            If Not String.IsNullOrEmpty(MatNo2) Then
                strSQL &= "and b.Material_id <= @MatNo2 "
            End If
            If Not String.IsNullOrEmpty(OutDate1) Then
                strSQL &= "and b.Out_date >= @OutDate1 "
            End If
            If Not String.IsNullOrEmpty(OutDate2) Then
                strSQL &= "and  b.Out_date <= @OutDate2 "
            End If
            If Not String.IsNullOrEmpty(Uid) Then
                strSQL &= "and p.id_card like @Uid "
            End If
            If Not String.IsNullOrEmpty(Ucode) Then
                strSQL &= "and a.Unit_Code = @Ucode "
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@type", type), _
            New SqlParameter("@MatNo1", MatNo1), _
            New SqlParameter("@MatNo2", MatNo2), _
            New SqlParameter("@OutDate1", OutDate1), _
            New SqlParameter("@OutDate2", OutDate2), _
            New SqlParameter("@Uid", "%" + Uid + "%"), _
            New SqlParameter("@Ucode", Ucode)}
            Return Query(strSQL, ps)

        End Function


    End Class
End Namespace
