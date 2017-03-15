<%@ WebHandler Language="C#" Class="HospitalName" %>

using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;


public class HospitalName : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string provinceCode = context.Request["ProvinceCode"];
        BLL.TrainingBaseBLL trainingBaseBLL = new BLL.TrainingBaseBLL();
        List<Model.TrainingBaseModel> list = new List<Model.TrainingBaseModel>();
        list = trainingBaseBLL.getHospitalNameListModel(provinceCode);
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}