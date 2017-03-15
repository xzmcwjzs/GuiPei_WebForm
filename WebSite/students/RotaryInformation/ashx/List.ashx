<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;
public class List : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //不让浏览器缓存
        context.Response.Buffer = true;
        context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        context.Response.AddHeader("pragma", "no-cache");
        context.Response.AddHeader("cache-control", "");
        context.Response.CacheControl = "no-cache";
        context.Response.ContentType = "text/plain";
        string strDo = context.Request.Params["do"];//获得操作类型
        switch (strDo)
        {
            case "l"://处理分页数据
                GetPagedList(context);
                break;
            case "d"://处理删除业务

                break;
            case "a"://处理新增业务
                break;
            case "m"://处理修改业务

                break;


        }
    }
    /// <summary>
    /// 根据页码获得数据
    /// </summary>
    /// <param name="context"></param>
    void GetPagedList(HttpContext context)
    {
        string strPi = context.Request["pi"];
        string students_name = context.Request["name"];
        string training_base_code = context.Request["training_base_code"];
        
        string rotary_dept=context.Request["rotary_dept"];
        string instructor = context.Request["instructor"];
        string rotary_begin_time = context.Request["rotary_begin_time"];
        string rotary_end_time = context.Request["rotary_end_time"];
        
        int intPi = 0;
        if (!int.TryParse(strPi, out intPi))//将字符串页码转成整形页码，如果失败，设为1
        {
            intPi = 1;
        }

        int rowCount = 0;
        int pageCount = 0;
        System.Collections.Generic.List<Model.StudentsRotaryModel> list = new BLL.StudentsRotaryBLL().GetPagedList(students_name,training_base_code,rotary_dept,instructor,rotary_begin_time,rotary_end_time,intPi, 15, out rowCount, out pageCount);



        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'rowCount':" + rowCount + ",'pageCount':" + pageCount + "}";

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