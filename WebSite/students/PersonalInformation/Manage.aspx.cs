using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
using Model;

public partial class students_PersonalInformation_Manage : System.Web.UI.Page
{

    protected string id = string.Empty;
    protected string pi = string.Empty;
    StudentsPersonalInformationBLL studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentsPersonalInformationModel studentsPersonalInformationModel = null;
        id = CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]);
        pi = CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]);
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        
        if (!IsPostBack) {
            studentsPersonalInformationModel = new StudentsPersonalInformationModel();
            studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelById(id);

            real_name.Text = studentsPersonalInformationModel.real_name.ToString();

            sex.SelectedValue = studentsPersonalInformationModel.sex.ToString();

            id_number.Text = studentsPersonalInformationModel.id_number.ToString();

            datebirth.Text = studentsPersonalInformationModel.datebirth.ToString();
            age.Text = studentsPersonalInformationModel.age.ToString();
            datebirth1.Value = studentsPersonalInformationModel.datebirth.ToString();
            age1.Value = studentsPersonalInformationModel.age.ToString();

            province1.Value = studentsPersonalInformationModel.province.ToString();
            city1.Value = studentsPersonalInformationModel.city.ToString();
            area1.Value = studentsPersonalInformationModel.area.ToString();

            detail_address.Text = studentsPersonalInformationModel.detail_address.ToString();
            telephon.Text = studentsPersonalInformationModel.telephon.ToString();
            mail.Text = studentsPersonalInformationModel.mail.ToString();

            minzu.SelectedValue = studentsPersonalInformationModel.minzu.ToString();

            bk_school.Text = studentsPersonalInformationModel.bk_school.ToString();
            bk_major.Text = studentsPersonalInformationModel.bk_major.ToString();
            graduation_time.Text = studentsPersonalInformationModel.graduation_time.ToString();

            high_education.SelectedValue = studentsPersonalInformationModel.high_education.ToString();

            high_school.Text = studentsPersonalInformationModel.high_school.ToString();
            high_major.Text = studentsPersonalInformationModel.high_major.ToString();
            high_education_time.Text = studentsPersonalInformationModel.high_education_time.ToString();

            identity_type.SelectedValue = studentsPersonalInformationModel.identity_type.ToString();

            send_unit.Text = studentsPersonalInformationModel.send_unit.ToString();

            training_base_province_code.Value = studentsPersonalInformationModel.training_base_province_code.ToString();
            training_base_province_name.Value = studentsPersonalInformationModel.training_base_province_name.ToString();
            training_base_code.Value = studentsPersonalInformationModel.training_base_code.ToString();
            training_base_name.Value = studentsPersonalInformationModel.training_base_name.ToString();

            collaborative_unit.Text = studentsPersonalInformationModel.collaborative_unit.ToString();

            professional_base_code.Value = studentsPersonalInformationModel.professional_base_code.ToString();
            professional_base_name.Value = studentsPersonalInformationModel.professional_base_name.ToString();

            training_time.Text = studentsPersonalInformationModel.training_time.ToString();

            plan_training_time.SelectedValue = studentsPersonalInformationModel.plan_training_time.ToString();

            writor.Text = studentsPersonalInformationModel.writor.ToString();
            register_date.Text = studentsPersonalInformationModel.register_date.ToString();
        
        }
        


    }
    protected void save_Click(object sender, EventArgs e)
    {
        bool count ;
        datebirth.Text = datebirth1.Value;
        age.Text = age1.Value;
        StudentsPersonalInformationModel studentspersonalinformationModel = new StudentsPersonalInformationModel();

        studentspersonalinformationModel.id = id;
        studentspersonalinformationModel.real_name = CommonFunc.FilterSpecialString(real_name.Text.Trim());
        studentspersonalinformationModel.sex = CommonFunc.FilterSpecialString(sex.SelectedValue.Trim());
        studentspersonalinformationModel.age = CommonFunc.FilterSpecialString(age.Text.Trim());
        studentspersonalinformationModel.datebirth = CommonFunc.FilterSpecialString(datebirth.Text.Trim());
        studentspersonalinformationModel.minzu = CommonFunc.FilterSpecialString(minzu.SelectedValue.Trim());

        studentspersonalinformationModel.province = CommonFunc.FilterSpecialString(province1.Value.Trim());
        studentspersonalinformationModel.city = CommonFunc.FilterSpecialString(city1.Value.Trim());
        studentspersonalinformationModel.area = CommonFunc.FilterSpecialString(area1.Value.Trim());
        studentspersonalinformationModel.detail_address = CommonFunc.FilterSpecialString(detail_address.Text.Trim());
        studentspersonalinformationModel.id_number = CommonFunc.FilterSpecialString(id_number.Text.Trim());
        studentspersonalinformationModel.telephon = CommonFunc.FilterSpecialString(telephon.Text.Trim());
        studentspersonalinformationModel.mail = CommonFunc.FilterSpecialString(mail.Text.Trim());
        studentspersonalinformationModel.bk_school = CommonFunc.FilterSpecialString(bk_school.Text.Trim());
        studentspersonalinformationModel.bk_major = CommonFunc.FilterSpecialString(bk_major.Text.Trim());
        studentspersonalinformationModel.graduation_time =CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(graduation_time.Text.Trim()),"yyyy-MM");
        studentspersonalinformationModel.high_education = CommonFunc.FilterSpecialString(high_education.Text.Trim());
        studentspersonalinformationModel.high_school = CommonFunc.FilterSpecialString(high_school.Text.Trim());
        studentspersonalinformationModel.high_major = CommonFunc.FilterSpecialString(high_major.Text.Trim());
        studentspersonalinformationModel.high_education_time =CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(high_education_time.Text.Trim()),"yyyy-MM");
        studentspersonalinformationModel.identity_type = CommonFunc.FilterSpecialString(identity_type.SelectedValue.Trim());
        studentspersonalinformationModel.send_unit = CommonFunc.FilterSpecialString(send_unit.Text.Trim());
        studentspersonalinformationModel.training_base_province_code = CommonFunc.FilterSpecialString(training_base_province_code.Value.Trim());
        studentspersonalinformationModel.training_base_province_name = CommonFunc.FilterSpecialString(training_base_province_name.Value.Trim());
        studentspersonalinformationModel.training_base_code = CommonFunc.FilterSpecialString(training_base_code.Value.Trim());
        studentspersonalinformationModel.training_base_name = CommonFunc.FilterSpecialString(training_base_name.Value.Trim());
        studentspersonalinformationModel.collaborative_unit = CommonFunc.FilterSpecialString(collaborative_unit.Text.Trim());
        studentspersonalinformationModel.professional_base_code = CommonFunc.FilterSpecialString(professional_base_code.Value.Trim());
        studentspersonalinformationModel.professional_base_name = CommonFunc.FilterSpecialString(professional_base_name.Value.Trim());
        studentspersonalinformationModel.training_time = CommonFunc.FilterSpecialString(training_time.Text.Trim());
        studentspersonalinformationModel.plan_training_time = CommonFunc.FilterSpecialString(plan_training_time.Text.Trim());
        studentspersonalinformationModel.writor = CommonFunc.FilterSpecialString(writor.Text.Trim());
        studentspersonalinformationModel.register_date = CommonFunc.FilterSpecialString(register_date.Text.Trim());
        if (string.IsNullOrEmpty(studentspersonalinformationModel.id_number))
        {
            ShowMessageBox.Showmessagebox(this, "居民身份证号码不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.detail_address))
        {
            ShowMessageBox.Showmessagebox(this, "家庭详细地址不能为空", null);
            return;
        }
        if (studentspersonalinformationModel.detail_address.Length > 70)
        {
            ShowMessageBox.Showmessagebox(this, "家庭常住地址不能大于70个字符", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.sex))
        {
            ShowMessageBox.Showmessagebox(this, "性别不能为空", null);
            return;
        }


        if (string.IsNullOrEmpty(studentspersonalinformationModel.telephon))
        {
            ShowMessageBox.Showmessagebox(this, "常用手机号码不能为空", null);
            return;
        }
        if (!ValidityCheck.PhoneNumIsValid(studentspersonalinformationModel.telephon, this)) return;
        if (string.IsNullOrEmpty(studentspersonalinformationModel.mail))
        {
            ShowMessageBox.Showmessagebox(this, "常用邮箱不能为空", null);
            return;
        }
        if (!ValidityCheck.EmailIsValid(studentspersonalinformationModel.mail, this)) return;

        if (string.IsNullOrEmpty(studentspersonalinformationModel.high_school))
        {
            ShowMessageBox.Showmessagebox(this, "最高学历毕业院校不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.high_major))
        {
            ShowMessageBox.Showmessagebox(this, "最高学历专业不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.high_education_time))
        {
            ShowMessageBox.Showmessagebox(this, "获得最高学历时间不能为空", null);
            return;
        }

        if (studentspersonalinformationModel.identity_type == "单位人")
        {
            if (string.IsNullOrEmpty(studentspersonalinformationModel.send_unit))
            {
                ShowMessageBox.Showmessagebox(this, "派出单位不能为空", null);
            }
            
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.training_base_name))
        {
            ShowMessageBox.Showmessagebox(this, "培训基地不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.professional_base_name))
        {
            ShowMessageBox.Showmessagebox(this, "培训专业不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.training_time))
        {
            ShowMessageBox.Showmessagebox(this, "参训时间不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(studentspersonalinformationModel.plan_training_time))
        {
            ShowMessageBox.Showmessagebox(this, "计划参训时间不能为空", null);
            return;
        }


        StudentsPersonalInformationBLL studentspersonalinformationBLL = new StudentsPersonalInformationBLL();
        
        count = studentspersonalinformationBLL.UpdateStudentsPersonalInformation(studentspersonalinformationModel);
        if (count)
        {
            try
            {
                Response.Write("<script> alert('个人信息修改成功');window.opener.window.loadPageList('"+pi+"');window.close();</script>");
               
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
        else {
            Response.Write("<script> alert('个人信息修改失败');</script>");
            
        }
    }
}