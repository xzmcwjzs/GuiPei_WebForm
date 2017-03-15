<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using Model;
using BLL;


public class Add : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        TiKuResultModel model = new TiKuResultModel();
        TiKuResultBLL bll=new TiKuResultBLL();
        
        string StudentsName = context.Request["StudentsName"];
        string StudentsRealName = context.Request["StudentsRealName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string TrainingBaseName = context.Request["TrainingBaseName"];
        string SubjectName = context.Request["SubjectName"];
        string SubjectCode = context.Request["SubjectCode"];
        string TotalScore = context.Request["TotalScore"];
        string TotalNum = context.Request["TotalNum"];
        string UndoNum = context.Request["UndoNum"];
        string CorrectNum = context.Request["CorrectNum"];
        string ErrorNum = context.Request["ErrorNum"];
        string RegisterDate = context.Request["RegisterDate"];

        model.Id = Guid.NewGuid().ToString();
        model.StudentsName = StudentsName;
        model.StudentsRealName = StudentsRealName;
        model.TrainingBaseCode = TrainingBaseCode;
        model.TrainingBaseName = TrainingBaseName;
        model.SubjectName = SubjectName;
        model.SubjectCode = SubjectCode;
        model.TotalScore = TotalScore;
        model.TotalNum = TotalNum;
        model.UndoNum = UndoNum;
        model.CorrectNum = CorrectNum;
        model.ErrorNum = ErrorNum;
        model.RegisterDate = RegisterDate;
        
        if(bll.Add(model)){
            context.Response.Write("addSuccess");
        }else{
            context.Response.Write("addError");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}