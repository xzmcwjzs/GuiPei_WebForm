using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

public partial class teachers_OutDeptExamInformation_Manage : System.Web.UI.Page
{
   protected string id = string.Empty;
   protected string pi = string.Empty;
    OutDeptExamModel outDeptExamModel = null;
    OutDeptExamBLL outDeptExamBLL = null;
    protected string status = string.Empty;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));

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
    protected void save_Click(object sender, EventArgs e)
    {
        outDeptExamBLL = new OutDeptExamBLL();
        outDeptExamModel = new OutDeptExamModel();
        
        outDeptExamModel.kqqk = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(kqqk.Text));
        outDeptExamModel.gztd = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(gztd.Text));
        outDeptExamModel.ydyf = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ydyf.Text));
        outDeptExamModel.llsp = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(llsp.Text));
        outDeptExamModel.zdzx = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(zdzx.Text));
        outDeptExamModel.blsx = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(blsx.Text));
        outDeptExamModel.clbrnl = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(clbrnl.Text));
        outDeptExamModel.sjcznl = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(sjcznl.Text));
        outDeptExamModel.czjn = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(czjn.Text));
        outDeptExamModel.zdsp = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(zdsp.Text));
        outDeptExamModel.djnl = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(djnl.Text));
        outDeptExamModel.total_score = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(totalscore.Text));
        outDeptExamModel.instructor_date = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(teacher_time.Text));
        outDeptExamModel.dept_manager = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(kzr.Text));
        outDeptExamModel.dept_manager_date = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(kzr_time.Text));
        outDeptExamModel.is_pass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(ispass.SelectedItem.Value));

        if (string.IsNullOrEmpty(outDeptExamModel.is_pass))
        {
            ShowMessageBox.Showmessagebox(this, "考核结果不能为空", null);
            return;
        }

        if (string.IsNullOrEmpty(outDeptExamModel.dept_manager))
        {
            ShowMessageBox.Showmessagebox(this, "科主任不能为空", null);
            return;
        }
       
        if (outDeptExamModel.is_pass == "同意出科")
        {
            status = "已出科";
        }
        else
        {
            status = "顺延一期";
        }

        if (new StudentsRotaryBLL().UpdateOutdeptStatusByT(status,id) && outDeptExamBLL.UpdateById(outDeptExamModel,id) )
        {
            try
            {
                Response.Write("<script language='javascript'> alert('出科考核表修改成功');window.opener.window.loadPageList('" + pi + "');window.close();</script>");
                Response.End();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
    }


}