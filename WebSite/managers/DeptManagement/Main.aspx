<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="managers_DeptManagement_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>轮转科室管理</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/bootstrap-2.3.3/js/bootstrap.min.js"></script>
    <link href="../../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/placeholder.js"></script>
    <style type="text/css">
        .table-hover tbody tr:hover > td,
        .table-hover tbody tr:hover > th {
            background-color: #c2d5ff;
        }
    </style>
</head>
<body style="text-align: center;">
    <form id="form1" runat="server" class="form-inline" role="form">
        <div class="form-group" style="margin: auto; margin-top: 10px;">
            <label class="sr-only" for="TrainingBaseName">培训基地</label>
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
        </div>
        <div style="margin-top:10px;">
            <table class="table table-bordered table-condensed table-hover">
                <caption>轮转科室管理</caption>
                <thead>
                    <tr>
                        <th style="text-align:center;">专业基地</th>
                        <th style="text-align:center;">轮转科室</th>
                        <th style="text-align:center;">要求时间(月)</th>
                        <th style="text-align:center;">实际时间(月)</th>
                        <th style="text-align:center;">是否必轮</th>
                        <th style="text-align:center;">移除</th>
                    </tr>
                </thead>
                <tbody id="main"></tbody>
             </table>
        </div>
        <div>
            <input type="button" id="SaveUpdate" name="SaveUpdate" class="btn btn-success" value="保存" onclick="saveAndUpdate()"/>
        </div>
    </form>

    <script type="text/javascript">
        var ManagersName = "<%=ManagersName%>";
        var ManagersRealName = "<%=ManagersRealName%>";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var TrainingBaseName = "<%=TrainingBaseName%>";
        var TrainingTime = "<%=DateTime.Now.Year%>" + "年";
        var trLength, Length;

        $(function () {
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
                $("#ProfessionalBaseName").val($("#ProfessionalBaseCode").find("option:selected").text());
                $("#main tr").remove();

                $.ajax({
                    cache: false,
                    type: "get",
                    url: "../../ASHX/DeptCodeByPB.ashx",
                    dataType: "text",
                    data: { professionalBaseCode: $("#ProfessionalBaseCode").val() },
                    success: function (data) {
                        var jsonArr = eval("(" + data + ")");
                        var result = jsonArr.RotaryDept;
                        if (result != null) {
                            var strHtml = "";
                            var totalTime = parseFloat(0);
                            for (i = 0; i < result.length; i++) {
                                trLength = result.length;
                                Length = result.length;
                                strHtml += '<tr id="tr' + i + '">';
                                strHtml += '<td style="text-align:center">' + $("#ProfessionalBaseCode").find("option:selected").text() + '</td>';
                                strHtml += '<td style="text-align:center">' + result[i].dept_name + '<input type="hidden" id="DeptName' + i + '" name="DeptName' + i + '" value="' + result[i].dept_name + '"><input type="hidden" id="DeptCode' + i + '" name="DeptCode' + i + '" value="' + result[i].dept_code + '"></td>';
                                strHtml += '<td style="text-align:center">' + result[i].dept_time + '<input type="hidden" id="DeptTime' + i + '" name="DeptTime' + i + '" value="' + result[i].dept_time + '"></td>';
                                strHtml += '<td style="text-align:center"><input type="text" class="form-control" id="RealTime' + i + '" name="RealTime' + i + '" style="width:20px;height:20px" value="' + result[i].dept_time + '" onkeyup="realTime('+i+',' + result.length + ')"></td>';
                                if (result[i].is_required == "1") {
                                    strHtml += '<td style="text-align:center">是<input type="hidden" id="IsRequired' + i + '" name="IsRequired' + i + '" value="' + result[i].is_required + '"></td>';
                                } else {
                                    strHtml += '<td style="text-align:center">否<input type="hidden" id="IsRequired' + i + '" name="IsRequired' + i + '" value="' + result[i].is_required + '"></td>';
                                }

                                strHtml += '<td style="text-align:center">' +
                                    '<input type="button" id="Delete' + i + '" name="Delete' + i + '" onclick="removeTr(' + i + ','+result.length+')" class="btn btn-success" value="移除"/></td>';
                                strHtml += '</tr>';
                                if (result[i].dept_time == "" || result[i].dept_time == null) {
                                    result[i].dept_time = parseFloat(0);
                                }
                                totalTime += parseFloat(result[i].dept_time);
                            }
                            //strHtml += "<tr><td style=\"text-align:left\" colspan=\"6\"><input type=\"button\" id=\"AddLine\" name=\"AddLine\" class=\"btn btn-success\" value=\"新增轮转科室\" onclick='addLine(\""+maxDeptCode+"\");'/></td></tr>";
                            strHtml += "<tr> <td colspan='2' style='text-align:center'>总计</td>" +
                                "<td style='text-align:center'>" + totalTime + "<input type='hidden' id='TotalDeptTime' name='TotalDeptTime' value='"+totalTime+"'></td>" +
                                "<td style='text-align:center'><input type='text' class='form-control' id='TotalRealTime' name='TotalRealTime' style='width:20px;height:20px' value='" + totalTime + "'><input type='hidden' id='trLength' name='trLength'><input type='hidden' id='TotalLength' name='TotalLength' value='" + result.length + "'></td><td colspan='2'></td></tr>";
                            $("#main").append(strHtml);
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
                
            });
           
        });

        function removeTr(i,length) {
            if (confirm("确定移除该轮转科室")) {
                $("#tr" + i).remove();
                trLength--;
                realTime(i,length);
            }
         }
        function realTime(i,length) {
            var realTotalTime = parseFloat(0);
            var reg = /^[0-9].*$/;
            var j;
            if (reg.test($("#RealTime" + i).val())||$("#RealTime"+i).length==0) {
                for (j = 0; j < length; j++) {
                    if ($("#RealTime" + j).length > 0) {//判断控件是否存在
                        if ($("#RealTime" + j).val() == "" || $("#RealTime" + j).val() == null) {
                            $("#RealTime" + j).val(parseFloat(0));
                        }
                        realTotalTime += parseFloat($("#RealTime" + j).val());
                    }
                }
                $("#TotalRealTime").val(realTotalTime);
            } else {
                alert("实际时间不合法，不能为空、0或存在1-2、2-3等模糊时间");
                $("#RealTime" + i).val("");
                return;
            }
            
        }

        function saveAndUpdate() {
            $("#trLength").val(trLength);
            for (n = 0; n < Length; n++) {
                if ($("#RealTime" + n).length > 0) {
                    var data = $("#RealTime" + n).val();
                    var reg = /^[1-9]\d*(\.\d+)?$/;
                    if (!reg.test(data)) {
                        alert("实际时间不合法，不能为空、0或存在1-2、2-3等模糊时间");
                        return false;
                    }
                }
            }
            if ($("#ProfessionalBaseCode").val() == ""||$("#main tr").length==1) {
                alert("轮转科室管理信息不能为空");
                return false;
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
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
            }
            
        }
    </script>
</body>
</html>
