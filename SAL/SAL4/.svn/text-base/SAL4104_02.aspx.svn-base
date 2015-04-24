<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL4104_02.aspx.vb" Inherits="SAL4104_02" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc1" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc2" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcROCYear.ascx" tagname="UcROCYear" tagprefix="uc4" %>
<%@ Register src="~/UControl/UcROCYearMonth.ascx" tagname="UcROCYearMonth" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">職等年功俸點對照表-新增
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 110px; height: 19px;"><span style="color: Red">*</span>官階</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlJob_type" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" style="width: 110px; height: 19px;"><span style="color: Red">*</span>職等</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlLevel_type" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>俸點</td>
                        <td class="TdHeightLight">
                           <asp:TextBox ID="txtL3" runat="server" MaxLength="4" Width="50px" ></asp:TextBox>
                           <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="※填寫範例(數字):0000"></asp:Label>
                        </td>
                                       <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>年功俸</td>
                        <td class="TdHeightLight">
                           <asp:TextBox ID="txtL1" runat="server" MaxLength="3" Width="50px" ></asp:TextBox>
                           <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※填寫範例(數字):000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnOK" runat="server" Text="確定" />
                            <asp:Button ID="btnCancel" runat="server" Text="取消" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
     </table>
</asp:Content>
