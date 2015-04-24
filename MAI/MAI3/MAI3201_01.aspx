<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI3201_01.aspx.vb" Inherits="MAI_MAI3_MAI3201_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">水電報修查詢及結案
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修類別(可複選)
                </td>
                <td colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucMtClass_type" Code_sys="019" Code_type="008" ControlType="CheckBoxList"    />
                    <asp:TextBox ID="txtMtItemOther_desc" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSAll" runat="server" Text="全選" />
                    <asp:Button ID="btnCAll" runat="server" Text="全不選" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修日期
                </td>
                <td style="width: 326px">
                    <uc1:UcDate runat="server" ID="ucApplyTimeS" />
                    ~
                    <uc1:UcDate runat="server" ID="ucApplyTimeE" />
                </td>
                <td class="htmltable_Left">報修單位
                </td>
                <td style="width: 326px">
                    <asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修人聯絡分機
                </td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtPhone_nos" runat="server"></asp:TextBox>
                </td>
                <td class="htmltable_Left">報修人
                </td>
                <td style="width: 326px"> 
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">處理情形
                </td>
                <td colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucMtStatus_type" Code_sys="019" Code_type="006" ControlType="CheckBoxList"    />
                </td>
            </tr>  

            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="QryBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
                </td> 
            </tr>
        </table>
          <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        visible="false" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                 CellPadding="1" CellSpacing="1" BorderWidth="0px" PageSize="30"
                Width="100%">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="項次">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate> 
                            <asp:Label ID="gvlbNum" runat="server" Text='<%# (Container.DataItemIndex + 1).ToString()%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="報修單號">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate> 
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/MAI/MAI3/MAI3201_02.aspx?flow_id=" + Eval("Flow_id") + "&MtClass_type=" + Eval("MtClass_type") %>'><%# Eval("Flow_id")%></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="User_name" HeaderText="報修人" />
                    <asp:BoundField DataField="ApplyTime" HeaderText="報修日期" />
                    <asp:BoundField DataField="MtClass_typeName" HeaderText="報修類別" />  
                    <asp:BoundField DataField="Problem_desc" HeaderText="報修描述" />  
                    <asp:BoundField DataField="Maintainer" HeaderText="維修人員及分機" />  
                    <asp:BoundField DataField="MtStatus_type" HeaderText="處理情形" />  
                    <asp:BoundField DataField="CaseClose_type" HeaderText="是否結案" />     
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
                <pagerstyle horizontalalign="Right" />
                <emptydatatemplate>
                        查無資料!!
                </emptydatatemplate>
            </asp:GridView>
            </td>
        </tr>
        <tr>
           <td align="right" class="TdHeightLight" style="width: 100%">
              <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                       PNow="1" PSize="10" Visible="true" />
            </td>
        </tr>
    </table>
    </div>

</asp:Content>

