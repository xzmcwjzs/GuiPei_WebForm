using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class students_ApplicationQuestionnaire_Questionaire : System.Web.UI.Page
{
    protected string id = string.Empty;
    protected string pi = string.Empty;
    StudentsRotaryModel studentsRotaryModel = null;
    StudentsRotaryBLL studentsRotaryBLL = null;
    QuestionnaireModel questionnaireModel = null;
    QuestionnaireBLL questionnaireBLL = null;
    protected string  questionnairewei="未填写";
    protected string questionnaireyi = "已填写";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));

        studentsRotaryBLL = new StudentsRotaryBLL();
        
        if (studentsRotaryBLL.GetQuestionnaire(id) == "已填写")
        {
            Response.Write("<script language='javascript'> alert('该问卷已填写，请勿重复');window.close();</script>");
            return;
        }

        //Response.Write("<script> alert('"+id+"');</script>");
        if (!IsPostBack)
        {
            studentsRotaryModel = new StudentsRotaryModel();
            studentsRotaryBLL = new StudentsRotaryBLL();

            studentsRotaryModel = studentsRotaryBLL.GetModelById(id);

            training_base_name.Text = studentsRotaryModel.training_base_name;
            training_base_code.Value = studentsRotaryModel.training_base_code;

            professional_base_name.Text = studentsRotaryModel.professional_base_name;
            professional_base_code.Value = studentsRotaryModel.professional_base_code;

            rotary_dept_name.Text = studentsRotaryModel.rotary_dept_name;
            rotary_dept_code.Value = studentsRotaryModel.rotary_dept_code;
            instructor.Text = studentsRotaryModel.instructor;
            writor.Value = studentsRotaryModel.writor;
            register_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

    }
    protected void save_Click(object sender, EventArgs e)
    {
        questionnaireModel = new QuestionnaireModel();
        questionnaireBLL = new QuestionnaireBLL();
        studentsRotaryBLL = new StudentsRotaryBLL();
        questionnaireModel.id = Guid.NewGuid().ToString();
        questionnaireModel.training_base_name =CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(training_base_name.Text.Trim()));
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
        if (RadioButtonList1.SelectedItem==null){
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
        if (questionnaireBLL.InsertQuestionnaire(questionnaireModel) && studentsRotaryBLL.UpdateQuestStatus(questionnaireyi, id))
        {
                try
                {

                    Response.Write("<script language='javascript'> alert('问卷调查提交成功');window.opener.window.loadPageList('"+pi+"');window.close();</script>");
                    return;
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }
    }
   }
       
