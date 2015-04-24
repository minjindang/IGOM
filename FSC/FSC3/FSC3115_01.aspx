<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3115_01.aspx.vb" Inherits="FSC3_FSC3115_01" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">資料同步作業</td>
        </tr>
        <tr>
            <td class="htmltable_Left">P2K來源：</td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlDBString" runat="server">
                    <asp:ListItem Value="1">環保署</asp:ListItem>
                    <asp:ListItem Value="2">水利署</asp:ListItem>
                    <asp:ListItem Value="3">警察大隊</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">員工編號：</td>
            <td style="width: 326px">
                <asp:TextBox ID="tbPECARD" runat="server" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">姓名：</td>
            <td style="width: 326px">
                <asp:TextBox ID="tbPENAME" runat="server" MaxLength="12"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" >
                <asp:Button ID="btnQuery" runat="server" Text="查詢 " />              
            </td>
        </tr>
    </table>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" AllowPaging="True" PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" PageSize="100">
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <Columns>
                <asp:TemplateField HeaderText="員工代號">
                    <ItemTemplate>
                        <asp:label ID="lbPECARD" runat="server" Text='<%# Eval("PECARD")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:label ID="lbPENAME" runat="server" Text='<%# Eval("PENAME")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="身分證字號">
                    <ItemTemplate>
                        <asp:label ID="lbPEIDNO" runat="server" Text='<%# Eval("PEIDNO")%>'></asp:label>
                        <asp:HiddenField ID="hfPEIDNO" runat="server"  Value='<%# Eval("PEIDNO2")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="到職日期">
                    <ItemTemplate>
                        <asp:label ID="lbPEACTDATE" runat="server" Text='<%# Eval("PEACTDATE")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="離職日期">
                    <ItemTemplate>
                        <asp:label ID="lbPELEVDATE" runat="server" Text='<%# Eval("PELEVDATE")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="俸點">
                    <ItemTemplate>
                        <asp:label ID="lbPEPOINT" runat="server" Text='<%# Eval("PEPOINT")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="專業加給">
                    <ItemTemplate>
                        <asp:label ID="lbPEPROFESS" runat="server" Text='<%# Eval("PEPROFESS")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="主管職務加給">
                    <ItemTemplate>
                        <asp:label ID="lbPECHIEF" runat="server" Text='<%# Eval("PECHIEF")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="檢視">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click" Text ="檢視" ></asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRow" />
            <HeaderStyle CssClass="Grid" />
            <PagerSettings Visible="False" />
            <RowStyle CssClass="Row" />
        </asp:GridView>
</asp:Content>
