<%@ WebHandler Language="C#" Class="Instructor" %>

using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Common;

public class Instructor : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string trainingbaseCode = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["trainingbaseCode"]);
        string professionalbaseCode = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["professionalbaseCode"]);
        string type = CommonFunc.SafeGetStringFromObj(context.Request.QueryString["type"]);
        BLL.LoginBLL loginBLL = new BLL.LoginBLL();
        List<Model.LoginModel> list = new List<Model.LoginModel>();
        list = loginBLL.getTeachersNameList(trainingbaseCode, professionalbaseCode, type);
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