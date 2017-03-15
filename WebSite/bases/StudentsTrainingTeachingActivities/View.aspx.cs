using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class bases_StudentsTrainingTeachingActivities_View : System.Web.UI.Page
{
    TrainingTeachingActivitiesModel trainingTeachingActivitiesModel = null;
    TrainingTeachingActivitiesBLL trainingTeachingActivitiesBLL = null;
    public string id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));

        trainingTeachingActivitiesModel = new TrainingTeachingActivitiesModel();
        trainingTeachingActivitiesBLL = new TrainingTeachingActivitiesBLL();

        trainingTeachingActivitiesModel = trainingTeachingActivitiesBLL.GetModelById(id);
        StudentsRealName.Text = trainingTeachingActivitiesModel.StudentsRealName.ToString();
        TrainingBaseName.Text = trainingTeachingActivitiesModel.TrainingBaseName.ToString();
        ProfessionalBaseName.Text = trainingTeachingActivitiesModel.ProfessionalBaseName.ToString();
        RotaryDept.SelectedItem.Text = trainingTeachingActivitiesModel.DeptName.ToString();
        RotaryDept.SelectedValue = trainingTeachingActivitiesModel.DeptCode.ToString();

        Teacher.SelectedItem.Text = trainingTeachingActivitiesModel.TeacherName.ToString();
        Teacher.SelectedItem.Value = trainingTeachingActivitiesModel.TeacherId.ToString();

        ActivityForm.SelectedValue = trainingTeachingActivitiesModel.ActivityFormId.ToString();
        ActivityContent.Text = trainingTeachingActivitiesModel.ActivityContent.ToString();
        MainSpeaker.Text = trainingTeachingActivitiesModel.MainSpeaker.ToString();
        ClassHour.Text = trainingTeachingActivitiesModel.ClassHour.ToString();
        ActivityDate.Text = trainingTeachingActivitiesModel.ActivityDate.ToString();
        Comment.Text = trainingTeachingActivitiesModel.Comment.ToString();
        Writor.Text = trainingTeachingActivitiesModel.Writor.ToString();
        RegisterDate.Text = trainingTeachingActivitiesModel.RegisterDate.ToString();
    }
}