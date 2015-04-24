Imports FSC.Logic

Partial Class UControl_UcLeaveDate2
    Inherits System.Web.UI.UserControl

#Region "Property"
    Private _IsDefault As Boolean = True
    Private _Apply_id As String

    Public Property Enabled() As Boolean
        Get
            Return tbStart_date.Enabled
        End Get
        Set(value As Boolean)
            tbStart_date.Enabled = value
            tbStart_time.Enabled = value
            tbEnd_date.Enabled = value
            tbEnd_time.Enabled = value
        End Set
    End Property

    Public Property Start_date() As String
        Get
            If Not String.IsNullOrEmpty(tbStart_date.Text.Trim()) Then
                Return tbStart_date.Text.Trim().PadLeft(7, "0").Replace("/", "")
            End If
            Return tbStart_date.Text.Trim()
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing AndAlso value.Length = 7 Then
                tbStart_date.Text = DateTimeInfo.ToDisplay(value)
            Else
                tbStart_date.Text = value
            End If
        End Set
    End Property

    Public Property Start_time() As String
        Get
            If Not String.IsNullOrEmpty(tbStart_time.Text.Trim()) Then
                Return tbStart_time.Text.Trim().PadLeft(4, "0")
            End If
            Return tbStart_time.Text.Trim()
        End Get
        Set(ByVal value As String)
            tbStart_time.Text = value
        End Set
    End Property

    Public Property End_date() As String
        Get
            If Not String.IsNullOrEmpty(tbEnd_date.Text.Trim()) Then
                Return tbEnd_date.Text.Trim().PadLeft(7, "0").Replace("/", "")
            End If
            Return tbEnd_date.Text.Trim()
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing AndAlso value.Length = 7 Then
                tbEnd_date.Text = DateTimeInfo.ToDisplay(value)
            Else
                tbEnd_date.Text = value
            End If
        End Set
    End Property

    Public Property End_time() As String
        Get
            If Not String.IsNullOrEmpty(tbEnd_time.Text.Trim()) Then
                Return tbEnd_time.Text.Trim().PadLeft(4, "0")
            End If
            Return tbEnd_time.Text.Trim()
        End Get
        Set(ByVal value As String)
            tbEnd_time.Text = value
        End Set
    End Property

    Public Property IsDefault() As Boolean
        Get
            Return _IsDefault
        End Get
        Set(ByVal value As Boolean)
            _IsDefault = value
        End Set
    End Property

    Public Property Apply_id() As String
        Get
            Return _Apply_id
        End Get
        Set(ByVal value As String)
            _Apply_id = value
            setDateTime(Me.IsDefault)
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgDates.Attributes.Add("onmouseover", "this.style.cursor='hand'")
        imgDatee.Attributes.Add("onmouseover", "this.style.cursor='hand'")
        imgDateS.Attributes.Add("onclick", "displayDatePicker('" & tbStart_date.ClientID & "', '" & tbStart_time.ClientID & "', 'S');return false;")
        ImgDateE.Attributes.Add("onclick", "displayDatePicker('" & tbEnd_date.ClientID & "', '" & tbEnd_time.ClientID & "', 'E');return false;")

        tbStart_date.Attributes.Add("onchange", "checkDate(this.id);chgValue('" & tbStart_date.Text & "','document.getElementById(""" & tbStart_time.ClientID & """)','S');if('function' == typeof(chgUcDate)){chgUcDate(this.id);}")
        tbEnd_date.Attributes.Add("onchange", "checkDate(this.id);chgValue('" & tbStart_date.Text & "','document.getElementById(""" & tbStart_time.ClientID & """)','E');if('function' == typeof(chgUcDate)){chgUcDate(this.id);}")

        tbStart_time.Attributes.Add("onchange", "checkTime(this.id);chgValue('" & tbStart_date.Text & "','document.getElementById(""" & tbStart_time.ClientID & """)','S');if('function' == typeof(chgUcDate)){chgUcDate(this.id);}")
        tbEnd_time.Attributes.Add("onchange", "checkTime(this.id);chgValue('" & tbStart_date.Text & "','document.getElementById(""" & tbStart_time.ClientID & """)','E');if('function' == typeof(chgUcDate)){chgUcDate(this.id);}")

        setDateTime(Me.IsDefault)

        If IsPostBack Then
            Return
        End If

        'If Not Me.IsDefault Then
        '    setDateTime(True)
        'End If
        setDateTime(Me.IsDefault)
    End Sub

    Public Sub setDateTime(ByVal IsDefault As Boolean)
        Dim WORKTIMEB As String = ""
        Dim WORKTIMEE As String = ""

        If IsDefault And Not String.IsNullOrEmpty(Me.Apply_id) Then
            Me.Start_date = DateTimeInfo.GetRocDate(Now)
            Me.End_date = DateTimeInfo.GetRocDate(Now)

            Dim ht As Hashtable = FSC.Logic.Content.GetWorkTime(Me.Apply_id, DateTimeInfo.GetRocDate(Now))
            If ht IsNot Nothing AndAlso ht.Count > 0 Then
                WORKTIMEB = ht("WORKTIMEB").ToString()
                WORKTIMEE = ht("WORKTIMEE").ToString()
            End If

            Me.Start_time = WORKTIMEB
            Me.End_time = WORKTIMEE
        End If
    End Sub

End Class
