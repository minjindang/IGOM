<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3108_05.aspx.vb" Inherits="SYS3108_05" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc3" TagName="UcDDLForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td colspan="4" class="htmltable_Title">
                    簽核流程查詢</td>
            </tr>
            <tr>
                <td colspan="4" class="htmltable_Title2">
                    查詢條件</td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width:100px" >
                    單位名稱</td>
                <td class="htmltable_Right" colspan="3">                    
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width:100px">
                    職稱</td>
                <td class="htmltable_Right">                    
                    <asp:DropDownList ID="ddlTitleNo" runat="server" DataTextField="Title_name"
                        DataValueField="Title_no"></asp:DropDownList>
                </td>
                <td class="htmltable_Left" style="width:100px">
                    人員</td>
                <td class="htmltable_Right">                    
                    <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
                </td>
            </tr>  
            <tr>
                <td class="htmltable_Left" style="width:100px">
                    申請項目</td>
                <td class="htmltable_Right" colspan="3">
                    <uc3:UcDDLForm runat="server" ID="UcDDLForm" />
                </td>
            </tr>
            <tr>           
                <td align="center"  class="TdHeightLight" colspan="4">
                    <asp:Button ID = "btnQuery" Text = "查詢" runat = "server" OnClientClick="blockUI();" /><input id="cbRest" type="button" value="重填" /><asp:Button ID="cbSetup" runat="server"  Text="簽核流程設定" UseSubmitBehavior="False" /></td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" runat="server" id="tbQ" visible="false">
            <tr>
                <td colspan="2">
                    <asp:Button ID="cbPreviewPrint" Text="預覽列印" PostBackUrl="" runat="server"  UseSubmitBehavior="False" /></td>
            </tr>     
            <tr>
            <td class="htmltable_Title2">
                表單說明</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvFormList" runat="server" AutoGenerateColumns="False" CssClass="Grid" HeaderStyle-Font-Size="Small"
                        PagerStyle-HorizontalAlign="Right" width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="申請類別">
                                <ItemTemplate>
                                    <asp:Label ID="lblMasterCodeName" runat="server" Text='<%# Bind("form_name")%>' Font-Size="small"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle  width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="申請項目">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetailCodeName" runat="server" Text='<%# Bind("form_desc")%>' Font-Size="small"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Title2" colspan="7">
                    查詢結果
                </td>
            </tr>
            <tr>
             <td class="htmltable_Right" >
                 <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" ShowHeader="false" BorderStyle="none" BorderWidth="0" BorderColor="white"
                    width="100%" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="30" EmptyDataText="查無資料!">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div style="margin-bottom:2px">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_name") %>' Font-Size="Small" Font-Bold="true"></asp:Label>
                                    (<asp:Label ID="Label2" runat="server" Text='<%# Bind("Depart_name") %>' Font-Size="Small" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Title_name") %>' Font-Size="Small" Font-Bold="true"></asp:Label>)
                                </div>
                                <asp:GridView ID="gvi" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                                    CssClass="Grid" width="100%" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="30" EmptyDataText="查無資料!">                
                                    <Columns>
                                        <asp:TemplateField HeaderText="申請類別" ItemStyle-width="120px" HeaderStyle-Font-Size="Small">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_lbformName" runat="server" Text='<%# Bind("form_name")%>' Font-Size="Small" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="簽核流程">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="Small" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate><asp:Label ID="gv_lbOutpostName" runat="server" Text='<%# Bind("outpost_name")%>' Font-Size="Small" /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <AlternatingRowStyle CssClass="AlternatingRow" />
                                    <RowStyle CssClass="Row" />
                                    <EmptyDataRowStyle CssClass="EmptyRow" />
                                </asp:GridView>         
                                      
                                <asp:Label ID="gv_lbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbId_card" runat="server" Text='<%# Bind("Id_card") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbDepart_id" runat="server" Text='<%# Bind("Depart_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbTitle_no" runat="server" Text='<%# Bind("Title_no") %>'  Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbEmployee_type" runat="server" Text='<%# Bind("Employee_type") %>'  Visible="false"></asp:Label>
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                 </asp:GridView>
                </td>
            </tr> 
            <tr>
                <td align="right" class="TdHeightLight" colspan="7">
                    <uc1:Ucpager ID="Ucpager2" runat="server" GridName="gv" Other1="Ucpager1" PNow="1"
                        PSize="30" Visible="true" />
                </td>
            </tr>
        </table>
</asp:Content>