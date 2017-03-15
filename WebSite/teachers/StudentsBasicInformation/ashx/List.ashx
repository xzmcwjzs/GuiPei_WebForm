<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    StudentsPersonalInformation2BLL bll = new StudentsPersonalInformation2BLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string training_base_code = context.Request["tbcode"];
        string professional_base_code = context.Request["professional_base_code"];

        string name = context.Request["name"];
        string sex = context.Request["sex"];
        string minzu = context.Request["minzu"];
        string high_education = context.Request["high_education"];
        string high_school = context.Request["high_school"];
        string identity_type = context.Request["identity_type"];
        string send_unit = context.Request["send_unit"];
        string collaborative_unit = context.Request["collaborative_unit"];
        string training_time = context.Request["training_time"];
        string plan_training_time = context.Request["plan_training_time"];

        int pageCount = bll.CommonGetPageCount(pageSize, training_base_code, professional_base_code, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time);
        int recordCount = bll.CommonGetRecordCount(training_base_code, professional_base_code, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.StudentsPersonalInformation2Model> list = new BLL.StudentsPersonalInformation2BLL().CommonGetPagedList(training_base_code, professional_base_code, name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time, pageIndex, pageSize);

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