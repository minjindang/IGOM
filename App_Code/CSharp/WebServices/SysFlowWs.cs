using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Transactions;
using System.Text;
using System.Data;

/// <summary>
/// FlowWs 的摘要描述
/// </summary>
[WebService(Namespace = "http://IGOM.SYS.Flow/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class SysFlowWs : System.Web.Services.WebService
{
    public SysFlowWs () {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    /// <summary>
    /// 表單流程介接
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    [WebMethod]
    public string SYS3107(String json)
    {
        SYS.Logic.WsMessage msg = new SYS.Logic.WsMessage();
        SYS.Logic.Flow f = new SYS.Logic.Flow();

        try
        {
            SYS.Logic.WsFlow wf = JsonConvert.DeserializeObject<SYS.Logic.WsFlow>(json);

            using (TransactionScope scope = new TransactionScope())
            {

                f.FlowId = new SYS.Logic.FlowId().GetFlowId(f.Orgcode, wf.FormId);
                f.Orgcode = wf.Orgcode;
                f.DepartId = wf.DepartId;
                f.ApplyIdcard = wf.ApplyIdcard;
                f.ApplyName = wf.ApplyName;
                f.ApplyPosid = wf.ApplyPosid;
                f.Reason = wf.Memo;
                f.FormId = wf.FormId;

                SYS.Logic.CommonFlow.AddFlow(f);
                scope.Complete();
            }
            msg.isSucess = "Y";
        }
        catch (FlowException e)
        {
            msg.isSucess = "N";
            msg.message = e.ToString();
        }        
        catch (Exception e)
        {
            msg.isSucess = "N";
            msg.message = "系統發生錯誤!";
        }
        return JsonConvert.SerializeObject(msg);
    }

    /// <summary>
    /// 取得待辦、待審之表單筆數
    /// </summary>
    /// <param name="AD_id"></param>
    /// <returns></returns>
    [WebMethod]
    public string getNextCount(string AD_id)
    {
        FSC.Logic.FSC0101 bll = new FSC.Logic.FSC0101();
        return bll.GetNextCount(AD_id).ToString();
    }

    /// <summary>
    /// 取得請假資料
    /// </summary>
    /// <param name="AD_id"></param>
    /// <returns></returns>
    [WebMethod]
    public string getSysFlowData(string AD_id, string yyymm)
    {
        FSC.Logic.FSC0101 bll = new FSC.Logic.FSC0101();
        DataTable dt = new DataTable();
        dt = bll.getLeaveMainData(AD_id, yyymm);
        DataSet ds = dt.DataSet;

        return JsonConvert.SerializeObject(ds, Formatting.Indented);
    }
}
