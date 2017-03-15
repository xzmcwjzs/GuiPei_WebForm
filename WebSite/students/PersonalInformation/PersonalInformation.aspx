<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInformation.aspx.cs" Inherits="students_PersonalInformation_PersonalInformation" %>
<%@ Import Namespace="Common" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>填写个人信息</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
    <script src="../../js/yearmonth.js"></script>
    <link href="../../js/jqueryAutocomplete/jquery.autocomplete.css" rel="stylesheet" />
    <script src="../../js/jqueryAutocomplete/jquery.autocomplete.js"></script>
    <script src="../../js/jquery-form.js"></script>
    <script src="../../js/SWFUpload/handlers.js"></script>
    <script src="../../js/SWFUpload/swfupload.js"></script>
    <style type="text/css">
        #cblDisability input {
            width: 20px;
        }
    
}
    </style>
   
    <script type="text/javascript">
        
        $(document).ready(function () {
            $.post("../ashx/Province.ashx",
                function (data) {

                    dat = eval(data);
                    if (dat != "") {
                        for (var i = 0; i < dat.length; i++) {
                            if (dat[i].provinceid == $("#province_code").val() || dat[i].province == $("#province_name").val()) {
                                $("#province").append("<option Value=" + dat[i].provinceid + " selected='selected'>" + dat[i].province + "</option>");

                                $.post("../ashx/City.ashx", { "father": dat[i].provinceid }, function (data) {
                                    dat = eval(data);
                                    if (dat != "") {
                                        for (var i = 0; i < dat.length; i++) {

                                            if (dat[i].cityid == $("#city_code").val() || dat[i].city == $("#city_name").val()) {
                                                $("#city").append("<option Value=" + dat[i].cityid + " selected='selected'>" + dat[i].city + "</option>");
                                                $.post("../ashx/Area.ashx", { "father": dat[i].cityid }, function (data) {
                                                    dat = eval(data);
                                                    if (dat != "") {
                                                        for (var i = 0; i < dat.length; i++) {
                                                            if (dat[i].areaid == $("#area_code").val() || dat[i].area == $("#area_name").val()) {
                                                                $("#area").append("<option Value=" + dat[i].areaid + " selected='selected'>" + dat[i].area + "</option>");
                                                            } else {

                                                                $("#area").append("<option Value=" + dat[i].areaid + ">" + dat[i].area + "</option>");

                                                            }
                                                        }
                                                    }
                                                });

                                            } else {

                                                $("#city").append("<option Value=" + dat[i].cityID + ">" + dat[i].city + "</option>");


                                            }
                                        }
                                    }

                                });

                            } else {
                                $("#province").append("<option Value=" + dat[i].provinceid + ">" + dat[i].province + "</option>");

                            }
                            
                        }

                    }

                });

            $("#province").change(function () {
                $("#city option:gt(0)").remove();
                $("#area option:gt(0)").remove();
                $.post("../ashx/City.ashx", { "father": $("#province").val() }, function (data) {
                    dat = eval(data);
                    if (dat != "") {
                        for (var i = 0; i < dat.length; i++) {
                            
                            $("#city").append("<option Value=" + dat[i].cityid + ">" + dat[i].city + "</option>");
                            
                        }
                    }

                });

                var pro_name = $("#province").find("option:selected").text();
                var pro_code = $("#province").val();
                if (pro_name == "==请选择==" || pro_code=="0") {
                    $("#province_name").val("");
                    $("#province_code").val("");
                    return;
                } else {
                    $("#province_name").val(pro_name);
                    $("#province_code").val(pro_code);
                }

            });

            $("#city").change(function () {
                $("#area option:gt(0)").remove();
                $.post("../ashx/Area.ashx", { "father": $("#city").val() }, function (data) {
                    dat = eval(data);
                    if (dat != "") {
                        for (var i = 0; i < dat.length; i++) {
                            $("#area").append("<option Value=" + dat[i].areaid + ">" + dat[i].area + "</option>");

                        }
                    }
                });
                var cit_name = $("#city").find("option:selected").text();
                var cit_code = $("#city").val();
                if (cit_name == "==请选择==" || cit_code=="0") {
                    $("#city_name").val("");
                    $("#city_code").val("");
                    
                } else {
                    $("#city_name").val(cit_name);
                    $("#city_code").val(cit_code);
                }

            });
            $("#area").change(function () {
                var are_name= $("#area").find("option:selected").text();
                var are_code = $("#area").val();
                if (are_name == "==请选择==" || are_code=="0") {
                    $("#area_name").val("");
                    $("#area_code").val("");
                } else {
                    $("#area_name").val(are_name);
                    $("#area_code").val(are_code);
                }

            });
            $("#identity_type").change(function () {
                if ($("#identity_type").val() == "单位人") {
                    $("#send_unit").removeAttr("disabled");
                } else {
                    $("#send_unit").attr("disabled", "disabled");
                    $("#send_unit").val("");
                }

            });

        });


    </script>
    <script type="text/javascript">
        var id = "<%=id%>";
        $(function () {
            $.post("../ashx/TrainingBaseProvince.ashx", function (data) {
                dat = eval(data);
                if (dat != "") {
                    for (var i = 0; i < dat.length; i++) {
                        if (dat[i].province_code == $("#training_base_province_code").val()) {
                            $("#training_base_province").append("<option Value=" + dat[i].province_code + " selected='selected'>" + dat[i].province_name + "</option>");

                            $.post("../ashx/TrainingBase.ashx", { "provinceCode": dat[i].province_code }, function (data) {
                                dat = eval(data);
                                if (dat != "") {
                                    for (var i = 0; i < dat.length; i++) {
                                        if (dat[i].hospital_code == $("#training_base_code").val()) {
                                            $("#training_base").append("<option Value=" + dat[i].hospital_code + " selected='selected'>" + dat[i].hospital_name + "</option>");
                                        } else {
                                            $("#training_base").append("<option Value=" + dat[i].hospital_code + ">" + dat[i].hospital_name + "</option>");
                                        }


                                    }
                                }

                            });


                        } else {
                            $("#training_base_province").append("<option Value=" + dat[i].province_code + ">" + dat[i].province_name + "</option>");
                        }


                    }
                }
            });

           

            $("#training_base_province").change(function () {
                $("#training_base option:gt(0)").remove();
                $.post("../ashx/TrainingBase.ashx", { "provinceCode": $("#training_base_province").val() }, function (data) {
                    dat = eval(data);
                    if (dat != "") {
                        for (var i = 0; i < dat.length; i++) {
                            $("#training_base").append("<option Value=" + dat[i].hospital_code + ">" + dat[i].hospital_name + "</option>");
                            
                        }
                    }

                });

                var tbproname = $("#training_base_province").find("option:selected").text();
                var tbprocode = $("#training_base_province").find("option:selected").val();

                if (tbproname == "==所在省市==" || tbprocode == "0") {
                    $("#training_base_province_code").val("");
                    $("#training_base_province_name").val("");
                    $("#training_base_code").val("");
                    $("#training_base_name").val("");
                    return;
                } else {
                    $("#training_base_province_code").val(tbprocode);
                    $("#training_base_province_name").val(tbproname);
                    $("#training_base_code").val("");
                    $("#training_base_name").val("");
                }


            });
            $("#training_base").change(function () {
                var tbcode = $("#training_base").find("option:selected").val();
                var tbname = $("#training_base").find("option:selected").text();
                if (tbname == "==请选择==" || tbcode == "0") {
                    $("#training_base_code").val("");
                    $("#training_base_name").val("");
                    return;
                } else {
                    $("#training_base_code").val(tbcode);
                    $("#training_base_name").val(tbname);
                }
            });

            $.post("../ashx/ProfessionalBase.ashx", function (data) {
                dat = eval(data);
                if (dat != "") {
                    for (var i = 0; i < dat.length; i++) {
                        if (dat[i].professional_base_code == $("#professional_base_code").val()) {
                            $("#professional_base").append("<option Value=" + dat[i].professional_base_code + " selected='selected'>" + dat[i].professional_base_name + "</option>");
                        } else {
                            $("#professional_base").append("<option Value=" + dat[i].professional_base_code + ">" + dat[i].professional_base_name + "</option>");
                        }
                    }
                }
            });

            $("#professional_base").change(function () {
                var pbname = $("#professional_base").find("option:selected").text();
                var pbcode = $("#professional_base").find("option:selected").val();

                if (pbname == "==请选择==" || pbcode == "0") {
                    $("#professional_base_code").val("");
                    $("#professional_base_name").val("");
                    return;
                } else {
                    $("#professional_base_code").val(pbcode);
                    $("#professional_base_name").val(pbname);
                }
            });
            

        });
    </script>

    <script type="text/javascript">

        function checkIdNumberAndcountBirthDateAndcountAge() {
            if (!isIdCardNo(document.getElementById('id_number').value)) {
                document.getElementById('id_number').focus();
                return;
            } else {
                countBirthDate();
                
                countAge();

                
            }
            if (id == "" || id == null) {
                $.post("../ashx/PersonalInformation.ashx", { "id_number": $("#id_number").val() }, function (data, status) {
                    if (status != "success") {
                        alert("数据库请求失败");
                        return;
                    }
                    if (data != "") {
                        alert("个人信息已经完善，请勿重复填写");
                        window.close();
                        return;
                    }
                });
            }

            
            
        }

        function countBirthDate() {
            var cardNum = document.getElementById('id_number').value;
            var date = "";
            if (cardNum.length == 15) {
                //date = "19";//substring 方法将返回位于 String 对象中指定位置的子字符串,返回一个包含从 start 到最后（不包含 end ）的子字符串的字符串。
                //date = date + cardNum.substring(6, 8) + "-" + cardNum.substring(8, 10) + "-" + cardNum.substring(10, 12);
                //document.getElementById('datebirth').innerText = date;
                alert("请输入18位第二代身份证号码");
                return;
            }
            else {
                date = "";
                date = date + cardNum.substring(6, 10) + "-" + cardNum.substring(10, 12) + "-" + cardNum.substring(12, 14);
                document.getElementById('datebirth').innerText = date;
                document.getElementById('datebirth').value = date;
            }
            return true;
        }

        function countAge() {
            //var birthDate = document.getElementById('datebirth').value;
            var cardNum = document.getElementById('id_number').value;
            var birthDate = "";
            if (cardNum.length == 15) {
                //birthDate = "19";//substring 方法将返回位于 String 对象中指定位置的子字符串,返回一个包含从 start 到最后（不包含 end ）的子字符串的字符串。
                //birthDate = birthDate + cardNum.substring(6, 8) + "-" + cardNum.substring(8, 10) + "-" + cardNum.substring(10, 12);
                alert("请输入18位第二代身份证号码");
                return;
            }
            else {
                birthDate = "";
                birthDate = birthDate + cardNum.substring(6, 10) + "-" + cardNum.substring(10, 12) + "-" + cardNum.substring(12, 14);
            }

            var age = '';
            if (birthDate.length == 10) {
                var Y = birthDate.substring(0, 4);
                var M = birthDate.substring(5, 7);
                var D = birthDate.substring(8, 10);
                var now = new Date(); var year = now.getYear(); var month = now.getMonth() + 1; var day = now.getDate();//getMonth 方法返回一个处于 0 到 11 之间的整数
                var ySpan = year - Y; var mSpan = month - M; var dSpan = day - D;
                if (ySpan > 0) {

                    document.getElementById('age').innerText = ySpan + '岁';

                    document.getElementById('age').value = ySpan + '岁';
                }
                else if (mSpan > 0 && ySpan == 0) {
                    document.getElementById('age').innerText = mSpan + '月';
                    document.getElementById('age').value = mSpan + '月';
                }
                else if (dSpan > 0 && mSpan == 0) {
                    document.getElementById('age').innerText = dSpan + '天';
                    document.getElementById('age').value = dSpan + '天';
                }
                else {
                    document.getElementById('age').innerText = '';
                    document.getElementById('age').value = '';
                }
                    
            }
        }
        function isIdCardNo(num) {
            num = num.toUpperCase();//该字符串中的所有字母都被转化为大写字母。
            //身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X。   
            //if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(num)))//返回一个 Boolean 值，它指出在被查找的字符串中是否存在模式
            //{
            //    alert('输入的身份证号长度不对，或者号码不符合规定！\n15位号码应全为数字，18位号码末位可以为数字或X。');
            //    return false;
            //}
            if (!(/(^\d{17}([0-9]|X)$)/.test(num)))//返回一个 Boolean 值，它指出在被查找的字符串中是否存在模式
            {
                alert('输入的身份证号长度不对，18位二代身份证号码末位可以为数字或X。');
                return false;
            }
            //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
            //下面分别分析出生日期和校验位 
            var len, re;
            len = num.length;
            //if (len == 15) {
            //    re = new RegExp(/^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$/);//本对象包含正则表达式模式以及表明如何应用模式的标志。
            //    var arrSplit = num.match(re);//使用正则表达式模式对字符串执行查找，并将包含查找的结果作为数组返回

            //    //检查生日日期是否正确 
            //    var dtmBirth = new Date('19' + arrSplit[2] + '/' + arrSplit[3] + '/' + arrSplit[4]);
            //    var bGoodDay;//对于1900-1999这段时间而言，返回的年份值是一个两位数字的整数，它代表了所保存的年份与 1900 年之间的差距。而对于其它的年份，返回值是一个四位的整数。例如，1996 年的返回值是 96，而 1825 和 2025 年的返回值则相应地为 1825 和 2025。
            //    bGoodDay = (dtmBirth.getYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
            //    if (!bGoodDay) {
            //        alert('输入的身份证号里出生日期不对！');
            //        return false;
            //    }
            //}
            if (len == 18) {
                re = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
                var arrSplit = num.match(re);

                //检查生日日期是否正确 
                var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
                var bGoodDay;//getFullYear 方法以绝对数字的形式返回年份值。例如，1976 年的返回值就是 1976。这样可以避免出现 2000 年问题，从而不会将 2000 年1月1日以后的日期与 1900 年1月1日以后的日期混淆起来。
                bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
                if (!bGoodDay) {
                    alert(dtmBirth.getYear());
                    alert(arrSplit[2]);
                    alert('输入的身份证号里出生日期不对！');
                    return false;
                }
                else {
                    //检验18位身份证的校验码是否正确。 
                    //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
                    var valnum;
                    var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);//加权因子
                    var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
                    var nTemp = 0, i;
                    for (i = 0; i < 17; i++) {
                        nTemp += num.substr(i, 1) * arrInt[i];//substr 方法返回一个从指定位置开始的指定长度的子字符串。
                        
                    }
                    valnum = arrCh[nTemp % 11];
                    if (valnum != num.substr(17, 1)) {
                        alert('18位身份证的校验码不正确！应该为：' + valnum);
                        return false;
                    }
                    return num;
                }
            }
            return false;
        }

    </script>

    <script type="text/javascript">
        $(function () {
            if ($("#image_path").val() == "" || $("#image_path").val() == null) {
                $("#imgUpload").attr("src", "../../images/head1.jpg");
                
            } else {
                $("#imgUpload").attr("src", $("#image_path").val());
            }
           
        });
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "ashx/upload.ashx",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg;*.gif;*.png;*.bmp;*.gif;*.jpeg",
                file_types_description: "jpg gif png bmp gif jpeg Images",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: showImage,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: "../../js/SWFUpload/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">请选择头像上传<span class="buttonSmall">(2 MB以内)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt;} .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding:5,

                // Flash Settings
                flash_url: "../../js//SWFUpload/swfupload.swf",	// Relative to this file
                flash9_url: "../../js//SWFUpload/swfupload_FP9.swf",	// Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });
        }
        //上传成功以后调用该方法
        function showImage(file, serverData) {
            //$("#showPhoto").attr("src", serverData);
            var result = eval('(' + serverData + ')');
            if (result.imgSrc == "0") {
                alert("请选择格式为:jpg、png、bmp、gif、jpeg的头像进行上传");
                return;

            } else if (result.imgSrc == "1") {
                alert("请选择头像进行上传");
                return;
            } else {
                $("#imgUpload").attr("src", result.imgSrc);
                //alert($("#imgUpload")[0].src);
                $("#image_path").val(result.imgSrc);
                $("#divFileProgressContainer").fadeOut("slow");
            }
        }

        //function doUplaod() {
        //    var fileName = $("#uploadFile").val();
        //    if (!fileName) {
        //        alert("请选择头像4进行上传");
        //        return false;
        //    } else {
        //        var ext = fileName.substring(fileName.lastIndexOf(".")+1).toLocaleLowerCase();
        //        if (ext != "jpg" && ext != "png" && ext != "bmp" && ext != "gif" && ext != "jpeg") {
        //            alert("请选择格式为:jpg、png、bmp、gif、jpeg的头像进行上传");
        //            return false;
        //        }
        //    }

        //    $("#form1").ajaxSubmit({
        //        cache: false,
        //        type: "post",
        //        url: "ashx/upload.ashx",
        //        dataType: "text",//如果是json的话，不用eval()在解析
        //        success: function (data) {
        //            var result = eval('(' + data + ')');
        //            if (result.imgSrc == "0") {
        //                alert("请选择格式为:jpg、png、bmp、gif、jpeg的头像进行上传");
        //                return;
                       
        //            } else if (result.imgSrc == "1") {
        //                alert("请选择头像进行上传");
        //                return;
        //            } else {
        //                $("#imgUpload").attr("src", result.imgSrc);
        //                //alert($("#imgUpload")[0].src);
        //                $("#image_path").val(result.imgSrc);
        //            }

        //        },
        //        error: function () {
        //            alert("系统繁忙，请联系管理员");
        //        }

        //    });
        //}
    </script>

    <script type="text/javascript">
        $(function () {
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/SchoolName.ashx",
                dataType: "text",
                success: function (data) {
                    jsonArr = eval('(' + data + ')');
                    $("#bk_school").autocomplete(jsonArr, {
                        autoFill: false,
                        matchContains: true,
                        width: 150,
                        max: 8,
                        matchSubset: true,
                        matchCase: true,
                        scroll: true,
                        formatItem: function (row, i, max) {
                            return row.SchoolName;
                        },
                        formatMatch: function (row, i, max) {
                            return row.SchoolName;
                        },
                        formatResult: function (row) {
                            return row.SchoolName;
                        }

                    });
                    $("#high_school").autocomplete(jsonArr, {
                        autoFill: false,
                        matchContains: true,
                        width: 150,
                        max: 8,
                        matchSubset: true,
                        matchCase: true,
                        scroll: true,
                        formatItem: function (row, i, max) {
                            return row.SchoolName;
                        },
                        formatMatch: function (row, i, max) {
                            return row.SchoolName;
                        },
                        formatResult: function (row) {
                            return row.SchoolName;
                        }

                    });

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });

        });
    </script>

