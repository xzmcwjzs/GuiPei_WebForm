<%@ WebHandler Language="C#" Class="ProfessionalBase" %>

using System;
using System.Web;
using BLL;

public class ProfessionalBase : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        BLL.ProfessionalBaseBLL professionalBaseBLL = new BLL.ProfessionalBaseBLL();
        System.Collections.Generic.List<Model.ProfessionalBaseModel> list = new System.Collections.Generic.List<Model.ProfessionalBaseModel>();
        list = professionalBaseBLL.getListModel();
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