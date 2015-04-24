<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SYS3111_02.aspx.vb" Inherits="SYS3111_02" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">人員角色設定
                        </td>
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                         <td class="htmltable_Right" style="width:250px">
                             <asp:Label ID="lbName" runat="server" />
                         </td>
                         <td class="htmltable_Left" style="width: 100px">員工編號</td>
                         <td class="htmltable_Right">
                            <asp:Label ID="lbId_card" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBoxList ID="cblRole" runat="server" RepeatColumns="5" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnConfrim" runat="server" Text="確認" />
                            <asp:Button ID="btnCancel" runat="server" Text="取消" />
                         </td>
                     </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
