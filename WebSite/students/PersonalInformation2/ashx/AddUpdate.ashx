<%@ WebHandler Language="C#" Class="AddUpdate" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;

public class AddUpdate : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        StudentsPersonalInformation2BLL bll = new StudentsPersonalInformation2BLL();
        StudentsPersonalInformation2Model model = new StudentsPersonalInformation2Model();
        
        model.Name =CommonFunc.SafeGetStringFromObj(context.Request["Name"]);
        model.RealName = CommonFunc.SafeGetStringFromObj(context.Request["RealName"]);
        model.ImagePath = CommonFunc.SafeGetStringFromObj(context.Request["ImagePath"]);
        model.Sex = CommonFunc.SafeGetStringFromObj(context.Request["Sex"]);
        model.IdNumber = CommonFunc.SafeGetStringFromObj(context.Request["IdNumber"]);
        model.DateBirth = CommonFunc.SafeGetStringFromObj(context.Request["DateBirth"]);
        model.MinZu = CommonFunc.SafeGetStringFromObj(context.Request["MinZu"]);
        model.Telephon = CommonFunc.SafeGetStringFromObj(context.Request["Telephon"]);
        model.Mail = CommonFunc.SafeGetStringFromObj(context.Request["Mail"]);
        model.BkSchool = CommonFunc.SafeGetStringFromObj(context.Request["BkSchool"]);
        model.BkMajor = CommonFunc.SafeGetStringFromObj(context.Request["BkMajor"]);
        model.GraduationTime = CommonFunc.SafeGetStringFromObj(context.Request["GraduationTime"]);
        model.HighEducation = CommonFunc.SafeGetStringFromObj(context.Request["HighEducation"]);
        model.HighSchool = CommonFunc.SafeGetStringFromObj(context.Request["HighSchool"]);
        model.HighMajor = CommonFunc.SafeGetStringFromObj(context.Request["HighMajor"]);
        model.HighEducationTime = CommonFunc.SafeGetStringFromObj(context.Request["HighEducationTime"]);
        model.IdentityType = CommonFunc.SafeGetStringFromObj(context.Request["IdentityType"]);
        model.SendUnit = CommonFunc.SafeGetStringFromObj(context.Request["SendUnit"]);
        //model.TrainingBaseProvinceCode = CommonFunc.SafeGetStringFromObj(context.Request["TrainingBaseProvince"]);
        //model.TrainingBaseProvinceName = CommonFunc.SafeGetStringFromObj(context.Request["TrainingBaseProvinceName"]);
        model.TrainingBaseCode = CommonFunc.SafeGetStringFromObj(context.Request["TrainingBaseCode"]);
        model.TrainingBaseName = CommonFunc.SafeGetStringFromObj(context.Request["TrainingBaseName"]);
        model.CollaborativeUnit = CommonFunc.SafeGetStringFromObj(context.Request["CollaborativeUnit"]);
        model.ProfessionalBaseCode = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBase"]);
        model.ProfessionalBaseName = CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        model.TrainingTime = CommonFunc.SafeGetStringFromObj(context.Request["TrainingTime"]);
        model.PlanTrainingTime = CommonFunc.SafeGetStringFromObj(context.Request["PlanTrainingTime"]);


        if (bll.CheckInfo(CommonFunc.SafeGetStringFromObj(context.Request["Name"])))
        {
            if (bll.Update(model))
            {
                context.Response.Write("个人基本信息更新成功");
            }
            else
            {
                context.Response.Write("个人基本信息更新失败，请联系管理员");
            }

        }
        else
        {
            model.Id = Guid.NewGuid().ToString();
            
            if (bll.Add(model))
            {
                context.Response.Write("个人基本信息保存成功");
            }
            else
            {
                context.Response.Write("个人基本信息保存失败，请联系管理员");
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}