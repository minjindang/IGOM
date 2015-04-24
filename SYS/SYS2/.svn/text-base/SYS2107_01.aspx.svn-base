<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SYS2107_01.aspx.cs" Inherits="SYS2107_01" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
    <table class="tableStyle99" width="100%" runat ="server" id="search">
        <tr>
            <td class="htmltable_Title" colspan="2">
                AD資料查詢
            </td>
        </tr>  
        <tr>
            <td class="htmltable_Left">
            AD帳號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="ADid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2" style="border-top: none;">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />           
            </td>
        </tr>
    </table>   
      
    <table id = "data" runat="server" visible ="false" class="tableStyle99" width="100%">
       <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
    <tr>
    <td >
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="100%" AllowPaging="True" CssClass="Grid" 
            onpageindexchanged="GridView1_PageIndexChanged" 
            onpageindexchanging="GridView1_PageIndexChanging">
          <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
          <EmptyDataTemplate>
            查無資料!!
        </EmptyDataTemplate>
            <PagerStyle HorizontalAlign="Right" />
           <RowStyle CssClass="Row" />
        <AlternatingRowStyle CssClass="AlternatingRow" />
        <PagerSettings Position="TopAndBottom" />
        <Columns>
        <asp:BoundField DataField="description" HeaderText="單位" />
          <asp:BoundField DataField="displayname" HeaderText="姓名" />
            <asp:BoundField DataField="telephonenumber" HeaderText="電話" />
              <asp:BoundField DataField="title" HeaderText="職稱" />
                <asp:BoundField DataField="mail" HeaderText="EMAIL" />
        </Columns>
        </asp:GridView>

    </td>  
    </tr>  
       <tr>
                 <td align="right">
                 <uc4:ucpager ID="UcPager1" runat="server" GridName="GridView1" 
                 PSize="30" PNow="1" />
                 </td>
                 </tr>
    </table>
   

    
</asp:Content>
