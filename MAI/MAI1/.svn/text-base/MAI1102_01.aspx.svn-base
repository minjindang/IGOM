<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI1102_01.aspx.vb" Inherits="MAT_MAT1_MAI1102_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">軟硬體報修-333客服
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修人聯絡分機
                </td>
                <td >
                    <asp:TextBox ID="txtPhone_nos" runat="server"></asp:TextBox>
                </td> 
                <td class="htmltable_Left">報修人
                </td>
                <td >
                    <asp:Label ID="lblUserInfo" runat="server" Text="Label"></asp:Label>
                </td> 
            </tr>
             <tr>
                <td class="htmltable_Left">報修系統
                </td>
                <td colspan="3">
                     <uc1:ucSaCode runat="server" ID="ucMtSys_type" Code_sys="019" Code_type="007" ControlType="RadioButtonList"  />
                </td>  
            </tr>
             <tr>
                <td class="htmltable_Left">備註
                </td>
                <td colspan="3">
                     點選確認後，將由系統客服人員以電話協助您處理問題，如您要自行輸入報修內容，請點選<asp:LinkButton ID="lbMaintain" runat="server">報修登記</asp:LinkButton>
                </td>  
            </tr>
        </table>
        <div align="center"> 
            <asp:Button ID="DoneBtn" runat="server" Text="確認" /> 
        </div> 
    </div>
</asp:Content>

