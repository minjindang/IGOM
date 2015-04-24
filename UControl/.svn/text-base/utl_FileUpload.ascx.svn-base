<%@ Control Language="VB" AutoEventWireup="false" CodeFile="utl_FileUpload.ascx.vb" Inherits="FileUpload" %>

<asp:FileUpload ID="FileUpload1" runat="server" width="400px"   /><br />
<asp:Button ID="Button1" runat="server"  Text="上傳" />
    <asp:Button ID="Button2" runat="server"    Text="刪除" />
<asp:CheckBox ID="chkVisible" runat="server" ForeColor="Red" Text="是否隱藏" /><br />
    <asp:GridView ID="GridView1" runat="server" Cssclass="htmltable_Title" Height="81px" width="100%" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="cbxAttach" runat="server"></asp:CheckBox>
                 <asp:HiddenField id="AttachID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AttachID") %>' />
                <asp:HiddenField id="FileName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "FilePath") %>' />
             </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="FileRealName" HeaderText="檔案名稱" />
        <asp:BoundField DataField="UploadID" HeaderText="上傳者" />
        <asp:BoundField DataField="UploadDate" HeaderText="上傳時間" />
    </Columns>
        <PagerStyle ForeColor="Red" />
    </asp:GridView>

&nbsp;
