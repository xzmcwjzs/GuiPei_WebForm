<%@ WebHandler Language="C#" Class="Update" %>

using System;
using System.Web;
using BLL;
using Model;
using Common;

public class Update : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        TeachersAppointInformationBLL basesAppointInformationBLL = new TeachersAppointInformationBLL();
        TeachersAppointInformationModel basesAppointInformationModel = new TeachersAppointInformationModel();
        basesAppointInformationModel.id = context.Request["Id"];
        basesAppointInformationModel.register_date = context.Request["RegisterDate"];

        basesAppointInformationModel.appoint_begin_time = context.Request["AppointBeginTime"];
        basesAppointInformationModel.appoint_end_time = context.Request["AppointEndTime"];
        basesAppointInformationModel.training_content = context.Request["TrainingContent"];
        basesAppointInformationModel.total_num = context.Request["TotalNum"];
        basesAppointInformationModel.class_num = context.Request["ClassNum"];
        basesAppointInformationModel.each_class_num = context.Request["EachClassNum"];
        basesAppointInformationModel.comment = context.Request["Comment"];

        if (basesAppointInformationBLL.Update(basesAppointInformationModel))
        {
            context.Response.Write("updateSuccess");
        }
        else
        {
            context.Response.Write("updateError");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}