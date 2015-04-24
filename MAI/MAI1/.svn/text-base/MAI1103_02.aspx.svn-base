<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI1103_02.aspx.vb" Inherits="MAI_MAI1_MAI1103_02" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div_Approve_Query" runat="server">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title" colspan="4">軟硬體報修基本資料
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left"><span style="color: red">*</span>  報修人聯絡分機
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone_nos" runat="server"></asp:TextBox>
                        </td>
                        <td class="htmltable_Left">報修人
                        </td>
                        <td>
                            <asp:Label ID="lblUserInfo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left"><span style="color: red">*</span>報修類別
                        </td>
                        <td>
                            <uc1:ucSaCode ID="ucMtClass_type" runat="server" Code_sys="020" ControlType="DropDownList" ShowType="true" ReturnEvent="true" OnCodeChanged="ucMtClass_type_CodeChanged" />
                            <uc1:ucSaCode ID="ucMtItem_type" runat="server" Code_sys="020" ControlType="DropDownList"  ReturnEvent="true" OnCodeChanged="ucMtItem_type_CodeChanged" /> 
                        </td>
                        <td class="htmltable_Left"><span style="color: red">*</span>服務對象
                        </td>
                        <td></td>
                    </tr>

                    <tr>
                        <td class="htmltable_Left"><span style="color: red">*</span>作業類別
                        </td>
                        <td colspan="3">
                            <uc1:ucSaCode ID="ucTask_type" runat="server" Code_sys="019" Code_type="001" ControlType="DropDownList" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">服務類型
                        </td>
                        <td>
                            <uc1:ucSaCode ID="ucServApply_type" runat="server" Code_sys="019" Code_type="002" ControlType="DropDownList" />
                        </td>
                        <td class="htmltable_Left">希望完成日
                        </td>
                        <td>
                            <uc1:UcDate runat="server" ID="uc_SfExpect_date" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">問題描述(以400字為限)
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtProblem_desc" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">上傳檔案1
                        </td>
                        <td colspan="3">
                            <asp:FileUpload ID="fuAttachment1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">上傳檔案2
                        </td>
                        <td colspan="3">
                            <asp:FileUpload ID="fuAttachment2" runat="server" />
                        </td>
                    </tr>
                </table>

                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title" colspan="4">處理回覆及驗收</td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">報修單號</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSwMaintain_code" runat="server" Text="102100001" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">處理人員</td>
                        <td style="width: 326px">
                            <asp:DropDownList ID="ddlMaintainer_name" runat="server" AutoPostBack="false">
                            </asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" style="width: 150px">處理人員聯絡分機</td>
                        <td style="width: 326px">
                            <asp:TextBox ID="txtMaintainerPhone_nos" runat="server" Width="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">問題分析</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtMtStatus_desc" runat="server" Rows="3" TextMode="MultiLine" Width="700" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">處理情形</td>
                        <td style="width: 326px" colspan="3">
                            <uc1:ucSaCode runat="server" ID="ucMtStatus_type" ControlType="DropDownList" Code_sys="019" Code_type="003" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">預定完成日</td>
                        <td style="width: 326px">
                            <uc1:UcDate runat="server" ID="ucForecast_date" />
                        </td>
                        <td class="htmltable_Left" style="width: 120px">處理時數</td>
                        <td style="width: 326px">
                            <asp:TextBox ID="TextBox3" runat="server" Style="text-align: center" Width="30px">4</asp:TextBox>小時                        
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">服務類型</td>
                        <td>
                           <uc1:ucSaCode runat="server" ID="ucServConfirm_type" ControlType="DropDownList" Code_sys="019" Code_type="004"  />
                        </td>
                        <td class="htmltable_Left">財產編號</td>
                        <td>
                            <asp:TextBox ID="txtProperty_id" runat="server" Style="text-align: center" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">上傳檔案</td>
                        <td>
                            <asp:FileUpload ID="fuReqAttachment" runat="server" />
                        </td>
                        <td class="htmltable_Left">處理型態</td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">回覆日期</td>
                        <td style="width: 326px">
                            <asp:Label ID="lblResponseTime" runat="server" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="cbExceed3Month_type" runat="server" Text="變更作業時程超過3個月" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                            <asp:Button ID="DoneBtn" runat="server" Text="送出資料" /> 
                            <asp:Button ID="ClrBtn" runat="server" Text="放棄修改" />
                            <asp:Button ID="ReSendBtn" runat="server" Text="重複報修" /> 
                        </td>
                    </tr>

                </table>

            </div>

            <div id="divConfirm" runat="server" visible="false">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Left">系統經辦人確認</td>
                        <td style="width: 326px" colspan="3">
                            <uc1:ucSaCode runat="server" ID="ucManagerCheck_type" ControlType="RadioButtonList"  Code_sys="019" Code_type="009" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">主管審核</td>
                        <td style="width: 326px" colspan="3">
                            <uc1:ucSaCode runat="server" ID="ucChiefCheck_type" ControlType="RadioButtonList"  Code_sys="019" Code_type="010" />
                        </td>
                    </tr>
                </table>
            </div>


            <div id="div_btn" runat="server" style="display: none;">
                <asp:Label ID="Message1" runat="server"></asp:Label>
                <asp:Button ID="Button_reload" runat="server" Text="Button" />
                <asp:Button ID="Button_do_delete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('確定刪除整批資料嗎? 刪除後資料將無法回復!');" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

