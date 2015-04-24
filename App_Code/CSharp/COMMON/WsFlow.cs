using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SYS.Logic
{
    /// <summary>
    /// WsFlow 的摘要描述
    /// </summary>
    public class WsFlow
    {
        public String Orgcode { get; set; }
        public String DepartId { get; set; }
        public String ApplyIdcard { get; set; }
        public String ApplyName { get; set; }
        public String ApplyPosid { get; set; }
        public String Memo { get; set; }
        public String FormId { get; set; }

        public WsFlow()
        {
            //
            // TODO: 在這裡新增建構函式邏輯
            //
        }
    }
}