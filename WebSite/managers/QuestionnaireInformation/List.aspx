<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="managers_QuestionnaireInformation_List" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学员反馈问卷统计分析</title>
    <script type="text/javascript" src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.js"></script> 
    <script type="text/javascript" src="../../js/PageList/FirstLast.js"></script>
    <style type="text/css">
        .button {
            width: 200px;
            height: 20px;
            border: #002D96 1px solid;
            padding: 2px;
            filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#FFFFFF, EndColorStr=#9DBCEA);
            cursor: pointer;
            color: black;
        }

        .tbmover {
            border: #336699 1px solid;
            padding-right: 2px;
            padding-left: 2px;
            cursor: pointer;
        }

        .tbmout {
            padding-right: 3px;
            padding-left: 3px;
        }

        .style1 {
            font-size: 14px;
            font-weight: bold;
        }
    </style>
 
    <script type="text/javascript">
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
         
        $(window).load(function () {
            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("ashx/List.ashx", { "pageIndex": pi, "TrainingBaseCode": TrainingBaseCode},
              function (data) {
                  var jsonArr = eval("(" + data + ")");
                  if (jsonArr.data == null) {
                      $("#tbList tr:gt(0)").remove();
                  } else {
                      createRows(jsonArr.data, pi);
                  }
                  createPageBar($("#PageList"), pi, jsonArr.recordCount, jsonArr.pageCount);

              });
        }
        function createRows(jsonArr) {
            var tbL = $("#tbList");
            $("#tbList tr:gt(0)").remove();
            for (i = 0; i < jsonArr.length; i++) {
                var trHTML = "<tr bgcolor='#FFFFFF'>";
                trHTML += "<td colspan='6' style='height: 25px'>" + jsonArr[i].advice + "</td>";
                trHTML += "</tr>";
                tbL.append(trHTML);
            }
        }
        function createPageBar(pagelistdiv, pageindex, rowcount, pagecount) {
            //var pageListDiv = $("#PageList");
            var divHtml = "共" + rowcount + "条<a style='padding-left:1em;'></a>分" + pagecount + "页<a style='padding-left:1em;'></a>" +
                "第" + pageindex + "页<a style='padding-left:1em;'></a>跳转到<input type='Text' id='index' name='index' style='width:25px;height:20px;'/>" +
                "<input type='Button' id='go' value='GO' style='width:25px;height:20px;' onclick='Go(" + pagecount + ")'/><a style='padding-left:1em;'></a>" +
                "每页5条<a style='padding-left:2em;'></a>" +
                "<a href='javascript:loadPageList(1)' style='color:#000000'>首页</a><a style='padding-left:1em;'>" +
                "<a href='javascript:loadPageList(" + prevPage(pageindex) + ")' style='color:#000000'>上一页<a style='padding-left:1em;'>" +
            "<a href='javascript:loadPageList(" + lastPage(pageindex, pagecount) + ")' style='color:#000000'>下一页<a style='padding-left:1em;'></a>" +
            "<a href='javascript:loadPageList(" + pagecount + ")' style='color:#000000'>尾页</a>";
            pagelistdiv.html(divHtml);
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div align="center">
                <br />
                <span class="style1">表1 学员对指导医师满意度调查反馈表</span><br />
                <br />
            </div>
            <table width="90%" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="margin: 0 auto">
                <tr align="center">
                    <td width="15%" style="height: 25px" align="center"><strong>调查项目</strong></td>
                    <td width="10%" style="height: 25px" align="center"><strong>A.非常满意的比例（人数）</strong></td>
                    <td width="10%" style="height: 25px" align="center"><strong>B.比较满意的比例（人数）</strong></td>
                    <td width="10%" style="height: 25px" align="center"><strong>C.一般的比例（人数）</strong></td>
                    <td width="10%" style="height: 25px" align="center"><strong>D.不满意的比例（人数）</strong></td>
                    <td width="10%" style="height: 25px" align="center"><strong>E.不清楚的比例（人数）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">敬业精神</td>
                    <td style="height: 25px"><strong><%=((double)one_a/sum).ToString("0.00%")%>（<%=one_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)one_b/sum).ToString("0.00%")%>（<%=one_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)one_c/sum).ToString("0.00%")%>（<%=one_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)one_d/sum).ToString("0.00%")%>（<%=one_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)one_e/sum).ToString("0.00%")%>（<%=one_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">工作作风</td>
                    <td style="height: 25px"><strong><%=((double)two_a/sum).ToString("0.00%")%>（<%=two_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)two_b/sum).ToString("0.00%")%>（<%=two_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)two_c/sum).ToString("0.00%")%>（<%=two_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)two_d/sum).ToString("0.00%")%>（<%=two_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)two_e/sum).ToString("0.00%")%>（<%=two_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">基础知识理论水平</td>
                    <td style="height: 25px"><strong><%=((double)three_a/sum).ToString("0.00%")%>（<%=three_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)three_b/sum).ToString("0.00%")%>（<%=three_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)three_c/sum).ToString("0.00%")%>（<%=three_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)three_d/sum).ToString("0.00%")%>（<%=three_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)three_e/sum).ToString("0.00%")%>（<%=three_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">疑难病症处理能力</td>
                   <td style="height: 25px"><strong><%=((double)four_a/sum).ToString("0.00%")%>（<%=four_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)four_b/sum).ToString("0.00%")%>（<%=four_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)four_c/sum).ToString("0.00%")%>（<%=four_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)four_d/sum).ToString("0.00%")%>（<%=four_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)four_e/sum).ToString("0.00%")%>（<%=four_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">临床操作技能</td>
                    <td style="height: 25px"><strong><%=((double)five_a/sum).ToString("0.00%")%>（<%=five_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)five_b/sum).ToString("0.00%")%>（<%=five_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)five_c/sum).ToString("0.00%")%>（<%=five_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)five_d/sum).ToString("0.00%")%>（<%=five_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)five_e/sum).ToString("0.00%")%>（<%=five_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">与患者、同事等交流能力</td>
                    <td style="height: 25px"><strong><%=((double)six_a/sum).ToString("0.00%")%>（<%=six_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)six_b/sum).ToString("0.00%")%>（<%=six_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)six_c/sum).ToString("0.00%")%>（<%=six_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)six_d/sum).ToString("0.00%")%>（<%=six_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)six_e/sum).ToString("0.00%")%>（<%=six_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">本学科进展了解能力</td>
                   <td style="height: 25px"><strong><%=((double)seven_a/sum).ToString("0.00%")%>（<%=seven_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)seven_b/sum).ToString("0.00%")%>（<%=seven_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)seven_c/sum).ToString("0.00%")%>（<%=seven_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)seven_d/sum).ToString("0.00%")%>（<%=seven_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)seven_e/sum).ToString("0.00%")%>（<%=seven_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">医疗纠纷防范意识</td>
                    <td style="height: 25px"><strong><%=((double)eight_a/sum).ToString("0.00%")%>（<%=eight_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eight_b/sum).ToString("0.00%")%>（<%=eight_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eight_c/sum).ToString("0.00%")%>（<%=eight_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eight_d/sum).ToString("0.00%")%>（<%=eight_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eight_e/sum).ToString("0.00%")%>（<%=eight_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">科研能力</td>
                    <td style="height: 25px"><strong><%=((double)nine_a/sum).ToString("0.00%")%>（<%=nine_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)nine_b/sum).ToString("0.00%")%>（<%=nine_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)nine_c/sum).ToString("0.00%")%>（<%=nine_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)nine_d/sum).ToString("0.00%")%>（<%=nine_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)nine_e/sum).ToString("0.00%")%>（<%=nine_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">外语运用水平</td>
                   <td style="height: 25px"><strong><%=((double)ten_a/sum).ToString("0.00%")%>（<%=ten_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)ten_b/sum).ToString("0.00%")%>（<%=ten_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)ten_c/sum).ToString("0.00%")%>（<%=ten_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)ten_d/sum).ToString("0.00%")%>（<%=ten_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)ten_e/sum).ToString("0.00%")%>（<%=ten_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">带教经验</td>
                    <td style="height: 25px"><strong><%=((double)eleven_a/sum).ToString("0.00%")%>（<%=eleven_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eleven_b/sum).ToString("0.00%")%>（<%=eleven_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eleven_c/sum).ToString("0.00%")%>（<%=eleven_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eleven_d/sum).ToString("0.00%")%>（<%=eleven_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)eleven_e/sum).ToString("0.00%")%>（<%=eleven_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">表达能力</td>
                   <td style="height: 25px"><strong><%=((double)twelve_a/sum).ToString("0.00%")%>（<%=twelve_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)twelve_b/sum).ToString("0.00%")%>（<%=twelve_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)twelve_c/sum).ToString("0.00%")%>（<%=twelve_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)twelve_d/sum).ToString("0.00%")%>（<%=twelve_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)twelve_e/sum).ToString("0.00%")%>（<%=twelve_e%>）</strong></td>
                </tr>
                <tr align="center" bgcolor="#FFFFFF">
                    <td style="height: 25px">放手能力</td>
                   <td style="height: 25px"><strong><%=((double)thirteen_a/sum).ToString("0.00%")%>（<%=thirteen_a%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)thirteen_b/sum).ToString("0.00%")%>（<%=thirteen_b%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)thirteen_c/sum).ToString("0.00%")%>（<%=thirteen_c%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)thirteen_d/sum).ToString("0.00%")%>（<%=thirteen_d%>）</strong></td>
                    <td style="height: 25px"><strong><%=((double)thirteen_e/sum).ToString("0.00%")%>（<%=thirteen_e%>）</strong></td>

                </tr>
                </table>
             <table width="90%" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" id="tbList" style="margin: 0 auto">
                <tr align="center" id="tr0">
                    <td colspan="6" style="height: 25px" align="center"><strong>学员对我院指导老师及轮转科室的评价、建议和出科小结</strong></td>
                </tr>
                
            </table>

            <div id="PageList" style="text-align:center;vertical-align:top; margin-top:10px; line-height:20px;">
            </div>
             
        </div>


    </form>

</body>

</html>
