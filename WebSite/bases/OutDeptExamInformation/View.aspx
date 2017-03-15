<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="bases_OutDeptExamInformation_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>出科考核填写</title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
   
   
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
                                <td width="50%" class="myDetailTitle" style="height: 25px;">考核依据</td>
                                <td width="10%" class="myDetailTitle" style="height: 25px;">得分</td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">1</td>
                                <td colspan="3" class="myDetailContent">考勤情况</td>
                                <td class="myDetailContent" width="5%">10</td>
                                <td class="detailContent">旷工一天扣5分；不参加节假日查房及跟班每次扣3分；迟到早退每次扣2分；每请假1天扣1分，超过一周不得分</td>
                                <td>
                                    <asp:TextBox ID="kqqk" runat="server" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">2</td>
                                <td colspan="3" class="myDetailContent">工作态度</td>
                                <td class="myDetailContent" width="5%">10</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="gztd" runat="server" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">3</td>
                                <td colspan="3" class="myDetailContent">医德医风</td>
                                <td class="myDetailContent" width="5%">5</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="ydyf" runat="server" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">4</td>
                                <td colspan="3" class="myDetailContent">理论水平</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">结合平时查房提问及出科理论考核</td>
                                <td>
                                    <asp:TextBox ID="llsp" runat="server" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">5</td>
                                <td colspan="3" class="myDetailContent">制度执行</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="zdzx" runat="server" Height="20px"></asp:TextBox>
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
                                    <asp:TextBox ID="blsx" runat="server" Height="20px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent">处理病人能力</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="clbrnl" runat="server" Height="20px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent">实际操作能力</td>
                                <td class="myDetailContent" width="5%">10</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="sjcznl" runat="server" Height="20px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td rowspan="2" class="myDetailContent" width="5%">医技科室</td>
                                <td class="myDetailContent">操作技能</td>
                                <td class="myDetailContent" width="5%">15</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="czjn" runat="server" Height="20px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent">诊断水平</td>
                                <td class="myDetailContent" width="5%">25</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="zdsp" runat="server" Height="20px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="5%">7</td>
                                <td colspan="3" class="myDetailContent">带教能力</td>
                                <td class="myDetailContent" width="5%">5</td>
                                <td class="detailContent">指导老师和科室同事综合评价</td>
                                <td>
                                    <asp:TextBox ID="djnl" runat="server" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="myDetailContent">合计得分（合计得分低于80分者视为不合格，顺延一期）</td>
                                <td>
                                    <asp:TextBox ID="totalscore" runat="server" Height="20px" onfocus="this.blur()"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" class="myDetailContent">指导老师：<asp:TextBox ID="teacher" runat="server"
                                    ReadOnly="True"></asp:TextBox><a style="padding-left: 150px"></a>
                                    日期：<asp:TextBox
                                        ID="teacher_time" runat="server"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td colspan="7" style="text-align: left;" class="myDetailContent">
                                    <asp:RadioButtonList ID="ispass" runat="server">
                                        <asp:ListItem Value="同意出科">通过考核，同意出科</asp:ListItem>
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
                
            </table>



        </div>
    </form>
</body>
</html>


