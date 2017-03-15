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
        SkillRequirement2Model skillRequirement2Model = new SkillRequirement2Model();
        SkillRequirement2BLL skillRequirement2BLL = new SkillRequirement2BLL();
        string id = context.Request["id"] ?? "";
        List<SkillRequirement2Model> list = new List<SkillRequirement2Model>();
        list = skillRequirement2BLL.GetListById(id);
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