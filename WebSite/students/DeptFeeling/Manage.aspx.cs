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
public partial class students_DeptFeeling_Manager : System.Web.UI.Page
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
    protected string teacher_status="未通过";
    protected string kzr_status = "未通过";
    protected string base_status = "未通过";
    protected string manage_status = "未通过";

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

            loginModel = (LoginModel)Session["loginModel"];
            writor.Text = loginModel.real_name;
            real_name.Text = loginModel.real_name; real_name.ReadOnly = true;
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
                training_base_name.Text = studentsPersonalInformationModel.TrainingBaseName.ToString(); training_base_name.ReadOnly = true;

                ProfessionalBaseCode.Value = studentsPersonalInformationModel.ProfessionalBaseCode.ToString();
                professional_base_name.Text = studentsPersonalInformationModel.ProfessionalBaseName.ToString(); professional_base_name.ReadOnly = true;

                dt = professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.ProfessionalBaseCode.ToString());

                RotaryDept.DataSource = dt;

                RotaryDept.DataTextField = "dept_name";
                RotaryDept.DataValueField = "dept_code";
                RotaryDept.DataBind();
                RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
            }




            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                inDeptFellingModel = new InDeptFellingModel();
                inDeptFellingBLL = new InDeptFellingBLL();

                inDeptFellingModel = inDeptFellingBLL.GetModelById(id);
                real_name.Text = inDeptFellingModel.real_name.ToString();
                training_base_name.Text = inDeptFellingModel.training_base_name.ToString();
                professional_base_name.Text = inDeptFellingModel.professional_base_name.ToString();
                //RotaryDept.SelectedItem.Text = inDeptFellingModel.rotary_dept_name.ToString();
                RotaryDept.SelectedValue = inDeptFellingModel.rotary_dept_code.ToString();
                dt = new LoginBLL().GetTeachersDtByDeptCode(inDeptFellingModel.training_base_code, inDeptFellingModel.professional_base_code, inDeptFellingModel.rotary_dept_code, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = inDeptFellingModel.TeacherId;
                
                //Teacher.SelectedValue = inDeptFellingModel.TeacherId.ToString();
                //Teacher.SelectedItem.Text = inDeptFellingModel.TeacherName.ToString();
                dept_felling.Text = inDeptFellingModel.indept_felling.ToString();
                writor.Text=inDeptFellingModel.writor.ToString();
                register_date.Text = inDeptFellingModel.register_date.ToString();

            }

        }

    }
    protected void save_Click(object sender, EventArgs e)
    {
        inDeptFellingModel = new InDeptFellingModel();
        inDeptFellingBLL = new InDeptFellingBLL();

        inDeptFellingModel.rotary_dept_code = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
        inDeptFellingModel.rotary_dept_name = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
        inDeptFellingModel.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
        inDeptFellingModel.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);
        inDeptFellingModel.indept_felling = CommonFunc.FilterSpecialString(dept_felling.Text);
        inDeptFellingModel.writor = CommonFunc.FilterSpecialString(writor.Text);
        inDeptFellingModel.register_date = CommonFunc.FilterSpecialString(register_date.Text.Trim());

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            inDeptFellingModel.id = id;
            inDeptFellingModel.name = name.Value.ToString();

            inDeptFellingModel.real_name = CommonFunc.FilterSpecialString(real_name.Text.Trim());
            inDeptFellingModel.training_base_code = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
            inDeptFellingModel.training_base_name = CommonFunc.FilterSpecialString(training_base_name.Text);
            inDeptFellingModel.professional_base_code = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
            inDeptFellingModel.professional_base_name = CommonFunc.FilterSpecialString(professional_base_name.Text);
            inDeptFellingModel.teacher_status = teacher_status;
            inDeptFellingModel.kzr_status = kzr_status;
            inDeptFellingModel.base_status = base_status;
            inDeptFellingModel.manager_status = manage_status;
            

            if (inDeptFellingModel.rotary_dept_code == "0" || inDeptFellingModel.rotary_dept_name == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (inDeptFellingModel.TeacherId == "0" || inDeptFellingModel.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(inDeptFellingModel.indept_felling))
            {
                ShowMessageBox.Showmessagebox(this, "入科感想不能为空", null);
                return;
            }

            if (inDeptFellingModel.indept_felling.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "入科感想字数不能超过1000字", null);
                return;
            }
            if (inDeptFellingBLL.InsertDeptFelling(inDeptFellingModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('入科感想添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                     
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else {
            if (inDeptFellingModel.rotary_dept_code == "0" || inDeptFellingModel.rotary_dept_name == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (inDeptFellingModel.TeacherId == "0" || inDeptFellingModel.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(inDeptFellingModel.indept_felling))
            {
                ShowMessageBox.Showmessagebox(this, "入科感想不能为空", null);
                return;
            }

            if (inDeptFellingModel.indept_felling.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "入科感想字数不能超过1000字", null);
                return;
            }
            if (inDeptFellingBLL.UpdateDeptFelling(inDeptFellingModel,id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('入科感想修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                     

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }

    }
    protected void RotaryDept_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        LoginBLL loginBLL = new LoginBLL();
        DataTable dt = new DataTable();
        string tbCode =CommonFunc.SafeGetStringFromObj(TrainingBaseCode.Value);
        string pbCode = CommonFunc.SafeGetStringFromObj(ProfessionalBaseCode.Value);
        string dCode = CommonFunc.SafeGetStringFromObj(RotaryDept.SelectedItem.Value);
        string type = "teachers";
        dt = loginBLL.GetTeachersDtByDeptCode(tbCode,pbCode,dCode,type);
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