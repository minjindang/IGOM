<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS2101_01.aspx.vb" Inherits="SYS2101_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/FSC/UcMember.ascx" tagname="UcMember" tagprefix="uc3" %>
   <%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcFormKind.ascx" TagPrefix="uc3" TagName="UcFormKind" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>
<%@ Register Src="~/UControl/SYS/UcAttach.ascx" TagPrefix="uc1" TagName="UcAttach" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc7" TagName="UcAuthorityMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                各類表單查詢</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件
            </td>
        </tr>        
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                日期區間
            </td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcDate1" runat="server" /> &nbsp;~<uc2:UcDate ID="UcDate2" runat="server" />
            </td>
            <td class="htmltable_Left" style="width:100px">
                單位名稱
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">人員姓名</td>
            <td class="htmltable_Right" style="width: 250px">
                <uc6:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
            <td class="htmltable_Left" style="width:100px">
                員工編號
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc7:UcAuthorityMember runat="server" ID="UcAuthorityMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單類型
            </td>
            <td class="htmltable_Right">
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCodeType" runat="server" AutoPostBack="true" DataTextField="code_desc1" DataValueField="code_no"
                             OnSelectedIndexChanged="ddlCodeType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlForm" runat="server" 
                            DataTextField="formName" DataValueField="formId">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:HiddenField ID="hfFormIds" runat="server" />
            </td>
            <td class="htmltable_Left">案件狀態</td>
            <td class="htmltable_Right" colspan="3">
                <asp:DropDownList id="ddlStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" /><input id="cbRest" type="button" value="重填" /></td>
        </tr>
    </table>
    <br />
    <table id="tbQ" runat="server" border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2">
                查詢結果
            </td>
        </tr>    
        <tr>
            <td style="width: 100%;" align="center" colspan="2" class="TdHeightLight">
                
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%"  PageSize="30"
                    CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true" AllowPaging="true">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                                <asp:Label ID="gvlbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gvlbFormId" runat="server" Text='<%# Bind("Form_id") %>' Visible="false" ></asp:Label>
                                <asp:hiddenfield ID="gvhfId" runat="server" Value='<%# Bind("id")%>' ></asp:hiddenfield>
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
                        <asp:TemplateField HeaderText="簽核進度">
                            <ItemTemplate>                     
                                <asp:Label ID="gvlbNextName" Text='<%# Bind("Next_name")%>' runat="server"></asp:Label>                                
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="簽核時間">
                            <ItemTemplate>                     
                                <asp:Label ID="gvlbAgreeTime" Text='<%# Bind("Agree_time")%>' runat="server"></asp:Label>                                
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="110px" />
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
            <td align="right" class="TdHeightLight" colspan="2">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gv" Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>    
    </table>    
</asp:Content>
