<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MAI1101_01.aspx.cs" Inherits="MAI1101_01" %>

<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagPrefix="uc1" TagName="UcTextBox" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDateTime.ascx" TagPrefix="uc1" TagName="UcDateTime" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="6">報修申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請人分機
            </td>
            <td class="htmltable_Right" style="width:150px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPhone_ext" runat="server" AutoPostBack="true" OnTextChanged="txtPhone_ext_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td> 
            <td class="htmltable_Left">申請人姓名
            </td>
            <td class="htmltable_Right" style="width:150px;">                
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblUserInfo" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hfIdCard" runat="server" />
                        <asp:HiddenField ID="hfDepartid" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td> 
            <td class="htmltable_Left">表單編號
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbFlowId" runat="server" Text=""></asp:Label>                    
            </td>
        </tr>
            <tr>
            <td class="htmltable_Left">申請類別
            </td>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:RadioButtonList ID="rblMaintain_kind" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblMaintain_kind_SelectedIndexChanged" 
                    RepeatLayout="Flow" AutoPostBack="true" DataTextField="code_desc1" DataValueField="code_no"></asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>  
        </tr>
            <tr>
            <td class="htmltable_Left">申請項目
            </td>
            <td colspan="5">                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMaintain_type" runat="server" AutoPostBack="true"
                        DataTextField="code_desc1" DataValueField="code_no" OnSelectedIndexChanged="ddlMaintain_type_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>                 
            </td>  
        </tr>
            <tr>
            <td class="htmltable_Left">問題描述
            </td>
            <td colspan="5">
                <uc1:UcTextBox runat="server" ID="UcProblem_desc" MaxLength="400" TextMode="MultiLine" Width="400" />
            </td>  
        </tr>
            <tr>
            <td class="htmltable_Left">上傳檔案
            </td>
            <td colspan="5">
                <uc1:UcAttachment runat="server" ID="UcAttachment" />
            </td>  
        </tr>
    </table>

    <asp:HiddenField ID="hfMainId" runat="server" />
        
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>

         <table class="tableStyle99" width="100%" id="tbNet" runat="server" visible="false">
            <tr>
                <td class="htmltable_Title" colspan="2">設備上網申請資料
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">使用期間</td>
                <td>
                    <uc1:UcDate runat="server" ID="UcNetUse_sdate" />
                    ~
                    <uc1:UcDate runat="server" ID="UcNetUse_edate" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvNet" runat="server" CssClass="Grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="類型">
                                <ItemTemplate>                                
                                    <asp:RadioButtonList ID="rblApply_type" runat="server" SelectedValue='<%# Eval("Apply_type") %>' RepeatLayout="Flow">
                                        <asp:ListItem Text="新申請" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="變更" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="註銷" Value="D"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="使用單位">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbUser_unit" runat="server" Text='<%# Eval("User_unit") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="使用者姓名">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbUser_name" runat="server" Text='<%# Eval("User_name") %>' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="聯絡電話">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbUser_phone" runat="server" Text='<%# Eval("User_phone") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="網卡MAC Address">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbMac_addr" runat="server" Text='<%# Eval("Mac_addr") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="原先IP或MAC">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbOld_macaddr" runat="server" Text='<%# Eval("Old_macaddr") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbNetInsert" runat="server" Text="插入" OnClick="gvcbNetInsert_Click" />
                                    <asp:Button ID="gvcbNetDelete" runat="server" Text="刪除" OnClick="gvcbNetDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <table class="tableStyle99" width="100%" id="tbDNS" runat="server" visible="false">
            <tr>
                <td class="htmltable_Title" colspan="2">DNS或防火牆資料
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">使用期間</td>
                <td>
                    <uc1:UcDate runat="server" ID="UcDnsUse_sdate" />
                    ~
                    <uc1:UcDate runat="server" ID="UcDnsUse_edate" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDNS" runat="server" CssClass="Grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="類型">
                                <ItemTemplate>                                
                                    <asp:RadioButtonList ID="rblApply_type" runat="server" SelectedValue='<%# Eval("Apply_type") %>' RepeatLayout="Flow">
                                        <asp:ListItem Text="新申請" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="變更" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="註銷" Value="D"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="伺服器/應用系統名稱">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbServer_name" runat="server" Text='<%# Eval("Server_name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IP">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbServer_ip" runat="server" Text='<%# Eval("Server_ip") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="網域名稱(網址)">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbDns_name" runat="server" Text='<%# Eval("Dns_name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="防火牆(連接埠)">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbFirewall_port" runat="server" Text='<%# Eval("Firewall_port") %>' Width="80"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbDnsInsert" runat="server" Text="插入" OnClick="gvcbDnsInsert_Click" />
                                    <asp:Button ID="gvcbDnsDelete" runat="server" Text="刪除" OnClick="gvcbDnsDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <table class="tableStyle99" width="100%" id="tbServ" runat="server" visible="false">
            <tr>
                <td class="htmltable_Title" colspan="2">主機申請
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">使用期間</td>
                <td>
                    <uc1:UcDate runat="server" ID="UcServUse_sdate" />
                    ~
                    <uc1:UcDate runat="server" ID="UcServUse_edate" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvServ" runat="server" CssClass="Grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="類型">
                                <ItemTemplate>                                
                                    <asp:RadioButtonList ID="rblApply_type" runat="server" SelectedValue='<%# Eval("Apply_type") %>' RepeatLayout="Flow">
                                        <asp:ListItem Text="新申請" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="變更" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="註銷" Value="D"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="伺服器/應用系統名稱">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbServer_name" runat="server" Text='<%# Eval("Server_name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CPU(個)">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbCpu_nos" runat="server" Text='<%# Eval("Cpu_nos") %>' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="記憶體(GB)">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbRam_size" runat="server" Text='<%# Eval("Ram_size") %>' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="資料碟(GB)">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbHd_size" runat="server" Text='<%# Eval("Hd_size") %>' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WINDOWS<br/>版本">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbWindows_ver" runat="server" Text='<%# Eval("Windows_ver") %>' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他版本<br/>(須自行安裝)">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbOther_ver" runat="server" Text='<%# Eval("Other_ver") %>' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="對內<br/>服務">
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvtbIntra_flag" runat="server" ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="對外<br/>服務">
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvtbOuter_flag" runat="server" ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbServInsert" runat="server" Text="插入" OnClick="gvcbServInsert_Click" />
                                    <asp:Button ID="gvcbServDelete" runat="server" Text="刪除" OnClick="gvcbServDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    
        <table class="tableStyle99" width="100%" id="tbAcc" runat="server" visible="false">
            <tr>
                <td class="htmltable_Title" colspan="2">帳號申請
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">使用期間</td>
                <td>
                    <uc1:UcDate runat="server" ID="UcAccUse_sdate" />
                    ~
                    <uc1:UcDate runat="server" ID="UcAccUse_edate" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvAcc" runat="server" CssClass="Grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="類型">
                                <ItemTemplate>                                
                                    <asp:RadioButtonList ID="rblApply_type" runat="server" SelectedValue='<%# Eval("Apply_type") %>' RepeatLayout="Flow">
                                        <asp:ListItem Text="新申請" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="變更" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="註銷" Value="D"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbUser_name" runat="server" Text='<%# Eval("User_name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="伺服器/電子郵件">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbAccount" runat="server" Text='<%# Eval("Account") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbAccInsert" runat="server" Text="插入" OnClick="gvcbAccInsert_Click" />
                                    <asp:Button ID="gvcbAccDelete" runat="server" Text="刪除" OnClick="gvcbAccDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    
        <table class="tableStyle99" width="100%" id="tbOth" runat="server" visible="false">
            <tr>
                <td class="htmltable_Title" colspan="2">其他服務申請資料
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">使用期間</td>
                <td>
                    <uc1:UcDate runat="server" ID="UcOthUse_sdate" />
                    ~
                    <uc1:UcDate runat="server" ID="UcOthUse_edate" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvOth" runat="server" CssClass="Grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="類型">
                                <ItemTemplate>                                
                                    <asp:RadioButtonList ID="rblApply_type" runat="server" SelectedValue='<%# Eval("Apply_type") %>' RepeatLayout="Flow">
                                        <asp:ListItem Text="新申請" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="變更" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="註銷" Value="D"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbUser_name" runat="server" Text='<%# Eval("User_name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbMemo" runat="server" Text='<%# Eval("Memo") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbOthInsert" runat="server" Text="插入" OnClick="gvcbOthInsert_Click" />
                                    <asp:Button ID="gvcbOthDelete" runat="server" Text="刪除" OnClick="gvcbOthDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>


        <table class="tableStyle99" width="100%" id="tbEroom" runat="server" visible="false">
            <tr>
                <td class="htmltable_Title" colspan="4">進出電腦機房申請
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">預計進入時間</td>
                <td class="htmltable_Right">
                    <uc1:UcDateTime runat="server" ID="UcEnterDateTime" />
                </td>
                <td class="htmltable_Left">申請主機名稱</td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="tbServer_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請系統名稱</td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="tbApplication_name" runat="server"></asp:TextBox>
                </td>
                <td class="htmltable_Left">臨時卡借用(進出機房終端室)
                </td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="rblCard_type" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="無需借用" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="臨時卡" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    卡號<asp:TextBox ID="tbCard_nos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請作業說明</td>
                <td class="htmltable_Right" colspan="3">
                    <asp:RadioButtonList ID="rblDesc_flag" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="程式新增或異動(提交資安檢查表)" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="系統檢核" Value="2"></asp:ListItem>
                        <asp:ListItem Text="其它" Value="3"></asp:ListItem>
                    </asp:RadioButtonList><asp:TextBox ID="tbDescribe" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">攜入設備</td>
                <td class="htmltable_Right" colspan="3">
                    <uc1:UcTextBox runat="server" ID="UcEquipment_desc" TextMode="MultiLine" MaxLength="400" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvEroom" runat="server" CssClass="Grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="公司名稱">
                                <ItemTemplate>    
                                    <asp:TextBox ID="gvtbCompany" runat="server" Text='<%# Eval("Company") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbUser_name" runat="server" Text='<%# Eval("User_name") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="電話">
                                <ItemTemplate>
                                    <asp:TextBox ID="gvtbPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbEroomInsert" runat="server" Text="插入" OnClick="gvcbEroomInsert_Click"  />
                                    <asp:Button ID="gvcbEroomDelete" runat="server" Text="刪除" OnClick="gvcbEroomDelete_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    
    <div align="center"> 
        <asp:Button ID="cbConfirm" runat="server" Text="送出申請" OnClick="cbConfirm_Click" /> 
        <asp:Button ID="cbBack" runat="server" Text="回上頁" Visible="false" OnClick="cbBack_Click" /> 
    </div>
</asp:Content>

