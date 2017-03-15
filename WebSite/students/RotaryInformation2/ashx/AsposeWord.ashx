<%@ WebHandler Language="C#" Class="AsposeWord" %>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using Aspose.Words;
using Aspose.Words.Tables;

public class AsposeWord : IHttpHandler{
    StudentsRotaryInformation2BLL bll = new StudentsRotaryInformation2BLL();
    protected string filename = string.Empty;
    DataTable dt = new DataTable();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string Name = context.Request["Name"];
        string RealName = context.Request["RealName"];
        string TrainingBaseCode = context.Request["TrainingBaseCode"];
        string TrainingBaseName = context.Request["TrainingBaseName"];
        
        string templatePath = HttpContext.Current.Server.MapPath(@"/RotaryTemplete/AsposeRotaryTemplete.docx");
        
        Document doc = new Document(templatePath);
        DocumentBuilder builder = new DocumentBuilder(doc);
        if (!File.Exists(templatePath)) { context.Response.Write("服务器没有模版"); return; };
        dt = bll.GetDtByNT(Name, TrainingBaseCode);
        filename = "个人轮转表-" + dt.Rows[0]["RealName"] + ".doc";
        string outputPath = HttpContext.Current.Server.MapPath(@"/RotaryWord/"+filename);
        int count = 0;

        for (var i = 0; i < dt.Columns.Count; i++)
        {
            if (doc.Range.Bookmarks[dt.Columns[i].ColumnName.Trim()] != null)
            {
                Bookmark mark = doc.Range.Bookmarks[dt.Columns[i].ColumnName.Trim()];
                mark.Text = "";
                count++;
            }
        }
        System.Collections.Generic.List<string> listcolumn = new System.Collections.Generic.List<string>(count);
        for (var i = 0; i < count; i++)
        {
            builder.MoveToCell(0, 0, i, 0); //移动单元格
            if (builder.CurrentNode.NodeType == NodeType.BookmarkStart)
            {
                listcolumn.Add((builder.CurrentNode as BookmarkStart).Name);
            }
        }
        double width = builder.CellFormat.Width;//获取单元格宽度
        builder.MoveToBookmark("table");        //开始添加值
        for (var m = 0; m < dt.Rows.Count; m++)
        {
            for (var i = 0; i < listcolumn.Count; i++)
            {
                builder.InsertCell();            // 添加一个单元格                    
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = width;
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                builder.Write(dt.Rows[m][listcolumn[i]].ToString());
            }
            builder.EndRow();
        }
        doc.Range.Bookmarks["table"].Text = "";    // 清掉标示  
        //doc.Save(filename, SaveFormat.Doc, SaveType.OpenInWord,context.Response);
        doc.Save(outputPath);
        //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", filename));
        //context.Response.WriteFile(outputPath);
        context.Response.Write(filename);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}