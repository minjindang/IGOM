<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2107_01.aspx.vb" Inherits="MAT2107_01" %>
                                                                                                     
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%--<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc3" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>   --%>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>
<%@ Register Src="~/UControl/MAT/UcDDLMatDepart.ascx" TagPrefix="uc1" TagName="UcDDLMatDepart" %>
<%@ Register Src="~/UControl/MAT/ucDDLMatMember.ascx" TagPrefix="uc1" TagName="ucDDLMatMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">                 
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">單項物品領用明細表</td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料編號                    
            </td>
            <td style="width: 326px">
              <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <asp:TextBox  ID="tbMaterial_id" runat="server" Enabled="false"  ></asp:TextBox>              
                        <uc1:UcMaterialClass runat="server" ID="UcMaterialClass" OnChecked="UcMaterialClass_Checked" />           
                  <%--  </ContentTemplate>
                </asp:UpdatePanel>   --%>                                                             
            </td>
             <td class="htmltable_Left">物料名稱                    
            </td>
            <td style="width: 326px">        
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>          
                       <asp:TextBox ID="tbMaterial_name" runat="server"  Enabled="false"/>            
                           </ContentTemplate>
                </asp:UpdatePanel> 
            </td>
        </tr>
             <tr>
            <td class="htmltable_Left">領用日期(起~迄)
            </td>
            <td colspan="3">
                        <uc2:UcDate ID="UcDateS" runat="server" />
                        ～　                                                                                                          
                        <uc2:UcDate ID="UcDateE" runat="server" />
            </td>
        </tr>
          <tr>
            <td class="htmltable_Left" style="width: 100px; height: 19px;">單位別
            </td>
            <td class="TdHeightLight" style="width: 250px; height: 19px;" colspan="3">
                <%--<uc1:UcDDLDepart runat="server" ID="ddlDepart_id" />--%>
                <uc1:UcDDLMatDepart runat="server" ID="ddlDepart_id" />
            </td>

        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">員工姓名</td>
            <td class="htmltable_Right" style="width: 250px" colspan="3">
                <%--<uc3:UcDDLMember runat="server" ID="ddlUser_name" />--%>
                <uc1:ucDDLMatMember runat="server" ID="ddlUser_name" />
            </td>
        </tr>
           <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="PrintBtn" runat="server" Text="列印" />
                <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
            </td>
        </tr>
    </table>

</asp:Content>

