using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;
using System.Data;

public partial class managers_StudentsSurgeryRecords_View : System.Web.UI.Page
{
    SurgeryRecordsModel surgeryRecordsModel = null;
    SurgeryRecordsBLL surgeryRecordsBLL = null;
    public string id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        surgeryRecordsModel = new SurgeryRecordsModel();
        surgeryRecordsBLL = new SurgeryRecordsBLL();

        surgeryRecordsModel = surgeryRecordsBLL.GetModelById(id);
        StudentsRealName.Text = surgeryRecordsModel.StudentsRealName.ToString();
        TrainingBaseName.Text = surgeryRecordsModel.TrainingBaseName.ToString();
        ProfessionalBaseName.Text = surgeryRecordsModel.ProfessionalBaseName.ToString();
        RotaryDept.SelectedItem.Text = surgeryRecordsModel.DeptName.ToString();
        RotaryDept.SelectedItem.Value = surgeryRecordsModel.DeptCode.ToString();
        Teacher.SelectedItem.Text = surgeryRecordsModel.TeacherName.ToString();
        Teacher.SelectedItem.Value = surgeryRecordsModel.TeacherId.ToString();
        PatientName.Text = surgeryRecordsModel.PatientName.ToString();
        CaseId.Text = surgeryRecordsModel.CaseId.ToString();
        SurgeryName.Text = surgeryRecordsModel.SurgeryName.ToString();
        IntraoperativePosition.Text = surgeryRecordsModel.IntraoperativePosition.ToString();
        RoomId.Text = surgeryRecordsModel.RoomId.ToString();
        MainDiagnosis.Text = surgeryRecordsModel.MainDiagnosis.ToString();
        SecondaryDiagnosis.Text = surgeryRecordsModel.SecondaryDiagnosis.ToString();
        Emergency.SelectedValue = surgeryRecordsModel.Emergency.ToString();
        SurgeryDate.Text = surgeryRecordsModel.SurgeryDate.ToString();
        SurgeryScale.Text = surgeryRecordsModel.SurgeryScale.ToString();
        DoctorInCharge.Text = surgeryRecordsModel.DoctorInCharge.ToString();
        Assistant.Text = surgeryRecordsModel.Assistant.ToString();
        Nurse.Text = surgeryRecordsModel.Nurse.ToString();
        AnesthesiaMethod.Text = surgeryRecordsModel.AnesthesiaMethod.ToString();
        Anesthetist.Text = surgeryRecordsModel.Anesthetist.ToString();
        SurgeryIsStop.SelectedValue = surgeryRecordsModel.SurgeryIsStop.ToString();
        if (surgeryRecordsModel.SurgeryIsStop == "否")
        {
            //StopReason.Text = surgeryRecordsModel.StopReason.ToString();
            StopReason.Enabled = false;
        }
        else
        {
            StopReason.Text = surgeryRecordsModel.StopReason.ToString();
            StopReason.Enabled = true;
        }

        Comment.Text = surgeryRecordsModel.Comment.ToString();
        Writor.Text = surgeryRecordsModel.Writor.ToString();
        RegisterDate.Text = surgeryRecordsModel.RegisterDate.ToString();
    }
}