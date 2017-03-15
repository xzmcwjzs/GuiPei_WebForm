<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    AttendanceManageBLL attendanceManageBLL = new AttendanceManageBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string AttendanceCategory = context.Request["AttendanceCategory"];
        string FirstDate = context.Request["FirstDate"];
        string LastDate = context.Request["LastDate"];
        string Days = context.Request["Days"];

        int pageCount = attendanceManageBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, AttendanceCategory, FirstDate,LastDate, Days);
        int recordCount = attendanceManageBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, AttendanceCategory, FirstDate, LastDate, Days);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.AttendanceManagementModel> list = new BLL.AttendanceManageBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, AttendanceCategory, FirstDate, LastDate, Days, pageIndex, pageSize);

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