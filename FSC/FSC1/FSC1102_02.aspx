<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1102_02.aspx.vb" Inherits="FSC1102_02" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="~/UControl/UcLeaveDate.ascx" TagName="UcLeaveDate" TagPrefix="uc7" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/FSC/UcLeaveMember.ascx" TagName="UcLeaveMember" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcLeaveDeputy.ascx" TagPrefix="uc2" TagName="UcLeaveDeputy" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc2" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcLeaveDate2.ascx" TagPrefix="uc2" TagName="UcLeaveDate2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function chgUcDate(id) {
            __doPostBack(id, '');
        }
    </script>
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%" class="tableStyle99">    
        <tr>
            <td colspan="2" class="htmltable_Title">
                申請公差
            </td>
        </tr>
        <tr >
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>申請類別</td>
            <td class="htmltable_Right">            
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLeave_type" runat="server" DataTextField="LeaveName" DataValueField="LeaveType">
                            <asp:ListItem Text="公差" Value="05"></asp:ListItem>
                            <%--<asp:ListItem Text="公出" Value="07"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr >
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>申請人員</td>
            <td class="htmltable_Right">                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:UcLeaveMember ID="UcLeaveMember" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>職務代理人</td>
            <td class="htmltable_Right"> 
                <uc2:UcLeaveDeputy runat="server" ID="UcLeaveDeputy" />
            </td>
        </tr>   
        <tr id="sigleDateTr1">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>公差日期</td>
            <td class="htmltable_Right">
                <uc2:UcLeaveDate2 runat="server" ID="UcLeaveDate" />   
            </td>                          
        </tr>
        <tr id="sigleDateTr2" runat="server" visible="false" >
            <td class="htmltable_Left" style="width:120px">
                假日執行<br />
                公務時間</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <uc7:UcLeaveDate ID="UcHolidayDate" runat="server" IsDefault="false" />
                        <asp:CheckBox ID="hcbx" runat="server" Text="假日執行公務" AutoPostBack="True" OnCheckedChanged="hcbx_CheckedChanged" />
                        (請填入洽公或開會時間。)
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>公差地點</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblLocationFlag" runat="server" RepeatColumns="2">
                     <asp:ListItem Value="0" Text="國內" Selected="True"></asp:ListItem>
                     <asp:ListItem Value="1" Text="國外"></asp:ListItem>
                </asp:RadioButtonList>
            </td>                          
        </tr>
        <tr >
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <uc5:uctextbox id="tbReason" runat="server" enableviewstate="true" maxlength="30" textmode="MultiLine" width="300"></uc5:uctextbox>
            </td>
        </tr>
        <tr>
            <td style="background-image:url(../../images/tb3.gif)" colspan="2" align="center" >公差明細</td>
        </tr>
        <tr>
            <td class="htmltable_Right" colspan="2">
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="公差日期">
                                    <ItemTemplate>                                        
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                 <uc2:UcDate runat="server" ID="UcDateS" Text='<%# Eval("Start_date")%>' />~
                                                <uc2:UcDate runat="server" ID="UcDateE" Text='<%# Eval("End_date")%>' />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※範例:103/01/01"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公差地點(起訖)" >
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbStart_place" runat="server" Text='<%# Eval("Start_place")%>' Width="75px" MaxLength="20" />
                                        至
                                        <asp:TextBox ID="tbEnd_place" runat="server" Text='<%# Eval("End_place")%>' Width="75px" MaxLength="20" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公差明細地點">
                                    <ItemTemplate>                                        
                                        <asp:TextBox ID="tbDetailPlace" runat="server" Text='<%# Eval("DetailPlace")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="交通工具">
                                    <ItemTemplate>                                        
                                        <asp:CheckBoxList runat="server" ID="cbxlTransport" 
                                            RepeatDirection="Horizontal" RepeatColumns="4"
                                            DataTextField="code_desc1" DataValueField="code_no">
                                        </asp:CheckBoxList>
                                        <asp:Label ID="lbTransport" runat="server" Text='<%# Eval("Transport")%>' Visible="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="搭乘高鐵或飛機之理由說明">
                                    <ItemTemplate>                                        
                                        <asp:TextBox ID="tbTransportDesc" runat="server" Text='<%# Eval("Transport_Desc")%>' TextMode="MultiLine" Rows="3" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="工作內容">
                                    <ItemTemplate>                                        
                                        <asp:TextBox ID="tbReason" runat="server" Text='<%# Eval("Reason")%>' TextMode="MultiLine" Rows="3" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="gv_cbInsert" runat="server" Text="插入" OnClick="gv_cbInsert_Click" />
                                        <asp:Button ID="gv_cbRemove" runat="server" OnClick="gv_cbRemove_Click" Text="刪除" />
                                    </ItemTemplate>
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <RowStyle CssClass="Row" />
                        </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                附件</td>
            <td class="htmltable_Right">
                <uc6:UcAttachment runat="server" ID="UcAttachment" />                 
            </td>
        </tr>                                                
        <tr>
           <td colspan="2" class="htmltable_Bottom" >
               <asp:Button ID="cbSubmit" runat="server" Text="送出申請"/>
               <input id="cbReset" onclick="clearForm(this.form)" type="button" value="重填" />
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" Visible="false" />
           </td>
        </tr>                          
    </table>
</asp:Content>