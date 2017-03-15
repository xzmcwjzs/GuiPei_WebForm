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

public partial class bases_StudentsWriteMedicalRecords_View : System.Web.UI.Page
{
    public string id = string.Empty;
    WriteMedicalRecordsModel writeMedicalRecordsModel = null;
    WriteMedicalRecordsBLL writeMedicalRecordsBLL = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));

        writeMedicalRecordsModel = new WriteMedicalRecordsModel();
        writeMedicalRecordsBLL = new WriteMedicalRecordsBLL();

        writeMedicalRecordsModel = writeMedicalRecordsBLL.GetModelById(id);
        StudentsRealName.Text = writeMedicalRecordsModel.StudentsRealName.ToString();
        TrainingBaseName.Text = writeMedicalRecordsModel.TrainingBaseName.ToString();
        ProfessionalBaseName.Text = writeMedicalRecordsModel.ProfessionalBaseName.ToString();
        RotaryDept.SelectedItem.Text = writeMedicalRecordsModel.DeptName.ToString();
        RotaryDept.SelectedValue = writeMedicalRecordsModel.DeptCode.ToString();
        
        Teacher.SelectedItem.Text = writeMedicalRecordsModel.TeacherName.ToString();
        Teacher.SelectedItem.Value = writeMedicalRecordsModel.TeacherId.ToString();
        
        PatientName.Text = writeMedicalRecordsModel.PatientName.ToString();
        CaseId.Text = writeMedicalRecordsModel.CaseId.ToString();
        MainDiagnosis.Text = writeMedicalRecordsModel.MainDiagnosis.ToString();
        SuperiorDoctor.Text = writeMedicalRecordsModel.SuperiorDoctor.ToString();
        IsBigCase.SelectedValue = writeMedicalRecordsModel.IsBigCase.ToString();
        Comment.Text = writeMedicalRecordsModel.Comment.ToString();
        Writor.Text = writeMedicalRecordsModel.Writor.ToString();
        RegisterDate.Text = writeMedicalRecordsModel.RegisterDate.ToString();
    }
}