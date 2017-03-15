<%@ WebHandler Language="C#" Class="AddUpdate" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

public class AddUpdate : IHttpHandler,IRequiresSessionState {
    StudyAndReadingModel studyAndReadingModel = null;
    StudyAndReadingBLL studyAndReadingBLL = null;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id = context.Request.Form["id"];
        string action = context.Request.Form["action"];
        if (action == "add")
        {
            Add();
        }
        else if (action == "update")
        {
            Update(id);
        }
        
    }

   
    private void Add()
    {
        HttpRequest request = HttpContext.Current.Request;
        HttpResponse response = HttpContext.Current.Response;
        studyAndReadingModel = new StudyAndReadingModel();
        studyAndReadingBLL = new StudyAndReadingBLL();
        studyAndReadingModel.Id = Guid.NewGuid().ToString();
        studyAndReadingModel.StudentsName = request.Form["StudentsName"]; studyAndReadingModel.StudentsRealName = request.Form["StudentsRealName"];
        studyAndReadingModel.TrainingBaseCode = request.Form["TrainingBaseCode"]; studyAndReadingModel.TrainingBaseName = request.Form["TrainingBaseName"];
        studyAndReadingModel.ProfessionalBaseCode = request.Form["ProfessionalBaseCode"]; studyAndReadingModel.ProfessionalBaseName = request.Form["ProfessionalBaseName"];
        studyAndReadingModel.DeptCode = request.Form["DeptCode"]; studyAndReadingModel.DeptName = request.Form["DeptName"];
        studyAndReadingModel.RegisterDate = request.Form["RegisterDate"]; studyAndReadingModel.Writor = request.Form["Writor"];
        studyAndReadingModel.TeacherCheck = "未通过"; studyAndReadingModel.KzrCheck = "未通过";
        studyAndReadingModel.BaseCheck = "未通过"; studyAndReadingModel.ManagerCheck = "未通过";
        studyAndReadingModel.TeacherId = request.Form["TeacherName"]; studyAndReadingModel.TeacherName = request.Form["TeacherRealName"];
        studyAndReadingModel.ActivityForm = request.Form["ActivityForm"]; studyAndReadingModel.ActivityContent = request.Form["ActivityContent"];
        studyAndReadingModel.ActivityDate = request.Form["ActivityDate"]; studyAndReadingModel.LanguageType = request.Form["LanguageType"];
        studyAndReadingModel.ClassHour = request.Form["ClassHour"]; studyAndReadingModel.MainSpeaker = request.Form["MainSpeaker"];
        studyAndReadingModel.SuperiorDoctor = request.Form["SuperiorDoctor"]; studyAndReadingModel.Comment = request.Form["Comment"];
        if (studyAndReadingBLL.Add(studyAndReadingModel))
        {

            response.Write("{\"data\":\"addSuccess\"}");
            response.End();
        }
        else
        {
            response.Write("{\"data\":\"error\"}");
            response.End();
        }
    }
    private void Update(string id)
    {
        HttpRequest request = HttpContext.Current.Request;
        HttpResponse response = HttpContext.Current.Response;
        studyAndReadingModel = new StudyAndReadingModel();
        studyAndReadingBLL = new StudyAndReadingBLL();
        studyAndReadingModel.StudentsName = request.Form["StudentsName"]; studyAndReadingModel.StudentsRealName = request.Form["StudentsRealName"];
        studyAndReadingModel.TrainingBaseCode = request.Form["TrainingBaseCode"]; studyAndReadingModel.TrainingBaseName = request.Form["TrainingBaseName"];
        studyAndReadingModel.ProfessionalBaseCode = request.Form["ProfessionalBaseCode"]; studyAndReadingModel.ProfessionalBaseName = request.Form["ProfessionalBaseName"];
        studyAndReadingModel.DeptCode = request.Form["DeptCode"]; studyAndReadingModel.DeptName = request.Form["DeptName"];
        studyAndReadingModel.RegisterDate = request.Form["RegisterDate"]; studyAndReadingModel.Writor = request.Form["Writor"];
        studyAndReadingModel.TeacherId = request.Form["TeacherName"]; studyAndReadingModel.TeacherName = request.Form["TeacherRealName"];
        studyAndReadingModel.ActivityForm = request.Form["ActivityForm"]; studyAndReadingModel.ActivityContent = request.Form["ActivityContent"];
        studyAndReadingModel.ActivityDate = request.Form["ActivityDate"]; studyAndReadingModel.LanguageType = request.Form["LanguageType"];
        studyAndReadingModel.ClassHour = request.Form["ClassHour"]; studyAndReadingModel.MainSpeaker = request.Form["MainSpeaker"];
        studyAndReadingModel.SuperiorDoctor = request.Form["SuperiorDoctor"]; studyAndReadingModel.Comment = request.Form["Comment"];
        if (studyAndReadingBLL.Update(studyAndReadingModel,id))
        {

            response.Write("{\"data\":\"updateSuccess\"}");
            response.End();
        }
        else
        {
            response.Write("{\"data\":\"error\"}");
            response.End();
        }
    } 
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}