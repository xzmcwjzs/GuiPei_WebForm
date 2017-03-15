using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managers_StudentsBasicInformation_View : System.Web.UI.Page
{
    StudentsPersonalInformation2Model studentsPersonalInformationModel = null;
    StudentsPersonalInformation2BLL studentsPersonalInformationBLL = null;
    string id = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            studentsPersonalInformationModel = new StudentsPersonalInformation2Model();
            studentsPersonalInformationBLL = new StudentsPersonalInformation2BLL();
            studentsPersonalInformationModel = studentsPersonalInformationBLL.GetModelById(id);

            real_name.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.RealName);
            sex.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.Sex);
            id_number.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.IdNumber);
            datebirth.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.DateBirth);
            telephon.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.Telephon);
            mail.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.Mail);
            minzu.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.MinZu);
            bk_school.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.BkSchool);
            bk_major.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.BkMajor);
            graduation_time.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.GraduationTime);
            high_education.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.HighEducation);
            high_school.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.HighSchool);
            high_major.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.HighMajor);
            high_education_time.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.HighEducationTime);
            identity_type.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.IdentityType);
            send_unit.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.SendUnit);
            training_base_name.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.TrainingBaseName);
            collaborative_unit.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.CollaborativeUnit);
            professional_base_name.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.ProfessionalBaseName);
            training_time.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.TrainingTime);
            plan_training_time.Text = CommonFunc.SafeGetStringFromObj(studentsPersonalInformationModel.PlanTrainingTime);
            image_path.Value = studentsPersonalInformationModel.ImagePath == null ? "" : studentsPersonalInformationModel.ImagePath.ToString();
        }

    }
}