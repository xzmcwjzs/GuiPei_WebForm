<%@ WebHandler Language="C#" Class="InsertRotary" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;
using System.Collections.Generic;
using System.Data;

public class InsertRotary : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name = context.Request["name"];
        string realName = context.Request["realName"];
        string trainingBaseCode = context.Request["trainingBaseCode"];
        string trainingBaseName = context.Request["trainingBaseName"];
        string professionalBaseName = context.Request["professionalBaseName"];
        string professionalBaseCode = context.Request["professionalBaseCode"];
        string deptCodeList = context.Request["deptCodeList"];
        string deptNameList = context.Request["deptNameList"];
        string beginTimeList = context.Request["beginTimeList"];
        string endTimeList = context.Request["endTimeList"];
        string daysList = context.Request["daysList"];
        string outdeptStatus = context.Request["outdeptStatus"];
        string outdeptApplication = context.Request["outdeptApplication"];
        string questionnaireStatus = context.Request["questionnaireStatus"];
        string trainingTime = context.Request["trainingTime"];
        int length = Convert.ToInt16(context.Request["length"]);
        
        List<string> TeachersNameList = new List<string>();
        List<string> TeachersRealNameList = new List<string>();
        List<string> DeptCodeList = new List<string>();
        List<string> DeptNameList = new List<string>();
        List<string> BeginTimeList = new List<string>();
        List<string> EndTimeList = new List<string>();
        List<string> DaysList = new List<string>();

        foreach (string s in deptCodeList.Split('}'))
        {
            DeptCodeList.Add(s);
        }
        foreach (string s1 in deptNameList.Split('}'))
        {
            DeptNameList.Add(s1);
        }
        foreach (string s2 in beginTimeList.Split('}'))
        {
            BeginTimeList.Add(s2);
        }
        foreach (string s3 in endTimeList.Split('}'))
        {
            EndTimeList.Add(s3);
        }
        foreach (string s4 in daysList.Split('}'))
        {
            DaysList.Add(s4);
        }
        
        
        
        DeptManagementBLL deptManagementBLL = new DeptManagementBLL();
        DataTable dt = new DataTable();
        dt = deptManagementBLL.GetTeachersDt(trainingTime, trainingBaseCode, professionalBaseCode);
        for (int j = 0; j < length; j++)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //string d1 = DeptCodeList[j];
                //string d = dt.Rows[i]["DeptCode"].ToString();
                if (DeptCodeList[j] == dt.Rows[i]["DeptCode"].ToString())
                {
                    //if (dt.Rows[i]["Tag1"].ToString() != "")
                   // {
                        TeachersNameList.Add(dt.Rows[i]["Tag1"].ToString());
                        TeachersRealNameList.Add(dt.Rows[i]["Tag2"].ToString());
                   // }
                    //else
                   // {
                   //     context.Response.Write("科室尚未分配指导医师");
                   //     return;
                   // }
                    
                }     
            }
        }
        StudentsRotaryInformation2BLL studentsRotaryInformation2BLL = new StudentsRotaryInformation2BLL();
        StudentsRotaryInformation2Model studentsRotaryInformation2Model = new StudentsRotaryInformation2Model();
        studentsRotaryInformation2Model.Name = name;
        studentsRotaryInformation2Model.RealName = realName;
        studentsRotaryInformation2Model.TrainingBaseCode = trainingBaseCode;
        studentsRotaryInformation2Model.TrainingBaseName = trainingBaseName;
        studentsRotaryInformation2Model.ProfessionalBaseCode = professionalBaseCode;
        studentsRotaryInformation2Model.ProfessionalBaseName = professionalBaseName;
        studentsRotaryInformation2Model.OutdeptStatus = outdeptStatus;
        studentsRotaryInformation2Model.OutdeptApplication = outdeptApplication;
        studentsRotaryInformation2Model.QuestionnaireStatus = questionnaireStatus;
        studentsRotaryInformation2Model.Tag1 = "0";
        if (studentsRotaryInformation2BLL.Add(length, studentsRotaryInformation2Model,DeptCodeList,DeptNameList,BeginTimeList,EndTimeList,DaysList,TeachersNameList,TeachersRealNameList))
        {
            context.Response.Write("轮转信息生成成功");
        }
        else
        {
            context.Response.Write("轮转信息生成失败");
        }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}