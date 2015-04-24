<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SAL2111.aspx.vb" Inherits="SAL_SAL2_SAL2111" %>

<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">各項調整薪差發放清冊
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">人員類別</td>
                    <td class="htmltable_Right">
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Text="全部" Value=""></asp:ListItem>
                            <%--<asp:ListItem Text="全部(含臨時人員)" Value="002"></asp:ListItem>--%>
                            <asp:ListItem Text="全部(不含臨時人員)" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="htmltable_Left">發放年月</td>
                    <td class="htmltable_Right" style="width: 326px">民國
                        <uc2:UcROCYearMonth ID="UcDate1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">預算來源
                    </td>
                    <td class="htmltable_Right" style="width: 326px" colspan="3">
                        <asp:DropDownList ID="DropDownList3" runat="server">
                            <asp:ListItem Value="0" Text="公務預算" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="空污預算"></asp:ListItem>
                            <asp:ListItem Value="2" Text="水利預算"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="Button_report" runat="server" Text="列印" />
                    </td>
                </tr>
                </tr>
            </table>

            <div id="div_info" runat="server" style="display: none">
                ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
                MID=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
