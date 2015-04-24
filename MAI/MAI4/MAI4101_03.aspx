<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MAI4101_03.aspx.cs" Inherits="MAI_MAI4_MAI4101_03" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">維修人員維護
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>維修人員單位/姓名
            </td>
            <td colspan="3">
                <uc1:UcDDLDepart runat="server" ID="ucDept" OnSelectedIndexChanged="ucDept_SelectedIndexChanged" />
                <uc1:UcDDLMember runat="server" ID="ucMember" /> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>維修人員聯絡電話(分機) 
            </td>
           <td colspan="3">
                <asp:TextBox ID="txtMaintainerPhone_nos" runat="server" Enabled="false" ></asp:TextBox>
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>負責維修項目
            </td>
            <td colspan="3">
                  <uc1:ucSaCode runat="server" ID="ucMaintain_type" ControlType="DropDownList"  Code_sys="019" Code_type="011" OnCodeChanged="ucMaintain_type_CodeChanged"  ReturnEvent="true"  /> 
                  <asp:CheckBoxList runat="server" ID="cblMtItem_type" RepeatDirection="Horizontal" RepeatColumns="8"></asp:CheckBoxList>
            </td>
        </tr> 
    </table>
    <div align="center"> 
        <asp:Button ID="DoneBtn" runat="server" Text="確認" OnClick="DoneBtn_Click" />
        <asp:Button ID="ClrBtn" runat="server" Text="放棄修改" OnClick="ResetBtn_Click" /> 
    </div>

</asp:Content>

