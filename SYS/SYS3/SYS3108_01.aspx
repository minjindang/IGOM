<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3108_01.aspx.vb" Inherits="SYS3108_01" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc3" TagName="UcDDLForm" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="6">
                簽核流程設定</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="6">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                適用單位</td>
            <td class="htmltable_Right" colspan="5">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                適用職稱 </td>
            <td class="htmltable_Right" style="width:250px">
                <asp:DropDownList ID="ddlTitleName" runat="server"  
                    DataTextField="Title_name" DataValueField="Title_no">
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" style="width:100px">
                適用人員</td >
            <td class="htmltable_Right" style="width:250px">
                <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
            <td class="htmltable_Left" style="width:100px">
                適用種類</td >
            <td class="htmltable_Right" style="width:250px">
                <asp:DropDownList ID="ddlEmpType" runat="server"  
                    DataTextField="code_desc1" DataValueField="code_no">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單類型</td>
            <td class="htmltable_Right" colspan="5">
                <uc3:UcDDLForm runat="server" ID="UcDDLForm" />
            </td>
        </tr>
        <tr align="center">
            <td class="htmltable_Bottom" colspan="6">
                <asp:Button ID="btnConfirm" runat="server" 
                    Text="查詢" OnClientClick="blockUI()" /><input id="cbRest" type="button" value="重填" /><asp:Button ID="cbToAdd" runat="server" 
                    Text="新增流程" UseSubmitBehavior="False" /><asp:Button ID="cbQuery" runat="server"  Text="簽核流程查詢" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
    <br />
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td　align="center" colspan="6" class="TdHeightLight">
                
                <asp:GridView ID="gv" runat="server" width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="Grid"  BorderWidth="0px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="small" PageSize="30">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                                <ItemStyle Width="30px" />
                                <HeaderStyle Width="30px" />
                            <ItemTemplate><asp:Label ID="gv_lbno" runat="server" Text="" /></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單類型">
                                <ItemStyle Width="70px" />
                                <HeaderStyle Width="70px" />
                            <ItemTemplate>
                                <asp:Label ID="gv_lbLeaveGroup" runat="server" Text='<%# Bind("Form_name") %>' Font-Size="small" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="簽核流程">
                            <ItemTemplate><asp:Label ID="gv_lbOutpostId" runat="server" Text='<%# Bind("Outpost_id") %>' Font-Size="small" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="適用對像">
                                <ItemStyle Width="220px" />
                                <HeaderStyle Width="220px" />
                            <ItemTemplate>
                                <asp:Label ID="gv_lbTitleno" runat="server" Text='<%# Bind("Target_name")%>' Font-Size="small" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="流程維護" >
                            <ItemTemplate>
                                <asp:Label ID="gv_lbfopID" runat="server" Text='<%# Bind("Flow_Outpost_id") %>' Font-Size="small" Visible="false"/>
                                <asp:Button ID="gv_cbStep1" runat="server" Text="修改" OnClick="gv_cbStep1_Click" Font-Size="Small" />
                                <asp:Button ID="gv_cbDelete" runat="server" Text="刪除" OnClick="gv_cbDelete_Click" OnClientClick="javascript:if(!confirm('是否確定刪除流程？')) return false;" Font-Size="Small" /><br>
                                <asp:Button ID="gv_cbStep2" runat="server" Text="修改表單類型" OnClick="gv_cbStep2_Click" Width="100px" Font-Size="Small" /><br />
                                <asp:Button ID="gv_cbStep3" runat="server" Text="修改適用職稱" OnClick="gv_cbStep3_Click" Width="100px" Font-Size="Small" /><br>
                                <asp:Button ID="gv_cbCopy" runat="server" Text="複製流程" OnClick="gv_cbCopy_Click" OnClientClick="javascript:if(!confirm('是否確定複製流程？')) return false;" Font-Size="Small" />
                            </ItemTemplate>
                            <ItemStyle width="105px" Font-Size="small" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle HorizontalAlign="Right" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <RowStyle CssClass="Row" />
                </asp:GridView>
                                    
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight">
                <uc1:Ucpager ID="Ucpager2" runat="server" EnableViewState="true" GridName="gv" Other1="Ucpager1" PNow="1" PSize="30" />
            </td>
        </tr>
    </table>
</asp:Content>