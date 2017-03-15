<%@ WebHandler Language="C#" Class="OutDeptExam" %>

using System;
using System.Web;
using Model;
using BLL;

public class OutDeptExam : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        OutDeptExamBLL outDeptExamBLL = new OutDeptExamBLL();
        OutDeptExamModel outDeptExamModel = new OutDeptExamModel();

        string name = context.Request["name"];
        string tbCode = context.Request["tbCode"];
        string rdCode = context.Request["rdCode"];
        string rbTime = context.Request["rbTime"];
        string reTime = context.Request["reTime"];
        outDeptExamModel = outDeptExamBLL.SelectRotaryTimeModel(name,tbCode,rdCode);
        
        if (outDeptExamModel == null)
        {
            context.Response.Write("0");
        }
        else {
            if (outDeptExamModel.rotary_begin_time == rbTime && outDeptExamModel.rotary_end_time == reTime)
            {
                context.Response.Write("1");
                
            }
            else {
                context.Response.Write("0");
               
            }
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}