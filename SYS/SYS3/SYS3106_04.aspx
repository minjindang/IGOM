<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SYS3106_04.aspx.vb" Inherits="SYS3106_04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">  
    <script type="text/javascript">
    function checkCheckBox(){
        var o = window.event.srcElement; 
	    if (o.tagName == "INPUT" && o.type == "checkbox") { 
	        var childrenDivID = o.id.replace('CheckBox','Nodes');
	        var div = document.getElementById(childrenDivID);
            if(div==null) return;
            var checkBoxs = div.getElementsByTagName('INPUT');
            for(var i=0;i<checkBoxs.length;i++)
            {
                if(checkBoxs[i].type=='checkbox')
                    checkBoxs[i].checked=o.checked; 
            }
	    }    
    }
    </script>
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title">
            角色權限控管</td>
        </tr>
        <tr>
            <td class="htmltable_Title2">
            表單設定</td>
        </tr>
        <tr>
            <td class="htmltable_Right" style="text-align:right">
                角色：<asp:Label ID="lblRoleName" runat="server"></asp:Label>
                <asp:Button ID="btnClose" runat="server" CausesValidation="False" 
                    Text="取消" OnClientClick="return confirm('確定要離開此作業?');"   /></td>
        </tr>
        <tr>
            <td class="htmltable_Right" style="text-align:right">
                <asp:Button ID="btnOK" runat="server" CausesValidation="False"
                    Text="確認" /></td>
        </tr>
    
         <tr>
             <td class="htmltable_Right">
                
                 <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!" OnPageIndexChanging="gvList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="項次" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:CheckBox ID="gvcbx" runat="server" />
                                <asp:Label id="gvlbNo" runat="server" Text='<%# (Container.DataItemIndex+1).tostring() %>'></asp:Label>
                                <asp:HiddenField ID="gvhfFormId" runat="server" Value='<%# Eval("Form_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Form_name1" HeaderText="表單類型" ></asp:BoundField>    
                        <asp:BoundField DataField="Form_name2" HeaderText="表單名稱" ItemStyle-HorizontalAlign="Left"></asp:BoundField>                       
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
             <td class="htmltable_Right" style="text-align:right">
                 <asp:Button ID="btnOK2" runat="server" CausesValidation="False" Text="確認" /></td>
         </tr>
        </table>
</asp:Content>
