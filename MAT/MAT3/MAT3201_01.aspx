<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT3201_01.aspx.vb" Inherits="MAT_MAT3_MAT3201_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">執行盤點註記
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">盤點開始日期
            </td>
            <td>
                <uc2:UcDate ID="ucInvStart_date" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">預定完成盤點日期
            </td>
            <td>
                <uc2:UcDate ID="ucExpected_date" runat="server" />
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DoneBtn" runat="server" Text="開始執行盤點" />
    </div>
</asp:Content>

