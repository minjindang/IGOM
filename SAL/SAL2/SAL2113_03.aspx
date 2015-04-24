<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SAL2113_03.aspx.vb" Inherits="SAL2113_03" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>全民健康保險投保單位補充保險費繳款書</title>
</head>
<body>
    <form id="form1" runat="server">
              <table border="0" cellpadding="0" cellspacing="0" width="100%" style="font-family: 標楷體">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 80%; text-align: center;">
                                    <font size="5pt"><b>全民健康保險<br />
                                        投保單位補充保險費繳款書
                                    </b></font>
                                </td>
                                <td>
                                    <table border="1pt" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="height: 50pt;">
                                                <font size="2pt">收據聯：<br />
                                                    本聯經代收機構收款<br />
                                                    蓋章後，交扣費義務<br />
                                                    人收執，做繳費憑證<br />
                                                </font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="1pt" cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="5">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="width: 100%">
                                                <font size="2pt">投保單位代號：</font>
                                                <asp:Label ID="lbUNhiCode" runat="server" Text="" Font-Size="12pt"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <font size="2pt">投保單位名稱：</font>
                                                <asp:Label ID="lbNhiName" runat="server" Text="" Font-Size="12pt"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30pt;" width="35%" align="center">
                                    <font size="4pt">給　　付　　年　　月</font>
                                </td>
                                <td width="35%" align="center">
                                    <asp:Label ID="lbYM" runat="server" Text="" Font-Size="12pt"></asp:Label>

                                </td>
                                <td width="30%" align="center">
                                    <font size="2pt">代收機構<br />
                                        經收人員蓋章</font>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30pt;" width="35%" align="center">
                                    <font size="4pt">繳　　款　　期　　限</font>
                                </td>
                                <td width="35%" align="center">
                                    <asp:Label ID="lbPayLimit" runat="server" Text="" Font-Size="12pt"></asp:Label>
                                </td>
                                <td width="30%" align="center" rowspan="2">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30pt;" width="35%" align="center">
                                    <font size="4pt">應　　繳　　金　　額</font>
                                </td>
                                <td width="35%" align="center">
                                    <asp:Label ID="lbAmt" runat="server" Text="" Font-Size="12pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td colspan="2">
                                                <font size="2pt">說明：</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <font size="2pt">一、投保單位依健保法第34條規定應負擔之補充保險費，應於次月底前繳納，得寬限15日；逾寬限期未繳納者，自寬限期滿<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;之翌日起至完納前1日止，每逾1日加徵其應納費額0.1%之滯納金；加徵之滯納金總額，最高為應納費額之15%為限；<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;逾寬限期限繳納保險費者，其應繳之滯納金將另行通知繳納。<br /><br />
                                                    二、投保單位請持本繳款書至健保署委託代收金融機構繳納；倘繳納金額2萬元以下，亦可至統一、全家、萊爾富及OK等便<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;利商店繳費(需自行負擔手續費3元)。<br /><br />
                                                    三、依健保法第35條第2項之規定，投保單位自應繳納之日起，逾30日未繳納者，本署得移送行政執行。<br />
                                                    <br />
                                                </font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td width="12%" align="right">
                                                            <font size="2pt">洽詢電話：</font>
                                                        </td>
                                                        <td colspan="2">
                                                            <font size="2pt">0800-030598</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="right">
                                                            <font size="2pt">繳款單編號：</font>
                                                        </td>
                                                        <td width="40%">
                                                            <asp:Label ID="lbBarCode" runat="server" Text="" Font-Size="10pt"></asp:Label>
                                                        </td>
                                                        <td valign="top">列印日期：
                                            <asp:Label ID="lbPrintDate" runat="server" Text="" Font-Size="10pt"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td style="height: 50pt;">
                                    <hr style="height: 1px; border: none; border-top: 1px dashed #CCCCCC;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 80%; text-align: center;">
                                    <font size="5pt"><b>全民健康保險<br />
                                        投保單位補充保險費繳款書
                                    </b></font>
                                </td>
                                <td>
                                    <table border="1pt" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td valign="middle" align="center" style="height: 50pt;">
                                                <font size="2pt">代收機構存查聯
                                                </font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="1" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="height: 40pt;" align="center" width="30%">
                                    <font size="4pt">條碼區</font>
                                </td>
                                <td align="center" colspan="4">
                                    <font size="4pt">代收明細</font>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="4" align="left">
                                    <font size="2pt">金融機構或便利商店繳費專用條碼<br />
                                    </font>
                                    &nbsp;&nbsp;<asp:Image ID="imgCode1" ImageUrl="" runat="server" Height="35" /><br />
                                    &nbsp;&nbsp;<asp:Image ID="imgCode2" ImageUrl="" runat="server" Height="35" /><br />
                                    &nbsp;&nbsp;<asp:Image ID="imgCode3" ImageUrl="" runat="server" Height="35" /><br />
                                </td>
                                <td style="height: 40pt;" align="center" width="20%">
                                    <font size="4pt">投保單位代號</font>
                                </td>
                                <td align="center" width="20%">
                                    <asp:Label ID="lbUNhiCode2" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td align="center" width="15%">
                                    <font size="4pt">連絡電話</font>
                                </td>
                                <td align="center" width="15%">
                                    <asp:Label ID="lbUnitTel" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40pt;" align="center">
                                    <font size="4pt">給付年月</font>
                                </td>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lbYM2" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td align="center" colspan="2">
                                    <font size="4pt">代收機構經手人員蓋章</font>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40pt;" align="center">
                                    <font size="4pt">應繳金額</font>
                                </td>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lbAmt2" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td align="center" rowspan="2">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60pt;" align="center" colspan="3">
                                    <font size="4pt">&nbsp;</font>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>


   