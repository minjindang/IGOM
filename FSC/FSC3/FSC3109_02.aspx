<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3109_02.aspx.vb" Inherits="FSC3109_02" %>

<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/FSC/UcLeaveMember.ascx" TagName="UcLeaveMember" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcLeaveDate.ascx" TagName="UcLeaveDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc6" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tb" border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">大批請假</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>假別</td>
            <td class="htmltable_Right">
                <div style="float: left">
                    <asp:DropDownList ID="ddlLeave_type" runat="server" DataTextField="Leave_name" DataValueField="Leave_type">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>表單申請人</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <uc6:UcDDLDepart runat="server" ID="UcDDLDepart" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEmployee_type" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="lbUnSelectMember" runat="server" DataTextField="User_name" DataValueField="Id_card" SelectionMode="Multiple" Width="280" Height="200"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:Button ID="cbToR" runat="server" Text="選擇>>" />
                                    <br />
                                    <asp:Button ID="cbToL" runat="server" Text="<<取消" />
                                </td>
                                <td>
                                    <asp:ListBox ID="lbMember" runat="server" DataTextField="full_name" SelectionMode="Multiple" Width="280" Height="200"></asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>請假日期</td>
            <td class="htmltable_Right" valign="top">
                <uc2:UcLeaveDate ID="UcLeaveDate" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <uc5:UcTextBox ID="tbReason" runat="server" EnableViewState="true" MaxLength="30"
                    TextMode="MultiLine" Width="300" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                備註說明</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMemo" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="htmltable_Bottom" colspan="3" style="border-top: none;">
                <asp:Button ID="cbSubmit" runat="server" Text="確定" /><input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)" /></td>
        </tr>
    </table>
</asp:Content>

