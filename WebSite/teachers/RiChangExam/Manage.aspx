<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="teachers_RiChangExam_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>日常考核填写</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script> 
    <link href="../../css/global.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="7" class="detailHead">日常考核表
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
                                <td colspan="2" width="50%" class="myDetailTitle" style="height: 25px;">考核内容</td>
                                <td width=30%" class="myDetailTitle" style="height: 25px;">评分等级</td>
                                <td width="20%" class="myDetailTitle" style="height: 25px;">成绩</td>
                               
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%">考勤</td>
                                <td class="myDetailContent" width="40%">组织纪律、有无旷工、迟到、早退、脱岗</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td>
                                
                            </tr>
                             <tr>
                                <td class="myDetailContent" width="10%" rowspan="4">医德医风</td>
                                <td class="myDetailContent" width="40%">服务态度、爱护伤病员观念</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">工作责任心、无差错</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">医疗作风、廉洁行医</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">团结协作、遵守制度</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                             <tr>
                                <td class="myDetailContent" width="10%" rowspan="2">指标完成情况</td>
                                <td class="myDetailContent" width="40%">病种、例数、手术治疗数量（门诊）</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">管理病人数（病房）</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" rowspan="3">基本技能</td>
                                <td class="myDetailContent" width="40%">医疗文件书写质量（门诊处方、各类检查申请单请、病历书写）</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">体格检查</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">手术或技能操作</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" rowspan="4">诊治能力</td>
                                <td class="myDetailContent" width="40%">常见病诊断和鉴别</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">急、危重病人的处置或抢救</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">结合病情分析、检查、报告</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">综合处置能力</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                             <tr>
                                <td class="myDetailContent" width="10%" rowspan="2">临床思维能力</td>
                                <td class="myDetailContent" width="40%">归纳能力(掌握病例特点、分析深入、语言表达精练、推理有逻辑性、思维正确)</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="40%">分析能力(理论和实践的结合)</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%">教学</td>
                                <td class="myDetailContent" width="40%">带教能力</td>
                                <td class="myDetailContent">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />差
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>
                             <tr>
                                <td class="myDetailContent" width="10%">医疗差错事故</td>
                                <td class="myDetailContent" width="40%">
                                    <input type="radio" />有
                                    <input type="radio" />无
                                    
                                </td>
                                <td class="myDetailContent">
                                    指定阅读的书籍
                                </td>
                                <td class="detailContent">
                                     <input type="radio" />完成
                                    <input type="radio" />未完成
                                </td> 
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="50%" colspan="2">考核总成绩（以上考核项目中有
一项不合格视为本次轮科不合格）
</td>
                                <td class="detailContent" colspan="2">
                                     <input type="radio" />合格
                                    <input type="radio" />不合格
                                </td> 
                            </tr>

 
                            <tr>
                                <td colspan="4" class="myDetailContent" style="text-align:right">指导老师：
                                    <asp:TextBox ID="teacher" runat="server"
                                    ReadOnly="True"></asp:TextBox>
                                    日期：<asp:TextBox ID="teacher_time" runat="server"></asp:TextBox></td>

                            </tr>
                             
                            
                        </table>
                    </td>
                </tr>
                <tr id="last">
                                <td colspan="3" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                                    <div style="text-align: center; margin-top: 8px;">
                                        <asp:Button ID="save" runat="server" Text="" Style="cursor: pointer; background-image: url(../../images/tijiao.jpg); border: none; height: 21px; width: 88px;"/>
                                         
                                    </div>
                                </td>
                            </tr>
            </table>



        </div>
    </form>
</body>
</html>
