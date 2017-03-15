<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="teachers_AppointInformation_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预约信息填写</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/jquery-form.js"></script>
    <script type="text/javascript">

        $(function () {
            var id = "<%=id%>";
            var files = "";

            if (id != "") {
                $("#fujian").remove();
            }
            $("#each_class_num").focus(function () {
                var reg = /^\+?[1-9]\d*$/;
                var totalnum = $("#total_num").val();
                var classnum = $("#class_num").val();
                if (classnum == "0" || !reg.test(totalnum) || !reg.test(classnum) || parseInt(classnum) > parseInt(totalnum)) {
                    alert("输入的数值不合法");
                    return;
                } else {
                    $("#each_class_num").val(Math.round(parseInt(totalnum) / parseInt(classnum)));
                }
            });
           
        });
        function doUplaod() {
            var fileName = $("#uploadFile").val();
            if (!fileName) {
                alert("请选择文件进行上传");
                return false;
            } else {//*.doc;*.docx;*.xls;*.xlsx;*.pdf;*.rar;*.zip
                var ext = fileName.substring(fileName.lastIndexOf(".") + 1).toLocaleLowerCase();
                if (ext != "doc" && ext != "docx" && ext != "xls" && ext != "xlsx" && ext != "pdf" && ext != "rar" && ext != "zip") {
                    alert("请选择格式为:doc、docx、ppt、pptx、xls、xlsx、pdf、PDF、rar、zip的文件进行上传");
                    return false;
                }
            }

            $("#form1").ajaxSubmit({
                type: "post",
                url: "ashx/upload.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                success: function (data) {
                    var result = eval('(' + data + ')');
                    if (result.fileName == "0") {
                        alert("请选择格式为:doc、docx、ppt、pptx、xls、xlsx、pdf、rar、zip的文件进行上传");
                        return;

                    } else if (result.fileName == "1") {
                        alert("请选择文件进行上传");
                        return;
                    } else {
                        alert("文件:" + result.fileName + "上传成功")
                        //alert(result.filePath);

                        $("#FileName").val(result.fileName);
                        $("#FilePath").val(result.filePath);
                    }

                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="7" class="detailHead">预约信息表
                    </td>
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">指导医师：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="teachers_real_name" runat="server" Width="100px"></asp:TextBox>
                        <asp:HiddenField ID="teachers_name" runat="server" />
                        <asp:HiddenField ID="training_base_code" runat="server" />
                        <asp:HiddenField ID="training_base_name" runat="server" />
                        <asp:HiddenField ID="professional_base_code" runat="server" />
                        <asp:HiddenField ID="professional_base_name" runat="server" />
                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">所在科室：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="dept_name" runat="server" Width="100px"></asp:TextBox>
                        <asp:HiddenField ID="dept_code" runat="server" />
                    </span>
                    </td>
                    <td width="10%" class="detailContent" style="height: 25px;"></td>
                    <td width="20%" class="detailContent" style="height: 25px;"></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">预约时间：<span style="color: #ff0000">*</span></td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;">
                        从<asp:TextBox ID="appoint_begin_time" runat="server" Width="180px" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                    到<asp:TextBox ID="appoint_end_time" runat="server" Width="180px" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                   
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训总人数：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="total_num" runat="server" Width="100px"></asp:TextBox>

                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">组数：</td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="class_num" runat="server" Width="100px"></asp:TextBox>组
                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">每组人数：</td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="each_class_num" runat="server" Width="100px" onfocus="this.blur()"></asp:TextBox>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">培训内容：<span style="color: #ff0000">*</span></td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="training_content" runat="server" Width="95%" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">备注：</td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="comment" runat="server" Width="95%" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </span>
                    </td>
                </tr>
                <tr id="fujian">
                    <td width="10%" class="detailTitle" style="height: 25px;">附件：</td>
                    <td colspan="3" width="20%"style="height: 25px;" class="detailContent"valign="bottom" align="center">
                       <label><span style="color: #ff0000">上传多个文件时，请压缩为.rar、.zip格式</span></label>
                        <input type="file" id="uploadFile" name="uploadFile" />
                    </td>
                    <td colspan="2" width="20%" class="detailContent" style="height: 25px;">
                       <img alt="" src="../../images/BeginUpload1.gif" width="77" height="23" onclick="doUplaod()" style="cursor: pointer;float:left;" />
                      <asp:HiddenField ID="FileName" runat="server" />
                     <asp:HiddenField ID="FilePath" runat="server" />
                     <asp:HiddenField ID="IsReceive" runat="server" />
                    </td>
                    
                </tr> 
                <tr>
                    <td colspan="6" class="detailContent" style="text-align: right">
                        <table align="right">
                            <tr> 
                                <td width="70px" class="detailTitle" style="height: 25px;">登记日期：<span style="color: #ff0000">*</span></td>
                                <td width="100px" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="register_date" runat="server" Width="100px"></asp:TextBox>
                                </span>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>

                <tr id="last">
                    <td colspan="6" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" Style="cursor: pointer; background-image: url(../../images/tijiao.jpg); border: none; height: 21px; width: 88px;" OnClick="save_Click" />
                            <%--<a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../../images/chongzhi.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />--%>
                        </div>
                    </td>
                </tr>
            </table>



        </div>
    </form>
</body>
</html>
