<%@ WebHandler Language="C#" Class="OutdeptApplication" %>

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
using Model;
public class OutdeptApplication : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string id = CommonFunc.SafeGetStringFromObj(context.Request["Id"]);
        StudentsRotaryInformation2BLL bll = new StudentsRotaryInformation2BLL();
        StudentsRotaryInformation2Model model = new StudentsRotaryInformation2Model();

        model.Id = id;
        model.OutdeptApplication = "1";

        if (bll.UpdateApplication(model))
        {
            context.Response.Write("申请出科考核成功，请耐心等待");
        }
        else
        {
            context.Response.Write("系统繁忙，请联系管理员");
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}