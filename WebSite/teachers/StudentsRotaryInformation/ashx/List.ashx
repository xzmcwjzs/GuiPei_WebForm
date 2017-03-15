<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    RotaryInformationJoinBLL bll = new RotaryInformationJoinBLL();
    RotaryInformationJoinModel model = new RotaryInformationJoinModel();
    
    public void ProcessRequest (HttpContext context) {
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
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        //name, sex, high_education, identity_type, send_unit, collaborative_unit, training_time, 
        //plan_training_time, rotary_begin_time, rotary_end_time, outdept_status
        string training_base_code = context.Request["tbcode"];
        string dept_code = context.Request["dcode"];
        string teachers_name = context.Request["teachers_name"];

        string name = context.Request["name"];
        string sex = context.Request["sex"];
        string high_education = context.Request["high_education"];
        string identity_type = context.Request["identity_type"];
        string send_unit = context.Request["send_unit"];
        string collaborative_unit = context.Request["collaborative_unit"];
        string training_time = context.Request["training_time"];
        string plan_training_time = context.Request["plan_training_time"];
        string rotary_begin_time = context.Request["rotary_begin_time"];
        string rotary_end_time=context.Request["rotary_end_time"];
        string outdept_status = context.Request["outdept_status"];


        int pageCount = bll.GetPageCount(pageSize, training_base_code,dept_code,teachers_name,
            name, sex, high_education,identity_type, send_unit, collaborative_unit, training_time, plan_training_time,rotary_begin_time,rotary_end_time,outdept_status);
        int recordCount = bll.GetRecordCount(training_base_code,dept_code,teachers_name,
            name, sex, high_education,identity_type, send_unit, collaborative_unit, training_time, plan_training_time,rotary_begin_time,rotary_end_time,outdept_status);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.RotaryInformationJoinModel> list = new BLL.RotaryInformationJoinBLL().GetPagedList(training_base_code, dept_code, teachers_name,
            name, sex, high_education,identity_type, send_unit, collaborative_unit, training_time, plan_training_time,rotary_begin_time,rotary_end_time,outdept_status, pageIndex, pageSize);

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