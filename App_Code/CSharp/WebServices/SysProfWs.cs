using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// SysProfWs 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class SysProfWs : System.Web.Services.WebService {

    public SysProfWs () {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    [WebMethod]
    public string getApplica(string AD_id)
    {
        EMPPLM.Logic.EMPCommon e = new EMPPLM.Logic.EMPCommon();
        DataTable dt = e.getApplica(AD_id);
        DataSet ds = dt.DataSet;

        return JsonConvert.SerializeObject(ds, Formatting.Indented);
    }
    
}
