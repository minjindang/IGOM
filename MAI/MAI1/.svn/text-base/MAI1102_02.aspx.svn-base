<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI1102_02.aspx.vb" Inherits="MAI_MAI1_MAI1102_02" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">軟硬體報修登記
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
                       <uc1:ucSaCode ID="ucMtClass_type" runat="server" Code_sys="020" ControlType="DropDownList" ShowType="true" ReturnEvent="true" OnCodeChanged="CodeChanged" />
                    <uc1:ucSaCode ID="ucMtItem_type" runat="server" Code_sys="020" ControlType="DropDownList"  />
                </td>
                <td class="htmltable_Left"><span style="color: red">*</span>服務對象
                </td>
                <td>
                     
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
        <div align="center">
            <asp:Button ID="DoneBtn" runat="server" Text="送出申請" />
            <asp:Button ID="ClrBtn" runat="server" Text="清空重填" />
        </div>
    </div>
</asp:Content>

