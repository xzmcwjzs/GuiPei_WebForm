<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="teachers_StudentsBasicInformation_List" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员轮转信息列表</title>
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
    var training_base_code = "<%=training_base_code%>";
    var dept_code = "<%=dept_code%>";
    var teachers_name = "<%=teachers_name%>";
    var session="<%=Session["loginModel"]%>";
    var name = "<%=name%>";
    var sex = "<%=sex%>";
    var high_education = "<%=high_education%>";
    var identity_type = "<%=identity_type%>";
    var send_unit = "<%=send_unit%>";
    var collaborative_unit = "<%=collaborative_unit%>";
    var training_time = "<%=training_time%>";
    var plan_training_time = "<%=plan_training_time%>";
    var rotary_begin_time = "<%=rotary_begin_time%>";
    var rotary_end_time = "<%=rotary_end_time%>";
    var outdept_status = "<%=outdept_status%>";

    $(window).load(function () {

        loadPageList(1);
    });

    function loadPageList(pi) {
        $.post("ashx/List.ashx?do=l", {
            "pi": pi, "tbcode": training_base_code, "dcode": dept_code, "teachers_name": teachers_name,
            "name": name, "sex": sex, "high_education": high_education,
            "identity_type": identity_type, "send_unit": send_unit, "collaborative_unit": collaborative_unit,
            "training_time": training_time, "plan_training_time": plan_training_time, "rotary_begin_time": rotary_begin_time,
            "rotary_end_time":rotary_end_time,"outdept_status":outdept_status
        },
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

    function createRows(jsonArr,pi) {
        var tbL = $("#tbList");
        $("#tbList tr:gt(0)").remove();
        for (i = 0; i < jsonArr.length; i++) {
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].RealName + "</td>";
            trHTML += "<td>" + jsonArr[i].Sex + "</td>";
            trHTML += "<td>" + jsonArr[i].HighEducation + "</td>";
            trHTML += "<td>" + jsonArr[i].HighMajor + "</td>";
            trHTML += "<td>" + jsonArr[i].ProfessionalBaseName + "</td>";
            trHTML += "<td>" + jsonArr[i].DeptName + "</td>";
            trHTML += "<td>" + jsonArr[i].RotaryBeginTime + "</td>";
            trHTML += "<td>" + jsonArr[i].RotaryEndTime + "</td>";
            trHTML += "<td>" + jsonArr[i].TeachersRealName + "</td>";

            if (jsonArr[i].OutdeptStatus == "0") {
                trHTML += "<td style='color:red'>未出科</td>";
            } else if (jsonArr[i].OutdeptStatus == "1") {
                trHTML += "<td>已出科</td>";
            } else if (jsonArr[i].OutdeptStatus == "2") {
                trHTML += "<td style='color:red'>顺延一期</td>";
            }

            if (jsonArr[i].OutdeptApplication == "0") {
                trHTML += "<td>未申请出科考核</td>";
            } else if (jsonArr[i].OutdeptApplication == "1") {
                trHTML += "<td  style='color:red'>已申请出科考核</td>";
            }

            trHTML += "<td><a onclick=\"OutDeptExam('" + jsonArr[i].Id + "','" + pi + "','" + jsonArr[i].OutdeptApplication + "','" + jsonArr[i].OutdeptStatus + "');\" href='#'><img alt='出科考核' src='../../images/imgs/icon_add.gif'/></a></td>";
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

    function OutDeptExam(id,pi,outAppli,outStatus) {
        if (outAppli == "1") {
            if (outStatus == "0") {
                OpenTopWindow("OutDeptExam.aspx?id=" + id + "&pi="+pi+"", 950, 605);
                return;
            } else {
                alert("该学员已进行过出科考核，请勿重复");
                return;
            }
  
        }else{
            alert("尚未申请出科，无法进行出科考核");
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
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />学员轮转信息                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>性别</td> 
                <td>最高学历</td>
                <td>最高学历专业</td> 
                <td>专业基地</td> 
                <td>轮转科室</td>                                           
                <td>轮转开始时间</td> 
                <td>轮转结束时间</td>
                <td>指导医师</td>
                <td>出科状态</td>
                <td>申请</td>
                <td>考核</td>
                
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
       <%--<asp:Literal runat="server" ID="wo"></asp:Literal>--%>
    </form>
   
</body>
    
</html>

