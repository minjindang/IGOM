<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3103_01.aspx.vb" Inherits="FSC3103_01" %>
<%@ Register src="../../UControl/UcMember.ascx" tagname="UcMember" tagprefix="uc1" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                直屬主管設定</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                單位名稱</td>
            <td class="htmltable_Right" style="width: 230px">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                職稱
            </td>
            <td class="htmltable_Right" >
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <contenttemplate>
                <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                主管姓名</td>
            <td class="htmltable_Right" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>                        
            <td class="htmltable_Left" style="width:100px">員工編號</td>
            <td class="htmltable_Right">
                 <asp:TextBox ID="tbIdcard" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                &nbsp;<asp:Button ID="btnFind" runat="server" CausesValidation="False" Text="查詢" /></td>
        </tr>
    </table>
    <br />
   
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果</td>
        </tr>
        <tr>
            <td style="width: 100%;" class="htmltable_Right" colspan="2">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料">                       
                    <Columns>
                        <asp:TemplateField HeaderText="人員姓名">
                            <ItemTemplate>
                                <asp:Label ID="lbID_card" runat="server"  Text='<%# Eval("ID_card") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lb_Username" runat="server" Text='<%# Eval("User_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TitleName" HeaderText="職稱" />
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" CommandArgument='<%# Eval("Orgcode")+"|"+ Eval("Depart_ID")+"|"+ Eval("ID_card") %>'
                                    CommandName="Upd" Text="設定新主管" />   
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
            <tr>
                <td align="right" class="TdHeightLight">
                    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                        PNow="1" PSize="30" Visible="true" />
                </td>
            </tr>                 
    </table>
</asp:Content>
