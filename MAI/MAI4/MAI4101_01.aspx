<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MAI4101_01.aspx.cs" Inherits="MAI_MAI4_MAI4101_01" %>


<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">維修人員維護-新增
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left">維修人員單位/姓名
            </td>
            <td colspan="3">
                <uc1:UcDDLDepart runat="server" ID="ucDept" OnSelectedIndexChanged="ucDept_SelectedIndexChanged" />
                <uc1:UcDDLMember runat="server" ID="ucMember" /> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">維修人員聯絡電話(分機) 
            </td>
           <td colspan="3">
                <asp:TextBox ID="txtMaintainerPhone_nos" runat="server"></asp:TextBox>
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left">負責維修項目
            </td>
            <td colspan="3">
                  <uc1:ucSaCode runat="server" ID="ucMaintain_type" ControlType="DropDownList"  Code_sys="019" Code_type="011" OnCodeChanged="ucMaintain_type_CodeChanged"  ReturnEvent="true"  /> 
                  <asp:CheckBoxList runat="server" ID="cblMtItem_type" RepeatDirection="Horizontal" RepeatColumns="8"></asp:CheckBoxList>
            </td>
        </tr> 
    </table>
          <div align="center"> 
          <asp:Button ID="AddBtn" runat="server" Text="新增" OnClick="AddBtn_Click" />
        <asp:Button ID="QryBtn" runat="server" Text="查詢" OnClick="QryBtn_Click" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click" />
    </div>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%" OnRowCommand="GridViewA_RowCommand" OnPageIndexChanging="GridViewA_PageIndexChanging">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:BoundField DataField="MtUnit_codeName" HeaderText="維修人員單位-姓名" />
                    <asp:BoundField DataField="MaintainerPhone_nos" HeaderText="維修人員聯絡電話(分機)" />
                    <asp:BoundField DataField="Maintain_type" HeaderText="維修大類" />  
                    <asp:BoundField DataField="MtItem_type" HeaderText="負責維修項目" />    
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Button ID="btn1" runat="server" Text="維護"
                                CommandArgument='<%# Eval("MaintainerPhone_nos")%>'
                                CommandName="Maintain" />
                            <asp:Button ID="btn2" CommandName="GoDelete"
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');"
                                CommandArgument='<%# Eval("MaintainerPhone_nos")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
              <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                       PNow="1" PSize="10" Visible="true" />
        </div>
    </div>

</asp:Content>

