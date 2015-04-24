<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT1114_03.aspx.vb" Inherits="MAT_MAT1_MAT1114_03" %>


<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc2" TagName="ucSaCode" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">盤點調整-維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料編號
            </td>
            <td style="width: 326px">
                <asp:HiddenField runat="server" ID="hfInventory" />
                <asp:TextBox ID="txtMaterial_id" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td class="htmltable_Left">物料名稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMaterial_name" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">單位
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnit" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td class="htmltable_Left">盤點前數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtInvBefore_cnt" runat="server"  Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">盤點日期
            </td>
            <td style="width: 326px">
                 <uc2:UcDate ID="ucInv_date" runat="server" />  
            </td>
            <td class="htmltable_Left">盤點數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtInvAfter_cnt" runat="server" AutoPostBack="True" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">調整數量
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtInvModify_cnt" runat="server" Enabled="false"></asp:TextBox>
            </td> 
        </tr> 
        <tr>
            <td class="htmltable_Left">差異解釋說明
            </td>
            <td colspan="3">
                <uc2:ucSaCode runat="server" ID="ucDiff_desc" Code_sys="014" Code_type="003" ControlType="DropDownList"  />
                <asp:TextBox ID="txtDiff_desc" runat="server" TextMode="MultiLine" Height="76px" Width="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DoneBtn" runat="server" Text="確認" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
    </div>
</asp:Content>

