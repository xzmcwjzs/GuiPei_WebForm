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
public partial class students_RotaryInformation_Manage : System.Web.UI.Page
{
    LoginModel loginModel = null;
    StudentsPersonalInformationModel studentsPersonalInformationModel = null;
    protected  string na=string.Empty;
    protected string tbcode=string.Empty;
    StudentsPersonalInformationBLL studentsPersonalInformationBLL = null;
    DataTable dt = null;
    ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
    StudentsRotaryModel studentsRotaryModel = null;
    StudentsRotaryBLL studentsRotaryBLL = null;
    public string id = string.Empty;
    protected string pi = string.Empty;
    protected string outdeptwei = "未出科";
    protected string outdeptapplicationwei = "未申请出科考试";
    protected string questionnairewei = "未填写";
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
            studentsPersonalInformationModel = new StudentsPersonalInformationModel();
            studentsPersonalInformationBLL=new StudentsPersonalInformationBLL();
            dt = new DataTable();
      

            professionalBaseDeptBLL=new ProfessionalBaseDeptBLL();

            loginModel = (LoginModel)Session["loginModel"];
            writor.Text = loginModel.real_name;
            real_name.Text = loginModel.real_name; real_name.ReadOnly = true;
            if(string.IsNullOrEmpty(id)){
                register_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }


            na = loginModel.name;
            name.Value = na;
            tbcode = loginModel.training_base_code;

            studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelByNameTBCode(na,tbcode);

            if (studentsPersonalInformationModel == null)
            {
                Response.Write("<script> alert('请完善个人基本信息');window.close();</script>");
                return;
            }
            else { 
                training_base_code.Value = studentsPersonalInformationModel.training_base_code.ToString();
                training_base_name.Text = studentsPersonalInformationModel.training_base_name.ToString(); training_base_name.ReadOnly = true;

            professional_base_code.Value = studentsPersonalInformationModel.professional_base_code.ToString();
            professional_base_name.Text = studentsPersonalInformationModel.professional_base_name.ToString(); professional_base_name.ReadOnly = true;

            dt = professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.professional_base_code.ToString());

            rotary_dept_name.DataSource = dt;
            
