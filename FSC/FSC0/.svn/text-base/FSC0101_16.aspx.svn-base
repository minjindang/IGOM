<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_16.aspx.vb" Inherits="FSC0101_16" %>

<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc1" TagName="UcFlowDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">表單明細</td>
        </tr>
        <tr>
            <td class="htmltable_Left">表單編號</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbFlow_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="border-bottom: none;">表單申請人</td>
            <td class="htmltable_Right" style="border-bottom: none;">
                <asp:Label ID="lbApply_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">表單填寫人</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWrite_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請項目</td>
            <td class="htmltable_Right">
                值日(夜)代(換)值申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">填單日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWrite_time" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">批核日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbAgree_time" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請代(換)類別</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDuty_type" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請代(換)值人員</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbApply_Username" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">指定代(換)值人員</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbShift_Username" runat="server" />
            </td>
        </tr>

        <tr>
            <td class="htmltable_Left">原值班日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbOriginal_Dutydate" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">代(換)值班日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbShift_Dutydate" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">原班別</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbSchedule_Name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">代(換)換班別</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbShift_Schedule_Name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDuty_reason" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />                
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
            </td>
        </tr>
    </table>
    <uc1:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>
