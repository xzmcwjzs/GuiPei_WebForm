using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;
using Common;
using System.Data;

public partial class students_RotaryInformation_Left : System.Web.UI.Page
{
    //protected string na = string.Empty;
    //protected string tbcode = string.Empty;

    //LoginModel loginModel = null;
    //StudentsPersonalInformationBLL studentsPersonalInformationBLL = null;
    //StudentsPersonalInformationModel studentsPersonalInformationModel = null;
    //DataTable dt = null;
    //ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["loginModel"] == null)
        //{
        //    Response.Write("<script>alert('请重新登录');window.close();</script>");
        //    return;

        //}
        //loginModel = new LoginModel();
        //studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
        //studentsPersonalInformationModel = new StudentsPersonalInformationModel();
        //professionalBaseDeptBLL = new ProfessionalBaseDeptBLL();

        //loginModel = (LoginModel)Session["loginModel"];
        //na = loginModel.name;
        //tbcode = loginModel.training_base_code;
        
        //studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelByNameTBCode(na, tbcode);
        //if (studentsPersonalInformationModel == null)
        //{
        //    //Response.Write("<script> alert('请先完善个人基本信息');</script>");
        //    rotary_dept.Items.Insert(0, new ListItem("==请选择==", string.Empty));
        //    return;
        //}
        //else {
        //    dt = professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.professional_base_code.ToString());

        //    rotary_dept.DataSource = dt;

        //    rotary_dept.DataTextField = "dept_name";
        //    rotary_dept.DataValueField = "dept_code";
        //    rotary_dept.DataBind();
        //    rotary_dept.Items.Insert(0, new ListItem("==请选择==", string.Empty));
        //}
        
    }
    
}