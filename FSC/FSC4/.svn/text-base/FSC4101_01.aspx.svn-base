<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC4101_01.aspx.vb" Inherits="FSC4_FSC4101_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
               員工勤惰資料匯出至P2K
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                單位名稱
            </td>
            <td class="TdHeightLight">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDepart" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            
            <td class="htmltable_Left" style="width:100px">
                科別名稱</td>
            <td class="TdHeightLight">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSubDepart_name" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                職稱
            </td>
            <td class="TdHeightLight">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            
            <td class="htmltable_Left" style="width:100px">
                人員姓名
            </td>
            <td class="TdHeightLight">
               <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlName" runat="server" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                年度
            </td>
            <td class="TdHeightLight">
                <asp:TextBox ID="tbYear" runat="server" MaxLength="4"></asp:TextBox>
            </td>
            <td class="htmltable_Left" style="width:100px">
                在職狀況
            </td>
            <td class="TdHeightLight">
                    <asp:DropDownList ID="ddlWork" runat="server">
                    </asp:DropDownList>
            </td>
        </tr>    
        <tr>
            <td class="htmltable_Left" style="width:100px">
                員工編號
            </td>
            <td class="TdHeightLight">
                <asp:TextBox ID="tbID_card" runat="server" MaxLength="10"></asp:TextBox>
            </td>
            
            <td class="htmltable_Left" style="width:100px">
            </td>
            <td class="TdHeightLight">
                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="cbExport" runat="server" Text="匯出" />
                <input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)" />
            </td>
        </tr>
    </table>
    </asp:Content>
