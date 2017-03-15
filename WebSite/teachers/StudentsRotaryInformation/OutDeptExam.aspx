<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutDeptExam.aspx.cs" Inherits="teachers_OutDeptExam_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>出科考核填写</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/jqueryAutocomplete/jquery.autocomplete.js"></script>
    <link href="../../js/jqueryAutocomplete/jquery.autocomplete.css" rel="stylesheet" />

    <script type="text/javascript">

        $(function () {
            var reg = /^[1-9]\d*|0$/;
           
            $("#kqqk").blur(function () {
                if ($("#kqqk").val() == "" || !reg.test($("#kqqk").val()) || parseFloat($("#kqqk").val()) > 10) {
                    alert("考勤情况考核项目得分数值不合法");
                    $("#kqqk").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val()==""?0:$("#blsx").val()) + parseFloat($("#clbrnl").val()==""?0:$("#clbrnl").val()) + parseFloat($("#sjcznl").val()==""?0:$("#sjcznl").val()) + parseFloat($("#czjn").val()==""?0:$("#czjn").val()) + parseFloat($("#zdsp").val()==""?0:$("#zdsp").val()) + parseFloat($("#djnl").val()==""?0:$("#djnl").val()));
                    
                }
                   
            });

            $("#gztd").blur(function () {
                if ($("#gztd").val() == "" || !reg.test($("#gztd").val()) || parseFloat($("#gztd").val()) > 10) {
                    alert("工作态度考核项目得分数值不合法");
                    $("#gztd").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#ydyf").blur(function () {
                if ($("#ydyf").val() == "" || !reg.test($("#ydyf").val()) || parseFloat($("#ydyf").val()) > 5) {
                    alert("医德医风考核项目得分数值不合法");
                    $("#ydyf").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#llsp").blur(function () {
                if ($("#llsp").val() == "" || !reg.test($("#llsp").val()) || parseFloat($("#llsp").val()) > 15) {
                    alert("理论水平考核项目得分数值不合法");
                    $("#llsp").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#zdzx").blur(function () {
                if ($("#zdzx").val() == "" || !reg.test($("#zdzx").val()) || parseFloat($("#zdzx").val()) > 15) {
                    alert("制度执行考核项目得分数值不合法");
                    $("#zdzx").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#blsx").blur(function () {
                if ($("#blsx").val() == "" || !reg.test($("#blsx").val()) || parseFloat($("#blsx").val()) > 15) {
                    alert("病历书写考核项目得分数值不合法");
                    $("#blsx").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#clbrnl").blur(function () {
                if ($("#clbrnl").val() == "" || !reg.test($("#clbrnl").val()) || parseFloat($("#clbrnl").val()) > 15) {
                    alert("处理病人能力考核项目得分数值不合法");
                    $("#clbrnl").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            
            $("#sjcznl").blur(function () {
                if ($("#sjcznl").val() == "" || !reg.test($("#sjcznl").val()) || parseFloat($("#sjcznl").val()) > 10) {
                    alert("实际操作能力考核项目得分数值不合法");
                    $("#sjcznl").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#czjn").blur(function () {
                if ($("#czjn").val() == "" || !reg.test($("#czjn").val()) || parseFloat($("#czjn").val()) > 15) {
                    alert("操作技能考核项目得分数值不合法");
                    $("#czjn").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#zdsp").blur(function () {
                if ($("#zdsp").val() == "" || !reg.test($("#zdsp").val()) || parseFloat($("#zdsp").val()) > 25) {
                    alert("诊断水平考核项目得分数值不合法");
                    $("#zdsp").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });
            $("#djnl").blur(function () {
                if ($("#djnl").val() == "" || !reg.test($("#djnl").val()) || parseFloat($("#djnl").val()) > 5) {
                    alert("带教能力考核项目得分数值不合法");
                    $("#djnl").val("");
                    return;
                } else {
                    $("#totalscore").val(parseFloat($("#kqqk").val() == "" ? 0 : $("#kqqk").val()) + parseFloat($("#gztd").val() == "" ? 0 : $("#gztd").val()) + parseFloat($("#ydyf").val() == "" ? 0 : $("#ydyf").val()) + parseFloat($("#llsp").val() == "" ? 0 : $("#llsp").val()) + parseFloat($("#zdzx").val() == "" ? 0 : $("#zdzx").val()) + parseFloat($("#blsx").val() == "" ? 0 : $("#blsx").val()) + parseFloat($("#clbrnl").val() == "" ? 0 : $("#clbrnl").val()) + parseFloat($("#sjcznl").val() == "" ? 0 : $("#sjcznl").val()) + parseFloat($("#czjn").val() == "" ? 0 : $("#czjn").val()) + parseFloat($("#zdsp").val() == "" ? 0 : $("#zdsp").val()) + parseFloat($("#djnl").val() == "" ? 0 : $("#djnl").val()));
                }
            });

          });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="7" class="detailHead">出科考核表
                    </td>
                </tr>
                <tr>
                    <td colspan="">
                        <table>
                            <tr>
                                <td width="8%" class="detailTitle" style="height: 25px;">姓名：<span style="color: #ff0000">*</span></td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="students_real_name" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                    <asp:HiddenField ID="students_name" runat="server" />
                                    <asp:HiddenField ID="training_base_code" runat="server" />
                                    <asp:HiddenField ID="training_base_name" runat="server" />
                                </span>
                                </td>
                                <td width="8%" class="detailTitle" style="height: 25px;">性别：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="sex" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                </span></td>
                                <td width="8%" class="detailTitle" style="height: 25px;">学历：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="high_education" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                </span></td>
                                <td width="8%" class="detailTitle" style="height: 25px;">毕业时间：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="high_education_time" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                </span></td>
                                <td width="8%" class="detailTitle" style="height: 25px;">专业基地：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="professional_base_name" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                    <asp:HiddenField ID="professional_base_code" runat="server" />
                                </span></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td colspan="">
                        <table>
                            <tr>
                                <td width="8%" class="detailTitle" style="height: 25px;">轮转科室：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="rotary_dept_name" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                    <asp:HiddenField ID="rotary_dept_code" runat="server" />
                                </span></td>
                                <td width="10%" class="detailTitle" style="height: 25px;">轮转开始时间：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="rotary_begin_time" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                </span></td>
                                <td width="10%" class="detailTitle" style="height: 25px;">轮转结束时间：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="rotary_end_time" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                </span></td>
                                <td width="10%" class="detailTitle" style="height: 25px;">指导老师：</td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="instructor" runat="server" Text="" ReadOnly="true" Width="100px"></asp:TextBox>
                                    <asp:HiddenField ID="instructor_tag" runat="server" />
                                </span></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="100%" border="1" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                            <tr>
                                <td colspan="4" width="30%" class="myDetailTitle" style="height: 25px;">考核项目</td>
                                <td width="10%" class="myDetailTitle" style="height: 25px;">满分</td>
                                <td width="55%" class="myDetailTitle" style="height: 25px;">考核依据</td>
                                <td  class="myDetailTitle" style="height: 25px;">得分</td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">1</td>
                                <td colspan="3" class="myDetailContent">考勤情况</td>
                                <td class="myDetailContent" width="5%">10</td>
                                <td class="detailContent">旷工一天扣5分；不参加节假日查房及跟班每次扣3分；迟到早退每次扣2分；每请假1天扣1分，超过一周不得分</td>
                                <td>
                                    <asp:TextBox ID="kqqk" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">2</td>
                                <td colspan="3" class="myDetailContent">工作态度</td>
                                <td class="myDetailContent" width="5%">10</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="gztd" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">3</td>
                                <td colspan="3" class="myDetailContent">医德医风</td>
                                <td class="myDetailContent" width="5%">5</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="ydyf" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">4</td>
                                <td colspan="3" class="myDetailContent">理论水平</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">结合平时查房提问及出科理论考核</td>
                                <td>
                                    <asp:TextBox ID="llsp" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">5</td>
                                <td colspan="3" class="myDetailContent">制度执行</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="zdzx" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="5" class="myDetailContent" width="5%">6</td>
                                <td rowspan="5" class="myDetailContent" width="5%">基本技能</td>
                                <td rowspan="3" class="myDetailContent" width="5%">临床科室</td>
                                <td class="myDetailContent">病历书写</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">丙级病历不得分；每份乙级病历扣5分</td>
                                <td>
                                    <asp:TextBox ID="blsx" runat="server" Height="20px" Width="50px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent">处理病人能力</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="clbrnl" runat="server" Height="20px" Width="50px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent">实际操作能力</td>
                                <td class="myDetailContent" width="5%">10</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="sjcznl" runat="server" Height="20px" Width="50px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td rowspan="2" class="myDetailContent" width="5%">医技科室</td>
                                <td class="myDetailContent">操作技能</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="czjn" runat="server" Height="20px" Width="50px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent">诊断水平</td>
                                <td class="myDetailContent" width="5%">25</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="zdsp" runat="server" Height="20px" Width="50px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">7</td>
                                <td colspan="3" class="myDetailContent">带教能力</td>
                                <td class="myDetailContent" width="5%">5</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="djnl" runat="server" Height="20px" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="myDetailContent">合计得分（合计得分低于80分者视为不合格，顺延一期）</td>
                                <td>
                                    <asp:TextBox ID="totalscore" runat="server" Height="20px" onfocus="this.blur()" Width="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" class="myDetailContent">指导老师：<asp:TextBox ID="teacher" runat="server"
                                    ReadOnly="True"></asp:TextBox><a style="padding-left: 150px"></a>
                                    日期：<asp:TextBox
                                        ID="teacher_time" runat="server" ></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td colspan="7" style="text-align:left;" class="myDetailContent">
                                    <asp:RadioButtonList ID="ispass" runat="server">
                                        <asp:ListItem Value="同意出科" Selected="True">通过考核，同意出科</asp:ListItem>
                                        <asp:ListItem Value="顺延一期">考核未通过，建议在本学科顺延一期</asp:ListItem>
                                    </asp:RadioButtonList>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" class="myDetailContent" style="border: 0px;">科主任：<asp:TextBox ID="kzr" runat="server"></asp:TextBox><a style="padding-left: 150px"></a>
                                    日期：<asp:TextBox ID="kzr_time" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
                <tr id="last">
                                <td colspan="3" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                                    <div style="text-align: center; margin-top: 8px;">
                                        <asp:Button ID="save" runat="server" Text="" Style="cursor: pointer; background-image: url(../../images/tijiao.jpg); border: none; height: 21px; width: 88px;" OnClick="save_Click"/>
                                        <%--<a style="padding-left: 2em"></a>
                                        <input type="button" style="cursor: pointer; background-image: url(../../images/chongzhi.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />--%>
                                    </div>
                                </td>
                            </tr>
            </table>



        </div>
    </form>
</body>
</html>
