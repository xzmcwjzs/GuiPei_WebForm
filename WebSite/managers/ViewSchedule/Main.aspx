<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="managers_ViewSchedule_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看轮转排班</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/bootstrap-2.3.3/js/bootstrap.min.js"></script>
    <link href="../../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/PageList/PageList2.js"></script>
    <style type="text/css">
        .table-hover tbody tr:hover > td,
        .table-hover tbody tr:hover > th {
            background-color: #c2d5ff;
        }
    </style>

    <script type="text/javascript">
        var ManagersName = "<%=ManagersName%>";
        var ManagersRealName = "<%=ManagersRealName%>";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var TrainingBaseName = "<%=TrainingBaseName%>";
        $(function () {
            $("#TrainingBaseCode").val(TrainingBaseCode);
            $("#TrainingBaseName").val(TrainingBaseName);
            $("#ManagersName").val(ManagersName);
            $("#ManagersRealName").val(ManagersRealName);

            $.post("../../ASHX/ProfessionalBase.ashx", function (data) {
                jsonArr = eval(data);
                if (jsonArr != null) {
                    for (var i = 0; i < jsonArr.length; i++) {
                        $("#ProfessionalBaseCode").append("<option Value=" + jsonArr[i].professional_base_code + ">" + jsonArr[i].professional_base_name + "</option>");
                    }
                }
            });
        })

        function search() {
            loadPageList(1);
        }

        $(window).load(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {

            $.post("ashx/List.ashx", {
                "pi": pi, "TrainingBaseCode": $("#TrainingBaseCode").val(), "ProfessionalBaseCode": $("#ProfessionalBaseCode").val(),
                "TrainingTime": $("#TrainingTime").val()
            },
              function (data) {
                  var jsonArr = eval("(" + data + ")");
                  if (jsonArr.data == null) {
                      $("#StudentsSchedule tr").remove();
                  } else {
                      createRows(jsonArr.data, pi);
                  }
                  createPageBar($("#PageList"), pi, jsonArr.recordCount, jsonArr.pageCount);

              });
        }

        function createRows(jsonArr, pi) {
            var BeginTimeArr = new Array();
            var EndTimeArr = new Array();
            var DaysArr = new Array();
            var DeptCodeArr = new Array();
            var DeptNameArr = new Array();
            var StudentsName = new Array();
            var StudentsRealName = new Array();
            var k = 1;
            var tbL = $("#StudentsSchedule");
            $("#StudentsSchedule tr").remove();
            for (var i = 0; i < jsonArr.length; i++) {
                var StudentsList = "";
                BeginTimeArr = jsonArr[i].BeginTimeList.split("}");
                EndTimeArr = jsonArr[i].EndTimeList.split("}");
                DaysArr = jsonArr[i].DaysList.split("}");
                DeptCodeArr = jsonArr[i].DeptCodeList.split("}");
                DeptNameArr = jsonArr[i].DeptNameList.split("}");
                StudentsName = jsonArr[i].Tag1.split("}");
                StudentsRealName = jsonArr[i].Tag2.split("}");

                var strHtml = "<tr>";
                strHtml += "<td style='text-align:center;'>" + k + "</td>";
                strHtml += "<td style='text-align:center;'>" + jsonArr[i].TotalRealTime + "月(" + jsonArr[i].TotalRealTime * 30 + "天)</td>";
                strHtml += "<td style='text-align:center;'>" + jsonArr[i].RotaryBeginTime + "</td>";
                strHtml += "<td style='text-align:center;'>" + jsonArr[i].RotaryEndTime + "</td>";

                strHtml += "<td style='text-align:center;'>" + DeptNameArr[0] + "(" + DaysArr[0] + "天)</td>";
                strHtml += "<td style='text-align:center;'>" + DeptNameArr[DeptNameArr.length - 1] + "(" + DaysArr[DaysArr.length - 1] + "天)</td>";

                for (var j = 0; j < StudentsRealName.length; j++) {
                    StudentsList = StudentsList + " " + StudentsRealName[j];
                }
                strHtml += "<td style='text-align:center;'>" + StudentsList + "</td>";
                strHtml += "</tr>";
                tbL.append(strHtml);
                k++;
            }
           
        }
       
    </script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server" class="form-inline" role="form">
        
        <div class="form-group" style="margin: auto; margin-top: 10px;">
           
            <label class="sr-only" for="TrainingBaseName" style="margin-left:20px;">培训基地</label>
            <input type="text" class="form-control" id="TrainingBaseName" name="TrainingBaseName" style="width:150px;height:20px" readonly="readonly">
            <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode">

            <label class="sr-only" for="ProfessionalBaseCode" style="margin-left:20px;">专业基地<span style="color:red">*</span></label>
            <select class="form-control" id="ProfessionalBaseCode" name="ProfessionalBaseCode" style="width:150px;">
                <option value="">==请选择==</option>
            </select><input type="hidden" id="ProfessionalBaseName" name="ProfessionalBaseName" />

            <label class="sr-only" for="TrainingBaseName" style="margin-left:20px;">参训时间</label>
            <input type="text" class="form-control" id="TrainingTime" name="TrainingTime" style="width:100px;height:20px">

            <label class="sr-only" for="TrainingBaseName" style="margin-left:20px;">管理员</label>
            <input type="text" class="form-control" id="ManagersRealName" name="ManagersRealName" style="width:100px;height:20px" readonly="readonly">
            <input type="hidden" id="ManagersName" name="ManagersName">

            <input type="button" id="Search" value="查询" class="btn btn-primary btn-success" data-toggle="modal" data-target="#myModal" onclick="search();"/>
        </div>
        <div class="form-group" style="margin: auto; margin-top:10px;">
             <table class="table table-bordered table-condensed table-hover"">
                <caption>学员轮转排班</caption>
                <thead>
                    <tr>
                        <th style="text-align:center;">序号</th>
                        <th style="text-align:center;">培训总时间</th>
                        <th style="text-align:center;">轮转开始时间</th>
                        <th style="text-align:center;">轮转结束时间</th>
                        <th style="text-align:center;">轮转开始科室(天数)</th>
                        <th style="text-align:center;">轮转结束科室(天数)</th>
                        <th style="text-align:center;">学员</th>
                    </tr>
                </thead>
                <tbody id="StudentsSchedule"></tbody>
            </table>
        </div>
        <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;"></div>
    </form>
</body>
</html>
