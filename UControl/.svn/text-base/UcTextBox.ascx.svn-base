<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcTextBox.ascx.vb" Inherits="UControl_UcTextBox" %>
<script type="text/javascript">
/*
function doKeypress(control){
    maxLength = control.attributes["maxLength"].value;
    value = control.value;
     if(maxLength && value.length > maxLength-1){
          event.returnValue = false;
          maxLength = parseInt(maxLength);
     }
}
// Cancel default behavior

function doBeforePaste(control){
    maxLength = control.attributes["maxLength"].value;
     if(maxLength)
     {
          event.returnValue = false;
     }
}
// Cancel default behavior and create a new paste routine

function doPaste(control){
    maxLength = control.attributes["maxLength"].value;
    value = control.value;
     if(maxLength){
          event.returnValue = false;
          maxLength = parseInt(maxLength);
          var oTR = control.document.selection.createRange();
          var iInsertLength = maxLength - value.length + oTR.text.length;
          var sData = window.clipboardData.getData("Text").substr(0,iInsertLength);
          oTR.text = sData;
     }
}
*/
    $().ready(function () {
        document.getElementById("<%=tb.ClientID %>").onchange = function () {
            var value = document.getElementById("<%=tb.ClientID %>").value;
            var maxLength = parseInt("<%=Me.MaxLength %>");
            if ("" != value && value.length > maxLength) {
                value = value.substring(0, maxLength);
                document.getElementById("<%=tb.ClientID %>").value = value;
            }
        }
        /**$('#<%=tb.ClientID %>').maxlength({ 
        maxCharacters: <%=Me.MaxLength %>,
        status: false
        });**/
    });    
</script>
<asp:TextBox ID="tb" runat="server" Height="40"></asp:TextBox>