using System;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

public partial class students_DiseaseRegister_Manage : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    LoginModel loginModel = null;
    StudentsPersonalInformation2Model studentsPersonalInformationModel = null;
    StudentsPersonalInformation2BLL studentsPersonalInformationBLL = null;
    DataTable dt = null;
    ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
    protected string na = string.Empty;
    protected string tbcode = string.Empty;
    InDeptFellingModel inDeptFellingModel = null;
    InDeptFellingBLL inDeptFellingBLL = null;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));

        if (!IsPostBack)
        {
            loginModel = new LoginModel();
            studentsPersonalInformationModel = new StudentsPersonalInformation2Model();
            studentsPersonalInformationBLL = new StudentsPersonalInformation2BLL();
            dt = new DataTable();


            professionalBaseDeptBLL = new ProfessionalBaseDeptBLL();

            loginModel = (LoginModel) Session["loginModel"];
            writor.Text = loginModel.real_name;
            real_name.Text = loginModel.real_name;
            real_name.ReadOnly = true;
            if (string.IsNullOrEmpty(id))
            {
                register_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }


            na = loginModel.name;
            name.Value = na;
            tbcode = loginModel.training_base_code;

            studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelByNameTBCode(na, tbcode);

            if (studentsPersonalInformationModel == null)
            {
                Response.Write("<script> alert('请完善个人基本信息');window.close();</script>");
                return;
            }
            else
            {
                TrainingBaseCode.Value = studentsPersonalInformationModel.TrainingBaseCode.ToString();
                training_base_name.Text = studentsPersonalInformationModel.TrainingBaseName.ToString();
                training_base_name.ReadOnly = true;

                ProfessionalBaseCode.Value = studentsPersonalInformationModel.ProfessionalBaseCode.ToString();
                professional_base_name.Text = studentsPersonalInformationModel.ProfessionalBaseName.ToString();
                professional_base_name.ReadOnly = true;

                dt =professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.ProfessionalBaseCode.ToString());

                RotaryDept.DataSource = dt;

                RotaryDept.DataTextField = "dept_name";
                RotaryDept.DataValueField = "dept_code";
                RotaryDept.DataBind();
                RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
            }
        }


    }


    protected void RotaryDept_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        LoginBLL loginBLL = new LoginBLL();
        DataTable dt = new DataTable();
        string tbCode = CommonFunc.SafeGetStringFromObj(TrainingBaseCode.Value);
        string pbCode = CommonFunc.SafeGetStringFromObj(ProfessionalBaseCode.Value);
        string dCode = CommonFunc.SafeGetStringFromObj(RotaryDept.SelectedItem.Value);
        string type = "teachers";
        dt = loginBLL.GetTeachersDtByDeptCode(tbCode, pbCode, dCode, type);

        if (dt != null)
        {
            Teacher.DataSource = dt;

            Teacher.DataTextField = "real_name";
            Teacher.DataValueField = "name";
            Teacher.DataBind();
            Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
        }
        else
        {
            Teacher.Items.Clear();
            Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
        }
    }
}