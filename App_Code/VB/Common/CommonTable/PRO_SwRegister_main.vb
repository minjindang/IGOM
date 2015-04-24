Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PRO_SwRegister_main
        Public DAO As PRO_SwRegister_mainDAO

        Public Sub New()
            DAO = New PRO_SwRegister_mainDAO()
        End Sub

        Public Function GetOne(Flow_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll() As DataTable
            Dim dt As DataTable = DAO.SelectAll()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Flow_id As String, OfficialNumber_id As String, Software_id As String, Software_type As String, _
            Software_name As String, Version As String, KeyNumber_nos As String, SoftwareKind_type As String, NetPLimit_cnt As Integer, _
            Sofeware_cnt As Integer, Obtain_type As String, ObtainOt_desc As String, SoftwareUnit_name As String, StorageMedia_type As String, _
            StorageMediaOt_desc As String, StorageMedia_cnt As Integer, RelatedPapers_name As String, LifeTime As Double, Fee_amt As Double, _
            MRent_amt As Double, Start_date As String, Unit_code As String, User_id As String, Register_date As String, _
            Memo As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(OfficialNumber_id) Then
                psList.Add(New SqlParameter("@OfficialNumber_id", OfficialNumber_id))
            Else
                psList.Add(New SqlParameter("@OfficialNumber_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Software_id) Then
                psList.Add(New SqlParameter("@Software_id", Software_id))
            Else
                psList.Add(New SqlParameter("@Software_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Software_type) Then
                psList.Add(New SqlParameter("@Software_type", Software_type))
            Else
                psList.Add(New SqlParameter("@Software_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Software_name) Then
                psList.Add(New SqlParameter("@Software_name", Software_name))
            Else
                psList.Add(New SqlParameter("@Software_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Version) Then
                psList.Add(New SqlParameter("@Version", Version))
            Else
                psList.Add(New SqlParameter("@Version", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(KeyNumber_nos) Then
                psList.Add(New SqlParameter("@KeyNumber_nos", KeyNumber_nos))
            Else
                psList.Add(New SqlParameter("@KeyNumber_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(SoftwareKind_type) Then
                psList.Add(New SqlParameter("@SoftwareKind_type", SoftwareKind_type))
            Else
                psList.Add(New SqlParameter("@SoftwareKind_type", DBNull.Value))
            End If
            If Not NetPLimit_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@NetPLimit_cnt", NetPLimit_cnt))
            Else
                psList.Add(New SqlParameter("@NetPLimit_cnt", DBNull.Value))
            End If
            If Not Sofeware_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Sofeware_cnt", Sofeware_cnt))
            Else
                psList.Add(New SqlParameter("@Sofeware_cnt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Obtain_type) Then
                psList.Add(New SqlParameter("@Obtain_type", Obtain_type))
            Else
                psList.Add(New SqlParameter("@Obtain_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ObtainOt_desc) Then
                psList.Add(New SqlParameter("@ObtainOt_desc", ObtainOt_desc))
            Else
                psList.Add(New SqlParameter("@ObtainOt_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(SoftwareUnit_name) Then
                psList.Add(New SqlParameter("@SoftwareUnit_name", SoftwareUnit_name))
            Else
                psList.Add(New SqlParameter("@SoftwareUnit_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(StorageMedia_type) Then
                psList.Add(New SqlParameter("@StorageMedia_type", StorageMedia_type))
            Else
                psList.Add(New SqlParameter("@StorageMedia_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(StorageMediaOt_desc) Then
                psList.Add(New SqlParameter("@StorageMediaOt_desc", StorageMediaOt_desc))
            Else
                psList.Add(New SqlParameter("@StorageMediaOt_desc", DBNull.Value))
            End If
            If Not StorageMedia_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@StorageMedia_cnt", StorageMedia_cnt))
            Else
                psList.Add(New SqlParameter("@StorageMedia_cnt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(RelatedPapers_name) Then
                psList.Add(New SqlParameter("@RelatedPapers_name", RelatedPapers_name))
            Else
                psList.Add(New SqlParameter("@RelatedPapers_name", DBNull.Value))
            End If
            If Not LifeTime = Double.MinValue Then
                psList.Add(New SqlParameter("@LifeTime", LifeTime))
            Else
                psList.Add(New SqlParameter("@LifeTime", DBNull.Value))
            End If
            If Not Fee_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Fee_amt", Fee_amt))
            Else
                psList.Add(New SqlParameter("@Fee_amt", DBNull.Value))
            End If
            If Not MRent_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@MRent_amt", MRent_amt))
            Else
                psList.Add(New SqlParameter("@MRent_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                psList.Add(New SqlParameter("@Start_date", Start_date))
            Else
                psList.Add(New SqlParameter("@Start_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Register_date) Then
                psList.Add(New SqlParameter("@Register_date", Register_date))
            Else
                psList.Add(New SqlParameter("@Register_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", DBNull.Value))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(OrgCode As String, Flow_id As String, OfficialNumber_id As String, Software_id As String, Software_type As String, _
                    Software_name As String, Version As String, KeyNumber_nos As String, SoftwareKind_type As String, NetPLimit_cnt As Integer, _
                    Sofeware_cnt As Integer, Obtain_type As String, ObtainOt_desc As String, SoftwareUnit_name As String, StorageMedia_type As String, _
                    StorageMediaOt_desc As String, StorageMedia_cnt As Integer, RelatedPapers_name As String, LifeTime As Double, Fee_amt As Double, _
                    MRent_amt As Double, Start_date As String, Unit_code As String, User_id As String, Register_date As String, _
                    Memo As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(OfficialNumber_id) Then
                psList.Add(New SqlParameter("@OfficialNumber_id", OfficialNumber_id))
            Else
                psList.Add(New SqlParameter("@OfficialNumber_id", dr("OfficialNumber_id")))
            End If
            If Not String.IsNullOrEmpty(Software_id) Then
                psList.Add(New SqlParameter("@Software_id", Software_id))
            Else
                psList.Add(New SqlParameter("@Software_id", dr("Software_id")))
            End If
            If Not String.IsNullOrEmpty(Software_type) Then
                psList.Add(New SqlParameter("@Software_type", Software_type))
            Else
                psList.Add(New SqlParameter("@Software_type", dr("Software_type")))
            End If
            If Not String.IsNullOrEmpty(Software_name) Then
                psList.Add(New SqlParameter("@Software_name", Software_name))
            Else
                psList.Add(New SqlParameter("@Software_name", dr("Software_name")))
            End If
            If Not String.IsNullOrEmpty(Version) Then
                psList.Add(New SqlParameter("@Version", Version))
            Else
                psList.Add(New SqlParameter("@Version", dr("Version")))
            End If
            If Not String.IsNullOrEmpty(KeyNumber_nos) Then
                psList.Add(New SqlParameter("@KeyNumber_nos", KeyNumber_nos))
            Else
                psList.Add(New SqlParameter("@KeyNumber_nos", dr("KeyNumber_nos")))
            End If
            If Not String.IsNullOrEmpty(SoftwareKind_type) Then
                psList.Add(New SqlParameter("@SoftwareKind_type", SoftwareKind_type))
            Else
                psList.Add(New SqlParameter("@SoftwareKind_type", dr("SoftwareKind_type")))
            End If
            If Not NetPLimit_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@NetPLimit_cnt", NetPLimit_cnt))
            Else
                psList.Add(New SqlParameter("@NetPLimit_cnt", dr("NetPLimit_cnt")))
            End If
            If Not Sofeware_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Sofeware_cnt", Sofeware_cnt))
            Else
                psList.Add(New SqlParameter("@Sofeware_cnt", dr("Sofeware_cnt")))
            End If
            If Not String.IsNullOrEmpty(Obtain_type) Then
                psList.Add(New SqlParameter("@Obtain_type", Obtain_type))
            Else
                psList.Add(New SqlParameter("@Obtain_type", dr("Obtain_type")))
            End If
            If Not String.IsNullOrEmpty(ObtainOt_desc) Then
                psList.Add(New SqlParameter("@ObtainOt_desc", ObtainOt_desc))
            Else
                psList.Add(New SqlParameter("@ObtainOt_desc", dr("ObtainOt_desc")))
            End If
            If Not String.IsNullOrEmpty(SoftwareUnit_name) Then
                psList.Add(New SqlParameter("@SoftwareUnit_name", SoftwareUnit_name))
            Else
                psList.Add(New SqlParameter("@SoftwareUnit_name", dr("SoftwareUnit_name")))
            End If
            If Not String.IsNullOrEmpty(StorageMedia_type) Then
                psList.Add(New SqlParameter("@StorageMedia_type", StorageMedia_type))
            Else
                psList.Add(New SqlParameter("@StorageMedia_type", dr("StorageMedia_type")))
            End If
            If Not String.IsNullOrEmpty(StorageMediaOt_desc) Then
                psList.Add(New SqlParameter("@StorageMediaOt_desc", StorageMediaOt_desc))
            Else
                psList.Add(New SqlParameter("@StorageMediaOt_desc", dr("StorageMediaOt_desc")))
            End If
            If Not StorageMedia_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@StorageMedia_cnt", StorageMedia_cnt))
            Else
                psList.Add(New SqlParameter("@StorageMedia_cnt", dr("StorageMedia_cnt")))
            End If
            If Not String.IsNullOrEmpty(RelatedPapers_name) Then
                psList.Add(New SqlParameter("@RelatedPapers_name", RelatedPapers_name))
            Else
                psList.Add(New SqlParameter("@RelatedPapers_name", dr("RelatedPapers_name")))
            End If
            If Not LifeTime = Double.MinValue Then
                psList.Add(New SqlParameter("@LifeTime", LifeTime))
            Else
                psList.Add(New SqlParameter("@LifeTime", dr("LifeTime")))
            End If
            If Not Fee_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@Fee_amt", Fee_amt))
            Else
                psList.Add(New SqlParameter("@Fee_amt", dr("Fee_amt")))
            End If
            If Not MRent_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@MRent_amt", MRent_amt))
            Else
                psList.Add(New SqlParameter("@MRent_amt", dr("MRent_amt")))
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                psList.Add(New SqlParameter("@Start_date", Start_date))
            Else
                psList.Add(New SqlParameter("@Start_date", dr("Start_date")))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", dr("Unit_code")))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(Register_date) Then
                psList.Add(New SqlParameter("@Register_date", Register_date))
            Else
                psList.Add(New SqlParameter("@Register_date", dr("Register_date")))
            End If
            If Not String.IsNullOrEmpty(Memo) Then
                psList.Add(New SqlParameter("@Memo", Memo))
            Else
                psList.Add(New SqlParameter("@Memo", dr("Memo")))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", dr("ModUser_id")))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", dr("Mod_date")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Flow_id As String, OrgCode As String)
            DAO.Delete(Flow_id, OrgCode)
        End Sub

    End Class
End Namespace
