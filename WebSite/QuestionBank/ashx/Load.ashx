<%@ WebHandler Language="C#" Class="Load" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;
using System.Web.Script.Serialization;

public class Load : IHttpHandler {
    NeiKeOptionBLL bll = new NeiKeOptionBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string code = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["code"]);

        System.Collections.Generic.List<Model.NeiKeOptionModel> list = new System.Collections.Generic.List<Model.NeiKeOptionModel>();
        list = bll.GetListByCode(code);
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