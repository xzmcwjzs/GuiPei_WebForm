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
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string RealName = context.Request["RealName"];
        string ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        string DeptName = context.Request["DeptName"];
        
        string AppointBeginTime = context.Request["AppointBeginTime"];
        string AppointEndTime = context.Request["AppointEndTime"];

        string IsPass = context.Request["IsPass"];

        int pageCount = basesAppointInformationBLL.managersGetPageCount(pageSize, TrainingBaseCode, RealName,ProfessionalBaseName,DeptName,AppointBeginTime,AppointEndTime,IsPass);
        int recordCount = basesAppointInformationBLL.managersGetRecordCount(TrainingBaseCode, RealName, ProfessionalBaseName, DeptName, AppointBeginTime, AppointEndTime, IsPass);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.TeachersAppointInformationModel> list = new BLL.TeachersAppointInformationBLL().managersGetPagedList(TrainingBaseCode, RealName, ProfessionalBaseName, DeptName, AppointBeginTime, AppointEndTime, IsPass, pageIndex, pageSize);

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