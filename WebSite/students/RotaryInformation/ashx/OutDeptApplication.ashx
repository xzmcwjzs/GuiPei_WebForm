<%@ WebHandler Language="C#" Class="OutDeptApplication" %>

using System;
using System.Web;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Common;
using BLL;
public class OutDeptApplication : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id = CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        string appli = "已申请出科考试";
        StudentsRotaryBLL studentsRotaryBLL = new StudentsRotaryBLL();
        string app = studentsRotaryBLL.GetApplication(id);
        if (app=="未申请出科考试")
        {
            if (studentsRotaryBLL.UpdateApplication(appli, id))
            {
                context.Response.Write("申请出科考试成功，请耐心等待");
                context.Response.End();
            }
            else {
                context.Response.Write("系统繁忙，请联系管理员");
                context.Response.End();
            }
            
        }
        else {

            context.Response.Write("您已申请出科考试，请勿重复提交");
            context.Response.End();
        }
        
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}