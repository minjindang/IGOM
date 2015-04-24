<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcAttach.ascx.vb" Inherits="UControl_UcAttach" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:LinkButton ID="lbLook" runat="server" OnClick="lbLook_Click" Text="查看"></asp:LinkButton>
<asp:HiddenField ID="hfFlowId" runat="server" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="lbLook"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1">
<table id="table" class="tableStyle99" border = '1' cellpadding="0" cellspacing ="0" width="100%" runat="server" Visible="false">
    <tr>
        <td>                
        <asp:GridView ID="gvAtt" runat="server" AutoGenerateColumns="False" Borderwidth="0px" CssClass="Grid" width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="項次"  ItemStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="gv_lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                    <asp:HiddenField ID="gv_hfId" runat="server" Value='<%# Bind("id")%>'></asp:HiddenField>
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="附件">
                    <ItemTemplate>
                        <asp:HiddenField ID="gv_hdfilePath" runat="server" Value='<%# Bind("File_Path") %>' />
                        <asp:HiddenField ID="gv_hdfileRealName" runat="server" Value='<%# Bind("File_real_name")%>' />
                        <asp:LinkButton ID="gv_lbtnAttachFile" runat="server" Text='<%# Bind("File_Name") %>' OnClick="gv_lbtnAttachFile_Click" ></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>  
                <asp:TemplateField ItemStyle-Width="50px"  ItemStyle-HorizontalAlign="Center" Visible="false" >
                    <ItemTemplate>
                        <asp:LinkButton ID="gv_lcbDel" runat="server" OnClick="gv_lcbDel_Click">刪除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>         
            </Columns>        
        </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="cbCancel" runat="server" Text="關閉" OnClick="cbCancel_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>            
        </td>
    </tr>
</table>
</asp:Panel>