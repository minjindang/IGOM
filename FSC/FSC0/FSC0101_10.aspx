<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_10.aspx.cs" Inherits="FSC0101_10" %>

<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagPrefix="uc1" TagName="UcTextBox" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDateTime.ascx" TagPrefix="uc1" TagName="UcDateTime" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<%@ Register Src="~/UControl/MAI/UcAttachment.ascx" TagPrefix="uc2" TagName="UcAttachment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style type="text/css">
        .modalBackground
    {
        background-color:Gray;
        filter:alpha(opacity=50);
        opacity:0.5;
    }
    </style>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">報修申請基本資料
            </td>
        </tr>
        <tr>            
            <td class="htmltable_Left">表單編號
            </td>
            <td class="htmltable_Right" style="width:300px;">
                <asp:Label ID="lbFlowId" runat="server" Text=""></asp:Label>  
                <asp:HiddenField ID="hfMainId" runat="server" />                  
            </td>  
            <td class="htmltable_Left">原表單編號
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbOldFlowId" runat="server" Text=""></asp:Label>                    
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請人姓名
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
            </td> 
            <td class="htmltable_Left">申請人分機
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbUserExt" runat="server"></asp:Label>
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left">填寫人姓名
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWriter" runat="server" Text=""></asp:Label>
            </td> 
            <td class="htmltable_Left">填寫人分機
            </td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWriterExt" runat="server"></asp:Label>
            </td> 
        </tr>
            <tr>
            <td class="htmltable_Left">申請類別
            </td>
            <td colspan="3">
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
            <td colspan="3">                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMaintain_type" runat="server"
                        DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>                 
            </td>  
        </tr>
        <tr>
            <td class="htmltable_Left">問題描述
            </td>
            <td colspan="3">
                <uc1:UcTextBox runat="server" ID="UcProblem_desc" MaxLength="400" TextMode="MultiLine"  Width="550"/>
            </td>  
        </tr>
         <tr>
            <td class="htmltable_Left">上傳檔案
            </td>
            <td colspan="3">
                <uc1:UcAttachment runat="server" ID="UcAttachment" />
            </td>  
        </tr>
    </table>

    
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
                                    <asp:Button ID="gvcbNetInsert" runat="server" Text="插入" OnClick="gvcbNetInsert_Click"/>
                                    <asp:Button ID="gvcbNetDelete" runat="server" Text="刪除" OnClick="gvcbNetDelete_Click"/>
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
                                    <asp:TextBox ID="gvtbFirewall_port" runat="server" Text='<%# Eval("Firewall_port") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbNetInsert" runat="server" Text="插入" OnClick="gvcbNetInsert_Click"/>
                                    <asp:Button ID="gvcbNetDelete" runat="server" Text="刪除" OnClick="gvcbNetDelete_Click"/>
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
                                    <asp:CheckBox ID="gvtbIntra_flag" runat="server" Checked='<%# Eval("Intra_flag").ToString() == "1" ? true : false %>' ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="對外<br/>服務">
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvtbOuter_flag" runat="server" Checked='<%# Eval("Outer_flag").ToString() == "1" ? true : false %>'></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="gvcbServInsert" runat="server" Text="插入" OnClick="gvcbServInsert_Click"/>
                                    <asp:Button ID="gvcbServDelete" runat="server" Text="刪除" OnClick="gvcbServDelete_Click"/>
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
                                    <asp:Button ID="gvcbAccInsert" runat="server" Text="插入" OnClick="gvcbAccInsert_Click"/>
                                    <asp:Button ID="gvcbAccDelete" runat="server" Text="刪除" OnClick="gvcbAccDelete_Click"/>
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
                    <asp:TextBox ID="tbApplication_name" runat="server" Width="300"></asp:TextBox>
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
                    <uc1:UcTextBox runat="server" ID="UcEquipment_desc" TextMode="MultiLine" MaxLength="400"  Width="550"/>
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

    
    <table class="tableStyle99" width="100%" id="tbHandleEroom" runat="server" visible="false">
        <tr>
            <td class="htmltable_Title" colspan="4">處理說明
            </td>
        </tr>            
        <tr>
            <td class="htmltable_Left">實際進入機房時間
            </td>
            <td class="htmltable_Right">
                <uc1:UcDateTime runat="server" ID="UcEnterRealDateTime" />
            </td> 
            <td class="htmltable_Left">實際進入機房時間填寫人員
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbEnter_signname" runat="server"></asp:TextBox>
            </td> 
        </tr>     
        <tr>
            <td class="htmltable_Left">實際離開機房時間
            </td>
            <td class="htmltable_Right">
                <uc1:UcDateTime runat="server" ID="UcLeftRealDateTime" />
            </td> 
            <td class="htmltable_Left">實際離開機房時間填寫人員
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbLeft_signname" runat="server"></asp:TextBox>
            </td> 
        </tr>
    </table>

    <table class="tableStyle99" width="100%" id="tbHandle" runat="server">
        <tr>
            <td class="htmltable_Title" colspan="6">問題確認
            </td>
        </tr>        
        <tr>
            <td class="htmltable_Left">問題確認人員
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlConfirm_idcard" runat="server" DataTextField="User_name" DataValueField="Id_card"></asp:DropDownList>
                <asp:TextBox ID="tbConfirm_name" runat="server"></asp:TextBox>
                <asp:HiddenField ID="hfHandleId" runat="server" />                
            </td> 
            <td class="htmltable_Left" style="width:140px;">問題確認人員分機
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbConfirm_ext" runat="server" Width="100"></asp:TextBox>
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left">問題分析
            </td>
            <td colspan="5">
                <uc1:UcTextBox runat="server" ID="UcProblem_analyze" MaxLength="400" TextMode="MultiLine"  Width="550"/>
            </td>  
        </tr> 
        <tr>
            <td class="htmltable_Left">預定完成日
            </td>
            <td colspan="5">
                <uc1:UcDate runat="server" ID="UcPredict_date" />
            </td>  
        </tr> 
        <tr>
            <td class="htmltable_Title" colspan="6">處理及回覆
            </td>
        </tr>           
        <tr>
            <td class="htmltable_Left">處理人員
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlHandle_idcard" runat="server" DataTextField="User_name" DataValueField="Id_card"></asp:DropDownList>
                <asp:TextBox ID="tbHandle_name" runat="server"></asp:TextBox>
            </td> 
            <td class="htmltable_Left">處理人員分機
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbHandle_ext" runat="server" Width="100"></asp:TextBox>
            </td> 
        </tr>         
        <tr id="trClass1" runat="server" visible="false">
            <td class="htmltable_Left">作業類別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlOperate_type" runat="server"
                        DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td> 
            <td class="htmltable_Left">服務類型
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlService_type" runat="server"
                        DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>                
            </td> 
        </tr>    
        <tr>
            <td class="htmltable_Left">處理狀態
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlStatus_type" runat="server"
                        DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td> 
            <td class="htmltable_Left">處理型態
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlHandle_type" runat="server"
                        DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>                
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left">處理回覆
            </td>
            <td colspan="5">
                <uc1:UcTextBox runat="server" ID="UcHandle_desc" MaxLength="400" TextMode="MultiLine" Width="550" />
            </td>  
        </tr>   
        <tr>
            <td class="htmltable_Left">開始處理日
            </td>
            <td class="htmltable_Right">
                <uc1:UcDateTime runat="server" ID="UcDateTimeS" />
            </td> 
            <td class="htmltable_Left">完成處理日
            </td>
            <td class="htmltable_Right">
                <uc1:UcDateTime runat="server" ID="UcDateTimeE" />
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left">處理時數
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbHandle_hours" runat="server"></asp:TextBox>
            </td> 
            <td class="htmltable_Left">回覆日期
            </td>
            <td class="htmltable_Right">                
                <uc1:UcDate runat="server" ID="UcReply_date" />
            </td> 
        </tr>
         <tr>
            <td class="htmltable_Left">上傳檔案
            </td>
            <td colspan="5">
                <uc2:UcAttachment runat="server" ID="UcMaiAttachment" />
            </td>  
        </tr>
         <tr>
            <td class="htmltable_Left">維運登錄
            </td>
            <td colspan="5">
                <asp:DropDownList ID="ddlMaintain_code" runat="server"></asp:DropDownList>
            </td>  
        </tr>
    </table>
    
    <table class="tableStyle99" width="100%" id="tbStatus" runat="server" visible="false">
        <tr>
            <td class="htmltable_Title" colspan="2">審核意見
            </td>
        </tr>  
         <tr>
            <td class="htmltable_Left">批核結果
            </td>
            <td>
                <%--<asp:CheckBoxList ID="cblCase_status" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" >
                    <asp:ListItem Value="1" Text="同意"></asp:ListItem>
                    <asp:ListItem Value="2" Text="不同意(退件)"></asp:ListItem>
                </asp:CheckBoxList>--%>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" >
                    <ContentTemplate>
                        <asp:CheckBox ID="cbCase_status_Y" runat="server" Text="確認/同意" AutoPostBack="true" OnCheckedChanged="cbCase_status_Y_CheckedChanged" />
                        <asp:Label ID="lbTip" runat="server" Visible="false" ForeColor="Red" Text="(若要結案請選擇處理狀態為「處理完成」)"></asp:Label>
                        <asp:CheckBox ID="cbCase_status_N" runat="server" Text="退件/不同意" AutoPostBack="true" OnCheckedChanged="cbCase_status_N_CheckedChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>  
        </tr>
         <tr>
            <td class="htmltable_Left">批核說明
            </td>
            <td>
                <uc1:UcTextBox runat="server" ID="UcComment" MaxLength="400" TextMode="MultiLine"  Width="550"/>
            </td>  
        </tr>
    </table>
    <table class="tableStyle99" width="100%" >
         <tr>
            <td class="htmltable_Left">批核記錄
            </td>
            <td>
                <asp:Label ID="lbFlowDetail" runat="server"></asp:Label>
            </td>  
        </tr>
    </table>
    <div align="center"> 
        <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" Visible="false"/> 
        <asp:Button ID="cbChangeForm" runat="server" Text="轉單" visible="false" />
        <asp:Button ID="cbDividForm" runat="server" Text="拆單" visible="false" />
        <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" /> 
    </div>

    <asp:HiddenField ID="hfMaintainerType" runat="server" />

    <asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbChangeForm"
        PopupControlID="Panel1"
        BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel runat="server" ID="Panel1">
        <div>
            <table id="table" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
                <tr>
                    <td class="htmltable_Title2" colspan="2">轉單</td>
                </tr>
                <tr>
                    <td class="htmltable_Left">新申請類別
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                            <asp:RadioButtonList ID="rblChangeMaintain_kind" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblChangeMaintain_kind_SelectedIndexChanged"
                            RepeatLayout="Flow" AutoPostBack="true" DataTextField="code_desc1" DataValueField="code_no"></asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>                
                    </td>  
                </tr>
                <tr>
                    <td class="htmltable_Left">新申請項目
                    </td>
                    <td>                
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChangeMaintain_type" runat="server"
                                DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>                 
                    </td>  
                </tr>
                <tr>
                    <td colspan='2' class="htmltable_Bottom">
                        <asp:Button ID="cbChangConfirm" runat="server" Text="確定" OnClick="cbChangConfirm_Click"/>
                        <asp:Button ID="cbChangeCancel" runat="server" Text="取消" OnClick="cbChangeCancel_Click"/>
                    </td>
                </tr>
            </table>   
        </div>
    </asp:Panel>

    
    <asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender1" runat="server" TargetControlID="cbDividForm"
        PopupControlID="Panel2"
        BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel runat="server" ID="Panel2">
        <div>
            <table id="table1" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
                <tr>
                    <td class="htmltable_Title2" colspan="2">拆單</td>
                </tr>
                <tr>
                    <td class="htmltable_Left">新申請類別
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                            <asp:RadioButtonList ID="rblDividMaintain_kind" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblDividMaintain_kind_SelectedIndexChanged"
                            RepeatLayout="Flow" AutoPostBack="true" DataTextField="code_desc1" DataValueField="code_no"></asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>                
                    </td>  
                </tr>
                <tr>
                    <td class="htmltable_Left">新申請項目
                    </td>
                    <td>                
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDividMaintain_type" runat="server"
                                DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>                 
                    </td>  
                </tr>
                <tr>
                    <td colspan='2' class="htmltable_Bottom">
                        <asp:Button ID="cbDividConfirm" runat="server" Text="確定" OnClick="cbDividConfirm_Click"/>
                        <asp:Button ID="cbDividCancel" runat="server" Text="取消" OnClick="cbDividCancel_Click"/>
                    </td>
                </tr>
            </table>   

            
        </div>
    </asp:Panel>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>

