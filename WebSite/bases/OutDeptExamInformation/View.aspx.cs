using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class bases_OutDeptExamInformation_View : System.Web.UI.Page
{
    string id = string.Empty;
    OutDeptExamModel outDeptExamModel = null;
    OutDeptExamBLL outDeptExamBLL = null;
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
            outDeptExamBLL = new OutDeptExamBLL();
            outDeptExamModel = new OutDeptExamModel();

            outDeptExamModel = outDeptExamBLL.SelectById(id);

            students_real_name.Text = outDeptExamModel.students_real_name;
            students_name.Value = outDeptExamModel.students_name;
            training_base_code.Value = outDeptExamModel.training_base_code;
            training_base_name.Value = outDeptExamModel.training_base_name;
            sex.Text = outDeptExamModel.sex;
            high_education.Text = outDeptExamModel.high_education;
            high_education_time.Text = outDeptExamModel.high_education_time;
            professional_base_code.Value = outDeptExamModel.professional_base_code;
            professional_base_name.Text = outDeptExamModel.professional_base_name;
            students_real_name.Text = outDeptExamModel.students_real_name;
            rotary_dept_name.Text = outDeptExamModel.rotary_dept_name;
            rotary_dept_code.Value = outDeptExamModel.rotary_dept_code;
            rotary_begin_time.Text = outDeptExamModel.rotary_begin_time;
            rotary_end_time.Text = outDeptExamModel.rotary_end_time;
            instructor.Text = outDeptExamModel.instructor;
            instructor_tag.Value = outDeptExamModel.instructor_tag;
            kqqk.Text = outDeptExamModel.kqqk;
            gztd.Text = outDeptExamModel.gztd;
            ydyf.Text = outDeptExamModel.ydyf;
            llsp.Text = outDeptExamModel.llsp;
            zdzx.Text = outDeptExamModel.zdzx;
            blsx.Text = outDeptExamModel.blsx;
            clbrnl.Text = outDeptExamModel.clbrnl;
            sjcznl.Text = outDeptExamModel.sjcznl;
            czjn.Text = outDeptExamModel.czjn;
            zdsp.Text = outDeptExamModel.zdsp;
            djnl.Text = outDeptExamModel.djnl;
            totalscore.Text = outDeptExamModel.total_score;
            teacher.Text = outDeptExamModel.instructor;
            teacher_time.Text = outDeptExamModel.instructor_date;
            kzr.Text = outDeptExamModel.dept_manager;
            kzr_time.Text = outDeptExamModel.dept_manager_date;
            if (outDeptExamModel.is_pass == "同意出科")
            {
                ispass.Items[0].Selected = true;
            }
            else if (outDeptExamModel.is_pass == "顺延一期")
            {
                ispass.Items[1].Selected = true;
            }

        }

    }
}