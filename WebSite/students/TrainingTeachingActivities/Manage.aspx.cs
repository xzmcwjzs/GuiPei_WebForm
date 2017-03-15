using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;
using System.Data;
public partial class students_TrainingTeachingActivities_Manage : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    TrainingTeachingActivitiesModel trainingTeachingActivitiesModel = null;
    TrainingTeachingActivitiesBLL trainingTeachingActivitiesBLL = null;
    LoginModel loginModel = null;
    StudentsPersonalInformation2Model studentsPersonalInformationModel = null;
    StudentsPersonalInformation2BLL studentsPersonalInformationBLL = null;
    DataTable dt = null;
    ProfessionalBaseDeptBLL professionalBaseDeptBLL = null;
    protected string na = string.Empty;
    protected string tbcode = string.Empty;

    protected string teacher_check = "未通过";
    protected string kzr_check = "未通过";
    protected string base_check = "未通过";
    protected string manager_check = "未通过";
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
            Writor.Text = loginModel.real_name;
            StudentsRealName.Text = loginModel.real_name; StudentsRealName.ReadOnly = true;
            RegisterDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            RegisterDate.ReadOnly = true;

            na = loginModel.name;
            StudentsName.Value = na;
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
                TrainingBaseName.Text = studentsPersonalInformationModel.TrainingBaseName.ToString(); TrainingBaseName.ReadOnly = true;

                ProfessionalBaseCode.Value = studentsPersonalInformationModel.ProfessionalBaseCode.ToString();
                ProfessionalBaseName.Text = studentsPersonalInformationModel.ProfessionalBaseName.ToString(); ProfessionalBaseName.ReadOnly = true;

                dt = professionalBaseDeptBLL.GetDeptDataTableByCode(studentsPersonalInformationModel.ProfessionalBaseCode.ToString());

                RotaryDept.DataSource = dt;

                RotaryDept.DataTextField = "dept_name";
                RotaryDept.DataValueField = "dept_code";
                RotaryDept.DataBind();
                RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
            }


            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                trainingTeachingActivitiesModel = new TrainingTeachingActivitiesModel();
                trainingTeachingActivitiesBLL = new TrainingTeachingActivitiesBLL();

                trainingTeachingActivitiesModel = trainingTeachingActivitiesBLL.GetModelById(id);
                StudentsRealName.Text = trainingTeachingActivitiesModel.StudentsRealName.ToString();
                TrainingBaseName.Text = trainingTeachingActivitiesModel.TrainingBaseName.ToString();
                ProfessionalBaseName.Text = trainingTeachingActivitiesModel.ProfessionalBaseName.ToString();
                //RotaryDept.SelectedItem.Text = trainingTeachingActivitiesModel.DeptName.ToString();
                RotaryDept.SelectedValue = trainingTeachingActivitiesModel.DeptCode.ToString();

                dt = new LoginBLL().GetTeachersDtByDeptCode(trainingTeachingActivitiesModel.TrainingBaseCode, trainingTeachingActivitiesModel.ProfessionalBaseCode, trainingTeachingActivitiesModel.DeptCode, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = trainingTeachingActivitiesModel.TeacherId;
                //Teacher.SelectedItem.Text = trainingTeachingActivitiesModel.TeacherName.ToString();
                //Teacher.SelectedItem.Value = trainingTeachingActivitiesModel.TeacherId.ToString();
               
                ActivityForm.SelectedValue = trainingTeachingActivitiesModel.ActivityFormId.ToString();
                ActivityContent.Text = trainingTeachingActivitiesModel.ActivityContent.ToString();
                MainSpeaker.Text = trainingTeachingActivitiesModel.MainSpeaker.ToString();
                ClassHour.Text = trainingTeachingActivitiesModel.ClassHour.ToString();
                ActivityDate.Text = trainingTeachingActivitiesModel.ActivityDate.ToString();
                Comment.Text = trainingTeachingActivitiesModel.Comment.ToString();
                Writor.Text = trainingTeachingActivitiesModel.Writor.ToString();
                RegisterDate.Text = trainingTeachingActivitiesModel.RegisterDate.ToString();

            }


        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        trainingTeachingActivitiesModel = new TrainingTeachingActivitiesModel();
        trainingTeachingActivitiesBLL = new TrainingTeachingActivitiesBLL();

        trainingTeachingActivitiesModel.DeptCode = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
        trainingTeachingActivitiesModel.DeptName = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
        trainingTeachingActivitiesModel.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
        trainingTeachingActivitiesModel.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);

        trainingTeachingActivitiesModel.ActivityForm = CommonFunc.FilterSpecialString(ActivityForm.SelectedItem.Text);
        trainingTeachingActivitiesModel.ActivityFormId = CommonFunc.FilterSpecialString(ActivityForm.SelectedItem.Value);
        trainingTeachingActivitiesModel.ActivityContent = CommonFunc.FilterSpecialString(ActivityContent.Text);
        trainingTeachingActivitiesModel.MainSpeaker = CommonFunc.FilterSpecialString(MainSpeaker.Text);
        trainingTeachingActivitiesModel.ClassHour = CommonFunc.FilterSpecialString(ClassHour.Text);
        trainingTeachingActivitiesModel.ActivityDate = CommonFunc.FilterSpecialString(ActivityDate.Text);

        trainingTeachingActivitiesModel.Comment = CommonFunc.FilterSpecialString(Comment.Text);
        
        trainingTeachingActivitiesModel.Writor = CommonFunc.FilterSpecialString(Writor.Text);
        trainingTeachingActivitiesModel.RegisterDate = CommonFunc.FilterSpecialString(RegisterDate.Text);

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            trainingTeachingActivitiesModel.Id = id;
            trainingTeachingActivitiesModel.StudentsName = StudentsName.Value.ToString();

            trainingTeachingActivitiesModel.StudentsRealName = CommonFunc.FilterSpecialString(StudentsRealName.Text.Trim());
            trainingTeachingActivitiesModel.TrainingBaseCode = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
            trainingTeachingActivitiesModel.TrainingBaseName = CommonFunc.FilterSpecialString(TrainingBaseName.Text);
            trainingTeachingActivitiesModel.ProfessionalBaseCode = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
            trainingTeachingActivitiesModel.ProfessionalBaseName = CommonFunc.FilterSpecialString(ProfessionalBaseName.Text);
            trainingTeachingActivitiesModel.TeacherCheck = teacher_check;
            trainingTeachingActivitiesModel.KzrCheck = kzr_check;
            trainingTeachingActivitiesModel.BaseCheck = base_check;
            trainingTeachingActivitiesModel.ManagerCheck = manager_check;

            if (trainingTeachingActivitiesModel.DeptCode == "0" || trainingTeachingActivitiesModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (trainingTeachingActivitiesModel.TeacherId == "0" || trainingTeachingActivitiesModel.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (trainingTeachingActivitiesModel.ActivityFormId == "-1" || trainingTeachingActivitiesModel.ActivityForm == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "活动形式不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(trainingTeachingActivitiesModel.ActivityContent))
            {
                ShowMessageBox.Showmessagebox(this, "活动内容不能为空", null);
                return;
            }
            if (trainingTeachingActivitiesModel.ActivityContent.Length > 2000)
            {
                ShowMessageBox.Showmessagebox(this, "活动内容字数不能超过2000字", null);
                return;
            }
            if (string.IsNullOrEmpty(trainingTeachingActivitiesModel.MainSpeaker))
            {
                ShowMessageBox.Showmessagebox(this, "主讲人不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(trainingTeachingActivitiesModel.ActivityDate))
            {
                ShowMessageBox.Showmessagebox(this, "活动日期不能为空", null);
                return;
            }
            
            if (trainingTeachingActivitiesModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (trainingTeachingActivitiesBLL.Add(trainingTeachingActivitiesModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('培训教学活动信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                   
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else
        {
            if (trainingTeachingActivitiesModel.DeptCode == "0" || trainingTeachingActivitiesModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (trainingTeachingActivitiesModel.ActivityFormId == "-1" || trainingTeachingActivitiesModel.ActivityForm == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "活动形式不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(trainingTeachingActivitiesModel.ActivityContent))
            {
                ShowMessageBox.Showmessagebox(this, "活动内容不能为空", null);
                return;
            }
            if (trainingTeachingActivitiesModel.ActivityContent.Length > 2000)
            {
                ShowMessageBox.Showmessagebox(this, "活动内容字数不能超过2000字", null);
                return;
            }
            if (string.IsNullOrEmpty(trainingTeachingActivitiesModel.MainSpeaker))
            {
                ShowMessageBox.Showmessagebox(this, "主讲人不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(trainingTeachingActivitiesModel.ActivityDate))
            {
                ShowMessageBox.Showmessagebox(this, "活动日期不能为空", null);
                return;
            }

            if (trainingTeachingActivitiesModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (trainingTeachingActivitiesBLL.Update(trainingTeachingActivitiesModel, id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('培训教学活动信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }

    }
    protected void RotaryDept_SelectedIndexChanged(object sender, EventArgs e)
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