<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3102_04.aspx.vb" Inherits="FSC3102_04" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">                
        <tr>
            <td colspan="4" class="htmltable_Title">
                預設代理人資料維護-修改</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                單位
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                人員姓名
            </td>
            <td class="htmltable_Right" style="width:250px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlName" runat="server"
                        DataTextField="User_name" DataValueField="id_Card">
                        </asp:DropDownList>    
                            </ContentTemplate>
                </asp:UpdatePanel>            
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                預設代理</td>
            <td class="htmltable_Right">
                <asp:CheckBox ID="cbxDeputy_flag" runat="server" Text="預設職務代理人" AutoPostBack="true" /></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                順序</td>
            <td class="htmltable_Right">
                <%--<asp:TextBox ID="txtDeputSeq" runat="server" Width="30px" AutoPostBack="true" OnTextChanged="txtDeputSeq_TextChanged"></asp:TextBox>--%>
                <asp:Label ID="lbDeputSeq" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="htmltable_Bottom">
                <asp:Button ID="btnModify" runat="server" Text="確定" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" />
            </td>
        </tr>
    </table>

</asp:Content>

