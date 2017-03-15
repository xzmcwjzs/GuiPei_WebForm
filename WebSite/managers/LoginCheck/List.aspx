<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="managers_LoginCheck_List" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>账号锁定/解锁</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-form.js"></script>
<style type="text/css">
    .button
    {
	    width:200px; height:20px; border: #002D96 1px solid; padding: 2px; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#FFFFFF, EndColorStr=#9DBCEA); cursor: pointer; color: black;
    }
    .tbmover{
		border: #336699 1px solid;
		padding-right: 2px; 
		padding-left: 2px; 
		cursor: pointer;
	}
	.tbmout{
		padding-right: 3px; padding-left: 3px;
		
	}
    </style>   
    <script type="text/javascript">
        
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var RealName = "<%=RealName%>";
        var Type = "<%=Type%>";
        var RegisterDate = "<%=RegisterDate%>";
        $(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("ashx/List.ashx", {
                "pi": pi, "TrainingBaseCode": TrainingBaseCode, "RealName": RealName, "Type": Type,
                "RegisterDate": RegisterDate
            },
              function (data) {
                  var jsonArr = eval("(" + data + ")");
                  if (jsonArr.data == null) {
                      $("#tbList tr:gt(0)").remove();
                  } else {
                      createRows(jsonArr.data, pi);
                  }
                  createPageBar($("#PageList"), pi, jsonArr.recordCount, jsonArr.pageCount);

              });
        }

        function createRows(jsonArr, pi) {
            var tbL = $("#tbList");
            $("#tbList tr:gt(0)").remove();
            for (i = 0; i < jsonArr.length; i++) {
                var trHTML = "<tr class='listTableContentRow'>";
                trHTML += "<td style='height:23px;'>" + jsonArr[i].name + "</td>";
                trHTML += "<td>" + jsonArr[i].real_name + "</td>";
                trHTML += "<td>" + jsonArr[i].password + "</td>";
                trHTML += "<td>" + jsonArr[i].training_base_name + "</td>";
                trHTML += "<td>" + jsonArr[i].professional_base_name + "</td>";
                trHTML += "<td style='width:10%;'>" + jsonArr[i].dept_name + "</td>";
                var arr = new Array();
                var type="";
                arr=jsonArr[i].type.split("_");
                for (var j = 0; j < arr.length; j++) {
                    if (arr[j] == "students") { arr[j] = "学员"; }
                    if (arr[j] == "teachers") { arr[j] = "指导医师"; }
                    if (arr[j] == "bases") { arr[j] = "专业基地负责人"; }
                    if (arr[j] == "managers") { arr[j] = "管理员"; }
                    type += arr[j]+" ";
                }
                trHTML += "<td >" + type + "</td>";
                
                trHTML += "<td>" + jsonArr[i].RegisterDate + "</td>";
                if (jsonArr[i].LoginState == "1") {
                    trHTML += "<td><a style='text-decoration:none;color:green;' onclick=\"handle('" + jsonArr[i].LoginState + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'>已解锁</a></td>";
                } else {
                    trHTML += "<td><a style='text-decoration:none;color:red;' onclick=\"handle('" + jsonArr[i].LoginState + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'>已锁定</a></td>";
                }
                
                trHTML += "</tr>";
                tbL.append(trHTML);


            }

            $("#tbList tr:gt(0)").mouseover(function () {
                $(this).removeClass("listTab  leContentRow");
                $(this).addClass("listTableContentRowMouseOver");
            });

            $("#tbList tr:gt(0)").mouseout(function () {
                $(this).removeClass("listTableContentRowMouseOver");
                $(this).addClass("listTableContentRow");
            });

        }
        function handle(check, id, pi) {
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Handle.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: { id: id, check: check },
                success: function (data) {
                    if (data == "checkSuccess") {
                        loadPageList(pi);
                        return;
                    } else {
                        alert("锁定/解锁操作失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }
        function basesUploadFile() {
            var fileName = $("#basesFile").val();
            if (!fileName) {
                alert("请选择文件进行上传");
                return false;
            } else {
                var ext = fileName.substring(fileName.lastIndexOf(".") + 1).toLocaleLowerCase();
                if (ext != "xlsx") {
                    alert("请选择格式为xlsx的文件进行上传");
                    return false;
                }
            }

            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/Upload.ashx?type=bases",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    if (data == "0") {
                        alert("请选择格式为xlsx的文件进行上传");
                        return;

                    } else if (data == "1") {
                        alert("请选择文件进行上传");
                        return;
                    } else {
                        var filePath=data;
                       
                        $.ajax({
                            cache: false,
                            async: false,
                            type: "post",
                            url: "ashx/basesImport.ashx",
                            dataType: "text",
                            data: { filePath: filePath },
                            success: function (data) {
                                alert(data);
                                loadPageList(1);
                            },
                            error: function () {
                                alert("系统繁忙，请联系管理员");
                            }
                        });
                        
                        
                    }

                }
            });
        }

        function teachersUploadFile() {
            var fileName = $("#teachersFile").val();
            if (!fileName) {
                alert("请选择文件进行上传");
                return false;
            } else {
                var ext = fileName.substring(fileName.lastIndexOf(".") + 1).toLocaleLowerCase();
                if (ext != "xlsx") {
                    alert("请选择格式为xlsx的文件进行上传");
                    return false;
                }
            }

            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/Upload.ashx?type=teachers",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    if (data == "0") {
                        alert("请选择格式为xlsx的文件进行上传");
                        return;

                    } else if (data == "1") {
                        alert("请选择文件进行上传");
                        return;
                    } else {
                        var filePath = data;

                        $.ajax({
                            cache: false,
                            async: false,
                            type: "post",
                            url: "ashx/teachersImport.ashx",
                            dataType: "text",
                            data: { filePath: filePath },
                            success: function (data) {
                                alert(data);
                                loadPageList(1);
                            },
                            error: function () {
                                alert("系统繁忙，请联系管理员");
                            }
                        });


                    }

                }
            });
        }

        function studentsUploadFile() {
            var fileName = $("#studentsFile").val();
            if (!fileName) {
                alert("请选择文件进行上传");
                return false;
            } else {
                var ext = fileName.substring(fileName.lastIndexOf(".") + 1).toLocaleLowerCase();
                if (ext != "xlsx") {
                    alert("请选择格式为xlsx的文件进行上传");
                    return false;
                }
            }

            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/Upload.ashx?type=students",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    if (data == "0") {
                        alert("请选择格式为xlsx的文件进行上传");
                        return;

                    } else if (data == "1") {
                        alert("请选择文件进行上传");
                        return;
                    } else {
                        var filePath = data;

                        $.ajax({
                            cache: false,
                            async: false,
                            type: "post",
                            url: "ashx/studentsImport.ashx",
                            dataType: "text",
                            data: { filePath: filePath },
                            success: function (data) {
                                alert(data);
                                loadPageList(1);
                            },
                            error: function () {
                                alert("系统繁忙，请联系管理员");
                            }
                        }); 
                    }

                }
            });
        }
    </script>

