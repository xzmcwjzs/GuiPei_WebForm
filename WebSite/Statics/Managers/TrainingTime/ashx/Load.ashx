<%@ WebHandler Language="C#" Class="Load" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;
using System.Web.Script.Serialization;
using System.Data;


public class Load : IHttpHandler {
    StudentsPersonalInformation2BLL bll=new StudentsPersonalInformation2BLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain"; 
        string Name = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["Name"]);
        string TrainingBaseCode = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["TrainingBaseCode"]);

        DataTable dt = new DataTable();
        dt = bll.StaticsTT(TrainingBaseCode);
        string jsonRes = JsonHelper.ToJson(dt);

        context.Response.Write(jsonRes);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}