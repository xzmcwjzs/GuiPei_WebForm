using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class students_RotaryInformation2_Questionnaire : System.Web.UI.Page
{
    protected string Id = string.Empty;
    StudentsRotaryInformation2BLL studentsRotaryInformation2BLL = null;
    StudentsRotaryInformation2Model studentsRotaryInformation2Model = null;
    QuestionnaireModel questionnaireModel = null;
    QuestionnaireBLL questionnaireBLL = null;

    protected string Name = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }

        Id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["Id"]));

        studentsRotaryInformation2Model = new StudentsRotaryInformation2Model();
        studentsRotaryInformation2BLL = new StudentsRotaryInformation2BLL();

        studentsRotaryInformation2Model = studentsRotaryInformation2BLL.GetModelById(Id);
        Name = studentsRotaryInformation2Model.Name;
        TrainingBaseCode = studentsRotaryInformation2Model.TrainingBaseCode;
        if (!IsPostBack)
        {
            
            training_base_name.Text = studentsRotaryInformation2Model.TrainingBaseName;
            training_base_code.Value = studentsRotaryInformation2Model.TrainingBaseCode;

            professional_base_name.Text = studentsRotaryInformation2Model.ProfessionalBaseName;
            professional_base_code.Value = studentsRotaryInformation2Model.ProfessionalBaseCode;

            rotary_dept_name.Text = studentsRotaryInformation2Model.DeptName;
            rotary_dept_code.Value = studentsRotaryInformation2Model.DeptCode;
            instructor.Text = studentsRotaryInformation2Model.TeachersRealName;
            writor.Value = studentsRotaryInformation2Model.RealName;
            register_date.Text = DateTime.Now.ToString("yyyy-MM-dd");          
        }

    }
    protected void save_Click(object sender, EventArgs e)
    {

        questionnaireModel = new QuestionnaireModel();
        questionnaireBLL = new QuestionnaireBLL();
        studentsRotaryInformation2BLL = new StudentsRotaryInformation2BLL();
        questionnaireModel.id = Guid.NewGuid().ToString();
        questionnaireModel.training_base_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(training_base_name.Text.Trim()));
        questionnaireModel.training_base_code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(training_base_code.Value.Trim()));
        questionnaireModel.professional_base_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(professional_base_name.Text.Trim()));
        questionnaireModel.professional_base_code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(professional_base_code.Value.Trim()));
        questionnaireModel.rotary_dept_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(rotary_dept_name.Text.Trim()));
        questionnaireModel.rotary_dept_code = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(rotary_dept_code.Value.Trim()));
        questionnaireModel.instructor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(instructor.Text.Trim()));
        questionnaireModel.one = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList1.SelectedValue));
        questionnaireModel.two = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList2.SelectedValue));
        questionnaireModel.three = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList3.SelectedValue));
        questionnaireModel.four = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList4.SelectedValue));
        questionnaireModel.five = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList5.SelectedValue));
        questionnaireModel.six = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList6.SelectedValue));
        questionnaireModel.seven = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList7.SelectedValue));
        questionnaireModel.eight = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList8.SelectedValue));
        questionnaireModel.nine = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList9.SelectedValue));
        questionnaireModel.ten = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList10.SelectedValue));
        questionnaireModel.eleven = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList11.SelectedValue));
        questionnaireModel.twelve = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList12.SelectedValue));
        questionnaireModel.thirteen = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(RadioButtonList13.SelectedValue));
        questionnaireModel.advice = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(advice.Text.Trim()));
        questionnaireModel.register_date = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(register_date.Text.Trim()));
        questionnaireModel.writor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(writor.Value.Trim()));
        if (RadioButtonList1.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第一项未选择", null);
            return;
        }
        if (RadioButtonList2.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第二项未选择", null);
            return;
        }
        if (RadioButtonList3.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第三项未选择", null);
            return;
        }
        if (RadioButtonList4.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第四项未选择", null);
            return;
        }
        if (RadioButtonList5.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第五项未选择", null);
            return;
        }
        if (RadioButtonList6.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第六项未选择", null);
            return;
        }
        if (RadioButtonList7.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第七项未选择", null);
            return;
        }
        if (RadioButtonList8.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第八项未选择", null);
            return;
        }
        if (RadioButtonList9.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第九项未选择", null);
            return;
        }
        if (RadioButtonList10.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第十项未选择", null);
            return;
        }
        if (RadioButtonList11.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第十一项未选择", null);
            return;
        }
        if (RadioButtonList12.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第十二项未选择", null);
            return;
        }
        if (RadioButtonList13.SelectedItem == null)
        {
            ShowMessageBox.Showmessagebox(this, "第十三项未选择", null);
            return;
        }
        if (string.IsNullOrEmpty(questionnaireModel.advice))
        {
            ShowMessageBox.Showmessagebox(this, "第十四项不能为空", null);
            return;
        }
        if (questionnaireBLL.InsertQuestionnaire(questionnaireModel) && studentsRotaryInformation2BLL.UpdateQuestStatus("1", Id))
        {
            try
            {

                Response.Write("<script language='javascript'> alert('问卷调查提交成功');window.opener.window.loadRotaryInfo('" + Name + "','"+TrainingBaseCode+"');window.close();</script>");
                return;
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
    }
}