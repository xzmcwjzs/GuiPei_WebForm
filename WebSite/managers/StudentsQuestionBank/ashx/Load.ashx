<%@ WebHandler Language="C#" Class="Load" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;
using System.Web.Script.Serialization;

public class Load : IHttpHandler {
    TiKuResultBLL bll = new TiKuResultBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string SubjectCode = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["SubjectCode"]);
        string StudentsName = "wangj";
        string TrainingBaseCode = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["TrainingBaseCode"]);

        System.Collections.Generic.List<Model.TiKuResultModel> list = new System.Collections.Generic.List<Model.TiKuResultModel>();
        list = bll.GetList(StudentsName,TrainingBaseCode,SubjectCode);
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}