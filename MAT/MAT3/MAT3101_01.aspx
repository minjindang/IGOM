<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="false" CodeFile="MAT3101_01.aspx.vb" Inherits="MAT_MAT3_MAT3101_01" %>

<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %> 
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart02" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">
                    雜項領物-查詢
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    請購日期(起~迄)
                </td>
                <td colspan="3">
                    <uc2:UcDate ID="ucApply_dateS" runat="server" />
                    ~
                    <uc2:UcDate ID="ucApply_dateE" runat="server" /> 
                    
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    請購單位別
                </td>
                <td style="width: 326px">
                    <uc2:UcDDLDepart02 runat="server" ID="UcDDLDepart02" OnSelectedIndexChanged="UcDDLDepart02_SelectedIndexChanged" />
                </td>
                <td class="htmltable_Left">
                    領物人員
                </td>
                <td style="width: 326px">
                    <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="AddBtn" runat="server" Text="新增" PostBackUrl="~/MAT/MAT3/MAT3101_02.aspx" />
                    <asp:Button ID="QryBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" /> 
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="Details_id"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px" EmptyDataText="查無資料!!"
                Width="100%"> 
                <Columns>
                    <asp:BoundField DataField="Flow_id" HeaderText="請購單號" /> 
                    <asp:BoundField DataField="Material_name" HeaderText="物料名稱" /> 
                    <asp:BoundField DataField="Out_cnt" HeaderText="使用數量" /> 
                    <asp:BoundField DataField="Unit" HeaderText="單位" /> 
                    <asp:BoundField DataField="TotalPrice_amt" HeaderText="總價" /> 
                    <asp:BoundField DataField="Company_name" HeaderText="廠商" />     
                    <asp:BoundField DataField="Memo" HeaderText="用途及備註" />     
                    <asp:BoundField DataField="Apply_date" HeaderText="領物日期" />
                    <asp:BoundField DataField="User_name" HeaderText="領物人員" />
                    <asp:TemplateField HeaderText="維護">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="維護" CommandName="Maintain" CommandArgument='<%# Eval("Details_id") %>' />
                            <asp:Button ID="btnDelete" CommandName="GoDelete" CommandArgument='<%# Eval("Details_id") %>' 
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                    <EmptyDataTemplate>
                       查無資料!!
                 </EmptyDataTemplate>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
             <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                        Other1="Ucpager2" PNow="1" PSize="10" Visible="true" />
        </div>
    </div>
</asp:Content>
