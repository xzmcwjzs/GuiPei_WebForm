<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="managers_ReleaseNews_Manage" ValidateRequest="false" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发布新闻公告</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/jquery-form.js"></script>
    <script src="../../js/ckeditor/ckeditor.js"></script>
    <script src="../../js/ckeditor/loadUBBCode.js"></script>
    <script type="text/javascript">
        var id = "<%=id%>";
        var pi = "<%=pi%>";
        var tag = "<%=tag%>";

        $(function () {
            //var editor = CKEDITOR.replace("NewsContent");
            loadUBBCode();

            if (id != "") {
                $("#fujian").remove();
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }
            if (id == "") {
                $("#ManagersRealName").val("<%=(Session["loginModel"] as LoginModel).real_name%>");
                $("#ManagersName").val("<%=(Session["loginModel"] as LoginModel).name%>");
                $("#TrainingBaseName").val("<%=(Session["loginModel"] as LoginModel).training_base_name%>");
                $("#TrainingBaseCode").val("<%=(Session["loginModel"] as LoginModel).training_base_code%>");
                $("#RegisterDate").val("<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>");
                $("#Writor").val("<%=(Session["loginModel"] as LoginModel).real_name%>");
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
            var oEditor = CKEDITOR.instances.NewsContent;
            if ($("#NewsTitle").val() == "") { alert("标题不能为空"); return; }
            if (oEditor.getData() == "") { alert("内容不能为空"); return; }
            if ($("input[type='checkbox']").is(':checked') == false) { alert("发布对象不能为空"); return; }

            var NewsContent = oEditor.getData();
            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/Add.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    if (data == "errorFormat") {
                        alert("请选择格式为:doc、docx、ppt、pptx、xls、xlsx、pdf、rar、zip的文件进行上传");
                        return;
                    } else if (data == "addSuccess") {
                        alert("新闻公告发布成功");
                        self.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);
                        window.close();
                    } else {
                        alert("新闻公告发布失败");
                    }

                }
            });
        }

        function loadAllData(id) {
            var oEditor = CKEDITOR.instances.NewsContent;
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
                        $("#NewsTitle").val(json.NewsTitle);
                        oEditor.setData(json.NewsContent);
                        $(":checkbox[name='Students'][value='" + json.Students + "']").attr('checked', true);
                        $(":checkbox[name='Teachers'][value='" + json.Teachers + "']").attr('checked', true);
                        $(":checkbox[name='Bases'][value='" + json.Bases + "']").attr('checked', true);
                        $("#Writor").val(json.Writor);
                        $("#RegisterDate").val(json.RegisterDate);

                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }

        function update() {
            var oEditor = CKEDITOR.instances.NewsContent;
            if ($("#NewsTitle").val() == "") { alert("标题不能为空"); return; }
            if (oEditor.getData() == "") { alert("内容不能为空"); return; }
            if ($("input[type='checkbox']").is(':checked') == false) { alert("发布对象不能为空"); return; }
            var forms = $("#form1").serializeArray();
            var NewsContent = oEditor.getData();
            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/Update.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    if (data == "updateSuccess") {
                        alert("新闻公告修改成功");
                        self.opener.window.loadPageList(pi);
                        window.close();
                    } else {
                        alert("新闻公告修改失败");
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
            <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
            <input type="hidden" id="TrainingBaseName" name="TrainingBaseName" />
            <input type="hidden" id="ManagersName" name="ManagersName" />
            <input type="hidden" id="ManagersRealName" name="ManagersRealName" />
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="2" class="detailHead">发布新闻公告
                    </td>
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">标题：<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <input type="text" id="NewsTitle" name="NewsTitle" style="width: 450px" /></span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">内容：<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <textarea id="NewsContent" name="NewsContent" rows="10" style="width: 95%;"></textarea>
                    </span>
                    </td>
                </tr>
                <tr id="fujian">
                    <td width="10%" class="detailTitle" style="height: 25px;">附件：</td>
                    <td width="70%" style="height: 25px;" class="detailContent" valign="bottom" align="center">
                        <label><span style="color: #ff0000">上传多个文件时，请压缩为.rar、.zip格式</span></label>
                        <input type="file" id="UploadFile" name="UploadFile" />
                        <input type="hidden" id="FileName" name="FileName" />
                        <input type="hidden" id="FilePath" name="FilePath" />
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">发送对象：<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height: 25px;" align="center"><span class="detailContent" style="height: 25px">
                        <label>
                            <input type="checkbox" id="Students" name="Students" value="1" />学员</label><a style="padding-left: 2em;"></a>
                        <label>
                            <input type="checkbox" id="Teachers" name="Teachers" value="1" />指导医师</label><a style="padding-left: 2em;"></a>
                        <label>
                            <input type="checkbox" id="Bases" name="Bases" value="1" />专业基地负责人</label>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="detailContent">
                        <table align="right">
                            <tr> 
                                <td width="70px" class="detailTitle" style="height: 25px;">发布人：<span style="color: #ff0000">*</span></td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <input type="text" id="Writor" name="Writor" style="width: 150px" />
                                </span>
                                </td>
                                <td width="70px" class="detailTitle" style="height: 25px;">发布时间：<span style="color: #ff0000">*</span></td>
                                <td width="10%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <input type="text" id="RegisterDate" name="RegisterDate" style="width: 150px" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss', maxDate: '%y-%M-%d', position: { left: -25, top: 0 } });" />
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
                            <%--<a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../../images/chongzhi.jpg); border: none; height: 21px; width: 88px;" />--%>
                        </div>
                    </td>
                </tr>
            </table>



        </div>
    </form>
</body>

</html>

