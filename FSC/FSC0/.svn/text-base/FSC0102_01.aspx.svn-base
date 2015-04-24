<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0102_01.aspx.vb" Inherits="FSC0102_01" %>

<%@ Register Src="~/UControl/SYS/UcAttach.ascx" TagPrefix="uc1" TagName="UcAttach" %>
<%@ Register Src="~/UControl/UcReason.ascx" TagPrefix="uc2" TagName="UcReason" %>
<%@ Register Src="~/UControl/SYS/UcFormKind.ascx" TagPrefix="uc3" TagName="UcFormKind" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc5" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc6" TagName="UcDDLForm" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc7" TagName="UcDate" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc8" TagName="UcCustomNext" %>
<%@ Register Src="~/UControl/SYS/UcAttachUploadButton.ascx" TagPrefix="uc1" TagName="UcAttachUploadButton" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UControl/SYS/UcCancelFlow.ascx" TagPrefix="uc1" TagName="UcCancelFlow" %>
<%@ Register Src="~/UControl/SYS/UcFormReason.ascx" TagPrefix="uc1" TagName="UcFormReason" %>
<%@ Register Src="~/UControl/SYS/UcNextName.ascx" TagPrefix="uc1" TagName="UcNextName" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >

    <table width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">申請案件查詢</td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請期間(起~迄)</td>
            <td class="htmltable_Right">                
                <uc7:UcDate runat="server" ID="UcDateS" /> ~
                <uc7:UcDate runat="server" ID="UcDateE" />
            </td>
            <td class="htmltable_Left">申請類別</td>
            <td class="htmltable_Right">
                <uc6:UcDDLForm runat="server" ID="UcDDLForm" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">案件狀態</td>
            <td class="htmltable_Right" colspan="3">
                <%--<asp:DropDownList id="ddlStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no">
                </asp:DropDownList>--%>
                <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="5" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">                
                <asp:button runat="server" id="cbQuery" Text="查詢" OnClick="cbQuery_Click"></asp:button>              
                <asp:Button ID="cbBack" runat="server" Text="返回收件匣" OnClick="cbBack_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" class="tableStyle99">
        <tr>
            <td align="center" colspan="4">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="true" PageSize="30" OnSorting="gv_Sorting"
                    CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true" OnRowDataBound="gv_RowDataBound1"  >
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                                <asp:HiddenField ID="gvhfOrgcode" runat="server" value='<%# Bind("Orgcode") %>' ></asp:HiddenField>
                                <asp:HiddenField ID="gvhfFormId" runat="server" value='<%# Bind("Form_id") %>' ></asp:HiddenField>
                                <asp:HiddenField ID="gvhfCaseStatus" runat="server" value='<%# Bind("case_status") %>' ></asp:HiddenField>
                                <asp:HiddenField ID="gvhfLastPass" runat="server" value='<%# Bind("Last_pass") %>' ></asp:HiddenField>
                                <asp:HiddenField ID="gvhfMergeFlag" runat="server" value='<%# Bind("Merge_flag") %>' ></asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單編號" SortExpression="Flow_id" >
                              <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbFlowId" runat="server"  Text='<%# Bind("Flow_id") %>' ></asp:Label>
                                <asp:Label ID="gvlbMergeFlag" runat="server"  Text='<%# IIf(Eval("Merge_flag").ToString() = "1", "*", "")%>' ForeColor="Red" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位" SortExpression="depart_id" >
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbDepartName" runat="server" Text='<%# Bind("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請人" SortExpression="Apply_idcard" >
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbApply_name" runat="server" Text='<%# Bind("Apply_name") %>'></asp:Label>
                                <asp:HiddenField ID="gvhfApply_id" Value='<%# Bind("Apply_idcard") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請日期" SortExpression="write_time" >
                            <ItemStyle Width="35px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="35px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbwrite_time" runat="server" Text='<%# Bind("write_time","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="表單類別">
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <uc3:UcFormKind runat="server" ID="UcFormKind" FormId='<%# Bind("Form_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="申請案件別" SortExpression="Form_id" >
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>                                
                                <uc4:UcFormType runat="server" ID="UcFormType" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請說明" >
                            <ItemStyle Width="350px" HorizontalAlign="left"/>
                            <ItemTemplate>
                                <uc1:UcFormReason runat="server" ID="UcFormReason" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="附件">
                            <ItemStyle Width="30px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="30px" />
                            <ItemTemplate>
                                <uc1:UcAttach runat="server" ID="UcAttach" Flow_id='<%# Bind("Flow_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="簽核進度" SortExpression="next_idcard" >
                            <ItemTemplate>
                                <uc1:UcNextName runat="server" ID="UcNextName" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>' NextDepartName='<%# Bind("Next_Departname")%>' LastPass='<%# Bind("Last_pass")%>' CaseStatus='<%# Bind("Case_status")%>' NextName='<%# Bind("Next_name")%>'/>
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="簽核時間" SortExpression="Agree_time" >
                            <ItemTemplate>                     
                                <asp:Label ID="gvlbAgreeTime" Text='<%# Bind("Agree_time")%>' runat="server"></asp:Label>                                
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="狀態" SortExpression="case_status" >
                            <ItemTemplate>                     
                                <asp:Label ID="gvlbStatus" runat="server"></asp:Label>                                
                            </ItemTemplate>
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>                     
                                <asp:Button ID="gvcbUpdate" runat="server" Text="修改" OnClick="gvcbUpdate_Click" Visible="false" />
                                <asp:Button ID="gvcbResent" runat="server" text="重送" OnClick="gvcbResent_Click" OnClientClick="if(!confirm('是否確定重送？'))return false; blockUI()" Visible="false"/>
                                <asp:Button ID="gvcbDelete" runat="server" text="刪除" OnClick="gvcbDelete_Click" OnClientClick="if(!confirm('是否確定刪除？'))return false; blockUI()" Visible="false"/>
                                <uc1:UcCancelFlow runat="server" id="UcCancelFlow" OnClick="gvcbCancel_Click" Visible="false" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id")%>'  />
                                <uc1:UcAttachUploadButton runat="server" ID="gvUcAttachUploadButton" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id")%>' Visible="false" OnFileUploaded="gvUcAttachUploadButton_FileUploaded" />
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center" />
                            <HeaderStyle Width="110px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:Ucpager runat="server" ID="UcPager" GridName="gv" PNow="1" PSize="30" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
