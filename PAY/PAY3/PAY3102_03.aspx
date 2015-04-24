<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3102_03.aspx.vb" Inherits="PAY_PAY3_PAY3102_03" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcBeneficiary.ascx" TagPrefix="uc1" TagName="UcBeneficiary" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">非預借零用金維護-維護 
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>會計年度
            </td>
            <td style="width: 326px"><uc1:UcROCYear runat="server" ID="ucFiscalYear_id" />
                <asp:HiddenField ID="hfSerialNumber_id" runat="server" /> 
            </td>
            <td class="htmltable_Left">零用金流水號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPettyCash_nos" runat="server" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>請購單號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPurchaseForm_id" runat="server" MaxLength="6" Width="80"></asp:TextBox>
                <asp:TextBox ID="txtPurchaseForm_sn" runat="server" MaxLength="6" Width="40"></asp:TextBox>
            </td>
            <td class="htmltable_Left"><span style="color: red;">*</span>發票日期
            </td>
            <td style="width: 326px">
                <uc1:UcDate runat="server" ID="ucInvoice_date" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>受款人
            </td>
            <td style="width: 326px">
                <uc1:UcBeneficiary runat="server" ID="UcBeneficiary" />
            </td>
            <td class="htmltable_Left">經手人
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMiddleman_id" runat="server" MaxLength="60" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txtMiddleman_name" runat="server" MaxLength="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>用途別
            </td>
            <td colspan="3">
                 <asp:TextBox ID="txtUse_type" runat="server" MaxLength="8"></asp:TextBox>
                 <asp:DropDownList ID="ddlUse_type" runat="server" AutoPostBack="true" ></asp:DropDownList>
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>單據張數
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtReceipt_cnt" runat="server" MaxLength="3"></asp:TextBox>
            </td>
            <td class="htmltable_Left"><span style="color: red;">*</span>請購金額
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPurchaseTotal_amt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">摘要
            </td> 
            <td style="width: 326px">
                <asp:TextBox ID="txtPurchaseAbstract_desc" runat="server" TextMode="MultiLine" Width="450" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">目前結存金額
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBalance_amt" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left">核銷日期
            </td>
            <td style="width: 326px">
                <uc1:UcDate runat="server" ID="ucWriteOff_date"  />
            </td>
            <td class="htmltable_Left">付款憑單編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPaymentVoucher_id" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr> 
    </table>
    <div align="center">
        <asp:Button ID="DonBtn" runat="server" Text="確認" />
        <asp:Button ID="ResetBtn" runat="server" Text="放棄修改" />
        <asp:Button ID="BackBtn" runat="server" Text="回上頁" OnClick="BackBtn_Click" />
        <asp:HiddenField ID="hfIsGeneration" runat="server" />
    </div>
</asp:Content>
