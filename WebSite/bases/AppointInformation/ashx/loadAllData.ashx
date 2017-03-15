<%@ WebHandler Language="C#" Class="loadAllData" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Collections.Generic;
using System.Web.Script.Serialization;


public class loadAllData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        TeachersAppointInformationModel model = new TeachersAppointInformationModel();
        TeachersAppointInformationBLL bll = new TeachersAppointInformationBLL();
        string id = context.Request["id"] ?? "";
        List<TeachersAppointInformationModel> list = new List<TeachersAppointInformationModel>();
        list = bll.SelectListById(id);
        string jsonStr = new JavaScriptSerializer().Serialize(list);
        string strRes = "{'data':" + jsonStr + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}