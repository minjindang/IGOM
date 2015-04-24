<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY2103_01.aspx.cs" Inherits="PAY_PAY2_PAY2103_01" %>

<%@ Register Src="~/UControl/UcBank.ascx" TagPrefix="uc1" TagName="UcBank" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">受款人明細表</td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    受款人姓名
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtBeneficiary_name" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="htmltable_Left">銀行代碼/名稱</td>
                <td colspan="3">
                    <uc1:UcBank runat="server" ID="ucBank" />
                </td>
            </tr> 
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click" />
                    <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click"/>  
                </td>
            </tr>
        </table> 
    </div>

</asp:Content>

