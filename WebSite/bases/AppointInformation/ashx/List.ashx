<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler
{
    TeachersAppointInformationBLL basesAppointInformationBLL = new TeachersAppointInformationBLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string BasesName = context.Request["BasesName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];

        string AppointBeginTime = context.Request["AppointBeginTime"];
        string AppointEndTime = context.Request["AppointEndTime"];

        string IsPass = context.Request["IsPass"];

        int pageCount = basesAppointInformationBLL.GetBasesPageCount(pageSize, BasesName, TrainingBaseCode, ProfessionalBaseCode,AppointBeginTime,AppointEndTime,IsPass);
        int recordCount = basesAppointInformationBLL.GetBasesRecordCount(BasesName, TrainingBaseCode, ProfessionalBaseCode, AppointBeginTime, AppointEndTime, IsPass);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.TeachersAppointInformationModel> list = new BLL.TeachersAppointInformationBLL().GetBasesPagedList(BasesName, TrainingBaseCode, ProfessionalBaseCode, AppointBeginTime, AppointEndTime, IsPass, pageIndex, pageSize);

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