<%@ WebHandler Language="C#" Class="SurgeryName" %>

using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Common;
using BLL;
public class SurgeryName : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        ICD9SurgeryBLL iCD9SurgeryBLL = new ICD9SurgeryBLL();

        //List<Model.ICD9SurgeryModel> list = new List<Model.ICD9SurgeryModel>();
        //list = iCD9SurgeryBLL.GetList();
        //JavaScriptSerializer jss = new JavaScriptSerializer();
        //string json = jss.Serialize(list);
        //context.Response.Write(json);

        DataTable dt = iCD9SurgeryBLL.GetDtSurgeryName();
        string jsonStr = JsonHelper.ToJson(dt);
        context.Response.Write(jsonStr);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}