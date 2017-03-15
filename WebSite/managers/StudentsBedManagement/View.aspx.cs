using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class managers_StudentsBedManagement_View : System.Web.UI.Page
{
    public string id = string.Empty;
    BedManagementModel bedManagementMode = null;
    BedManagementBLL bedManagementBLL = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        bedManagementMode = new BedManagementModel();
        bedManagementBLL = new BedManagementBLL();

        bedManagementMode = bedManagementBLL.GetModelById(id);
        students_real_name.Text = bedManagementMode.students_real_name.ToString();
        training_base_name.Text = bedManagementMode.training_base_name.ToString();
        professional_base_name.Text = bedManagementMode.professional_base_name.ToString();
        rotary_dept.SelectedItem.Text = bedManagementMode.dept_name.ToString();
        rotary_dept.SelectedItem.Value = bedManagementMode.dept_code.ToString();
        Teacher.SelectedItem.Text = bedManagementMode.TeacherName.ToString();
        Teacher.SelectedItem.Value = bedManagementMode.TeacherId.ToString();
        patient_name.Text = bedManagementMode.patient_name.ToString();
        patient_id.Text = bedManagementMode.patient_id.ToString();
        bed_id.Text = bedManagementMode.bed_id.ToString();
        bed_card.Text = bedManagementMode.bed_card.ToString();
        bed_price.Text = bedManagementMode.bed_price.ToString();
        bed_status.Text = bedManagementMode.bed_status.ToString();
        room_id.Text = bedManagementMode.room_id.ToString();
        building_id.Text = bedManagementMode.building_id.ToString();
        comment.Text = bedManagementMode.comment.ToString();
        writor.Text = bedManagementMode.writor.ToString();
        register_date.Text = bedManagementMode.register_date.ToString();
    }
}