</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
        <div id="couDiv">
            <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td class="listTableHeadTR" style="height: 22px;" width="20%">
                        <img height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />人员登录账号查询结果                  
                    </td>
                    
                </tr>
            </table>
            <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
                <tr id="tr0" class="listTableTitleRow">
                    <td>用户名</td>
                    <td>真实姓名</td>
                    <td>密码</td>
                    <td>培训基地</td>
                    <td>专业基地</td>
                    <td>所在科室</td>
                    <td>角色</td>
                    <td>注册年份</td>
                    <td>解锁/锁定</td>
                </tr>

            </table>
            <div id="PageList" style="text-align: center; vertical-align: middle; margin-top: 10px;">
            </div>
                      
        </div>
        <div style="margin-left:0">
            <div id="studentsImport" style="margin-top: 20px;margin-left:5px; float: left">
                <h3>学员基本信息表导入</h3>
                <br />
                <input type="file" id="studentsFile" name="studentsFile" style="width: 150px; height: 20px;">
                <button type="button" id="studentsUpload" name="studentsUpload" style="height: 20px;" onclick="studentsUploadFile()">学员信息导入</button>
            |</div>
            <div id="teachersImport" style="margin-top: 20px; margin-left:10px;float: left">
                <h3>指导医师基本信息表导入</h3>
                <br />
                <input type="file" id="teachersFile" name="teachersFile" style="width: 150px; height: 20px;">
                <button type="button" id="teachersUpload" name="teachersUpload" style="height: 20px;" onclick="teachersUploadFile()">指导医师信息导入</button>
            |</div>
            <div id="basesImport" style="margin-top: 20px; margin-left:10px;float: left">
                <h3>专业基地负责人基本信息表导入</h3>
                <br />
                <input type="file" id="basesFile" name="basesFile" style="width: 150px; height: 20px;">
                <button type="button" id="basesUpload" name="basesUpload" style="height: 20px;" onclick="basesUploadFile()">专业基地负责人信息导入</button>
            </div>
        </div>
         
    </form>

</body>
    
</html>


