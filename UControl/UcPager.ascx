<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcPager.ascx.vb" Inherits="UControl_Pager" %>
<script type="text/javascript">
function checkPage(id,val,type){
    var valid = "0123456789";
    var chk = true;
    for (var i=0; i<val.length; i++) {
        var tmp = val.substring(i, i+1);
        if (valid.indexOf(tmp) == "-1") {
            chk = false;
            alert("筆數頁數必輸為數字!");
            break;
        }
    }
    if(!chk){
        if (type=="1"){
            document.getElementById(id).value = "10";
        }else{
            document.getElementById(id).value = "1";
        }
    }
}
</script>

<div>
    <table class="Pager" id="Pager" runat="server">
        <tr>
            <td style="height: 21px" valign="bottom">
                <asp:Label ID="lbOne" runat="server" Text="每頁顯示筆數：" width="112px"></asp:Label>
                <asp:TextBox ID="tbRowOfPage" runat="server" width="40px"></asp:TextBox>
                <asp:Button ID="btnReShow" runat="server" Text="重新顯示" />&nbsp;
                <asp:Label ID="lbTwo" runat="server" Text="-目前頁數："></asp:Label>
                <asp:TextBox ID="tbNowPage" runat="server" width="40px"></asp:TextBox>
                <asp:Button ID="btnToPage" runat="server" Text="跳頁" />
                <asp:Label ID="lbThree" runat="server" Text="-資料總筆數："></asp:Label>
                <asp:Label ID="lbRowCount" runat="server" Text="0"></asp:Label>
                <asp:Label ID="lbFour" runat="server" Text="筆-總頁數："></asp:Label>
                <asp:Label ID="lbPageCount" runat="server" Text="0"></asp:Label></td>
        </tr>
    </table>
</div>
