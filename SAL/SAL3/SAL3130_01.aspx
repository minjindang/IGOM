<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3130_01.aspx.cs" Inherits="SAL3130_01" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                薪資異動通知作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位
            </td>
            <td class="htmltable_Right">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>      
        <tr>
            <td class="htmltable_Left">
                員工編號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtId_card" runat="server" MaxLength="6" ></asp:TextBox>
            </td>      
        </tr>
        <tr>
            <td class="htmltable_Left">
                發送狀態
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:DropDownList ID="ddlSend_status" runat="server">
                    <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                    <asp:ListItem Text="未發送" Value="0"></asp:ListItem>
                    <asp:ListItem Text="已發送" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>          
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2" style="border-top: none;">
                <asp:Button ID="cbSearch" runat="server" Text="查詢" OnClick="cbSearch_Click"/>
                <asp:Button ID="cbInsert" runat="server" Text="新增" OnClick="cbInsert_Click"/>
                <asp:Button ID="cbSendList" runat="server" Text="設定發送名單" OnClick="cbSendList_Click" />
            </td>
        </tr>      
    </table>

    <table width="100%">
    <tr><td>
      <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" PageSize="30" PagerStyle-HorizontalAlign="right"
                          Width="100%" CssClass="Grid" AllowPaging="true" OnPageIndexChanging="gv_PageIndexChanging" >
           <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <Columns>
                <asp:TemplateField HeaderText="單位">
                    <ItemTemplate>
                        <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="人員編號">
                    <ItemTemplate>
                        <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card") %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name") %>' />  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="官等">
                    <ItemTemplate>
                         <asp:Label ID="lbL3_name" runat="server" Text='<%# Eval("L3_name") %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>                              
                <asp:TemplateField HeaderText="職等">
                    <ItemTemplate>
                         <asp:Label ID="lbL1_name" runat="server" Text='<%# Eval("L1_name") %>'/>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="俸階">
                    <ItemTemplate>                  
                         <asp:Label ID="lbL2_name" runat="server" Text='<%# Eval("L2_name") %>'/>        
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="功能">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="檢視" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnSend" runat="server" Text="發送" OnClick="btnSend_Click" />
                        <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>      
            </Columns>
        </asp:GridView>    
    </td></tr>
    <tr><td>
        <uc1:Ucpager runat="server" ID="UcPager" GridName="gv" PNow="1" PSize="30" />
    </td></tr>
    </table>

</asp:Content>
 