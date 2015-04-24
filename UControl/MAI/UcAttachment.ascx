<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcAttachment.ascx.vb" Inherits="UControl_MAI_UcAttachment" %>
<div id="div1" runat="server">           
    <div id="div11" runat="server">    
        <asp:FileUpload ID="fuFile1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="上傳" />
    </div>        
    <div id="div12" runat="server">
        <asp:GridView ID="gvAtt" runat="server" AutoGenerateColumns="False" Borderwidth="0px" CssClass="Grid" 
            Visible="false">
            <Columns>
                <asp:TemplateField HeaderText="項次" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:Label ID="gv_lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                        <asp:HiddenField ID="gv_hfId" runat="server" Value='<%# Bind("id")%>'></asp:HiddenField>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附件" >
                    <ItemTemplate>
                        <asp:HiddenField ID="gv_hdfilePath" runat="server" Value='<%# Bind("File_Path") %>' />
                        <asp:HiddenField ID="gv_hdfileRealName" runat="server" Value='<%# Bind("File_real_name")%>' />
                        <asp:LinkButton ID="gv_lbtnAttachFile" runat="server" Text='<%# Bind("File_Name") %>' OnClick="gv_lbtnAttachFile_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>     
                <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="gv_lcbDel" runat="server" OnClick="gv_lcbDel_Click">刪除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>   
            </Columns>        
        </asp:GridView>
    </div>
</div> 
<div id="div2" runat="server">
    <%--<asp:Label ID="lblMeMo" runat="server" ForeColor="Blue" Text="※	最多可上傳3個檔案。<br>※	每個檔案大小上限為1MB(1024kbytes)。<br>※	3個檔案大小合計上限為3MB(3072kbytes)。<br>※	副檔名為doc、xls、ppt、docx、xlsx、pptsx、txt、pdf、zip、rar、jpg、png、bmp。">--%>
    <asp:Label ID="lblMeMo" runat="server" ForeColor="Blue" Text="※	每個檔案大小上限為2MB(2048kbytes)。<br>※	副檔名為doc、xls、ppt、docx、xlsx、pptsx、txt、pdf、zip、rar、jpg、png、bmp。">
    </asp:Label>
</div>
<asp:HiddenField ID="hfMainId" runat="server" />
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfFlowId" runat="server" />
