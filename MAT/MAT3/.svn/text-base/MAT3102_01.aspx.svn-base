<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT3102_01.aspx.vb" Inherits="MAT3_MAT3102_01" %>

<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialId" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%"> 
            <tr>
                <td class="htmltable_Title" colspan="4">
                    物品入庫-查詢
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    物料編號
                </td>
                <td style="width: 326px"> 
                    <asp:TextBox ID="txtMaterialId" runat="server" Enabled="false"></asp:TextBox>
                    <uc1:UcMaterialId runat="server" ID="UcMaterialId" OnChecked="UcMaterialId_Checked" />
                </td>
                <td class="htmltable_Left">
                    廠商
                </td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtCompanyName" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    入庫日期
                </td>
                <td style="width: 326px" colspan="2" > 
                    <uc1:UcDate runat="server" ID="UcDateS" />~<uc1:UcDate runat="server" ID="UcDateE" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="AddBtn" runat="server" Text="新增" PostBackUrl="~/MAT/MAT3/MAT3102_02.aspx" />
                    <asp:Button ID="QryBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" PostBackUrl="~/MAT/MAT3/MAT3102_01.aspx" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"  
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%" EmptyDataText="查無資料!!"> 
                <Columns>
                    <asp:BoundField DataField="Material_id" HeaderText="物料編號" /> 
                    <asp:BoundField DataField="Material_name" HeaderText="物料名稱" />  
                    <asp:BoundField DataField="Unit" HeaderText="單位" /> 
                    <asp:BoundField DataField="Safe_cnt" HeaderText="安全庫存數量" /> 
                    <asp:BoundField DataField="Reserve_cnt" HeaderText="目前庫存數量" /> 
                    <asp:BoundField DataField="Buy_cnt" HeaderText="申購數量" /> 
                    <asp:BoundField DataField="In_cnt" HeaderText="入庫數量" /> 
                    <asp:BoundField DataField="UnitPrice_amt" HeaderText="單價" DataFormatString="{0:N2}" />  
                    <asp:BoundField DataField="Company_name" HeaderText="廠商" />     
                    <asp:BoundField DataField="Memo" HeaderText="備註說明" />
                     <asp:TemplateField HeaderText="異動日期">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="lbMod_date" runat="server" Text='<%# FSC.Logic.DateTimeInfo.ToDisplay(FSC.Logic.DateTimeInfo.GetRocDate(Eval("Mod_date")))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>             
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="維護" CommandName="Maintain" CommandArgument='<%# Eval("OrgCode") + ";" + Eval("Material_id") + ";" + Eval("In_date")%>' />
                            <asp:Button ID="btnDelete" CommandName="GoDelete" CommandArgument='<%# Eval("OrgCode") + ";" + Eval("Material_id") + ";" + Eval("In_date") %>' 
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