</head>
<body style="background-color: #efebef;">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="6" class="detailHead">填写个人信息</td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="real_name" runat="server" Text="" ReadOnly="true"></asp:TextBox></span>
                    </td>

                    <td width="60%" class="detailContent" style="height: 50px" colspan="4" rowspan="5">
                        <div style="float:left;width:30%;height:125px;margin-left:70px;margin-top:5px;">
                            <img src="" alt="头像" id="imgUpload" width="120px" height="160px"/>
                            <%--<asp:Image ID="imgUpload" runat="server" src="../../images/head1.jpg"/>--%>
                            <asp:HiddenField ID="image_path" runat="server" />
                            <%--<div id="uploadfileQueue" style="padding: 1px; width: 200px">
                            </div>--%>
                            
                        </div>
                        
                        <div style="float:left;vertical-align:middle;margin-top:100px;">
                            <div>
				                 <span id="spanButtonPlaceholder"></span>
                            </div>
                            <%--<div id="file_upload" style="text-align:center;">
                            </div>--%>
                            <%--<input type="file" name="uploadFile" id="uploadFile"><br />
                            <img alt="" src="../../images/BeginUpload1.gif" width="77" height="23" onclick="doUplaod()" style="cursor: pointer" />--%>
                            <%--<img alt="" src="../../images/CancelUpload1.gif" width="77" height="23" onclick="closeLoad()" style="cursor: pointer;margin-left:20px;" />--%>
                            <div id="divFileProgressContainer" style="height: 75px;"></div>
                        </div>
                    
                    </td>
                    
                </tr>
                <tr>
                    <td  width="10%" class="detailTitle" style="height: 25px;">性别<span style="color: #ff0000">*</span></td>
                    <td  class="detailContent" width="23%"  style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                            <asp:ListItem Value="女">女</asp:ListItem>
                        </asp:RadioButtonList></span>
                        </td>
                    
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">居民身份证号<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="id_number" runat="server" Text="" onblur="checkIdNumberAndcountBirthDateAndcountAge()"></asp:TextBox>
                    </span></td>
                    
                    </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px"><span class="detailTitle" style="height: 25px">出生日期</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="datebirth" runat="server"></asp:TextBox>
                   </span></td>
                    
                    
                    </tr>
                <tr>
                    
                    <td class="detailTitle" style="height: 25px;" width="10%"><span class="detailTitle" style="height: 25px; width: 31px;">年龄</span></td>
                    <td class="detailContent" style="height: 25px" width="23%"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="age" runat="server"></asp:TextBox>
                    </span></td>
                    </tr>
                   <tr>
                     <td class="detailTitle" style="height: 25px;" width="10%"><span class="detailTitle" style="height: 25px;">常住地址<span style="color: #ff0000">*</span></span></td>
                    <td colspan="5" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                       
                        <select id="province" name="province" style="width:100px">
                            <option value="0">==请选择==</option>

                        </select>
                        <select id="city" name="city" style="width:100px">
                            <option value="0">==请选择==</option>

                        </select>
                        <select id="area" name="area" style="width:100px">
                            <option value="0">==请选择==</option>

                        </select>
                        <asp:TextBox ID="detail_address" runat="server" Text="" style="width: 50%;"></asp:TextBox>
                        <asp:HiddenField ID="province_name" runat="server" />
                        <asp:HiddenField ID="city_name" runat="server" />
                        <asp:HiddenField ID="area_name" runat="server" />
                        <asp:HiddenField ID="province_code" runat="server" />
                        <asp:HiddenField ID="city_code" runat="server" />
                        <asp:HiddenField ID="area_code" runat="server" />

                     </span></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">手机号码<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="telephon" runat="server" Text=""></asp:TextBox>
                       
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">常用邮箱<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="mail" runat="server" Text="" ></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">民族</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                         <asp:DropDownList ID="minzu" runat="server">
                    <asp:ListItem Text="汉族" Value="汉族" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="阿昌族" Value="阿昌族"></asp:ListItem>
                    <asp:ListItem Text="白族" Value="白族"></asp:ListItem>
                    <asp:ListItem Text="保安族" Value="保安族"></asp:ListItem> 
                    <asp:ListItem Text="布朗族" Value="布朗族"></asp:ListItem>
                    <asp:ListItem Text="布依族" Value="布依族"></asp:ListItem>
                    <asp:ListItem Text="朝鲜族" Value="朝鲜族"></asp:ListItem>
                    <asp:ListItem Text="达斡尔族" Value="达斡尔族"></asp:ListItem>
                    <asp:ListItem Text="傣族" Value="傣族"></asp:ListItem>
                    <asp:ListItem Text="德昂族" Value="德昂族"></asp:ListItem>
                    <asp:ListItem Text="侗族" Value="侗族"></asp:ListItem>
                    <asp:ListItem Text="东乡族" Value="东乡族"></asp:ListItem>
                    <asp:ListItem Text="独龙族" Value="独龙族"></asp:ListItem>
                    <asp:ListItem Text="鄂伦春族" Value="鄂伦春族"></asp:ListItem>
                    <asp:ListItem Text="俄罗斯族" Value="俄罗斯族"></asp:ListItem>
                    <asp:ListItem Text="鄂温克族" Value="鄂温克族"></asp:ListItem>
                    <asp:ListItem Text="高山族" Value="高山族"></asp:ListItem>
                    <asp:ListItem Text="仡佬族" Value="仡佬族"></asp:ListItem>
                    <asp:ListItem Text="哈尼族" Value="哈尼族"></asp:ListItem>
                    <asp:ListItem Text="哈萨克族" Value="哈萨克族"></asp:ListItem>
                    <asp:ListItem Text="赫哲族" Value="赫哲族"></asp:ListItem>
                    <asp:ListItem Text="回族" Value="回族"></asp:ListItem>
                    <asp:ListItem Text="基诺族" Value="基诺族"></asp:ListItem>
                    <asp:ListItem Text="京族" Value="京族"></asp:ListItem>
                    <asp:ListItem Text="景颇族" Value="景颇族"></asp:ListItem>
                    <asp:ListItem Text="柯尔克孜族" Value="柯尔克孜族"></asp:ListItem>
                    <asp:ListItem Text="拉祜族" Value="拉祜族"></asp:ListItem>
                    <asp:ListItem Text="黎族" Value="黎族"></asp:ListItem>
                    <asp:ListItem Text="傈僳族" Value="傈僳族"></asp:ListItem>
                    <asp:ListItem Text="珞巴族" Value="珞巴族"></asp:ListItem>
                    <asp:ListItem Text="满族" Value="满族"></asp:ListItem>
                    <asp:ListItem Text="毛南族" Value="毛南族"></asp:ListItem>
                    <asp:ListItem Text="门巴族" Value="门巴族"></asp:ListItem>
                    <asp:ListItem Text="蒙古族" Value="蒙古族"></asp:ListItem>
                    <asp:ListItem Text="苗族" Value="苗族"></asp:ListItem>
                    <asp:ListItem Text="仫佬族" Value="仫佬族"></asp:ListItem>
                    <asp:ListItem Text="纳西族" Value="纳西族"></asp:ListItem>
                    <asp:ListItem Text="怒族" Value="怒族"></asp:ListItem>
                    <asp:ListItem Text="普米族" Value="普米族"></asp:ListItem>
                    <asp:ListItem Text="羌族" Value="羌族"></asp:ListItem>
                    <asp:ListItem Text="撒拉族" Value="撒拉族"></asp:ListItem>
                    <asp:ListItem Text="畲族" Value="畲族"></asp:ListItem>
                    <asp:ListItem Text="水族" Value="水族"></asp:ListItem>
                    <asp:ListItem Text="塔吉克族" Value="塔吉克族"></asp:ListItem>
                    <asp:ListItem Text="塔塔尔族" Value="塔塔尔族"></asp:ListItem>
                    <asp:ListItem Text="土族" Value="土族"></asp:ListItem>
                    <asp:ListItem Text="土家族" Value="土家族"></asp:ListItem>
                    <asp:ListItem Text="佤族" Value="佤族"></asp:ListItem>
                    <asp:ListItem Text="锡伯族" Value="锡伯族"></asp:ListItem>
                    <asp:ListItem Text="乌兹别克族" Value="乌兹别克族"></asp:ListItem>
                    <asp:ListItem Text="瑶族" Value="瑶族"></asp:ListItem>
                    <asp:ListItem Text="彝族" Value="彝族"></asp:ListItem>
                    <asp:ListItem Text="裕固族" Value="裕固族"></asp:ListItem>
                    <asp:ListItem Text="裕固族" Value="裕固族"></asp:ListItem>
                    <asp:ListItem Text="维吾尔族" Value="维吾尔族"></asp:ListItem>
                    <asp:ListItem Text="壮族" Value="壮族"></asp:ListItem>
         </asp:DropDownList>
                    </span></td>
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">紧急联系人</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="urgent" runat="server" Text=""></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">紧急联系人手机</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="urgent_telephon" runat="server" Text="" ></asp:TextBox>
                    </span></td>
                   
                    <td width="10%" class="detailTitle" style="height: 25px"></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                    </span></td>
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">本科毕业院校</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="bk_school" runat="server" Text=""></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">本科专业</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="bk_major" runat="server" Text="" ></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">本科毕业时间</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="graduation_time" runat="server" Text="" onfocus="setmonth(this);"></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">最高学历</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <%--<asp:TextBox ID="high_education" runat="server" Text=""></asp:TextBox>--%>
                        <asp:DropDownList ID="high_education" runat="server">
                            <asp:ListItem>专科</asp:ListItem>
                            <asp:ListItem>本科</asp:ListItem>
                            <asp:ListItem>硕士研究生</asp:ListItem>
                            <asp:ListItem>博士研究生</asp:ListItem>
                            
                        </asp:DropDownList>
                    </span></td>
                    <td width="14%" class="detailTitle" style="height: 25px">最高学历毕业院校<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="high_school" runat="server" Text="" ></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">最高学历专业<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="high_major" runat="server" Text=""></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <td width="14%" class="detailTitle" style="height: 25px">获得最高学历时间<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="high_education_time" runat="server" Text="" onfocus="setmonth(this);"></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">身份类型</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <%--<asp:TextBox ID="identity_type" runat="server" Text="" ></asp:TextBox>--%>
                        <asp:DropDownList ID="identity_type" runat="server">
                            <asp:ListItem Value="单位人" Text="单位人" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="社会人" Text="社会人"></asp:ListItem>
                        </asp:DropDownList>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">派出单位</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="send_unit" runat="server" Text=""></asp:TextBox>
                    </span></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px" colspan="3"><span class="detailContent" style="height: 25px">
                        <select id="training_base_province" name="training_base_province" style="width:150px">
                            <option value="0">==所在省市==</option>
                        </select>
                        <select id="training_base" name="training_base" style="width:150px">
                            <option value="0">==请选择==</option>
                        </select>
                        <asp:HiddenField ID="training_base_province_code" runat="server" />
                        <asp:HiddenField ID="training_base_province_name" runat="server" />
                        <asp:HiddenField ID="training_base_code" runat="server" />
                        <asp:HiddenField ID="training_base_name" runat="server" />
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">协同单位</td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="collaborative_unit" runat="server" Text="" ></asp:TextBox>
                    </span></td>
                    
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">培训专业<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                       <select id="professional_base" name="professional_base" style="width:150px">
                           <option value="0">==请选择==</option>
                       </select><asp:HiddenField ID="professional_base_code" runat="server" />
                    <asp:HiddenField ID="professional_base_name" runat="server" />
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">参训时间<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="training_time" runat="server" Text="" ></asp:TextBox>
                    </span></td>
                    <td width="10%" class="detailTitle" style="height: 25px">计划参训时限<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                        <asp:DropDownList ID="plan_training_time" runat="server">
                            <asp:ListItem>1年</asp:ListItem>
                            <asp:ListItem>2年</asp:ListItem>
                            <asp:ListItem>3年</asp:ListItem>
                            <asp:ListItem>4年</asp:ListItem>
                            <asp:ListItem>5年</asp:ListItem>
                            <asp:ListItem>6年</asp:ListItem>
                            <asp:ListItem>7年</asp:ListItem>
                            <asp:ListItem>8年</asp:ListItem>
                            <asp:ListItem>9年</asp:ListItem>
                            <asp:ListItem>10年</asp:ListItem>
                            
                        </asp:DropDownList>
                    </span></td>
                </tr>

                <tr>

                    <td width="10%" class="detailTitle" style="height: 25px"></td>
                    <td width="23%" class="detailContent" style="height: 25px" colspan="5">
                        <table>
                            <tr>
                                
                                <td width="40%" class="detailContent" style="height: 25px" ></td>
                                
                                <td width="10%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="23%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="writor" runat="server" Text=""></asp:TextBox>
                                </span></td>
                                <td width="10%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="23%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="register_date" runat="server" Text="" ></asp:TextBox>
                                </span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="last">
                    <td colspan="6" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;" OnClick="save_Click"/>
                            <a style="padding-left: 2em"></a>
                            <input type="button"  style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                         </div>
                    </td>
                </tr>


           </table>

        </div>
    </form>
</body>
</html>
