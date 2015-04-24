<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="SAL2110_01.aspx.vb" Inherits="SAL_SAL2_SAL2110_01" %>

<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">各項調整薪差發放清冊
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">人員類別</td>
                    <td class="htmltable_Right">
                        <asp:DropDownList ID="ddlsaproj" runat="server">
                            <%--<asp:ListItem Text="政務人員" Value="001"></asp:ListItem>
                            <asp:ListItem Text="一般行政人員" Value="002"></asp:ListItem>
                            <asp:ListItem Text="監察調查人員" Value="003"></asp:ListItem>
                            <asp:ListItem Text="約聘僱人員" Value="004"></asp:ListItem>
                            <asp:ListItem Text="駐衛警察" Value="005"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td class="htmltable_Left">發放年月</td>
                    <td class="htmltable_Right" style="width: 326px">民國
                        <uc2:UcROCYearMonth ID="UcDate1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="Button_report" runat="server" Text="列印" />
                        <asp:Literal ID="Literal1" runat="server" Visible="true"></asp:Literal>
                    </td>
                </tr>
                </tr>
            </table>

            <div id="div_info" runat="server" style="display: none">
                ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
                MID=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
            </div>
        <Triggers>
        </Triggers>
</asp:Content>
