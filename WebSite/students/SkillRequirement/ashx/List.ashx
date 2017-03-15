<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using BLL;


public class List : IHttpHandler {

    SkillRequirement2BLL skillRequirement2BLL = new SkillRequirement2BLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"].ToString();
        string TrainingBaseCode = context.Request["TrainingBaseCode"].ToString();
        string DeptName = context.Request["DeptName"].ToString();
        string SkillName = context.Request["SkillName"].ToString();
        string RequiredNum = context.Request["RequiredNum"].ToString();
        string MasterDegree = context.Request["MasterDegree"].ToString();

        int pageCount = skillRequirement2BLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, SkillName, RequiredNum, MasterDegree);
        int recordCount = skillRequirement2BLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, SkillName, RequiredNum, MasterDegree);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.SkillRequirement2Model> list = new BLL.SkillRequirement2BLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, SkillName, RequiredNum, MasterDegree, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}