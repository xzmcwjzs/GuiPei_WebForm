<%@ WebHandler Language="C#" Class="loadAllData" %>

using System;
using System.Web;
using Common;
using Model;
using BLL;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class loadAllData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        MedicalErrorModel medicalErrorModel = new MedicalErrorModel();
        MedicalErrorBLL medicalErrorBLL = new MedicalErrorBLL();
        string id = context.Request["id"] ?? "";
        List<MedicalErrorModel> list = new List<MedicalErrorModel>();
        list = medicalErrorBLL.GetListById(id);
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