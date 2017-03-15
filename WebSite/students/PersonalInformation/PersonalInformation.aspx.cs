using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;


public partial class students_PersonalInformation_PersonalInformation : System.Web.UI.Page
{
    LoginModel loginModel = new LoginModel();
    static string  na;
    StudentsPersonalInformationBLL studentsPersonalInformationBLL = null;
    StudentsPersonalInformationModel studentsPersonalInformationModel = null;
    protected string pi = string.Empty;
    protected string id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
         pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));
         id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        
        if (!IsPostBack) {
            loginModel = (LoginModel)Session["loginModel"];
            writor.Text = loginModel.real_name;
            real_name.Text = loginModel.real_name;
            register_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            na = loginModel.name;
            training_time.Text = DateTime.Now.Year.ToString() + "年";

            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                studentsPersonalInformationModel = new StudentsPersonalInformationModel();
                studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
                studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelById(id);

                real_name.Text =studentsPersonalInformationModel.real_name==null?"":studentsPersonalInformationModel.real_name.ToString();

                sex.SelectedValue =studentsPersonalInformationModel.sex==null?"":studentsPersonalInformationModel.sex.ToString();

                id_number.Text = studentsPersonalInformationModel.id_number == null ? "" : studentsPersonalInformationModel.id_number.ToString();

                datebirth.Text = studentsPersonalInformationModel.datebirth == null ? "" : studentsPersonalInformationModel.datebirth.ToString();
                age.Text = studentsPersonalInformationModel.age == null ? "" : studentsPersonalInformationModel.age.ToString();
                datebirth.Text = studentsPersonalInformationModel.datebirth == null ? "" : studentsPersonalInformationModel.datebirth.ToString();
                age.Text = studentsPersonalInformationModel.age == null ? "" : studentsPersonalInformationModel.age.ToString();

                province_name.Value = studentsPersonalInformationModel.province == null ? "" : studentsPersonalInformationModel.province.ToString();
                city_name.Value = studentsPersonalInformationModel.city == null ? "" : studentsPersonalInformationModel.city.ToString();
                area_name.Value = studentsPersonalInformationModel.area == null ? "" : studentsPersonalInformationModel.area.ToString();

                province_code.Value = studentsPersonalInformationModel.province_code == null ? "" : studentsPersonalInformationModel.province_code.ToString();
                city_code.Value = studentsPersonalInformationModel.city_code == null ? "" : studentsPersonalInformationModel.city_code.ToString();
                area_code.Value = studentsPersonalInformationModel.area_code == null ? "" : studentsPersonalInformationModel.area_code.ToString();

                detail_address.Text = studentsPersonalInformationModel.detail_address == null ? "" : studentsPersonalInformationModel.detail_address.ToString();
                telephon.Text = studentsPersonalInformationModel.telephon == null ? "" : studentsPersonalInformationModel.telephon.ToString();
                mail.Text = studentsPersonalInformationModel.mail == null ? "" : studentsPersonalInformationModel.mail.ToString();

                minzu.SelectedValue = studentsPersonalInformationModel.minzu == null ? "" : studentsPersonalInformationModel.minzu.ToString();

                bk_school.Text = studentsPersonalInformationModel.bk_school == null ? "" : studentsPersonalInformationModel.bk_school.ToString();
                bk_major.Text = studentsPersonalInformationModel.bk_major == null ? "" : studentsPersonalInformationModel.bk_major.ToString();
                graduation_time.Text = studentsPersonalInformationModel.graduation_time == null ? "" : studentsPersonalInformationModel.graduation_time.ToString();

                high_education.SelectedValue = studentsPersonalInformationModel.sex == null ? "" : studentsPersonalInformationModel.high_education.ToString();

                high_school.Text = studentsPersonalInformationModel.high_school == null ? "" : studentsPersonalInformationModel.high_school.ToString();
                high_major.Text = studentsPersonalInformationModel.high_major == null ? "" : studentsPersonalInformationModel.high_major.ToString();
                high_education_time.Text = studentsPersonalInformationModel.high_education_time == null ? "" : studentsPersonalInformationModel.high_education_time.ToString();

                identity_type.SelectedValue = studentsPersonalInformationModel.identity_type == null ? "" : studentsPersonalInformationModel.identity_type.ToString();

                send_unit.Text = studentsPersonalInformationModel.send_unit == null ? "" : studentsPersonalInformationModel.send_unit.ToString();

                training_base_province_code.Value = studentsPersonalInformationModel.training_base_province_code == null ? "" : studentsPersonalInformationModel.training_base_province_code.ToString();
                training_base_province_name.Value = studentsPersonalInformationModel.training_base_province_name == null ? "" : studentsPersonalInformationModel.training_base_province_name.ToString();
                training_base_code.Value = studentsPersonalInformationModel.training_base_code == null ? "" : studentsPersonalInformationModel.training_base_code.ToString();
                training_base_name.Value = studentsPersonalInformationModel.training_base_name == null ? "" : studentsPersonalInformationModel.training_base_name.ToString();

                collaborative_unit.Text = studentsPersonalInformationModel.collaborative_unit == null ? "" : studentsPersonalInformationModel.collaborative_unit.ToString();

                professional_base_code.Value = studentsPersonalInformationModel.professional_base_code == null ? "" : studentsPersonalInformationModel.professional_base_code.ToString();
                professional_base_name.Value = studentsPersonalInformationModel.professional_base_name == null ? "" : studentsPersonalInformationModel.professional_base_name.ToString();

                training_time.Text = studentsPersonalInformationModel.training_time == null ? "" : studentsPersonalInformationModel.training_time.ToString();

                plan_training_time.SelectedValue = studentsPersonalInformationModel.plan_training_time == null ? "" : studentsPersonalInformationModel.plan_training_time.ToString();

                writor.Text = studentsPersonalInformationModel.writor == null ? "" : studentsPersonalInformationModel.writor.ToString();
                register_date.Text = studentsPersonalInformationModel.register_date == null ? "" : studentsPersonalInformationModel.register_date.ToString();

                urgent.Text = studentsPersonalInformationModel.urgent == null ? "" : studentsPersonalInformationModel.urgent.ToString();
                urgent_telephon.Text = studentsPersonalInformationModel.urgent_telephon == null ? "" : studentsPersonalInformationModel.urgent_telephon.ToString();
                image_path.Value = studentsPersonalInformationModel.image_path == null ? "" : studentsPersonalInformationModel.image_path.ToString();
            }
        }

        

    }
    
    protected void save_Click(object sender, EventArgs e)
    {
        
        int count = 0;
        bool tag = false;
        studentsPersonalInformationModel = new StudentsPersonalInformationModel();
        studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();

        studentsPersonalInformationModel.real_name = CommonFunc.FilterSpecialString(real_name.Text.Trim());
            
        studentsPersonalInformationModel.sex = CommonFunc.FilterSpecialString(sex.SelectedValue.Trim());
        studentsPersonalInformationModel.age = CommonFunc.FilterSpecialString(age.Text.Trim());
        studentsPersonalInformationModel.datebirth = CommonFunc.FilterSpecialString(datebirth.Text.Trim());
        studentsPersonalInformationModel.minzu = CommonFunc.FilterSpecialString(minzu.SelectedValue.Trim());

        studentsPersonalInformationModel.province = CommonFunc.FilterSpecialString(province_name.Value.Trim());
        studentsPersonalInformationModel.city = CommonFunc.FilterSpecialString(city_name.Value.Trim());
        studentsPersonalInformationModel.area = CommonFunc.FilterSpecialString(area_name.Value.Trim());

        studentsPersonalInformationModel.province_code = CommonFunc.FilterSpecialString(province_code.Value.Trim());
        studentsPersonalInformationModel.city_code = CommonFunc.FilterSpecialString(city_code.Value.Trim());
        studentsPersonalInformationModel.area_code = CommonFunc.FilterSpecialString(area_code.Value.Trim());


        studentsPersonalInformationModel.detail_address = CommonFunc.FilterSpecialString(detail_address.Text.Trim());
        studentsPersonalInformationModel.id_number = CommonFunc.FilterSpecialString(id_number.Text.Trim());
        studentsPersonalInformationModel.telephon = CommonFunc.FilterSpecialString(telephon.Text.Trim());
        studentsPersonalInformationModel.mail = CommonFunc.FilterSpecialString(mail.Text.Trim());
        studentsPersonalInformationModel.bk_school = CommonFunc.FilterSpecialString(bk_school.Text.Trim());
        studentsPersonalInformationModel.bk_major = CommonFunc.FilterSpecialString(bk_major.Text.Trim());
        studentsPersonalInformationModel.graduation_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(graduation_time.Text.Trim()), "yyyy-MM");
        studentsPersonalInformationModel.high_education = CommonFunc.FilterSpecialString(high_education.Text.Trim());
        studentsPersonalInformationModel.high_school = CommonFunc.FilterSpecialString(high_school.Text.Trim());
        studentsPersonalInformationModel.high_major = CommonFunc.FilterSpecialString(high_major.Text.Trim());
        studentsPersonalInformationModel.high_education_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(high_education_time.Text.Trim()), "yyyy-MM");
        studentsPersonalInformationModel.identity_type = CommonFunc.FilterSpecialString(identity_type.SelectedValue.Trim());
        studentsPersonalInformationModel.send_unit = CommonFunc.FilterSpecialString(send_unit.Text.Trim());
        studentsPersonalInformationModel.training_base_province_code = CommonFunc.FilterSpecialString(training_base_province_code.Value.Trim());
        studentsPersonalInformationModel.training_base_province_name = CommonFunc.FilterSpecialString(training_base_province_name.Value.Trim());
        studentsPersonalInformationModel.training_base_code = CommonFunc.FilterSpecialString(training_base_code.Value.Trim());
        studentsPersonalInformationModel.training_base_name = CommonFunc.FilterSpecialString(training_base_name.Value.Trim());
        studentsPersonalInformationModel.collaborative_unit = CommonFunc.FilterSpecialString(collaborative_unit.Text.Trim());
        studentsPersonalInformationModel.professional_base_code = CommonFunc.FilterSpecialString(professional_base_code.Value.Trim());
        studentsPersonalInformationModel.professional_base_name = CommonFunc.FilterSpecialString(professional_base_name.Value.Trim());
        studentsPersonalInformationModel.training_time = CommonFunc.FilterSpecialString(training_time.Text.Trim());
        studentsPersonalInformationModel.plan_training_time = CommonFunc.FilterSpecialString(plan_training_time.Text.Trim());
        studentsPersonalInformationModel.writor = CommonFunc.FilterSpecialString(writor.Text.Trim());
        studentsPersonalInformationModel.register_date = CommonFunc.FilterSpecialString(register_date.Text.Trim());

        studentsPersonalInformationModel.urgent = CommonFunc.FilterSpecialString(urgent.Text.Trim());
        studentsPersonalInformationModel.urgent_telephon = CommonFunc.FilterSpecialString(urgent_telephon.Text.Trim());
        studentsPersonalInformationModel.image_path = CommonFunc.FilterSpecialString(image_path.Value.Trim());
        
        if (string.IsNullOrEmpty(id))
        {
            
            studentsPersonalInformationModel.id = Guid.NewGuid().ToString();
            studentsPersonalInformationModel.name = na.ToString();
            
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.id_number))
            {
                ShowMessageBox.Showmessagebox(this, "居民身份证号码不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.detail_address))
            {
                ShowMessageBox.Showmessagebox(this, "家庭详细地址不能为空", null);
                return;
            }
            if (studentsPersonalInformationModel.detail_address.Length > 70)
            {
                ShowMessageBox.Showmessagebox(this, "家庭常住地址不能大于70个字符", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.sex))
            {
                ShowMessageBox.Showmessagebox(this, "性别不能为空", null);
                return;
            }


            if (string.IsNullOrEmpty(studentsPersonalInformationModel.telephon))
            {
                ShowMessageBox.Showmessagebox(this, "常用手机号码不能为空", null);
                return;
            }
            if (!ValidityCheck.PhoneNumIsValid(studentsPersonalInformationModel.telephon, this)) return;
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.mail))
            {
                ShowMessageBox.Showmessagebox(this, "常用邮箱不能为空", null);
                return;
            }
            if (!ValidityCheck.EmailIsValid(studentsPersonalInformationModel.mail, this)) return;
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.high_school))
            {
                ShowMessageBox.Showmessagebox(this, "最高学历毕业院校不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.high_major))
            {
                ShowMessageBox.Showmessagebox(this, "最高学历专业不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.high_education_time))
            {
                ShowMessageBox.Showmessagebox(this, "获得最高学历时间不能为空", null);
                return;
            }

            if (studentsPersonalInformationModel.identity_type == "单位人")
            {
                if (string.IsNullOrEmpty(studentsPersonalInformationModel.send_unit))
                {
                    ShowMessageBox.Showmessagebox(this, "派出单位不能为空", null);
                }

            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.training_base_name))
            {
                ShowMessageBox.Showmessagebox(this, "培训基地不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.professional_base_name))
            {
                ShowMessageBox.Showmessagebox(this, "培训专业不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.training_time))
            {
                ShowMessageBox.Showmessagebox(this, "参训时间不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.plan_training_time))
            {
                ShowMessageBox.Showmessagebox(this, "计划参训时间不能为空", null);
                return;
            }

            count = studentsPersonalInformationBLL.InsertStudentsPersonalInformation(studentsPersonalInformationModel);

            if (count > 0)
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('个人信息添加成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                    Response.End();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else {

            studentsPersonalInformationModel.id = id;

            if (string.IsNullOrEmpty(studentsPersonalInformationModel.id_number))
            {
                ShowMessageBox.Showmessagebox(this, "居民身份证号码不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.detail_address))
            {
                ShowMessageBox.Showmessagebox(this, "家庭详细地址不能为空", null);
                return;
            }
            if (studentsPersonalInformationModel.detail_address.Length > 70)
            {
                ShowMessageBox.Showmessagebox(this, "家庭常住地址不能大于70个字符", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.sex))
            {
                ShowMessageBox.Showmessagebox(this, "性别不能为空", null);
                return;
            }


            if (string.IsNullOrEmpty(studentsPersonalInformationModel.telephon))
            {
                ShowMessageBox.Showmessagebox(this, "常用手机号码不能为空", null);
                return;
            }
            if (!ValidityCheck.PhoneNumIsValid(studentsPersonalInformationModel.telephon, this)) return;
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.mail))
            {
                ShowMessageBox.Showmessagebox(this, "常用邮箱不能为空", null);
                return;
            }
            if (!ValidityCheck.EmailIsValid(studentsPersonalInformationModel.mail, this)) return;
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.high_school))
            {
                ShowMessageBox.Showmessagebox(this, "最高学历毕业院校不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.high_major))
            {
                ShowMessageBox.Showmessagebox(this, "最高学历专业不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.high_education_time))
            {
                ShowMessageBox.Showmessagebox(this, "获得最高学历时间不能为空", null);
                return;
            }

            if (studentsPersonalInformationModel.identity_type == "单位人")
            {
                if (string.IsNullOrEmpty(studentsPersonalInformationModel.send_unit))
                {
                    ShowMessageBox.Showmessagebox(this, "派出单位不能为空", null);
                }

            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.training_base_name))
            {
                ShowMessageBox.Showmessagebox(this, "培训基地不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.professional_base_name))
            {
                ShowMessageBox.Showmessagebox(this, "培训专业不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.training_time))
            {
                ShowMessageBox.Showmessagebox(this, "参训时间不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(studentsPersonalInformationModel.plan_training_time))
            {
                ShowMessageBox.Showmessagebox(this, "计划参训时间不能为空", null);
                return;
            }

            tag = studentsPersonalInformationBLL.UpdateStudentsPersonalInformation(studentsPersonalInformationModel);
            if (tag)
            {
                try
                {
                    Response.Write("<script> alert('个人信息修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                    Response.End();
                    
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }
            else
            {
                Response.Write("<script> alert('个人信息修改失败');</script>");
                Response.End();
               
            }
            
        }
        
        
        
    }
}