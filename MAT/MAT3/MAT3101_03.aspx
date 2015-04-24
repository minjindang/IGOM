<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT3101_03.aspx.vb" Inherits="MAT_MAT3_MAT3101_03" %>

<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc2" TagName="ucSaCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hfDetailID" />
    <asp:HiddenField runat="server" ID="hfFormIDc" />
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">雜項領物-編輯
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">領用類別
            </td>
            <td style="width: 326px">雜項領物
            </td>
            <td class="htmltable_Left">雜項領物類別
            </td>
            <td style="width: 326px">
                <uc2:ucSaCode runat="server" ID="ucSaCode" Code_sys="014" Code_type="001" ControlType="DropDownList" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">領物日期
            </td>
            <td style="width: 326px">
                <uc2:UcDate ID="ucApply_date" runat="server" /> 
            </td>
            <td class="htmltable_Left">請購單編號
            </td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlFlowId" runat="server">
                    <asp:ListItem Value="">請選擇</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">請購單位別
            </td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="00">請選擇</asp:ListItem>
                    <asp:ListItem Value="01">單位1</asp:ListItem>
                    <asp:ListItem Value="02">單位2</asp:ListItem>
                    <asp:ListItem Value="03">單位3</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">領物人員
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUser_Id" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料名稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMaterialName" runat="server" MaxLength="100"></asp:TextBox>
            </td>
            <td class="htmltable_Left">領用數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtOutCnt" runat="server" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">單位
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnit" runat="server" MaxLength="4"></asp:TextBox>
            </td>
            <td class="htmltable_Left">總價
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtTotalPriceAmt" runat="server" MaxLength="6" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">廠商
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="60" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">用途及備註
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMemo" runat="server" MaxLength="255" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center" >
        <asp:Button ID="DonBtn" runat="server" Text="確認" />
        <asp:Button ID="RestoreBtn" runat="server" Text="放棄修改" />
        <asp:Button ID="BackBtn" runat="server" Text="回上頁" PostBackUrl="~/MAT/MAT3/MAT3101_01.aspx" />
    </div>
</asp:Content>

