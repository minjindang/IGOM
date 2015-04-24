Imports System
Imports System.Data
Imports FSCPLM.Logic

Partial Class FSC3_FSC3115_01
    Inherits BaseWebForm

    Dim dtData As DataTable
    Dim bll As New FSC.Logic.FSC3115()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        ' 取出P2K資料->將P2K資料，寫入差勤系統
        dtData = bll.GetData_InsertData_ToIGOMDB("Synchronous01", Me.tbPECARD.Text, Me.tbPENAME.Text)

        ' 取出差異資料
        dtData = bll.GetDifferenceData(Me.tbPECARD.Text, Me.tbPENAME.Text)

        Me.gvList.DataSource = dtData
        Me.gvList.DataBind()

        For i As Integer = 0 To (gvList.Rows.Count - 1)
            Dim lbPEACTDATE As Label = gvList.Rows(i).FindControl("lbPEACTDATE")
            Dim lbPELEVDATE As Label = gvList.Rows(i).FindControl("lbPELEVDATE")
            Dim lbPEPOINT As Label = gvList.Rows(i).FindControl("lbPEPOINT")
            Dim lbPEPROFESS As Label = gvList.Rows(i).FindControl("lbPEPROFESS")
            Dim lbPECHIEF As Label = gvList.Rows(i).FindControl("lbPECHIEF")
            Dim lbView As LinkButton = gvList.Rows(i).FindControl("lbView")

            lbView.Visible = False

            If lbPEACTDATE.Text <> "無差異" Then
                lbView.Visible = True
            End If
            If lbPELEVDATE.Text <> "無差異" Then
                lbView.Visible = True
            End If
            If lbPEPOINT.Text <> "無差異" Then
                lbView.Visible = True
            End If
            If lbPEPROFESS.Text <> "無差異" Then
                lbView.Visible = True
            End If
            If lbPECHIEF.Text <> "無差異" Then
                lbView.Visible = True
            End If

        Next


    End Sub

    ''' <summary>
    ''' GridView 中的檢視按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub lbView_Click(sender As Object, e As EventArgs)
        ' 取得該列數
        Dim Row As System.Web.UI.WebControls.GridViewRow
        Dim RowIndex As Integer
        Row = CType(sender, LinkButton).NamingContainer
        RowIndex = Row.RowIndex

        ' 取得該列的資料
        Dim lbPECARD As Label = gvList.Rows(RowIndex).FindControl("lbPECARD")
        Dim hfPEIDNO As HiddenField = gvList.Rows(RowIndex).FindControl("hfPEIDNO")

        Session("FSC_PECARD") = lbPECARD.Text
        Session("FSC_PEIDNO") = hfPEIDNO.Value

        Response.Redirect("FSC3115_02.aspx")
    End Sub
End Class
