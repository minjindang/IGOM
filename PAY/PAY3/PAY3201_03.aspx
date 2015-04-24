<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3201_03.aspx.vb" Inherits="PAY_PAY3_PAY3201_03" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcPayer.ascx" TagPrefix="uc1" TagName="UcPayer" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">審查收入維護作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>收入類別
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtExamineIncome_type" runat="server" Enabled="false" ></asp:TextBox>
                <asp:DropDownList ID="ddlExamineIncome" runat="server" Enabled="false" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">收據編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtReceiptStart_id" runat="server" Enabled="false"></asp:TextBox>
                ~
                <asp:TextBox ID="txtReceiptEnd_id" runat="server" Enabled="false" ></asp:TextBox>
            </td>
            <td class="htmltable_Left"><span style="color: red;">*</span>收款日期
            </td>
            <td style="width: 326px">
                <uc1:UcDate runat="server" ID="ucReceipt_date" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">件數
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtExamine_cnt" runat="server" Enabled="false" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">單價
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnitPrice_amt" runat="server" Enabled="false" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>總額
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTotalPrice_amt" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>付款人
            </td>
            <td colspan="3">
                <uc1:UcPayer runat="server" ID="UcPayer" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">付款方式
            </td>
            <td style="width: 326px"> 
                <asp:DropDownList ID="ddlPayMode_type" runat="server"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">收據已作廢
            </td>
            <td style="width: 326px">
                <asp:CheckBox ID="cbReceiptScrap_type" runat="server" AutoPostBack="true" OnCheckedChanged="cbReceiptScrap_type_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">支票號碼一
            </td> 
            <td style="width: 326px">
                <asp:TextBox ID="txtCheck1_nos" runat="server" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">支票號碼二
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtCheck2_nos" runat="server" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DonBtn" runat="server" Text="確認" />
        <asp:Button ID="ResetBtn" runat="server" Text="放棄修改" />
        <asp:Button ID="BackBtn" runat="server" Text="回查詢" />
    </div>
</asp:Content>

