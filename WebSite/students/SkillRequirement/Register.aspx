<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="students_SkillRequirement_Register" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>技能名称</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
     <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript">
        var StudentsName = "<%=StudentsName%>";
        var StudentsRealName = "<%=StudentsRealName%>";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var TrainingBaseName = "<%=TrainingBaseName%>";
        var ProfessionalBaseCode = "<%=ProfessionalBaseCode%>";
        var ProfessionalBaseName = "<%=ProfessionalBaseName%>";
        var DeptCode = "<%=DeptCode%>";
        var DeptName = "<%=DeptName%>";
        var TeacherId = "<%=TeacherId%>";
        var TeacherName = "<%=TeacherName%>";
        var RequiredNum = "<%=RequiredNum%>";
        var MasterDegree = "<%=MasterDegree%>";
        var Writor = "<%=Writor%>";
        var RegisterDate = "<%=RegisterDate%>";
        var SkillName = "<%=SkillName%>";

        var id = "<%=id%>";
        var pi = "<%=pi%>";
        var tag = "<%=tag%>";
        $(function () {
            $("#StudentsName").val(StudentsName);
            $("#StudentsRealName").val(StudentsRealName);
            $("#TrainingBaseCode").val(TrainingBaseCode);
            $("#TrainingBaseName").val(TrainingBaseName);
            $("#ProfessionalBaseCode").val(ProfessionalBaseCode);
            $("#ProfessionalBaseName").val(ProfessionalBaseName);
            $("#DeptCode").val(DeptCode);
            $("#DeptName").val(DeptName);
            $("#TeacherId").val(TeacherId);
            $("#TeacherName").val(TeacherName);
            $("#RequiredNum").val(RequiredNum);
            $("#MasterDegree").val(MasterDegree);
            $("#Writor").val(Writor);
            $("#RegisterDate").val(RegisterDate);
            $("#SkillName").val(SkillName);

            if (id != "") {
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }
            $("#SaveAndUpdate").click(function () {
                if (id != "") {
                    update();
                } else {
                    add();
                }
            });
        });

        function add() {
            var forms = $("#form1").serializeArray();
            if ($("#Comment").val() == "") { alert("详细说明不能为空"); return; }
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Add.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: forms,
                success: function (data) {
                    if (data == "addSuccess") {
                        alert("技能登记信息保存成功");
                        self.opener.opener.frames.parent.bodyFrame.frames.frmright.window.loadPageList(1);
                        window.close();
                    } else {
                        alert("技能登记信息保存失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }
        function update() {
            var forms = $("#form1").serializeArray();
            if ($("#Comment").val() == "") { alert("详细说明不能为空"); return; }
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Update.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: forms,
                success: function (data) {
                    if (data == "updateSuccess") {
                        alert("技能登记信息修改成功");
                        self.opener.window.loadPageList(pi);
                        window.close();
                    } else {
                        alert("技能登记信息修改失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }

        function loadAllData(id) {
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/loadAllData.ashx",
                dataType: "text",
                data: { id: id },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    var json = jsonArr.data[0];
                    if (json == null) { return; } else {
                        $("#Id").val(json.Id);
                       
                        $("#Comment").val(json.Comment);

                        $("#SkillName").val(json.SkillName);
                        $("#PatientName").val(json.PatientName);
                        $("#CaseNum").val(json.CaseNum);
                        $("input[name=IsOk][value='"+json.IsOk+"']").attr("checked", true);
                        $("#OperateDate").val(json.OperateDate);


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
    <form id="form1" runat="server">
        <div align="center">
            <input type="hidden" id="Id" name="Id" />
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">技能名称：<span style="color: #ff0000">*</span></td>
                    <td colspan="3" width="70%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="SkillName" name="SkillName" style="width:250px;" />
                        
                        <input type="hidden" id="StudentsName" name="StudentsName" />
                         <input type="hidden" id="StudentsRealName" name="StudentsRealName" />
                         <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                         <input type="hidden" id="TrainingBaseName" name="TrainingBaseName" />
                         <input type="hidden" id="ProfessionalBaseCode" name="ProfessionalBaseCode" />
                         <input type="hidden" id="ProfessionalBaseName" name="ProfessionalBaseName" />
                         <input type="hidden" id="DeptCode" name="DeptCode" />
                         <input type="hidden" id="DeptName" name="DeptName" />
                         <input type="hidden" id="TeacherId" name="TeacherId" />
                         <input type="hidden" id="TeacherName" name="TeacherName" />
                         <input type="hidden" id="RequiredNum" name="RequiredNum" />
                         <input type="hidden" id="MasterDegree" name="MasterDegree" />
                         <input type="hidden" id="Writor" name="Writor" />
                         <input type="hidden" id="RegisterDate" name="RegisterDate" />
                        </span>
                    </td>
                 </tr>
                 <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">病人姓名：</td>
                    <td width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="PatientName" name="PatientName" style="width:150px;" />
                        </span>
                    </td>
                     <td width="20%" class="detailTitle" style="height: 25px;">病历号：</td>
                    <td width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="CaseNum" name="CaseNum" style="width:150px;" />
                        </span>
                    </td>
                 </tr>
                
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">是否成功：</td>
                    <td  width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <label><input type="radio" id="Success" name="IsOk" value="成功"/>成功</label>
                        <label><input type="radio" id="Error" name="IsOk" value="失败"/>失败</label>
                        </span>
                    </td>
                    <td width="20%" class="detailTitle" style="height: 25px;">操作日期：</td>
                    <td  width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="OperateDate" name="OperateDate" style="width: 150px;" onclick="WdatePicker({ maxDate: '%y-%M-%d', position: { left: -10, top: 0 } });"/>
                        </span>
                    </td>
                 </tr>
                
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">详细说明：<span style="color: #ff0000">*</span></td>
                    <td colspan="3" width="70%" class="detailContent"><span class="detailContent">
                        <textarea rows="" cols="" id="Comment" name="Comment" style="width:100%;height:120px;"></textarea>
                        </span>
                    </td>
                 </tr>
                <tr id="last">
                    <td colspan="8" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <input id="SaveAndUpdate" name="SaveAndUpdate" type="button" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;"/>
                           <%-- <a style="padding-left: 2em"></a>
                            <input type="button"  style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                           --%>
                         </div>
                    </td>
                </tr>
           </table>

        </div>
    </form>
    
</body>
</html>


