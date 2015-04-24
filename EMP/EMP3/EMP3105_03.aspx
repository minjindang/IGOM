<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EMP3105_03.aspx.cs" Inherits="EMP3105_03" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc2" TagName="UcShowDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">        
        <tr>
            <td class="htmltable_Title"  colspan="2">
                人員借調設定</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
                <span style="color: #ff0000">*</span>借調起迄</td>
            <td class="htmltable_Right">                
                <uc2:UcDate runat="server" ID="UcDateS" />~
                <uc2:UcDate runat="server" ID="UcDateE" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
               備註</td>
            <td class="htmltable_Right" style="width:200px">
                <asp:TextBox ID="tbMemo" runat="server" Rows="5" Width="70%" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lbId" runat="server" Visible="false"></asp:Label>
                <asp:Button ID="cbConfirm" runat="server" Text="確認" onclick="cbConfirm_Click" />
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" Visible="false" 
                    onclick="cbCancel_Click" />
            </td>
        </tr>
    </table>
    <br />
     <table id="Table1" border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">        
        <tr>
            <td  colspan="4" class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30" 
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red" >                       
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="借調起日">
                            <ItemTemplate>
                                <uc2:UcShowDate runat="server" ID="UcShowDateS" Text='<%# Eval("Start_date") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="借調迄日">
                            <ItemTemplate>
                                <uc2:UcShowDate runat="server" ID="UcShowDateE" Text='<%# Eval("End_date") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="備註">
                            <ItemTemplate>
                                <asp:Label ID="lbMemo" runat="server" Text='<%# Eval("Memo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="cbUpdate" runat="server" Text="修改" onclick="cbUpdate_Click"/>
                                <asp:Button ID="cbDelete" runat="server" Text="刪除" 
                                    OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;" onclick="cbDelete_Click" 
                                    />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />                    
                </asp:GridView>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
