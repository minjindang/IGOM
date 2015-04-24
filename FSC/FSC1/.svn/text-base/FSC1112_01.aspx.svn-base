<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1112_01.aspx.vb" Inherits="FSC1112_01" %>
    
<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/FSC/UcLeaveMember.ascx" TagPrefix="uc2" TagName="UcLeaveMember" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagPrefix="uc2" TagName="UcTextBox" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc2" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>






<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td colspan="2" class="htmltable_Title">
                紙本表單線上申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請人姓名</td>
            <td class="htmltable_Right">
                <uc2:UcLeaveMember runat="server" ID="UcLeaveMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請日期</td>
            <td class="htmltable_Right">
                <uc2:UcDate id="UcDate" runat="server">
                </uc2:UcDate>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>紙本表單項目</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlPaper" runat="server" DataValueField="id" DataTextField="File_Name" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請事由</td>
            <td class="htmltable_Right">
                <uc2:UcTextBox runat="server" ID="tbReason" EnableViewState="true" MaxLength="400"
                    TextMode="MultiLine" Width="300" />
                <br />
                <span style="color:blue">註：請輸入400字為限。</span>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>上傳紙本表單檔案</td>
            <td class="htmltable_Right">
                <asp:FileUpload ID="fuFile" runat="server" />
                <asp:GridView ID="gvAtt" runat="server" AutoGenerateColumns="False" Borderwidth="0px" CssClass="Grid" width="100%" Visible="false">
                <Columns>
                    <asp:TemplateField HeaderText="附件">
                        <ItemTemplate>
                            <asp:HiddenField ID="gv_hdfilePath" runat="server" Value='<%# Bind("File_Path") %>' />
                            <asp:LinkButton ID="gv_lbtnAttachFile" runat="server" Text='<%# Bind("File_Name") %>' OnClick="gv_lbtnAttachFile_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>     
                    <asp:TemplateField ItemStyle-Width="50px"  ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="gv_lcbDel" runat="server" OnClick="gv_lcbDel_Click">刪除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>   
                </Columns>        
            </asp:GridView>
            <br />
            <span style="color:blue">※ 僅可上傳WORD格式的紙本表單檔案。</span>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">上傳其他附件檔案</td>
            <td class="htmltable_Right">
                <uc2:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <tr id="trNext" runat="server">
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>選擇審核人員
            </td>
            <td class="htmltable_Right">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
                <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">備註說明
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMark" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbSubmit" runat="server" Text="送出申請"  />
                <input id="cbReset" onclick="clearForm(this.form)" type="button" value="重填" />
            </td>
        </tr>
    </table>
</asp:Content>
