<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3102_01.aspx.vb" Inherits="FSC3102_01"  %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">                
        <tr>
            <td colspan="4" class="htmltable_Title">
                預設代理人資料維護</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                單位
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                人員姓名
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDDLAuthorityMember runat="server" ID="ddlName" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="htmltable_Bottom">
                <asp:Button ID="btnFind" runat="server" Text="查詢" />
                
                <asp:Button ID="btnNew" runat="server" Text="新增" />
            </td>
        </tr>
    </table>
    <table id="dataList" runat="server" visible="false" border="0" cellpadding="0" cellspacing="0"  width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" class="htmltable_Right" colspan="4">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料">                       
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label ID="lblDepart_name" runat="server" Text='<%# Eval("depart_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="職稱">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle_name" runat="server" Text='<%# Eval("title_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <asp:Label ID="lblUser_name" runat="server" Text='<%# Eval("USER_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="行政代理人" >
                            <ItemTemplate>
                                <asp:Label ID="lblDeputy_det" runat="server" Text='<%# Me.Get_Deputy_list(Eval("Orgcode"), Eval("ID_card"), "1")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="教學代理人">
                            <ItemTemplate>
                                <asp:Label ID="lblTeachDeputy_det" runat="server" Text='<%# me.Get_Deputy_list(Eval("Orgcode"),Eval("ID_card"), "2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="職務代理人" >
                            <ItemTemplate>
                                <asp:Label ID="lblDeputy_detForExpo" runat="server" Text='<%# Me.Get_Deputy_list(Eval("Orgcode"), Eval("ID_card"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("Orgcode") & "," & Eval("ID_card") %>'
                                    CommandName="View" Text="檢視" />
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
            <td align="right" class="TdHeightLight" colspan="4">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>                 
    </table>
</asp:Content>

