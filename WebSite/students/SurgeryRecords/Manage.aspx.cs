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

public partial class students_SurgeryRecords_Manage : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    SurgeryRecordsModel surgeryRecordsModel = null;
    SurgeryRecordsBLL surgeryRecordsBLL = null;
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
                surgeryRecordsModel = new SurgeryRecordsModel();
                surgeryRecordsBLL = new SurgeryRecordsBLL();

                surgeryRecordsModel = surgeryRecordsBLL.GetModelById(id);
                StudentsRealName.Text = surgeryRecordsModel.StudentsRealName.ToString();
                TrainingBaseName.Text = surgeryRecordsModel.TrainingBaseName.ToString();
                ProfessionalBaseName.Text = surgeryRecordsModel.ProfessionalBaseName.ToString();
                //RotaryDept.SelectedItem.Text = surgeryRecordsModel.DeptName.ToString();
                RotaryDept.SelectedValue = surgeryRecordsModel.DeptCode.ToString();
                //RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
                dt = new LoginBLL().GetTeachersDtByDeptCode(surgeryRecordsModel.TrainingBaseCode, surgeryRecordsModel.ProfessionalBaseCode, surgeryRecordsModel.DeptCode, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = surgeryRecordsModel.TeacherId;
                //Teacher.SelectedItem.Text = surgeryRecordsModel.TeacherName.ToString();
                //Teacher.SelectedItem.Value = surgeryRecordsModel.TeacherId.ToString();
                PatientName.Text = surgeryRecordsModel.PatientName.ToString();
                CaseId.Text = surgeryRecordsModel.CaseId.ToString();
                SurgeryName.Text = surgeryRecordsModel.SurgeryName.ToString();
                IntraoperativePosition.Text = surgeryRecordsModel.IntraoperativePosition.ToString();
                RoomId.Text = surgeryRecordsModel.RoomId.ToString();
                MainDiagnosis.Text = surgeryRecordsModel.MainDiagnosis.ToString();
                SecondaryDiagnosis.Text = surgeryRecordsModel.SecondaryDiagnosis.ToString();
                Emergency.SelectedValue = surgeryRecordsModel.Emergency.ToString();
                SurgeryDate.Text = surgeryRecordsModel.SurgeryDate.ToString();
                SurgeryScale.Text = surgeryRecordsModel.SurgeryScale.ToString();
                DoctorInCharge.Text = surgeryRecordsModel.DoctorInCharge.ToString();
                Assistant.Text = surgeryRecordsModel.Assistant.ToString();
                Nurse.Text = surgeryRecordsModel.Nurse.ToString();
                AnesthesiaMethod.Text = surgeryRecordsModel.AnesthesiaMethod.ToString();
                Anesthetist.Text = surgeryRecordsModel.Anesthetist.ToString();
                SurgeryIsStop.SelectedValue = surgeryRecordsModel.SurgeryIsStop.ToString();
                if (surgeryRecordsModel.SurgeryIsStop == "否")
                {
                    //StopReason.Text = surgeryRecordsModel.StopReason.ToString();
                    StopReason.Enabled = false;
                }
                else
                {
                    StopReason.Text = surgeryRecordsModel.StopReason.ToString();
                    StopReason.Enabled = true;
                }
                
                Comment.Text = surgeryRecordsModel.Comment.ToString();
                Writor.Text = surgeryRecordsModel.Writor.ToString();
                RegisterDate.Text = surgeryRecordsModel.RegisterDate.ToString();

            }


        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        surgeryRecordsModel = new SurgeryRecordsModel();
        surgeryRecordsBLL = new SurgeryRecordsBLL();

        surgeryRecordsModel.DeptCode = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
        surgeryRecordsModel.DeptName = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
        surgeryRecordsModel.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
        surgeryRecordsModel.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);

        surgeryRecordsModel.PatientName = CommonFunc.FilterSpecialString(PatientName.Text);
        surgeryRecordsModel.CaseId = CommonFunc.FilterSpecialString(CaseId.Text);
        surgeryRecordsModel.SurgeryName = CommonFunc.FilterSpecialString(SurgeryName.Text);
        surgeryRecordsModel.IntraoperativePosition = CommonFunc.FilterSpecialString(IntraoperativePosition.Text);
        surgeryRecordsModel.RoomId = CommonFunc.FilterSpecialString(RoomId.Text);
        surgeryRecordsModel.MainDiagnosis = CommonFunc.FilterSpecialString(MainDiagnosis.Text);
        surgeryRecordsModel.SecondaryDiagnosis = CommonFunc.FilterSpecialString(SecondaryDiagnosis.Text);
        surgeryRecordsModel.Emergency = CommonFunc.FilterSpecialString(Emergency.SelectedItem.Text);
        surgeryRecordsModel.SurgeryDate = CommonFunc.FilterSpecialString(SurgeryDate.Text);
        surgeryRecordsModel.SurgeryScale = CommonFunc.FilterSpecialString(SurgeryScale.Text);
        surgeryRecordsModel.DoctorInCharge = CommonFunc.FilterSpecialString(DoctorInCharge.Text);
        surgeryRecordsModel.Assistant = CommonFunc.FilterSpecialString(Assistant.Text);
        surgeryRecordsModel.Nurse = CommonFunc.FilterSpecialString(Nurse.Text);
        surgeryRecordsModel.AnesthesiaMethod = CommonFunc.FilterSpecialString(AnesthesiaMethod.Text);
        surgeryRecordsModel.Anesthetist = CommonFunc.FilterSpecialString(Anesthetist.Text);
        surgeryRecordsModel.SurgeryIsStop = CommonFunc.FilterSpecialString(SurgeryIsStop.SelectedItem.Text);
        surgeryRecordsModel.StopReason = CommonFunc.FilterSpecialString(StopReason.Text);

        surgeryRecordsModel.Comment = CommonFunc.FilterSpecialString(Comment.Text);
        
        surgeryRecordsModel.Writor = CommonFunc.FilterSpecialString(Writor.Text);
        surgeryRecordsModel.RegisterDate = CommonFunc.FilterSpecialString(RegisterDate.Text);

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            surgeryRecordsModel.Id = id;
            surgeryRecordsModel.StudentsName = StudentsName.Value.ToString();

            surgeryRecordsModel.StudentsRealName = CommonFunc.FilterSpecialString(StudentsRealName.Text.Trim());
            surgeryRecordsModel.TrainingBaseCode = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
            surgeryRecordsModel.TrainingBaseName = CommonFunc.FilterSpecialString(TrainingBaseName.Text);
            surgeryRecordsModel.ProfessionalBaseCode = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
            surgeryRecordsModel.ProfessionalBaseName = CommonFunc.FilterSpecialString(ProfessionalBaseName.Text);
            surgeryRecordsModel.TeacherCheck = teacher_check;
            surgeryRecordsModel.KzrCheck = kzr_check;
            surgeryRecordsModel.BaseCheck = base_check;
            surgeryRecordsModel.ManagerCheck = manager_check;

            if (surgeryRecordsModel.DeptCode == "0" || surgeryRecordsModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (surgeryRecordsModel.TeacherId == "0" || surgeryRecordsModel.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.PatientName))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.CaseId))
            {
                ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.SurgeryName))
            {
                ShowMessageBox.Showmessagebox(this, "手术名称不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.IntraoperativePosition))
            {
                ShowMessageBox.Showmessagebox(this, "术中职务不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.MainDiagnosis))
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断不能为空", null);
                return;
            }
            if (surgeryRecordsModel.MainDiagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断字数不能超过1000字", null);
                return;
            }
            if (surgeryRecordsModel.SecondaryDiagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "次要诊断字数不能超过1000字", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.DoctorInCharge))
            {
                ShowMessageBox.Showmessagebox(this, "主刀医师不能为空", null);
                return;
            }
            if (surgeryRecordsModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (surgeryRecordsBLL.Add(surgeryRecordsModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('手术记录信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else
        {
            if (surgeryRecordsModel.DeptCode == "0" || surgeryRecordsModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (surgeryRecordsModel.TeacherId == "0" || surgeryRecordsModel.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.PatientName))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.CaseId))
            {
                ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.SurgeryName))
            {
                ShowMessageBox.Showmessagebox(this, "手术名称不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.IntraoperativePosition))
            {
                ShowMessageBox.Showmessagebox(this, "术中职务不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.MainDiagnosis))
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断不能为空", null);
                return;
            }
            if (surgeryRecordsModel.MainDiagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断字数不能超过1000字", null);
                return;
            }
            if (surgeryRecordsModel.SecondaryDiagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "次要诊断字数不能超过1000字", null);
                return;
            }
            if (string.IsNullOrEmpty(surgeryRecordsModel.DoctorInCharge))
            {
                ShowMessageBox.Showmessagebox(this, "主刀医师不能为空", null);
                return;
            }
            if (surgeryRecordsModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (surgeryRecordsBLL.Update(surgeryRecordsModel, id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('手术记录信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                    Response.End();

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