<%@ WebHandler Language="C#" Class="SkillRequirement" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using BLL;
using Model;
using Common;

public class SkillRequirement : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string dept_code = context.Request["DeptCode"];
        SkillRequirementBLL skillRequirementBLL = new SkillRequirementBLL();
        System.Collections.Generic.List<SkillRequirementModel> list = skillRequirementBLL.GetList(dept_code);
        string strJsonArr = new JavaScriptSerializer().Serialize(list);
        string strRes = "{'data':" + strJsonArr + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}