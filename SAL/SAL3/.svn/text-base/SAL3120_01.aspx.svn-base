<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL3120_01.aspx.cs" Inherits="SAL_SAL3_SAL3120_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                <tr>
                    <td class="htmltable_Title" colspan="4">
                        排程程式所得稅申報查詢
                    </td>
                </tr>
                </table>

    <asp:GridView ID="GridView_batengf" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                        AllowPaging="True" PageSize="30" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                        Width="100%" EnableModelValidation="True" >
        <Columns>
            <asp:TemplateField HeaderText="執行人員">
                <HeaderStyle CssClass="item_col" />
                <ItemStyle CssClass="col_1" HorizontalAlign="center" />
                <ItemTemplate>
                    <asp:Label ID="Label_org" runat="server" Text='<%# Unit_Name(Eval("Unit_Dep"),Eval("User_Name")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="薪資年月">
                <HeaderStyle CssClass="item_col" />
                <ItemStyle CssClass="col_1" HorizontalAlign="center" />
                <ItemTemplate>
                    <asp:Label ID="Label_ym" runat="server" Text='<%# YM_Name(Eval("Engf_Ym")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="作業狀態">
                <HeaderStyle CssClass="item_col" />
                <ItemStyle CssClass="col_1" HorizontalAlign="center" />
                <ItemTemplate>
                    <asp:Label ID="Label_status" runat="server" Text='<%# Status_Name(Eval("Engf_Status"),Eval("Engf_Msg")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="起始時間">
                <HeaderStyle CssClass="item_col" />
                <ItemStyle CssClass="col_1" HorizontalAlign="center" />
                <ItemTemplate>
                    <asp:Label ID="Label_start" runat="server" Text='<%# Time_Name(Eval("Engf_StartTime")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="結束時間">
                <HeaderStyle CssClass="item_col" />
                <ItemStyle CssClass="col_1" HorizontalAlign="center" />
                <ItemTemplate>
                    <asp:Label ID="Label_stop" runat="server" Text='<%# Time_Name(Eval("Engf_StopTime")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="查詢結果">
                <HeaderStyle CssClass="item_col" />
                <ItemStyle CssClass="col_1" HorizontalAlign="center" />
                <ItemTemplate>
                    <asp:Button ID="Button_qry" runat="server" Text="查詢結果" CssClass="formcss1"
                    Visible='<%# Btn_Vis(Eval("Engf_Status"),Eval("Engf_Orgid")) %>'
                    CommandArgument='<%# "?act=search&date=" + Eval("Engf_Ym")  %>'
                    OnClick="Button_qry_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
    </asp:GridView>
     <uc1:Ucpager ID="Ucpager2" runat="server" GridName="GridView_batengf" PSize="30" />   
    <asp:ObjectDataSource ID="ObjectDataSource_gv" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="spExeSQLGetDataTable" TypeName="DB_TableAdapters.DB_TableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox_SQLs1" DefaultValue="select top 1 * from sabase where 1=0"
                Name="SQLs" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    
    



    
    
    


    <div id="div_info" runat="server" visible="false">
        ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
        MID=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
        SQLs1=<asp:TextBox ID="TextBox_SQLs1" runat="server" Visible="false"></asp:TextBox><br />
    </div>
</asp:Content>