            rotary_dept_name.DataTextField = "dept_name";
            rotary_dept_name.DataValueField = "dept_code";
            rotary_dept_name.DataBind();
            rotary_dept_name.Items.Insert(0, new ListItem("==请选择==", "0"));
            }
            



            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                studentsRotaryModel=new StudentsRotaryModel();
                studentsRotaryBLL=new StudentsRotaryBLL();
                studentsRotaryModel=studentsRotaryBLL.GetModelById(id);

                //rotary_dept_name.SelectedItem.Text = studentsRotaryModel.rotary_dept_name.ToString();
                rotary_dept_name.SelectedValue = studentsRotaryModel.rotary_dept_code.ToString();
               
                dt = new LoginBLL().GetTeachersDtByDeptCode(studentsRotaryModel.training_base_code, studentsRotaryModel.professional_base_code, studentsRotaryModel.rotary_dept_code, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = studentsRotaryModel.instructor_tag;

                //instructor.Text = studentsRotaryModel.instructor.ToString();
                //instructor_tag.Value = studentsRotaryModel.instructor_tag.ToString();
                //Teacher.SelectedItem.Text = studentsRotaryModel.instructor.ToString();
                //Teacher.SelectedItem.Value = studentsRotaryModel.instructor_tag.ToString();
                rotary_begin_time.Text = studentsRotaryModel.rotary_begin_time.ToString();
                rotary_end_time.Text = studentsRotaryModel.rotary_end_time.ToString();
                register_date.Text = studentsRotaryModel.register_date.ToString();
            }

        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        studentsRotaryModel = new StudentsRotaryModel();
        studentsRotaryBLL = new StudentsRotaryBLL();


        studentsRotaryModel.rotary_begin_time =CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(rotary_begin_time.Text.Trim()),"yyyy-MM-dd");
        studentsRotaryModel.rotary_end_time =CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(rotary_end_time.Text.Trim()),"yyyy-MM-dd");

        studentsRotaryModel.rotary_dept_code = CommonFunc.FilterSpecialString(rotary_dept_name.SelectedItem.Value);
        studentsRotaryModel.rotary_dept_name = CommonFunc.FilterSpecialString(rotary_dept_name.SelectedItem.Text);
        studentsRotaryModel.instructor = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);
        studentsRotaryModel.instructor_tag = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);

        studentsRotaryModel.writor = CommonFunc.FilterSpecialString(writor.Text.Trim());

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            studentsRotaryModel.id = id;

            studentsRotaryModel.name = name.Value.ToString();
            studentsRotaryModel.real_name = CommonFunc.FilterSpecialString(real_name.Text.Trim());

            studentsRotaryModel.training_base_code = CommonFunc.FilterSpecialString(training_base_code.Value);
            studentsRotaryModel.training_base_name = CommonFunc.FilterSpecialString(training_base_name.Text);
            studentsRotaryModel.professional_base_code = CommonFunc.FilterSpecialString(professional_base_code.Value);
            studentsRotaryModel.professional_base_name = CommonFunc.FilterSpecialString(professional_base_name.Text);

            studentsRotaryModel.register_date = CommonFunc.FilterSpecialString(register_date.Text.Trim());
            studentsRotaryModel.outdept_status = CommonFunc.FilterSpecialString(outdeptwei);
            studentsRotaryModel.outdept_application = CommonFunc.FilterSpecialString(outdeptapplicationwei);
            studentsRotaryModel.questionnaire_status = CommonFunc.FilterSpecialString(questionnairewei);

            if (studentsRotaryModel.rotary_dept_code == "0" || studentsRotaryModel.rotary_dept_name == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (studentsRotaryModel.instructor == "==请选择=="||studentsRotaryModel.instructor_tag=="0")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(rotary_begin_time.Text.Trim()) || string.IsNullOrEmpty(rotary_end_time.Text.Trim()))
            {
                ShowMessageBox.Showmessagebox(this, "轮转时间不能为空", null);
                return;
            }
            if (studentsRotaryBLL.InsertStudentsRotary(studentsRotaryModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('科室轮转信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);;window.close();</script>");
                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else {


            if (studentsRotaryModel.rotary_dept_code == "0" || studentsRotaryModel.rotary_dept_name == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (studentsRotaryModel.instructor == "==请选择==" || studentsRotaryModel.instructor_tag == "0")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(rotary_begin_time.Text.Trim()) || string.IsNullOrEmpty(rotary_end_time.Text.Trim()))
            {
                ShowMessageBox.Showmessagebox(this, "轮转时间不能为空", null);
                return;
            }
            if (studentsRotaryBLL.UpdateRotary(studentsRotaryModel,id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('科室轮转信息修改成功');window.opener.window.loadPageList('"+pi+"');window.close();;</script>");
                    Response.End();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }
            else {
                
                Response.Write("<script language='javascript'> alert('科室轮转信息修改失败');window.close();</script>");
               
            }
        }

    }

    protected void rotary_dept_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoginBLL loginBLL = new LoginBLL();
        DataTable dt = new DataTable();
        string tbCode = CommonFunc.SafeGetStringFromObj(training_base_code.Value);
        string pbCode = CommonFunc.SafeGetStringFromObj(professional_base_code.Value);
        string dCode = CommonFunc.SafeGetStringFromObj(rotary_dept_name.SelectedItem.Value);
        string type = "teachers";
        dt = loginBLL.GetTeachersDtByDeptCode(tbCode, pbCode, dCode, type);

        Teacher.DataSource = dt;

        Teacher.DataTextField = "real_name";
        Teacher.DataValueField = "name";
        Teacher.DataBind();
        Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
    }
}