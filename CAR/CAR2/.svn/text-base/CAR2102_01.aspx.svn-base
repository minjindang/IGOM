<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CAR2102_01.aspx.cs" Inherits="CAR_CAR2_CAR2102_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">派車統計報表
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">派車日期起迄
                </td>
                <td colspan="3">
                    <uc1:UcDate runat="server" ID="ucStart_date" />
                    ~
                    <uc1:UcDate runat="server" ID="ucEnd_date" />
                </td> 
            </tr>
             <tr>
                <td class="htmltable_Left">查詢依據
                </td>
                <td colspan="3">
                    <asp:RadioButtonList ID="rblTYpe" runat="server">
                        <asp:ListItem Value="0">依車輛查詢</asp:ListItem>
                        <asp:ListItem Value="1">依部門查詢</asp:ListItem>
                    </asp:RadioButtonList>
                </td>  
            </tr>
        </table>
        <div align="center"> 
            <asp:Button ID="DoneBtn" runat="server" Text="查詢" OnClick="DoneBtn_Click" /> 
            <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click" /> 
        </div> 
         <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px" OnDataBound="GridViewA_DataBound" OnPageIndexChanging="GridViewA_PageIndexChanging"
                Width="100%" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="車牌號碼">
                            <ItemStyle HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Name")%>' NavigateUrl='<%#  Eval("LINKS") %> ' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField HeaderText="使用時數" DataField="Hours" />
                     <asp:TemplateField HeaderText="使用率">
                            <ItemStyle HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Usage")  %>'></asp:Label><asp:Label ID="Label2" runat="server" Text="%"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField HeaderText="使用次數" DataField="Count" />
                </Columns>
                <PagerSettings Visible="false" /> 
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
               <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA" PNow="1" PSize="20" Visible="true" />
        </div>





    </div>

</asp:Content>

