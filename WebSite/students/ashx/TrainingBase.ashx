<%@ WebHandler Language="C#" Class="TrainingBase" %>

using System;
using System.Web;

public class TrainingBase : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string provinceCode = context.Request["provinceCode"];
        BLL.TrainingBaseBLL trainingBaseBLL = new BLL.TrainingBaseBLL();
        System.Collections.Generic.List<Model.TrainingBaseModel> list = new System.Collections.Generic.List<Model.TrainingBaseModel>();
        list = trainingBaseBLL.getHospitalNameListModel(provinceCode);
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}