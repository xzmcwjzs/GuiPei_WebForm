<%@ WebHandler Language="C#" Class="City" %>

using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

public class City : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string father=context.Request["father"];

        BLL.CityBLL cityBLL = new BLL.CityBLL();
        List<Model.CityModel> list = new List<Model.CityModel>();
        list = cityBLL.getListModel(father);
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