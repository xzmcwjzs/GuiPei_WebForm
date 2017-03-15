<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="bases_AppointInformation_Manage" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预约信息填写</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/jquery-form.js"></script>
    <script src="../../js/autosize.js"></script>
    <script type="text/javascript">
        var id = "<%=id%>";
        var pi = "<%=pi%>";
        var tag = "<%=tag%>";
        $(function () {

            if (id != "") {
                $("#fujian").remove();
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }
            $("#EachClassNum").focus(function () {
                var reg = /^\+?[1-9]\d*$/;
                var totalnum = $("#TotalNum").val();
                var classnum = $("#ClassNum").val();
                if (classnum == "0" || !reg.test(totalnum) || !reg.test(classnum) || parseInt(classnum) > parseInt(totalnum)) {
                    alert("输入的数值不合法");
                    return;
                } else {
                    $("#EachClassNum").val(Math.round(parseInt(totalnum) / parseInt(classnum)));
                }
            });
            $("#BasesRealName").val("<%=(Session["loginModel"] as LoginModel).real_name%>");
            $("#BasesName").val("<%=(Session["loginModel"] as LoginModel).name%>");
            $("#TrainingBaseName").val("<%=(Session["loginModel"] as LoginModel).training_base_name%>");
            $("#TrainingBaseCode").val("<%=(Session["loginModel"] as LoginModel).training_base_code%>");
            $("#ProfessionalBaseName").val("<%=(Session["loginModel"] as LoginModel).professional_base_name%>");
            $("#ProfessionalBaseCode").val("<%=(Session["loginModel"] as LoginModel).professional_base_code%>");
            $("#RegisterDate").val("<%=DateTime.Now.Date.ToString("yyyy-MM-dd")%>");

            $("#SaveAndUpdate").click(function () {
                if (id != "") {
                    update();
                } else {
                    add();
                }
            });
        });

        function add() {
            $("#BasesRealName").attr("readonly", true); $("#ProfessioanalBaseName").attr("readonly", true);
            if ($("#AppointBeginTime").val() == "" || $("#AppointEndTime").val() == "") { alert("预约时间不能为空"); return; }
            if ($("#TotalNum").val() == "") { alert("培训总人数不能为空"); return; }
            if ($("#TrainingContent").val() == "") { alert("培训内容不能为空"); return; }
            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/Add.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    if (data == "errorFormat") {
                        alert("请选择格式为:doc、docx、ppt、pptx、xls、xlsx、pdf、rar、zip的文件进行上传");
                        return;
                    } else if (data == "addSuccess") {
                        alert("预约信息提交成功");
                        self.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);
                        window.close();
                    } else {
                        alert("预约信息提交失败");
                    }

                }
            });
        }
        function update() {
            var forms = $("#form1").serializeArray();
            $("#BasesRealName").attr("readonly", true); $("#ProfessioanalBaseName").attr("readonly", true);
            if ($("#AppointBeginTime").val() == "" || $("#AppointEndTime").val() == "") { alert("预约时间不能为空"); return; }
            if ($("#TotalNum").val() == "") { alert("培训总人数不能为空"); return; }
            if ($("#TrainingContent").val() == "") { alert("培训内容不能为空"); return; }
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Update.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: forms,
                success: function (data) {
                    if (data == "updateSuccess") {
                        alert("预约信息修改成功");
                        self.opener.window.loadPageList(pi);
                        window.close();
                    } else {
                        alert("预约信息修改失败");
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

                        $("#Id").val(json.id);
                        $("#BasesRealName").val(json.teachers_real_name);
                        $("#ProfessionalBaseName").val(json.professional_base_name);
                        $("#RegisterDate").val(json.register_date);
                        $("#AppointBeginTime").val(json.appoint_begin_time);
                        $("#AppointEndTime").val(json.appoint_end_time);
                        $("#TrainingContent").val(json.training_content);
                        $("#TotalNum").val(json.total_num);
                        $("#ClassNum").val(json.class_num);

                        $("#EachClassNum ").val(json.each_class_num);
                        $("#Comment ").val(json.comment);


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
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div align="center">
            <input type="hidden" id="Id" name="Id" />
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="7" class="detailHead">预约信息表
                    </td>
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">基地负责人：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="BasesRealName" name="BasesRealName" style="width: 100px" />
                        <input type="hidden" id="BasesName" name="BasesName" />
                        <input type="hidden" id="TrainingBaseName" name="TrainingBaseName" />
                        <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />

                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">专业基地：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <input type="hidden" id="ProfessionalBaseCode" name="ProfessionalBaseCode" />
                        <input type="Text" id="ProfessionalBaseName" name="ProfessionalBaseName" style="width: 100px" />
                    </span>
                    </td>
                    <td width="10%" class="detailContent" style="height: 25px;"></td>
                    <td width="20%" class="detailContent" style="height: 25px;"></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">预约时间：<span style="color: #ff0000">*</span></td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;">从<input type="text" id="AppointBeginTime" name="AppointBeginTime" style="width: 180px" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" />
                        到<input type="text" id="AppointEndTime" name="AppointEndTime" style="width: 180px" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训总人数：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="TotalNum" name="TotalNum" style="width: 100px" />
                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">组数：</td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="ClassNum" name="ClassNum" style="width: 100px" />组
                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">每组人数：</td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="EachClassNum" name="EachClassNum" style="width: 100px" />
                    </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">培训内容：<span style="color: #ff0000">*</span></td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <textarea id="TrainingContent" name="TrainingContent" rows="3" style="width: 95%;"></textarea>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">备注：</td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <textarea id="Comment" name="Comment" rows="3" style="width: 95%;"></textarea>
                    </span>
                    </td>
                </tr>
                <tr id="fujian">
                    <td width="10%" class="detailTitle" style="height: 25px;">附件：</td>
                    <td colspan="3" width="20%" style="height: 25px;" class="detailContent" valign="bottom" align="center">
                        <label><span style="color: #ff0000">上传多个文件时，请压缩为.rar、.zip格式</span></label>
                        <input type="file" id="UploadFile" name="UploadFile" />
                    </td>
                    <td colspan="2" width="20%" class="detailContent" style="height: 25px;">
                        <%--<img alt="" src="../../images/BeginUpload1.gif" width="77" height="23" onclick="doUplaod()" style="cursor: pointer;float:left;" />
                        --%>
                        <input type="hidden" id="FileName" name="FileName" />
                        <input type="hidden" id="FilePath" name="FilePath" />
                        <input type="hidden" id="IsReceive" name="IsReceive" />
                    </td>

                </tr>
                <tr>
                    <td colspan="6" class="detailContent">
                        <table align="right">
                            <tr> 
                                <td width="70px" class="detailTitle" style="height: 25px;">登记日期：<span style="color: #ff0000">*</span></td>
                                <td  width="100px" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px" />
                                </span>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>

                <tr id="last">
                    <td colspan="6" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <input id="SaveAndUpdate" name="SaveAndUpdate" type="button" style="cursor: pointer; background-image: url(../../images/tijiao.jpg); border: none; height: 21px; width: 88px;" />
                            <a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../../images/chongzhi.jpg); border: none; height: 21px; width: 88px;" />
                        </div>
                    </td>
                </tr>
            </table>



        </div>
    </form>
</body>
<script type="text/javascript">
    $("textarea").autosize();
</script>
</html>
