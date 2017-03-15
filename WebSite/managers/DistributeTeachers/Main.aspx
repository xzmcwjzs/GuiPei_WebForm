<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="managers_DistributeTeachers_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>轮转科室管理</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/bootstrap-2.3.3/js/bootstrap.min.js"></script>
    <link href="../../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />
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
            <input type="hidden" id="length" name="length">
        </div>
        <div style="margin-top:10px;">
            <table class="table table-bordered table-condensed table-hover">
                <caption>指导医师分配</caption>
                <thead>
                    <tr>
                        <th style="text-align:center;">专业基地</th>
                        <th style="text-align:center;">科室</th>
                        <th style="text-align:center;">时间(月)</th>
                        <th style="text-align:center;">是否必轮</th>
                        <th style="text-align:center;">指导医师</th>
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
        var length;
        
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
                $("#main tr").remove();
                
                $.ajax({
                    cache: false,
                    async: false,
                    type: "get",
                    url: "ashx/GetDeptList.ashx",
                    dataType: "text",
                    data: { TrainingBaseCode: $("#TrainingBaseCode").val(), ProfessionalBaseCode: $("#ProfessionalBaseCode").val() ,TrainingTime:$("#TrainingTime").val()},
                    success: function (data) {
                        if (data == "") {
                            alert("请在轮转科室管理中制定该专业的轮转计划");
                            return false;
                        } else {
                            var jsonArr = eval("(" + data + ")");
                            
                            for (var i = 0; i < jsonArr.length; i++) {
                                length = jsonArr.length;

                                var options = "<option value=''>==请选择==</option>";
                                var  strHtml = '<tr>';
                                strHtml += '<td style="text-align:center">' + $("#ProfessionalBaseCode").find("option:selected").text() + '</td>';
                                strHtml += '<td style="text-align:center">' + jsonArr[i].DeptName + '</td>';
                                strHtml += '<td style="text-align:center">' + jsonArr[i].RealTime + '</td>';
                               
                                if (jsonArr[i].IsRequired == "1") {
                                    strHtml += '<td style="text-align:center">是</td>';
                                } else {
                                    strHtml += '<td style="text-align:center">否</td>';
                                }

                                strHtml += '<td style="text-align:center">' +
                                    '<select id="Teachers' + i + '" name="Teachers' + i + '" onchange="RealName('+i+')"></select>'+
                                    '<input type="hidden" id="TeachersRealName' + i + '" name="TeachersRealName' + i + '" value=""><input type="hidden" id="Id' + i + '" name="Id' + i + '" value="' + jsonArr[i].Id + '"></td>';
                                strHtml += '</tr>';
                                $("#main").append(strHtml);

                                $.ajax({
                                    cache: false,
                                    async: false,
                                    type: "get",
                                    url: "ashx/GetTeachers.ashx",
                                    dataType: "text",
                                    data: { TrainingBaseCode: $("#TrainingBaseCode").val(), ProfessionalBaseCode: $("#ProfessionalBaseCode").val(), DeptCode: jsonArr[i].DeptCode },
                                    success: function (data) {
                                        if (data != "") {
                                            var jsonTeachersArr = eval("(" + data + ")");
                                            for (var k = 0; k < jsonTeachersArr.length; k++) {
                                                options += "<option value=" + jsonTeachersArr[k].name + ">" + jsonTeachersArr[k].real_name + "</option>";
                                                
                                            }
                                           
                                        }
                                       
                                    },
                                    error: function () {
                                        alert("系统繁忙，请联系管理员");
                                    }
                                });

                                $("#Teachers" + i).append(options);
                            }
                            $("#length").val(length);

                         }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });

            });


        });
        function RealName(i) {
            var TeachersRealName = $("#Teachers" + i).find("option:selected").text();
            if (TeachersRealName == "==请选择==") {
                TeachersRealName = "";
            }
            $("#TeachersRealName" + i).val(TeachersRealName);
        }
        
        
        function saveAndUpdate() {
            for (var k = 0; k < length; k++) {
                if ($("#Teachers" + k).val() == "") {
                    alert("指导医师不能为空");
                    return false;
                }
            }
            var forms = $("#form1").serializeArray();
            $.ajax({
                cache: false,
                async:true,
                type: "post",
                url: "ashx/UpdateTeachers.ashx",
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
    </script>
</body>
</html>
