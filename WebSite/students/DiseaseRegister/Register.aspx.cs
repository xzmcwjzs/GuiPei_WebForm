using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;
using BLL;

public partial class students_DiseaseRegister_Register : System.Web.UI.Page
{
    DiseaseRegister2Model diseaseRegister2Model = null;
    DiseaseRegister2BLL diseaseRegister2BLL = null;
    protected string teacher_check = "未通过";
    protected string kzr_check = "未通过";
    protected string base_check = "未通过";
    protected string manage_check = "未通过";
    public string id = string.Empty;
    public string pi = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));

        if (!IsPostBack)
        {
            students_name.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["students_name"]));
            students_real_name.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["students_real_name"]));
            training_base_name.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["training_base_name"]));
            training_base_code.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["training_base_code"]));
            professional_base_code.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["professional_base_code"]));
            professional_base_name.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["professional_base_name"]));
            dept_code.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["dept_code"]));
            dept_name.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["dept_name"]));
            TeacherId.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["TeacherId"]));
            TeacherName.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["TeacherName"]));
            required_num.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["required_num"]));
            master_degree.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["master_degree"]));
            writor.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["writor"]));
            register_date.Value = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["register_date"]));
            disease_name.Text = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["disease_name"]));
            //Response.Write("<script>alert('" + students_name.Value + students_real_name.Value + training_base_code.Value + professional_base_code.Value + dept_code.Value + disease_name.Text +writor.Value+"');</script>");

            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                diseaseRegister2Model = new DiseaseRegister2Model();
                diseaseRegister2BLL = new DiseaseRegister2BLL();

                diseaseRegister2Model = diseaseRegister2BLL.GetModelById(id);
                disease_name.Text = diseaseRegister2Model.disease_name.ToString();
                patient_name.Text = diseaseRegister2Model.patient_name.ToString();
                case_num.Text = diseaseRegister2Model.case_num.ToString();
                main_diagnosis.Text = diseaseRegister2Model.main_diagnosis.ToString();
                secondary_diagnosis.Text = diseaseRegister2Model.secondary_diagnosis.ToString();
                is_charge.SelectedValue = diseaseRegister2Model.is_charge;
                is_rescue.SelectedValue = diseaseRegister2Model.is_rescue;
                cure_measure.Text = diseaseRegister2Model.cure_measure;
                visit_date.Text = diseaseRegister2Model.visit_date.ToString();
                comment.Text = diseaseRegister2Model.comment.ToString();
                condition.Text = diseaseRegister2Model.condition.ToString();
            }
        
        
        
        }


        
    }
    protected void save_Click(object sender, EventArgs e)
    {
        diseaseRegister2Model = new DiseaseRegister2Model();
        diseaseRegister2BLL = new DiseaseRegister2BLL();

        
        diseaseRegister2Model.disease_name = CommonFunc.FilterSpecialString(disease_name.Text.ToString());
        diseaseRegister2Model.patient_name = CommonFunc.FilterSpecialString(patient_name.Text.ToString());
        diseaseRegister2Model.case_num = CommonFunc.FilterSpecialString(case_num.Text.ToString());
        diseaseRegister2Model.main_diagnosis = CommonFunc.FilterSpecialString(main_diagnosis.Text.ToString());
        diseaseRegister2Model.secondary_diagnosis = CommonFunc.FilterSpecialString(secondary_diagnosis.Text.ToString());
        diseaseRegister2Model.is_charge = CommonFunc.FilterSpecialString(is_charge.SelectedItem.Text);
        diseaseRegister2Model.is_rescue = CommonFunc.FilterSpecialString(is_rescue.SelectedItem.Text);
        diseaseRegister2Model.cure_measure = CommonFunc.FilterSpecialString(cure_measure.Text.ToString());
        diseaseRegister2Model.visit_date =CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(visit_date.Text.ToString()),"yyyy-MM-dd");
        diseaseRegister2Model.comment = CommonFunc.FilterSpecialString(comment.Text.ToString());
        diseaseRegister2Model.condition = CommonFunc.FilterSpecialString(condition.Text.ToString());
        
        if (string.IsNullOrEmpty(id))
        {
            diseaseRegister2Model.id = Guid.NewGuid().ToString();
            diseaseRegister2Model.students_name = students_name.Value.ToString();
            diseaseRegister2Model.students_real_name = students_real_name.Value.ToString();
            diseaseRegister2Model.training_base_code = training_base_code.Value.ToString();
            diseaseRegister2Model.training_base_name = training_base_name.Value.ToString();
            diseaseRegister2Model.professional_base_code = professional_base_code.Value.ToString();
            diseaseRegister2Model.professional_base_name = professional_base_name.Value.ToString();
            diseaseRegister2Model.dept_code = dept_code.Value.ToString();
            diseaseRegister2Model.dept_name = dept_name.Value.ToString();
            diseaseRegister2Model.TeacherId = TeacherId.Value.ToString();
            diseaseRegister2Model.TeacherName = TeacherName.Value.ToString();
            diseaseRegister2Model.writor = writor.Value.ToString();
            diseaseRegister2Model.register_date = register_date.Value.ToString();
            diseaseRegister2Model.required_num = required_num.Value.ToString();
            diseaseRegister2Model.master_degree = master_degree.Value.ToString();

            diseaseRegister2Model.teacher_check = CommonFunc.FilterSpecialString(teacher_check);
            diseaseRegister2Model.kzr_check = CommonFunc.FilterSpecialString(kzr_check);
            diseaseRegister2Model.base_check = CommonFunc.FilterSpecialString(base_check);
            diseaseRegister2Model.manage_check = CommonFunc.FilterSpecialString(manage_check);
            if (string.IsNullOrEmpty(diseaseRegister2Model.disease_name))
            {
                ShowMessageBox.Showmessagebox(this, "病种名称不能为空", null);
                return;
            }

            if (string.IsNullOrEmpty(diseaseRegister2Model.patient_name))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.case_num))
            {
                ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.main_diagnosis))
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断不能为空", null);
                return;
            }
            if (diseaseRegister2Model.main_diagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断字数不能超过1000字", null);
                return;
            }
            if (diseaseRegister2Model.secondary_diagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, " 次要诊断字数不能超过1000字", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.cure_measure))
            {
                ShowMessageBox.Showmessagebox(this, "治疗措施不能为空", null);
                return;
            }
            if (diseaseRegister2Model.cure_measure.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "治疗措施字数不能超过1000字", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.visit_date))
            {
                ShowMessageBox.Showmessagebox(this, "出诊日期不能为空", null);
                return;
            }
            if (diseaseRegister2Model.comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (diseaseRegister2BLL.Insert(diseaseRegister2Model))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('病种登记成功');window.opener.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }
        }
        else
        {
            if (string.IsNullOrEmpty(diseaseRegister2Model.disease_name))
            {
                ShowMessageBox.Showmessagebox(this, "病种名称不能为空", null);
                return;
            }

            if (string.IsNullOrEmpty(diseaseRegister2Model.patient_name))
            {
                ShowMessageBox.Showmessagebox(this, "病人姓名不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.case_num))
            {
                ShowMessageBox.Showmessagebox(this, "病历号不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.main_diagnosis))
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断不能为空", null);
                return;
            }
            if (diseaseRegister2Model.main_diagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "主要诊断字数不能超过1000字", null);
                return;
            }
            if (diseaseRegister2Model.secondary_diagnosis.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, " 次要诊断字数不能超过1000字", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.cure_measure))
            {
                ShowMessageBox.Showmessagebox(this, "治疗措施不能为空", null);
                return;
            }
            if (diseaseRegister2Model.cure_measure.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "治疗措施字数不能超过1000字", null);
                return;
            }
            if (string.IsNullOrEmpty(diseaseRegister2Model.visit_date))
            {
                ShowMessageBox.Showmessagebox(this, "出诊日期不能为空", null);
                return;
            }
            if (diseaseRegister2Model.comment.Length > 1000)
            {
                ShowMessageBox.Showmessagebox(this, "备注字数不能超过1000字", null);
                return;
            }
            if (diseaseRegister2BLL.Update(diseaseRegister2Model,id))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('病种登记修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }
        }

        
    }
}