<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_SkillRequirement_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>技能要求</title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../../js/global.js"></script>
     <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/InitialStudents/InitialInformation.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        $(function () {
            Initial();

            $("#Teacher").change(function () {
                var DeptCode = $("#RotaryDept").val();
                var DeptName = $("#RotaryDept option:selected").text();
                var TeacherId = $("#Teacher option:selected").val();
                var TeacherName = $("#Teacher option:selected").text();
                $("#skill tr:gt(0)").remove();
                if ($("#RotaryDept").val() != "") {
                    var DeptCode = $("#RotaryDept").val();
                    $.post("ashx/SkillRequirement.ashx", { "DeptCode": DeptCode }, function (data) {
                        var jsonArr = eval("(" + data + ")");
                        if (jsonArr.data == null) {

                        } else {
                            var k = 1;
                            for (i = 0; i < jsonArr.data.length; i++) {

                                var trHTML = "<tr class='listTableContentRow'>";
                                if (jsonArr.data[i].SkillCode == null || jsonArr.data[i].SkillCode == "") {

                                } else {
                                    trHTML += "<td align='center'>" + k + "</td>";
                                    trHTML += "<td align='center'>" + jsonArr.data[i].SkillName + "</td>";
                                    if (jsonArr.data[i].RequiredNum == null || jsonArr.data[i].RequiredNum == "") {
                                        trHTML += "<td align='center'>" + '无' + "</td>";
                                    } else {
                                        trHTML += "<td align='center'>" + jsonArr.data[i].RequiredNum + "</td>";
                                    }
                                    trHTML += "<td align='center'>" + jsonArr.data[i].MasterDegree + "</td>";
                                    trHTML += "<td align='center'><font color='#0063ff'>" +
                                        "<a style='text-decoration:none;' " +
                                        "onclick=\"OpenTopWindow('Register.aspx?StudentsName=" + $("#StudentsName").val() + "" +
                                        "&StudentsRealName=" + $("#StudentsRealName").val() + "" +
                                        "&TrainingBaseCode=" + $("#TrainingBaseCode").val() + "" +
                                        "&TrainingBaseName=" + $("#TrainingBaseName").val() + "" +
                                        "&ProfessionalBaseCode=" + $("#ProfessionalBaseCode").val() + "" +
                                        "&ProfessionalBaseName=" + $("#ProfessionalBaseName").val() + "" +
                                        "&DeptCode=" + DeptCode + "" +
                                        "&DeptName=" + DeptName + "" +
                                        "&TeacherId=" + TeacherId + "" +
                                        "&TeacherName=" + TeacherName + "" +
                                        "&Writor=" + $("#Writor").val() + "" +
                                        "&RegisterDate=" + $("#RegisterDate").val() + "" +
                                        "&SkillName=" + jsonArr.data[i].SkillName + "" +
                                        "&RequiredNum=" + jsonArr.data[i].RequiredNum + "" +
                                        "&MasterDegree=" + jsonArr.data[i].MasterDegree + "',520,250);\" " +
                                        "href='#'>登记</a></font></td>";
                                    k += 1;
                                }
                                trHTML += "</tr>";
                                $("#skill").append(trHTML);
                            }
                            $("#skill tr:gt(0)").mouseover(function () {
                                $(this).removeClass("listTableContentRow");
                                $(this).addClass("listTableContentRowMouseOver");
                            });

                            $("#skill tr:gt(0)").mouseout(function () {
                                $(this).removeClass("listTableContentRowMouseOver");
                                $(this).addClass("listTableContentRow");
                            });
                            //$("#disease").append("<tr><td colspan='5'align='left'><input type='button' value='新增病种登记' id='addDisease' name='addDisease' height='25'></td></tr>");
                        }
                        $("#skill").append("<tr><td colspan='5'align='left'><input onclick=\"OpenTopWindow('Register.aspx?StudentsName=" + $("#StudentsName").val() + "" +
                            "&StudentsRealName=" + $("#StudentsRealName").val() + "" +
                                        "&TrainingBaseCode=" + $("#TrainingBaseCode").val() + "" +
                                        "&TrainingBaseName=" + $("#TrainingBaseName").val() + "" +
                                        "&ProfessionalBaseCode=" + $("#ProfessionalBaseCode").val() + "" +
                                        "&ProfessionalBaseName=" + $("#ProfessionalBaseName").val() + "" +
                                        "&DeptCode=" + DeptCode + "" +
                                        "&DeptName=" + DeptName + "" +
                                        "&TeacherId=" + TeacherId + "" +
                                        "&TeacherName=" + TeacherName + "" +
                                        "&Writor=" + $("#Writor").val() + "" +
                                        "&RegisterDate=" + $("#RegisterDate").val() + "" +
                                        "&SkillName=" + "" + "" +
                                        "&RequiredNum=" + ""+ "" +
                                        "&MasterDegree=" + "" + "',520,250);\" " +
                            " type='button' value='新增技能登记' id='addDisease' name='addDisease' height='25'></td></tr>");

                    });

                }

            });

        });

    </script>
</head>
<body>
     <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="8" class="detailHead">技能登记</td>
                </tr>
                <tr>
                    <td width="3%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="6%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                         <input type="text" id="StudentsRealName" name="StudentsRealName" readonly="readonly" style="width: 150px;"/>
                            <input type="hidden" id="StudentsName" name="StudentsName"/>
                        </span>
                    </td>
                    <td width="12%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="15%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="TrainingBaseName" name="TrainingBaseName" readonly="readonly" style="width: 150px;" />
                            <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                    </td>
                    <td width="12%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="15%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="ProfessionalBaseName" name="ProfessionalBaseName" readonly="readonly" style="width: 150px;" />
                            <input type="hidden" id="ProfessionalBaseCode" name="ProfessionalBaseCode" />
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="6">
                        <table style="margin:0 auto">
                            <tr>
                                <td width="25%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                                <td width="25%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <select id="RotaryDept" name="RotaryDept" style="width: 200px">
                                        <option value="">==请选择==</option>
                                    </select><input type="hidden" id="DeptName" name="DeptName" />
                                </span>
                                </td>
                                <td width="25%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                                <td width="25%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <select id="Teacher" name="Teacher" style="width: 150px">
                                        <option value="">==请选择==</option>
                                    </select>
                                    <input type="hidden" id="TeacherName" name="TeacherName" />
                                </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>

                    <td colspan="6">
                        <table width="100%" class="listTable" id="skill" style="border: 1px;border-style: solid">
                            <tr class="listTableTitleRow">
                                <td width="10%" style="height: 25px;" align="center">序号</td>
                                <td width="60%" style="height: 25px;" align="center">技能要求</td>
                                <td width="10%"  style="height: 25px;"align="center">要求例数</td>
                                <td width="10%"  style="height: 25px;" align="center">掌握程度</td>
                                <td width="10%"  style="height: 25px;" align="center">登记</td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center" bgcolor="#f1f3f5">请选择轮转科室进行技能登记</td>
                            </tr>
                            

                        </table>

                    </td>
                </tr>
               
                <tr>
                    <td width="85%" class="detailContent" style="height: 25px" colspan="7">
                        <table align="right">
                            <tr>
                                
                                <td width="20%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <input type="text" id="Writor" name="Writor" style="width: 100px;"/>
                                </span></td>
                                <td width="30%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                                </span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--<tr id="last">
                    <td colspan="8" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;" />
                            <a style="padding-left: 2em"></a>
                            <input type="button"  style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                           
                         </div>
                    </td>
                </tr>--%>
           </table>

        </div>
    </form>
    
</body>
</html>
