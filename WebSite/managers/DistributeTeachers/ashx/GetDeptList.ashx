<%@ WebHandler Language="C#" Class="GetDeptList" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Web.Script.Serialization;
using System.Collections.Generic;


public class GetDeptList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        DeptManagementBLL bll = new DeptManagementBLL();
        DeptManagementModel model = new DeptManagementModel();
        
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string TrainingTime = context.Request["TrainingTime"];
        string strJson;
        List<DeptManagementModel> list = bll.GetDeptList(TrainingTime, TrainingBaseCode, ProfessionalBaseCode);
        if (list == null)
        {
            strJson = "";
        }
        else
        {
            strJson = new JavaScriptSerializer().Serialize(list);
        }
       

        context.Response.Write(strJson);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}