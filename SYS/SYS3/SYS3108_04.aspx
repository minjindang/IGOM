<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3108_04.aspx.vb" Inherits="SYS3108_04" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing ="0" width="100%" runat = "server" id = "TbQueryArea" class = "tableStyle99">
        <tr>
            <td colspan="6" class="htmltable_Title" >
                新增簽核流程</td>
        </tr>
        <tr>
            <td colspan="6" class="htmltable_Title2" >
                步驟三：職稱與簽核流程勾稽</td>
        </tr>
        <tr>
            <td class="htmltable_Left" rowspan="2" style="width:80px">簽核流程</td>
            <td colspan="5" style="letter-spacing: 1px; line-height: 25px">
                <asp:Label ID="lbFlowOutpost" runat="server"></asp:Label></td>

        </tr>
        <tr>
            <td colspan="5" style="letter-spacing: 0.5px; line-height: 25px">
                <asp:Label ID="lbFormText" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="6">
                選擇適用的單位與職稱</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                選擇單位
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <table style="border-width:0px; border-style:none;">
                    <tr><td><asp:RadioButton ID="rbl1" runat="server" GroupName="rbl" Checked="true" OnCheckedChanged="rbl1_CheckedChanged" AutoPostBack="true" /></td>
                        <td>全部單位</td>
                    </tr>
                    <tr><td><asp:RadioButton ID="rbl3" runat="server" GroupName="rbl" OnCheckedChanged="rbl1_CheckedChanged" AutoPostBack="true" /></td>
                        <td>一層單位</td>
                    </tr>
                    <tr><td><asp:RadioButton ID="rbl4" runat="server" GroupName="rbl" OnCheckedChanged="rbl1_CheckedChanged" AutoPostBack="true" /></td>
                        <td>二層單位</td>
                    </tr>
                    <tr><td><asp:RadioButton ID="rbl5" runat="server" GroupName="rbl" OnCheckedChanged="rbl1_CheckedChanged" AutoPostBack="true" /></td>
                        <td>三層單位</td>
                    </tr>
                    <tr><td><asp:RadioButton ID="rbl2" runat="server" GroupName="rbl" OnCheckedChanged="rbl2_CheckedChanged" AutoPostBack="true" /></td>
                        <td><uc1:UcDDLDepart runat="server" ID="ddlDepartname" /></td>
                    </tr>                    
                </table>  
                </ContentTemplate>
                </asp:UpdatePanel>    
            </td>
        </tr>                
        <tr>
            
            <td class="htmltable_Left">
                選擇人員</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:ListBox ID="lbxId_card" runat="server" DataTextField="User_name"
                    DataValueField="Id_card" Height="100px" width="130px" SelectionMode="Multiple"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:HiddenField ID="hfOrgcode" runat="server" />
            </td>

            <td class="htmltable_Left">
                選擇職稱
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        職稱層級
                        <asp:DropDownList ID="ddlTitle_Level" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="">全部</asp:ListItem>
                            <asp:ListItem Value="1">一層</asp:ListItem>
                            <asp:ListItem Value="2">二層</asp:ListItem>
                            <asp:ListItem Value="3">三層</asp:ListItem>
                            <asp:ListItem Value="0">其他</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:ListBox ID="lbxTitleNo" runat="server" DataTextField="Title_name"
                    DataValueField="Title_no" Height="100px" width="200px" SelectionMode="Multiple"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            
            <td class="htmltable_Left">
                選擇職務</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <asp:ListBox ID="lbxEmpType" runat="server" DataTextField="code_desc1"
                    DataValueField="code_no" Height="100px" width="180px" SelectionMode="Multiple"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center" >
                <asp:Button ID = "cbSelect" Text = "選擇" runat = "server" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing ="0" width="100%" id="Table3" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" >
                設定結果</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"
                    CssClass="Grid" width="100%" PagerStyle-HorizontalAlign="Right">
                    <Columns>
                        <asp:TemplateField HeaderText="適用單位">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Depart_name") %>'></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Depart_id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="適用職稱/人員">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("target_name")%>'></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("target") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="動作">
                            <ItemTemplate>
                                <asp:Button ID="gv_cbCancel" runat="server" Text="取消" OnClick="gv_cbCancel_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <RowStyle CssClass="Row" />
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="cbPreStep" runat="server" Text="上一步" UseSubmitBehavior="False" /><asp:Button ID="cbCancel" runat="server" Text="取消" UseSubmitBehavior="False" /><asp:Button ID="cbSave" runat="server" Text="確認" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
</asp:Content>