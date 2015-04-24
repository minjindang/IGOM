<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3110_01.aspx.vb" Inherits="SYS3110_01"  %>

<%@ Register Src="~/UControl/UCTabButton.ascx" TagPrefix="uc1" TagName="UCTabButton" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" runat="server" id="Table1">
       <tr>
            <td class="htmltable_Title" colspan="2">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                假別類型
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlleaveGroup" runat="server" autopostback="true">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                假別
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlLeaveType" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" />
                <input id="cbReset" type="button" value="重填" />
                <input id="cbAdd" type="button" value="新增" onclick="document.location.href = 'SYS3110_02.aspx'" /></td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="Grid" width="100%">            
                <Columns>
                    <asp:TemplateField HeaderText="假別類型名稱">
                        <ItemTemplate>
                            <asp:Label ID="lbLeaveType" runat="server" Text='<%# Bind("Leave_group_name")%>' Width="280"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="假別名稱">
                        <ItemTemplate>
                            <asp:Label ID="lbLeaveName" runat="server" Text='<%# Bind("Leave_name")%>' Width="280"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbID" runat="server" Text='<%# Bind("id")%>' Width="280" Visible="false"></asp:Label>
                            <asp:Button ID="btnUpdate" runat="server" Text="修改" onclick="doUpdate"/>
                            <asp:Button ID="btnDel" runat="server" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定刪除?')) return false;" onclick="doDelete"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>        
                <EmptyDataTemplate>
                    查無資料
                </EmptyDataTemplate>
                <EmptyDataRowStyle CssClass="EmptyRow" />
     </asp:GridView>
</asp:Content>