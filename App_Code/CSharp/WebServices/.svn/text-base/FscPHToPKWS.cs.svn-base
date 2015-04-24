using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// FscPHToPKWS 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class FscPHToPKWS : System.Web.Services.WebService {

    public FscPHToPKWS () {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    [WebMethod]
    public void RunBatch(String orgcode, String departId, String idCard, String sdate, String edate) {
                
        FSC.Logic.FSC4202 bll = new FSC.Logic.FSC4202();
        bll.Transfer(orgcode, departId, idCard, idCard, sdate, edate, true); 

    }
    
}
