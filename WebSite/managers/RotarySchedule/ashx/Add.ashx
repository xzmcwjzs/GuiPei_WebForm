<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using Model;
using BLL;
using Common;
using System.Collections.Generic;

public class Add : IHttpHandler
{

    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "text/plain";
        int i;
        List<string> DeptNameList = new List<string>();
        List<string> DeptCodeList = new List<string>();
        List<string> BeginTimeList = new List<string>();
        List<string> EndTimeList = new List<string>();
        List<string> DaysList = new List<string>();
        List<string> SchemeOrder = new List<string>();
        RotaryScheduleModel model = new RotaryScheduleModel();
        RotaryScheduleBLL bll = new RotaryScheduleBLL();

        int SelectLength = Convert.ToInt16(context.Request["SelectLength"]);
        string ManagersName = context.Request["ManagersName"];
        string ManagersRealName = context.Request["ManagersRealName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string TrainingBaseName = context.Request["TrainingBaseName"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string ProfessionalBaseName = context.Request["ProfessionalBaseName"];
        string TrainingTime = context.Request["TrainingTime"];
        string TotalRealTime = context.Request["TotalRealTime"];
        string RotaryBeginTime = context.Request["RotaryBeginTime"];
        string RotaryEndTime = context.Request["RotaryEndTime"];
        for (i = 0; i < SelectLength; i++)
        {

            BeginTimeList.Add(context.Request["BeginTimeList" + i]);
            EndTimeList.Add(context.Request["EndTimeList" + i]);
            DaysList.Add(context.Request["DaysList" + i]);
            DeptCodeList.Add(context.Request["DeptCodeList" + i]);
            DeptNameList.Add(context.Request["DeptNameList" + i]);
            SchemeOrder.Add(context.Request["SchemeOrder" + i]);
        }
        model.ManagersName = ManagersName;
        model.ManagersRealName = ManagersRealName;
        model.TrainingBaseCode = TrainingBaseCode;
        model.TrainingBaseName = TrainingBaseName;
        model.ProfessionalBaseCode = ProfessionalBaseCode;
        model.ProfessionalBaseName = ProfessionalBaseName;
        model.TrainingTime = TrainingTime;
        model.TotalRealTime = TotalRealTime;
        model.RotaryBeginTime = RotaryBeginTime;
        model.RotaryEndTime = RotaryEndTime;

        if (bll.CheckScheme(TrainingTime, TrainingBaseCode, ProfessionalBaseCode))
        {
           if (!bll.Delete(TrainingTime, TrainingBaseCode, ProfessionalBaseCode))
            {
                context.Response.Write("轮转科室信息更新失败，请联系管理员");
                return;
            }
        }
        
        if (bll.Add(SelectLength, model, BeginTimeList, EndTimeList, DaysList, DeptCodeList, DeptNameList, SchemeOrder))
        {
            context.Response.Write("科室轮转计划保存成功");
        }
        else
        {
            context.Response.Write("轮转科室信息保存失败，请联系管理员");
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