<%@ WebHandler Language="C#" Class="DeptCodeByPB" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class DeptCodeByPB : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        BLL.ProfessionalBaseDeptBLL ProfessionalBaseDeptBLL = new ProfessionalBaseDeptBLL();
        Model.ProfessionalBaseDeptModel professionalBaseDeptModel = new ProfessionalBaseDeptModel();
        string professionalBaseCode = context.Request["professionalBaseCode"];
        List<ProfessionalBaseDeptModel> list = ProfessionalBaseDeptBLL.GetDeptList(professionalBaseCode);
        string jsonStr = new JavaScriptSerializer().Serialize(list);
        string jsonRes = "{\"RotaryDept\":" + jsonStr + "}";
        context.Response.Write(jsonRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}