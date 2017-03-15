<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class List : IHttpHandler {
    BedManagementBLL bedManagementBLL = new BedManagementBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string students_name = context.Request["name"];
        string training_base_code = context.Request["training_base_code"];
        string dept_name = context.Request["dept_name"];
        string patient_name = context.Request["patient_name"];
        string bed_id = context.Request["bed_id"];
        string bed_status = context.Request["bed_status"];
        string room_id = context.Request["room_id"];
        string building_id = context.Request["building_id"];

        int pageCount = bedManagementBLL.GetPageCount(pageSize, students_name, training_base_code, dept_name,patient_name,bed_id,bed_status,room_id,building_id);
        int recordCount = bedManagementBLL.GetRecordCount(students_name, training_base_code, dept_name, patient_name, bed_id, bed_status, room_id, building_id);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.BedManagementModel> list = new BLL.BedManagementBLL().GetPagedList(students_name, training_base_code, dept_name, patient_name, bed_id, bed_status, room_id, building_id, pageIndex, pageSize);

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