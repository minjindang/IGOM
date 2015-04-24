<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3115_01.aspx.vb" Inherits="SYS3115_01" %>

<%@ Register Src="~/UControl/SYS/UcAttach.ascx" TagPrefix="uc1" TagName="UcAttach" %>
<%@ Register Src="~/UControl/UcReason.ascx" TagPrefix="uc2" TagName="UcReason" %>
<%@ Register Src="~/UControl/SYS/UcFormKind.ascx" TagPrefix="uc3" TagName="UcFormKind" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc5" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc6" TagName="UcDDLForm" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc7" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc1" TagName="UcCustomNext" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="6">
                表單移轉</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                簽核單位</td>
            <td class="htmltable_Right">
                <uc5:UcDDLDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                簽核人員</td >
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單類型</td>
            <td class="htmltable_Right">
                <uc6:UcDDLForm runat="server" ID="UcDDLForm" />
            </td>
        </tr>
        <tr align="center">
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="btnConfirm" runat="server" 
                    Text="查詢" OnClientClick="blockUI()" OnClick="btnConfirm_Click" /><input id="cbRest" type="button" value="重填" />
            </td>
        </tr>
    </table>
    
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td>                
                <uc1:UcCustomNext runat="server" ID="UcCustomNext" Text="移轉人員" OnClick="UcCustomNext_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" 
                    CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true" EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                                <asp:Label ID="gvlbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gvlbFormId" runat="server" Text='<%# Bind("Form_id") %>' Visible="false" ></asp:Label>
                                <asp:hiddenfield ID="gvhfGroupId" runat="server" Value='<%# Bind("Group_id") %>' ></asp:hiddenfield>
                                <asp:hiddenfield ID="gvhfId" runat="server" Value='<%# Bind("next_id")%>' ></asp:hiddenfield>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單編號">
                              <ItemStyle Width="90px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="90px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbFlowId" runat="server"  Text='<%# Bind("Flow_id") %>' ></asp:Label>
                                <asp:Label ID="gvlbMergeFlag" runat="server"  Text='<%# IIf(Eval("Merge_flag").ToString() = "1", "*", "")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemStyle Width="50px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbDepartName" runat="server" Text='<%# Bind("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="送件人">
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbApply_name" runat="server" Text='<%# Bind("Apply_name") %>'></asp:Label>
                                <asp:HiddenField ID="gvhfApply_id" Value='<%# Bind("Apply_idcard") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="填單日期">
                            <ItemStyle Width="35px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="35px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbwrite_time" runat="server" Text='<%# Bind("write_time","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單類別">
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <uc3:UcFormKind runat="server" ID="UcFormKind" FormId='<%# Bind("Form_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單名稱">
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>                                
                                <uc4:UcFormType runat="server" ID="UcFormType" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請說明" >
                            <ItemStyle Width="160px" HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <asp:Label ID="gvlbReason" Text='<%# Bind("Reason")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="附件">
                            <ItemStyle Width="30px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="30px" />
                            <ItemTemplate>
                                <uc1:UcAttach runat="server" ID="UcAttach" Flow_id='<%# Bind("Flow_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        無待批資料
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:Ucpager runat="server" ID="UcPager" GridName="gv" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
    </table>
</asp:Content>
