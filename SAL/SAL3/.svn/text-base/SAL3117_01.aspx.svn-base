<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL3117_01.aspx.vb" Inherits="SAL3117_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucGridViewPager.ascx" TagName="ucGridViewPager" TagPrefix="UserCon" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript">
function check()
{
    //year = parseInt(document.aspnetForm.ctl00_ContentPlaceHolder1_DropDownList_year.value);
	//msg = "民國" + year + "年" + document.aspnetForm.ctl00_ContentPlaceHolder1_DropDownList_month.value + "月之發薪資料";
	//msg = msg + "\n是否鎖定??";

	//if (confirm(msg)) {
	//    document.aspnetForm.submit();
	//}
}

    </script>

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">薪資鎖定作業</td>
        </tr>
        <tr>
            <td class="htmltable_Left">鎖定年月</td>
            <td style="width: 500px">民國
                <asp:DropDownList ID="DropDownList_year" runat="server" ></asp:DropDownList>
                <asp:DropDownList ID="DropDownList_month" runat="server" >
                    <asp:ListItem Value="01">01</asp:ListItem>
                    <asp:ListItem Value="02">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem Value="04">04</asp:ListItem>
                    <asp:ListItem Value="05">05</asp:ListItem>
                    <asp:ListItem Value="06">06</asp:ListItem>
                    <asp:ListItem Value="07">07</asp:ListItem>
                    <asp:ListItem Value="08">08</asp:ListItem>
                    <asp:ListItem Value="09">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>月
            </td>
            <td class="htmltable_Left" style="width: 170px">鎖定計算項目</td>
            <td>
                <uc1:ucSaCode ID="UcSaCode1" runat="server" Code_sys="003" Code_type="005" ControlType="DropDownList" ReturnEvent="true" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="btnUpdate" runat="server" Text="確定鎖定" OnClientClick="check()" />
            </td>
        </tr>
    </table>
</asp:Content>
