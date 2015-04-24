<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS2104_01.aspx.vb" Inherits="SYS2_SYS2104_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="../../UControl/FSC/UcMember.ascx" tagname="UcMember" tagprefix="uc3" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                登入登出記錄查詢</td>
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
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                在職狀態
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlWorkType" runat="server">
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" style="width:100px">
                人員類別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlEmployeeType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                登入狀態
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:DropDownList ID="ddlLoginStatus" runat="server">
                    <asp:ListItem Value="">請選擇</asp:ListItem>
                    <asp:ListItem Value="1">登入</asp:ListItem>
                    <asp:ListItem Value="2">登出</asp:ListItem>
                    <asp:ListItem Value="3">登入失敗-其它</asp:ListItem>
                    <asp:ListItem Value="4">登入失敗-密碼錯誤</asp:ListItem>
                    <asp:ListItem Value="5">登入失敗-帳號停用</asp:ListItem>
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
                <asp:GridView ID="gvList" runat="server" width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" GridLines="None" PageSize="30" CssClass="Grid" Borderwidth="0px"
                    PagerStyle-HorizontalAlign="Right" EmptyDataText="查無資料!" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red">
                    <Columns>
                        <asp:BoundField DataField="NOS" HeaderText="項次"  />
                        <asp:BoundField DataField="Departname01" HeaderText="單位" />
                        <asp:BoundField DataField="Departname02" HeaderText="科別" />
                        <asp:BoundField DataField="CodeName" HeaderText="職稱" />
                        <asp:BoundField DataField="UserName" HeaderText="人員姓名" />
                        <asp:BoundField DataField="IdCard" HeaderText="員工編號" />
                        <asp:BoundField DataField="LoginStatus" HeaderText="登入狀態" />
                        <asp:BoundField DataField="LoginTime" HeaderText="登入時間" />
                    </Columns>                
                    <PagerStyle HorizontalAlign="Right" />                
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />                    
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" colspan="2">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList" Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>    
    </table>    
</asp:Content>
