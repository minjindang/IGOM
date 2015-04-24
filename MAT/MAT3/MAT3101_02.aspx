<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="false" CodeFile="MAT3101_02.aspx.vb" Inherits="MAT_MAT3_MAT3101_02" %>

<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc2" TagName="ucSaCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                雜項領物-新增
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                領用類別
            </td>
            <td style="width: 326px">
                雜項領物
            </td>
            <td class="htmltable_Left">
                領物日期
            </td>
            <td style="width: 326px">
                <uc2:UcDate ID="ucApply_date" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                請購單編號
            </td>
            <td style="width: 326px"> 
                <asp:Button ID="cbSelect" runat="server" Text="匯入請購單" OnClick="cbSelect_Click" />
            </td>
             <td class="htmltable_Left">雜項領物類別
            </td>
            <td style="width: 326px">
                <uc2:ucSaCode runat="server" ID="ucSaCode" Code_sys="014" Code_type="001" ControlType="DropDownList" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                領物單位別
            </td>
            <td style="width: 326px">
                 <asp:Label ID="lblDept_name" runat="server" />
            </td>
            <td class="htmltable_Left">
                領物人員
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblUser_name" runat="server" />
            </td>
        </tr> 
    </table>
    <div id="div1" runat="server">
        <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" 
            PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
            Width="100%" EnableModelValidation="True"> 
            <Columns>
                <asp:BoundField DataField="Index" HeaderText="序號" />
                <asp:TemplateField HeaderText="物料名稱">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMaterialName" runat="server" Text='<%# Bind("Material_name") %>' MaxLength="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="領用數量">
                    <ItemTemplate>
                        <asp:TextBox ID="txtOutCnt" runat="server" Text='<%# Bind("Out_cnt") %>' MaxLength="6"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnit" runat="server" Text='<%# Bind("Unit") %>' MaxLength="4"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="總價">
                    <ItemTemplate>
                        <asp:TextBox ID="txtTotalPriceAmt" runat="server" Text='<%# Bind("TotalPrice_amt") %>' MaxLength="6"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廠商">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCompanyName" runat="server" Text='<%# Bind("Company_name") %>' MaxLength="60" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用途及備註">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMemo" runat="server" Text='<%# Bind("Memo") %>' MaxLength="255"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfFlowId" runat="server" Value='<%# Bind("Flow_id")%>' />
                        <asp:HiddenField ID="hf_IsAuto" runat="server" Value='<%# Bind("IsAuto") %>' />
                        <asp:Button ID="btnAdd" runat="server" Text="插入" onclick="btnAdd_Click" />
                        <asp:Button ID="btnDelete"
                            runat="server" Text="刪除" onclick="btnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    
    </div>
    <div align="center" >
        <asp:Button ID="DonBtn" runat="server" Text="確認"  />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
        <asp:Button ID="BackBtn" runat="server" Text="回上頁" PostBackUrl="~/MAT/MAT3/MAT3101_01.aspx" />
    </div>

    
    <asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbSelect"
        PopupControlID="Panel1"
        BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

    <asp:Panel runat="server" ID="Panel1">
        <div>
            <table id="table" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
                <tr>
                    <td class="htmltable_Title2" style ="text-align:center">
                      請購單匯入
                    </td>        
                </tr>
                <tr>
                    <td>                                             
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
                            PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                            Width="100%" EnableModelValidation="True" CssClass="Grid"> 
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox id="cbxAll" runat="server" OnCheckedChanged="cbxAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbx" runat="server" />
                                        <asp:HiddenField ID="hfFlowId" runat="server" Value='<%# Bind("Flow_id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="depart_name" HeaderText="請購單位" />
                                <asp:BoundField DataField="User_name" HeaderText="申請人" />
                                <asp:BoundField DataField="Apply_date" HeaderText="請購日期" />
                            </Columns>
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom">
                        <asp:Button ID="cbConfirm" runat="server" Text="確定" OnClick="cbConfirm_Click"/>
                        <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click"/>
                    </td>
                </tr>
            </table>   
        </div>
    </asp:Panel>


</asp:Content>