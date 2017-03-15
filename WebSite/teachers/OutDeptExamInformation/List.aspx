<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="teachers_OutDeptExam_List" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员基本信息列表</title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
    <style type="text/css">
    .button
    {
	    width:200px; height:20px; border: #002D96 1px solid; padding: 2px; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#FFFFFF, EndColorStr=#9DBCEA); cursor: pointer; color: black;
    }
    .tbmover{
		border: #336699 1px solid;
		padding-right: 2px; 
		padding-left: 2px; 
		cursor: pointer;
	}
	.tbmout{
		padding-right: 3px; padding-left: 3px;
		
	}
    </style>  
<script type="text/javascript">
    var teachers_name = "<%=teachers_name%>";
    var teachers_real_name = "<%=teachers_real_name%>";
    var training_base_code = "<%=training_base_code%>";
    var dept_code = "<%=dept_code%>";


    var students_name = "<%=name%>";
    var rotary_begin_time = "<%=rotary_begin_time%>";
    var rotary_end_time = "<%=rotary_end_time%>";
    var total_score = "<%=total_score%>";
    var is_pass = "<%=is_pass%>";
    $(window).load(function () {

        loadPageList(1);
    });

    function loadPageList(pi) {

        $.post("ashx/List.ashx?do=l", {
            "pi": pi, "tName": teachers_name, "trName": teachers_real_name, "tbCode": training_base_code, "dCode": dept_code,
            "students_name":students_name,"rotary_begin_time":rotary_begin_time,"rotary_end_time":rotary_end_time,"total_score":total_score,"is_pass":is_pass
        },
          function (data) {
              var jsonArr = eval("(" + data + ")");
              if (jsonArr.data == null) {
                  $("#tbList tr:gt(0)").remove();
              } else {
                  createRows(jsonArr.data, pi);
              }
              createPageBar($("#PageList"), pi, jsonArr.rowCount, jsonArr.pageCount);
          });
    }

    function createRows(jsonArr,pi) {
        var tbL = $("#tbList");
        $("#tbList tr:gt(0)").remove();
        for (i = 0; i < jsonArr.length; i++) {
            var jbjn = parseFloat(jsonArr[i].blsx) + parseFloat(jsonArr[i].clbrnl) + parseFloat(jsonArr[i].sjcznl) + parseFloat(jsonArr[i].czjn) + parseFloat(jsonArr[i].zdsp);
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].students_real_name + "</td>";
            trHTML += "<td>" + jsonArr[i].rotary_begin_time + "</td>";
            trHTML += "<td>" + jsonArr[i].rotary_end_time + "</td>";
            trHTML += "<td>" + jsonArr[i].kqqk + "</td>";
            trHTML += "<td>" + jsonArr[i].gztd + "</td>";
            trHTML += "<td>" + jsonArr[i].ydyf + "</td>";
            trHTML += "<td>" + jsonArr[i].llsp + "</td>";
            trHTML += "<td>" + jsonArr[i].zdzx + "</td>";
            trHTML += "<td>" + jbjn + "</td>";
            trHTML += "<td>" + jsonArr[i].djnl + "</td>";
            trHTML += "<td>" + jsonArr[i].total_score + "</td>";
            trHTML += "<td><font color='red'>" + jsonArr[i].is_pass + "</font></td>";
            trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].id + "',950,580);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
            trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].id + "&pi="+pi+"',950,605);\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
            trHTML += "</tr>";
            tbL.append(trHTML);


        }

        $("#tbList tr:gt(0)").mouseover(function () {
            $(this).removeClass("listTableContentRow");
            $(this).addClass("listTableContentRowMouseOver");
        });

        $("#tbList tr:gt(0)").mouseout(function () {
            $(this).removeClass("listTableContentRowMouseOver");
            $(this).addClass("listTableContentRow");
        });

    }


    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />学员出科考核结果查询                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>轮转开始时间</td>  
                <td>轮转结束时间</td> 
                <td>考勤情况</td>                                           
                <td>工作态度</td> 
                <td>医德医风</td>
                <td>理论水平</td>
                <td>制度执行</td>
                <td>基本技能</td>
                <td>带教能力</td>
                <td>合计得分</td>
                <td>出科情况</td>
                <td>查看</td>
                <td>修改</td>
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
      <%--<asp:Literal ID="xianshi" runat="server"></asp:Literal>--%>
    </form>
   
</body>
    
</html>


