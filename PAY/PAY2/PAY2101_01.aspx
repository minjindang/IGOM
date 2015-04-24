<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY2101_01.aspx.cs" Inherits="PAY_PAY2_PAY2101_01" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">零用金清單/備查簿列印</td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    會計年度
                </td>
                <td> 
                    <uc1:UcROCYear runat="server" ID="ucFiscalYear_id" />
                </td>
                <td class="htmltable_Left">
                    零用金清單編號(起~迄)
                </td>
                <td>
                    <asp:TextBox ID="txtPCList_idS" runat="server"></asp:TextBox>~<asp:TextBox ID="txtPCList_idE" runat="server"></asp:TextBox>
                 </td>
            </tr> 
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click" />
                    <asp:Button ID="Print2Btn" runat="server" Text="列印備查簿" OnClick="Print2Btn_Click" />
                    <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click"/>  
                </td>
            </tr>
        </table> 
    </div>


</asp:Content>

