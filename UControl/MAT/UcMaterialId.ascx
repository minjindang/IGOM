<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcMaterialId.ascx.vb" Inherits="UControl_UcMaterialId" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>


<asp:Button ID="cbPick" runat="server" Text="..." OnClick="cbPick_Click"  />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbPick"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>


<asp:Panel runat="server" ID="Panel1"  >
    <div style="width:300px;height:400px;overflow:auto;" >
    <table class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">物料挑選</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                物料類別
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlClass" runat="server" DataTextField="MaterialClass_name" DataValueField="MaterialClass_id"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" OnClick="cbQuery_Click" />
                <asp:Button ID="cbClose" runat="server" Text="關閉" OnClick="cbClose_Click" />
            </td>        
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv" runat="server"
                    AutoGenerateColumns="false" CssClass="Grid"
                    AllowPaging="false" PagerSettings-Visible="true"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!">
                    <PagerSettings Visible="False"/>
                    <Columns>      
                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:RadioButton ID="rb" runat="server" AutoPostBack="true" OnCheckedChanged="rb_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>              
                        <asp:TemplateField HeaderText="物料名稱">
                            <ItemTemplate>
                                <asp:Label ID="Material_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="物料編號">
                            <ItemTemplate>
                                <asp:Label ID="Material_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfOrgcode" runat="server" />
    <asp:HiddenField ID="hfMaterialId" runat="server" />
    </div>
</asp:Panel>