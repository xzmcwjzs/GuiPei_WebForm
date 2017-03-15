using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class managers_StudentsRescuePatientRecords_View : System.Web.UI.Page
{
    public string id = string.Empty;
    RescuePatientRecordsModel rescuePatientRecordsModel = null;
    RescuePatientRecordsBLL rescuePatientRecordsBLL = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        
            rescuePatientRecordsModel = new RescuePatientRecordsModel();
            rescuePatientRecordsBLL = new RescuePatientRecordsBLL();

            rescuePatientRecordsModel = rescuePatientRecordsBLL.GetModelById(id);
            StudentsRealName.Text = rescuePatientRecordsModel.StudentsRealName.ToString();
            TrainingBaseName.Text = rescuePatientRecordsModel.TrainingBaseName.ToString();
            ProfessionalBaseName.Text = rescuePatientRecordsModel.ProfessionalBaseName.ToString();
            RotaryDept.SelectedItem.Text = rescuePatientRecordsModel.DeptName.ToString();
            RotaryDept.SelectedValue = rescuePatientRecordsModel.DeptCode.ToString();
            Teacher.SelectedItem.Text = rescuePatientRecordsModel.TeacherName.ToString();
            Teacher.SelectedItem.Value = rescuePatientRecordsModel.TeacherId.ToString();

            PatientName.Text = rescuePatientRecordsModel.PatientName.ToString();
            CaseId.Text = rescuePatientRecordsModel.CaseId.ToString();
            DiseaseName.Text = rescuePatientRecordsModel.DiseaseName.ToString();
            Condition.Text = rescuePatientRecordsModel.Condition.ToString();
            RescueMeasure.Text = rescuePatientRecordsModel.RescueMeasure.ToString();
            Comment.Text = rescuePatientRecordsModel.Comment.ToString();
            Writor.Text = rescuePatientRecordsModel.Writor.ToString();
            RegisterDate.Text = rescuePatientRecordsModel.RegisterDate.ToString();

        
    }
}