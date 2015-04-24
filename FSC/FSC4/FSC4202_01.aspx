<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC4202_01.aspx.vb" Inherits="FSC4202_01"  %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="../../UControl/UcMember.ascx" tagname="UcMember" tagprefix="uc5" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="dialog" style="text-align:center; background-color:white;">
    <span id="message"></span>    
</div>

       <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="4">
                    刷卡轉出勤</td>
            </tr>
            <tr>
                <td class="htmltable_Title2" colspan="4">
                條件設定
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    轉檔日期</td>
                <td class="htmltable_Right" colspan="3">
                    <uc2:UcDate ID="tbStartDate" runat="server" />
                    &nbsp;~
                    <uc2:UcDate ID="tbEndDate" runat="server" /><br />
                <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    單位名稱</td>
                <td class="htmltable_Right" colspan="3">
                    <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    人員姓名</td>
                <td class="htmltable_Right">
                    <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
                </td>      
                <td class="htmltable_Left" style="width:100px">
                    員工編號</td>
                <td class="TdHeightLight">
                    <uc5:UcMember ID="UcMember" runat="server" />
                </td>   
            </tr>
            <tr>
                <td align="center" class="TdHeightLight" colspan="4">
                    <asp:Button ID="btTransfer" runat="server" Text="開始執行" OnClientClick="blockUI()" /><br />
                    <asp:Label ID="lbTip1" runat="server" Visible="false" ForeColor="Red"  Text="注意事項：系統定時於每日上午11時、下午14時，自動進行刷卡轉出勤。毋需手動執行此作業。"></asp:Label><br />
                    </td>
            </tr>
        </table>  
        <br />   
       <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title2" colspan="4">
                查詢條件
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    查詢報表日期</td>
                <td class="htmltable_Right">
                    <uc2:UcDate ID="tbQryDate" runat="server" />
                </td>            
            </tr>
            <tr>
                <td align="center" class="TdHeightLight" colspan="4">
                    <asp:Button ID="btQuery" runat="server" Text="查詢" /></td>
            </tr>
        </table>
        <br />
        <table id="showTable" width="100%" runat="server" visible="false">
            <tr>
                <td>
                    <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                        Borderwidth="0px" CssClass="Grid" FooterStyle-CssClass="Foot" PagerStyle-HorizontalAlign="Right"
                        ShowFooter="True" width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="檔案名稱">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("URL") %>' Target="_blank"
                                        Text='<%# Bind("NAME") %>'></asp:HyperLink>
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
                        <FooterStyle CssClass="Foot" />
                    </asp:GridView>
                </td>
            </tr>
        </table>    
</asp:Content>

