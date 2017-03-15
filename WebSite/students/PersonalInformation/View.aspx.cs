using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class students_PersonalInformation_View : System.Web.UI.Page
{
    StudentsPersonalInformationModel studentsPersonalInformationModel = null;
    StudentsPersonalInformationBLL studentsPersonalInformationBLL = new StudentsPersonalInformationBLL();
    string id = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]);
        if (!IsPostBack) {
            studentsPersonalInformationModel = new StudentsPersonalInformationModel();
            studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelById(id);

            real_name.Text = studentsPersonalInformationModel.real_name == null ? "" : studentsPersonalInformationModel.real_name.ToString();

            sex.Text = studentsPersonalInformationModel.sex == null ? "" : studentsPersonalInformationModel.sex.ToString();

            id_number.Text = studentsPersonalInformationModel.id_number == null ? "" : studentsPersonalInformationModel.id_number.ToString();

            datebirth.Text = studentsPersonalInformationModel.datebirth == null ? "" : studentsPersonalInformationModel.datebirth.ToString();
            age.Text = studentsPersonalInformationModel.age == null ? "" : studentsPersonalInformationModel.age.ToString();
            datebirth.Text = studentsPersonalInformationModel.datebirth == null ? "" : studentsPersonalInformationModel.datebirth.ToString();
            age.Text = studentsPersonalInformationModel.age == null ? "" : studentsPersonalInformationModel.age.ToString();

            province.Text = studentsPersonalInformationModel.province == null ? "" : studentsPersonalInformationModel.province.ToString();
            city.Text = studentsPersonalInformationModel.city == null ? "" : studentsPersonalInformationModel.city.ToString();
            area.Text = studentsPersonalInformationModel.area == null ? "" : studentsPersonalInformationModel.area.ToString();

            detail_address.Text = studentsPersonalInformationModel.detail_address == null ? "" : studentsPersonalInformationModel.detail_address.ToString();
            telephon.Text = studentsPersonalInformationModel.telephon == null ? "" : studentsPersonalInformationModel.telephon.ToString();
            mail.Text = studentsPersonalInformationModel.mail == null ? "" : studentsPersonalInformationModel.mail.ToString();

            minzu.Text = studentsPersonalInformationModel.minzu == null ? "" : studentsPersonalInformationModel.minzu.ToString();

            bk_school.Text = studentsPersonalInformationModel.bk_school == null ? "" : studentsPersonalInformationModel.bk_school.ToString();
            bk_major.Text = studentsPersonalInformationModel.bk_major == null ? "" : studentsPersonalInformationModel.bk_major.ToString();
            graduation_time.Text = studentsPersonalInformationModel.graduation_time == null ? "" : studentsPersonalInformationModel.graduation_time.ToString();

            high_education.Text = studentsPersonalInformationModel.sex == null ? "" : studentsPersonalInformationModel.high_education.ToString();

            high_school.Text = studentsPersonalInformationModel.high_school == null ? "" : studentsPersonalInformationModel.high_school.ToString();
            high_major.Text = studentsPersonalInformationModel.high_major == null ? "" : studentsPersonalInformationModel.high_major.ToString();
            high_education_time.Text = studentsPersonalInformationModel.high_education_time == null ? "" : studentsPersonalInformationModel.high_education_time.ToString();

            identity_type.Text = studentsPersonalInformationModel.identity_type == null ? "" : studentsPersonalInformationModel.identity_type.ToString();

            send_unit.Text = studentsPersonalInformationModel.send_unit == null ? "" : studentsPersonalInformationModel.send_unit.ToString();

            training_base_province_name.Text = studentsPersonalInformationModel.training_base_province_name == null ? "" : studentsPersonalInformationModel.training_base_province_name.ToString();
            training_base_name.Text = studentsPersonalInformationModel.training_base_name == null ? "" : studentsPersonalInformationModel.training_base_name.ToString();

            collaborative_unit.Text = studentsPersonalInformationModel.collaborative_unit == null ? "" : studentsPersonalInformationModel.collaborative_unit.ToString();

            professional_base_name.Text = studentsPersonalInformationModel.professional_base_name == null ? "" : studentsPersonalInformationModel.professional_base_name.ToString();

            training_time.Text = studentsPersonalInformationModel.training_time == null ? "" : studentsPersonalInformationModel.training_time.ToString();

            plan_training_time.Text = studentsPersonalInformationModel.plan_training_time == null ? "" : studentsPersonalInformationModel.plan_training_time.ToString();

            writor.Text = studentsPersonalInformationModel.writor == null ? "" : studentsPersonalInformationModel.writor.ToString();
            register_date.Text = studentsPersonalInformationModel.register_date == null ? "" : studentsPersonalInformationModel.register_date.ToString();

            urgent.Text = studentsPersonalInformationModel.urgent == null ? "" : studentsPersonalInformationModel.urgent.ToString();
            urgent_telephon.Text = studentsPersonalInformationModel.urgent_telephon == null ? "" : studentsPersonalInformationModel.urgent_telephon.ToString();
            //imgUpload.ImageUrl = studentsPersonalInformationModel.image_path == null ? "../../images/head1,jpg" : studentsPersonalInformationModel.image_path.ToString();
          image_path.Value = studentsPersonalInformationModel.image_path == null ? "" : studentsPersonalInformationModel.image_path.ToString();
        }
       
    }
}