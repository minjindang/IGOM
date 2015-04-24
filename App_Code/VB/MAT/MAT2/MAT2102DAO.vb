Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MAT2102DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub


        Public Function MAT2102SelectData(ByVal ApplyRadioButtonSelectedValue As String, _
                                          ByVal SortRadioButtonListValue As String, _
                                          ByVal Material_detS As String, _
                                          ByVal Material_detE As String, _
                                          ByVal ReceiveS As String, _
                                          ByVal ReceiveE As String, _
                                          ByVal OrgCodeDropDownList As String, _
                                          ByVal User_name As String) As DataTable

            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "Select MAT_ApplyMaterial_main.Form_type, "
            StrSQL &= "(select code_desc1 from sys_code where code_sys='014' and code_type='001' and code_no=MAT_ApplyMaterial_main.Form_type) as Form_type_name, "
            StrSQL &= "MAT_ApplyMaterial_main.Unit_Code, "
            StrSQL &= "(select depart_name from FSC_Org where Orgcode=MAT_ApplyMaterial_main.OrgCode and depart_id=MAT_ApplyMaterial_main.Unit_Code) as Unit_name, "
            StrSQL &= "FSC_Personnel.User_name, "
            StrSQL &= "MAT_ApplyMaterial_main.Apply_date, "
            StrSQL &= "MAT_ApplyMaterial_det.Out_date, "
            StrSQL &= "MAT_ApplyMaterial_det.Material_id, "
            StrSQL &= "MAT_Material_main.Material_name, "
            StrSQL &= "MAT_Material_main.Unit, "
            StrSQL &= "MAT_ApplyMaterial_det.Apply_cnt, "
            StrSQL &= "MAT_ApplyMaterial_det.Out_cnt, "
            StrSQL &= "MAT_ApplyMaterial_main.User_id "
            StrSQL &= "from MAT_ApplyMaterial_det "
            StrSQL &= "inner join MAT_Material_main on MAT_ApplyMaterial_det.Material_id=MAT_Material_main.Material_id "
            StrSQL &= "inner Join MAT_ApplyMaterial_main on MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id "
            StrSQL &= "inner Join FSC_personnel on MAT_ApplyMaterial_main.User_id=FSC_personnel.id_card "
            StrSQL &= "where MAT_ApplyMaterial_main.Form_type=@ApplyMaterial_mainForm_type "
            If Not String.IsNullOrEmpty(Material_detS) Then
                StrSQL &= "and MAT_ApplyMaterial_det.Material_id>=@Material_detS "
            End If
            If Not String.IsNullOrEmpty(Material_detE) Then
                StrSQL &= "and MAT_ApplyMaterial_det.Material_id<=@Material_detE "
            End If
            If Not String.IsNullOrEmpty(ReceiveS) Then
                StrSQL &= "and MAT_ApplyMaterial_det.Out_date>=@ReceiveS "
            End If
            If Not String.IsNullOrEmpty(ReceiveE) Then
                StrSQL &= "and MAT_ApplyMaterial_det.Out_date<=@ReceiveE "
            End If
            If Not String.IsNullOrEmpty(OrgCodeDropDownList) Then
                StrSQL &= "and MAT_ApplyMaterial_main.Unit_Code=@OrgCodeDropDownList "
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                StrSQL &= "and FSC_personnel.Id_card=@User_name "
            End If
            If Not String.IsNullOrEmpty(SortRadioButtonListValue) Then
                If SortRadioButtonListValue = "0" Then
                    StrSQL &= "order by MAT_ApplyMaterial_det.Out_cnt DESC "
                ElseIf SortRadioButtonListValue = "1" Then
                    StrSQL &= "order by FSC_Personnel.User_name "
                ElseIf SortRadioButtonListValue = "2" Then
                    StrSQL &= "order by MAT_ApplyMaterial_det.Material_id "
                End If
            End If

            Dim ps() As SqlParameter = {New SqlParameter("@ApplyMaterial_mainForm_type", ApplyRadioButtonSelectedValue), _
                                        New SqlParameter("@Material_detS", Material_detS), _
                                        New SqlParameter("@Material_detE", Material_detE), _
                                        New SqlParameter("@ReceiveS", ReceiveS), _
                                        New SqlParameter("@ReceiveE", ReceiveE), _
                                        New SqlParameter("@OrgCodeDropDownList", OrgCodeDropDownList), _
                                        New SqlParameter("@User_name", User_name)}
            Return Query(StrSQL, ps)
        End Function

    End Class
End Namespace