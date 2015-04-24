<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3108_02.aspx.vb" Inherits="SYS3108_02" ValidateRequest="false"  %>

<%@ Register src="~/UControl/SYS/UcTitleDialog.ascx" tagname="UcTitleDialog" tagprefix="uc4" %>
<%@ Register src="~/UControl/SYS/UcUserDialog.ascx" tagname="UcUserDialog" tagprefix="uc3" %>
<%@ Register Src="~/UControl/SYS/UcRoleDialog.ascx" TagName="UcRoleDialog" TagPrefix="uc5" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td colspan="2" class="htmltable_Title">
                新增流程
            </td>
        </tr>
        <tr>
            <td colspan="2" class="htmltable_Title2">
                步驟一：設定批核關卡
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td valign="top" style="width:45%">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <fieldset>
                    <legend>主流程</legend>                    

                    <fieldset>
                        <legend>請選擇單位內批核關卡</legend>      
                        <asp:ListBox ID="lbxUnitInOutpost" runat="server" Height="120px" SelectionMode="Multiple"
                            width="100%" DataTextField="Code_desc1" DataValueField="Code_no"></asp:ListBox>                     
                    </fieldset>

                    <fieldset>
                        <legend>主管別關卡</legend>      
                        <asp:ListBox ID="lbxBossLevel" runat="server" Height="70px" SelectionMode="Multiple"
                            width="100%" DataTextField="Code_desc1" DataValueField="Code_no"></asp:ListBox>                     
                    </fieldset>
                    
                    <fieldset>
                        <legend>指定職稱</legend>                        
                        <uc4:UcTitleDialog ID="UcTitleDialog" runat="server" />                        
                    </fieldset>
                    
                    <fieldset>
                        <legend>指定人員</legend>                       
                        <uc3:UcUserDialog ID="UcUserDialog" runat="server" />                       
                    </fieldset>
                    
                    <fieldset>
                        <legend>指定角色</legend>                       
                        <uc5:UcRoleDialog runat="server" ID="UcRoleDialog" />
                    </fieldset>
                                
                </fieldset>
                <br />
                             
                <fieldset>
                    <legend>會辦流程</legend>                       
                                            
                    <fieldset>
                        <legend>指定職稱</legend>                        
                        <uc4:UcTitleDialog ID="UcTitleDialog1" runat="server" />                        
                    </fieldset>
                    
                    <fieldset>
                        <legend>指定人員</legend>                       
                        <uc3:UcUserDialog ID="UcUserDialog1" runat="server" />                       
                    </fieldset>
                    
                    <fieldset>
                        <legend>指定角色</legend>                       
                        <uc5:UcRoleDialog ID="UcRoleDialog1" runat="server" />
                    </fieldset>

                </fieldset>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width:10%" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="cbRight" runat="server" Text="選擇>" Width="90px" OnClick="cbRight_Click" /><br />
                        <asp:Button ID="cbLeft" runat="server" Text="<移除" Width="90px" OnClick="cbLeft_Click"/><br />
                        <asp:Button ID="cbLeftALL" runat="server" Text="<全部移除" Width="90px" OnClick="cbLeftALL_Click"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width:45%" valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <legend>已選擇的批核關卡</legend>
                        <div style="float:left; width:80%; vertical-align:middle;">
                            <asp:ListBox ID="lbxFlowOutpost" runat="server" Height="360px" SelectionMode="Multiple"
                            width="100%" DataTextField="text" DataValueField="value"></asp:ListBox>                            
                        </div>
                        <div style="float:right; width:20%; vertical-align:middle; margin-top:150px;">
                            <asp:Button ID="cbUp" runat="server" Text="往上" OnClick="cbUp_Click" />
                            <asp:Button ID="cbDown" runat="server" Text="往下" OnClick="cbDown_Click" />
                        </div>    
                        <asp:HiddenField ID="hfjoinoutpostid" runat="server" />
                    </fieldset>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="height: 30px">
                <asp:Button ID="cbCancel" runat="server"
                    Text="取消" UseSubmitBehavior="False" /><asp:Button ID="cbConfirm" runat="server" OnClick="cbConfirm_Click" 
                    Text="確認" UseSubmitBehavior="False" Visible="false" /><asp:Button ID="cbNextStep" runat="server" 
                    Text="下一步" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
</asp:Content>

