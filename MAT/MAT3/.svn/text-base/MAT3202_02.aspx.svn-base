<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT3202_02.aspx.vb" Inherits="MAT3202_02" %>

<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc2" TagName="ucSaCode" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">盤點調整-新增
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMaterial_id" runat="server" MaxLength="9" AutoPostBack="True"></asp:TextBox>
                <uc1:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
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
            <td class="htmltable_Left">盤點後數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtInvAfter_cnt" runat="server" MaxLength="6" AutoPostBack="True" ></asp:TextBox>
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
                <%--<uc2:ucSaCode runat="server" ID="ucDiff_desc" Code_sys="014" Code_type="003" ControlType="DropDownList" DDLDefaultValue="true"  />--%>
                <asp:DropDownList ID="ddlDiff_desc" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true" />
                <asp:TextBox ID="txtDiff_desc" runat="server" TextMode="MultiLine" Height="76px" Width="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DoneBtn" runat="server" Text="確認" />
        <%--<asp:Button ID="ResetBtn" runat="server" Text="清空重填" />--%>
        <input type="button" value="清空重填" onclick="clearForm(this.form);" />
        <asp:Button ID="BackBtn" runat="server" Text="回上頁" PostBackUrl="~/MAT/MAT3/MAT3202_01.aspx" />
    </div>
</asp:Content>

