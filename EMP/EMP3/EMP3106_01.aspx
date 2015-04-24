<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="EMP3106_01.aspx.vb" Inherits="EMP3106_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLMemberWithoutMaintainVendors.ascx" TagPrefix="uc1" TagName="UcDDLMemberWithoutMaintainVendors" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">員工個人資料
                        </td>
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                         <td class="htmltable_Right" style="width:250px">
                             <asp:Label ID="lbName" runat="server" />
                             <asp:Label ID="lbBirthday" runat="server" Visible="false" />
                         </td>
                         <td class="htmltable_Right" style="width:250px" rowspan="3" colspan="2" >
                              <asp:Image ID="imgPic" runat="server" Width="80px" />
                              <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />
                              <asp:Button ID="btnUpload" runat="server" Text="上傳" />
                         </td>
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">員工編號</td>
                         <td class="htmltable_Right">
                            <asp:Label ID="lbId_card" runat="server" />
                        </td>
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">單位</td>
                         <td class="htmltable_Right">
                             <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">分機</td>
                         <td class="htmltable_Right">
                             <asp:TextBox ID="tbext" runat="server" MaxLength="4" Width="50px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Title" colspan="4">員工個人簡介</td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">自述</td>
                        <td class="htmltable_Right" style="width: 230px">
                            <asp:TextBox ID="txtIntro_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                        </td>
                        <td class="htmltable_Left" style="width: 120px">專長</td>
                        <td class="htmltable_Right" style="width: 230px">
                            <asp:TextBox ID="txtSkill_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">興趣</td>
                        <td class="htmltable_Right" style="width: 230px">
                             <asp:TextBox ID="txtSpecialty_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                        </td>
                        <td class="htmltable_Left" style="width: 120px">心情感言</td>
                        <td class="htmltable_Right" style="width: 230px">
                             <asp:TextBox ID="txtMood_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Title" colspan="4">代理人設定</td>
                    </tr>
                     <tr>
                        <td style="width: 100%;" class="htmltable_Right" colspan="4">
                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                AllowPaging="True" PageSize="30" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                                Width="100%" EnableModelValidation="True" >
                                <Columns>
                                    <asp:TemplateField HeaderText="單位名稱" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
                                            <asp:HiddenField ID="hfDeputy_departid" runat="server" Value='<%# Eval("Deputy_departid")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="代理人">
                                        <ItemTemplate>
                                            <%--<uc1:UcDDLMember runat="server" ID="UcDDLMember" />--%>
                                            <uc1:UcDDLMemberWithoutMaintainVendors runat="server" ID="UcDDLMember" />
                                            <asp:HiddenField ID="hfDeputy_idcard" runat="server" Value='<%# Eval("Deputy_idcard")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="預設代理">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbDeputy_flag" runat="server" />
                                            <asp:HiddenField ID="hfDeputy_flag" runat="server" Value='<%# Eval("Deputy_flag")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnInsert" runat="server" Text="插入" OnClick="btnInsert_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" OnClientClick="javascript:if(!confirm('是否確定要刪除?')) return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td> 
                    </tr> 
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnConfrim" runat="server" Text="確認" />
                         </td>
                     </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
