<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Questionnaire.aspx.cs" Inherits="students_ApplicationQuestionnaire_Questionaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
</head>
<body style="background-color: #efebef">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="3" class="detailHead">学员对指导医师满意度调查反馈问卷</td>
                </tr>
                <tr>
                    <td width="100%" style="height: 25px; background-color: #e2ebfb;" colspan="3" align="center">填表说明：<span style="height: 25px; color: red;">
                 1.根据自身真实意见选择答案<a style="padding-left: 2em;"></a>2.该问卷不记名
                    </span></td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="background-color: #f1f3f5;">
                        <table>
                            <tr>
                                <td width="10%" class="detailTitle" style="height: 25px;">培训基地：<span style="color: #ff0000">*</span></td>
                                <td width="17%" class="detailContent" style="height: 25px;" align="left">
                                    <asp:Literal ID="training_base_name" runat="server"></asp:Literal>
                                    <asp:HiddenField ID="training_base_code" runat="server" />
                                </td>
                                <td width="10%" class="detailTitle" style="height: 25px;">专业基地：<span style="color: #ff0000">*</span></td>
                                <td width="12%" class="detailContent" style="height: 25px;" align="left">
                                    <asp:Literal ID="professional_base_name" runat="server">

                                    </asp:Literal><asp:HiddenField ID="professional_base_code" runat="server" />
                                </td>
                                <td width="10%" class="detailTitle" style="height: 25px;">轮转科室：<span style="color: #ff0000">*</span></td>
                                <td width="23%" class="detailContent" style="height: 25px;" align="left">
                                    <asp:Literal ID="rotary_dept_name" runat="server"></asp:Literal>
                                    <asp:HiddenField ID="rotary_dept_code" runat="server" />
                                </td>
                                <td width="10%" class="detailTitle" style="height: 25px;">指导医师：<span style="color: #ff0000">*</span></td>
                                <td width="8%" class="detailContent" style="height: 25px;" align="left">
                                    <asp:Literal ID="instructor" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td align="center">
                        <table width="100%" border="1" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                            <tr>
                                <td width="5%" style="height: 25px; background-color: #e2ebfb;" class="myDetailTitle">序号</td>
                                <td width="15%" style="height: 25px; background-color: #e2ebfb;" class="myDetailTitle">选择题目</td>
                                <td width="20%" style="height: 25px; background-color: #e2ebfb;" class="myDetailTitle">选项</td>

                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">1</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师的敬业精神：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">2</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师严谨的工作作风：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">3</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师基础知识理论水平：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">4</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师临床疑难病症处理能力：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">5</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师临床操作技能：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">6</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师与患者、同事、被带教者之间交流能力：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">7</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师对本学科进展的了解能力：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">8</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师对医疗纠纷的防范意识：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">9</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师科研能力：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">10</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师的外语运用水平：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">11</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师的带教经验：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">12</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师带教表达能力：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">13</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对指导老师的带教放手能力：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal" Font-Bold="True" CellSpacing="5" CellPadding="5" RepeatLayout="Table" Height="100%" Width="100%">
                                        <asp:ListItem Value="A">A.非常满意</asp:ListItem>
                                        <asp:ListItem Value="B">B.比较满意</asp:ListItem>
                                        <asp:ListItem Value="C">C.一般</asp:ListItem>
                                        <asp:ListItem Value="D">D.不满意</asp:ListItem>
                                        <asp:ListItem Value="E">E.不清楚</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="5%" style="height: 30px; background-color: #e2ebfb;" align="center">14</td>
                                <td width="15%" style="height: 30px; background-color: #e2ebfb;" align="left">您对我院指导老师及轮转科室的评价、建议和出科小结：</td>
                                <td width="20%" class="detailContent" style="height: 30px;" align="left">
                                    <asp:TextBox ID="advice" runat="server" TextMode="MultiLine" Width="100%" Height="300%"></asp:TextBox>
                                </td>
                            </tr>
                </tr>
                <tr>
                    <td width="5%" style="height: 30px; background-color: #e2ebfb;"></td>
                    <td width="15%" style="height: 30px; background-color: #e2ebfb;"></td>
                    <td width="20%" class="detailContent" style="height: 30px;">
                        <table>
                            <tr>
                                <td class="detailTitle" width="20%" style="height: 30px;"></td>
                                <td class="detailTitle" width="20%" style="height: 30px;">填写日期：<span style="color: #ff0000">*</span></td>
                                <td class="detailContent" width="20%" style="height: 30px;">
                                    <asp:TextBox ID="register_date" runat="server" ReadOnly="true"></asp:TextBox>
                                    <asp:HiddenField ID="writor" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="last">
                    <td colspan="3" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" Style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;" OnClick="save_Click" />
                            <a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                        </div>
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
