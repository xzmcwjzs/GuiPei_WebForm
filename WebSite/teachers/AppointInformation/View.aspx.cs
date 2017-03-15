using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
using Model;

public partial class teachers_AppointInformation_View : System.Web.UI.Page
{
    LoginModel loginModel = new LoginModel();
    TeachersAppointInformationModel teachersAppointInformationModel = null;
    TeachersAppointInformationBLL teachersAppointInformationBLL = null;
    protected string id = string.Empty;
    
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
            loginModel = (LoginModel)Session["loginModel"];
            teachers_real_name.Text = loginModel.real_name.ToString();
            teachers_name.Value = loginModel.name.ToString();
            training_base_code.Value = loginModel.training_base_code.ToString();
            training_base_name.Value = loginModel.training_base_name.ToString();
            professional_base_code.Value = loginModel.professional_base_code;
            professional_base_name.Value = loginModel.professional_base_name;
            dept_code.Value = loginModel.dept_code;
            dept_name.Text = loginModel.dept_name;
            register_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                teachersAppointInformationModel = new TeachersAppointInformationModel();
                teachersAppointInformationBLL = new TeachersAppointInformationBLL();

                teachersAppointInformationModel = teachersAppointInformationBLL.SelectModelById(id);

                appoint_begin_time.Text = teachersAppointInformationModel.appoint_begin_time;
                appoint_end_time.Text = teachersAppointInformationModel.appoint_end_time;
                total_num.Text = teachersAppointInformationModel.total_num;
                class_num.Text = teachersAppointInformationModel.class_num;
                each_class_num.Text = teachersAppointInformationModel.each_class_num;
                training_content.Text = teachersAppointInformationModel.training_content;
                comment.Text = teachersAppointInformationModel.comment;
                register_date.Text = teachersAppointInformationModel.register_date;

            }

        }
    

    }
}