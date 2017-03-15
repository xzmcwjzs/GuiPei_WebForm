using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class students_PersonalInformation_Top : System.Web.UI.Page
{
   public DataTable dt = new DataTable();
   public  string json = "";
   StudentsModel studentsModel = new StudentsModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }

            //StudentsPersonalInformationBLL studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
            //studentsModel = (StudentsModel)Session["studentsModel"];
            //dt = studentsPersonalInformationBLL.GetDataTable(studentsModel);

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    json = "不为空";
            //}
            //else
            //{
            //    json = "";
            //}


        }
        
      
     
    
}