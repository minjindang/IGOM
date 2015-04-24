Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_EXAMINE_fee
        Public DAO As SAL_EXAMINE_feeDAO

        Public Sub New()
            DAO = New SAL_EXAMINE_feeDAO()
        End Sub

        Public Function GetOne(Id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Org_code As String, Optional Flow_id As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(Org_code, Flow_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function
        Public Function GetID(count As Integer) As DataTable
            Dim dt As DataTable = DAO.SelectID(count)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function
        Public Function GetIDData(id As Integer) As DataTable
            Dim dt As DataTable = DAO.SelectIDData(id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(BASE_IDNO As String, Meeting_date As String, Meeting_content As String) As DataTable
            Dim dt As DataTable = DAO.SelectAll(BASE_IDNO, Meeting_date, Meeting_content)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(Flow_id As String, User_id As String, Unit_code As String, Apply_date As String, BASE_IDNO As String, _
BASE_NAME As String, BASE_SERVICE_PLACE_DESC As String, BASE_DCODE_NAME As String, Meeting_pos As String, Meeting_date As String, _
Meeting_content As String, BASE_ADDR As String, Pay_type As String, BASE_BANK_CODE As String, BASE_BANK_NO As String, _
BANK_TDPF_SEQNO As String, Budget_code As String, Item_code As String, Apply_amt As Integer, Health_Insurance As Integer, _
Receive_fee As Integer, Pay_date As String, Org_code As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                psList.Add(New SqlParameter("@Apply_date", Apply_date))
            Else
                psList.Add(New SqlParameter("@Apply_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_IDNO) Then
                psList.Add(New SqlParameter("@BASE_IDNO", BASE_IDNO))
            Else
                psList.Add(New SqlParameter("@BASE_IDNO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_NAME) Then
                psList.Add(New SqlParameter("@BASE_NAME", BASE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_NAME", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_SERVICE_PLACE_DESC) Then
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", BASE_SERVICE_PLACE_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_DCODE_NAME) Then
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", BASE_DCODE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Meeting_pos) Then
                psList.Add(New SqlParameter("@Meeting_pos", Meeting_pos))
            Else
                psList.Add(New SqlParameter("@Meeting_pos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Meeting_date) Then
                psList.Add(New SqlParameter("@Meeting_date", Meeting_date))
            Else
                psList.Add(New SqlParameter("@Meeting_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Meeting_content) Then
                psList.Add(New SqlParameter("@Meeting_content", Meeting_content))
            Else
                psList.Add(New SqlParameter("@Meeting_content", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ADDR) Then
                psList.Add(New SqlParameter("@BASE_ADDR", BASE_ADDR))
            Else
                psList.Add(New SqlParameter("@BASE_ADDR", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Pay_type) Then
                psList.Add(New SqlParameter("@Pay_type", Pay_type))
            Else
                psList.Add(New SqlParameter("@Pay_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_BANK_CODE) Then
                psList.Add(New SqlParameter("@BASE_BANK_CODE", BASE_BANK_CODE))
            Else
                psList.Add(New SqlParameter("@BASE_BANK_CODE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_BANK_NO) Then
                psList.Add(New SqlParameter("@BASE_BANK_NO", BASE_BANK_NO))
            Else
                psList.Add(New SqlParameter("@BASE_BANK_NO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_TDPF_SEQNO) Then
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", BANK_TDPF_SEQNO))
            Else
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Budget_code) Then
                psList.Add(New SqlParameter("@Budget_code", Budget_code))
            Else
                psList.Add(New SqlParameter("@Budget_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Item_code) Then
                psList.Add(New SqlParameter("@Item_code", Item_code))
            Else
                psList.Add(New SqlParameter("@Item_code", DBNull.Value))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", DBNull.Value))
            End If
            If Not Health_Insurance = Integer.MinValue Then
                psList.Add(New SqlParameter("@Health_Insurance", Health_Insurance))
            Else
                psList.Add(New SqlParameter("@Health_Insurance", DBNull.Value))
            End If
            If Not Receive_fee = Integer.MinValue Then
                psList.Add(New SqlParameter("@Receive_fee", Receive_fee))
            Else
                psList.Add(New SqlParameter("@Receive_fee", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Pay_date) Then
                psList.Add(New SqlParameter("@Pay_date", Pay_date))
            Else
                psList.Add(New SqlParameter("@Pay_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", DBNull.Value))
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

        Public Sub Modify(Id As Integer, Flow_id As String, User_id As String, Unit_code As String, Apply_date As String, BASE_IDNO As String, _
BASE_NAME As String, BASE_SERVICE_PLACE_DESC As String, BASE_DCODE_NAME As String, Meeting_pos As String, Meeting_date As String, _
Meeting_content As String, BASE_ADDR As String, Pay_type As String, BASE_BANK_CODE As String, BASE_BANK_NO As String, _
BANK_TDPF_SEQNO As String, Budget_code As String, Item_code As String, Apply_amt As Integer, Health_Insurance As Integer, _
Receive_fee As Integer, Pay_date As String, Org_code As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(Id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Id", Id))
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", dr("Flow_id")))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", dr("Unit_code")))
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                psList.Add(New SqlParameter("@Apply_date", Apply_date))
            Else
                psList.Add(New SqlParameter("@Apply_date", dr("Apply_date")))
            End If
            If Not String.IsNullOrEmpty(BASE_IDNO) Then
                psList.Add(New SqlParameter("@BASE_IDNO", BASE_IDNO))
            Else
                psList.Add(New SqlParameter("@BASE_IDNO", dr("BASE_IDNO")))
            End If
            If Not String.IsNullOrEmpty(BASE_NAME) Then
                psList.Add(New SqlParameter("@BASE_NAME", BASE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_NAME", dr("BASE_NAME")))
            End If
            If Not String.IsNullOrEmpty(BASE_SERVICE_PLACE_DESC) Then
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", BASE_SERVICE_PLACE_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", dr("BASE_SERVICE_PLACE_DESC")))
            End If
            If Not String.IsNullOrEmpty(BASE_DCODE_NAME) Then
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", BASE_DCODE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", dr("BASE_DCODE_NAME")))
            End If
            If Not String.IsNullOrEmpty(Meeting_pos) Then
                psList.Add(New SqlParameter("@Meeting_pos", Meeting_pos))
            Else
                psList.Add(New SqlParameter("@Meeting_pos", dr("Meeting_pos")))
            End If
            If Not String.IsNullOrEmpty(Meeting_date) Then
                psList.Add(New SqlParameter("@Meeting_date", Meeting_date))
            Else
                psList.Add(New SqlParameter("@Meeting_date", dr("Meeting_date")))
            End If
            If Not String.IsNullOrEmpty(Meeting_content) Then
                psList.Add(New SqlParameter("@Meeting_content", Meeting_content))
            Else
                psList.Add(New SqlParameter("@Meeting_content", dr("Meeting_content")))
            End If
            If Not String.IsNullOrEmpty(BASE_ADDR) Then
                psList.Add(New SqlParameter("@BASE_ADDR", BASE_ADDR))
            Else
                psList.Add(New SqlParameter("@BASE_ADDR", dr("BASE_ADDR")))
            End If
            If Not String.IsNullOrEmpty(Pay_type) Then
                psList.Add(New SqlParameter("@Pay_type", Pay_type))
            Else
                psList.Add(New SqlParameter("@Pay_type", dr("Pay_type")))
            End If
            If Not String.IsNullOrEmpty(BASE_BANK_CODE) Then
                psList.Add(New SqlParameter("@BASE_BANK_CODE", BASE_BANK_CODE))
            Else
                psList.Add(New SqlParameter("@BASE_BANK_CODE", dr("BASE_BANK_CODE")))
            End If
            If Not String.IsNullOrEmpty(BASE_BANK_NO) Then
                psList.Add(New SqlParameter("@BASE_BANK_NO", BASE_BANK_NO))
            Else
                psList.Add(New SqlParameter("@BASE_BANK_NO", dr("BASE_BANK_NO")))
            End If
            If Not String.IsNullOrEmpty(BANK_TDPF_SEQNO) Then
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", BANK_TDPF_SEQNO))
            Else
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", dr("BANK_TDPF_SEQNO")))
            End If
            If Not String.IsNullOrEmpty(Budget_code) Then
                psList.Add(New SqlParameter("@Budget_code", Budget_code))
            Else
                psList.Add(New SqlParameter("@Budget_code", dr("Budget_code")))
            End If
            If Not String.IsNullOrEmpty(Item_code) Then
                psList.Add(New SqlParameter("@Item_code", Item_code))
            Else
                psList.Add(New SqlParameter("@Item_code", dr("Item_code")))
            End If
            If Not Apply_amt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", dr("Apply_amt")))
            End If
            If Not Health_Insurance = Integer.MinValue Then
                psList.Add(New SqlParameter("@Health_Insurance", Health_Insurance))
            Else
                psList.Add(New SqlParameter("@Health_Insurance", dr("Health_Insurance")))
            End If
            If Not Receive_fee = Integer.MinValue Then
                psList.Add(New SqlParameter("@Receive_fee", Receive_fee))
            Else
                psList.Add(New SqlParameter("@Receive_fee", dr("Receive_fee")))
            End If
            If Not String.IsNullOrEmpty(Pay_date) Then
                psList.Add(New SqlParameter("@Pay_date", Pay_date))
            Else
                psList.Add(New SqlParameter("@Pay_date", dr("Pay_date")))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", dr("Org_code")))
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

        Public Sub Remove(Id As Integer)
            DAO.Delete(Id)
        End Sub

        Public Sub DeleteByFid(ByVal flow_id As String)
            DAO.DeleteByFid(flow_id)
        End Sub
    End Class
End Namespace
