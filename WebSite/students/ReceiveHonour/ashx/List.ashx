<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Common;

public class List : IHttpHandler {
    ReceiveHonourBLL receiveHonourBLL = new ReceiveHonourBLL();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsName = context.Request["StudentsName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string DeptName = context.Request["DeptName"];
        string HonourName = context.Request["HonourName"];
        string HonourDepartment = context.Request["HonourDepartment"];
        string HonourDate = context.Request["HonourDate"];

        int pageCount = receiveHonourBLL.GetPageCount(pageSize, StudentsName, TrainingBaseCode, DeptName, HonourName, HonourDepartment, HonourDate);
        int recordCount = receiveHonourBLL.GetRecordCount(StudentsName, TrainingBaseCode, DeptName, HonourName, HonourDepartment, HonourDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.ReceiveHonourModel> list = new BLL.ReceiveHonourBLL().GetPagedList(StudentsName, TrainingBaseCode, DeptName, HonourName, HonourDepartment, HonourDate, pageIndex, pageSize);

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