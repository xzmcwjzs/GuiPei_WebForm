<%@ WebHandler Language="C#" Class="RotaryTime" %>

using System;
using System.Web;
using Common;
using BLL;
using Model;
using System.Collections.Generic;

public class RotaryTime : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name = CommonFunc.SafeGetStringFromObj(context.Request.Form["name"]);
        string training_base_code = CommonFunc.SafeGetStringFromObj(context.Request.Form["training_base_code"]);
        string professional_base_code = CommonFunc.SafeGetStringFromObj(context.Request.Form["professional_base_code"]);
        StudentsRotaryBLL studentsRotaryBLL = new StudentsRotaryBLL();
        List<Model.StudentsRotaryModel> list = new List<Model.StudentsRotaryModel>();
        list = studentsRotaryBLL.getRotaryTimeList(name, training_base_code,professional_base_code);
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}