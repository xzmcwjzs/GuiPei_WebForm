<%@ WebHandler Language="C#" Class="List" %>

using System;
using System.Web;
using BLL;

public class List : IHttpHandler {
    
    DiseaseRegister2BLL diseaseRegister2BLL=new DiseaseRegister2BLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageIndex = context.Request["pi"] != null ? int.Parse(context.Request["pi"]) : 1;
        int pageSize = 15;
        string students_name = context.Request["name"].ToString();
        string training_base_code = context.Request["training_base_code"].ToString();
        string dept_name = context.Request["dept_name"].ToString();
        string disease_name = context.Request["disease_name"].ToString();
        string required_num = context.Request["required_num"].ToString();
        string master_degree = context.Request["master_degree"].ToString();

        int pageCount = diseaseRegister2BLL.GetPageCount(pageSize, students_name, training_base_code, dept_name,disease_name,required_num,master_degree);
        int recordCount = diseaseRegister2BLL.GetRecordCount(students_name, training_base_code, dept_name, disease_name, required_num, master_degree);

        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageIndex = pageIndex > pageCount ? pageCount : pageIndex;


        System.Collections.Generic.List<Model.DiseaseRegister2Model> list = new BLL.DiseaseRegister2BLL().GetPagedList(students_name, training_base_code, dept_name, disease_name, required_num, master_degree, pageIndex, pageSize);

        string strJsonArr = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        string strRes = "{'data':" + strJsonArr + ",'recordCount':" + recordCount + ",'pageCount':" + pageCount + "}";

        context.Response.Write(strRes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}