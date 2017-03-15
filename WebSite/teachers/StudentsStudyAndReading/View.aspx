<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="teachers_StudentsStudyAndReading_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学习和阅读</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            var id = "<%=id%>";
            var pi = "<%=pi%>";
            var tag = "<%=tag%>";
            var action;
           

            if (id != "") {
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }
            function loadAllData(id) {
                $.ajax({
                    cache: false,
                    type: "get",
                    url: "../../students/StudyAndReading/ashx/loadAllData.ashx",
                    dataType: "text",
                    data: { id: id },
                    success: function (data) {
                        var jsonArr = eval("(" + data + ")");
                        var json = jsonArr.data[0];
                        if (json == null) { return; } else {
                            $("#StudentsRealName").val(json.StudentsRealName);
                            $("#TrainingBaseName").val(json.TrainingBaseName);
                            $("#ProfessionalBaseName").val(json.ProfessionalBaseName);
                            $("#RotaryDept option:selected").text(json.DeptName);
                            $("#Teacher option:selected").text(json.TeacherName);
                            $("#RotaryDept").val(json.DeptCode);
                            //loadTeachers(json.DeptCode, json.TeacherId)
                            $("#ActivityForm").val(json.ActivityForm); $("#ActivityContent").val(json.ActivityContent);
                            $("#ActivityDate").val(json.ActivityDate); $("#LanguageType").val(json.LanguageType);
                            $("#ClassHour").val(json.ClassHour); $("#MainSpeaker").val(json.MainSpeaker);
                            $("#SuperiorDoctor").val(json.SuperiorDoctor); $("#Comment").val(json.Comment);
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });
            }
            function loadTeachers(DeptCode, TeacherId) {
                $.ajax({
                    cache: false,
                    type: "get",
                    url: "../../ASHX/Initial.ashx",
                    dataType: "text",
                    data: { action: "GetTeachers", DeptCode: DeptCode },
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
                                if (Teacher[i].name == TeacherId) {
                                    $("#Teacher").append("<option value=" + Teacher[i].name + " selected='selected'>" + Teacher[i].real_name + "</option>");
                                } else {
                                    $("#Teacher").append("<option value=" + Teacher[i].name + ">" + Teacher[i].real_name + "</option>");
                                }

                            }
                        }

                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }
                });


            }

        });
    </script>
</head>
<body style="background-color: #efebef;">
    <form id="form1">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">学习和阅读</td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="StudentsRealName" name="StudentsRealName" readonly="readonly" style="width: 150px;"/>
                            <input type="hidden" id="StudentsName" name="StudentsName"/>
                        </span>
                    </td>

                </tr>

                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="TrainingBaseName" name="TrainingBaseName" readonly="readonly" style="width: 150px;" />
                            <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="ProfessionalBaseName" name="ProfessionalBaseName" readonly="readonly" style="width: 150px;" />
                            <input type="hidden" id="ProfessionalBaseCode" name="ProfessionalBaseCode" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="RotaryDept" name="RotaryDept" style="width:200px">
                               <option value="-1" >==请选择==</option>
                            </select>
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="Teacher" name="Teacher" style="width:150px">
                                <option value="-1">==请选择==</option>
                            </select>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">活动形式<span style="color: #ff0000">*</span></td>
                    <td width="70%" colspan="3" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="ActivityForm" name="ActivityForm">
                                <option value="-1">==请选择==</option>
                                <option value="专业学习">专业学习</option>
                                <option value="英语学习">英语学习</option>
                                <option value="文献综述阅读">文献综述阅读</option>
                                <option value="文献综述撰写">文献综述撰写</option>
                                <option value="读书报告">读书报告</option>
                                <option value="病例报告">病例报告</option>
                                <option value="其他形式的学习和阅读">其他形式的学习和阅读</option>
                            </select>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">内容(题目)<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height: 25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <textarea id="ActivityContent" name="ActivityContent" style="width: 100%; height:120px;"></textarea>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" class="detailContent">
                        <table>
                            <tr>
                                <td width="15%" class="detailTitle" style="height: 25px;">日期<span style="color: #ff0000">*</span></td>
                                <td width="15%" class="detailContent" style="height: 25px;">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="ActivityDate" name="ActivityDate" style="width: 100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />
                                    </span>
                                </td>
                                <td width="15%" class="detailTitle" style="height: 25px;">语种</td>
                                <td width="15%" class="detailContent" style="height: 25px;" colspan="3">
                                    <span class="detailContent" style="height: 25px">
                                        <select id="LanguageType" name="Language">
                                            <option value="-1">==请选择==</option>
                                            <option value="中文">中文</option>
                                            <option value="英文">英文</option>
                                            <option value="其他">其他</option>
                                        </select>
                                    </span>
                                </td>
                                <td width="15%" class="detailTitle" style="height: 25px;">学时</td>
                                <td width="15%" class="detailContent" style="height: 25px;">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="ClassHour" name="ClassHour" style="width: 100px;" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">主讲人</td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="MainSpeaker" name="MainSpeaker" style="width: 150px;" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">上级医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="SuperiorDoctor" name="SuperiorDoctor" style="width: 150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="70%" class="detailContent" style="height: 25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <textarea id="Comment" name="Comment" style="width: 100%; height: 100px;"></textarea>
                        </span>
                    </td>

                </tr>
                <tr>
                     
                    <td width="100%" class="detailContent" style="height: 25px" colspan="5">
                        <table align="right">
                            <tr>
 
                                <td width="20%" class="detailTitle" style="height: 25px">填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="Writor" name="Writor" style="width: 100px;"/>
                                    </span>
                                </td>
                                <td width="30%" class="detailTitle" style="height: 25px">登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px;" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="last">
                    <td colspan="6" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <input id="SaveAndUpdate" name="SaveAndUpdate" type="button" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;"/>
                            <a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();"/>

                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </form>

</body>
</html>

