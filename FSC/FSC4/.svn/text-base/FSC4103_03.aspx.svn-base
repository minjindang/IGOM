<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4103_03.aspx.vb" Inherits="FSC4103_03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfOrgcode" runat="server" />
    <asp:HiddenField ID="hfLoginCardId" runat="server" />
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" runat="server"
        id="TbMailSetting">
        <tr>
            <td>
                <table border="1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server"
                    id="Table2" class="tableStyle99">
                    <tr>
                        <td colspan="4" class="htmltable_Title2">
                            修改刷卡補登次數
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left2">
                            項次</td>
                        <td class="htmltable_Left2">
                            設定內容</td>
                    </tr>
                    <tr>
                        <td class="htmltable_Middle">
                            1
                        </td>
                        <td class="htmltable_Right">
                            <asp:RadioButton ID="rdbIsSelect1" GroupName="NotCheckInOutSetting" runat="server"
                                Checked="true" />
                            刷卡補登不限次數。
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Middle">
                            2
                        </td>
                        <td class="htmltable_Right">
                            <asp:RadioButton ID="rdbIsSelect2" GroupName="NotCheckInOutSetting" runat="server" />
                            每年上限<asp:TextBox ID="txtItem2YearTimes" runat="server" Width="50px" MaxLength="2"
                                CssClass="NumAlignRight"></asp:TextBox>次， 且每月上限<asp:TextBox ID="txtItem2MonthTimes"
                                    runat="server" Width="50px" MaxLength="2" CssClass="NumAlignRight"></asp:TextBox>次。
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Middle">
                            3
                        </td>
                        <td class="htmltable_Right">
                            <asp:RadioButton ID="rdbIsSelect3" GroupName="NotCheckInOutSetting" runat="server" />
                            每年上限<asp:TextBox ID="txtItem3YearTimes" runat="server" Width="50px" MaxLength="2"
                                CssClass="NumAlignRight"></asp:TextBox>次。
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Middle">
                            4
                        </td>
                        <td class="htmltable_Right">
                            <asp:RadioButton ID="rdbIsSelect4" GroupName="NotCheckInOutSetting" runat="server" />
                            每月上限<asp:TextBox ID="txtItem4MonthTimes" runat="server" Width="50px" MaxLength="2"
                                CssClass="NumAlignRight"></asp:TextBox>次。
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="htmltable_Bottom">
                            <asp:Button ID="btnConfirm" Text="確認" runat="server"></asp:Button>
                            <asp:Button ID="btnPrevious" Text="返回上一頁" runat="server"></asp:Button>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
