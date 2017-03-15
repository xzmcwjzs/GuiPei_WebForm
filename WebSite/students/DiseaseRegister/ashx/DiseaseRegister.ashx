<%@ WebHandler Language="C#" Class="DiseaseRegister" %>

using System;
using System.Collections.Generic;
using System.Web;
using Model;
using BLL;
using System.Web.Script.Serialization;

public class DiseaseRegister : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string dept_code = context.Request["rotary_dept_code"];
        DiseaseRegisterBLL diseaseRegisterBLL=new DiseaseRegisterBLL();
        List<DiseaseRegisterModel> list = diseaseRegisterBLL.GetList(dept_code);
        string strJsonArr=new JavaScriptSerializer().Serialize(list);
        string strRes = "{'data':" + strJsonArr + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}