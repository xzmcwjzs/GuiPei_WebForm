<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;
using System.Collections.Generic;

public class Add : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int i;
        List<string> DeptNameList = new List<string>();
        List<string> DeptCodeList = new List<string>();
        List<string> DeptTimeList = new List<string>();
        List<string> RealTimeList = new List<string>();
        List<string> IsRequiredList = new List<string>();
        List<string> SqlList = new List<string>();
        DeptManagementModel model = new DeptManagementModel();
        DeptManagementBLL bll=new DeptManagementBLL();

        int trLength = Convert.ToInt16(context.Request["trLength"]);
        int TotalLength = Convert.ToInt16(context.Request["TotalLength"]);
        string ManagersName = context.Request["ManagersName"];
        string ManagersRealName = context.Request["ManagersRealName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string TrainingBaseName = context.Request["TrainingBaseName"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        string TrainingTime = context.Request["TrainingTime"];
        string TotalDeptTime = context.Request["TotalDeptTime"];
        string TotalRealTime = context.Request["TotalRealTime"];
        for (i = 0; i < TotalLength; i++)
        {
            if (context.Request["DeptName" + i] != null)
            {
                DeptNameList.Add(context.Request["DeptName" + i]);
                DeptCodeList.Add(context.Request["DeptCode" + i]);
                RealTimeList.Add(context.Request["RealTime" + i]);
                DeptTimeList.Add(context.Request["DeptTime" + i]);
                IsRequiredList.Add(context.Request["IsRequired" + i]);
            }
            
        }
        model.ManagersName = ManagersName;
        model.ManagersRealName = ManagersRealName;
        model.TrainingBaseCode = TrainingBaseCode;
        model.TrainingBaseName = TrainingBaseName;
        model.ProfessionalBaseCode = ProfessionalBaseCode;
        model.ProfessionalBaseName = ProfessionalBaseName;
        model.TrainingTime = TrainingTime;
        model.TotalDeptTime = TotalDeptTime;
        model.TotalRealTime = TotalRealTime;

        if (bll.CheckDept(TrainingTime, TrainingBaseCode, ProfessionalBaseCode))
        {
            if(bll.Delete(TrainingTime,TrainingBaseCode,ProfessionalBaseCode)){

                if (bll.Add(trLength, model, DeptNameList, DeptCodeList, DeptTimeList, RealTimeList, IsRequiredList))
                {
                    context.Response.Write("轮转科室信息保存成功");
                }
                else
                {
                    context.Response.Write("轮转科室信息保存失败，请联系管理员");
                }
            }
            else
            {
                context.Response.Write("系统繁忙，请联系管理员");
            }

        }
        else
        {
            if (bll.Add(trLength, model, DeptNameList, DeptCodeList, DeptTimeList, RealTimeList, IsRequiredList))
            {
                context.Response.Write("轮转科室信息保存成功");
            }
            else
            {
                context.Response.Write("轮转科室信息保存失败，请联系管理员");
            }
        }
        
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}