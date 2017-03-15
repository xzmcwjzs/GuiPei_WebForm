<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    InDeptFellingBLL inDeptFellingBLL = new InDeptFellingBLL();
    public void ProcessRequest(HttpContext context)
    {
        //不让浏览器缓存
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        context.Response.AddHeader("pragma", "no-cache");
        context.Response.AddHeader("cache-control", "");
        context.Response.CacheControl = "no-cache";
        
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string students_name = context.Request["name"];
        string training_base_code = context.Request["training_base_code"];

        string rotary_dept = context.Request["rotary_dept"];

        int pageCount = inDeptFellingBLL.GetPageCount(pageSize, students_name, training_base_code, rotary_dept);
        int recordCount = inDeptFellingBLL.GetRecordCount(students_name, training_base_code, rotary_dept);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
        
               
        System.Collections.Generic.List<Model.InDeptFellingModel> list = new BLL.InDeptFellingBLL().GetPagedList(students_name, training_base_code, rotary_dept,pageIndex,pageSize);
        
        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
    }



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}