<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3118_02.aspx.vb" Inherits="SYS3118_02"  %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLDepart02.ascx" TagPrefix="uc1" TagName="UcDDLDepart02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                紙本表單維護</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位
            </td>
            <td class="htmltable_Right">
                <uc1:UcDDLDepart02 runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                表單
            </td>
            <td class="htmltable_Right">
                <asp:FileUpload ID="fuFile" runat="server" />
                <br />
                <asp:Label ID="lbFile_name" runat="server"></asp:Label>
                <asp:HiddenField ID="hfFile_name" runat="server" />
                <asp:HiddenField ID="hfReal_name" runat="server" />
                <asp:HiddenField ID="hfPath" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                上架時間
            </td>
            <td class="htmltable_Right">
                <uc1:UcDate runat="server" ID="UcDate1" />~<uc1:UcDate runat="server" ID="UcDate2" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                是否下架
            </td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblFlag" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True" >否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbConfrim" runat="server" Text="確認" OnClick="cbConfrim_Click" />
               <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" /></td>
        </tr>
    </table>
</asp:Content>

