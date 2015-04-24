<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3104_01.aspx.vb" Inherits="PAY_PAY3_PAY3104_01" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">發E-mail通知零用金發放
            </td>
        </tr> 
        <tr>
            <td colspan="4">依零用金清單單號整批發信
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>年度別
            </td>
            <td style="width: 326px">
                 <uc1:UcROCYear runat="server" ID="ucFiscalYear_id" />
            </td>
            <td class="htmltable_Left"><span style="color: red;">*</span>零用金清單編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPCList_id" runat="server"></asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>主旨
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtSubject" runat="server" TextMode="MultiLine" Rows="3" Width="300"></asp:TextBox> 
            </td>
            <td class="htmltable_Left">副本人員
            </td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlCC" runat="server"></asp:DropDownList>
            </td>
        </tr> 
    </table>
    <div align="center">
        <asp:Button ID="SendBtn" runat="server" Text="發信" /> 
    </div>

</asp:Content>

