<%@ WebHandler Language="C#" Class="Add" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Model;
using System.Web.Script.Serialization;
using BLL;

public class Add : IHttpHandler {
    private const string filePath = "/UploadFile/bases/";
    private string fileName = string.Empty;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        HttpPostedFile file = context.Request.Files["UploadFile"];

        if (file != null && file.ContentLength > 0)
        {
            if (!Directory.Exists(context.Server.MapPath(filePath)))
            {
                Directory.CreateDirectory(context.Server.MapPath(filePath));
            }

            fileName = Path.GetFileName(file.FileName);
            string strExt = Path.GetExtension(fileName);
            string[] strExts = { ".doc", ".docx",".ppt",".pptx", ".xls", ".xlsx", ".pdf", ".rar", ".zip" };
            if (strExts.Contains(strExt))
            {
                if (File.Exists(context.Server.MapPath(filePath) + fileName))
                {
                    File.Delete(context.Server.MapPath(filePath) + fileName);
                }

                file.SaveAs(context.Server.MapPath(filePath) + fileName);
               
            }
            else
            {
                context.Response.Write("errorFormat");
                context.Response.End();
            }

        }

        TeachersAppointInformationBLL basesAppointInformationBLL = new TeachersAppointInformationBLL();
        TeachersAppointInformationModel basesAppointInformationModel = new TeachersAppointInformationModel();
        basesAppointInformationModel.id = Guid.NewGuid().ToString();
        basesAppointInformationModel.teachers_real_name = context.Request["BasesRealName"];
        basesAppointInformationModel.teachers_name = context.Request["BasesName"];
        basesAppointInformationModel.training_base_code = context.Request["TrainingBaseCode"];
        basesAppointInformationModel.training_base_name = context.Request["TrainingBaseName"];
        basesAppointInformationModel.professional_base_code = context.Request["ProfessionalBaseCode"];
        basesAppointInformationModel.professional_base_name = context.Request["ProfessionalBaseName"];
        basesAppointInformationModel.register_date = context.Request["RegisterDate"];
        basesAppointInformationModel.FileName = fileName;
        basesAppointInformationModel.FilePath = filePath;
        basesAppointInformationModel.IsReceive = "未接收";
        
        basesAppointInformationModel.appoint_begin_time = context.Request["AppointBeginTime"];
        basesAppointInformationModel.appoint_end_time = context.Request["AppointEndTime"];
        basesAppointInformationModel.training_content = context.Request["TrainingContent"];
        basesAppointInformationModel.total_num = context.Request["TotalNum"];
        basesAppointInformationModel.class_num = context.Request["ClassNum"];
        basesAppointInformationModel.each_class_num = context.Request["EachClassNum"];
        basesAppointInformationModel.comment = context.Request["Comment"];
        basesAppointInformationModel.is_pass = "未通过";
        basesAppointInformationModel.type = "专业基地";
        
        if (basesAppointInformationBLL.Insert(basesAppointInformationModel))
        {
            context.Response.Write("addSuccess");
        }
        else
        {
            context.Response.Write("addError");
        }
       
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}