<%@ WebHandler Language="C#" Class="Update" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;

public class Update : IHttpHandler
{
    BigMedicalRecordsBLL bll = new BigMedicalRecordsBLL();
    BigMedicalRecordsModel model = new BigMedicalRecordsModel();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string id = CommonFunc.SafeGetStringFromObj(context.Request["id"]);
        string XZZhenDuan = CommonFunc.SafeGetStringFromObj(context.Request["XZZhenDuan"]);
        string Reviewer = CommonFunc.SafeGetStringFromObj(context.Request["Reviewer"]);
        string ReviewerDate = CommonFunc.SafeGetStringFromObj(context.Request["ReviewerDate"]);
        model.Id = id;
        model.XZZhenDuan = XZZhenDuan;
        model.Reviewer = Reviewer;
        model.ReviewerDate = ReviewerDate;

        if (bll.UpdateRedirect(model))
        {
            context.Response.Write("updateSuccess");
            context.Response.End();
        }
        else
        {
            context.Response.Write("updateError");
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