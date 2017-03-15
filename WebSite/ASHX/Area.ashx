<%@ WebHandler Language="C#" Class="Area" %>

using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

public class Area : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string father = context.Request["father"];

        BLL.AreaBLL areaBLL = new BLL.AreaBLL();
        List<Model.AreaModel> list = new List<Model.AreaModel>();
        list = areaBLL.getListModel(father);
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}