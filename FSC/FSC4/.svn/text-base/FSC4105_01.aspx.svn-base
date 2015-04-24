<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true"
    CodeFile="FSC4105_01.aspx.vb" Inherits="FSC4105_01" %>
<%@ Register src="../../UControl/FSC/UcAuthorityMember.ascx" tagname="UcMember" tagprefix="uc1" %>
<%@ Register Src="~/UControl/FSC/UcDeputyDialog.ascx" TagPrefix="uc1" TagName="UcDeputyDialog" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>
<%@ Register Src="~/UControl/UcLeaveDate.ascx" TagPrefix="uc1" TagName="UcLeaveDate" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
   <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                個人秘書設定</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                單位名稱</td>
            <td class="htmltable_Right" style="width:230px">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
            <td class="htmltable_Left" style="width:120px">
                人員
            </td>
            <td class="htmltable_Right" style="width:230px">
                <uc1:UcDDLAuthorityMember runat="server" ID="ddlName" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                秘書啟動
            </td>
            <td class="htmltable_Right" style="width:230px">
                <asp:DropDownList ID="ddlactive" runat="server">
                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                    <asp:ListItem Text="未啟動" Value="N"></asp:ListItem>
                    <asp:ListItem Text="已啟動" Value="Y"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" style="width:120px">
                姓名
            </td>
            <td class="htmltable_Right" style="width:230px">
                <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="cbQuery" runat="server" CausesValidation="False" Text="查詢" /></td>
        </tr>
    </table>
    <table width="100%" class="tableStyle99" visible="false" id="tb" runat="server" >
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果</td>
        </tr>    
        <tr>
            <td style="width: 100%;" class="htmltable_Right" colspan="2">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">                       
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Depart_name" HeaderText="單位名稱" />
                        <asp:BoundField DataField="User_name" HeaderText="人員姓名" />
                        <asp:TemplateField HeaderText="員工編號">
                            <ItemTemplate> 
                                <asp:Label ID="lbID_card" runat="server" Text='<%# Bind("ID_card") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="個人秘書" ItemStyle-HorizontalAlign="Left" >
                            <ItemTemplate>
                                <uc1:UcDeputyDialog runat="server" ID="UcDeputyDialog" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="強制代理時間起迄" ItemStyle-HorizontalAlign="Left" >
                            <ItemTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate> 
                                        <uc1:UcLeaveDate runat="server" ID="UcLeaveDate" Start_date='<%# Bind("Deputy_active_sdate")%>' Start_time='<%# Bind("Deputy_active_stime")%>'
                                            End_date='<%# Bind("Deputy_active_edate")%>' End_time='<%# Bind("Deputy_active_etime")%>' />
                                    </ContentTemplate> 
                                </asp:UpdatePanel> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Label ID="lbactive" runat="server" Text='<%# Bind("Deputy_active") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbDeputyActiveIdcard" runat="server" Text='<%# Bind("Deputy_active_idcard") %>' Visible="false"></asp:Label>
                                <asp:Label ID="ibDeputyName" runat="server" Text='<%# Bind("Deputy_active_name") %>' Visible="false"></asp:Label>
                                <asp:Button id="cbactive" runat="server" Text="啟動" OnClick="cbactive_Click" OnClientClick="if(!confirm('確定啟動？')) return false;" />
                                <asp:Button id="cbinactive" runat="server" Text="刪除" OnClick="cbinactive_Click" OnClientClick="if(!confirm('確定刪除？')) return false;" />
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
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
