<%@ WebHandler Language="C#" Class="Update" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

public class Update : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        SkillRequirement2Model skillRequirement2Model = new SkillRequirement2Model();
        SkillRequirement2BLL skillRequirement2BLL = new SkillRequirement2BLL();
        skillRequirement2Model.Id = context.Request["Id"]; ;
        
        skillRequirement2Model.Comment = context.Request["Comment"];

        skillRequirement2Model.SkillName = context.Request["SkillName"];
        skillRequirement2Model.PatientName = context.Request["PatientName"];
        skillRequirement2Model.CaseNum = context.Request["CaseNum"];
        skillRequirement2Model.IsOk = context.Request["IsOk"];
        skillRequirement2Model.OperateDate = context.Request["OperateDate"];
        if (skillRequirement2BLL.Update(skillRequirement2Model))
        {
            context.Response.Write("updateSuccess");
        }
        else
        {
            context.Response.Write("updateError");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}