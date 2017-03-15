<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

public class Add : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        SkillRequirement2Model skillRequirement2Model = new SkillRequirement2Model();
        SkillRequirement2BLL skillRequirement2BLL = new SkillRequirement2BLL();
        skillRequirement2Model.Id = Guid.NewGuid().ToString();
        skillRequirement2Model.StudentsRealName = context.Request["StudentsRealName"];
        skillRequirement2Model.StudentsName = context.Request["StudentsName"];
        skillRequirement2Model.TrainingBaseCode = context.Request["TrainingBaseCode"];
        skillRequirement2Model.TrainingBaseName = context.Request["TrainingBaseName"];
        skillRequirement2Model.ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        skillRequirement2Model.ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        skillRequirement2Model.DeptCode = context.Request["DeptCode"];
        skillRequirement2Model.DeptName = context.Request["DeptName"];
        skillRequirement2Model.RegisterDate = context.Request["RegisterDate"];
        skillRequirement2Model.Writor = context.Request["Writor"];
        skillRequirement2Model.TeacherCheck = "未通过";
        skillRequirement2Model.KzrCheck = "未通过";
        skillRequirement2Model.BaseCheck = "未通过";
        skillRequirement2Model.ManagerCheck = "未通过";
        skillRequirement2Model.TeacherId = context.Request["TeacherId"];
        skillRequirement2Model.TeacherName = context.Request["TeacherName"];
        skillRequirement2Model.RequiredNum = context.Request["RequiredNum"];
        skillRequirement2Model.MasterDegree = context.Request["MasterDegree"];
        skillRequirement2Model.Comment = context.Request["Comment"];

        skillRequirement2Model.SkillName = context.Request["SkillName"];
        skillRequirement2Model.PatientName = context.Request["PatientName"];
        skillRequirement2Model.CaseNum = context.Request["CaseNum"];
        skillRequirement2Model.IsOk = context.Request["IsOk"];
        skillRequirement2Model.OperateDate = context.Request["OperateDate"];
        if (skillRequirement2BLL.Add(skillRequirement2Model))
        {
            context.Response.Write("addSuccess");
        }
        else
        {
            context.Response.Write("addError");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}