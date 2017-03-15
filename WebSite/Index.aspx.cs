using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class Index : System.Web.UI.Page
{
    //protected TeachersModel teachersModel = null;
    //protected StudentsModel studentsModel = null;
    //protected BasesModel basesModel = null;
    protected LoginModel loginModel = null;
    protected string type = null;
    protected ManagersModel managersModel = null;
    #region

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.SetFocus(login);

        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "Default.aspx");
            return;
        }

        loginModel = new LoginModel();
        loginModel = (LoginModel)Session["loginModel"];
        title.Text = loginModel.training_base_name == null ? "" : loginModel.training_base_name.ToString();
        if (loginModel.type != null || loginModel.type != "")
        {
            type = loginModel.type.ToString();

            string[] identity = type.Split('_');
            foreach (string i in identity)
            {
                if (i == "students") { role.Items.Add(new ListItem("学员", "students")); }
                else if (i == "teachers") { role.Items.Add(new ListItem("指导医师", "teachers")); }
                else if (i == "kzr") { role.Items.Add(new ListItem("科主任", "kzr")); }
                else if (i == "bases") { role.Items.Add(new ListItem("专业基地负责人", "bases")); }
                else if (i == "managers") { role.Items.Add(new ListItem("管理员", "managers")); }
                else
                {
                    return;
                }
            }
        }
        else
        {
            Response.Write("<script> alert('登录人员权限未分配');</script>");
        }

    }

    protected void login_Click(object sender, EventArgs e)
    {
        type = role.SelectedValue.ToString();
        if (type == "students")
        {
            if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name))
            {
                Response.Write("<script>alert(登录信息未填写完整);</script>");
                Response.Redirect("Default.aspx");
            }
            Response.Redirect("Frame_students.aspx");
            //Response.Redirect("Frame.aspx?role=students");
            return;
        }
        if (type == "teachers")
        {
            if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name) ||
                string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name) ||
                string.IsNullOrEmpty(loginModel.dept_code) || string.IsNullOrEmpty(loginModel.dept_name))
            {
                Response.Write("<script>alert(登录信息未填写完整);</script>");
                Response.Redirect("Default.aspx");
            }
            Response.Redirect("Frame_teachers.aspx");
            return;
        }
        if (type == "kzr")
        {
            if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name) ||
                string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name) ||
                string.IsNullOrEmpty(loginModel.dept_code) || string.IsNullOrEmpty(loginModel.dept_name))
            {
                Response.Write("<script>alert(登录信息未填写完整);</script>");
                Response.Redirect("Default.aspx");
            }
            Response.Redirect("Frame_kzr.aspx");
            return;
        }
        if (type == "bases")
        {
            if (string.IsNullOrEmpty(loginModel.training_base_code) || string.IsNullOrEmpty(loginModel.training_base_name) ||
                string.IsNullOrEmpty(loginModel.professional_base_code) || string.IsNullOrEmpty(loginModel.professional_base_name))
            {
                Response.Write("<script>alert(登录信息未填写完整);</script>");
                Response.Redirect("Default.aspx");
            }
            Response.Redirect("Frame_bases.aspx");
            return;
        }
        if (type == "managers")
        {
            if (string.IsNullOrEmpty(loginModel.training_base_name))
            {
                Response.Write("<script>alert(登录信息未填写完整);</script>");
                Response.Redirect("Default.aspx");
            }
            Response.Redirect("Frame_managers.aspx");
            return;
        }


    }

}