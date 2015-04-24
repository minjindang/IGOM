<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3201_01.aspx.vb" Inherits="FSC3201_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">線上差勤資料結轉作業</td>
        </tr>
        <tr>
            <td class="htmltable_Left">執行區間</td>
            <td class="htmltable_Right">                
                <uc1:UcDate runat="server" ID="UcSDate" />~
                <uc1:UcDate runat="server" ID="UcEDate" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="htmltable_Bottom">
                <asp:Button ID="btnRun" runat="server" Text="執行" />
            </td>
        </tr>
    </table>
</asp:Content>
