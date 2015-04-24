<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcAttachUploadButton.ascx.vb" Inherits="UControl_SYS_UcAttachUploadButton" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:Button ID="cbUpload" runat="server" Text="附件上傳" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbUpload"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfFlowId" runat="server" />

<asp:Panel runat="server" ID="Panel1">
<table class="tableStyle99">
    <tr>
        <td valign="top" style="width:450px">            
            <table>
                <tr>
                    <td class="htmltable_Left" style="width:120px">
                        附件檔案1</td>
                    <td class="htmltable_Right">
                        <asp:FileUpload ID="fuFile1" runat="server"  width="300px"  />
                    </td>
                </tr>
                <%--<tr>
                    <td class="htmltable_Left" style="width:120px">
                        附件檔案2</td>
                    <td class="htmltable_Right">
                        <asp:FileUpload ID="fuFile2" runat="server"  width="300px" />
                        </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width:120px">
                        附件檔案3</td>
                    <td class="htmltable_Right">
                        <asp:FileUpload ID="fuFile3" runat="server"  width="300px" />
                        </td>
                </tr>--%>
            </table>
        </td>
    </tr>    
    <tr>
        <td colspan="2">
            <%--<asp:Label ID="lblMeMo" runat="server" ForeColor="Blue" Text="※	最多可上傳3個檔案。<br>※	每個檔案大小上限為1MB(1024kbytes)。<br>※	3個檔案大小合計上限為3MB(3072kbytes)。<br>※	副檔名為doc、xls、ppt、docx、xlsx、pptsx、txt、pdf、zip、rar、jpg、png、bmp。">--%>
            <asp:Label ID="lblMeMo" runat="server" ForeColor="Blue" Text="※	每個檔案大小上限為2MB(2048kbytes)。<br>※	副檔名為doc、xls、ppt、docx、xlsx、pptsx、txt、pdf、zip、rar、jpg、png、bmp。">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" />
            <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" />
        </td>
    </tr>
</table>
</asp:Panel>
