<%@ WebHandler Language="C#" Class="Dept" %>

using System;
using System.Web;

public class Dept : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        BLL.ProfessionalBaseDeptBLL professionalBaseDeptBLL = new BLL.ProfessionalBaseDeptBLL();
        System.Collections.Generic.List<Model.ProfessionalBaseDeptModel> list = new System.Collections.Generic.List<Model.ProfessionalBaseDeptModel>();
        list = professionalBaseDeptBLL.GetDeptList(ProfessionalBaseCode);
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