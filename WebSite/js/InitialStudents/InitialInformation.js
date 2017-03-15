/// <reference path="../jquery-1.7.2.js" />
function Initial() {

    $.ajax({
        cache: false,
        type: "get",
        url: "../../ASHX/Initial.ashx",
        dataType: "text",//如果是json的话，不用eval()在解析
        data: { action: "BasicInformation" },
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr.data == "close") {
                alert("请重新登录");
                window.close();
            }
            else if (jsonArr.data == "noData") {
                alert("请完善个人基本信息");
                window.close();
            } else {
                var StudentsName = jsonArr.StudentsName;
                var StudentsRealName = jsonArr.StudentsRealName;
                var TrainingBaseCode = jsonArr.TrainingBaseCode;
                var TrainingBaseName = jsonArr.TrainingBaseName;
                var ProfessionalBaseCode = jsonArr.ProfessionalBaseCode;
                var ProfessionalBaseName = jsonArr.ProfessionalBaseName;
                var RotaryDept = jsonArr.RotaryDept;
                var RegisterDate = jsonArr.RegisterDate;

                $("#StudentsName").val(StudentsName);
                $("#StudentsRealName").val(StudentsRealName);
                $("#TrainingBaseCode").val(TrainingBaseCode);
                $("#TrainingBaseName").val(TrainingBaseName);
                $("#ProfessionalBaseCode").val(ProfessionalBaseCode);
                $("#ProfessionalBaseName").val(ProfessionalBaseName);
                $("#Writor").val(StudentsRealName);
                $("#RegisterDate").val(RegisterDate);
                for (var i = 0; i < RotaryDept.length; i++) {
                    $("#RotaryDept").append("<option value=" + RotaryDept[i].dept_code + ">" + RotaryDept[i].dept_name + "</option>");
                }

            }
            $("#DeptName").val("");
            $("#TeacherName").val("");
            
        },
        error: function () {
            alert("系统繁忙，请联系管理员");
        }

    });
    $("#RotaryDept").change(function () {
        $("#Teacher option:not(:first)").remove();
        $.ajax({
            cache: false,
            type: "get",
            url: "../../ASHX/Initial.ashx",
            dataType: "text",
            data: { action: "GetTeachers", DeptCode: $("#RotaryDept").val() },
            success: function (data) {
                var jsonArr = eval("(" + data + ")");
                var Teacher = jsonArr.Teacher;
                if (jsonArr.data == "close") {
                    alert("请重新登录");
                    window.close();
                }
                else if (Teacher == null) {
                    return;
                } else {
                    for (var i = 0; i < Teacher.length; i++) {
                        $("#Teacher").append("<option value=" + Teacher[i].name + ">" + Teacher[i].real_name + "</option>");
                    }
                }
                if ($("#RotaryDept").val() == "") {
                    $("#DeptName").val("");
                    $("#TeacherName").val("");
                } else {
                    $("#DeptName").val($("#RotaryDept").find("option:selected").text());
                    
                }
                

            },
            error: function () {
                alert("系统繁忙，请联系管理员");
            }
        });
    });
    $("#Teacher").change(function () {
        if ($("#Teacher").val == "") {
            $("#TeacherName").val("");
        } else {
            $("#TeacherName").val($("#Teacher").find("option:selected").text());
        }
    });
}

