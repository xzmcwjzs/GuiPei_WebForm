﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

public partial class bases_StudentsReceiveHonour_List : System.Web.UI.Page
{
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string HonourName = string.Empty;
    protected string HonourDepartment = string.Empty;
    protected string HonourDate = string.Empty;
    protected string DeptName = string.Empty;
    protected string TeachersRealName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }
        if (!IsPostBack)
        {
            LoginModel loginModel = new LoginModel();
            loginModel = (LoginModel)Session["loginModel"];
            TrainingBaseCode = loginModel.training_base_code;
            ProfessionalBaseCode = loginModel.professional_base_code;

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        HonourName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["HonourName"]));
        HonourDepartment = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["HonourDepartment"]));
        HonourDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["HonourDate"]));
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());

    }
}