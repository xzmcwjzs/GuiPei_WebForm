<%@ WebHandler Language="C#" Class="studentsImport" %>

using System;
using System.Collections.Generic;
using System.Web;
using Common;
using System.Data;
using DAL;
using BLL;

public class studentsImport : IHttpHandler {
    SqlHelper db = new SqlHelper();
    TrainingBaseBLL trainingBaseBLL = new TrainingBaseBLL();
    DataTable dtTB = new DataTable();

    ProfessionalBaseDeptBLL professionalBaseDeptBLL = new ProfessionalBaseDeptBLL();
    DataTable dtPD = new DataTable();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string filePath = context.Request["filePath"];

        dtTB = trainingBaseBLL.GetDt();
        dtPD = professionalBaseDeptBLL.GetDt();

        DataTable dt = ExcelHelper.GetDataTable(context.Server.MapPath(filePath));

        List<string> sqlList = new List<string>();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int t1 = 0, t2 = 0;
                if (dt.Rows[i]["用户名"].ToString() != string.Empty)
                {

                    for (int j = 0; j < dtTB.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["培训基地名称"].ToString() == dtTB.Rows[j]["hospital_name"].ToString())
                        {
                            t1 = j;
                        }
                    }
                    for (int k = 0; k < dtPD.Rows.Count; k++)
                    {
                        if (dt.Rows[i]["培训专业名称"].ToString() == dtPD.Rows[k]["professional_base_name"].ToString())
                        {
                            t2 = k;
                        }
                    }
                    string sql1 = "insert into GP_Login (id,name,password,real_name,training_base_name,training_base_code,type,LoginState,RegisterDate) values(" +
                    "'" + Guid.NewGuid().ToString() + "','" + dt.Rows[i]["用户名"].ToString() + "','" + dt.Rows[i]["密码"].ToString() + "','" + dt.Rows[i]["真实姓名"].ToString() + "'" +
                ",'" + dt.Rows[i]["培训基地名称"].ToString() + "','" + dtTB.Rows[t1]["hospital_code"].ToString() + "'" +
                ",'students','1','" + DateTime.Now.Year.ToString() + "')";
                    
                    sqlList.Add(sql1);
                    
                    string sql2 = "insert into GP_StudentsPersonalInformation2 (Id,Name,RealName,Sex,IdNumber,Telephon,HighEducation,IdentityType,SendUnit,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,TrainingTime,PlanTrainingTime) values(" +
                    "'" + Guid.NewGuid().ToString() + "','" + dt.Rows[i]["用户名"].ToString() + "','" + dt.Rows[i]["真实姓名"].ToString() + "'" +
                    ",'" + dt.Rows[i]["性别"].ToString() + "','" + dt.Rows[i]["身份证号码"].ToString() + "','" + dt.Rows[i]["手机号码"].ToString() + "','" + dt.Rows[i]["最高学历"].ToString() + "'" +
                    ",'" + dt.Rows[i]["身份类型"].ToString() + "','" + dt.Rows[i]["派出单位(仅限身份类型为单位人的填写)"].ToString() + "','" + dtTB.Rows[t1]["hospital_code"].ToString() + "'" +
                ",'" + dt.Rows[i]["培训基地名称"].ToString() + "','" +dtPD.Rows[t2]["professional_base_code"].ToString() + "'" +
                ",'" + dt.Rows[i]["培训专业名称"].ToString() + "','" + dt.Rows[i]["参训时间"].ToString() + "','" + dt.Rows[i]["计划参训时限"].ToString() + "')";
                    
                    
                    sqlList.Add(sql2);
                }

            }

            int rows = db.ExecuteSqlTran(sqlList);
            if (rows > 0)
            {
                context.Response.Write("学员基本信息导入成功");
            }
            else
            {
                context.Response.Write("学员基本信息导入失败");
            }
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