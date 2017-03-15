<%@ WebHandler Language="C#" Class="UpdateTeachers" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Web.Script.Serialization;
using System.Collections.Generic;


public class UpdateTeachers : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        DeptManagementBLL bll = new DeptManagementBLL();
        DeptManagementModel model = new DeptManagementModel();
        int i;
        int length = Convert.ToInt16(context.Request["length"]);
        List<string> IdList = new List<string>();
        List<string> TeachersNameList = new List<string>();
        List<string> TeachersRealNameList = new List<string>();

        for (i = 0; i < length; i++)
        {
            IdList.Add(context.Request["Id" + i]);
            TeachersNameList.Add(context.Request["Teachers" + i]);
            TeachersRealNameList.Add(context.Request["TeachersRealName" + i]);
        }

        if (bll.UpdateTeachers(length, IdList,TeachersNameList,TeachersRealNameList))
        {
            context.Response.Write("指导医师信息保存成功");
        }
        else
        {
            context.Response.Write("指导医师信息保存失败，请联系管理员");
        }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}