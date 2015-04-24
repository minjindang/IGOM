Imports System.Data.SqlClient

Partial Class SAL2120_04
    Inherits BaseWebForm
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack Then

            ShowReport()

        End If

    End Sub

    Protected Sub ShowReport()
        Dim p_type As String = Request("p_type")


        Dim seqno As String = Request("seqno")
        Dim seqnoz() As String = seqno.Trim.Split(",")

        Dim year As String = Request("year")
        Dim yearz() As String = year.Trim.Split(",")

        Dim nhikind As String = Request("nhikind")
        Dim nhikindz() As String = nhikind.Trim.Split(",")

        Dim amt As String = Request("amt")
        Dim amtz() As String = amt.Trim.Split(",")

        Dim ext As String = Request("ext")
        Dim extz() As String = ext.Trim.Split(",")

        'Response.Write("<br />seqno=" & seqno)
        'Response.Write("<br />year=" & year)
        'Response.Write("<br />nhikind=" & nhikind)
        'Response.Write("<br />amt=" & amt)
        'Response.Write("<br />ext=" & ext)

        For i As Integer = 0 To seqnoz.Length - 1

            If i <> 0 Then
                Response.Write("<p style='page-break-after:always'>&nbsp</p>")
            End If

            Dim cmd As New SqlCommand
            cmd.CommandText &= " select b.base_name, b.base_addr, b.base_idno "
            cmd.CommandText &= " ,'' nhi_code "
            cmd.CommandText &= " ,u.unit_tax, u.unit_hname, u.unit_addr, u.unit_dep "

            cmd.CommandText &= " from SAL_sabase b "

            'cmd.CommandText &= " left outer join SAL_sanhi n "
            'cmd.CommandText &= " on base_orgid = nhi_orgid "
            'cmd.CommandText &= " and base_nhino = nhi_no "

            cmd.CommandText &= " left outer join SAL_saunit u "
            cmd.CommandText &= " on unit_no = base_orgid "

            cmd.CommandText &= " where b.base_seqno = @seqno "

            cmd.Parameters.AddWithValue("@seqno", seqnoz(i))
            Using connection As New SqlConnection(ConfigurationManager.AppSettings("DBString"))
                connection.Open()
                cmd.Connection = connection
                Dim rs As SqlDataReader = cmd.ExecuteReader()

                If rs.Read Then
                    Dim rd As New rdata

                    rd.nhi_kind = nhikindz(i)
                    If rd.nhi_kind = "62" Then
                        rd.nhi_code = rs("nhi_code").ToString
                    End If

                    rd.unit_dep = rs("unit_dep").ToString
                    rd.unit_tax = rs("unit_tax").ToString
                    rd.unit_hname = rs("unit_hname").ToString
                    rd.unit_addr = rs("unit_addr").ToString

                    rd.inco_year = yearz(i)
                    rd.inco_amt = FormatNumber(amtz(i), 0)
                    rd.inco_health_ext = FormatNumber(extz(i), 0)

                    Dim idno As String = rs("base_idno").ToString
                    idno = idno.Substring(0, idno.Length - 4) & "****"

                    rd.base_idno = idno

                    rd.base_name = rs("base_name").ToString
                    rd.base_addr = rs("base_addr").ToString

                    Response.Write(GetHtml(p_type, rd))
                End If
                connection.Close()
            End Using
        Next

    End Sub

    Protected Class rdata
        Public nhi_kind As String = ""
        Public nhi_code As String = ""

        Public inco_year As String = ""
        Public inco_amt As String = ""
        Public inco_health_ext As String = ""

        Public base_name As String = ""
        Public base_addr As String = ""
        Public base_idno As String = ""

        Public unit_tax As String = ""
        Public unit_hname As String = ""
        Public unit_addr As String = ""
        Public unit_dep As String = ""
    End Class


    Protected Function GetHtml(ByVal P_Type As String, ByVal rd As rdata) As String
        Dim rv As String = ""

        rv &= "<table width='700' height='950' border='0' cellpadding='0' cellspacing='0' style='font-family:標楷體;'>"

        If P_Type = "1" Or P_Type = "3" Then

            rv &= "<tr><td height='47%' width='100%'>"

            rv &= "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='3'>"
            rv &= "  <tr valign='bottom'>"
            rv &= "    <td height='10%' width='61%' align='right' rowspan='2'>"
            rv &= "      <font size='5'><b>"
            rv &= "      全民健康保險<br/>"
            rv &= "      各類所得補充保險費扣費證明單"
            rv &= "      </b></font>"
            rv &= "    </td>"
            rv &= "    <td width='14%' rowspan='2'>&nbsp;</td>"
            rv &= "    <td width='25%' height='8%'>&nbsp;</td>"
            rv &= "  </tr>"
            rv &= "  <tr>"
            rv &= "    <td width='25%'>"
            rv &= "      <table width='100%' height='100%' border='1' cellpadding='0' cellspacing='0'><tr><td align='center' style='border-color:Black;' valign='bottom'><font size='2'>存根聯</font></td></tr></table>"
            rv &= "    </td>"
            rv &= "  </tr>"
            rv &= "  <tr>"
            rv &= "    <td height='75%' colspan='3'>"
            rv &= "      <table width='100%' height='100%' border='1' cellpadding='0' cellspacing='0' style='border-color:Black;'>"
            rv &= "        <tr >"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>扣費單位統一編號</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%'>所得人身分證號</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%' colspan='3'>所得(收入)類別代號</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%'>投保單位代號</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>&nbsp;" & rd.unit_tax & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%'>&nbsp;" & rd.base_idno & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%' colspan='3'>&nbsp;" & rd.nhi_kind & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%' rowspan='2'><font size='2'>"
            rv &= "            " & rd.nhi_code & "<br/>(填列獎金所得時必填)"
            rv &= "          </font></td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>所得人姓名</td>"
            rv &= "          <td align='center' style='border-color:Black;' colspan='4'>&nbsp;" & rd.base_name & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>所得人地址</td>"
            rv &= "          <td align='center' style='border-color:Black;' colspan='5'>&nbsp;" & rd.base_addr & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>所得給付年度</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='33%' colspan='2'>給付總額</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='42%' colspan='3'>扣繳補充保險費金額</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>&nbsp;" & rd.inco_year & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='33%' colspan='2'>&nbsp;" & rd.inco_amt & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='42%' colspan='3'>&nbsp;" & rd.inco_health_ext & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='66%' colspan='5'>扣　　費　　單　　位</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='34%' colspan='2'>扣繳補充代號說明</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='17%'>名　　　稱</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='49%' colspan='4'>&nbsp;" & rd.unit_dep & "</td>"
            rv &= "          <td align='left' style='border-color:Black;' width='34%' colspan='2' rowspan='3'><font size='1'>"
            rv &= "          &nbsp;62.所屬投保單位給付全年累計逾當月<br/>&nbsp;投保金額四倍之獎金<br/>"
            rv &= "          &nbsp;63.非所屬投保單位給付之薪資所得<br/>"
            rv &= "          &nbsp;65.執行業務收入<br/>"
            rv &= "          &nbsp;66.股利所得<br/>"
            rv &= "          &nbsp;67.利息所得<br/>"
            rv &= "          &nbsp;68.租金收入"
            rv &= "          </font></td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='17%'>地　　　址</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='49%' colspan='4'>&nbsp;" & rd.unit_addr & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='17%'>扣費義務人</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='49%' colspan='4'>&nbsp;" & rd.unit_hname & "</td>"
            rv &= "        </tr>"
            rv &= "      </table>"
            rv &= "    </td>"
            rv &= "  </tr>"

            rv &= "  <tr valign='top'>"
            rv &= "    <td height='15%' colspan='3'>"
            rv &= "      <br/>＊存根聯&nbsp;扣繳單位存查"
            rv &= "      <br/>＊備查聯&nbsp;交所得人保存備查"
            rv &= "    </td>"
            rv &= "  </tr>"

            rv &= "</table>"
            rv &= "</td></tr>"

        End If

        If P_Type = "2" Or P_Type = "3" Then

            If P_Type = "3" Then
                rv &= "<tr><td height='6%' width='100%'>&nbsp;</td></tr>"
            End If

            rv &= "<tr><td height='47%' width='100%'>"

            rv &= "<table width='100%' height='100%' border='0' cellpadding='0' cellspacing='3'>"
            rv &= "  <tr valign='bottom'>"
            rv &= "    <td height='10%' width='61%' align='right' rowspan='2'>"
            rv &= "      <font size='5'><b>"
            rv &= "      全民健康保險<br/>"
            rv &= "      各類所得補充保險費扣費證明單"
            rv &= "      </b></font>"
            rv &= "    </td>"
            rv &= "    <td width='14%' rowspan='2'>&nbsp;</td>"
            rv &= "    <td width='25%' height='8%'>&nbsp;</td>"
            rv &= "  </tr>"
            rv &= "  <tr>"
            rv &= "    <td width='25%'>"
            rv &= "      <table width='100%' height='100%' border='1' cellpadding='0' cellspacing='0'><tr><td align='center' style='border-color:Black;' valign='bottom'><font size='2'>備查聯</font></td></tr></table>"
            rv &= "    </td>"
            rv &= "  </tr>"
            rv &= "  <tr>"
            rv &= "    <td height='75%' colspan='3'>"
            rv &= "      <table width='100%' height='100%' border='1' cellpadding='0' cellspacing='0' style='border-color:Black;'>"
            rv &= "        <tr >"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>扣費單位統一編號</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%'>所得人身分證號</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%' colspan='3'>所得(收入)類別代號</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%'>投保單位代號</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>&nbsp;" & rd.unit_tax & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%'>&nbsp;" & rd.base_idno & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%' colspan='3'>&nbsp;" & rd.nhi_kind & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='25%' rowspan='2'><font size='2'>"
            rv &= "            " & rd.nhi_code & "<br/>(填列獎金所得時必填)"
            rv &= "          </font></td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>所得人姓名</td>"
            rv &= "          <td align='center' style='border-color:Black;' colspan='4'>&nbsp;" & rd.base_name & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>所得人地址</td>"
            rv &= "          <td align='center' style='border-color:Black;' colspan='5'>&nbsp;" & rd.base_addr & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>所得給付年度</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='33%' colspan='2'>給付總額</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='42%' colspan='3'>扣繳補充保險費金額</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='25%' colspan='2'>&nbsp;" & rd.inco_year & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='33%' colspan='2'>&nbsp;" & rd.inco_amt & "</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='42%' colspan='3'>&nbsp;" & rd.inco_health_ext & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='66%' colspan='5'>扣　　費　　單　　位</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='34%' colspan='2'>扣繳補充代號說明</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='17%'>名　　　稱</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='49%' colspan='4'>&nbsp;" & rd.unit_dep & "</td>"
            rv &= "          <td align='left' style='border-color:Black;' width='34%' colspan='2' rowspan='3'><font size='1'>"
            rv &= "          &nbsp;62.所屬投保單位給付全年累計逾當月<br/>&nbsp;投保金額四倍之獎金<br/>"
            rv &= "          &nbsp;63.非所屬投保單位給付之薪資所得<br/>"
            rv &= "          &nbsp;65.執行業務收入<br/>"
            rv &= "          &nbsp;66.股利所得<br/>"
            rv &= "          &nbsp;67.利息所得<br/>"
            rv &= "          &nbsp;68.租金收入"
            rv &= "          </font></td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='17%'>地　　　址</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='49%' colspan='4'>&nbsp;" & rd.unit_addr & "</td>"
            rv &= "        </tr>"
            rv &= "        <tr>"
            rv &= "          <td align='center' style='border-color:Black;' height='10%' width='17%'>扣費義務人</td>"
            rv &= "          <td align='center' style='border-color:Black;' width='49%' colspan='4'>&nbsp;" & rd.unit_hname & "</td>"
            rv &= "        </tr>"
            rv &= "      </table>"
            rv &= "    </td>"
            rv &= "  </tr>"

            rv &= "  <tr valign='top'>"
            rv &= "    <td height='15%' colspan='3'>"
            rv &= "      <br/>＊存根聯&nbsp;扣繳單位存查"
            rv &= "      <br/>＊備查聯&nbsp;交所得人保存備查"
            rv &= "    </td>"
            rv &= "  </tr>"

            rv &= "</table>"
            rv &= "</td></tr>"

        End If

        If P_Type = "1" Or P_Type = "2" Then
            rv &= "<tr><td height='6%' width='100%'>&nbsp;</td></tr>"
            rv &= "<tr><td height='47%' width='100%'>&nbsp;</td></tr>"
        End If


        rv &= "</table>"

        Return rv
    End Function


End Class
