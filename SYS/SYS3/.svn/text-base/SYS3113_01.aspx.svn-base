<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3113_01.aspx.vb" Inherits="SYS3_SYS3113_01" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">作業鎖定功能</td>
        </tr>
        <tr>
            <td class="htmltable_Left">功能名稱</td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlFuncFlag" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlFuncName" runat="server">
                </asp:DropDownList>
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
                <asp:BoundField DataField="Depart_name" HeaderText="單位名稱" ></asp:BoundField>
                <asp:TemplateField HeaderText="單位代碼" Visible="false">
                    <ItemTemplate>
                        <asp:label ID="lbDepartId" runat="server" Text='<%# Eval("Depart_id")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>    
                <asp:TemplateField HeaderText="是否鎖定" Visible="false">
                    <ItemTemplate>
                        <asp:label ID="lbFreeze" runat="server" Text='<%# Eval("isFreeze")%>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>         
                <asp:TemplateField HeaderText="">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lbLockAll" runat="server" Text="全部開放" OnClick="lbLockAll_Click" ></asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lbUnLockAll" runat="server" Text="全部開放" OnClick="lbUnLockAll_Click" ></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbUpdate" runat="server" OnClick="lbUpdate_Click" ></asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="EmptyRow" />
            <HeaderStyle CssClass="Grid" />
            <PagerSettings Visible="False" />
            <RowStyle CssClass="Row" />
        </asp:GridView>
</asp:Content>
