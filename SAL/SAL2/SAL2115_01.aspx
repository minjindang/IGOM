<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL2115_01.aspx.cs" Inherits="SAL_SAL2_SAL2115" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">年度所得清冊
                    </td>
                </tr>
                <tr>
                     <td class="htmltable_Left">報表年月</td> 
                     <td class="htmltable_Right">民國
                     <asp:DropDownList ID="DropDownList_Year" runat="server" AutoPostBack="True">
                         </asp:DropDownList>年
                         <asp:DropDownList ID="DropDownList_Month" runat="server" AutoPostBack="True">
                             <asp:ListItem></asp:ListItem>
                             <asp:ListItem Value="01">01</asp:ListItem>
                             <asp:ListItem Value="02">02</asp:ListItem>
                             <asp:ListItem Value="03">03</asp:ListItem>
                             <asp:ListItem Value="04">04</asp:ListItem>
                             <asp:ListItem Value="05">05</asp:ListItem>
                             <asp:ListItem Value="06">06</asp:ListItem>
                             <asp:ListItem Value="07">07</asp:ListItem>
                             <asp:ListItem Value="08">08</asp:ListItem>
                             <asp:ListItem Value="09">09</asp:ListItem>
                             <asp:ListItem Value="10">10</asp:ListItem>
                             <asp:ListItem Value="11">11</asp:ListItem>
                             <asp:ListItem Value="12">12</asp:ListItem>
                         </asp:DropDownList>月
                     </td>
                    <td class="htmltable_Left">分頁方式
                    </td>
                    <td class="htmltable_Right">
                        <asp:DropDownList ID="ddlsort" runat="server">
                            <asp:ListItem Text="連續印" Value="0"></asp:ListItem>                          
                            <asp:ListItem Text="一人一頁" Value="1"></asp:ListItem>                           
                        </asp:DropDownList>
                    </td> 
                </tr>
                <tr>
                <td class="htmltable_Left">單位別</td>
                <td class="htmltable_Right">
                       <uc2:UcSelectOrg ID="ddltype" runat="server" ShowMulti="True" />
                </td>
                <td class="htmltable_Left">員工姓名</td>
                <td class="htmltable_Right"> <asp:TextBox ID="txtName" runat="server"></asp:TextBox> </td>
                </tr>
                 <tr>
                <td class="htmltable_Left">人員類別</td>
                <td class="htmltable_Right">    <uc1:ucSaCode ID="ucSaCode" runat="server" 
                        ControlType="2" Code_Kind="P" 
                                  Code_sys="002" Code_type="017" Mode="query"/>
                  </td>
                <td class="htmltable_Left">員工編號</td>
                <td class="htmltable_Right"><asp:TextBox ID="txtNum" runat="server"></asp:TextBox></td>
                </tr>  
             <tr>
            <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right" colspan="3" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="ddl_Budget_code" runat="server" Code_Kind="P" Code_sys="002" Code_type="018"
                            ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            </tr>             
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" >
                        <asp:Button ID="Button_report" runat="server" Text="列印" 
                            onclick="Button_report_Click" />
                              <asp:Button ID="reset" runat="server" Text="重置" 
                            onclick="Button_reset_Click" />
                           
                    </td>
                </tr>               
            </table>
</asp:Content>

