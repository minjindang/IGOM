<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT1101_01.aspx.vb" Inherits="MAT_MAT1_MAT1101_01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="scrollFollow" style="position:fixed;float:right;bottom:0;right:0px">
        <table id="Table1" runat="server">
            <tr>
                <td>
                    <asp:Button ID="OkBtn" runat="server" Text="確認" OnClick="OkBtn_Click" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" PostBackUrl="~/MAT/MAT1/MAT1101_01.aspx" OnClick="ResetBtn_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Div_Approve_Query" runat="server">
        <asp:ListView ID="lvMatClass" runat="server">
            <LayoutTemplate>
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title" colspan="2">個人領物申請
                        </td>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <table class="tableStyle99" width="100%">
                <tr runat="server" >
                    <td class="htmltable_Left">
                        <asp:Label ID="lblMatClassName" runat="server" Text='<%# Eval("MaterialClass_name")%>'></asp:Label>
                        <asp:HiddenField ID="hfMatClassId" runat="server" Value='<%# Eval("MaterialClass_id")%>' />
                    </td>
                    <td>
                        <asp:DataList ID="dlMaterial" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" BorderWidth="0" BorderStyle="None" RepeatLayout="Flow"  >
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAvailable_cnt" runat="server" Value='<%# Eval("Available_cnt")%>' />
                                <asp:HiddenField ID="hfMaterial_id" runat="server" Value='<%# Eval("Material_id")%>' />
                                <asp:HiddenField ID="hfMaterialIcon" runat="server" Value='<%# Eval("MaterialIcon")%>' />
                                <asp:CheckBox ID="cbMaterial_name" runat="server" Text='<%# Eval("Material_name")%>' />
                                <asp:Image ID="imgMaterial" runat="server" Width="64px" Height="64px" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>