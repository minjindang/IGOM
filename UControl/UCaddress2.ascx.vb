
Partial Class UC_UCaddress
    Inherits System.Web.UI.UserControl

    Dim _city(0) As String
    Dim _area As New ArrayList
    Dim _postalcode As New ArrayList
    Dim _default_city As String
    Dim _default_Area As String
#Region "Property"
    Property City() As String
        Get
            Return ddlcity.SelectedValue
        End Get
        Set(ByVal value As String)
            initCity()
            ddlcity.SelectedValue = value
            initArea()
        End Set
    End Property

    Property Area() As String
        Get
            Return ddlarea.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlarea.SelectedValue = value
            showPostalCode()
        End Set
    End Property

    Property Postalcode() As String
        Get
            Return tbpostalcode.Text.Trim
        End Get
        Set(ByVal value As String)
            tbpostalcode.Text = value
        End Set
    End Property

    Property Address() As String
        Get
            Return tbaddress.Text.Trim
        End Get
        Set(ByVal value As String)
            tbaddress.Text = value
        End Set
    End Property

    Public Property default_city() As String
        Get
            Return _default_city
        End Get
        Set(ByVal value As String)
            _default_city = value
        End Set
    End Property

    Public Property default_Area() As String
        Get
            Return _default_Area
        End Get
        Set(ByVal value As String)
            _default_Area = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        startInit()
        If IsPostBack Then Return
        initCity()
    End Sub

    Protected Sub initCity()
        ddlcity.Items.Clear()
        For i As Integer = 0 To _city.Length - 1
            ddlcity.Items.Add(New ListItem(_city(i), _city(i)))
        Next
        If Not String.IsNullOrEmpty(default_city) Then
            ddlcity.SelectedValue = default_city
        End If
        initArea()
    End Sub

    Protected Sub initArea()
        Dim countyindex As Integer = ddlcity.SelectedIndex

        Dim zone() As String = CType(_area.Item(countyindex), Array)

        ddlarea.Items.Clear()
        For i As Integer = 0 To zone.Length - 1
            ddlarea.Items.Add(New ListItem(zone(i), zone(i)))
        Next
        If Not String.IsNullOrEmpty(default_Area) Then
            ddlarea.SelectedValue = default_Area
        End If
        showPostalCode()
    End Sub

    Public Sub showPostalCode()
        tbpostalcode.Text = CType(_postalcode.Item(ddlcity.SelectedIndex), Array)(ddlarea.SelectedIndex).ToString
    End Sub
    Protected Sub ddlcity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity.SelectedIndexChanged
        initArea()
    End Sub

    Protected Sub ddlarea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlarea.SelectedIndexChanged
        showPostalCode()
    End Sub

    Protected Sub startInit()
        _city = New String() {"臺北市", "基隆市", "新北市", "宜蘭縣", "新竹市", _
                "新竹縣", "桃園縣", "苗栗縣", "臺中市", "彰化縣", _
                "南投縣", "嘉義市", "嘉義縣", "雲林縣", "臺南市", _
                "高雄市", "澎湖縣", "屏東縣", "臺東縣", "花蓮縣", _
                "金門縣", "連江縣", "南海諸島", "釣魚台列嶼"}

        ' for "臺北市"
        _area.Add(New String() {"", "中正區", "大同區", "中山區", "松山區", "大安區", _
                                "萬華區", "信義區", "士林區", "北投區", "內湖區", "南港區", _
                                "文山區(木柵)", "文山區(景美)"})
        ' for "基隆市"
        _area.Add(New String() {"仁愛區", "信義區", "中正區", "中山區", "安樂區", _
                                "暖暖區", "七堵區"})

        ' for "新北市"
        _area.Add(New String() {"萬里區", "金山區", "板橋區", "汐止區", "深坑區", "石碇區", "瑞芳區", _
                                 "平溪區", "雙溪區", "貢寮區", "新店區", "坪林區", "烏來區", "永和區", "中和區", "土城區", _
                                 "三峽區", "樹林區", "鶯歌區", "三重區", "新莊區", "泰山區", "林口區", "蘆洲區", "五股區", _
                                 "八里區", "淡水區", "三芝區", "石門區"})
        ' for "宜蘭縣"
        _area.Add(New String() {"宜蘭市", "頭城鎮", "礁溪鄉", "壯圍鄉", "員山鄉", "羅東鎮", "三星鄉", _
         "大同鄉", "五結鄉", "冬山鄉", "蘇澳鎮", "南澳鄉"})
        ' for "新竹市"
        _area.Add(New String() {""})
        ' for "新竹縣"
        _area.Add(New String() {"竹北市", "湖口鄉", "新豐鄉", "新埔鄉", "關西鎮", "芎林鄉", "寶山鄉", _
         "竹東鎮", "五峰鄉", "橫山鄉", "尖石鄉", "北埔鄉", "峨嵋鄉"})
        ' for "桃園縣"
        _area.Add(New String() {"中壢市", "平鎮", "龍潭鄉", "楊梅鎮", "新屋鄉", "觀音鄉", "桃園市", _
         "龜山鄉", "八德市", "大溪鎮", "復興鄉", "大園鄉", "蘆竹鄉"})
        ' for "苗栗縣"
        _area.Add(New String() {"竹南鎮", "頭份鎮", "三灣鄉", "南庄鄉", "獅潭鄉", "後龍鎮", "通霄鎮", _
         "苑裡鎮", "苗栗市", "造橋鄉", "頭屋鄉", "公館鄉", "大湖鄉", "泰安鄉", "鉰鑼鄉", "三義鄉", _
         "西湖鄉", "卓蘭鄉"})
        ' for "臺中市"
        _area.Add(New String() {"中區", "東區", "南區", "西區", "北區", "北屯區", _
         "西屯區", "南屯區", "太平區", "大里區", "霧峰區", "烏日區", "豐原區", "后里區", "石岡區", _
         "東勢區", "和平區", "新社區", "潭子區", "大雅區", "神岡區", "大肚區", "沙鹿區", "龍井區", _
         "梧棲區", "清水區", "大甲區", "外圃區", "大安區"})
        ' for "彰化縣"
        _area.Add(New String() {"彰化市", "芬園鄉", "花壇鄉", "秀水鄉", "鹿港鎮", "福興鄉", "線西鄉", _
         "和美鎮", "伸港鄉", "員林鎮", "社頭鄉", "永靖鄉", "埔心鄉", "溪湖鎮", "大村鄉", "埔鹽鄉", _
         "田中鎮", "北斗鎮", "田尾鄉", "埤頭鄉", "溪州鄉", "竹塘鄉", "二林鎮", "大城鄉", "芳苑鄉", _
         "二水鄉"})
        ' for "南投縣"
        _area.Add(New String() {"南投市", "中寮鄉", "草屯鎮", "國姓鄉", "埔里鎮", "仁愛鄉", "名間鄉", _
         "集集鄉", "水里鄉", "魚池鄉", "信義鄉", "竹山鎮", "鹿谷鄉"})
        ' for "嘉義市"
        _area.Add(New String() {""})
        ' for "嘉義縣"
        _area.Add(New String() {"番路鄉", "梅山鄉", "竹崎鄉", "阿里山鄉", "中埔鄉", "大埔鄉", _
        "水上鄉", "鹿草鄉", "太保市", "朴子市", "東石鄉", "六腳鄉", "新港鄉", "民雄鄉", "大林鎮", "漢口鄉", _
        "義竹鄉", "布袋鎮"})
        ' for "雲林縣"
        _area.Add(New String() {"斗南鎮", "大埤鄉", "虎尾鎮", "土庫鎮", "褒忠鄉", "東勢鄉", "臺西鄉", _
         "崙背鄉", "麥寮鄉", "斗六市", "林內鄉", "古坑鄉", "莿桐鄉", "西螺鎮", "二崙鄉", "北港鎮", _
         "水林鄉", "口湖鄉", "四湖鄉", "元長鄉"})
        ' for "臺南市"
        _area.Add(New String() {"中區", "東區", "南區", "西區", "北區", "安平區", _
         "安南區", "永康區", "歸仁區", "新化區", "左鎮區", "玉井區", "楠西區", "南化區", _
         "仁德區", "關廟區", "龍崎區", "官田區", "麻豆區", "佳里區", "西港區", "七股區", "將軍區", _
         "學甲區", "北門區", "新營區", "後壁區", "白河區", "東山區", "六甲區", "下營區", "柳營區", _
         "鹽水區", "善化區", "大內區", "山上區", "新市區", "安定區"})
        ' for "高雄市"
        _area.Add(New String() {"新興區", "前金區", "苓雅區", "鹽埕區", "鼓山區", _
         "旗津區", "前鎮區", "三民區", "楠梓區", "小港區", "左營區", "仁武區", "大社區", "岡山區", "路竹區", "阿蓮區", "田寮區", "燕巢區", _
         "橋頭區", "梓官區", "彌陀區", "永安區", "湖內區", "鳳山區", "大寮區", "林園區", "鳥松區", _
         "大樹區", "旗山區", "美濃區", "六龜區", "內門區", "杉林區", "甲仙區", "桃源區", "三民區", _
         "茂林區", "茄萣區"})
        ' for "澎湖縣"
        _area.Add(New String() {"馬公市", "西嶼鄉", "望安鄉", "七美鄉", "白沙鄉", "湖西鄉"})
        ' for "屏東縣"
        _area.Add(New String() {"屏東市", "三地門鄉", "霧臺鄉", "瑪家鄉", "九如鄉", "里港鄉", "高樹鄉", _
         "鹽埔鄉", "長治鄉", "麟洛鄉", "竹田鄉", "內埔鄉", "萬丹鄉", "潮州鎮", "泰武鄉", "來義鄉", _
         "萬巒鄉", "崁頂鄉", "新埤鄉", "南州鄉", "林邊鄉", "東港鎮", "琉球鄉", "佳冬鄉", "新園鄉", _
         "枋寮鄉", "枋山鄉", "春日鄉", "獅子鄉", "車城鄉", "牡丹鄉", "恆春鎮", "滿州鄉"})
        ' for "臺東縣"
        _area.Add(New String() {"臺東市", "綠島鄉", "蘭嶼鄉", "延平鄉", "卑南鄉", "鹿野鄉", "關山鎮", _
         "海端鄉", "池上鄉", "東河鄉", "成功鎮", "長濱鄉", "太麻里鄉", "金峰鄉", "大武鄉", "達仁鄉"})
        ' for "花蓮縣"
        _area.Add(New String() {"花蓮市", "新城鄉", "秀林鄉", "吉安鄉", "壽豐鄉", "鳳林鎮", "光復鄉", _
         "豐濱鄉", "瑞穗鄉", "萬榮鄉", "玉里鎮", "卓溪鄉", "富里鄉"})
        ' for "金門縣"
        _area.Add(New String() {"金沙鎮", "金湖鎮", "金寧鄉", "金城鎮", "烈嶼鄉", "烏坵鄉"})
        ' for "連江縣"
        _area.Add(New String() {"南竿鄉", "北竿鄉", "莒光鄉", "東引"})
        ' for "南海諸島"
        _area.Add(New String() {"東沙", "西沙"})
        ' for "釣魚台列嶼"
        _area.Add(New String() {""})


        ' for "臺北市"
        _postalcode.Add(New String() {"", "100", "103", "104", "105", "106", "108", "110", "111", _
         "112", "114", "115", "116", "117"})
        ' for "基隆市"
        _postalcode.Add(New String() {"200", "201", "202", "203", "204", "205", "206"})
        ' for "臺北縣"
        _postalcode.Add(New String() {"207", "208", "220", "221", "222", "223", "224", "226", _
         "227", "228", "231", "232", "233", "234", "235", "236", "237", "238", "239", _
         "241", "242", "243", "244", "247", "248", "249", "251", "252", "253"})
        ' for "宜蘭縣"
        _postalcode.Add(New String() {"260", "261", "262", "263", "264", "265", "266", "267", _
         "268", "269", "270", "272"})
        ' for "新竹市"
        _postalcode.Add(New String() {"300"})
        ' for "新竹縣"
        _postalcode.Add(New String() {"302", "303", "304", "305", "306", "307", "308", "310", _
         "311", "312", "313", "314", "315"})
        ' for "桃園縣"
        _postalcode.Add(New String() {"320", "324", "325", "326", "327", "328", "330", "333", _
         "334", "335", "336", "337", "338"})
        ' for "苗栗縣"
        _postalcode.Add(New String() {"350", "351", "352", "353", "354", "356", "357", _
         "358", "360", "361", "362", "363", "364", "365", "366", "367", "368", "369"})
        ' for "臺中市"
        _postalcode.Add(New String() {"400", "401", "402", "403", "404", "406", "407", "408", "411", "412", "413", "414", "420", "421", "422", "423", _
         "424", "426", "427", "428", "429", "432", "433", "434", "435", "436", "437", _
         "438", "439"})
        ' for "彰化縣"
        _postalcode.Add(New String() {"500", "502", "503", "504", "505", "506", "507", "508", _
         "509", "510", "511", "5112", "513", "514", "515", "516", "520", "521", "522", _
         "523", "524", "525", "526", "527", "528", "530"})
        ' for "南投縣"
        _postalcode.Add(New String() {"540", "541", "542", "544", "545", "546", "551", "552", _
         "553", "555", "556", "557", "558"})
        ' for "嘉義市"
        _postalcode.Add(New String() {"600"})
        ' for "嘉義縣"
        _postalcode.Add(New String() {"602", "603", "604", "605", "606", "607", "608", "611", _
         "612", "613", "614", "615", "616", "621", "622", "623", "624", "625"})
        ' for "雲林縣"
        _postalcode.Add(New String() {"630", "631", "632", "633", "634", "635", "636", "637", _
         "638", "640", "643", "646", "647", "648", "649", "651", "652", "653", "654", _
         "655"})
        ' for "臺南市"
        _postalcode.Add(New String() {"700", "701", "702", "703", "704", "708", "709", "710", "711", "712", "713", "714", "715", "716", "717", _
         "718", "719", "720", "721", "722", "723", "724", "725", "726", "727", "730", _
         "731", "732", "733", "734", "735", "736", "737", "741", "742", "743", "744", _
         "745"})
        ' for "高雄市"
        _postalcode.Add(New String() {"800", "801", "802", "803", "804", "805", "806", "807", _
         "811", "812", "813", "814", "815", "820", "821", "822", "823", "824", "825", _
         "826", "827", "828", "829", "830", "831", "832", "833", "840", "842", "843", _
         "844", "845", "846", "847", "848", "849", "851", "852"})
        ' for "澎湖縣"
        _postalcode.Add(New String() {"880", "881", "882", "883", "884", "885"})
        ' for "屏東縣"
        _postalcode.Add(New String() {"900", "901", "902", "903", "904", "905", "906", "907", _
         "908", "909", "911", "912", "913", "920", "921", "922", "923", "924", "925", _
         "926", "927", "928", "929", "931", "932", "940", "941", "942", "943", "944", _
         "945", "946", "947"})
        ' for "臺東縣"
        _postalcode.Add(New String() {"950", "951", "952", "953", "954", "955", "956", "957", _
         "958", "959", "961", "962", "963", "964", "965", "966"})
        ' for "花蓮縣"
        _postalcode.Add(New String() {"970", "971", "972", "973", "974", "975", "976", "977", _
         "978", "979", "981", "982", "983"})
        ' for "金門縣"
        _postalcode.Add(New String() {"890", "891", "892", "893", "894", "896"})
        ' for "連江縣"
        _postalcode.Add(New String() {"209", "210", "211", "212"})
        ' for "南海諸島"
        _postalcode.Add(New String() {"817", "819", "290"})
        ' for "釣魚台列嶼"
        _postalcode.Add(New String() {"290"})

    End Sub

End Class
