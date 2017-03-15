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

public partial class teachers_StudentsRotaryInformation_Left : System.Web.UI.Page
{
    protected string na = string.Empty;
    protected string tbcode = string.Empty;

    LoginModel loginModel = null;
    StudentsPersonalInformationBLL studentsPersonalInformationBLL = null;
    StudentsPersonalInformationModel studentsPersonalInformationModel = null;
    DataTable dt = null;
    ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请先重新登录", "../../Default.aspx");
            return;

        }
        //studentsModel = new StudentsModel();
        //studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
        //studentsPersonalInformationModel = new StudentsPersonalInformationModel();
        //professionalBaseDeptBLL = new ProfessionalBaseDeptBLL();

        //studentsModel = (StudentsModel)Session["studentsModel"];
        //na = studentsModel.students_name;
        //tbcode = studentsModel.training_base_code;
        //studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelByNameTBCode(na, tbcode);

        //dt = professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.professional_base_code.ToString());

        //rotary_dept.DataSource = dt;

        //rotary_dept.DataTextField = "dept_name";
        //rotary_dept.DataValueField = "dept_code";
        //rotary_dept.DataBind();
        //rotary_dept.Items.Insert(0, new ListItem("==请选择==", string.Empty));
    }

}