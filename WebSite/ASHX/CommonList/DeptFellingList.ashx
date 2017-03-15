<%@ WebHandler Language="C#" Class="DeptFellingList" %>

using System;
using System.Web;
using BLL;
using Common;

public class DeptFellingList : IHttpHandler {
    InDeptFellingBLL inDeptFellingBLL=new InDeptFellingBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
       int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string StudentsRealName = context.Request["StudentsRealName"];
        string TeachersName = context.Request["TeachersName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string ProfessionalBaseCode = context.Request["ProfessionalBaseCode"];
        string DeptCode = context.Request["DeptCode"];
        string ProfessionalBaseName =CommonFunc.SafeGetStringFromObj(context.Request["ProfessionalBaseName"]);
        string DeptName = CommonFunc.SafeGetStringFromObj(context.Request["DeptName"]);
        string TeachersRealName = CommonFunc.SafeGetStringFromObj(context.Request["TeachersRealName"]); 

        int pageCount = inDeptFellingBLL.CommonGetPageCount(pageSize, StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName);
        int recordCount = inDeptFellingBLL.CommonGetRecordCount(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName, TeachersRealName);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.InDeptFellingModel> list = new BLL.InDeptFellingBLL().CommonGetPagedList(StudentsRealName, TrainingBaseCode, ProfessionalBaseCode, DeptCode, TeachersName, ProfessionalBaseName, DeptName,TeachersRealName, pageIndex, pageSize);
        
        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
   