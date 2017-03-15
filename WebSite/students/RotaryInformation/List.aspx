<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="students_RotaryInformation_List" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>轮转信息</title>
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
        var name = "<%=students_name%>";
        var tbcode = "<%=training_base_code%>";
        var rdept = "<%=rotary_dept%>";
        var instru = "<%=instructor%>";
        var rbtime = "<%=rotary_begin_time%>";
        var retime = "<%=rotary_end_time%>";
        $(window).load(function () {

            loadPageList(1);
        });

           function loadPageList(pi) {
               $.post("ashx/List.ashx?do=l", {
                   "pi": pi, "name": name, "training_base_code": tbcode, "rotary_dept": rdept,
                   "instructor": instru, "rotary_begin_time": rbtime, "rotary_end_time": retime
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
                var trHTML = "<tr class='listTableContentRow'>";
                trHTML += "<td>" + jsonArr[i].real_name + "</td>";
                trHTML += "<td>" + jsonArr[i].training_base_name + "</td>";
                trHTML += "<td>" + jsonArr[i].professional_base_name + "</td>";
                trHTML += "<td>" + jsonArr[i].rotary_dept_name + "</td>";
                trHTML += "<td>" + jsonArr[i].rotary_begin_time + "</td>";
                trHTML += "<td>" + jsonArr[i].rotary_end_time + "</td>";
                trHTML += "<td>" + jsonArr[i].instructor + "</td>";
                trHTML += "<td>" + jsonArr[i].register_date + "</td>";
                trHTML += "<td><font color='red'>" + jsonArr[i].outdept_status + "</font></td>";
                trHTML += "<td><font color='red'>" + jsonArr[i].questionnaire_status + "</font></td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].id + "',600,200);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].id + "&pi="+pi+"',600,250);\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
                trHTML += "<td><a onclick=\"application('" + jsonArr[i].id + "');\" href='#'><img alt='申请出科考试' src='../../images/imgs/icon_rotary.png'/></a></td>";
                trHTML += "<td><a onclick=\"questionnaire('" + jsonArr[i].id + "','" + jsonArr[i].questionnaire_status + "','" + pi + "');\" href='#'><img alt='填写问卷' src='../../images/imgs/icon_add.gif'/></a></td>";

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
        function application(id) {
            $.post("ashx/OutDeptApplication.ashx", { "id": id }, function (data) {
                alert(data);

            });

        }
        function questionnaire(tag,status,pi) {
            if (status == "未填写") {
                OpenTopWindow("Questionnaire.aspx?id=" + tag + "&pi="+pi+"", 900, 650);
                return;
            }
            if (status == "已填写")
            {
                alert("该问卷已填写，请勿重复");
                return;
            }
            
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />轮转信息查询结果                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>培训基地</td>  
                <td>专业基地</td> 
                <td>轮转科室</td>                                           
                <td>轮转开始时间</td> 
                <td>轮转结束时间</td>
                <td>指导医师</td>
                <td>登记时间</td>
                <td>状态</td>
                <td>问卷</td>
                <td>查看</td>
                <td>修改</td>
                <td>申请</td>
                <td>问卷</td>
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
      
    </form>
   
</body>
    
</html>
