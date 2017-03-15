using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
using Model;
using System.Data;

public partial class students_PersonalInformation_List : System.Web.UI.Page
{
    protected DataTable dt = null;
    LoginModel loginModel = null;
    public string students_name;
    protected void Page_Load(object sender, EventArgs e)
    {
       if(Session["loginModel"]==null){
           ShowMessageBox.Showmessagebox(this,"请重新登录","../../Default.aspx");
           return;
       }

       if (!IsPostBack)
       {
           StudentsPersonalInformationModel studentsPersonalInformationModel = new StudentsPersonalInformationModel();
           StudentsPersonalInformationBLL studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
           loginModel = (LoginModel)Session["loginModel"];
           students_name = loginModel.name;


       }
         
        
     }
}