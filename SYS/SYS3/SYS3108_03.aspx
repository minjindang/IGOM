<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3108_03.aspx.vb" Inherits="SYS3108_03"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="TbSettingHourNumCondiForm" runat="server" border="0" cellpadding="0"
        cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                新增簽核流程
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                步驟二.設定時數條件與適用差假別
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="100">
                申請類別
            </td>
            <td>
                <asp:DropDownList ID="ddlCodeType" runat="server" AutoPostBack="true" DataTextField="code_desc1" DataValueField="code_no">
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="100">
                申請項目
            </td>
            <td>
                <asp:CheckBoxList ID="cbxlForm" runat="server" 
                    DataTextField="formName" DataValueField="formId">
                </asp:CheckBoxList>
                
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                請設定流程<br />
                的時數條件</td>
            <td>
                <asp:Table ID="Table1" runat="server"></asp:Table>
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="Grid" width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="關卡順序">
                                <ItemTemplate>
                                    <asp:Label ID="gv_lbFlow_outpost_id" runat="server" Text='<%# Bind("Flow_outpost_id")%>' Visible="false" />
                                    <asp:Label ID="gv_lbOutpost_id" runat="server" Text='<%# Bind("Outpost_id")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbOutpost_orgcode" runat="server" Text='<%# Bind("Outpost_orgcode")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbOutpost_departid" runat="server" Text='<%# Bind("Outpost_Departid")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbOutpost_posid" runat="server" Text='<%# Bind("Outpost_posid")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbGroup_id" runat="server" Text='<%# Bind("Group_id")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbGroup_seq" runat="server" Text='<%# Bind("Group_seq")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbGroup_type" runat="server" Text='<%# Bind("Group_type")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbRelate_flag" runat="server" Text='<%# Bind("Relate_flag")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbUnit_flag" runat="server" Text='<%# Bind("Unit_flag")%>' Visible="false"/>
                                    <asp:Label ID="gv_lbOutpost_seq" runat="server" Text='<%# Bind("Outpost_seq") %>' />
                               </ItemTemplate>
                                <ItemStyle width="50px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="流程關卡">
                                <ItemTemplate><asp:Label ID="gv_lbtext" runat="server" Text='<%# Bind("text") %>' /></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="設定時數條件">
                                <ItemTemplate>
                                    <asp:HiddenField ID="gv_hfHoursettingId" runat="server" value='<%# Bind("Hoursetting_id") %>'/>
                                    <asp:DropDownList ID="gv_ddlHoursettingId" runat="server"
                                        DataTextField="code_desc1" DataValueField="code_no">
                                    </asp:DropDownList>
                                    
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="郵件通知">
                                <ItemTemplate>
                                    <asp:HiddenField ID="gv_hfMailFlag" runat="server" value='<%# Bind("Mail_flag")%>'/>
                                    <asp:RadioButtonList ID="gv_rbxlMailFlag" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="cbPreStep" runat="server"
                     PostBackUrl="" Text="上一步" UseSubmitBehavior="False" /><asp:Button ID="cbCancel" runat="server"
                     PostBackUrl="" Text="取消" UseSubmitBehavior="False" /><asp:Button ID="cbConfirm" runat="server" OnClick="cbConfirm_Click" 
                    Text="確認" UseSubmitBehavior="False" Visible="false" /><asp:Button ID="cbNextStep" runat="server"
                     PostBackUrl="" Text="下一步" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
</asp:Content>

