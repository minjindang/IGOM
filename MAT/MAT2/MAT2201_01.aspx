<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2201_01.aspx.vb" Inherits="MAT2201_01" EnableEventValidation="true"%>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>
<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%" runat="server">
            <tr>
                <td class="htmltable_Title" colspan="4">物品盤點報表</td>
            </tr>
            <tr runat="server">
                <td class="htmltable_Left">物料編號(起~迄)</td>
                <td style="width: 326px" colspan="3" runat="server">
                    <asp:TextBox ID="Material_idS" runat="server" Width="150px" MaxLength="9"></asp:TextBox>
                      <uc1:UcMaterialClass runat="server" ID="Material_detS" OnChecked="UcMaterialClassB_Checked" />
				        &nbsp;&nbsp;~&nbsp;&nbsp;
			        <asp:TextBox ID="Material_idE" runat="server" Width="150px" MaxLength="9"></asp:TextBox>
                    <uc1:UcMaterialClass runat="server" ID="Material_detE" OnChecked="UcMaterialClassE_Checked" />
                </td>
            </tr>            
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click"/>
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click"/>
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
                    <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridView_Uporg"
            PNow="1" PSize="25" Visible="true" />
        </div>
    </div>

</asp:Content>
