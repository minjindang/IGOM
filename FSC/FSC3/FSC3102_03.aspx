<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3102_03.aspx.vb" Inherits="FSC3102_03" %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">                
        <tr>
            <td colspan="4" class="htmltable_Title">
                預設代理人資料維護-新增</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                單位
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDDLAuthorityDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                人員姓名
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDDLAuthorityMember runat="server" ID="ddlName" />
            </td>
        </tr>    
        <tr>
            <td class="htmltable_Left" style="width:100px">
                代理人單位
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDeputy_Depart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                代理人姓名
            </td>
            <td class="htmltable_Right" style="width:250px">
                <asp:UpdatePanel id="UpdatePanel1" runat="server" >
                    <ContentTemplate>
                         <asp:DropDownList ID="ddlDeputy_Name" runat="server" DataTextField="Full_name" DataValueField="id_card" />
                    </ContentTemplate>
                </asp:UpdatePanel>       
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                預設代理</td>
            <td class="htmltable_Right">
                <asp:CheckBox ID="cbxDeputy_flag" runat="server" Text="預設職務代理人" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                順序</td>
            <td class="htmltable_Right">
                <%--<asp:TextBox ID="txtDeputSeq" runat="server" Width="30px" AutoPostBack="true" OnTextChanged="txtDeputSeq_TextChanged" ></asp:TextBox>--%>
                <asp:Label ID="lbtDeputSeq" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="htmltable_Bottom">
                <asp:Button ID="btnInsert" runat="server" Text="新增代理人" /> &nbsp;<asp:Button ID="btnBack" runat="server" Text="上一頁" />
            </td>
        </tr>
    </table>

</asp:Content>

