<%@ Page Language="VB" AutoEventWireup="false" CodeFile="testPortal.aspx.vb" Inherits="testPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" >
    <input type="hidden" name="Personel_id" value="250018" />
<%--    <input type="button" value="Submit" />--%>
        <asp:Button Text="Submit" PostBackUrl ="PortalInterface.aspx" runat="server"  />
        </form>
</body>
</html>
