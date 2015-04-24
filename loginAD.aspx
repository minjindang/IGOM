<%@ Page Language="VB" AutoEventWireup="false" CodeFile="loginAD.aspx.vb" Inherits="loginAD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>歡迎使用整合性總務作業管理資訊系統!!</title>    
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>     
    <script type="text/javascript">
    function checkEmptyField(idlist,fieldlist){
        var checknum=/^[0-9, ]+$/i;         
        var aid = new Array();
        var afield = new Array();
        aid = idlist.split(",");
        afield = fieldlist.split(",");   
        
        for(var i=0 ; i<aid.length ; i++){
            if(document.getElementById(aid[i]).value==''){
                alert("「"+afield[i]+"」欄位為必填。");
                document.getElementById(aid[i]).focus();
                return false;                            
            }
        }
        return true;
    }
    $().ready(function() {
        $('#<%=txtAcc.ClientID %>').focus();
        $('#txtPass').val('qwer1234');
    });
    </script>
    <style type="text/css"> 
    <!--
    body {
	    margin-left: 0px;
	    margin-right: 0px;
    }
    -->
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="background: url('images/login.jpg') no-repeat; height:422px; width:934px;">
                
                    <div style="margin-top:245px; margin-left:650px; width:280px;">
                        
                        <table width="100%" cellpadding="1" >
                            <tr>
                                <td style="width:60px; height:30px;"></td>
                                <td>
                                    <asp:TextBox style="FONT-SIZE: 8pt" id="txtAcc" runat="server" MaxLength="10" width="140px" Text="L411"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height:37px;"></td>
                                <td>
                                    <asp:TextBox id="txtPass" runat="server" MaxLength="12" width="140px" TextMode="Password" ></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="height:2px;"></td>
                                <td>
                                    <asp:TextBox ID="tbcode" runat="server" Width="80px" MaxLength="5"></asp:TextBox>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="ValidateCode.ashx" ImageAlign="Top" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2" align="center" style="height:30px;">
                                    <%--<a href="user_guide.doc"><span style="font-size:15px;">使用者手冊</span></a>--%>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton id="btnLogin" ImageAlign="AbsMiddle" runat="server" ImageUrl="~/images/login.png" ToolTip="登入整合性總務作業管理資訊系統"></asp:ImageButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 60px; color: Red; font-size:13px;">
                                    <!--*帳號與密碼同現行人事差勤系統的帳號與密碼--></td>
                            </tr>
                        </table>
                        
                    </div>
                </td>
                <td style="background: url('images/login2.jpg') repeat-x;">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
