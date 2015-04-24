<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="MAI2101_01.aspx.vb" Inherits="MAI2101_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                水電報修紀錄查詢
            </td>
        </tr>
        <tr>                    
            <td class="htmltable_Left" style="width:100px; height: 19px;">
                統計類別
            </td>
            <td class="TdHeightLight" style="width:250px; height: 19px;">
                <asp:DropDownList ID="ddlType" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" />
            </td>        
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                報修日期</td>
                <td class="htmltable_Right">
                    <uc1:UcDate runat="server" ID="UcDateS" />~<uc1:UcDate runat="server" ID="UcDateE" />
                </td>
        </tr>
        <tr>
            <td align="center" colspan="2" class="TdHeightLight">
                <asp:Button ID="btnExport" runat="server" Text="匯出" />
            </td>
        </tr>
                    
    </table>
</asp:Content>
