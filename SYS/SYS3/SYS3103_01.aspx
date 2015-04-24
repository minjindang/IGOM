<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3103_01.aspx.vb" Inherits="SYS3103_01"  %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table1" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99"
    width="100%">
    <tr>
        <td class="htmltable_Title2" colspan="2">
            代碼維護
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" style="width:120px">
            <span style="color:red">*</span>子系統別</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:DropDownList ID="ddlCODE_SYS" runat="server" />
        </td>
    </tr>    
    <tr>
        <td class="htmltable_Left" style="width:120px">
            <span style="color:red">*</span>代碼種類</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:DropDownList ID="ddlCODE_KIND" runat="server" >
                <asp:ListItem Value="P">公共</asp:ListItem>
                <asp:ListItem Value="D">自訂</asp:ListItem>
                <asp:ListItem Value="S">系統用</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" style="width:120px">
            <span style="color:red">*</span>代碼類別</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:DropDownList ID="ddlCODE_TYPE" runat="server" />
        </td>
    </tr>    
    <tr>
        <td class="htmltable_Left" style="width:120px">
            <span style="color:red">*</span>代碼編號</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbCODE_NO" runat="server" MaxLength="10" />
        </td>
    </tr>   
    <tr>
        <td class="htmltable_Left" style="width:120px">
            <span style="color:red">*</span>代碼說明(1)</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbCODE_DESC1" runat="server" MaxLength="50" />
        </td>
    </tr> 
    <tr>
        <td class="htmltable_Left" style="width:120px">
            代碼說明(2)</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbCODE_DESC2" runat="server" MaxLength="50" />
        </td>
    </tr> 
        <tr>
        <td class="htmltable_Left" style="width:120px">
            備註(1)</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbCODE_REMARK1" runat="server" MaxLength="50" />
        </td>
    </tr> 
    <tr>
        <td class="htmltable_Left" style="width:120px">
            備註(2)</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbCODE_REMARK2" runat="server" MaxLength="50" />
        </td>
    </tr> 
    <tr>
        <td class="htmltable_Left" style="width:120px"><span style="color:red">*</span>
            排序</td>
        <td class="htmltable_Right" style="width:230px">
            <asp:TextBox ID="tbCODE_SORT" runat="server" MaxLength="50" />
        </td>
    </tr> 
    <tr>
        <td class="htmltable_Bottom" colspan="2">
            <asp:Button ID="cbAdd" runat="server" Text="新增" />
            <asp:Button ID="cbSubmit" runat="server" Text="確定" Visible="false" />
            <asp:Button ID="cbCancel" runat="server" Text="取消" Visible="false" />
        </td>
    </tr>
</table>
<br />     
<table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99"> 
    <tr>
        <td>            
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="true" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red">                       
                <Columns>
                    <asp:TemplateField HeaderText="子系統別">
                        <ItemTemplate>
                            <asp:Label ID="lbCODE_SYS_Name" runat="server" Text='<%# Bind("CODE_SYS_Name")%>' />
                            <asp:Label ID="lbCODE_SYS" runat="server" Text='<%# Bind("CODE_SYS")%>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="代碼種類">
                        <ItemTemplate>
                            <asp:Label ID="lbCODE_KIND_Name" runat="server" Text='<%# Bind("CODE_KIND_Name")%>' />
                            <asp:Label ID="lbCODE_KIND" runat="server" Text='<%# Bind("CODE_KIND")%>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="代碼類別">
                        <ItemTemplate>
                            <asp:Label ID="lbCODE_TYPE_Name" runat="server" Text='<%# Bind("CODE_TYPE_Name")%>' />
                            <asp:Label ID="lbCODE_TYPE" runat="server" Text='<%# Bind("CODE_TYPE")%>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CODE_NO" HeaderText="代碼編號" />
                    <asp:BoundField DataField="CODE_DESC1" HeaderText="代碼說明(1)" />
                    <asp:BoundField DataField="CODE_DESC2" HeaderText="代碼說明(2)" />
                    <asp:BoundField DataField="CODE_REMARK1" HeaderText="備註(1)" />
                    <asp:BoundField DataField="CODE_REMARK2" HeaderText="備註(2)" />
                    <asp:BoundField DataField="CODE_SORT" HeaderText="排序" />
                    <asp:TemplateField HeaderText="功能">
                        <ItemTemplate>
                            <asp:Button ID="cbNext" runat="server" Text="下層代碼" onclick="cbNext_Click" />                                            
                            <asp:Button ID="cbUpdate" runat="server" Text="修改" onclick="cbUpdate_Click" />
                            <asp:Button ID="cbDelete" runat="server" Text="刪除" onclick="cbDelete_Click" OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Right" />
                <EmptyDataTemplate>
                    查無資料!!
                </EmptyDataTemplate>
                <RowStyle CssClass="Row" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />                    
            </asp:GridView>  
        </td>    
    </tr>
    <tr>
        <td align="right" class="TdHeightLight" style="width: 100%">
            <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList" PNow="1" PSize="30" />
        </td>
    </tr>
</table>

</asp:Content>

