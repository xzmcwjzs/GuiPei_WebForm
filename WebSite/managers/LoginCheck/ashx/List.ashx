<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;

public class List : IHttpHandler {
    LoginBLL bll = new LoginBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string RealName = context.Request["RealName"];
        string Type = context.Request["Type"];
        string RegisterDate = context.Request["RegisterDate"];
      
        int pageCount = bll.GetPageCount(pageSize, TrainingBaseCode, RealName, Type, RegisterDate);
        int recordCount = bll.GetRecordCount(TrainingBaseCode, RealName, Type, RegisterDate);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.LoginModel> list = new BLL.LoginBLL().GetPagedList(TrainingBaseCode, RealName, Type, RegisterDate, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}