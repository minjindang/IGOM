<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS2102_01.aspx.vb" Inherits="SYS2102_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/FSC/UcMember.ascx" tagname="UcMember" tagprefix="uc3" %>
<%@ Register Src="~/UControl/SYS/UcFormKind.ascx" TagPrefix="uc3" TagName="UcFormKind" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>
<%@ Register Src="~/UControl/SYS/UcAttach.ascx" TagPrefix="uc1" TagName="UcAttach" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" runat="server">
        <tr>
            <td class="htmltable_Title" colspan="4">
                各類表單使用件數統計表</td>
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
        
        <%--<tr>
            <td class="htmltable_Left" style="width:100px">
                人員姓名
            </td>
            <td class="htmltable_Right" style="width:250px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUser_name" runat="server" DataTextField="full_name" DataValueField="Id_card">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left" style="width:100px">
                員工編號
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc3:UcMember ID="UcPersonal_id" runat="server" />
            </td>
        </tr>--%>
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
                
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" PageSize="30" AllowPaging="true"
                    CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                                <asp:Label ID="gvlbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gvlbFormId" runat="server" Text='<%# Bind("Form_id") %>' Visible="false" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemStyle Width="50px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbDepartName" runat="server" Text='<%# Bind("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單類別">
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbFormKind" runat="server" Text='<%# Bind("FormKind")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單名稱">
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>                                
                                <asp:Label ID="gvlbFormType" runat="server" Text='<%# Bind("FormType")%>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="使用件數" >
                            <ItemStyle Width="160px" HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <asp:Label ID="gvlbCount" Text='<%# Bind("Counts")%>' runat="server"></asp:Label>
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
            <td align="right" class="TdHeightLight" colspan="2">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gv"  PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>    
    </table>    
</asp:Content>
