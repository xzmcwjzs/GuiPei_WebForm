<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrameLeft.aspx.cs" Inherits="managers_FrameLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>功能列表</title>
    <link href="../css/global.css" rel="stylesheet" />
    <script src="../js/global.js"></script>
    <script src="../js/jquery-1.11.0.js"></script>

    <style type="text/css">
        body {
            margin: 0px;
            font: 12px 宋体;
            background-color: #ECF0FB;
        }

        a:visited, a:link, a:hover {
            text-decoration: none;
            color: #000080;
        }

        .sec_menu {
            border-left: 2px solid #84bf92;
            border-right: 2px solid #84bf92;
        }

        .sec_menu1 {
            border-left: 2px solid #84bf92;
            border-right: 2px solid #84bf92;
            border-bottom: 2px solid #84bf92;
        }

        .sec_menu td {
            padding-left: 2px;
        }

        .menu_hide {
            background: url(../images/main/hide.gif) right no-repeat;
            background-color: #0066cc;
            color: white;
            font-size: 14px;
            height: 26px;
            border: 2px solid #84bf92;
            padding-left: 13px;
            cursor: pointer;
        }

        .menu_show {
            background: url(../images/main/show.gif) right no-repeat;
            background-color: #0066cc;
            color: white;
            font-size: 14px;
            height: 26px;
            border: 2px solid #84bf92;
            border-bottom: 2px;
            padding-left: 13px;
            cursor: pointer;
        }

        .menu_title SPAN {
            font-weight: bold;
            left: 8px;
            color: #215dc6;
            position: relative;
            top: 2px;
        }

        .auto-style1 {
            border-left: 2px solid #84bf92;
            border-right: 2px solid #84bf92;
            border-top: 2px solid #84bf92;
            border-bottom: 2px solid #84bf92;
            background: #0066cc url('../images/main/show.gif') no-repeat right 50%;
            color: white;
            font-size: 14px;
            height: 26px;
            padding-left: 13px;
            cursor:pointer;
            width: 142px;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
        }

        .auto-style2 {
            width: 142px;
        }

        .menu_hide1 {
            width: 100px;
            background: url(../images/title_bg_hide.gif) right no-repeat;
        }

        .menu_show1 {
            width: 120PX;
            background: url(../images/title_bg_show.gif) right no-repeat;
        }
    </style>

    <script type="text/javascript">
        function showsubmenu(sid, f_id) {
            whichEl = eval("submenu" + sid);
            if (whichEl.style.display == "none") {
                eval("submenu" + sid + ".style.display=\"\";");
                eval("this.menuTitle" + sid + ".className=\"menu_hide\";");

            }
            else {
                eval("submenu" + sid + ".style.display=\"none\";");
                eval("this.menuTitle" + sid + ".className=\"menu_show\";");
            }



        }

        function showsubmenu1(sid, f_id) {
            whichEl = eval("submenu" + sid);
            if (whichEl.style.display == "none") {
                eval("submenu" + sid + ".style.display=\"\";");
                eval("this.menuTitle" + sid + ".className=\"menu_hide1\";");
            }
            else {
                eval("submenu" + sid + ".style.display=\"none\";");
                eval("this.menuTitle" + sid + ".className=\"menu_show1\";");
            }

        }
    </script>
    <script type="text/javascript">
        $(function () {

            //$("#submenu2").hide();
            $("#submenu2 div table tr td").click(function () {
                alert("该模块由指导老师进行操作");
            });
            //$("#submenu3").hide();
            $("#submenu3 div table tr td").click(function () {
                alert("该模块由专业基地老师进行操作");
            });
            //$("#submenu1").hide();
            $("#submenu1 div table tr td").click(function () {
                alert("该模块由学员进行操作");
            });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-left: 2px;">
            <table cellspacing="0" cellpadding="0" width="140">
                <tr>
                    <td class="menu_show" id="menuTitle1" onclick="showsubmenu(1,'05')">学员信息</td>
                </tr>
                <tr>
                    <td id="submenu1" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_1"></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">基本信息 </a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">轮转信息 </a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">问卷调查 </a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" id="menuTitle2" onclick="showsubmenu(2,'05')">培训小组</td>
                    <%--<td class="auto-style1" id="menuTitle2">培训小组</td>--%>
                </tr>
                <tr>
                    <td id="submenu2" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_4"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">出科考核</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">预约信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">问卷调查</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1" id="menuTitle3" onclick="showsubmenu(3,'05')">专业基地 </td>
                </tr>
                <tr>
                    <td id="submenu3" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_5"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">学员信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="#">预约信息</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" id="menuTitle4" onclick="showsubmenu(4,'05')">管理人员 </td>
                </tr>
                <tr>
                    <td id="submenu4" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="Td3"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">学员基本信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">学员出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">预约信息</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" id="menuTitle5" onclick="showsubmenu(5,'05')">考试考核</td>
                </tr>
                <tr>
                    <td id="submenu5" class="auto-style2">
                        <div class="sec_menu1" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="Td6"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_hide1" id="menuTitle6" onclick="showsubmenu1(6,'05')"><span style="color: #84bf92">&middot;</span>过程考核</td>
                                </tr>
                                <tr>
                                    <td id="submenu6" class="auto-style2" style="display: none">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">日常考核</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Anxiety/Frame.htm" target="MainFrame">出科考核</a> </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Depression/Frame.htm" target="MainFrame">年度考核</a> </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">结业考核</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="menu_show" id="menuTitle7" onclick="showsubmenu(7,'05')">统计查询</td>
                </tr>
                <tr>
                    <td id="submenu7" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_1"></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Personal/Frame.htm" target="MainFrame">科室</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">派出单位</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">协同单位</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">培训基地</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">专业基地</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">指导老师</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">问卷调查</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">日常考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">年度考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="BasicInformation/Family/Frame.htm" target="MainFrame">接业考核</a></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>



