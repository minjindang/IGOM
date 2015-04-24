
Partial Class UControl_UcShowDayHours
    Inherits System.Web.UI.UserControl

    Private _Leave_hours As Integer
    Private _Leave_type As Integer
    Public Property Leave_type() As Integer
        Get
            Return _Leave_type
        End Get
        Set(ByVal value As Integer)
            _Leave_type = value
        End Set
    End Property

    Public Property Leave_hours() As Integer
        Get
            Return _Leave_hours
        End Get
        Set(ByVal value As Integer)
            _Leave_hours = value


            'If dayhours = 0.0 Then
            '    lbDayhours.Text = "0小時"
            '    Return
            'End If

            'Dim dayhour As String = dayhours
            'Dim day As String = "0"
            'Dim hour As String = "0"

            'If dayhour.IndexOf(".") > 0 Then
            '    day = Mid(dayhour, 1, dayhour.IndexOf("."))
            '    hour = Mid(dayhour, dayhour.IndexOf(".") + 2, dayhour.Length - dayhour.IndexOf("."))
            '    lbDayhours.Text = IIf(day = "0", "", day & "日") & IIf(hour = "0", "", hour & "小時")
            'Else
            '    lbDayhours.Text = dayhour & "日"
            'End If
            If Leave_type = 4 Or Leave_type = 20 Or Leave_type = 80 Or Leave_type = 82 Then
                lbDayhours.Text = value & " 小時"
            Else
                Dim dayhours As Double = FSC.Logic.Content.ConvertDayHours(value)
                'lbDayhours.Text = dayhours & " 天"
                Dim dayhour As String = dayhours
                Dim day As String = "0"
                Dim hour As String = "0"

                If dayhour.IndexOf(".") > 0 Then
                    day = Mid(dayhour, 1, dayhour.IndexOf("."))
                    hour = Mid(dayhour, dayhour.IndexOf(".") + 2, dayhour.Length - dayhour.IndexOf("."))
                    lbDayhours.Text = IIf(day = "0", "", day & " 天 ") & IIf(hour = "0", "", hour & " 小時")
                Else
                    lbDayhours.Text = dayhour & " 天"
                End If
            End If
        End Set
    End Property

End Class
