<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2110_01.aspx.vb" Inherits="MAT2110_01" %>

<%@ Register src="~/UControl/UcROCYearMonth.ascx" tagname="UcROCYearMonth" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">月底結算
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">物品結算年月
                </td>
                <td colspan="3">
                    <uc2:UcROCYearMonth ID="UcROCYearMonth1" runat="server" />
                </td> 
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="CalBtn" runat="server" Text="結算物品收支月報表" />
            <asp:Button ID="PrnBtn" runat="server" Text="列印" />
            <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
        </div> 
    </div>

</asp:Content>

