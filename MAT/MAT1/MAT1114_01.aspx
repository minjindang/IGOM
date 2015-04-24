﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT1114_01.aspx.vb" Inherits="MAT_MAT1_MAT1114_01" %>


<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">盤點調整
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">物料編號
                </td>
                <td>
                    <asp:TextBox ID="txtMaterial_id" runat="server"></asp:TextBox>

                </td>
                <td class="htmltable_Left">請購日期(起~迄)
                </td>
                <td>
                     
                    <uc2:UcDate ID="ucInv_date" runat="server" />
                     
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="AddBtn" runat="server" Text="新增" />
            <asp:Button ID="QryBtn" runat="server" Text="查詢" />
            <asp:Button ID="ResetBtn" runat="server" Text="重置" />
        </div>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"  
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%"> 
                <Columns>
                    <asp:BoundField DataField="Material_id" HeaderText="物料編號" /> 
                    <asp:BoundField DataField="Material_name" HeaderText="物料名稱" /> 
                    <asp:BoundField DataField="Unit" HeaderText="單位" /> 
                    <asp:BoundField DataField="InvBefore_cnt" HeaderText="盤點前數量" /> 
                    <asp:BoundField DataField="Inv_date" HeaderText="盤點日期" /> 
                    <asp:BoundField DataField="InvAfter_cnt" HeaderText="盤點數量" />     
                    <asp:BoundField DataField="Diff_desc" HeaderText="差異解釋說明" />     
                    <asp:BoundField DataField="Mod_date" HeaderText="異動日期" />       
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Button ID="btnMaintain" runat="server" Text="維護" CommandName="Maintain" CommandArgument='<%# Eval("OrgCode") + ";" + Eval("Inventory_id").ToString() + ";" + Eval("Material_id")%>' />
                            <asp:Button ID="btnDelete" CommandName="GoDelete" CommandArgument='<%# Eval("OrgCode") + ";" + Eval("Inventory_id").ToString() + ";" + Eval("Material_id")%>' 
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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
