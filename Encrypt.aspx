<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Encrypt.aspx.vb" Inherits="Encrypt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server" style="height: 600px; width: 800px;">
        <div align="center">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large"
                ForeColor="Red" Text="此功能目的:幫webconfig檔案加密處裡"></asp:Label><br />
            <asp:Button ID="btnEncrypt" runat="server" Text="加密" />
            <asp:Button ID="btnDecrypt" runat="server" Text="解密" />&nbsp;<br />
            </div>
    </form>
</body>
</html>
