<%@ WebHandler Language="C#" Class="StudentsBasicList" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class StudentsBasicList : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        StudentsPersonalInformation2BLL bll = new StudentsPersonalInformation2BLL();
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;

        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];

        string StudentsRealName = context.Request["StudentsRealName"];
        string Sex = context.Request["Sex"];
        string MinZu = context.Request["MinZu"];
        string HighEducation = context.Request["HighEducation"];
        string HighSchool = context.Request["HighSchool"];
        string IdentityType = context.Request["IdentityType"];
        string SendUnit = context.Request["SendUnit"];
        string CollaborativeUnit = context.Request["CollaborativeUnit"];
        string TrainingTime = context.Request["TrainingTime"];
        string PlanTrainingTime = context.Request["PlanTrainingTime"];

        int pageCount = bll.CommonGetPageCount(pageSize, TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime);
        int recordCount = bll.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.StudentsPersonalInformation2Model> list = new BLL.StudentsPersonalInformation2BLL().CommonGetPagedList(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, pageIndex, pageSize);

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