<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3107_01.aspx.vb" Inherits="FSC3107_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%" class="tableStyle99">        
        <tr>
            <td class="htmltable_Title" colspan="2">
                �~�׵���@�~
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                ���ɶ���</td>                        
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlitem" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged">
                    <asp:ListItem Text="���𰲥[�Z�O�j��ӽФ��d�ߧ@�~" Value="1"></asp:ListItem>
                    <asp:ListItem Text="�s�W���u�s�~�׫O�d�����ɧ@�~" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                �~��</td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                ���u����</td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlEmpType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>                
    </table>

    <div style="text-align:center;">
        <asp:Button ID="btnTrans" runat="server" Text="����/�d��" OnClientClick="blockUI()" />
    </div>

    <table id="TABLE2" runat="server" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Right">
                <asp:Button ID="cbConfirm" runat="server" Text="�T�{" OnClick="cbConfirm_Click" />
                <asp:Button ID="cbSendNotice" runat="server" Text="���𰲥[�Z�O�q��" OnClick="cbSendNotice_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    ShowFooter="false" width="100%" AllowPaging="false">
                    <FooterStyle CssClass="Foot" />
                    <RowStyle CssClass="Row" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <asp:CheckBox ID="cbxAll" runat="server" OnCheckedChanged="cbxAll_CheckedChanged" AutoPostBack="true" />                                
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />  
                                <asp:HiddenField ID="hfDepart_id" runat="server" value='<%# Bind("Depart_id")%>'/>                                                                                           
                                <asp:HiddenField ID="hfUser_name" runat="server" value='<%# Bind("User_name")%>'/> 
                                <asp:HiddenField ID="hfId_card" runat="server" value='<%# Bind("Id_card")%>'/> 
                                <asp:HiddenField ID="hfHolidays" runat="server" value='<%# Bind("Holidays")%>'/> 
                                <asp:HiddenField ID="hfLeave_days" runat="server" value='<%# Bind("Leave_days")%>'/> 
                                <asp:HiddenField ID="hfCan_pay_days" runat="server" value='<%# Bind("Can_pay_days")%>'/> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Depart_name" HeaderText="���" />
                        <asp:BoundField DataField="User_name" HeaderText="�H���m�W" />
                        <asp:BoundField DataField="yyy" HeaderText="�ӽЦ~��" />
                        <asp:BoundField DataField="Holidays" HeaderText="�i��Ѽ�" />
                        <asp:BoundField DataField="Leave_days" HeaderText="�w��Ѽ�" />
                        <asp:BoundField DataField="Can_pay_days" HeaderText="�i�ФѼ�" />
                        <asp:TemplateField HeaderText="�ӽФѼ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApplyDays" runat="server" Width="50" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        �d�L���
                    </EmptyDataTemplate>
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>

            </td>
        </tr>
    </table>

</asp:Content>
