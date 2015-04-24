Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3101DAO
        Inherits BaseDAO

        Dim sbSQL As New System.Text.StringBuilder

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Sub New(connStr As String)
            MyBase.New(connStr)
        End Sub

        ''' <summary>
        ''' 回傳【VW_IGSS_PO】相關資料
        ''' </summary>
        ''' <param name="PoYear">請購會計年度號</param>
        ''' <param name="PoNo">請購單號</param>
        ''' <param name="PoNosn">請購單序號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(PoYear As String, PoNo As String, PoNosn As String) As DataTable
            sbSQL.Length = 0
            sbSQL.Append(" SELECT TOP 1 ")
            sbSQL.Append(" vpo.RECVNO, ")
            sbSQL.Append(" vpo.RECVNAME, ")
            sbSQL.Append(" vpo.POID, ")
            sbSQL.Append(" vpo.POID as AD_ID, ")
            sbSQL.Append(" vpo.POREMNM, ")
            sbSQL.Append(" vpo.VOUNO ")
            sbSQL.Append(" FROM VW_IGSS_PO vpo ")
            sbSQL.Append(" WHERE vpo.POYEAR=@PoYear and vpo.PONO=@PoNo and vpo.PONOSN=@PoNoSn ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@PoYear", PoYear), _
            New SqlParameter("@PoNo", PoNo), _
            New SqlParameter("@PoNoSn", PoNosn)}

            Return Query(sbSQL.ToString(), ps)
        End Function

        Public Function SelectPAY310101(OrgCode As String, FiscalYear_id As String, PettyCash_type As String, PCList_id As String, _
                                        PettyCashStart_nos As String, PettyCashEnd_nos As String, PrepayStart_nos As String, PrepayEnd_nos As String, _
                                        WriteOff_date As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As New System.Text.StringBuilder
            strSQL.Append("SELECT * " & vbCrLf)
            strSQL.Append("FROM   PAY_LendPetty_main a " & vbCrLf)
            strSQL.Append("       INNER JOIN PAY_PettyList_main b " & vbCrLf)
            strSQL.Append("               ON a.FiscalYear_id = b.FiscalYear_id " & vbCrLf)
            strSQL.Append("                  AND a.OrgCode = b.OrgCode " & vbCrLf)
            strSQL.Append("                  AND a.PCList_id = b.PCList_id " & vbCrLf)
            strSQL.Append("       LEFT JOIN PAY_PettyReturn_main c " & vbCrLf)
            strSQL.Append("              ON b.PCList_id = c.PettyCashInventory_id " & vbCrLf)
            strSQL.Append("                 AND a.FiscalYear_id = b.FiscalYear_id " & vbCrLf)
            strSQL.Append("                 AND a.OrgCode = b.OrgCode " & vbCrLf)
            strSQL.Append("WHERE  a.OrgCode = @OrgCode AND a.FiscalYear_id=@FiscalYear_id ")

            If Not String.IsNullOrEmpty(PettyCash_type) Then
                strSQL.Append(" AND b.PettyCash_type=@PettyCash_type ")
            End If

            If Not String.IsNullOrEmpty(PCList_id) Then
                strSQL.Append(" AND b.PCList_id=@PCList_id ")
            End If

            If Not String.IsNullOrEmpty(PettyCashStart_nos) Then
                strSQL.Append(" AND b.PettyCashStart_nos=@PettyCashStart_nos ")
            End If

            If Not String.IsNullOrEmpty(PettyCashEnd_nos) Then
                strSQL.Append(" AND b.PettyCashEnd_nos=@PettyCashEnd_nos ")
            End If

            If Not String.IsNullOrEmpty(PrepayStart_nos) Then
                strSQL.Append(" AND b.PrepayStart_nos=@PrepayStart_nos  ")
            End If

            If Not String.IsNullOrEmpty(PrepayEnd_nos) Then
                strSQL.Append(" AND b.PrepayEnd_nos=@PrepayEnd_nos  ")
            End If

            If Not String.IsNullOrEmpty(WriteOff_date) Then
                strSQL.Append(" AND a.WriteOff_date=@WriteOff_date ")
            End If

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@FiscalYear_id", FiscalYear_id), _
            New SqlParameter("@PettyCash_type", PettyCash_type), _
            New SqlParameter("@PCList_id", PCList_id), _
            New SqlParameter("@PettyCashStart_nos", PettyCashStart_nos), _
            New SqlParameter("@PettyCashEnd_nos", PettyCashEnd_nos), _
            New SqlParameter("@PrepayStart_nos", PrepayStart_nos), _
            New SqlParameter("@PrepayEnd_nos", PrepayEnd_nos), _
            New SqlParameter("@WriteOff_date", WriteOff_date)}

            Return Query(strSQL.ToString(), ps)
        End Function

    End Class

End Namespace
