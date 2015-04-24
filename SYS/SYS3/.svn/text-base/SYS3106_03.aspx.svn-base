<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SYS3106_03.aspx.vb" Inherits="SYS3106_03" %>

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
            權限設定</td>
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
                <asp:TreeView ID="treeMenu" runat="server" 
                    NodeIndent="15" ShowLines="True" width="230px" ShowCheckBoxes="All">
                    <ParentNodeStyle Font-Bold="False" HorizontalPadding="3px" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" />
                    <NodeStyle Font-Size="13px" ForeColor="Black" HorizontalPadding="5px" ImageUrl="~/images/folder.gif" />
                    <LeafNodeStyle HorizontalPadding="5px" ImageUrl="~/images/doc.gif" />
                </asp:TreeView>
             </td>
         </tr>
         <tr>
             <td class="htmltable_Right" style="text-align:right">
                 <asp:Button ID="btnOK2" runat="server" CausesValidation="False" Text="確認" /></td>
         </tr>
        </table>
</asp:Content>
