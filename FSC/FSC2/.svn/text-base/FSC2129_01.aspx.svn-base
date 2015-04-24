<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2129_01.aspx.vb" Inherits="FSC2129_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td align="center" class="htmltable_Title" colspan="2">
                員工基本資料及差假統計查詢
            </td>
        </tr>    
        <tr>
            <td align="center" style="width: 100%" colspan="10">

                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td align="center" class="htmltable_Title3" colspan="3">員工編號</td>
                        <td align="center" colspan="3">
                            <asp:Label ID="lbId_card" runat="server"></asp:Label></td>
                        <td align="center" class="htmltable_Title3" colspan="2">員工姓名</td>
                        <td align="center" colspan="3">
                            <asp:Label ID="lbUser_name" runat="server"></asp:Label></td>
                        <td align="center" class="htmltable_Title3">單位</td>
                        <td align="center" colspan="4">
                            <asp:Label ID="lbDepart_name" runat="server"></asp:Label></td>
                        <td align="center" colspan="4">
                            <asp:Label ID="lbEmployee_type" runat="server"></asp:Label></td>

                    </tr>
                    <tr>
                        <td align="center" colspan="20"><%=Now.Year - 1911%>年度可請假天數</td>
                    </tr>
                    <tr>
                        <td align="center" class="htmltable_Title3" colspan="3"><%=Now.Year - 1911%>年休假天數</td>
                        <td align="center" colspan="2">
                            <asp:Label ID="lbPEHDAY" runat="server"></asp:Label></td>
                        <td align="center" class="htmltable_Title3" colspan="2">保留<%=Now.Year - 1912%>年<br />未休假天數</td>
                        <td align="center">
                            <asp:Label ID="lbPERDAY1" runat="server"></asp:Label></td>
                        <td align="center" class="htmltable_Title3" colspan="2">保留<%=Now.Year - 1913%>年<br />未休假天數</td>
                        <td align="center" colspan="2">
                            <asp:Label ID="lbPERDAY2" runat="server"></asp:Label></td>
                        <td align="center" class="htmltable_Title3" colspan="2">事假天數</td>
                        <td align="center">
                            <asp:Label ID="lbPEHDAY2" runat="server"></asp:Label></td>
                        <td align="center" class="htmltable_Title3" colspan="2">病假天數</td>                        
                        <td align="center" colspan="3">
                            <asp:Label ID="lbPEHDAY3" runat="server"></asp:Label></td>

                    </tr>
                    <tr>
                        <td align="center" colspan="20"><%=Now.Year - 1911%>年度已請假天數</td>
                    </tr>
                    <tr>
                        <td align="center" class="htmltable_Title3" rowspan="2">公差</td>
                        <td align="center" class="htmltable_Title3" colspan="2">事假</td>
                        <td align="center" class="htmltable_Title3" colspan="2">病假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">婚假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">產前假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">分娩假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">流產假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">陪產假</td>
                        <td align="center" class="htmltable_Title3" colspan="2">休假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">喪假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">加班<br/>補休</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">公差<br/>補休</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">值班<br/>補休</td>                        
                        <td align="center" class="htmltable_Title3" rowspan="2">公假</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">災防</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">器官捐贈</td>
                        <td align="center" class="htmltable_Title3" rowspan="2">其它</td>
                    </tr>
                    <tr>
                        <td align="center" class="htmltable_Title3">一般</td>
                        <td align="center" class="htmltable_Title3">家庭<br/>照顧假</td>
                        <td align="center" class="htmltable_Title3">一般</td>
                        <td align="center" class="htmltable_Title3">生理假</td>
                        <td align="center" class="htmltable_Title3">今年</td>
                        <td align="center" class="htmltable_Title3">保留</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lb05" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb01" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb25" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb02" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb24" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb08" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb21" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb09" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb13" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb22" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb03_1" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb03_0" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb10" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb04" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb20" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb32" runat="server"></asp:Label></td>                        
                        <td align="center">
                            <asp:Label ID="lb06" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb18" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb23" runat="server"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lb" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
