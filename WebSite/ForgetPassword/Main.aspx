<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="ForgetPassword_Main" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人员注册</title>
    <script src="../js/jquery-1.7.2.js"></script>
    <link href="../css/global.css" rel="stylesheet" />
    <style type="text/css">
        <!--
        .STYLE20 a:hover {
            font-size: 16px;
            color: #ffffff;
            text-decoration: none;
        }

        {
            font-size: 15px;
            font-family: "宋体";
            color: #FFFFFF;
        }

        .STYLE79 a:hover {
            font-size: 15px;
            color: #ffffff;
            text-decoration: none;
        }

        {
            font-size: 14px;
            font-family: "宋体";
            color: #FFFFFF;
        }

        .STYLE21 {
            font-size: 14px;
            line-height: 20px;
        }

        .STYLE22 {
            font-size: 12px;
            vertical-align: 1%;
            line-height: normal;
        }

        .STYLE25 {
            font-size: 14px;
            line-height: 15px;
        }

        .STYLE29 {
            font-family: "Times New Roman", Times, serif;
            font-size: 12px;
            vertical-align: 5%;
            line-height: normal;
            color: #000080;
        }

        .STYLE27 {
            font-size: 12px;
        }

        .STYLE28 {
            font-size: 10px;
            color: black;
        }

        a:link {
            text-decoration: none;
            color: #0000FF;
        }

        a:visited {
            color: #0000FF;
            text-decoration: none;
        }

        a:active {
            color: #0000FF;
            text-decoration: none;
        }

        .STYLE36 {
            font-family: "宋体";
        }

        a {
            color: #000080;
        }

        .STYLE40 {
            font-size: 12px;
            color: #000080;
        }

        .STYLE46 {
            font-size: 10pt;
        }

        .STYLE56 {
            font-size: 15px;
            color: #FFFFFF;
        }

        .STYLE63 {
            color: #000099;
        }

        .STYLE66 {
            font-size: 14px;
            line-height: 15px;
            color: #000099;
        }

        BODY {
            COLOR: #000000;
            FONT-SIZE: 10pt;
        }

        UL {
            FONT-SIZE: 10pt;
        }

        .STYLE69 {
            font-size: 10pt;
            line-height: 20px;
            color: #009933;
        }

        .STYLE76 {
            font-size: 14px;
        }

        .STYLE78 {
            color: #000080;
        }

        .STYLE79 {
            font-size: 15pt;
        }

        .STYLE80 {
            font-size: 15px;
        }

        #newsIframe {
            height: 21px;
        }

        .auto-style2 {
            height: 89px;
        }

        .auto-style4 {
            width: 612px;
        }

        .button {
            width: 61px;
            height: 23px;
        }
         #bottominfo {
            height: 41px;
        }

        .auto-style12 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            color: #000000;
            height: 20px;
            width: 91px;
        }

        .auto-style14 {
            font-size: 14px;
            line-height: 15px;
            color: #000099;
            height: 25px;
        }

        .auto-style15 {
            height: 25px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            
            $("#GetPassword").click(function () {
                if ($("#Name").val() == "") { alert("用户名不能为空"); return false; }
                if ($("#RealName").val() == "") { alert("真实姓名不能为空"); return false; }
                var forms = $("#form1").serializeArray();
                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/GetPassword.ashx",
                    dataType: "text",//如果是json的话，不用eval()在解析
                    data: forms,
                    success: function (data) {
                        if (data !="-1") {
                            alert("您的密码为："+data);
                        } else {
                            alert("用户名或真实姓名错误");
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }

                });
            });
        });

    </script>

</head>
<body style="text-align: center; background-color: #FFFFFF; margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; overflow-x: hidden;" marginwidth="0" marginheight="0">
    <center>   
    <form id="form1" runat="server" name="form1" target="_blank">

        <table style="width:1000px;height:811px;border:0px;" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="height:114px;" colspan="3">

                        <iframe style="width: 997px" frameborder="0" scrolling="no" height="111" src="../index/top.html"></iframe>
                    </td>

                </tr>
                <tr>
                    <td style="height:700px;width:143px" valign="top">
                        <iframe frameborder="0px" scrolling="no" src="../index/right.html" style="width: 152px; margin-right: 1px; height: 557px;"></iframe>

                    </td>
                    <td valign="top" class="auto-style4">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 682px; height: 520px; margin-left: 0px;">
                            <tr>
                                <td align="center" colspan="2" class="auto-style2">
                                  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="667" height="80">
                                  <param name="movie" value="../index/swf/zyys.swf">
                                  <param name="quality" value="high">
                                  <embed src="../index/swf/zyys.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="667" height="80"></embed>
                                  </object>
                                </td>
                            </tr>
                        <tr>
                        <td style="width:375px;">
                        <table style="width:676px;height:500px; text-align:center; margin:auto;"  border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height:20px;width:676px"align="left" valign="bottom"><a style="font-size:19px;font-family:KaiTi;font-weight:900;color:#000;text-align:center" >密码找回</a><a style="padding-left:50px"></a></td>
                               
                           </tr>
                            <tr>
                                <td height="10"><img src="../images/gif066.gif" alt="gp" width="676" height="2"/></td>
                            </tr>
                            <tr>
                                
                                <td style="height:40px;">
                                    用<a style="padding-left:0.5em;"></a>户<a style="padding-left:0.5em;"></a>名：<input type="text" id="Name"name="Name" style="width:150px;" />
                                </td>
                             </tr>
                            <tr>
                                <td valign="top" style="height:40px;">
                                    真实姓名：<input type="text" id="RealName"name="RealName" style="width:150px;" />
                                </td>
                             </tr>
                            <tr>
                                <td valign="top">
                                    <input id="GetPassword" name="GetPassword" type="button" class="button" value="找回密码" style="width:61px;height:25px;"/>
                                    <a style="padding-left:5px;"></a>
                                    <input id="Reset" name="Reset" type="button" value="重置" style="width:61px;height:25px;" onclick="form1.reset();"/>
                                </td>
                             </tr>
                        </table>
                        </td>
                    
                            </tr>
                     </table>
                     </td>
                    <td width="143" valign="top">
                      <iframe frameborder="0" scrolling="no" src="../index/left.html" style="width: 152px; margin-left: 0px; height: 557px;"></iframe>
                   </td>
                </tr>
            </table>
    </form>
    </center>
</body>
</html>
