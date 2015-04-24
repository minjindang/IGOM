<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3108_07.aspx.vb" Inherits="SYS3108_07" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc3" TagName="UcDDLForm" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc1" TagName="UcCustomNext" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="6">
                簽核人員異動</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                簽核單位</td>
            <td class="htmltable_Right">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                簽核人員</td >
            <td class="htmltable_Right" style="width:250px">
                <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單類型</td>
            <td class="htmltable_Right">
                <uc3:UcDDLForm runat="server" ID="UcDDLForm" />
            </td>
        </tr>
        <tr align="center">
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="btnConfirm" runat="server" 
                    Text="查詢" OnClientClick="blockUI()" /><input id="cbRest" type="button" value="重填" />
            </td>
        </tr>
    </table>
    <br />
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td>                
                <uc1:UcCustomNext runat="server" ID="UcCustomNext" Text="新簽核人員" OnClick="UcCustomNext_Click" />
            </td>
        </tr>
        <tr>
            <td　align="center" colspan="6" class="TdHeightLight">
                
                <asp:GridView ID="gv" runat="server" width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="Grid"  BorderWidth="0px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="small" PageSize="30">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle Width="30px" />
                            <HeaderStyle Width="30px" />
                            <ItemTemplate>
                                <asp:Label ID="gv_lbno" runat="server" Text="" />
                                <asp:HiddenField ID="gv_hfFlowOutpostId" runat="server" Value='<%# Bind("Flow_outpost_id")%>' />
                                <asp:HiddenField ID="gv_hfFormId" runat="server" Value='<%# Bind("Form_id")%>' />
                                <asp:HiddenField ID="gv_hfMasterId" runat="server" Value='<%# Bind("id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="單位名稱" DataField="Depart_name" >
                            <ItemStyle Width="70px" Font-Size="small" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="適用職稱/<br />人員">
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                            <ItemTemplate>
                                <asp:Label ID="gv_lbTitleno" runat="server" Text='<%# Bind("Target_name")%>' Font-Size="small" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單類型">
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                            <ItemTemplate>
                                <asp:Label ID="gv_lbFormName" runat="server" Text='<%# Bind("Form_name") %>' Font-Size="small" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="簽核流程">
                            <ItemTemplate><asp:Label ID="gv_lbOutpostId" runat="server" Text='<%# Bind("Outpost_id") %>' Font-Size="small" /></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        查無資料
                    </EmptyDataTemplate>
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