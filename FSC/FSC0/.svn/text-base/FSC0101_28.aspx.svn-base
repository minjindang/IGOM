<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_28.aspx.vb" Inherits="FSC0101_28" %>

<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc1" TagName="UcCustomNext" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td colspan="2" class="htmltable_Title">
                表單明細
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單編號</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbFlow_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單申請人</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbApplyName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                表單項目</td>
            <td class="htmltable_Right">
                紙本表單申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                紙本表單項目</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbPaperName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                填單日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbChange_date" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                申請事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbReason" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                上傳紙本表單檔案</td>
            <td class="htmltable_Right">
                <asp:LinkButton ID="lbtnAttachFile" runat="server" ></asp:LinkButton>
                <asp:HiddenField ID="hdfilePath" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">上傳其他附件檔案</td>
            <td class="htmltable_Right">
                <uc1:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />                
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
                <uc1:UcCustomNext runat="server" ID="UcCustomNext" Visible="false" OnClick="UcCustomNext_Click" />
            </td>
        </tr>
    </table>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />

</asp:Content>
