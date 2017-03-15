<%@ WebHandler Language="C#" Class="Handle" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;

public class Handle : IHttpHandler {
    BigMedicalRecordsBLL bll = new BigMedicalRecordsBLL();
    BigMedicalRecordsModel model = new BigMedicalRecordsModel();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string id = CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        string check = CommonFunc.SafeGetStringFromObj(context.Request["check"]);
        if (check == "尚未提交")
        {
            check = "已提交";
        }
        else
        {
            check = "已提交";
        }
        model.Id = id;
        model.RecordsStatus = check;
        if (bll.UpdateRecordsStatus(model))
        {
            context.Response.Write("Success");
            context.Response.End();
        }
        else
        {
            context.Response.Write("Error");
            context.Response.End();
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