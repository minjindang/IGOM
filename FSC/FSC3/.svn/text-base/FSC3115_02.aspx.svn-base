<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3115_02.aspx.vb" Inherits="FSC3_FSC3115_02" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">資料同步作業</td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" >
                <asp:Button ID="btnUpdate" runat="server" Text="更新 " />&nbsp;
                <asp:Button ID="btnReturn" runat="server" Text="回上頁 " />          
            </td>
        </tr>
    </table>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" AllowPaging="True" PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" PageSize="100">
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSubmit" runat="server" />
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="資料表名稱">
                    <ItemTemplate>
                        <asp:label ID="lbTABLENAME" runat="server" Text='<%# Eval("TABLENAME")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>
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

            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRow" />
            <HeaderStyle CssClass="Grid" />
            <PagerSettings Visible="False" />
            <RowStyle CssClass="Row" />
        </asp:GridView>
</asp:Content>
