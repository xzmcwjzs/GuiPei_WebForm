<%@ WebHandler Language="C#" Class="StudentsRotaryList" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using Common;

public class StudentsRotaryList : IHttpHandler {


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        RotaryInformationJoinBLL rotaryInformationJoinBLL = new RotaryInformationJoinBLL();
        
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

        string ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]); 
        string RotaryBeginTime = context.Request["RotaryBeginTime"];
        string RotaryEndTime = context.Request["RotaryEndTime"];
        string OutdeptStatus = context.Request["OutdeptStatus"];

        int pageCount = rotaryInformationJoinBLL.CommonGetPageCount(pageSize, TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus);
        int recordCount = rotaryInformationJoinBLL.CommonGetRecordCount(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime, DeptName, ProfessionalBaseName, TeachersRealName, RotaryBeginTime, RotaryEndTime, OutdeptStatus);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.RotaryInformationJoinModel> list = new BLL.RotaryInformationJoinBLL().CommonGetPagedList(TrainingBaseCode, ProfessionalBaseCode, StudentsRealName, Sex, MinZu, HighEducation, HighSchool, IdentityType, SendUnit, CollaborativeUnit, TrainingTime, PlanTrainingTime,DeptName,ProfessionalBaseName,TeachersRealName,RotaryBeginTime,RotaryEndTime,OutdeptStatus, pageIndex, pageSize);

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