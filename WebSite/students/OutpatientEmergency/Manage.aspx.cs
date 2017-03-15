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

public partial class students_OutpatientEmergency_Manage : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    OutpatientEmergencyModel outpatientEmergencyModel = null;
    OutpatientEmergencyBLL outpatientEmergencyBLL = null;
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
                outpatientEmergencyModel = new OutpatientEmergencyModel();
                outpatientEmergencyBLL = new OutpatientEmergencyBLL();

                outpatientEmergencyModel = outpatientEmergencyBLL.GetModelById(id);
                StudentsRealName.Text = outpatientEmergencyModel.StudentsRealName.ToString();
                TrainingBaseName.Text = outpatientEmergencyModel.TrainingBaseName.ToString();
                ProfessionalBaseName.Text = outpatientEmergencyModel.ProfessionalBaseName.ToString();
                //RotaryDept.SelectedItem.Text = outpatientEmergencyModel.DeptName.ToString();
                RotaryDept.SelectedValue = outpatientEmergencyModel.DeptCode.ToString();
                dt = new LoginBLL().GetTeachersDtByDeptCode(outpatientEmergencyModel.TrainingBaseCode, outpatientEmergencyModel.ProfessionalBaseCode, outpatientEmergencyModel.DeptCode, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = outpatientEmergencyModel.TeacherId;
                //Teacher.SelectedItem.Text = outpatientEmergencyModel.TeacherName.ToString();
                //Teacher.SelectedItem.Value = outpatientEmergencyModel.TeacherId.ToString();
                //RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
                RecordType.SelectedValue = outpatientEmergencyModel.RecordTypeId.ToString();
                DiseaseName.Text = outpatientEmergencyModel.DiseaseName.ToString();
                DiseaseNum.Text = outpatientEmergencyModel.DiseaseNum.ToString();
                Comment.Text = outpatientEmergencyModel.Comment.ToString();
                Writor.Text = outpatientEmergencyModel.Writor.ToString();
                RegisterDate.Text = outpatientEmergencyModel.RegisterDate.ToString();

            }


        }
    }
    protected void save_Click(object sender, EventArgs e)
    {
        outpatientEmergencyModel = new OutpatientEmergencyModel();
        outpatientEmergencyBLL = new OutpatientEmergencyBLL();

        outpatientEmergencyModel.DeptCode = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
        outpatientEmergencyModel.DeptName = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
        outpatientEmergencyModel.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
        outpatientEmergencyModel.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);
        outpatientEmergencyModel.RecordTypeId = CommonFunc.FilterSpecialString(RecordType.SelectedItem.Value);
        outpatientEmergencyModel.RecordTypeName = CommonFunc.FilterSpecialString(RecordType.SelectedItem.Text);
        outpatientEmergencyModel.DiseaseName = CommonFunc.FilterSpecialString(DiseaseName.Text);
        outpatientEmergencyModel.DiseaseNum = CommonFunc.FilterSpecialString(DiseaseNum.Text);
        outpatientEmergencyModel.Comment = CommonFunc.FilterSpecialString(Comment.Text);

        outpatientEmergencyModel.Writor = CommonFunc.FilterSpecialString(Writor.Text);
        outpatientEmergencyModel.RegisterDate = CommonFunc.FilterSpecialString(RegisterDate.Text);

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            outpatientEmergencyModel.Id = id;
            outpatientEmergencyModel.StudentsName = StudentsName.Value.ToString();

            outpatientEmergencyModel.StudentsRealName = CommonFunc.FilterSpecialString(StudentsRealName.Text.Trim());
            outpatientEmergencyModel.TrainingBaseCode = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
            outpatientEmergencyModel.TrainingBaseName = CommonFunc.FilterSpecialString(TrainingBaseName.Text);
            outpatientEmergencyModel.ProfessionalBaseCode = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
            outpatientEmergencyModel.ProfessionalBaseName = CommonFunc.FilterSpecialString(ProfessionalBaseName.Text);
            outpatientEmergencyModel.TeacherCheck = teacher_check;
            outpatientEmergencyModel.KzrCheck = kzr_check;
            outpatientEmergencyModel.BaseCheck = base_check;
            outpatientEmergencyModel.ManagerCheck = manager_check;

            if (outpatientEmergencyModel.DeptCode == "0" || outpatientEmergencyModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (outpatientEmergencyModel.RecordTypeId == "-1" || outpatientEmergencyModel.RecordTypeName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "类型不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(outpatientEmergencyModel.DiseaseName))
            {
                ShowMessageBox.Showmessagebox(this, "接诊病种名称不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(outpatientEmergencyModel.DiseaseNum))
            {
                ShowMessageBox.Showmessagebox(this, "接诊例数不能为空", null);
                return;
            }
            if (outpatientEmergencyModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (outpatientEmergencyBLL.Add(outpatientEmergencyModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('门/急诊诊治记录信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                    

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else
        {
            if (outpatientEmergencyModel.DeptCode == "0" || outpatientEmergencyModel.DeptName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (outpatientEmergencyModel.RecordTypeId == "-1" || outpatientEmergencyModel.RecordTypeName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "类型不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(outpatientEmergencyModel.DiseaseName))
            {
                ShowMessageBox.Showmessagebox(this, "接诊病种名称不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(outpatientEmergencyModel.DiseaseNum))
            {
                ShowMessageBox.Showmessagebox(this, "接诊例数不能为空", null);
                return;
            }
            if (outpatientEmergencyModel.Comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (outpatientEmergencyBLL.Update(outpatientEmergencyModel, id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('门/急诊诊治记录信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                    

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

        Teacher.DataSource = dt;

        Teacher.DataTextField = "real_name";
        Teacher.DataValueField = "name";
        Teacher.DataBind();
        Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
    }
}