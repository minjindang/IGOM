<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3120_02.aspx.vb" Inherits="FSC3120_02" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">���B�N�z�H�]�w
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">���B���
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">���B¾��
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <asp:DropDownList ID="ddlBossTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">�N�z���
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDeputyDepart" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">�N�z�H
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLMember runat="server" ID="UcDDLMember" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnConfirm" runat="server" Text="�T�{" />
                            <asp:Button ID="btnCancel" runat="server" Text="����" />
                            <asp:HiddenField ID="hfid" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
