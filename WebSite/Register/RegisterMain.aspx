<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterMain.aspx.cs" Inherits="Register_RegisterMain" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人员注册</title>
    <script src="../js/jquery-1.7.2.js"></script>
    <link href="../css/global.css" rel="stylesheet" />
    <script src="../js/jquery-easyui-1.3.6/jquery.easyui.min.js"></script>
    <link href="../js/jquery-easyui-1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="../js/jquery-easyui-1.3.6/themes/default/easyui.css" rel="stylesheet" />
    <style type="text/css">
        <!--
        .STYLE20 a:hover {
            font-size: 16px;
            color: #ffffff;
            text-decoration: none;
        }

        {
            font-size: 15px;
            font-family: "宋体";
            color: #FFFFFF;
        }

        .STYLE79 a:hover {
            font-size: 15px;
            color: #ffffff;
            text-decoration: none;
        }

        {
            font-size: 14px;
            font-family: "宋体";
            color: #FFFFFF;
        }

        .STYLE21 {
            font-size: 14px;
            line-height: 20px;
        }

        .STYLE22 {
            font-size: 12px;
            vertical-align: 1%;
            line-height: normal;
        }

        .STYLE25 {
            font-size: 14px;
            line-height: 15px;
        }

        .STYLE29 {
            font-family: "Times New Roman", Times, serif;
            font-size: 12px;
            vertical-align: 5%;
            line-height: normal;
            color: #000080;
        }

        .STYLE27 {
            font-size: 12px;
        }

        .STYLE28 {
            font-size: 10px;
            color: black;
        }

        a:link {
            text-decoration: none;
            color: #0000FF;
        }

        a:visited {
            color: #0000FF;
            text-decoration: none;
        }

        a:active {
            color: #0000FF;
            text-decoration: none;
        }

        .STYLE36 {
            font-family: "宋体";
        }

        a {
            color: #000080;
        }

        .STYLE40 {
            font-size: 12px;
            color: #000080;
        }

        .STYLE46 {
            font-size: 10pt;
        }

        .STYLE56 {
            font-size: 15px;
            color: #FFFFFF;
        }

        .STYLE63 {
            color: #000099;
        }

        .STYLE66 {
            font-size: 14px;
            line-height: 15px;
            color: #000099;
        }

        BODY {
            COLOR: #000000;
            FONT-SIZE: 10pt;
        }

        UL {
            FONT-SIZE: 10pt;
        }

        .STYLE69 {
            font-size: 10pt;
            line-height: 20px;
            color: #009933;
        }

        .STYLE76 {
            font-size: 14px;
        }

        .STYLE78 {
            color: #000080;
        }

        .STYLE79 {
            font-size: 15pt;
        }

        .STYLE80 {
            font-size: 15px;
        }

        #newsIframe {
            height: 21px;
        }

        .auto-style2 {
            height: 89px;
        }

        .auto-style4 {
            width: 612px;
        }

        .auto-style5 {
            height: 174px;
        }

        .auto-style7 {
            height: 30px;
            width: 290px;
            border: 0px;
        }

        .button {
            width: 61px;
            height: 23px;
        }

        #bottominfo {
            height: 41px;
        }

        .auto-style12 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            color: #000000;
            height: 20px;
            width: 91px;
        }

        .auto-style14 {
            font-size: 14px;
            line-height: 15px;
            color: #000099;
            height: 25px;
        }

        .auto-style15 {
            height: 25px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $.post("ashx/ProvinceName.ashx",
                  function (data) {
                      jsonArr = eval('(' + data + ')');
                      if (jsonArr != "") {
                          for (var i = 0; i < jsonArr.length; i++) {
                              $("#StudentsProvince").append("<option Value=" + jsonArr[i].province_code + ">" + jsonArr[i].province_name + "</option>");
                              $("#TeachersProvince").append("<option Value=" + jsonArr[i].province_code + ">" + jsonArr[i].province_name + "</option>");
                              $("#BasesProvince").append("<option Value=" + jsonArr[i].province_code + ">" + jsonArr[i].province_name + "</option>");
                              $("#ManagersProvince").append("<option Value=" + jsonArr[i].province_code + ">" + jsonArr[i].province_name + "</option>");
                          }
                      }

                  });

            $.post("ashx/ProfessionalBase.ashx", function (data) {
                jsonArr = eval('(' + data + ')');
                if (jsonArr != "") {
                    for (var i = 0; i < jsonArr.length; i++) {
                        $("#TeachersProfessionalBaseCode").append("<option Value=" + jsonArr[i].professional_base_code + ">" + jsonArr[i].professional_base_name + "</option>");
                        $("#BasesProfessionalBaseCode").append("<option Value=" + jsonArr[i].professional_base_code + ">" + jsonArr[i].professional_base_name + "</option>");
                    }
                }
            });
            $("#TeachersProfessionalBaseCode").change(function () {
                $("#TeachersDeptCode option:gt(0)").remove();
                $.post("ashx/Dept.ashx", { 'ProfessionalBaseCode': $("#TeachersProfessionalBaseCode").val()}, function (data) {
                    jsonArr = eval('(' + data + ')');
                    if (jsonArr != "") {
                        for (var i = 0; i < jsonArr.length; i++) {
                            $("#TeachersDeptCode").append("<option Value=" + jsonArr[i].dept_code + ">" + jsonArr[i].dept_name + "</option>");
                           
                        }
                    }
                });

            });

            $("#StudentsSave").click(function () {
                if ($("#StudentsName").val() == "") { alert("用户名不能为空"); return false; }
                if ($("#StudentsRealName").val() == "") { alert("真实姓名不能为空"); return false; }
                if ($("#StudentsPassword").val() == "") { alert("密码不能为空"); return false; }
                if ($("#StudentsPassword2").val() == "") { alert("确认密码不能为空"); return false; }
                if ($("#StudentsProvince").val() == "") { alert("所属基地省份不能为空"); return false; }
                if ($("#StudentsTrainingBaseCode").val() == "") { alert("培训基地不能为空"); return false; }
                if ($("#StudentsPassword").val() != $("#StudentsPassword2").val()) {
                    alert("两次输入密码不一致，请重新输入");
                    $("#StudentsPassword").val("");
                    $("#StudentsPassword2").val("");
                    $("#StudentsPassword").focus();
                }
                $("#StudentsTrainingBaseName").val($("#StudentsTrainingBaseCode").find("option:selected").text());
                var forms = $("#form1").serializeArray();
                
                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/StudentsAdd.ashx",
                    dataType: "text",//如果是json的话，不用eval()在解析
                    data:forms,
                    success: function (data) {
                        if (data == "addSuccess") {
                            alert("注册成功");
                        } else {
                            alert("注册失败");
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }

                });
            });

            $("#TeachersSave").click(function () {
                if ($("#TeachersName").val() == "") { alert("用户名不能为空"); return false; }
                if ($("#TeachersRealName").val() == "") { alert("真实姓名不能为空"); return false; }
                if ($("#TeachersPassword").val() == "") { alert("密码不能为空"); return false; }
                if ($("#TeachersPassword2").val() == "") { alert("确认密码不能为空"); return false; }
                if ($("#TeachersProvince").val() == "") { alert("所属基地省份不能为空"); return false; }
                if ($("#TeachersTrainingBaseCode").val() == "") { alert("培训基地不能为空"); return false; }
                if ($("#TeachersProfessionalBaseCode").val() == "") { alert("所在专业基地不能为空"); return false; }
                if ($("#TeachersDeptCode").val() == "") { alert("所在科室不能为空"); return false; }
                if ($("#TeachersPassword").val() != $("#TeachersPassword2").val()) {
                    alert("两次输入密码不一致，请重新输入");
                    $("#TeachersPassword").val("");
                    $("#TeachersPassword2").val("");
                    $("#TeachersPassword").focus();
                }
                $("#TeachersTrainingBaseName").val($("#TeachersTrainingBaseCode").find("option:selected").text());
                $("#TeachersProfessionalBaseName").val($("#TeachersProfessionalBaseCode").find("option:selected").text());
                $("#TeachersDeptName").val($("#TeachersDeptCode").find("option:selected").text());
                var forms = $("#form1").serializeArray();

                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/TeachersAdd.ashx",
                    dataType: "text",//如果是json的话，不用eval()在解析
                    data: forms,
                    success: function (data) {
                        if (data == "addSuccess") {
                            alert("注册成功");
                        } else {
                            alert("注册失败");
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }

                });
            });

            $("#BasesSave").click(function () {
                if ($("#BasesName").val() == "") { alert("用户名不能为空"); return false; }
                if ($("#BasesRealName").val() == "") { alert("真实姓名不能为空"); return false; }
                if ($("#BasesPassword").val() == "") { alert("密码不能为空"); return false; }
                if ($("#BasesPassword2").val() == "") { alert("确认密码不能为空"); return false; }
                if ($("#BasesProvince").val() == "") { alert("所属基地省份不能为空"); return false; }
                if ($("#BasesTrainingBaseCode").val() == "") { alert("培训基地不能为空"); return false; }
                if ($("#BasesProfessionalBaseCode").val() == "") { alert("所在专业基地不能为空"); return false; }
                
                if ($("#BasesPassword").val() != $("#BasesPassword2").val()) {
                    alert("两次输入密码不一致，请重新输入");
                    $("#BasesPassword").val("");
                    $("#BasesPassword2").val("");
                    $("#BasesPassword").focus();
                }
                $("#BasesTrainingBaseName").val($("#BasesTrainingBaseCode").find("option:selected").text());
                $("#BasesProfessionalBaseName").val($("#BasesProfessionalBaseCode").find("option:selected").text());
                
                var forms = $("#form1").serializeArray();

                $.ajax({
                    cache: false,
                    type: "post",
                    url: "ashx/BasesAdd.ashx",
                    dataType: "text",//如果是json的话，不用eval()在解析
                    data: forms,
                    success: function (data) {
                        if (data == "addSuccess") {
                            alert("注册成功");
                        } else {
                            alert("注册失败");
                        }
                    },
                    error: function () {
                        alert("系统繁忙，请联系管理员");
                    }

                });
            });

            //$("#ManagersSave").click(function () {
            //    if ($("#ManagersName").val() == "") { alert("用户名不能为空"); return false; }
            //    if ($("#ManagersRealName").val() == "") { alert("真实姓名不能为空"); return false; }
            //    if ($("#ManagersPassword").val() == "") { alert("密码不能为空"); return false; }
            //    if ($("#ManagersPassword2").val() == "") { alert("确认密码不能为空"); return false; }
            //    if ($("#ManagersProvince").val() == "") { alert("所属基地省份不能为空"); return false; }
            //    if ($("#ManagersTrainingBaseCode").val() == "") { alert("培训基地不能为空"); return false; }
            //    if ($("#ManagersPassword").val() != $("#ManagersPassword2").val()) {
            //        alert("两次输入密码不一致，请重新输入");
            //        $("#ManagersPassword").val("");
            //        $("#ManagersPassword2").val("");
            //        $("#ManagersPassword").focus();
            //    }
            //    $("#ManagersTrainingBaseName").val($("#ManagersTrainingBaseCode").find("option:selected").text());
            //    var forms = $("#form1").serializeArray();

            //    $.ajax({
            //        cache: false,
            //        type: "post",
            //        url: "ashx/ManagersAdd.ashx",
            //        dataType: "text",//如果是json的话，不用eval()在解析
            //        data: forms,
            //        success: function (data) {
            //            if (data == "addSuccess") {
            //                alert("注册成功");
            //            } else {
            //                alert("注册失败");
            //            }
            //        },
            //        error: function () {
            //            alert("系统繁忙，请联系管理员");
            //        }

            //    });
            //});

        });

        function TrainingBase(type1, type2) {
            $(type2+" option:gt(0)").remove();
            $.post("ashx/HospitalName.ashx", { 'ProvinceCode': $(type1).val() },
                  function (data) {
                      jsonArr = eval('(' + data + ')');
                      if (jsonArr != "") {
                          for (var i = 0; i < jsonArr.length; i++) {
                              $(type2).append("<option Value=" + jsonArr[i].hospital_code + ">" + jsonArr[i].hospital_name + "</option>");
                          }
                      }

                  });
        }

        function checkPassword(p1,p2,t) {
            var psw1 = $(p1).val();
            var length1 = $(p1).val().length;

            var psw2 = $(p2).val();
            var length2 = $(p2).val().length;
            if (length1 < 6) {
                $(t).text("密码长度不得小于六位");
                $(p1).val(""); $(p2).val("");
                $(p1).focus();
                return;
            }
            if (length1 == length2) {
                if (psw1 == psw2) {
                    $(t).text("两次输入密码一致");
                } else {
                    $(t).text("密码输入不一致，请重新输入");
                    $(p1).val(""); $(p2).val("");
                    $(p1).focus();
                }
            }

        }

        function checkName(id) {
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/checkName.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: { 'name': $(id).val() },
                success: function (data) {
                    if (data=="1") {
                        return;
                    } else {
                        alert("用户名已存在，请重新输入");
                        $(id).val("");
                        $(id).focus();
                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }


    </script>

</head>
<body style="text-align: center; background-color: #FFFFFF; margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; overflow-x: hidden;" marginwidth="0" marginheight="0">
    <center>   
    <form id="form1" runat="server" name="form1" target="_blank">

        <table style="width:1000px;height:811px;border:0px;" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="height:114px;" colspan="3">

                        <iframe style="width: 997px" frameborder="0" scrolling="no" height="111" src="../index/top.html"></iframe>
                    </td>

                </tr>
                <tr>
                    <td style="height:700px;width:143px" valign="top">
                        <iframe frameborder="0px" scrolling="no" src="../index/right.html" style="width: 152px; margin-right: 1px; height: 557px;"></iframe>

                    </td>
                    <td valign="top" class="auto-style4">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 682px; height: 520px; margin-left: 0px;">
                            <tr>
                                <td align="center" colspan="2" class="auto-style2">
                                  <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="667" height="80">
                                  <param name="movie" value="../index/swf/zyys.swf">
                                  <param name="quality" value="high">
                                  <embed src="../index/swf/zyys.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="667" height="80"></embed>
                                  </object>
                                </td>
                            </tr>
                        <tr>
                        <td style="width:375px;">
                        <table style="width:676px;height:500px; text-align:center; margin:auto;"  border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height:20px;width:676px"align="left" valign="bottom"><a style="font-size:19px;font-family:KaiTi;font-weight:900;color:#000;text-align:center" >新用户注册</a><a style="padding-left:50px"></a><span class="STYLE28">带有"<span style="color: #ff0000">*</span>"的项目必须填写</span></td>
                               
                           </tr>
                            <tr>
                                <td height="10"><img src="../images/gif066.gif" alt="gp" width="676" height="2"/></td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div id="tt" class="easyui-tabs" style="width:690px;height:350px;text-align:center;">
		                                <div title="学员" style="text-align:center;">
                                           <table>
                                               <tr>
                                                <td align="right" style="width:100px;padding-top:2px">用户名：</td>
                                                <td  align="left" style="width:400px">
                                                    <input type="text" id="StudentsName" name="StudentsName" style="width:150px" onblur="checkName('#StudentsName');"/>
                                                 <span style="color: #ff0000">*</span><span>可由字母、数字、下划线组成</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">真实姓名：</td>
                                                <td  style="padding-top:2px" align="left">
                                                    <input type="text" id="StudentsRealName" name="StudentsRealName" style="width:150px"/>
                                                 <span style="color: #ff0000">*</span><span>请正确填写</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">密码：</td>
                                                <td  style="padding-top:2px" align="left"><span  class="tbl-txt">
                                                    <input type="password" id="StudentsPassword" name="StudentsPassword" style="width:150px"/></span>
                                                 <span style="color: #ff0000">*</span><span>请输入6-20个字符长度的密码</span></td>
                                            </tr>
                                            
                                            <tr>
                                                <td  align="right"  style="padding-top:2px">确认密码：</td>
                                                <td  style="padding-top:2px" align="left" colspan="3">
                                                    <input type="password" id="StudentsPassword2" name="StudentsPassword2" style="width:150px" onkeyup="checkPassword('#StudentsPassword','#StudentsPassword2','#StudentsTip');"/>
                                                    <span style="color: #ff0000"><label id="StudentsTip"></label></span>
                                                    </td>
                                            </tr>
                                               <tr>
                                                <td align="right"  style="padding-top:2px">所属培训基地：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    <select id="StudentsProvince" name="StudentsProvince" onchange="TrainingBase('#StudentsProvince','#StudentsTrainingBaseCode');">
                                                        <option value="">==请选择省份==</option>
                                                    </select>
                                                    <select id="StudentsTrainingBaseCode"name="StudentsTrainingBaseCode" >
                                                        <option value="">==请选择培训基地==</option>
                                                    </select><input type="hidden" id="StudentsTrainingBaseName" name="StudentsTrainingBaseName" /></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td  align="left"  style="padding-top:5px;padding-left:10px;" colspan="3">
                                                    <input id="StudentsSave" name="StudentsSave" type="button" class="button" value="确认提交" style="width:61px;height:25px;"/>
                                                    <a style="padding-left:5px;"></a>
                                                    <input id="StudentsReset" name="StudentsReset" type="button" value="重置" style="width:61px;height:25px;" onclick="form1.reset();"/>
                                                </td>
                                               
                                            </tr>
                                           </table>
		                                </div>
                                           <div title="指导医师" style="text-align:center;">
                                               <table>
                                               <tr>
                                                <td align="right" style="width:100px;padding-top:2px">用户名：</td>
                                                <td  align="left" style="width:400px">
                                                    <input type="text" id="TeachersName" name="TeachersName" style="width:150px" onblur="checkName('#TeachersName');"/>
                                                 <span style="color: #ff0000">*</span><span>可由字母、数字、下划线组成</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">真实姓名：</td>
                                                <td  style="padding-top:2px" align="left">
                                                    <input type="text" id="TeachersRealName" name="TeachersRealName" style="width:150px"/>
                                                 <span style="color: #ff0000">*</span><span>请正确填写</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">密码：</td>
                                                <td  style="padding-top:2px" align="left"><span  class="tbl-txt">
                                                    <input type="password" id="TeachersPassword" name="TeachersPassword" style="width:150px"/></span>
                                                 <span style="color: #ff0000">*</span><span>请输入6-20个字符长度的密码</span></td>
                                            </tr>
                                            
                                            <tr>
                                                <td  align="right"  style="padding-top:2px">确认密码：</td>
                                                <td  style="padding-top:2px" align="left" colspan="3">
                                                    <input type="password" id="TeachersPassword2" name="TeachersPassword2" style="width:150px" onkeyup="checkPassword('#TeachersPassword','#TeachersPassword2','#TeachersTip');"/>
                                                     <span style="color: #ff0000"><label id="TeachersTip"></label></span>
                                                    </td>
                                            </tr>
                                               <tr>
                                                <td align="right"  style="padding-top:2px">所属培训基地：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    <select id="TeachersProvince" name="TeachersProvince" onchange="TrainingBase('#TeachersProvince','#TeachersTrainingBaseCode');">
                                                        <option value="">==请选择省份==</option>
                                                    </select>
                                                    <select id="TeachersTrainingBaseCode"name="TeachersTrainingBaseCode" >
                                                        <option value="">==请选择培训基地==</option>
                                                    </select><input type="hidden" id="TeachersTrainingBaseName" name="TeachersTrainingBaseName" />
                                                 </td>
                                            </tr>
                                                   <tr>
                                                <td align="right"  style="padding-top:2px">所在专业基地：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    <select id="TeachersProfessionalBaseCode" name="TeachersProfessionalBaseCode">
                                                        <option value="">==请选择专业基地==</option>
                                                    </select><input type="hidden" id="TeachersProfessionalBaseName" name="TeachersProfessionalBaseName" />
                                                    
                                                </td>
                                            </tr>
                                                    <tr>
                                                <td align="right"  style="padding-top:2px">所在科室：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    
                                                    <select id="TeachersDeptCode"name="TeachersDeptCode" >
                                                        <option value="">==请选择所在科室==</option>
                                                    </select><input type="hidden" id="TeachersDeptName" name="TeachersDeptName" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td></td>
                                                <td  align="left"  style="padding-top:5px;padding-left:10px;" colspan="3">
                                                    <input id="TeachersSave" name="TeachersSave" type="button" class="button" value="确认提交" style="width:61px;height:25px;" />
                                                    <a style="padding-left:5px;"></a>
                                                    <input id="TeachersReset" name="TeachersReset" type="button" value="重置" style="width:61px;height:25px;"onclick="form1.reset();"/>
                                                </td>
                                               
                                            </tr>
                                           </table>
		                                  </div>
                                           <div title="专业基地负责人" style="text-align:center;">
                                                <table>
                                               <tr>
                                                <td align="right" style="width:100px;padding-top:2px">用户名：</td>
                                                <td  align="left" style="width:400px">
                                                    <input type="text" id="BasesName" name="BasesName" style="width:150px" onblur="checkName('#BasesName');"/>
                                                 <span style="color: #ff0000">*</span><span>可由字母、数字、下划线组成</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">真实姓名：</td>
                                                <td  style="padding-top:2px" align="left">
                                                    <input type="text" id="BasesRealName" name="BasesRealName" style="width:150px"/>
                                                 <span style="color: #ff0000">*</span><span>请正确填写</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">密码：</td>
                                                <td  style="padding-top:2px" align="left"><span  class="tbl-txt">
                                                    <input type="password" id="BasesPassword" name="BasesPassword" style="width:150px"/></span>
                                                 <span style="color: #ff0000">*</span><span>请输入6-20个字符长度的密码</span></td>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td  align="right"  style="padding-top:2px">确认密码：</td>
                                                <td  style="padding-top:2px" align="left" colspan="3">
                                                    <input type="password" id="BasesPassword2" name="BasesPassword2" style="width:150px" onkeyup="checkPassword('#BasesPassword','#BasesPassword2','#BasesTip');"/>
                                                    <span style="color: #ff0000"><label id="BasesTip"></label></span></td>
                                            </tr>
                                               <tr>
                                                <td align="right"  style="padding-top:2px">所属培训基地：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    <select id="BasesProvince" name="BasesProvince" onchange="TrainingBase('#BasesProvince','#BasesTrainingBaseCode');">
                                                        <option value="">==请选择省份==</option>
                                                    </select>
                                                    <select id="BasesTrainingBaseCode"name="BasesTrainingBaseCode" >
                                                        <option value="">==请选择培训基地==</option>
                                                    </select><input type="hidden" id="BasesTrainingBaseName" name="BasesTrainingBaseName" /></td>
                                            </tr>
                                                   <tr>
                                                <td align="right"  style="padding-top:2px">所在专业基地：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    <select id="BasesProfessionalBaseCode" name="BasesProfessionalBaseCode">
                                                        <option value="">==请选择专业基地==</option>
                                                    </select><input type="hidden" id="BasesProfessionalBaseName" name="BasesProfessionalBaseName" />
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td  align="left"  style="padding-top:5px;padding-left:10px;" colspan="3">
                                                    <input id="BasesSave" name="BasesSave" type="button" class="button" value="确认提交" style="width:61px;height:25px;" />
                                                    <a style="padding-left:5px;"></a>
                                                    <input id="BasesReset" name="BasesReset" type="button" value="重置" style="width:61px;height:25px;"onclick="form1.reset();"/>
                                                </td>
                                               
                                            </tr>
                                           </table>
		                                </div>
                                           <%--<div title="管理员" style="text-align:center;">
                                                <table>
                                               <tr>
                                                <td align="right" style="width:100px;padding-top:2px">用户名：</td>
                                                <td  align="left" style="width:400px">
                                                    <input type="text" id="ManagersName" name="ManagersName" style="width:150px" onblur="checkName('#ManagersName');"/>
                                                 <span style="color: #ff0000">*</span><span>可由字母、数字、下划线组成</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">真实姓名：</td>
                                                <td  style="padding-top:2px" align="left">
                                                    <input type="text" id="ManagersRealName" name="ManagersRealName" style="width:150px"/>
                                                 <span style="color: #ff0000">*</span><span>请正确填写</span></td>
                                            </tr>
                                            <tr>
                                                <td align="right"  style="padding-top:2px">密码：</td>
                                                <td  style="padding-top:2px" align="left"><span  class="tbl-txt">
                                                    <input type="password" id="ManagersPassword" name="ManagersPassword" style="width:150px" /></span>
                                                 <span style="color: #ff0000">*</span><span>请输入6-20个字符长度的密码</span></td>

                                            </tr>
                                            
                                            <tr>
                                                <td  align="right"  style="padding-top:2px">确认密码：</td>
                                                <td  style="padding-top:2px" align="left" colspan="3">
                                                    <input type="password" id="ManagersPassword2" name="ManagersPassword2" style="width:150px" onkeyup="checkPassword('#ManagersPassword','#ManagersPassword2','#ManagersTip');"/>
                                                    <span style="color: #ff0000"><label id="ManagersTip"></label></span></td>
                                                
                                            </tr>
                                               <tr>
                                                <td align="right"  style="padding-top:2px">所属培训基地：</td>
                                                <td  style="padding-top:2px" align="left" class="auto-style15">
                                                    <select id="ManagersProvince" name="ManagersProvince" onchange="TrainingBase('#ManagersProvince','#ManagersTrainingBaseCode');">
                                                        <option value="">==请选择省份==</option>
                                                    </select>
                                                    <select id="ManagersTrainingBaseCode"name="ManagersTrainingBaseCode" >
                                                        <option value="">==请选择培训基地==</option>
                                                    </select><input type="hidden" id="ManagersTrainingBaseName" name="ManagersTrainingBaseName" /></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td  align="left"  style="padding-top:5px;padding-left:10px;" colspan="3">
                                                    <input id="ManagersSave" name="ManagersSave" type="button" class="button" value="确认提交" style="width:61px;height:25px;" onclick="alert('请联系系统管理员，进行入库注册');"/>
                                                    <a style="padding-left:5px;"></a>
                                                    <input id="ManagersReset" name="ManagersReset" type="button" value="重置" style="width:61px;height:25px;" onclick="form1.reset();"/>
                                                </td>
                                               
                                            </tr>
                                           </table>
		                                </div>--%>

	                                 </div>
                                  </td>
                             </tr>
                            
                        </table>
                        </td>
                    
                            </tr>
                     </table>
                     </td>
                    <td width="143" valign="top">
                      <iframe frameborder="0" scrolling="no" src="../index/left.html" style="width: 152px; margin-left: 0px; height: 557px;"></iframe>
                   </td>
                </tr>
            </table>
    </form>
    </center>
</body>
</html>
