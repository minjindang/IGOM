<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Error.aspx.vb" Inherits="ErrorLog_Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>error</title>
    <link href="error.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>系統執行時發生錯誤</h2><hr/> <br>
        此頁面在執行時發生了未預期的錯誤；錯誤訊息已經被記錄於錯誤記錄檔，錯誤編號為："<%=Request.QueryString("ErrorCode")%> "。<br/> 
        <br/><b>錯誤發生在：</b> 
        <pre><%=Request.QueryString("ErrorCode2") %> </pre>
    </div>
    </form>
</body>
</html>
