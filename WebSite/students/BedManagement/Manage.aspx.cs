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

public partial class students_BedManagement_Manage : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    BedManagementModel bedManagementMode = null;
    BedManagementBLL bedManagementBLL = null;
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
            writor.Text = loginModel.real_name;
            students_real_name.Text = loginModel.real_name; students_real_name.ReadOnly = true;
            if (string.IsNullOrEmpty(id))
            {
                register_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }


            na = loginModel.name;
            students_name.Value = na;
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
                bedManagementMode = new BedManagementModel();
                bedManagementBLL = new BedManagementBLL();

                bedManagementMode = bedManagementBLL.GetModelById(id);
                students_real_name.Text = bedManagementMode.students_real_name.ToString();
                training_base_name.Text = bedManagementMode.training_base_name.ToString();
                professional_base_name.Text = bedManagementMode.professional_base_name.ToString();
                //RotaryDept.SelectedItem.Text = bedManagementMode.dept_name.ToString();
                RotaryDept.SelectedValue = bedManagementMode.dept_code.ToString();
                //RotaryDept.Items.Insert(0, new ListItem("==请选择==", "0"));
                dt = new LoginBLL().GetTeachersDtByDeptCode(bedManagementMode.training_base_code, bedManagementMode.professional_base_code, bedManagementMode.dept_code, "teachers");
                Teacher.DataSource = dt;
                Teacher.DataTextField = "real_name";
                Teacher.DataValueField = "name";
                Teacher.DataBind();
                Teacher.Items.Insert(0, new ListItem("==请选择==", "0"));
                Teacher.SelectedValue = bedManagementMode.TeacherId;
                //Teacher.SelectedItem.Text = bedManagementMode.TeacherName.ToString();
                //Teacher.SelectedItem.Value = bedManagementMode.TeacherId.ToString();

                
                patient_name.Text = bedManagementMode.patient_name.ToString();
                patient_id.Text = bedManagementMode.patient_id.ToString();
                bed_id.Text = bedManagementMode.bed_id.ToString();
                bed_card.Text = bedManagementMode.bed_card.ToString();
                bed_price.Text = bedManagementMode.bed_price.ToString();
                bed_status.Text = bedManagementMode.bed_status.ToString();
                room_id.Text = bedManagementMode.room_id.ToString();
                building_id.Text = bedManagementMode.building_id.ToString();
                comment.Text = bedManagementMode.comment.ToString();
                writor.Text = bedManagementMode.writor.ToString();
                register_date.Text = bedManagementMode.register_date.ToString();

            }


        }

    }
    protected void save_Click(object sender, EventArgs e)
    {
        bedManagementMode = new BedManagementModel();
        bedManagementBLL = new BedManagementBLL();

        bedManagementMode.dept_code = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Value);
        bedManagementMode.dept_name = CommonFunc.FilterSpecialString(RotaryDept.SelectedItem.Text);
        bedManagementMode.TeacherId = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Value);
        bedManagementMode.TeacherName = CommonFunc.FilterSpecialString(Teacher.SelectedItem.Text);

        bedManagementMode.patient_name = CommonFunc.FilterSpecialString(patient_name.Text);
        bedManagementMode.patient_id = CommonFunc.FilterSpecialString(patient_id.Text);
        bedManagementMode.bed_id = CommonFunc.FilterSpecialString(bed_id.Text);
        bedManagementMode.bed_card = CommonFunc.FilterSpecialString(bed_card.Text);
        bedManagementMode.bed_price = CommonFunc.FilterSpecialString(bed_price.Text);
        bedManagementMode.bed_status = CommonFunc.FilterSpecialString(bed_status.Text);
        bedManagementMode.room_id = CommonFunc.FilterSpecialString(room_id.Text);
        bedManagementMode.building_id = CommonFunc.FilterSpecialString(building_id.Text);
        bedManagementMode.comment = CommonFunc.FilterSpecialString(comment.Text);
        bedManagementMode.writor = CommonFunc.FilterSpecialString(writor.Text);
        bedManagementMode.register_date = CommonFunc.FilterSpecialString(register_date.Text.Trim());

        if (string.IsNullOrEmpty(id))
        {

            id = Guid.NewGuid().ToString();
            bedManagementMode.id = id;
            bedManagementMode.students_name =students_name.Value.ToString();

            bedManagementMode.students_real_name = CommonFunc.FilterSpecialString(students_real_name.Text.Trim());
            bedManagementMode.training_base_code = CommonFunc.FilterSpecialString(TrainingBaseCode.Value);
            bedManagementMode.training_base_name = CommonFunc.FilterSpecialString(training_base_name.Text);
            bedManagementMode.professional_base_code = CommonFunc.FilterSpecialString(ProfessionalBaseCode.Value);
            bedManagementMode.professional_base_name = CommonFunc.FilterSpecialString(professional_base_name.Text);
            bedManagementMode.teacher_check = teacher_check;
            bedManagementMode.kzr_check = kzr_check;
            bedManagementMode.base_check = base_check;
            bedManagementMode.manager_check = manager_check;
            

            if (bedManagementMode.dept_code == "0" || bedManagementMode.dept_name == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (bedManagementMode.TeacherId == "0" || bedManagementMode.TeacherName == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "指导医师不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.patient_name))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.bed_id))
            {
                ShowMessageBox.Showmessagebox(this, "床位编号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.bed_status))
            {
                ShowMessageBox.Showmessagebox(this, "床位状态不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.room_id))
            {
                ShowMessageBox.Showmessagebox(this, "房间号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.building_id))
            {
                ShowMessageBox.Showmessagebox(this, "所在楼不能为空", null);
                return;
            }
            if (bedManagementMode.comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (bedManagementBLL.Add(bedManagementMode))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('床位管理信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                  
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else
        {
            if (bedManagementMode.dept_code == "0" || bedManagementMode.dept_name == "==请选择==")
            {
                ShowMessageBox.Showmessagebox(this, "轮转科室不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.patient_name))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.bed_id))
            {
                ShowMessageBox.Showmessagebox(this, "床位编号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.bed_status))
            {
                ShowMessageBox.Showmessagebox(this, "床位状态不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.room_id))
            {
                ShowMessageBox.Showmessagebox(this, "房间号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(bedManagementMode.building_id))
            {
                ShowMessageBox.Showmessagebox(this, "所在楼不能为空", null);
                return;
            }
            if (bedManagementMode.comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (bedManagementBLL.Update(bedManagementMode, id))
            {

                try
                {
                    Response.Write("<script language='javascript'> alert('床位管理信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                   
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }

    }
    protected void rotary_dept_SelectedIndexChanged(object sender, EventArgs e)
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