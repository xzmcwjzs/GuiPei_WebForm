using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;

public partial class teachers_StudentsRotaryInformation_View : System.Web.UI.Page
{
    string id = string.Empty;
    StudentsRotaryModel studentsRotaryModel = null;
    StudentsRotaryBLL studentsRotaryBLL = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        if (!IsPostBack)
        {
            studentsRotaryModel = new StudentsRotaryModel();
            studentsRotaryBLL = new StudentsRotaryBLL();

            studentsRotaryModel = studentsRotaryBLL.GetModelById(id);

            real_name.Text = studentsRotaryModel.real_name;
            training_base_name.Text = studentsRotaryModel.training_base_name;
            professional_base_name.Text = studentsRotaryModel.professional_base_name;
            rotary_begin_time.Text = studentsRotaryModel.rotary_begin_time;
            rotary_end_time.Text = studentsRotaryModel.rotary_end_time;
            rotary_dept_name.Text = studentsRotaryModel.rotary_dept_name;
            instructor.Text = studentsRotaryModel.instructor;
            writor.Text = studentsRotaryModel.writor;
            register_date.Text = studentsRotaryModel.register_date;

        }

    }
}