function loadProvinceCityArea(provinceId, cityId, areaId, provinceHidden, cityHidden, areaHidden) {
    $.ajax({
        cache: false,
        type: "get",
        url: "../../ASHX/Province.ashx",
        dataType: "text",
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            if (jsonArr != "") {
                for (var i = 0; i < jsonArr.length; i++) {
                    $(provinceId).append("<option Value=" + jsonArr[i].provinceid + ">" + jsonArr[i].province + "</option>");
                }
            }
            $(provinceHidden).val("");
            $(cityHidden).val("");
            $(areaHidden).val("");
        },
        error: function () {
            alert("系统繁忙，请联系管理员");
        }
    });
    $(provinceId).change(function () {

        $(cityId + " " + "option:gt(0)").remove();
        $(areaId + " " + "option:gt(0)").remove();
        $.post("../../ASHX/City.ashx", { "father": $(provinceId).val() }, function (data) {
            jsonArr = eval('(' + data + ')');
            if (jsonArr != "") {
                for (var i = 0; i < jsonArr.length; i++) {

                    $(cityId).append("<option Value=" + jsonArr[i].cityid + ">" + jsonArr[i].city + "</option>");

                }
            }

        });
        var pro_name = $(provinceId).find("option:selected").text();
        var pro_code = $(provinceId).val();
        if (pro_code == "") {
            $(provinceHidden).val("");
            return;
        } else {
            $(provinceHidden).val(pro_name);
        }

    });
    $(cityId).change(function () {
        $(areaId + " " + "option:gt(0)").remove();
        $.post("../../ASHX/Area.ashx", { "father": $(cityId).val() }, function (data) {
            jsonArr = eval('(' + data + ')');
            if (jsonArr != "") {
                for (var i = 0; i < jsonArr.length; i++) {
                    $(areaId).append("<option Value=" + jsonArr[i].areaid + ">" + jsonArr[i].area + "</option>");

                }
            }
        });
        var cit_name = $(cityId).find("option:selected").text();
        var cit_code = $(cityId).val();
        if (cit_code == "") {
            $(cityHidden).val("");
        } else {
            $(cityHidden).val(cit_name);
        }
    });

    $(areaId).change(function () {
        var are_name = $(areaId).find("option:selected").text();
        var are_code = $(areaId).val();
        if (are_code == "") {
            $(areaHidden).val("");
        } else {
            $(areaHidden).val(are_name);
        }
    });

}

function loadUpdateCA(pCode, cityId, cCdoe, areaId, aCode) {
   $.post("../../ASHX/City.ashx", { "father": pCode }, function (data) {
        jsonArr = eval('(' + data + ')');
        if (jsonArr != "") {
            for (var i = 0; i < jsonArr.length; i++) {
                if (jsonArr[i].cityid == cCdoe) {
                    $(cityId).append("<option selected='selected' Value=" + jsonArr[i].cityid + ">" + jsonArr[i].city + "</option>");
                } else {
                    $(cityId).append("<option Value=" + jsonArr[i].cityid + ">" + jsonArr[i].city + "</option>");
                }
                
            }
        }

    });
    $.post("../../ASHX/Area.ashx", { "father":cCdoe }, function (data) {
        jsonArr = eval('(' + data + ')');
        if (jsonArr != "") {
            for (var i = 0; i < jsonArr.length; i++) {
                if (jsonArr[i].areaid == aCode) {
                    $(areaId).append("<option selected='selected' Value=" + jsonArr[i].areaid + ">" + jsonArr[i].area + "</option>");
                } else {
                    $(areaId).append("<option Value=" + jsonArr[i].areaid + ">" + jsonArr[i].area + "</option>");
                }
                
            }
        }
    });

}
function loadTeacher(deptCode, teacherId) {
   $.ajax({
        cache: false,
        type: "get",
        url: "../../ASHX/Initial.ashx",
        dataType: "text",
        data: { action: "GetTeachers", DeptCode: deptCode },
        success: function (data) {
            var jsonArr = eval("(" + data + ")");
            var Teacher = jsonArr.Teacher;
            for (var i = 0; i < Teacher.length; i++) {
                if (Teacher[i].name == teacherId) {
                    $("#Teacher").append("<option selected='selected' value=" + Teacher[i].name + ">" + Teacher[i].real_name + "</option>");
                } else {
                    $("#Teacher").append("<option value=" + Teacher[i].name + ">" + Teacher[i].real_name + "</option>");
                }
                
           }
            
        },
        error: function () {
            alert("系统繁忙，请联系管理员");
        }
    });

}
