using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;

public partial class teachers_OutDeptExam_Manage : System.Web.UI.Page
{
    protected string id=string.Empty;
    protected string pi = string.Empty;
    RotaryInformationJoinModel rotaryInformationJoinModel = null;
    RotaryInformationJoinBLL rotaryInformationJoinBLL = null;
    OutDeptExamBLL outDeptExamBLL = null;
    OutDeptExamModel outDeptExamModel = null;
    protected string status = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        teacher.Text = ((Model.LoginModel)Session["loginModel"]).real_name.ToString();
        teacher_time.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        kzr_time.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

         id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
         pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));

         rotaryInformationJoinModel = new RotaryInformationJoinModel();
         rotaryInformationJoinBLL = new RotaryInformationJoinBLL();

         rotaryInformationJoinModel = rotaryInformationJoinBLL.GetModelById(id);

         students_name.Value = rotaryInformationJoinModel.Name.ToString();

         students_real_name.Text = rotaryInformationJoinModel.RealName.ToString();
         training_base_code.Value = rotaryInformationJoinModel.TrainingBaseCode.ToString();
         training_base_name.Value = rotaryInformationJoinModel.TrainingBaseName.ToString();
         sex.Text = rotaryInformationJoinModel.Sex.ToString();
         high_education.Text = rotaryInformationJoinModel.HighEducation.ToString();
         high_education_time.Text = rotaryInformationJoinModel.HighEducationTime.ToString();
         professional_base_code.Value = rotaryInformationJoinModel.ProfessionalBaseCode.ToString();
         professional_base_name.Text = rotaryInformationJoinModel.ProfessionalBaseName.ToString();
         rotary_dept_code.Value = rotaryInformationJoinModel.DeptCode.ToString();
         rotary_dept_name.Text = rotaryInformationJoinModel.DeptName.ToString();
         rotary_begin_time.Text = rotaryInformationJoinModel.RotaryBeginTime.ToString();
         rotary_end_time.Text = rotaryInformationJoinModel.RotaryEndTime.ToString();
         instructor.Text = rotaryInformationJoinModel.TeachersRealName.ToString();
         instructor_tag.Value = rotaryInformationJoinModel.TeachersName.ToString();
          
        
    }

    protected void save_Click(object sender, EventArgs e)
    {
        outDeptExamBLL = new OutDeptExamBLL();
        outDeptExamModel = new OutDeptExamModel();
        outDeptExamModel.id = Guid.NewGuid().ToString();
        outDeptExamModel.students_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(students_name.Value));
        outDeptExamModel.students_real_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(students_real_name.Text));
        outDeptExamModel.training_base_code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(training_base_code.Value));
        outDeptExamModel.training_base_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(training_base_name.Value));
        outDeptExamModel.sex = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(sex.Text));
        outDeptExamModel.high_education = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(high_education.Text));
        outDeptExamModel.high_education_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(high_education_time.Text));
        outDeptExamModel.professional_base_code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(professional_base_code.Value));
        outDeptExamModel.professional_base_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(professional_base_name.Text));
        outDeptExamModel.rotary_dept_code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(rotary_dept_code.Value));
        outDeptExamModel.rotary_dept_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(rotary_dept_name.Text));
        outDeptExamModel.rotary_begin_time =CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(rotary_begin_time.Text),"yyyy-MM-dd");
        outDeptExamModel.rotary_end_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(rotary_end_time.Text), "yyyy-MM-dd");
        outDeptExamModel.instructor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(instructor.Text));
        outDeptExamModel.instructor_tag = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(instructor_tag.Value));
        outDeptExamModel.kqqk = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(kqqk.Text));
        outDeptExamModel.gztd = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(gztd.Text));
        outDeptExamModel.ydyf = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ydyf.Text));
        outDeptExamModel.llsp = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(llsp.Text));
        outDeptExamModel.zdzx = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(zdzx.Text));
        outDeptExamModel.blsx = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(blsx.Text));
        outDeptExamModel.clbrnl = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(clbrnl.Text));
        outDeptExamModel.sjcznl = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(sjcznl.Text));
        outDeptExamModel.czjn = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(czjn.Text));
        outDeptExamModel.zdsp = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(zdsp.Text));
        outDeptExamModel.djnl = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(djnl.Text));
        outDeptExamModel.total_score = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(totalscore.Text));
        outDeptExamModel.instructor_date = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(teacher_time.Text));
        outDeptExamModel.dept_manager = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(kzr.Text));
        outDeptExamModel.dept_manager_date = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(kzr_time.Text));
        outDeptExamModel.is_pass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ispass.SelectedItem.Value));

        //Response.Write("<script> alert('"+totalscore.Text+"');</script>");
        if (string.IsNullOrEmpty(outDeptExamModel.total_score))
        {
            ShowMessageBox.Showmessagebox(this, "合计得分不能为空", null);
            return;
        }
        if (string.IsNullOrEmpty(outDeptExamModel.is_pass))
        {
            ShowMessageBox.Showmessagebox(this, "考核结果不能为空", null);
            return;
        }
        
        if (string.IsNullOrEmpty(outDeptExamModel.dept_manager))
        {
            ShowMessageBox.Showmessagebox(this, "科主任不能为空", null);
            return;
        }
        if (outDeptExamModel.is_pass == "同意出科")
        {
            status = "1";
        }
        else
        {
            status = "2";
            //StudentsRotaryInformation2BLL bll = new StudentsRotaryInformation2BLL();
            //StudentsRotaryInformation2Model model = new StudentsRotaryInformation2Model();
            //model = bll.GetModelById(id);

            //model.Id = Guid.NewGuid().ToString();
            //model.OutdeptStatus = "0";
            //model.OutdeptApplication = "0";
            //model.QuestionnaireStatus = "0";
            //model.Tag1 = "0";

            //bll.AddOne(model);
        }
        if (outDeptExamBLL.Insert(outDeptExamModel) && new StudentsRotaryInformation2BLL().UpdateOutdeptStatusByT(status, id))
        {
            try
            {
                Response.Write("<script language='javascript'> alert('出科考核表提交成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                Response.End();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
    }


}