<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="teachers_NianDuExam_Manage" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>年度考核填写</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script> 
    <link href="../../css/global.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="7" class="detailHead">年度考核表
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
                                <td colspan="2" width="30%" class="myDetailTitle" style="height: 25px;">考核内容</td>
                                <td width=40%" class="myDetailTitle" style="height: 25px;">考核要求</td>
                                <td width="10%" class="myDetailTitle" style="height: 25px;">得分</td>
                               <td width="20%" class="myDetailTitle" style="height: 25px;">备注</td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" rowspan="6">临床工作能力</td>
                                <td class="myDetailContent" width="20%">1.文书书写</td>
                                <td class="myDetailContent">
                                    抽查大病历、处方、医嘱等。
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                             <tr> 
                                <td class="myDetailContent" width="20%">2.管理病人</td>
                                <td class="myDetailContent">
                                   培训大纲要求的病种和例数。
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="20%">3.体格检查</td>
                                <td class="myDetailContent">
                                   体格检查的正确性及阳性体征的发现能力等。。
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="20%">4.技术操作</td>
                                <td class="myDetailContent">
                                   培训大纲要求的病种和例数。
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="20%">5.查房</td>
                                <td class="myDetailContent">
                                   询问病情，检查病人，汇报病情及疑难问题，归纳上级医师的意见等能力。
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr> 
                                <td class="myDetailContent" width="20%">6.病例讨论</td>
                                <td class="myDetailContent">
                                   掌握病例特点，分析深入，语言表达准确精练，推理逻辑性强。
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" colspan="2">阅读专业文献能力</td> 
                                <td class="myDetailContent">
                                    结合临床工作做文献综述或提交读书报告
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" colspan="2">阅读专业文献能力</td> 
                                <td class="myDetailContent">
                                    结合临床工作做文献综述或提交读书报告
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" colspan="2">专业外语水平</td> 
                                <td class="myDetailContent">
                                    能阅读和笔译外文专业文献
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" colspan="2">工作表现和态度</td> 
                                <td class="myDetailContent">
                                    热爱本职工作，对工作认真负责，服务规范，团结同志，遵守医院和科室规章制度，服从领导
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:25px;height:20px"/>
                                </td>
                                <td class="detailContent">
                                     <input type="text" style="width:100px;height:20px"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" colspan="2">参加科室学术活动</td> 
                                <td class="myDetailContent" colspan="3">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />中
                                    <input type="radio" />差
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="myDetailContent" width="10%" colspan="2">带教能力</td> 
                                <td class="myDetailContent" colspan="3">
                                    <input type="radio" />优
                                    <input type="radio" />良
                                    <input type="radio" />中
                                    <input type="radio" />差
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
