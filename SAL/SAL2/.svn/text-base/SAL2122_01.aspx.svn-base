<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL2122_01.aspx.cs" Inherits="SAL_SAL2_SAL2122_01" %>
<%@ Register Src="../../UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList"
    TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                已扣補充保費明細查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                 給付年月起
            </td>
            <td class="htmltable_Right">
             <uc2:ucDateDropDownList ID="UcDateDropDownList1" runat="server" Kind="YM" />
            </td>
            <td class="htmltable_Left">
                給付年月迄
            </td>
            <td class="htmltable_Right">
                <uc2:ucDateDropDownList ID="ddl_PAYO_YYMM" runat="server" Kind="YM" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right" style="width: 326px" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="ddl_Budget_code" runat="server" Code_Kind="P" Code_sys="002" Code_type="018"
                            ControlType="2"  Budget_Code="Y" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="查詢" onclick="Button1_Click" />
                <asp:Button ID="Button_report" runat="server" Text="列印" OnClick="Button_report_Click" />
            </td>
        </tr>
    </table>

      <table class="tableStyle99" width="100%" runat="server" visible ="false" id = "tableGV1">
      <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
      <tr>
      <td>
     <asp:GridView ID="GridView1" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        EnableModelValidation="True" Width="100%" AllowPaging="True" 
              onpageindexchanging="GridView1_PageIndexChanging" 
              onrowdatabound="GridView1_RowDataBound" PageSize="30"  >
        <EmptyDataTemplate>
            查無資料!!
        </EmptyDataTemplate>
         <PagerStyle HorizontalAlign="Right" />
        <RowStyle CssClass="Row" />
        <AlternatingRowStyle CssClass="AlternatingRow" />
        <PagerSettings Position="TopAndBottom" />
           <FooterStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField HeaderText="月份" DataField="mm" />
            <asp:BoundField HeaderText="薪資種類" DataField="code_desc1" />
            <asp:BoundField HeaderText="單位" DataField="Depart_name"  />
            <asp:BoundField HeaderText="姓名" DataField="BASE_NAME" />
            <asp:BoundField HeaderText="職員類別" DataField="desc2" />
            <asp:BoundField HeaderText="當月投保額" DataField="mout" 
                ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="給付金額" DataField="inco_amt" 
                ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
    </asp:GridView>
    </td>
    </tr>
    <tr>
    <td align="right">
    <uc4:ucpager ID="UcPager" runat="server" GridName="GridView1" 
    PSize="30" PNow="1" />
    </td>
    </tr>
    </table>

</asp:Content>

