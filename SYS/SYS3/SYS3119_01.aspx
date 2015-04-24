<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3119_01.aspx.vb" Inherits="SYS3119_01"  %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="Table1" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99"
    width="100%">
    <tr>
        <td class="htmltable_Title" colspan="4">
            機關資料維護
        </td>
    </tr>
    <tr>
        <td class="htmltable_Title2" colspan="4">
            查詢條件</td>
    </tr>
    <tr>
        <td class="htmltable_Left" style="width:120px">
            機關代碼</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbOrgcode" runat="server"></asp:TextBox>
        </td>
        <td class="htmltable_Left" style="width:120px">
            機關名稱</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbOrgcodeName" runat="server"></asp:TextBox>
        </td>
    </tr>    
    <tr>
        <td class="htmltable_Bottom" colspan="4">
            <asp:Button ID="cbQuery" runat="server" CausesValidation="False" Text="查詢" />
            <asp:Button ID="cbAdd" runat="server" Text="新增" CausesValidation="False" /></td>
    </tr>
</table>
<br />     
<table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
    <tr>
        <td class="htmltable_Title2" style="width: 100%" align="center">
            查詢結果</td>
    </tr>    
    <tr>
        <td>            
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red">                       
                <Columns>
                    <asp:BoundField DataField="Orgcode" HeaderText="機關代號" />
                    <asp:BoundField DataField="Orgcode_name" HeaderText="機關名稱" />
                    <asp:BoundField DataField="Orgcode_shortname" HeaderText="機關簡易名稱" />
                    <asp:TemplateField HeaderText="功能">
                        <ItemTemplate>                                          
                            <asp:Button ID="cbUpdate" runat="server" Text="修改" onclick="cbUpdate_Click" />
                            <asp:Button ID="cbDelete" runat="server" Text="刪除" onclick="cbDelete_Click" OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Right" />
                <EmptyDataTemplate>
                    查無資料!!
                </EmptyDataTemplate>
                <RowStyle CssClass="Row" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />                    
            </asp:GridView>
            
            
        </td>    
    </tr>
</table>

</asp:Content>

