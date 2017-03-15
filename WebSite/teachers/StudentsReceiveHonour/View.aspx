<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="teachers_StudentsReceiveHonour_View" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>获奖记录</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/InitialStudents/InitialInformation.js"></script>
    <script type="text/javascript">
        var id = "<%=id%>";
        var pi = "<%=pi%>";
        var tag = "<%=tag%>";
        $(function () {
           

            if (id != "") {
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }
        });
       
        function loadAllData(id) {
            $.ajax({
                cache: false,
                type: "get",
                url: "../../students/ReceiveHonour/ashx/loadAllData.ashx",
                dataType: "text",
                data: { id: id },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    var json = jsonArr.data[0];
                    if (json == null) { return; } else {
                        $("#RotaryDept option:selected").text(json.DeptName);
                        $("#Teacher option:selected").text(json.TeacherName);
                        $("#Id").val(json.Id);
                        $("#StudentsRealName").val(json.StudentsRealName);
                        $("#StudentsName").val(json.StudentsName);
                        $("#TrainingBaseCode").val(json.TrainingBaseCode);
                        $("#TrainingBaseName").val(json.TrainingBaseName);
                        $("#ProfessionalBaseCode").val(json.ProfessionalBaseCode);
                        $("#ProfessionalBaseName").val(json.ProfessionalBaseName);
                        $("#RotaryDept").val(json.DeptCode);
                        $("#DeptName").val(json.DeptName);
                        $("#RegisterDate").val(json.RegisterDate);
                        $("#Writor").val(json.Writor);
                        $("#Teacher").val(json.TeacherId);
                        $("#TeacherName").val(json.TeacherName);
                        $("#Comment").val(json.Comment);

                        $("#HonourName").val(json.HonourName);
                        $("#HonourDepartment").val(json.HonourDepartment);
                        $("#HonourDetail").val(json.HonourDetail);
                        $("#HonourDate").val(json.HonourDate);


                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1">
        <div align="center">
            <input type="hidden"id="Id"name="Id" />
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">获奖记录</td>
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
                            </select><input type="hidden"id="DeptName"name="DeptName" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <select id="Teacher" name="Teacher" style="width:150px">
                                <option value="-1">==请选择==</option>
                            </select><input type="hidden"id="TeacherName"name="TeacherName" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">表扬事由/获奖名称<span style="color: #ff0000">*</span></td>
                    <td width="35%"class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text"id="HonourName"name="HonourName"style="width:150px;" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;">表扬/获奖部门<span style="color: #ff0000">*</span></td>
                    <td width="35%" colspan="3" class="detailContent" style="height:25px;">
                        <span class="detailContent" style="height: 25px">
                            <input type="text"id="HonourDepartment"name="HonourDepartment"style="width:150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">获奖详情</td>
                    <td width="70%" class="detailContent" style="height: 25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <textarea id="HonourDetail" name="HonourDetail" rows=""cols="" style="width: 100%; height: 110px;"></textarea>
                        </span>
                    </td>

                </tr>
                
                <tr>
                    
                    <td width="15%" class="detailTitle" style="height: 25px;">日期<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height:25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <input type="text" id="HonourDate" name="HonourDate" style="width: 150px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="70%" class="detailContent" style="height: 25px;" colspan="3">
                        <span class="detailContent" style="height: 25px">
                            <textarea id="Comment" name="Comment" rows=""cols="" style="width: 100%; height: 100px;"></textarea>
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
                                        <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
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


