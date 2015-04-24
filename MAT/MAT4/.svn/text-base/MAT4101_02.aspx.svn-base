<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT4101_02.aspx.vb" Inherits="MAT4101_02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">物料基本資料維護-新增
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:Red">*</span>分類號
            </td>
            <td>
                <asp:DropDownList ID="ddl_MaterialClass" runat="server">
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left"><span style="color:Red">*</span>物料編號
            </td>
            <td>
                <asp:TextBox ID="txtMaterialId" runat="server" AutoPostBack="True" MaxLength="9" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:Red">*</span>物料名稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtMaterialName" runat="server" MaxLength="60" ></asp:TextBox>
            </td>
            <td class="htmltable_Left"><span style="color:Red">*</span>單位
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnit" runat="server" Width="50px" MaxLength="4" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:Red">*</span>單位領用限量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtUnitLimitCnt" runat="server" Width="50px" MaxLength="5"></asp:TextBox>單位/<asp:TextBox ID="txtUnitLimitMMCnt" runat="server" Width="25px" MaxLength="2"></asp:TextBox>月
            </td>
            <td class="htmltable_Left"><span style="color:Red">*</span>員工領用限量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPersonLimitCnt" runat="server" Width="50px" MaxLength="5"></asp:TextBox>單位/<asp:TextBox ID="txtPersonLimitMMCnt" runat="server" Width="25px" MaxLength="2"></asp:TextBox>月
            </td>
        </tr>
        <tr> 
            <td class="htmltable_Left"><span style="color:Red">*</span>安全庫存數量
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtSafeCount" runat="server" Width="50px" MaxLength="5"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left">目前庫存數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtReserveCnt" runat="server" Width="50px" readonly="true" BackColor="LightGray"></asp:TextBox>
            </td>
            <td class="htmltable_Left">目前可用餘額
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtAvailableCnt" runat="server" Width="50px"  readonly="true" BackColor="LightGray"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left">存放地點
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtLoction" runat="server" Width="150px" MaxLength="60" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">圖片上傳
            </td>
            <td style="width: 326px"> 
                <asp:FileUpload ID="fuMaterialIcon" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">備註說明
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" Height="76px" Width="100%" MaxLength="255" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DonBtn" runat="server" Text="確認" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
        <asp:Button ID="btnPostBackUrl" runat="server" Text="回上頁" PostBackUrl="~/MAT/MAT4/MAT4101_01.aspx"/>
    </div>
</asp:Content>

