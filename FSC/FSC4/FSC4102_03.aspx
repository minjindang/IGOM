<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4102_03.aspx.vb" Inherits="FSC4102_03" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center" colspan="4">
                ���q���H���]�w
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
                �t���O
            </td>
            <td class="htmltable_Right" style="width:550px" colspan="3">
                <asp:Label ID="lbLeave_name" runat="server"></asp:Label>
                <asp:HiddenField ID="hfLeave_type" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               <span style="color:Red">*</span>���W��
            </td>
            <td class="TdHeightLight">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                ¾��</td>
            <td class="TdHeightLight">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTitle_Name" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                            DataTextField="CODE_DESC1" DataValueField="CODE_NO">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                �H���m�W</td>
            <td class="TdHeightLight">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUser_name" runat="server" DataTextField="User_name"
                            DataValueField="Id_card" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>        
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="cbAdd" runat="server" Text="�s�W" />
                <asp:Button ID="cbCancel" runat="server" Text="����" />
            </td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td style="width: 100%;" class="htmltable_Right" colspan="4">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" BorderWidth="0px" PageSize="30"
                    AllowPaging="True" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="�d�L���">
                    <Columns>
                        <asp:TemplateField HeaderText="����H">
                            <ItemTemplate>
                                <asp:Label ID="lbUser_name" Text='<%# Bind("User_name") %>' runat="server" />
                                <asp:HiddenField ID="hfID_card" Value ='<%# Bind("ID_card") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lbEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���@">
                            <ItemTemplate>
                                <asp:Button ID="cbDelete" runat="server" Text="�R��" 
                                    OnClientClick="javascript:if(!confirm('�O�_�T�w�R���H')) return false;" 
                                    onclick="cbDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        �d�L���!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
