Imports System.Data
Imports PAY.Logic
Imports System.Transactions
Imports System.IO
Partial Class PAY2_PAY2102_01
    Inherits BaseWebForm
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
#End Region
#Region "產製媒體檔"
    Protected Sub DiskBBtnButton(sender As Object, e As EventArgs) Handles DiskBBtn.Click
        Select Case Type.SelectedValue
            Case "1" '受款人支用清單(匯出媒體檔)
                '民國兩碼年月日
                Dim YYMMDDString As String = (Convert.ToInt32(Year(Date.Today())) - 1911).ToString.Substring(1, 2) & Right("0" & Month(Date.Today()), 2) & Right("0" & Day(Date.Today), 2)
                Dim YYYMMDDString As String = (Convert.ToInt32(Year(Date.Today())) - 1911).ToString & Right("0" & Month(Date.Today()), 2) & Right("0" & Day(Date.Today), 2)
                Dim db As DataTable = Nothing
                Dim dc As DataTable = Nothing
                Dim mc As PAY2102 = New PAY2102()
                Dim md As SATDPF = New SATDPF()
                dc = mc.Select_01_01(Server.HtmlEncode(PettyCash_nosS.Text), Server.HtmlEncode(PettyCash_nosE.Text), Server.HtmlEncode(ucBeneficiary.Beneficiary_ID), Server.HtmlEncode(UcROCYear.Year))
                If dc.Rows.Count > 0 Then

                    db = md.GetData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))

                    Dim tax As String = mc.GetUNIT_TAX(LoginManager.OrgCode)

                    If db IsNot Nothing AndAlso db.Rows.Count > 0 And Not String.IsNullOrEmpty(tax) Then

                        Dim String1 As String = YYMMDDString & _
                                                YYMMDDString & _
                                                db.Rows(0).Item("TDPF_BRANCH").ToString().PadLeft(3, " ") & _
                                                tax & _
                                                db.Rows(0).Item("TDPF_CUSTOM").ToString().PadLeft(3, " ") & _
                                                "".PadLeft(14, "0") & _
                                                dc.Compute("sum(PurchaseTotal_amt)", "").ToString().PadLeft(12, "0") & _
                                                dc.Rows.Count.ToString().PadLeft(4, "0") & _
                                                "".PadLeft(3, "0") & _
                                                "".PadLeft(60, " ") & _
                                                "9"

                        Response.ClearHeaders()
                        Response.Clear()
                        Response.Expires = 0
                        Response.Buffer = True
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5")
                        '檔案名稱
                        Response.AddHeader("content-disposition", "attachment; filename=" & System.Web.HttpUtility.UrlEncode("PAY2102_" & Convert.ToInt32(Year(Date.Today())) - 1911 & Right("0" & Month(Date.Today()), 2) & Right("0" & Day(Date.Today), 2) & Right(Date.Now, 8).ToString.Substring(0, 2) & Right(Date.Now, 8).ToString.Substring(3, 2) & Right(Date.Now, 8).ToString.Substring(6, 2) & "_轉帳" & ".txt"))
                        Response.ContentType = "text/plain"
                        '檔案內容
                        '資料標頭
                        Response.Write(String1 & vbCrLf)
                        For i As Integer = 0 To dc.Rows.Count - 1
                            Dim BankAccount_nos As String = dc.Rows(i).Item("BankAccount_nos").ToString.PadLeft(14, "0")
                            Dim Beneficiary_name As String = dc.Rows(i).Item("Beneficiary_name").ToString.PadRight(12, "0")
                            Dim PurchaseTotal_amt As String = dc.Rows(i).Item("PurchaseTotal_amt").ToString.PadLeft(12, "0")
                            '資料明細
                            Response.Write("".PadLeft(3, " ") & BankAccount_nos & PurchaseTotal_amt & "".PadLeft(30, " ") & Beneficiary_name & YYYMMDDString.PadLeft(8, " ") & "零用金".PadRight(40, " ") & "9" & vbCrLf)
                        Next

                        Response.End()
                    Else
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無銀行資料")
                    End If

                Else '查無資料
                    Dim PettyCash_nosRange As String = ""
                    If Not String.IsNullOrEmpty(Server.HtmlEncode(PettyCash_nosS.Text)) Then
                        PettyCash_nosRange &= Server.HtmlEncode(PettyCash_nosS.Text)
                    End If
                    If Not String.IsNullOrEmpty(Server.HtmlEncode(PettyCash_nosE.Text)) Then
                        PettyCash_nosRange &= "-"
                        PettyCash_nosRange &= Server.HtmlEncode(PettyCash_nosE.Text)
                    End If
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無民國" & Server.HtmlEncode(UcROCYear.Year) & "年" & PettyCash_nosRange & "媒體檔資料")
                End If
            Case "2" '大批匯款明細表(匯出媒體檔)
                '民國兩碼年月日
                Dim YYMMDDString As String = (Convert.ToInt32(Year(Date.Today())) - 1911).ToString.Substring(1, 2) & Right("0" & Month(Date.Today()), 2) & Right("0" & Day(Date.Today), 2)
                Dim Petty As String = (LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) & "零用金專戶").PadRight(GetPadLength(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) & "零用金專戶", 68), "")
                Dim Filler As String = ("").PadRight(GetPadLength("", 64), "")
                Dim db As DataTable = New DataTable
                Dim dc As DataTable = New DataTable
                Dim mc As PAY2102 = New PAY2102()
                Dim md As SATDPF = New SATDPF()
                dc = mc.Select_02_01(Server.HtmlEncode(PettyCash_nosS.Text), Server.HtmlEncode(PettyCash_nosE.Text), Server.HtmlEncode(ucBeneficiary.Beneficiary_ID), Server.HtmlEncode(UcROCYear.Year))
                If dc.Rows.Count > 0 Then
                    db = md.SelectSATDPF(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), "E")
                    Dim String1 As String = "1" & db.Rows(0).Item("TDPF_BRANCH") & YYMMDDString & db.Rows(0).Item("TDPF_CUSTOM") & "00000" & YYMMDDString & "                       " & Petty & Filler
                    Dim String2_1 As String = "2" & db.Rows(0).Item("TDPF_BRANCH") & YYMMDDString
                    Dim Total As Integer = 0
                    Response.ClearHeaders()
                    Response.Clear()
                    Response.Expires = 0
                    Response.Buffer = True
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5")
                    '檔案名稱
                    Response.AddHeader("content-disposition", "attachment; filename=" & System.Web.HttpUtility.UrlEncode("PAY2102_" & Convert.ToInt32(Year(Date.Today())) - 1911 & Right("0" & Month(Date.Today()), 2) & Right("0" & Day(Date.Today), 2) & Right(Date.Now, 8).ToString.Substring(0, 2) & Right(Date.Now, 8).ToString.Substring(3, 2) & Right(Date.Now, 8).ToString.Substring(6, 2) & "_匯款" & ".txt"))
                    Response.ContentType = "text/plain"
                    '檔案內容
                        '資料標頭
                    Response.Write(String1 & vbCrLf)
                    For i As Integer = 0 To dc.Rows.Count - 1
                        Dim SerialNumber As String = dc.Rows(i).Item("SerialNumber").ToString.PadLeft(GetPadLength(dc.Rows(i).Item("SerialNumber").ToString, 5), "0")
                        Dim BankAccount_nos As String = dc.Rows(i).Item("BankAccount_nos").ToString.PadLeft(GetPadLength(dc.Rows(i).Item("BankAccount_nos").ToString, 14), "0")
                        Dim Beneficiary_name As String = dc.Rows(i).Item("Beneficiary_name").ToString.PadRight(GetPadLength(dc.Rows(i).Item("Beneficiary_name").ToString, 68), "")
                        Dim PurchaseTotal_amt As String = dc.Rows(i).Item("PurchaseTotal_amt").ToString.PadLeft(12, "0") & "00"
                        Total = Total + CType(dc.Rows(i).Item("PurchaseTotal_amt"), Integer)
                        '資料明細
                        Response.Write(String2_1 & SerialNumber & YYMMDDString & dc.Rows(i).Item("Bank_id") & "10" & BankAccount_nos & Beneficiary_name & PurchaseTotal_amt & ("").PadRight(GetPadLength("", 50), "") & vbCrLf)
                    Next
                    Dim String3 As String = "3" & db.Rows(0).Item("TDPF_BRANCH") & YYMMDDString & db.Rows(0).Item("TDPF_CUSTOM") & "99999" & YYMMDDString & dc.Rows.Count.ToString.PadLeft(4, "0") & Total.ToString.PadLeft(12, "0") & "00" & ("").PadRight(GetPadLength("", 137), "")
                    '最後一筆資料
                    Response.Write(String3)
                    Response.End()
                Else '查無資料
                    Dim PettyCash_nosRange As String = ""
                    If Not String.IsNullOrEmpty(Server.HtmlEncode(PettyCash_nosS.Text)) Then
                        PettyCash_nosRange &= Server.HtmlEncode(PettyCash_nosS.Text)
                    End If
                    If Not String.IsNullOrEmpty(Server.HtmlEncode(PettyCash_nosE.Text)) Then
                        PettyCash_nosRange &= "-"
                        PettyCash_nosRange &= Server.HtmlEncode(PettyCash_nosE.Text)
                    End If
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無民國" & Server.HtmlEncode(UcROCYear.Year) & "年" & PettyCash_nosRange & "媒體檔資料")
                End If
        End Select
    End Sub
#End Region
#Region " 重置"
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)

    End Sub
#End Region
#Region "列印"
    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim pagerowcnt As Integer = 25
        Dim url As String = "PAY2102_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(Server.HtmlEncode(PettyCash_nosS.Text)) Then
            url &= "&PettyCash_nosS=" & Server.HtmlEncode(PettyCash_nosS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(PettyCash_nosE.Text)) Then
            url &= "&PettyCash_nosE=" & Server.HtmlEncode(PettyCash_nosE.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ucBeneficiary.Beneficiary_ID)) Then
            url &= "&Beneficiary_id=" & Server.HtmlEncode(ucBeneficiary.Beneficiary_ID)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(UcROCYear.Year)) Then
            url &= "&year=" & Server.HtmlEncode(UcROCYear.Year)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Type.SelectedValue)) Then
            url &= "&Type=" & Server.HtmlEncode(Type.SelectedValue)
        End If
        Response.Redirect(url)
        'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")
    End Sub
#End Region
    Public Function GetPadLength(ByVal s As String, ByVal expectLength As Integer) As String
        Return expectLength - (System.Text.Encoding.Default.GetBytes(s).Length - s.Length)
    End Function
End Class


