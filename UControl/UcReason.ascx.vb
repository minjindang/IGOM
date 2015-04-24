Imports System.Data
Imports FSCPLM.Logic

Partial Class UControl_UcReason
    Inherits System.Web.UI.UserControl

#Region "Property"
    Private _Flow_id As String = String.Empty
    Private _Leave_type As Integer
    Private _Orgcode As String

    Public Property Flow_id() As String
        Get
            Return _Flow_id
        End Get
        Set(ByVal value As String)
            _Flow_id = value
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return _Orgcode
        End Get
        Set(ByVal value As String)
            _Orgcode = value
        End Set
    End Property

    Public Property Leave_type() As Integer
        Get
            Return _Leave_type
        End Get
        Set(ByVal value As Integer)
            _Leave_type = value
            'lbLook.Attributes.Add("onclick", "javascript:window.showModalDialog('FSC1101_12.aspx?fid=" & Flow_id & "&le=" & Leave_type & "','window','dialogHeight:250px; dialogWidth:500px;')")
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lbLook.Attributes.Add("onmouseover", "this.style.cursor='hand'")
        'Bind()
    End Sub

    'Protected Sub Bind()
    '    Dim dt As DataTable

    '    dt = New Flow().GetLastDataByFlow_id(Me.Flow_id, Me.Orgcode)

    '    If dt.Rows.Count <= 0 Then
    '        Return
    '    End If

    '    Dim dr As DataRow = dt.Rows(0)
    '    Dim Depart_id As String = dr("Depart_id").ToString()

    '    Dim cpadt As DataTable

    '    Select Case Me.Leave_type

    '        Case "5", "7"
    '            '公差,公出
    '            cpadt = New CPAPP16M().GetCPAPP16MByFlow_id(Flow_id)
    '            If cpadt.Rows.Count <= 0 Then Return
    '            lbReason.Text = cpadt.Rows(0)("PPREASON").ToString()

    '        Case "20"
    '            '出差補休

    '            cpadt = New CPAPX24M().GetCPAPX24MByFlow_Id(Flow_id)
    '            If cpadt.Rows.Count <= 0 Then Return
    '            lbReason.Text = cpadt.Rows(0)("PXBIG").ToString()

    '        Case "4"
    '            '加班補休

    '            cpadt = New CPAPS19M().GetCPAPS19MByFlow_Id(Flow_id)
    '            If cpadt.Rows.Count <= 0 Then Return
    '            lbReason.Text = cpadt.Rows(0)("PSBIG").ToString()

    '        Case "80", "82"
    '            '加班,專案加班

    '            cpadt = New CPAPR18M().GetCPAPR18MByFlow_id(Flow_id)
    '            If cpadt.Rows.Count <= 0 Then Return
    '            lbReason.Text = cpadt.Rows(0)("PRREASON").ToString()

    '        Case "57"
    '            '忘刷卡

    '            cpadt = New ForgotClock().GetForgotClockByFlow_id(Flow_id)
    '            If cpadt.Rows.Count <= 0 Then Return
    '            lbReason.Text = cpadt.Rows(0)("Reason").ToString()

    '        Case Else

    '            cpadt = New CPAPO15M().GetCPAPO15MByFlow_id(Flow_id)
    '            If cpadt.Rows.Count <= 0 Then Return
    '            lbReason.Text = cpadt.Rows(0)("POREMARK").ToString()

    '    End Select
    'End Sub
End Class
