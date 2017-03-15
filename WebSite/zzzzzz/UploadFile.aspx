<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="zzzzzz_UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.7.2.js"></script>
    <script src="../js/uploadify/jquery.uploadify.min.js"></script>
    <link href="../js/uploadify/uploadify.css" rel="stylesheet" />
    <script src="../js/uploadify/swfobject.js"></script>
    <script type="text/javascript">

        $(function () {
            $("#file_upload").uploadify({
                'debug': false,
                'buttonClass':'red',
                'swf': '../js/uploadify/uploadify.swf',
                'uploader': 'UploadFile.ashx',
                'fileObjName': 'Filedata',
                'method':'post',
                'cancelImg': '../js/uploadify/uploadify-cancel.png', 
                'queueID': 'uploadfileQueue',
                'auto': false,
                'multi': false,  //multi设置为true或false来控制是否可以进行多文件上传
                'fileTypeExts': '*.jpg;*.png;*.bmp;*.gif;*.jpeg',
                'fileTypeDesc': '请选择jpg , png , gif , jpeg文件',
                'fileSizeLimit':'2MB',
                'removeTimeout': '1',
                'buttonText': '选择照片',
                'width': '75',
                'height': '24',
                'progressData':'percentage',
                'onFallback': function () { //检测FLASH失败调用
                    alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。");
                },
                //返回一个错误，选择文件的时候触发  
                'onSelectError': function (file, errorCode, errorMsg) {
                    switch (errorCode) {
                        case -100:
                            alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                            break;
                        case -110:
                            alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "大小！");
                            break;
                        case -120:
                            alert("文件 [" + file.name + "] 大小异常！");
                            break;
                        case -130:
                            alert("文件 [" + file.name + "] 类型不正确！");
                            break;
                    }
                },
                "onUploadError": function (file, errorCode, erorMsg, errorString) {
                    alert("头像上传失败");
                },
                "onUploadSuccess": function (file, data, response) {
                    //上传成功触发，data是用来接受从后台返回来的数值
                //    alert("id:" + file.id + " -索引:" + file.index + " -文件名称:" + file.name +
                //+" -文件大小:" + file.size + " -文件类型:" + file.type + " -创建日期:" + file.creationdate +
                //+" -修改日期:" + file.modificationdate + " -文件状态:" + file.filestatus +
                    //+" –服务器端消息:" + data + " –是否上传成功:" + response);
                    var result = eval('(' + data + ')');
                    if (result.imgSrc != "0") {
                        alert(result.imgSrc);
                        alert(file.name);
                        $("#imgUpload").attr("src", result.imgSrc);
                    } else {
                        alert("头像上传失败");
                    }
                    
                 }
                    
            });

        });

        function doUplaod() {
            $('#file_upload').uploadify('upload', '*');
        }

        function closeLoad() {
            $('#file_upload').uploadify('cancel', '*');
        }
    </script>
</head>
<body>
    <table width="500" border="0" align="center" cellpadding="0" cellspacing="0" id="__01">  
        <tr>  
            <td align="center" valign="middle">  
                <div id="uploadfileQueue" style="padding: 3px;width:200px">  
                </div>
                <img src="../images/logo/logo.png" alt="图标" id="imgUpload" width="120px" height="170px"/>
                <div id="file_upload">
                      
                </div>  
            </td>  
        </tr>  
        <tr>  
            <td height="50" align="center" valign="middle">  
               <img alt="" src="../images/BeginUpload.gif" width="77" height="23" onclick="doUplaod()" style="cursor: hand" />  
                <img alt="" src="../images/CancelUpload.gif" width="77" height="23" onclick="closeLoad()" style="cursor: hand" />  
            </td>   
        </tr>  
    </table>  
</body>
</html>
