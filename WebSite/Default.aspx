<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>规范化培训系统</title>
    <script type="text/javascript" src="js/jquery-1.11.0.js"></script>
    <script type="text/javascript" src="js/swfobject.js"></script>
    <script type="text/javascript" src="js/global.js"></script>
    <script type="text/javascript">

        $(function () {
            $("#Image1").attr('src', 'ValidateImg.aspx?i=' + Math.random());
            $("#Image1").click(function () {
                $("#Image1").attr('src', 'ValidateImg.aspx?i=' + Math.random());

            });
        });

        $(function () {

            var h = 100;
            $("#newsIframe").height(h);
            setInterval(function () {
                reinitIframe('newsIframe');
            }, 200);
        });
    </script>

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
            COLOR: #009933;
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

        .auto-style1 {
            height: 92px;
        }
        -->
    </style>
</head>

<body style="background-color: #FFFFFF; margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; overflow-x: hidden;" marginwidth="0" marginheight="0">
    <center>
        <form id="form1" runat="server" name="form1" method="post" action="" target="_blank">

            <table style="width: 1000px; height: 92%; border: 0px;" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="height: 114px;" colspan="3">

                        <iframe style="width: 997px" frameborder="0" scrolling="no" height="111" src="index/Top2.html"></iframe>
                    </td>

                </tr>
                <tr>
                    <td style="height: 700px;" valign="top" class="auto-style3">
                        <iframe frameborder="0px" scrolling="no" src="index/right.html" style="width: 152px; margin-right: 8px; height: 519px;"></iframe>

                    </td>
                    <td valign="top" class="auto-style4">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 682px; height: 520px; margin-left: 0px;">
                            <tr>

                                <td align="center" colspan="3" class="auto-style2">
                                    <%--<div id="swfmovie"></div>--%>

                                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="667" height="80">
                                        <param name="movie" value="index/swf/<%=s %>.swf">
                                        <param name="quality" value="high">
                                        <embed src="index/swf/<%=s %>.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="667" height="80"></embed>
                                    </object>
                                </td>

                            </tr>

                            <tr>
                                <td style="height: 161px; width: 385px;">
                                    <table style="width: 100%; height: 142px; border: 0px;" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="height: 36px;" align="center">
                                                <label>
                                                    <span class="STYLE66">用户名：</span>
                                                    <asp:TextBox ID="txtUserName" runat="server" Width="95px"></asp:TextBox>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td style="height: 36px;" align="center">
                                                <label>
                                                    <span class="STYLE66">密<a style="padding-left: 1em"></a>码：</span>
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="95px"></asp:TextBox>
                                                </label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 36px;" align="center">
                                                <label>
                                                    <span class="STYLE66"><a style="padding-left: 4.5em"></a>验证码：</span>
                                                    <asp:TextBox ID="txtCode" runat="server" TextMode="Password" Width="95px"></asp:TextBox>

                                                </label>
                                                <asp:Image ID="Image1" runat="server" alt="" src="ValidateImg.aspx" ImageAlign="AbsBottom" Style="cursor: pointer;" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td height="36" valign="bottom" align="center"><a style="padding-left: 3em"></a>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/gif-0784 拷贝.jpg" OnClick="Login_Click" /><a style="padding-left: 1em"></a>
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/gif-0895 拷贝.jpg" OnClick="Registe_Click1" /><a style="padding-left: 1em"></a>
                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/gif-0784 拷贝4.gif" OnClick="ImageButton3_Click" /><a style="padding-left: 1em"></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                                <td width="300" valign="top" style="padding-top: 6px;">
                                    <ul style="padding-left: 0px; margin: 5px; height: 108px; float: left; width: 134px;">
                                        <li style="list-style-type: none; padding-top: 7px; color: #000080; font-size: 14px; height: 30px;">
                                            <img alt="" src="index/images/ball04.gif" style="margin-bottom: -3px" />&nbsp
                                           <a href="http://222.192.61.8:8077" target="_blank" style="color: #000080">自我健康管理</a>
                                        </li>
                                        <li style="list-style-type: none; padding-top: 7px; color: #000080; font-size: 14px; height: 30px;">
                                            <img alt="" src="index/images/ball05.gif" style="margin-bottom: -3px" />&nbsp
                                           <a href="http://222.192.61.8:8072" target="_blank" style="color: #000080">成人健康体检</a>
                                        </li>
                                        <li style="list-style-type: none; padding-top: 7px; color: #000080; font-size: 14px; height: 30px;">
                                            <img alt="" src="index/images/ball06.gif" style="margin-bottom: -3px" />&nbsp
                                           <a href="http://www.chinaehr.org" target="_blank" style="color: #000080">居民健康档案</a>
                                        </li>
                                    </ul>

                                    <ul style="padding-left: 0px; margin: 5px; height: 108px; float: right; width: 134px;">
                                        <li style="list-style-type: none; padding-top: 7px; color: #000080; font-size: 14px; height: 30px;">
                                            <img alt="" src="index/images/ball07.gif" style="margin-bottom: -3px" />&nbsp
                                           <a href="http://222.192.61.8:8090" target="_blank" style="color: #000080">卫生信息平台</a>
                                        </li>
                                        <li style="list-style-type: none; padding-top: 7px; color: #000080; font-size: 14px; height: 30px;">
                                            <img alt="" src="index/images/ball08.gif" style="margin-bottom: -3px" />&nbsp
                                           <a href="http://222.192.61.8:8089" target="_blank" style="color: #000080">标准电子病历</a>
                                        </li>
                                        <li style="list-style-type: none; padding-top: 7px; color: #000080; font-size: 14px; height: 30px;">
                                            <img alt="" src="index/images/ball09.gif" style="margin-bottom: -3px" />&nbsp
                                           <a href="http://222.192.61.8:8086" target="_blank" style="color: #000080">住院医师规陪</a>
                                        </li>
                                    </ul>
                                    <br />
                                    <div style="margin-top: 8px;">
                                        <asp:ImageButton ID="LatestVersion" runat="server" ImageUrl="images/ty.gif" /><a style="padding-left: 1em"></a>
                                        <asp:ImageButton ID="Dowload" runat="server" ImageUrl="~/images/down3.gif" OnClick="Dowload_Click" />
                                    </div>
                                </td>

                            </tr>

                            <tr>

                                <td height="50" align="center" colspan="3">
                                    <img src="images/up-3ghf.gif" width="637" height="50" />

                                </td>
                            </tr>
                            <tr>
                                <td height="13" colspan="3">
                                    <iframe id="newsIframe" src="index/news.html" frameborder="0" width="100%"></iframe>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="baseline" colspan="3">
                                    <div id="bottominfo">
                                        <table width="670" height="40" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="2" align="center">
                                                    <hr style="width: 660px; color: #bbb;" size="1" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td height="19" align="center"><span class="STYLE40">电话：<span class="STYLE36">0513-85051890</span> <a href="mailto:nthealth@126.com" style="color: #000080">邮箱：chinancd@163.com </a></span></td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="bottom">
                                                    <p class="STYLE40">Copyright &copy; 2015-2017 <span class="STYLE27">www.chinaehr.org </span><span class="STYLE40"><a href="http://icp.valu.cn/beianxinxi/28552c0a-5976-4e41-92c4-3a8f38460f02.html" target="_blank" style="color: #000080">苏ICP备11018114号</a></span>  </p>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="height: 700px;" valign="top" class="auto-style3">
                        <iframe style="width: 152px; margin-left: 8px; height: 519px;" frameborder="0" scrolling="no" src="index/left.html"></iframe>
                    </td>
                </tr>

            </table>

            <div>
            </div>

        </form>

    </center>
    <map name="Map">
        <area shape="rect" coords="319,32,661,74" href="" />
        <area shape="rect" coords="778,3,843,45" href="">
    </map>
</body>

</html>

