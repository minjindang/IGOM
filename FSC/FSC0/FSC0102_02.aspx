﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0102_02.aspx.vb" Inherits="FSC0102_02" %>

<%@ Register Src="~/UControl/SYS/UcAttach.ascx" TagPrefix="uc1" TagName="UcAttach" %>
<%@ Register Src="~/UControl/UcReason.ascx" TagPrefix="uc2" TagName="UcReason" %>
<%@ Register Src="~/UControl/SYS/UcFormKind.ascx" TagPrefix="uc3" TagName="UcFormKind" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc5" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc6" TagName="UcDDLForm" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc7" TagName="UcDate" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc8" TagName="UcCustomNext" %>
<%@ Register Src="~/UControl/SYS/UcAttachUploadButton.ascx" TagPrefix="uc1" TagName="UcAttachUploadButton" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">申請案件查詢</td>
        </tr>
        <tr>
            <td class="TdHeightLight" colspan="4">
                <div style="float: right">
                    <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
                </div>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" OnSorting="gv_Sorting"
                    CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true">
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
                              <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbFlowId" runat="server"  Text='<%# Bind("Flow_id") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位" SortExpression="depart_id" >
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbDepartName" runat="server" Text='<%# Bind("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="送件人" SortExpression="Apply_idcard">
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbApply_name" runat="server" Text='<%# Bind("Apply_name") %>'></asp:Label>
                                <asp:HiddenField ID="gvhfApply_id" Value='<%# Bind("Apply_idcard") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="填單日期" SortExpression="write_time" >
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
                        <asp:TemplateField HeaderText="表單名稱" SortExpression="Form_id" >
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
                        <asp:TemplateField HeaderText="簽核進度" SortExpression="Next_idcard" >
                            <ItemTemplate>                     
                                <asp:Label ID="gvlbNextName" Text='<%# Bind("Next_name")%>' runat="server"></asp:Label>                                
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
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>                     
                                <asp:Button ID="gvcbUpdate" runat="server" Text="修改" OnClick="gvcbUpdate_Click" />
                                <uc1:UcAttachUploadButton runat="server" ID="UcAttachUploadButton" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id")%>' OnFileUploaded="gvUcAttachUploadButton_FileUploaded" />
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                            <HeaderStyle Width="80px" />
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