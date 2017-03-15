<%@ WebHandler Language="C#" Class="PersonalInformation" %>

using System;
using System.Web;
using Model;
using BLL;
using System.Data;
using System.Data.SqlClient;

public class PersonalInformation : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string idNumber = context.Request["id_number"];
        StudentsPersonalInformationBLL spi = new StudentsPersonalInformationBLL();
        DataSet ds = new DataSet();
        string data = "";
        ds = spi.GetDataTableByIdNumber(idNumber);
        
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            data = "个人信息已完善";
            context.Response.Write(data);
        }
        else {
            context.Response.Write(data);
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}