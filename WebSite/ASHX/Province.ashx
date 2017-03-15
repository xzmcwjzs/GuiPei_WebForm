<%@ WebHandler Language="C#" Class="Province" %>

using System;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;


using System.Threading.Tasks;
public class Province : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        BLL.ProvinceBLL provinceBLL = new BLL.ProvinceBLL();
        List<Model.ProvinceModel> list = new List<Model.ProvinceModel>();
        list = provinceBLL.getListModel();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(list);
        context.Response.Write(json);
        //DAL.ProvinceDAL provinceDAL = new DAL.ProvinceDAL();
        //DataTable dt = new DataTable();
        //dt = provinceDAL.getListModel1();
        //JavaScriptSerializer jss = new JavaScriptSerializer();
        //string json = jss.Serialize(dt);
        ////string S = DataTable2JsonCom(dt);
        //context.Response.Write(json);
    }


    //public static string DataTable2JsonCom(DataTable dt, int pid = -1)
    //{
    //    StringBuilder jsonBuilder = new StringBuilder();
    //    jsonBuilder.Append("[");
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {

    //        jsonBuilder.Append("{");
    //        for (int j = 0; j < dt.Columns.Count; j++)
    //        {
    //            int id = pid;
    //            jsonBuilder.Append("\"");
    //            dt.Columns[j].ColumnName = dt.Columns[j].ColumnName.ToLower();
    //            jsonBuilder.Append(dt.Columns[j].ColumnName);
    //            jsonBuilder.Append("\":\"" + dt.Rows[i][j].ToString() + "\",");

    //        }

    //        if (dt.Columns.Count > 0)
    //        {
    //            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
    //        }
    //        jsonBuilder.Append("},");
    //    }
    //    if (dt.Rows.Count > 0)
    //    {
    //        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
    //    }
    //    jsonBuilder.Append("]");
    //    return jsonBuilder.ToString();
    //}
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}