<%@ WebHandler Language="C#" Class="upload" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;


public class upload : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Charset = "utf-8";
        HttpPostedFile file = context.Request.Files["Filedata"];
       // HttpPostedFile file = context.Request.Files["uploadFile"];
        //string uploadPath = context.Server.MapPath("..\\UploadFile\\images\\");
        //if (file != null)
        //{

        //    if (!Directory.Exists(uploadPath))
        //    {
        //        Directory.CreateDirectory(uploadPath);
        //    }
        //    file.SaveAs(uploadPath + file.FileName);

        //    context.Response.Write(uploadPath);

        //}
        //else
        //{
        //    context.Response.Write("0");
        //}

        if (file != null && file.ContentLength > 0)
        {
            
            string strfillName =Path.GetFileName(file.FileName);
            string strExt = Path.GetExtension(strfillName);
            string[] strExts = { ".jpg", ".png", ".bmp", ".gif", ".jpeg" };

            if (strExts.Contains(strExt))
            {
                //string strSaveName = string.Empty;
                //string strSavePath = ConvertImageByWH(context, file.InputStream, 60, 80, strExt, out strSaveName);
                string strSavePath = ConvertImageByWH(context, file.InputStream, 120, 170, strExt, strfillName);

                string strJson = "{'imgSrc':'" + strSavePath + "'}";

                context.Response.Write(strJson);

            }
            else
            {
                context.Response.Write("{'imgSrc':'0'}");//请选择格式为:jpg、png、bmp、gif、jpeg的头像进行上传
            }
        }
        else
        {
            context.Response.Write("{'imgSrc':'1'}");//请选择头像进行上传
        }
    }

    /// <summary>
    /// 按照给定的宽高对图片进行压缩
    /// </summary>
    /// <param name="byteImg">图片字节流</param>
    /// <param name="intImgCompressWidth">压缩后的图片宽度</param>
    /// <param name="intImgCompressHeight">压缩后的图片高度</param>
    /// <param name="strExt">扩展名</param>
    /// <param name="strSaveName">保存后的名字</param>
    /// <returns>压缩后的图片相对路径</returns>
    private string ConvertImageByWH(HttpContext context, Stream stream, int intImgCompressWidth, int intImgCompressHeight, string strExt, string strSaveName)
    {
        //从输入流中获取上传的image对象
        using (System.Drawing.Image img = System.Drawing.Image.FromStream(stream))
        {
            //根据压缩比例求出图片的宽度
            int intWidth = intImgCompressWidth / intImgCompressHeight * img.Height;
            int intHeight = img.Width * intImgCompressHeight / intImgCompressWidth;
            //画布
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(img, new Size(intImgCompressWidth, intImgCompressHeight)))
            {
                //在画布上创建画笔对象
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
                {
                    //将图片使用压缩后的宽高,从0，0位置画在画布上
                    graphics.DrawImage(img, 0, 0, intImgCompressWidth, intImgCompressHeight);
                    //创建保存路径
                    string strSavePath = "/UploadFile/images/";

                    //如果保存目录不存在，则创建
                    if (!Directory.Exists(context.Server.MapPath(strSavePath)))
                    {
                        Directory.CreateDirectory(context.Server.MapPath(strSavePath));
                    }
                    // //定义新的文件名
                    // string strfileNameNoExt = string.Empty;
                    // //接收参数
                    // string strId = context.Request.Params["strId"];
                    // if (!string.IsNullOrEmpty(strId))
                    //{
                    //    if (strId == "1")
                    //      {
                    //         //定义新的文件名
                    //       strfileNameNoExt = Guid.NewGuid().ToString();
                    //    }
                    // }

                    // strSaveName = strfileNameNoExt + strExt;
                    //添加时如果图片已经存在则删除
                    if (File.Exists(context.Server.MapPath(strSavePath) + strSaveName))
                    {
                        File.Delete(context.Server.MapPath(strSavePath) + strSaveName);
                    }
                    //保存文件
                    bitmap.Save(context.Server.MapPath(strSavePath) + strSaveName);
                    return strSavePath + strSaveName;
                }
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}