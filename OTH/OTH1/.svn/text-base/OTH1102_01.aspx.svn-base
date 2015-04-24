<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="OTH1102_01.aspx.cs" Inherits="OTH_OTH1_OTH1102_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">資訊網路服務申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:red">*</span>申請類別
            </td>
            <td>
                <uc1:ucSaCode runat="server" ID="ucApply_type" Code_sys="022" Code_type="004" ControlType="RadioButtonList" ReturnEvent="true" OnCodeChanged="ucApply_type_CodeChanged" />
                <asp:TextBox ID="txtApply_type_desc" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:red">*</span>申請事由
            </td>
            <td>
                <asp:TextBox ID="txtApply_reason" runat="server" TextMode="MultiLine" Height="50px" Width="600px"></asp:TextBox>
                (如為系統，請述明系統名稱及用途)
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">使用期間
            </td>
            <td>自<uc1:UcDate runat="server" ID="ucApply_StartDate" />
                至<uc1:UcDate runat="server" ID="ucApply_EndDate" />
                止(網路開放設定區間)
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請項目</td>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 200px">新進人員帳號申請</td>
                        <td>
                            <uc1:ucSaCode runat="server" ID="ucapply_acc_req" Code_sys="022" Code_type="002" ControlType="RadioButtonList" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">新設備上網</td>
                        <td>網卡 MAC Address :
                            <asp:TextBox ID="txtnewMac_addr" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">更換設備上網</td>
                        <td>網卡 MAC Address :
                            <asp:TextBox ID="txtchgMac_addr" runat="server"></asp:TextBox>
                            原先 IP 或 MAC :
                            <asp:TextBox ID="txtoldMac_addr" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">伺服器進機房</td>
                        <td>
                            <uc1:ucSaCode runat="server" ID="ucequipRoom_type" Code_sys="022" Code_type="003" ControlType="RadioButtonList" ReturnEvent="true" OnCodeChanged="ucequipRoom_type_CodeChanged" />
                            <asp:TextBox ID="txtEquipRoom_Memo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">申請DNS</td>
                        <td>IP :
                            <asp:TextBox ID="txtdns_ip" runat="server"></asp:TextBox>
                            網域名稱(網址) :
                            <asp:TextBox ID="txtdns_host" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px">其他及行政業務資訊系統</td>
                        <td>
                            <asp:TextBox ID="txtadmin_sys" runat="server" TextMode="MultiLine" Height="50px" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">是否開放連接埠
            </td>
            <td>
                <asp:RadioButtonList ID="rblport_open" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <div id="div1" runat="server" align="center">
        <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False"
            PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
            Width="100%" EnableModelValidation="True">
            <Columns> 
                <asp:TemplateField HeaderText="單/雙向">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="rbldirection" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True">單向</asp:ListItem>
                            <asp:ListItem Value="1">雙向</asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="來源IP/網段">
                    <ItemTemplate>
                        <asp:TextBox ID="txtresource_ip" runat="server" Text='<%# Eval("resource_ip") %>' MaxLength="30"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="目的IP/網段">
                    <ItemTemplate>
                        <asp:TextBox ID="txtgoal_ip" runat="server" Text='<%# Eval("goal_ip") %>' MaxLength="30"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="連接埠及開放理由">
                    <ItemTemplate>
                        <asp:TextBox ID="txtreason" runat="server" Text='<%# Eval("reason") %>' MaxLength="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="動作">
                    <ItemTemplate>
                        <asp:Button ID="btnAdd"
                            runat="server" Text="插入" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnDelete"
                            runat="server" Text="刪除" OnClick="btnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <asp:Button ID="DonBtn" runat="server" Text="送出申請" OnClick="OkBtn_Click" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" PostBackUrl="~/OTH/OTH1/OTH1102_01.aspx" />
    </div>
</asp:Content>

