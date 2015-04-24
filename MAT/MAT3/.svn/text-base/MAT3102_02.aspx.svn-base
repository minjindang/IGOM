<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT3102_02.aspx.vb" Inherits="MAT3_MAT3102_02" %>

<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc2" TagName="UcMaterialId" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">物品入庫維護-新增
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMaterialId" runat="server" Enabled="false"></asp:TextBox>
                <uc2:UcMaterialId runat="server" ID="UcMaterialId" OnChecked="UcMaterialId_Checked" />
            </td>
            <td class="htmltable_Left">物料名稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMaterialName" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">單位
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnit" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td class="htmltable_Left">安全庫存數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtSafeCount" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申購數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBuyCnt" runat="server" Width="50px" MaxLength="5" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">申購日期
            </td>
            <td style="width: 326px">
                 <uc2:UcDate ID="ucBuyDate" runat="server" />  
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">目前庫存數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtReserveCnt" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td class="htmltable_Left">入庫數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtInCnt" runat="server" Width="50px" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">入庫日期
            </td>
            <td colspan="3"> 
                 <uc2:UcDate ID="ucInDate" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">單價
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnitPriceAmt" runat="server" Width="100px" MaxLength="6"></asp:TextBox>
            </td>
            <td class="htmltable_Left">廠商
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtCompanyName" runat="server" Width="100px"  MaxLength="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">備註說明
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" Height="76px" Width="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DonBtn" runat="server" Text="確認" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
        <asp:Button ID="btnBack" runat="server" Text="回上頁" PostBackUrl="~/MAT/MAT3/MAT3102_01.aspx" />
    </div>
</asp:Content>

