<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="managers_RotarySchedule_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学员轮转分配</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/bootstrap-2.3.3/js/bootstrap.min.js"></script>
    <link href="../../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/DateFormat.js"></script>
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
        var TrainingTime = "<%=DateTime.Now.Year%>" + "年";
        var TotalRealTime;
        var jsonRes; 
        //var studentsJsonArr;
        var BeginTimeList = "", EndTimeList = "", DaysList = "", DeptCodeList = "", DeptNameList = "";
        var options = "";
        $(function () {
            $("#btnRightAll").click(function () {
                $("#selectLeft").children().appendTo("#selectRight");
            });

            $("#btnRight").click(function () {
                $("#selectLeft :selected").appendTo("#selectRight");
            });

            $("#btnLeftAll").click(function () {
                $("#selectRight").children().appendTo("#selectLeft");
            });

            $("#btnLeft").click(function () {
                $("#selectRight :selected").appendTo("#selectLeft");
            });

            $("#TrainingBaseCode").val(TrainingBaseCode);
            $("#TrainingBaseName").val(TrainingBaseName);
            $("#ManagersName").val(ManagersName);
            $("#ManagersRealName").val(ManagersRealName);
            $("#TrainingTime").val(TrainingTime);

            $.post("../../ASHX/ProfessionalBase.ashx", function (data) {
                jsonArr = eval(data);
                if (jsonArr != null) {
                    for (var i = 0; i < jsonArr.length; i++) {
                        $("#ProfessionalBaseCode").append("<option Value=" + jsonArr[i].professional_base_code + ">" + jsonArr[i].professional_base_name + "</option>");
                    }
                }
            });
            $("#ProfessionalBaseCode").change(function () {
                var ProfessionalBaseName = $("#ProfessionalBaseCode").find("option:selected").text();
                $("#ProfessionalBaseName").val(ProfessionalBaseName);
            });

        });
        
       
        function Generate() {
            $("#SelectLength").val($("#selectRight option").length);
            $("#RotaryScheme div").remove();
            
            if ($("#RotaryBeginTime").val() == "") {
                alert("学员开始轮转时间不能为空");
                return false;
            }
            if ($("#selectLeft option").length > 0) {
                alert("左侧存在尚未调整顺序的科室");
                return false;
            }
            
            var RotaryBeginTime = $("#RotaryBeginTime").val();
            var RotaryEndTime = $("#RotaryEndTime").val();
            var strHtml = "<div class='form-group' style='width:200%;'><label class='col-sm-2 control-label'>科室轮转方案</label></div><div style='width:200%;'><table class='table table-bordered table-condensed table-hover'><tbody>";

            for (var n = 0; n < $("#selectRight option").length; n++) {//循环产生tr

                strHtml += "<tr>";
                for (var j = 0; j < $("#selectRight option").length; j++) {//循环产生td
                    var k;
                    for (var i = 0; i < jsonRes.length; i++) {//根据selectRight产生一个td
                        if ($("#selectRight option:eq(" + j + ")").val() == jsonRes[i].DeptCode) {
                            k = i;
                            BeginTimeList = BeginTimeList + "}" + RotaryBeginTime;
                            EndTimeList = EndTimeList + "}" + countTime(RotaryBeginTime, jsonRes[k].RealTime);
                            DaysList = DaysList + "}" + jsonRes[k].RealTime * 30;
                            DeptCodeList = DeptCodeList + "}" + jsonRes[k].DeptCode;
                            DeptNameList = DeptNameList + "}" + jsonRes[k].DeptName;
                            strHtml += "<td>" + RotaryBeginTime + "到" + countTime(RotaryBeginTime, jsonRes[k].RealTime) + "</br>(共" + jsonRes[k].RealTime * 30 + "天)</br>" + jsonRes[k].DeptName + "</td>";
                        }
                    }
                    RotaryBeginTime = countNextTime(RotaryBeginTime, jsonRes[k].RealTime);
                }
                strHtml += "<input type='hidden' id='BeginTimeList" + n + "' name='BeginTimeList" + n + "' value='" + BeginTimeList.substr(1,BeginTimeList.length) + "'>" +
                          "<input type='hidden' id='EndTimeList" + n + "' name='EndTimeList" + n + "' value='" + EndTimeList.substr(1, EndTimeList.length) + "'>"+
                          "<input type='hidden' id='DaysList" + n + "' name='DaysList" + n + "' value='" + DaysList.substr(1, DaysList.length) + "'>" +
                          "<input type='hidden' id='DeptCodeList" + n + "' name='DeptCodeList" + n + "' value='" + DeptCodeList.substr(1, DeptCodeList.length) + "'>" +
                          "<input type='hidden' id='DeptNameList" + n + "' name='DeptNameList" + n + "' value='" + DeptNameList.substr(1, DeptNameList.length) + "'>" +
                          "<input type='hidden' id='SchemeOrder" + n + "' name='SchemeOrder" + n + "' value='" + n + "'>";

                $("#selectRight").append("<option Value=" + $("#selectRight option:eq(0)").val() + ">" + $("#selectRight option:eq(0)").text() + "</option>");
                $("#selectRight option:eq(0)").remove();
                RotaryBeginTime = $("#RotaryBeginTime").val();
                BeginTimeList = "";
                EndTimeList = "";
                DaysList = "";
                DeptCodeList = "";
                DeptNameList = "";
                SchemeOrder = "";
                strHtml += "</tr>";
             }
            strHtml += "</tbody></table></div>";
            $("#RotaryScheme").append(strHtml);

        }

        function checkPB() {
            $("#selectRight option").remove();
            $("#RotaryBeginTime").val(""); $("#RotaryEndTime").val("");
            $("#RotaryScheme div").remove();
            if ($("#ProfessionalBaseCode").val() == "" || $("#TrainingTime").val() == "") {
                alert("专业基地或参训时间不能为空");
                $("#PaiBan").removeAttr("data-toggle");
            } else {
                $("#selectLeft option").remove();
                $("#PaiBan").attr("data-toggle", "modal");
                $.ajax({
                    cache: false,
                    type: "get",
                    url: "ashx/Dept.ashx",
                    dataType: "text",
                    data: { TrainingTime: $("#TrainingTime").val(), TrainingBaseCode: TrainingBaseCode, ProfessionalBaseCode: $("#ProfessionalBaseCode").val() },
                    success: function (data) {
                        var jsonArr = eval("(" + data + ")");
                            jsonRes = jsonArr.data;
                           if (jsonRes != null) {
                               $("#RotaryBeginTime").attr("disabled", false);
                               $("#GenerateScheme").attr("disabled", false);
                               $("#submit").attr("disabled", false);
                               TotalRealTime = jsonRes[0].TotalRealTime;
                               $("#TotalRealTime").val(TotalRealTime);
                               for (var i = 0; i < jsonRes.length; i++) {
                                   $("#selectLeft").append("<option Value=" + jsonRes[i].DeptCode + ">" + jsonRes[i].DeptName + "</option>");
                               }
                           } else {
                               alert("请在轮转科室管理中制定该专业的轮转计划");
                               $("#ProfessionalBaseCode").val("");
                               $("#RotaryBeginTime").attr("disabled", true);
                               $("#GenerateScheme").attr("disabled", true);
                               $("#submit").attr("disabled", true);
                               return;
                           }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
            }
        }

        function countEndTime() {
            if ($("#RotaryBeginTime").val() == "") {
                return;
            } else {
                var timeadd=countTime($("#RotaryBeginTime").val(),TotalRealTime);
               $("#RotaryEndTime").val(timeadd);
            }
            
        }
        function countTime(beginTime,months){
            var timeadd = new Date(beginTime.replace(/-/g, "/"));
            timeadd = new Date(timeadd.getTime() + ((months) * 30 - 1) * 24 * 60 * 60 * 1000);
            
            //timeadd = timeadd.getFullYear() + "-" + (timeadd.getMonth() + 1) + "-" + timeadd.getDate();
            //return timeadd;
            return timeadd.Format("yyyy-MM-dd");
        }
        function countNextTime(beginTime, months) {
            var timeadd = new Date(beginTime.replace(/-/g, "/"));
            timeadd = new Date(timeadd.getTime() + (months) * 30 * 24 * 60 * 60 * 1000);
            //timeadd = timeadd.getFullYear() + "-" + (timeadd.getMonth() + 1) + "-" + timeadd.getDate();
            //return timeadd;
            return timeadd.Format("yyyy-MM-dd")
        }

        function submitScheme() {
            if ($("#RotaryScheme div").length == 0) { 
                alert("请生成轮转方案后提交");
                return;
            } else {
                var forms = $("#form1").serializeArray();

                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/Add.ashx",
                    dataType: "text",
                    data: forms,
                    success: function (data) {
                        alert(data);
                        return;
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
            }
            
        }

        function distributeStudents() {
            $("#StudentsSchedule tr").remove();
            $("#MyModal div").remove();
            if ($("#ProfessionalBaseCode").val() == "" || $("#TrainingTime").val() == "") {
                alert("专业基地或参训时间不能为空");
                return false;
            }

            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/GetStudents.ashx",
                dataType: "text",
                data: { TrainingBaseCode: TrainingBaseCode, ProfessionalBaseCode: $("#ProfessionalBaseCode").val(), TrainingTime: $("#TrainingTime").val() },
                success: function (data) {
                    if (data == "") {
                        options = "";
                        alert("尚无学员信息");

                    } else {
                        var studentsJsonArr = eval("(" + data + ")");
                        for (var h = 0; h < studentsJsonArr.length; h++) {
                            options += "<option value=" + studentsJsonArr[h].Name + ">" + studentsJsonArr[h].RealName + "</option>";
                        }
                    }
                 },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });

            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/List.ashx",
                dataType: "text",
                data: { TrainingBaseCode: TrainingBaseCode, ProfessionalBaseCode: $("#ProfessionalBaseCode").val(), TrainingTime: $("#TrainingTime").val() },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    var jsonRes = jsonArr.data;
                    if (jsonRes != null) {
                        var strHtml = "";
                        var modalHtml = "";
                        
                        var BeginTimeArr = new Array();
                        var EndTimeArr = new Array();
                        var DaysArr = new Array();
                        var DeptCodeArr = new Array();
                        var DeptNameArr = new Array();
                        var length;
                       
                        for (var i = 0; i < jsonRes.length; i++) {
                            length = jsonRes.length;
                            var modalTr = "";
                            BeginTimeArr = jsonRes[i].BeginTimeList.split("}");
                            EndTimeArr = jsonRes[i].EndTimeList.split("}");
                            DaysArr = jsonRes[i].DaysList.split("}");
                            DeptCodeArr = jsonRes[i].DeptCodeList.split("}");
                            DeptNameArr = jsonRes[i].DeptNameList.split("}");

                            modalHtml += "<div class=\"modal fade\" id='myModal"+i+"' tabindex=\"-1\" role=\"dialog\"aria-labelledby=\"myModalLabel\" aria-hidden=\"true\" data-backdrop=\"static\" style=\"display:none;height:500px;width:80%;margin-left:-40%;\">" +
             "<div class=\"modal-dialog\">" +
                "<div class=\"modal-content\">" +
                    "<div class=\"modal-body\" style=\"max-height:400px; min-height: 400px;\">" +

                       "<div class=\"form-group\" style=\"margin: auto; margin-top:10px;float:left;width:55%;\">" +
"             <table class=\"table table-bordered table-condensed table-hover\"\">" +
"                <caption>" + jsonRes[i].ProfessionalBaseName + "专业基地学员分配方案" + (parseInt(jsonRes[i].SchemeOrder, 10) + 1) + "</caption>" +
"                <thead>" +
"                    <tr>" +
"                        <th style=\"text-align:center;\">开始日期</th>" +
"                        <th style=\"text-align:center;\">结束日期</th>" +
"                        <th style=\"text-align:center;\">天数</th>" +
"                        <th style=\"text-align:center;\">轮转科室</th>" +
"                    </tr>" +
"                </thead>" +
"                <tbody id='StudentsScheme"+i+"'></tbody>" +
"            </table>" +
"        </div>" +

"<div class=\"form-group\" style=\"margin: auto; margin-top:30px;margin-left:20px;float:left;width:25%;\">" +

"<table>" +
"                                    <tr>" +
"                                        <td id='studentsLeft"+i+"'>所有(剩)学员" +
//"                                            <select id='selectStudentsLeft' multiple=\"multiple\" class=\"form-control\" style=\"height:380px;width:150px;\"></select>" +
"                                        </td>" +
"                                        <td>" +
"                                            <input type=\"button\" id='btnStudentsRight"+i+"' value=\">\" class=\"btn btn-default\" onclick=\"studentsRight("+i+")\"/>" +
"                                            <br />" +
"                                            <input type=\"button\" id='btnStudentsLeft" + i + "' value=\"<\" class=\"btn btn-default\" onclick=\"studentsLeft(" + i + ")\"/>" +
"                                        </td>" +
"                                        <td>分配的学员" +
"                                            <select id='selectStudentsRight"+i+"' multiple=\"multiple\" class=\"form-control\" style=\"height:380px;width:150px;\"></select>" +
"                                        </td>" +
"                                    </tr>" +
"                                </table>"+

"        </div>" +

                    "</div>" +
                "<div class=\"modal-footer\" style=\"margin: auto; text-align: center;\">" +
                      "<input type=\"button\" id='close" + i + "' name='close" + i + "' onclick=\"removeSelect("+i+");\" class=\"btn btn-default\" data-dismiss=\"modal\" value=\"关闭\" />" +
                      "<input type=\"button\" id='submit" + i + "' name='submit" + i + "' class=\"btn btn-success\" value=\"保存\" onclick=\"saveStudents('"+i+"','"+jsonRes[i].Id+"')\"/>" +
                "</div>" +
              "</div>" +
            "</div>" +
          "</div>";

                            $("#MyModal").append(modalHtml);

                            for (var j = 0; j < length; j++) {
                                modalTr += "<tr>" +
                "                        <td style=\"text-align:center;\">" +BeginTimeArr[j] + "</td>" +
                "                        <td style=\"text-align:center;\">" +EndTimeArr[j] + "</td>" +
                "                        <td style=\"text-align:center;\">" +DaysArr[j] + "</td>" +
                "                        <td style=\"text-align:center;\">" +DeptNameArr[j] + "</td>" +
                "                    </tr>";
                            }
                            $("#StudentsScheme" + i).append(modalTr);

                            strHtml += "<tr>";
                            strHtml += "<td style='text-align:center;'>" + (parseInt(jsonRes[i].SchemeOrder,10)+1)+"</td>";
                            strHtml += "<td style='text-align:center;'>" + jsonRes[i].ProfessionalBaseName  + "</td>";
                            strHtml += "<td style='text-align:center;'>" + jsonRes[i].TrainingTime  + "</td>";
                            strHtml += "<td style='text-align:center;'>" + jsonRes[i].TotalRealTime + "月(" + jsonRes[i].TotalRealTime *30+ "天)</td>";
                            strHtml += "<td style='text-align:center;'>" + jsonRes[i].RotaryBeginTime + "</td>";
                            strHtml += "<td style='text-align:center;'>" + jsonRes[i].RotaryEndTime + "</td>";
                            strHtml += "<td style='text-align:center;'>" + DeptNameArr[0] + "(" + DaysArr [0]+ "天)</td>";
                            strHtml += "<td style='text-align:center;'>" + DeptNameArr[DeptNameArr.length - 1] + "(" + DaysArr[DaysArr.length - 1] + "天)</td>";
                            strHtml += "<td style='text-align:center;'><input type='button' id='add" + i + "' name='add" + i + "' onclick=\"addStudents("+i+")\"  class='btn btn-success' value='添加' data-toggle='modal' data-target='#myModal" + i + "'/></td>";
                            strHtml += "</tr>";
                        }

                        $("#StudentsSchedule").append(strHtml);
                         

                    } else {
                        alert("尚未生成排班方案，无法分配学员");
                        return false;
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }
        function addStudents(m) {
            $("#selectStudentsLeft").empty();
            $("#studentsLeft" + m).append("<select id='selectStudentsLeft' multiple=\"multiple\" class=\"form-control\" style=\"height:380px;width:150px;\"></select>");
            
            $("#selectStudentsLeft").append(options);

        }
        function removeSelect(g) {
            $("#studentsLeft" + g).find("select").remove();
        }
        function studentsRight(n) {
            $("#selectStudentsLeft :selected").appendTo("#selectStudentsRight" + n);
            options = "";
            if ($("#selectStudentsLeft option").length != 0) {
                for (var i = 0; i < $("#selectStudentsLeft option").length; i++) {
                    options += "<option value=" + $("#selectStudentsLeft option").eq(i).val() + ">" + $("#selectStudentsLeft option").eq(i).text() + "</option>";
                }
            }
            

        }
        function studentsLeft(a) {
            $("#selectStudentsRight" + a).find("option:selected").appendTo("#selectStudentsLeft");
            options = "";
            if ($("#selectStudentsLeft option").length != 0) {
                for (var i = 0; i < $("#selectStudentsLeft option").length; i++) {
                    options += "<option value=" + $("#selectStudentsLeft option").eq(i).val() + ">" + $("#selectStudentsLeft option").eq(i).text() + "</option>";
                }
            }
            
        }
        function saveStudents(i, id) {
            var StudentsNameList="";
            var StudentsRealNameList="";
            var length=$("#selectStudentsRight" + i).find("option").length;
            if(length==0){
                alert("请分配学员");
                return;
            }else{
                for (var t = 0; t < length; t++) {
                    StudentsNameList = StudentsNameList + "}" + $("#selectStudentsRight" + i).find("option:eq("+t+")").val();
                    StudentsRealNameList = StudentsRealNameList + "}" + $("#selectStudentsRight" + i).find("option:eq("+t+")").text();
                }
                
                StudentsNameList=StudentsNameList.substr(1,StudentsNameList.length);
                StudentsRealNameList=StudentsRealNameList.substr(1,StudentsRealNameList.length);

                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/SaveStudents.ashx",
                    dataType: "text",
                    data: {id:id,StudentsNameList:StudentsNameList,StudentsRealNameList:StudentsRealNameList },
                    success: function (data) {
                        alert(data);
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
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
            <input type="hidden" id="TotalRealTime" name="TotalRealTime" />
            <input type="hidden" id="SelectLength" name="SelectLength" />
        </div>
        <div class="form-group" style="margin: auto; margin-top: 10px;">
            <label class="sr-only" for="PaiBan" style="margin-left:20px;color:red;font-size:17px;">第一步：</label>
            <input type="button" id="PaiBan" value="轮转排班" class="btn btn-primary btn-success" data-toggle="modal" data-target="#myModal" onclick="checkPB();"/>
            <label class="sr-only" for="PaiBan" style="margin-left:100px;color:red;font-size:17px;">第二步：</label>
            <input type="button" id="DistributeStudents" value="分配学员" class="btn btn-primary btn-success" onclick="distributeStudents();"/>
        </div>
        <div class="form-group" style="margin: auto; margin-top:10px;">
             <table class="table table-bordered table-condensed table-hover"">
                <caption>轮转排班</caption>
                <thead>
                    <tr>
                        <th style="text-align:center;">方案</th>
                        <th style="text-align:center;">专业基地</th>
                        <th style="text-align:center;">参训时间</th>
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
        <%--<div>
            <input type="button" id="SaveUpdate" name="SaveUpdate" class="btn btn-success" value="保存" onclick="saveAndUpdate()"/>
        </div>--%>
            

<!-- 模态框（Modal） -->
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" style="display:none;height:500px;width:90%;margin-left:-45%;top:5%;">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="myModalLabel">科室轮转计划</h4>
                        </div>
                        <div class="modal-body" style="max-height: 400px; min-height: 400px; padding: 5px;">
                            <div class="form-group">
                                <label class="sr-only" for="TrainingBaseName">学员轮转开始时间</label>
                                <input type="text" class="form-control" id="RotaryBeginTime" name="RotaryBeginTime" style="width: 150px; height: 20px" onclick="WdatePicker();" onblur="countEndTime();">
                                <label class="sr-only" for="TrainingBaseName" style="margin-left: 20px;">学员轮转结束时间</label>
                                <input type="text" class="form-control" id="RotaryEndTime" name="RotaryEndTime" style="width: 150px; height: 20px" readonly="readonly">
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    轮转科室顺序调整
                                </label>
                            </div>
                            <div class="form-group" align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <select id="selectLeft" multiple="multiple" class="form-control" style="height:120px;width:300px;"></select>
                                        </td>
                                        <td>
                                            <input type="button" id="btnRightAll" value=">>" class="btn btn-default" />
                                            <input type="button" id="btnRight" value=">" class="btn btn-default" />
                                            <br />
                                            <input type="button" id="btnLeft" value="<" class="btn btn-default" />
                                            <input type="button" id="btnLeftAll" value="<<" class="btn btn-default" />
                                        </td>
                                        <td>
                                            <select id="selectRight" multiple="multiple" class="form-control" style="height:120px;width:300px;"></select>
                                        </td>
                                        <td>
                                            <input type="button" id="GenerateScheme" name="GenerateScheme" value="生成轮转方案" class="btn btn-success" onclick="Generate();" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group" align="center" id="RotaryScheme"></div>
                        </div>
                        <div class="modal-footer" style="margin: auto; text-align: center;">
                            <input type="button" id="close" name="close" class="btn btn-default" data-dismiss="modal" value="关闭" />
                            <input type="button" id="submit" name="submit" class="btn btn-success" value="提交" onclick="submitScheme();"/>

                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal -->
            </div>


        <div id="MyModal">

        </div>
        <%--<div class="modal fade" id="myModal1" tabindex="-1" role="dialog"aria-labelledby="myModalLabel" aria-hidden="true" style="display:none">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        在这里添加一些文本
                    </div>
                    <div class="modal-footer">
                        <input type="button" id="close'+i+'" name="close" class="btn btn-default" data-dismiss="modal" value="关闭" />
                        <input type="button" id="submit'+i+'" name="submit" class="btn btn-success" value="保存" onclick="submitScheme();"/>
                    </div>
                </div>
            </div>
        </div>--%>


    </form>
</body>
</html>
