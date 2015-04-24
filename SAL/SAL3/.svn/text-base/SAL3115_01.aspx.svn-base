<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SAL3115_01.aspx.vb" Inherits="SAL_SAL3_SAL3115_01" %>

<%@ Register Src="~/UControl/SAL/ucGridViewPager.ascx" TagName="ucGridViewPager" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" style="width: 100%">
                轉帳服務查詢
            </td>
        </tr>
        <tr>
        <td class="htmltable_Title2" style="width: 100%" align="center">
        查詢結果
        </td>
        </tr>
        <tr>
            <td>

                <asp:GridView ID="GridView_batengf" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_gv"
                    AllowPaging="True" CssClass="Grid" CellPadding="1"
                    CellSpacing="1" BorderWidth="0px" Width="100%" 
                    OnPageIndexChanging="GridView_batengf_PageIndexChanging" PageSize="30">
                    <Columns>
                        <asp:TemplateField HeaderText="薪資項目">                        
                            <ItemStyle HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:Label ID="Label_org" runat="server" Text='<%# Unit_Name(Eval("Unit_Dep"),Eval("User_Name"),Eval("kind_name")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="薪資年月">                        
                            <ItemStyle  HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:Label ID="Label_ym" runat="server" Text='<%# YM_Name(Eval("TRN_YM")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作業狀態">                        
                            <ItemStyle  HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:Label ID="Label_status" runat="server" Text='<%# Status_Name(Eval("trn_status")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="起始時間">                          
                            <ItemStyle  HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:Label ID="Label_start" runat="server" Text='<%# Time_Name(Eval("TRN_STARTTIME")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="結束時間">                   
                            <ItemStyle  HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:Label ID="Label_stop" runat="server" Text='<%# Time_Name(Eval("TRN_STOPTIME")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="list_tr" />
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager runat="server" ID="UcPager" GridName="GridView_batengf" PNow="1" PSize="30" />
            </td>
        </tr>
    </table>

    <asp:ObjectDataSource ID="ObjectDataSource_gv" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="spExeSQLGetDataTable" TypeName="DB_TableAdapters.DB_TableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox_SQLs1" DefaultValue="select top 1 * from sal_sabase where 1=0" Name="SQLs" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <div id="div_info" runat="server" visible="false">
        ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
        MID=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
        SQLs1=<asp:TextBox ID="TextBox_SQLs1" runat="server" Visible="false"></asp:TextBox><br />
    </div>
</asp:Content>
