<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrameLeft.aspx.cs" Inherits="FrameLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>功能列表</title>
    <link href="css/global.css" rel="stylesheet" />
    <script src="js/global.js"></script>
    <script src="js/jquery-1.7.2.js"></script>
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
            background: url(images/main/hide.gif) right no-repeat;
            background-color: #0066cc;
            color: white;
            font-size: 14px;
            height: 26px;
            border: 2px solid #84bf92;
            padding-left: 13px;
            cursor: pointer;
        }

        .menu_show {
            background: url(images/main/show.gif) right no-repeat;
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
            background: #0066cc url('images/main/show.gif') no-repeat right 50%;
            color: white;
            font-size: 14px;
            height: 26px;
            padding-left: 13px;
            cursor: pointer;
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
            background: url(images/title_bg_hide.gif) right no-repeat;
        }

        .menu_show1 {
            width: 120PX;
            background: url(images/title_bg_show.gif) right no-repeat;
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
            var role = "<%=role%>";
            if (role == "students") {
                $("#menuTitle2").hide(); $("#submenu2").hide();
                $("#menuTitle3").hide(); $("#submenu3").hide();
                $("#menuTitle4").hide(); $("#submenu4").hide();
                $("#menuTitle5").hide(); $("#submenu5").hide();
                $("#menuTitle7").hide(); $("#submenu7").hide();
                $("#menuTitle71").hide(); $("#submenu71").hide();
                $("#menuTitle72").hide(); $("#submenu72").hide();
            } else if (role == "teachers") {
                $("#menuTitle1").hide(); $("#submenu1").hide();
                $("#menuTitle3").hide(); $("#submenu3").hide();
                $("#menuTitle4").hide(); $("#submenu4").hide();
                $("#menuTitle5").hide(); $("#submenu5").hide();
                $("#menuTitle71").hide(); $("#submenu71").hide();
                
                $("#menuTitle7").hide(); $("#submenu7").hide();
                $("#menuTitle8").hide(); $("#submenu8").hide();
            }  else if (role == "bases") {
                $("#menuTitle1").hide(); $("#submenu1").hide();
                $("#menuTitle3").hide(); $("#submenu3").hide();
                $("#menuTitle2").hide(); $("#submenu2").hide();
                $("#menuTitle5").hide(); $("#submenu5").hide();
                $("#menuTitle7").hide(); $("#submenu7").hide();
                $("#menuTitle8").hide(); $("#submenu8").hide();
                
                $("#menuTitle72").hide(); $("#submenu72").hide();
            } else if (role == "managers") {
                $("#menuTitle1").hide(); $("#submenu1").hide();
                $("#menuTitle3").hide(); $("#submenu3").hide();
                $("#menuTitle4").hide(); $("#submenu4").hide();
                $("#menuTitle2").hide(); $("#submenu2").hide();
                $("#menuTitle8").hide(); $("#submenu8").hide();
                $("#menuTitle71").hide(); $("#submenu71").hide();
                $("#menuTitle72").hide(); $("#submenu72").hide();
            } else {
                return;
            }

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-left: 2px;">
            <table cellspacing="0" cellpadding="0" width="140">

                <tr>
                    <td class="menu_show" id="menuTitle1" onclick="showsubmenu(1,'05')">学员</td>
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
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/PersonalInformation2/Frame.html" target="MainFrame">基本信息 </a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/RotaryInformation2/Frame.html" target="MainFrame">轮转信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle101" onclick="showsubmenu1(101,'05')"><span style="color: #84bf92">&middot;</span>轮转记录</td>
                                </tr>
                                <tr>
                                    <td id="submenu101" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_101"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/DeptFeeling/Frame.html" target="MainFrame">入科感想</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/DiseaseRegister/Frame.html" target="MainFrame">病种登记</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/SkillRequirement/Frame.html" target="MainFrame">技能要求</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/SurgeryRecords/Frame.html" target="MainFrame">手术记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/BedManagement/Frame.html" target="MainFrame">床位管理</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/RescuePatientRecords/Frame.html" target="MainFrame">抢救病人记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/TrainingTeachingActivities/Frame.html" target="MainFrame">培训教学活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/WriteMedicalRecords/Frame.html" target="MainFrame">书写病历</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/OutpatientEmergency/Frame.html" target="MainFrame">门/急诊诊治记录</a></td>
                                                </tr>

                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/StudyAndReading/Frame.html" target="MainFrame">学习和阅读</a></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/BigMedicalRecords/Frame.html" target="MainFrame">大病历</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle102" onclick="showsubmenu1(102,'05')"><span style="color: #84bf92">&middot;</span>其他项目登记</td>
                                </tr>
                                <tr>
                                    <td id="submenu102" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_102"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/JoinTeachingRecords/Frame.html" target="MainFrame">参加教学记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/JoinResearchRecords/Frame.html" target="MainFrame">参加科研记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/JoinStudyActivities/Frame.html" target="MainFrame">参加学术活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/PublishArticalRecords/Frame.html" target="MainFrame">发表文章记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/MedicalError/Frame.html" target="MainFrame">医疗差错事故</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="students/ReceiveHonour/Frame.html" target="MainFrame">获奖情况</a></td>
                                                </tr>

                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/AttendanceManagement/Frame.html" target="MainFrame">考勤管理</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/AdviceFeedback/Frame.html" target="MainFrame">意见反馈</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/News/Frame.html" target="MainFrame">查看新闻公告</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="QuestionBank/Frame.html" target="MainFrame">题库训练</a></td>
                                </tr>
                               <%-- <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">日常考核成绩</td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="students/ChuKeExam/Frame.html" target="MainFrame">出科考核成绩</td>
                                </tr>
                               <%-- <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">年度考核成绩</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">结业考核成绩</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">变更基地/退培申请</td>
                                </tr>--%>

                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" id="menuTitle8" onclick="showsubmenu(8,'05')">统计分析</td>
                </tr>
                <tr>
                    <td id="submenu8" class="auto-style2" style="border-bottom: 2px solid #84bf92;">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_8"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/QuestionBank/Frame.html" target="MainFrame">题库训练结果</a></td>
                                </tr>
                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">科室情况</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">培训专业</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">派出单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">协同单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">身份类型</td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">参训时间</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">日常考核</td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="/Statics/Students/ChuKeExam/Frame.html" target="MainFrame">考核成绩</td>
                                </tr>
                               <%-- <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">年度考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">结业考核</td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>

                <%--<tr>
                    <td class="auto-style1" id="menuTitle11" onclick="showsubmenu(11,'05')">考试考核</td>
                </tr>--%>
                <%-- <tr>
                    <td id="submenu11" class="auto-style2">
                        <div class="sec_menu1" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_11"></td>
                                </tr>
                               <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">日常考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">年度考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">结业考核</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>--%>

                <tr>
                    <td class="auto-style1" id="menuTitle2" onclick="showsubmenu(2,'05')">指导医师</td>

                </tr>
                <tr>
                    <td id="submenu2" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>

                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_2"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/StudentsBasicInformation/Frame.html" target="MainFrame">学员基本信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/StudentsRotaryInformation/Frame.html" target="MainFrame">学员轮转信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/OutDeptExamInformation/Frame.html" target="MainFrame">学员出科成绩</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/StudentsAttendanceManagement/Frame.html" target="MainFrame">学员考勤管理</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle201" onclick="showsubmenu1(201,'05')"><span style="color: #84bf92">&middot;</span>学员轮转记录</td>
                                </tr>
                                <tr>
                                    <td id="submenu201" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_201"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsDeptFeeling/Frame.html" target="MainFrame">入科感想</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsDiseaseRegister/Frame.html" target="MainFrame">病种登记</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsSkillRequirement/Frame.html" target="MainFrame">技能要求</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsSurgeryRecords/Frame.html" target="MainFrame">手术记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsBedManagement/Frame.html" target="MainFrame">床位管理</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsRescuePatientRecords/Frame.html" target="MainFrame">抢救病人记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsTrainingTeachingActivities/Frame.html" target="MainFrame">培训教学活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsWriteMedicalRecords/Frame.html" target="MainFrame">书写病历</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsOutpatientEmergency/Frame.html" target="MainFrame">门/急诊诊治记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsStudyAndReading/Frame.html" target="MainFrame">学习和阅读</a></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/StudentsBigMedicalRecords/Frame.html" target="MainFrame">学员大病历</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle202" onclick="showsubmenu1(202,'05')"><span style="color: #84bf92">&middot;</span>学员其他项目</td>
                                </tr>
                                <tr>
                                    <td id="submenu202" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_202"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsJoinTeachingRecords/Frame.html" target="MainFrame">参加教学记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsJoinResearchRecords/Frame.html" target="MainFrame">参加科研记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsJoinStudyActivities/Frame.html" target="MainFrame">参加学术活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsPublishArticalRecords/Frame.html" target="MainFrame">发表文章记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsMedicalError/Frame.html" target="MainFrame">医疗差错事故</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="teachers/StudentsReceiveHonour/Frame.html" target="MainFrame">获奖情况</a></td>
                                                </tr>

                                            </table>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/AppointInformation/Frame.html" target="MainFrame">预约信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/QuestionnaireInformation/Frame.html" target="MainFrame">查看问卷情况</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/News/Frame.html" target="MainFrame">查看新闻公告</a></td>
                                </tr>
                               <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/RiChangExam/Frame.html" target="MainFrame">学员日常考核</td>
                                </tr>
                                 <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/OutDeptExamInformation/Frame.html" target="MainFrame">学员出科考核</a></td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/NianDuExam/Frame.html" target="MainFrame">学员年度考核</td>
                                </tr>
                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员结业考核</td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>


                <%--<tr>
                    <td class="auto-style1" id="menuTitle21" onclick="showsubmenu(21,'05')">考试考核</td>
                </tr>
                <tr>
                    <td id="submenu21" class="auto-style2">
                        <div class="sec_menu1" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_21"></td>
                                </tr>
                               <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员日常考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/OutDeptExamInformation/Frame.html" target="MainFrame">学员出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员年度考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员结业考核</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>--%>

                 <tr>
                    <td class="auto-style1" id="menuTitle72" onclick="showsubmenu(72,'05')">统计分析</td>
                </tr>
                <tr>
                    <td id="submenu72" class="auto-style2" style="border-bottom: 2px solid #84bf92;">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_72"></td>
                                </tr>

                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">科室情况</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">培训专业</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/SendUnit/Frame.html" target="MainFrame">派出单位</td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/CollaborativeUnit/Frame.html" target="MainFrame">协同单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/IdentityType/Frame.html" target="MainFrame">身份类型</td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/TrainingTime/Frame.html" target="MainFrame">参训时间</td>
                                </tr>
                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">日常考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">出科考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">年度考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">结业考核</td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1" id="menuTitle4" onclick="showsubmenu(4,'05')">专业基地负责人 </td>
                </tr>
                <tr>
                    <td id="submenu4" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_4"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/StudentsBasicInformation/Frame.html" target="MainFrame">学员基本信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/StudentsRotaryInformation/Frame.html" target="MainFrame">学员轮转信息</a></td>

                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/OutDeptExamInformation/Frame.html" target="MainFrame">学员出科成绩</a></td>

                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/StudentsAttendanceManagement/Frame.html" target="MainFrame">学员考勤管理</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle401" onclick="showsubmenu1(401,'05')"><span style="color: #84bf92">&middot;</span>学员轮转记录</td>
                                </tr>
                                <tr>
                                    <td id="submenu401" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_401"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsDeptFeeling/Frame.html" target="MainFrame">入科感想</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsDiseaseRegister/Frame.html" target="MainFrame">病种登记</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsSkillRequirement/Frame.html" target="MainFrame">技能要求</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsSurgeryRecords/Frame.html" target="MainFrame">手术记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsBedManagement/Frame.html" target="MainFrame">床位管理</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsRescuePatientRecords/Frame.html" target="MainFrame">抢救病人记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsTrainingTeachingActivities/Frame.html" target="MainFrame">培训教学活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsWriteMedicalRecords/Frame.html" target="MainFrame">书写病历</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsOutpatientEmergency/Frame.html" target="MainFrame">门/急诊诊治记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsStudyAndReading/Frame.html" target="MainFrame">学习和阅读</a></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/StudentsBigMedicalRecords/Frame.html" target="MainFrame">学员大病历</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle402" onclick="showsubmenu1(402,'05')"><span style="color: #84bf92">&middot;</span>学员其他项目</td>
                                </tr>
                                <tr>
                                    <td id="submenu402" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_402"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsJoinTeachingRecords/Frame.html" target="MainFrame">参加教学记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsJoinResearchRecords/Frame.html" target="MainFrame">参加科研记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsJoinStudyActivities/Frame.html" target="MainFrame">参加学术活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsPublishArticalRecords/Frame.html" target="MainFrame">发表文章记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsMedicalError/Frame.html" target="MainFrame">医疗差错事故</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="bases/StudentsReceiveHonour/Frame.html" target="MainFrame">获奖情况</a></td>
                                                </tr>

                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/AppointInformation/Frame.html" target="MainFrame">预约信息</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="bases/News/Frame.html" target="MainFrame">查看新闻公告</a></td>
                                </tr>
                               <%-- <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员日常考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员年度考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员结业考核</a></td>
                                </tr>--%>
                             </table>
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1" id="menuTitle71" onclick="showsubmenu(71,'05')">统计分析</td>
                </tr>
                <tr>
                    <td id="submenu71" class="auto-style2" style="border-bottom: 2px solid #84bf92;">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_71"></td>
                                </tr>

                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">科室情况</td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">培训专业</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">派出单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">协同单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">身份类型</td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">参训时间</td>
                                </tr>
                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">日常考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">出科考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">年度考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">结业考核</td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>
                           


                <%--<tr>
                    <td class="auto-style1" id="menuTitle41" onclick="showsubmenu(41,'05')">考试考核</td>
                </tr>
                <tr>
                    <td id="submenu41" class="auto-style2">
                        <div class="sec_menu1" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_41"></td>
                                </tr>
                               <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员日常考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="teachers/OutDeptExamInformation/Frame.html" target="MainFrame">学员出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员年度考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员结业考核</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>--%>

                <tr>
                    <td class="auto-style1" id="menuTitle5" onclick="showsubmenu(5,'05')">管理员 </td>
                </tr>
                <tr>
                    <td id="submenu5" class="auto-style2">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_5"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/StudentsBasicInformation/Frame.html" target="MainFrame">学员基本信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/StudentsRotaryInformation/Frame.html" target="MainFrame">学员轮转信息</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/OutDeptExamInformation/Frame.html" target="MainFrame">学员出科成绩</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/StudentsAttendanceManagement/Frame.html" target="MainFrame">学员考勤管理</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle501" onclick="showsubmenu1(501,'05')"><span style="color: #84bf92">&middot;</span>学员轮转记录</td>
                                </tr>
                                <tr>
                                    <td id="submenu501" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_501"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsDeptFeeling/Frame.html" target="MainFrame">入科感想</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsDiseaseRegister/Frame.html" target="MainFrame">病种登记</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsSkillRequirement/Frame.html" target="MainFrame">技能要求</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsSurgeryRecords/Frame.html" target="MainFrame">手术记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsBedManagement/Frame.html" target="MainFrame">床位管理</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsRescuePatientRecords/Frame.html" target="MainFrame">抢救病人记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsTrainingTeachingActivities/Frame.html" target="MainFrame">培训教学活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsWriteMedicalRecords/Frame.html" target="MainFrame">书写病历</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsOutpatientEmergency/Frame.html" target="MainFrame">门/急诊诊治记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsStudyAndReading/Frame.html" target="MainFrame">学习和阅读</a></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/StudentsBigMedicalRecords/Frame.html" target="MainFrame">学员大病历</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle502" onclick="showsubmenu1(502,'05')"><span style="color: #84bf92">&middot;</span>学员其他项目</td>
                                </tr>
                                <tr>
                                    <td id="submenu502" class="auto-style2" style="display: block">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_502"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsJoinTeachingRecords/Frame.html" target="MainFrame">参加教学记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsJoinResearchRecords/Frame.html" target="MainFrame">参加科研记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsJoinStudyActivities/Frame.html" target="MainFrame">参加学术活动</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsPublishArticalRecords/Frame.html" target="MainFrame">发表文章记录</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsMedicalError/Frame.html" target="MainFrame">医疗差错事故</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/StudentsReceiveHonour/Frame.html" target="MainFrame">获奖情况</a></td>
                                                </tr>

                                            </table>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/AdviceFeedback/Frame.html" target="MainFrame">查看学员意见</a></td>
                                </tr>
                                <tr>

                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/AppointInformation/Frame.html" target="MainFrame">查看预约信息</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;" class="menu_show1" id="menuTitle503" onclick="showsubmenu1(503,'05')"><span style="color: #84bf92">&middot;</span>轮转排班</td>
                                </tr>
                                <tr>
                                    <td id="submenu503" class="auto-style2" style="display: none">
                                        <div style="width: 122px">
                                            <table cellspacing="0" cellpadding="0" style="width: 135px">
                                                <tr>
                                                    <td style="height: 4px;"></td>
                                                </tr>
                                                <tr>
                                                    <td id="sub_503"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/DeptManagement/Frame.html" target="MainFrame">轮转科室管理</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/DistributeTeachers/Frame.html" target="MainFrame">指导医师分配</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/RotarySchedule/Frame.html" target="MainFrame">学员轮转分配</a></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">&nbsp<span style="color: #84bf92">&middot;</span><a href="managers/ViewSchedule/Frame.html" target="MainFrame">查看轮转排班</a></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/ReleaseNews/Frame.html" target="MainFrame">发布新闻公告</a></td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/LoginCheck/Frame.html" target="MainFrame">账号管理</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/QuestionnaireInformation/Frame.html" target="MainFrame">查看问卷情况</td>
                                </tr>
                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">相关经费管理</td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/StudentsQuestionBank/Frame.html" target="MainFrame">学员题库成绩</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/RiChangExam/Frame.html" target="MainFrame">学员日常考核成绩</td>
                                </tr>
                                 <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员出科考核成绩</td>
                                </tr>--%>
                               <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="managers/NianDuExam/Frame.html" target="MainFrame">学员年度考核成绩</td>
                                </tr>
                               <%-- <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">学员结业考核成绩</td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>

                <%--<tr>
                    <td class="auto-style1" id="menuTitle51" onclick="showsubmenu(51,'05')">考试考核</td>
                </tr>
                <tr>
                    <td id="submenu51" class="auto-style2">
                        <div class="sec_menu1" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_51"></td>
                                </tr>
                               <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员日常考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员出科考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员年度考核</a></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="HealthLiteracy/Knowledge/Frame.htm" target="MainFrame">学员结业考核</a></td>
                                </tr>

                            </table>
                        </div>
                    </td>
                </tr>--%>

                <tr>
                    <td class="auto-style1" id="menuTitle7" onclick="showsubmenu(7,'05')">统计分析</td>
                </tr>
                <tr>
                    <td id="submenu7" class="auto-style2" style="border-bottom: 2px solid #84bf92;">
                        <div class="sec_menu" style="width: 142px">
                            <table cellspacing="0" cellpadding="0" width="140">
                                <tr>
                                    <td style="height: 4px;"></td>
                                </tr>
                                <tr>
                                    <td id="sub_7"></td>
                                </tr>

                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">科室情况</td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/ProfessionalBase/Frame.html" target="MainFrame">培训专业</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/SendUnit/Frame.html" target="MainFrame">派出单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/CollaborativeUnit/Frame.html" target="MainFrame">协同单位</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/IdentityType/Frame.html" target="MainFrame">身份类型</td>
                                </tr>

                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="Statics/Managers/TrainingTime/Frame.html" target="MainFrame">参训时间</td>
                                </tr>
                                <%--<tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">日常考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">出科考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">年度考核</td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;"><span style="color: #84bf92">&middot;</span><a href="a/Frame.html" target="MainFrame">结业考核</td>
                                </tr>--%>
                            </table>
                        </div>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>

