<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucGridViewPager.ascx.vb" Inherits="uc_ucGridViewPager" %>

<asp:Panel ID="GridViewPagerPanel" runat="server">
    <table class="table_1"><tr><td>

        <table width="95%" cellspacing="0" cellpadding="3" align="center" height="17">
            <tr><td width="47%"><font size="-1">
                <asp:ImageButton ID="b_pageFirst" runat="server" ImageUrl="~/images/SAL/intra_image/image_chinese/chinese_style1/share/FIRST_1.GIF" />&nbsp;&nbsp;&nbsp;&nbsp; <%-- 第一頁 --%>
                <asp:ImageButton ID="b_pagePrev" runat="server" ImageUrl="~/images/SAL/intra_image/image_chinese/chinese_style1/share/FORWARD_1.GIF" />&nbsp;&nbsp;&nbsp;&nbsp; <%-- 上一頁 --%>
                <asp:ImageButton ID="b_pageNext" runat="server" ImageUrl="~/images/SAL/intra_image/image_chinese/chinese_style1/share/REARWARD_1.GIF" />&nbsp;&nbsp;&nbsp;&nbsp; <%-- 下一頁 --%>
                <asp:ImageButton ID="b_pageLast" runat="server" ImageUrl="~/images/SAL/intra_image/image_chinese/chinese_style1/share/backward_1.GIF" />&nbsp;&nbsp;&nbsp;&nbsp; <%-- 最後一頁 --%>
            </font></td><td width="53%">
            <div align="right"><font size="-1">共&nbsp;<asp:Label ID="v_DataRowsCount" runat="server" ForeColor="Red" />&nbsp;筆&nbsp;&nbsp;第&nbsp;<asp:Label ID="v_PageIndex" runat="server" ForeColor="Red" />&nbsp;/&nbsp;<asp:Label ID="v_PageCount" runat="server" />&nbsp;頁 </font></div>
        </td></tr></table>

    </td></tr></table>
</asp:Panel>
<asp:Label ID="info" runat="server" />

