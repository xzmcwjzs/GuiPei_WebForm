<%@ WebHandler Language="C#" Class="loadAllData" %>

using System;
using System.Web;
using Common;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class loadAllData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        ReceiveHonourModel receiveHonourModel = new ReceiveHonourModel();
        ReceiveHonourBLL receiveHonourBLL = new ReceiveHonourBLL();
        string id = context.Request["id"] ?? "";
        List<ReceiveHonourModel> list = new List<ReceiveHonourModel>();
        list = receiveHonourBLL.GetListById(id);
        string jsonStr = new JavaScriptSerializer().Serialize(list);
        string strRes = "{'data':" + jsonStr + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}