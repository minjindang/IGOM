Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT2105_01
    Inherits BaseWebForm
#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SelectBtn_Click()
    End Sub
#End Region
#Region " SelectBtn_Click"
    Protected Sub SelectBtn_Click()
        Dim db As New DataTable
        Dim mc As Material_main = New Material_main()
        db = mc.MAT2105SelectData()
        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        Me.div1.Visible = True
    End Sub
#End Region
End Class


