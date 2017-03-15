<%@ WebHandler Language="C#" Class="GetData" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;
using System.Data;


public class GetData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        StudentsPersonalInformation2BLL bll = new StudentsPersonalInformation2BLL();
        StudentsPersonalInformation2Model model = new StudentsPersonalInformation2Model();
        string name = context.Request["name"];
        string jsonRes;
        DataTable dt = bll.GetDt(name);

        if (dt == null)
        {
            jsonRes = "";
        }
        else
        {
           jsonRes = JsonHelper.ToJson(dt);
        }
       
        context.Response.Write(jsonRes);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}