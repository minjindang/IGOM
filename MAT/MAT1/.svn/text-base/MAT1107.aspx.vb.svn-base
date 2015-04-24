Imports FSCPLM.Logic
Imports System.Data

Partial Class MAT1_MAT1107
    Inherits BaseWebForm
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim url As String = "MAT1107_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        '將Ucpager1的tbRowOfPage轉值
        If Not String.IsNullOrEmpty(material_id1.Text) Then
            url &= ";id1=" & Server.HtmlEncode(material_id1.Text)
        End If
        If Not String.IsNullOrEmpty(material_id2.Text) Then
            url &= ";id2=" & Server.HtmlEncode(material_id2.Text)
        End If
        '將值url帶入另一個aspx

        btnPrint.OnClientClick = "window.open('  " & url & " ','',' memubar=no, status=no, scrollbars=yes, top=100, left=200, toolbar=no, width=800, height=600')"


    End Sub


    Protected Sub Btn_Reset(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        material_id1.Text = ""
        material_id2.Text = ""
        div1.Visible = False
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub

#Region "GirdView"
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim db As DataTable = New DataTable
        Dim mat As Material_main = New Material_main
        Dim id1 As String = ""
        Dim id2 As String = ""

        If Not String.IsNullOrEmpty(material_id1.Text) Then
            id1 = Server.HtmlEncode(material_id1.Text)
        End If
        If Not String.IsNullOrEmpty(material_id2.Text) Then
            id2 = Server.HtmlEncode(material_id2.Text)
        End If
        db = mat.GetMaterial(id1, id2)

        Me.GridView_Uporg.DataSource = db
        Me.GridView_Uporg.DataBind()

        Me.div1.Visible = True

    End Sub
#End Region

#Region "列印excel版"
    'Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    '    Dim dt As DataTable = New DataTable()

    '    Dim Material As MAT_Material_main = New MAT_Material_main()

    '    dt = CType((Material.GetMaterial(material_id1.Text, material_id2.Text)), DataTable)
    '    dt.Columns.Add("num", GetType(System.String)) '加入num欄位

    '    Dim theDTReport As CommonLib.DTReport1
    '    Dim strParam(6) As String '宣告字串陣列

    '    For i As Integer = 0 To dt.Rows.Count - 1 '所有資料num欄位的值
    '        dt.Rows(i).Item("num") = i \ 25 + 1
    '    Next
    '    strParam(0) = Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")
    '    strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)

    '    Dim f As New FSCPLM.Logic.FSCorg
    '    strParam(2) = f.GetOrgcodeName(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
    '    strParam(3) = "MAT0307"
    '    strParam(4) = ""
    '    strParam(5) = ""

    '    theDTReport = New CommonLib.DTReport1(Server.MapPath("~/Report/MAT_Material_main/MAT0317.mht"), dt)
    '    'Dim _GroupPageArys As String() = {"Material_name", "Material_name"}
    '    'theDTReport._GroupPageArys = _GroupPageArys
    '    theDTReport.breakPage = "num"
    '    theDTReport.Param = strParam

    '    theDTReport.ExportFileName = "物品代碼、名稱對照表列印"
    '    theDTReport.ExportToExcel()


    '    dt.Dispose()

    'End Sub
#End Region


End Class
