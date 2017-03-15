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

public partial class students_WriteMedicalRecords_Manage : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    WriteMedicalRecordsModel writeMedicalRecordsModel = null;
    WriteMedicalRecordsBLL writeMedicalRecordsBLL = null;
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
                writeMedicalRecordsModel = new WriteMedicalRecordsModel();
                writeMedicalRecordsBLL = new WriteMedicalRecordsBLL();

                writeMedicalRecordsModel = writeMedicalRecordsBLL.GetModelById(id);
                StudentsRealName.Text = writeMedicalRecordsModel.StudentsRealName.ToString();
                TrainingBaseName.Text = writeMedicalRecordsModel.TrainingBaseName.ToString();
                ProfessionalBaseName.Text = writeMedicalRecordsModel.ProfessionalBaseName.ToString();
                //RotaryDept.SelectedItem.Text = writeMedicalRecordsModel.DeptName.ToString();
                RotaryDept.SelectedValue = writeMedicalRecordsModel.DeptCode.ToString();
                dt = new LoginBLL().GetTeachersDtByDeptCode(writeMedicalRecordsModel.TrainingBaseCode, writeMedicalRecordsModel.ProfessionalBaseCode, writeMedicalRecordsModel.DeptCode, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = writeMedicalRecordsModel.TeacherId;
                //Teacher.SelectedItem.Text = writeMedicalRecordsModel.TeacherName.ToString();
                //Teacher.SelectedItem.Value = writeMedicalRecordsModel.TeacherId.ToString();
                //RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
                PatientName.Text = writeMedicalRecordsModel.PatientName.ToString();
                CaseId.Text = writeMedicalRecordsModel.CaseId.ToString();
                MainDiagnosis.Text = writeMedicalRecordsModel.MainDiagnosis.ToString();
                SuperiorDoctor.Text = writeMedicalRecordsModel.SuperiorDoctor.ToString();
                IsBigCase.SelectedValue = writeMedicalRecordsModel.IsBigCase.ToString();
                Comment.Text = writeMedicalRecordsModel.Comment.ToString();
                Writor.Text = writeMedicalRecordsModel.Writor.ToString();
                RegisterDate.Text = writeMedicalRecordsModel.RegisterDate.ToString();

            }


        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        writeMedicalRecordsModel = new WriteMedicalRecordsModel();
        writeMedicalRecordsBLL = new WriteMedicalRecordsBLL();

        writeMedicalRecordsModel.DeptCode = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
        writeMedicalRecordsModel.DeptName = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
        writeMedicalRecordsModel.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
        writeMedicalRecordsModel.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);

        writeMedicalRecordsModel.PatientName = CommonFunc.FilterSpecialString(PatientName.Text);
        writeMedicalRecordsModel.CaseId = CommonFunc.FilterSpecialString(CaseId.Text);
        writeMedicalRecordsModel.MainDiagnosis = CommonFunc.FilterSpecialString(MainDiagnosis.Text);
        writeMedicalRecordsModel.SuperiorDoctor = CommonFunc.FilterSpecialString(SuperiorDoctor.Text);
        writeMedicalRecordsModel.IsBigCase = CommonFunc.FilterSpecialString(IsBigCase.SelectedItem.Value);

        writeMedicalRecordsModel.Comment = CommonFunc.FilterSpecialString(Comment.Text);

        writeMedicalRecordsModel.Writor = CommonFunc.FilterSpecialString(Writor.Text);
        writeMedicalRecordsModel.RegisterDate = CommonFunc.FilterSpecialString(RegisterDate.Text);

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            writeMedicalRecordsModel.Id = id;
            writeMedicalRecordsModel.StudentsName = StudentsName.Value.ToString();

            writeMedicalRecordsModel.StudentsRealName = CommonFunc.FilterSpecialString(StudentsRealName.Text.Trim());
            writeMedicalRecordsModel.TrainingBaseCode = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
            writeMedicalRecordsModel.TrainingBaseName = CommonFunc.FilterSpecialString(TrainingBaseName.Text);
            writeMedicalRecordsModel.ProfessionalBaseCode = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
            writeMedicalRecordsModel.ProfessionalBaseName = CommonFunc.FilterSpecialString(ProfessionalBaseName.Text);
            writeMedicalRecordsModel.TeacherCheck = teacher_check;
            writeMedicalRecordsModel.KzrCheck = kzr_check;
            writeMedicalRecordsModel.BaseCheck = base_check;
            writeMedicalRecordsModel.ManagerCheck = manager_check;

            if (writeMedicalRecordsModel.DeptCode == "0" || writeMedicalRecordsModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (writeMedicalRecordsModel.TeacherId == "0" || writeMedicalRecordsModel.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(writeMedicalRecordsModel.PatientName))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(writeMedicalRecordsModel.CaseId))
            {
                ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(writeMedicalRecordsModel.MainDiagnosis))
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断不能为空", null);
                return;
            }
            if (writeMedicalRecordsModel.MainDiagnosis.Length > 2000)
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断字数不能超过2000字", null);
                return;
            }
            if (writeMedicalRecordsModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (writeMedicalRecordsBLL.Add(writeMedicalRecordsModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('病历信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                     
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else
        {
            if (writeMedicalRecordsModel.DeptCode == "0" || writeMedicalRecordsModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(writeMedicalRecordsModel.PatientName))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(writeMedicalRecordsModel.CaseId))
            {
                ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(writeMedicalRecordsModel.MainDiagnosis))
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断不能为空", null);
                return;
            }
            if (writeMedicalRecordsModel.MainDiagnosis.Length > 2000)
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断字数不能超过2000字", null);
                return;
            }
            if (writeMedicalRecordsModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (writeMedicalRecordsBLL.Update(writeMedicalRecordsModel, id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('病历录信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                    
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