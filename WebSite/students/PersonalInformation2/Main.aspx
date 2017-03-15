<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="students_PersonalInformation2_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人基本信息</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/bootstrap-2.3.3/js/bootstrap.min.js"></script>
    <script src="../../js/yearmonth.js"></script>
    <link href="../../js/jqueryAutocomplete/jquery.autocomplete.css" rel="stylesheet" />
    <script src="../../js/jqueryAutocomplete/jquery.autocomplete.js"></script>
    <script src="../../js/SWFUpload/handlers.js"></script>
    <script src="../../js/SWFUpload/swfupload.js"></script>
    <link href="../../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">       
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
                button_text_left_padding: 5,

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
            var result = eval('(' + serverData + ')');
            if (result.imgSrc == "0") {
                alert("请选择格式为:jpg、png、bmp、gif、jpeg的头像进行上传");
                return;

            } else if (result.imgSrc == "1") {
                alert("请选择头像进行上传");
                return;
            } else {
                $("#imgUpload").attr("src", result.imgSrc);
                $("#ImagePath").val(result.imgSrc);
                $("#divFileProgressContainer").fadeOut("slow");
            }
        }

    </script>

    <script type="text/javascript">
        $(function () {
       
            $.post("../ashx/ProfessionalBase.ashx", function (data) {
                dat = eval(data);
                if (dat != "") {
                    for (var i = 0; i < dat.length; i++) {
                        if (dat[i].professional_base_code == $("#ProfessionalBase").val()) {
                            $("#ProfessionalBase").append("<option Value=" + dat[i].professional_base_code + " selected='selected'>" + dat[i].professional_base_name + "</option>");
                        } else {
                            $("#ProfessionalBase").append("<option Value=" + dat[i].professional_base_code + ">" + dat[i].professional_base_name + "</option>");
                        }
                    }
                }
            });

            $("#ProfessionalBase").change(function () {
                var pbname = $("#ProfessionalBase").find("option:selected").text();
                var pbcode = $("#ProfessionalBase").find("option:selected").val();

                if (pbcode == "") {
                    $("#ProfessionalBaseName").val("");
                    return;
                } else {
                    $("#ProfessionalBaseName").val(pbname);
                }
            });

            $("#IdentityType").change(function () {
                if ($("#IdentityType").val() == "单位人") {
                    $("#SendUnit").removeAttr("disabled");
                } else {
                    $("#SendUnit").attr("disabled", "disabled");
                    $("#SendUnit").val("");
                }

            });
        })
    </script>

     <script type="text/javascript">

         function checkIdNumberAndcountBirthDateAndcountAge() {
             if (!isIdCardNo(document.getElementById('IdNumber').value)) {
                 document.getElementById('IdNumber').focus();
             } else {
                 countBirthDate();
                 //countAge();
             }

         }

         function countBirthDate() {
             var cardNum = document.getElementById('IdNumber').value;
             var date = "";
             if (cardNum.length == 15) {
                 
                 alert("请输入18位第二代身份证号码");
                 return;
             }
             else {
                 date = "";
                 date = date + cardNum.substring(6, 10) + "-" + cardNum.substring(10, 12) + "-" + cardNum.substring(12, 14);
                 
                 //document.getElementById('DateBirth').innerText = date;
                 document.getElementById('DateBirth').value = date;
                 //$("#DateBirth").val(date);
                 
             }
             return true;
         }

         function countAge() {
             var cardNum = document.getElementById('IdNumber').value;
             var birthDate = "";
             if (cardNum.length == 15) {
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
             $.ajax({
                 cache: false,
                 type: "get",
                 url: "ashx/SchoolName.ashx",
                 dataType: "text",
                 success: function (data) {
                     jsonArr = eval('(' + data + ')');
                     $("#BkSchool").autocomplete(jsonArr, {
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
                     $("#HighSchool").autocomplete(jsonArr, {
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

    <script type="text/javascript">
        var Name = "<%:Name%>";
        var RealName = "<%:RealName%>";
        var TrainingBaseCode = "<%:TrainingBaseCode%>";
        var TrainingBaseName = "<%:TrainingBaseName%>";
        $(function () {
            $("#Name").val(Name);
            $("#RealName").val(RealName);
            $("#TrainingBaseCode").val(TrainingBaseCode);
            $("#TrainingBaseName").val(TrainingBaseName);

            loadData();
        });

        function saveAndUpdate() {
            if ($("#RealName").val() == "") { alert("姓名不能为空"); return;}
            if ($("#IdNumber").val() == "") { alert("居民身份证号不能为空"); return; }
            if ($("#Telephon").val() == "") { alert("手机号码不能为空"); return; }
            if ($("#TrainingBase").val() == "") { alert("培训基地不能为空"); return; }
            if ($("#ProfessionalBase").val() == "") { alert("培训专业不能为空"); return }

            var forms = $("#form1").serializeArray();
            $.ajax({
                cache: false,
                async: true,
                type: "post",
                url: "ashx/AddUpdate.ashx",
                dataType: "text",
                data: forms,
                success: function (data) {
                    alert(data);
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }

        function loadData() {

            $.ajax({
                cache: false,
                async: true,
                type: "get",
                url: "ashx/GetData.ashx",
                dataType: "text",
                data: {name:Name},
                success: function (data) {
                    if (data == "") {
                        return;
                    } else {
                        var jsonArr = eval("(" + data + ")");
                        //$("#TouXiang").css("display", "none");

                        $("#Id").val(jsonArr[0].Id);
                        $("#Name").val(jsonArr[0].Name);
                        $("#RealName").val(jsonArr[0].RealName);
                        $("#ImagePath").val(jsonArr[0].ImagePath);

                        if ($("#ImagePath").val() == "") {
                            $("#imgUpload").attr("src", "../../images/head1.jpg");

                        } else {
                            $("#imgUpload").attr("src", $("#ImagePath").val());
                        }
                        

                        $("input[name='Sex'][value='" + jsonArr[0].Sex + "']").attr("checked", true);

                        $("#IdNumber").val(jsonArr[0].IdNumber);
                        $("#DateBirth").val(jsonArr[0].DateBirth);
                        $("#MinZu").val(jsonArr[0].MinZu);
                        $("#Telephon").val(jsonArr[0].Telephon);
                        $("#Mail").val(jsonArr[0].Mail);
                        $("#BkSchool").val(jsonArr[0].BkSchool);
                        $("#BkMajor").val(jsonArr[0].BkMajor);
                        $("#GraduationTime").val(jsonArr[0].GraduationTime); $("#HighEducation").val(jsonArr[0].HighEducation);
                        $("#HighSchool").val(jsonArr[0].HighSchool);
                        $("#HighMajor").val(jsonArr[0].HighMajor);
                        $("#HighEducationTime").val(jsonArr[0].HighEducationTime);
                        $("#IdentityType").val(jsonArr[0].IdentityType);
                        if ($("#IdentityType").val() == "社会人") {
                            $("#SendUnit").attr("disabled", true);
                        }
                        $("#SendUnit").val(jsonArr[0].SendUnit);
                        $("#TrainingBaseCode").val(jsonArr[0].TrainingBaseCode);
                        $("#TrainingBaseName").val(jsonArr[0].TrainingBaseName);
                        $("#CollaborativeUnit").val(jsonArr[0].CollaborativeUnit);
                        $("#ProfessionalBase").val(jsonArr[0].ProfessionalBaseCode);
                        $("#ProfessionalBaseName").val(jsonArr[0].ProfessionalBaseName);
                        $("#TrainingTime").val(jsonArr[0].TrainingTime);
                        $("#PlanTrainingTime").val(jsonArr[0].PlanTrainingTime);
                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }
    </script>
</head>
<body style="text-align: center;">
    <form id="form1" runat="server" class="form-inline" role="form">
           <div style="margin:auto;width:800PX;">
            <table class="table table-bordered table-condensed" border="0" style="border-collapse: collapse;width:100%;">
                <tr>
                    <td style="height:20px;text-align:center;" colspan="4"><h4>填写个人基本信息</h4></td>
                </tr>
                <tr>
                    <td style="height: 20px;width:150px;text-align:right;" >
                        <label class="sr-only" for="RealName">姓名<span style="color:red">*</span></label>

                    </td>
                    <td style="height:20px;width:200px;">
                        <input type="text" id="RealName" name="RealName" style="height:20px;width:150px;" readonly="readonly"/>
                        <input type="hidden" id="Name" name="Name" />
                        <input type="hidden" id="Id" name="Id" />
                    </td>

                    <td style="height: 50px; width: 400PX;" colspan="2" rowspan="5">
                        <div style="float: left; width: 30%; height: 125px; margin-left: 70px; margin-top: 5px;">
                            <img src="../../images/head1.jpg" alt="头像" id="imgUpload" style="width: 120px; height: 160px;" />
                            <input type="hidden" id="ImagePath" name="ImagePath" />

                        </div>
                        <div style="float: left; vertical-align: middle; margin-top: 100px;display:block;" id="TouXiang">
                            <div><span id="spanButtonPlaceholder"></span></div>
                            <div id="divFileProgressContainer" style="height: 60px;"></div>
                        </div>

                    </td>
                    
                </tr>
                <tr>
                    <td style="height: 20px; width: 150px;text-align:right;">
                        <label class="sr-only" for="Sex">性别</label><span style="color: #ff0000">*</span>

                    </td>
                    <td style="height: 20px; width:200px;">
                        <label>
                            <input type="radio" id="Man" name="Sex" checked="checked" value="男"/>男</label>
                        <label>
                            <input type="radio" id="Woman" name="Sex" value="女"/>女</label>
                    </td>
                </tr>

                <tr>
                    <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="IdNumber">居民身份证号<span style="color: #ff0000">*</span></label></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="IdNumber" name="IdNumber" style="height:20px;width:150px;" onblur="checkIdNumberAndcountBirthDateAndcountAge()" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="DateBirth">出生日期</label></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="DateBirth" name="DateBirth" style="height:20px;width:150px;"/>
                    </td>
                 </tr>
               <tr>
                    <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="MinZu">民族</label><span style="color: #ff0000">*</span></td>
                    <td style="height: 20px;width:200px;">
                        <select id="MinZu" name="MinZu" style="width:160px">
                                <option value="汉族" selected="selected">汉族</option>
                                <option value="蒙古族">蒙古族</option>
                                <option value="彝族">彝族</option>
                                <option value="侗族">侗族</option>
                                <option value="哈萨克族">哈萨克族</option>
                                <option value="畲族">畲族</option>
                                <option value="纳西族">纳西族</option>
                                <option value="仫佬族">仫佬族</option>
                                <option value="仡佬族">仡佬族</option>
                                <option value="怒族">怒族</option>
                                <option value="保安族">保安族</option>
                                <option value="鄂伦春族">鄂伦春族</option>
                                <option value="回族">回族</option>
                                <option value="壮族">壮族</option>
                                <option value="瑶族">瑶族</option>
                                <option value="傣族">傣族</option>
                                <option value="高山族">高山族</option>
                                <option value="景颇族">景颇族</option>
                                <option value="羌族">羌族</option>
                                <option value="锡伯族">锡伯族</option>
                                <option value="乌孜别克族">乌孜别克族</option>
                                <option value="裕固族">裕固族</option>
                                <option value="赫哲族">赫哲族</option>
                                <option value="藏族">藏族</option>
                                <option value="布依族">布依族</option>
                                <option value="白族">白族</option>
                                <option value="黎族">黎族</option>
                                <option value="拉祜族">拉祜族</option>
                                <option value="柯尔克孜族">柯尔克孜族</option>
                                <option value="布朗族">布朗族</option>
                                <option value="阿昌族">阿昌族</option>
                                <option value="俄罗斯族">俄罗斯族</option>
                                <option value="京族">京族</option>
                                <option value="门巴族">门巴族</option>
                                <option value="维吾尔族">维吾尔族</option>
                                <option value="朝鲜族">朝鲜族</option>
                                <option value="土家族">土家族</option>
                                <option value="傈僳族">傈僳族</option>
                                <option value="水族">水族</option>
                                <option value="土族">土族</option>
                                <option value="撒拉族">撒拉族</option>
                                <option value="普米族">普米族</option>
                                <option value="鄂温克族">鄂温克族</option>
                                <option value="塔塔尔族">塔塔尔族</option>
                                <option value="珞巴族">珞巴族</option>
                                <option value="苗族">苗族</option>
                                <option value="满族">满族</option>
                                <option value="哈尼族">哈尼族</option>
                                <option value="佤族">佤族</option>
                                <option value="东乡族">东乡族</option>
                                <option value="达斡尔族">达斡尔族</option>
                                <option value="毛南族">毛南族</option>
                                <option value="塔吉克族">塔吉克族</option>
                                <option value="德昂族">德昂族</option>
                                <option value="独龙族">独龙族</option>
                                <option value="基诺族">基诺族</option>
                            </select>
                    </td>
                 </tr>
                 <tr>
                    <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="Telephon">手机号码</label><span style="color: #ff0000">*</span></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="Telephon" name="Telephon" style="height:20px;width:150px;"/>
                    </td>
                      <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="Mail">常用邮箱</label></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="Mail" name="Mail" style="height:20px;width:150px;"/>
                    </td>
                 </tr>
                 <tr>
                    <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="BkSchool">本科毕业院校</label></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="BkSchool" name="BkSchool" style="height:20px;width:150px;"/>
                    </td>
                      <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="BkMajor">本科专业</label></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="BkMajor" name="BkMajor" style="height:20px;width:150px;"/>
                    </td>
                 </tr>   
                   <tr>
                    <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="GraduationTime">本科毕业时间</label></td>
                    <td style="height: 20px;width:200px;">
                        <input type="text" id="GraduationTime" name="GraduationTime" style="height:20px;width:150px;" onfocus="setmonth(this);"/>
                    </td>
                      <td style="height: 20px;width:150px;text-align:right"><label class="sr-only" for="HighEducation">最高学历</label><span style="color: #ff0000">*</span></td>
                    <td style="height: 20px;width:200px;">
                        <select style="width:160px;" id="HighEducation" name="HighEducation">
                            <option value="专科">专科</option>
                            <option value="本科">本科</option>
                            <option value="硕士研究生" selected="selected">硕士研究生</option>
                            <option value="博士研究生">博士研究生</option>
                        </select>
                    </td>
                 </tr>   
                <tr>
                    <td colspan="4">
                        <table>
                            <tr>
                                <td style="height: 20px; width: 150px; text-align: right">
                                    <label class="sr-only" for="HighSchool">最高学历毕业院校</label></td>
                                <td style="height: 20px; width: 100px;">
                                    <input type="text" id="HighSchool" name="HighSchool" style="height: 20px; width: 100px;" />
                                </td>
                                <td style="height: 20px; width: 150px; text-align: right">
                                    <label class="sr-only" for="HighMajor">最高学历专业</label></td>
                                <td style="height: 20px; width: 100px;">
                                    <input type="text" id="HighMajor" name="HighMajor" style="height: 20px; width: 100px;" />
                                </td>
                                <td style="height: 20px; width: 150px; text-align: right">
                                    <label class="sr-only" for="HighEducationTime">获得最高学历时间</label></td>
                                <td style="height: 20px; width: 100px;">
                                    <input type="text" id="HighEducationTime" name="HighEducationTime" style="height: 20px; width: 100px;" onfocus="setmonth(this);" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px; width: 150px; text-align: right">
                        <label class="sr-only" for="IdentityType">身份类型</label><span style="color: #ff0000">*</span></td>
                    <td style="height: 20px; width: 200px;">
                        <select style="width: 160px;" id="IdentityType" name="IdentityType">
                            <option value="单位人" selected="selected">单位人</option>
                            <option value="社会人">社会人</option>
                        </select>
                    </td>
                    <td style="height: 20px; width: 150px; text-align: right">
                        <label class="sr-only" for="SendUnit">派出单位</label><span style="color: #ff0000">*</span></td>
                    <td style="height: 20px; width: 200px;">
                        <input type="text" id="SendUnit" name="SendUnit" style="height: 20px; width: 150px;"/>
                    </td>
                </tr>
                <tr>

                    <td style="height: 20px; width: 100px; text-align: right">
                        <label class="sr-only" for="TrainingBaseName">培训基地</label><span style="color: #ff0000">*</span></td>
                    <td style="height: 20px; width: 200px;">
                        <input type="text" id="TrainingBaseName" name="TrainingBaseName" style="height: 20px; width: 150px;" readonly="readonly"/>
                        <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                        <%--<select style="width: 150px;" id="TrainingBaseProvince" name="TrainingBaseProvince">
                            <option value="">==所在省市==</option>
                        </select><input type="hidden" id="TrainingBaseProvinceName" name="TrainingBaseProvinceName" />
                        <select style="width: 150px;" id="TrainingBase" name="TrainingBase">
                            <option value="">==请选择==</option>
                        </select><input type="hidden" id="TrainingBaseName" name="TrainingBaseName" />--%>
                    </td>
                    <td style="height: 20px; width: 150px; text-align: right">
                        <label class="sr-only" for="CollaborativeUnit">协同单位</label></td>
                    <td style="height: 20px; width: 200px;">
                        <input type="text" id="CollaborativeUnit" name="CollaborativeUnit" style="height: 20px; width: 150px;" />
                    </td>

                </tr>
               <tr>
                    <td colspan="4">
                        <table>
                            <tr>
                                <td style="height: 20px; width: 150px; text-align: right">
                                    <label class="sr-only" for="ProfessionalBase">培训专业</label><span style="color: #ff0000">*</span></td>
                                <td style="height: 20px; width: 100px;">
                                    <select id="ProfessionalBase" name="ProfessionalBase" style="width: 160px">
                                        <option value="">==请选择==</option>
                                    </select><input type="hidden" id="ProfessionalBaseName" name="ProfessionalBaseName" />
                                </td>
                                <td style="height: 20px; width: 150px; text-align: right">
                                    <label class="sr-only" for="TrainingTime">参训时间</label><span style="color: #ff0000">*</span></td>
                                <td style="height: 20px; width: 100px;">
                                   <select id="TrainingTime" name="TrainingTime" style="width: 100px">
                                        <option value="2012年">2012年</option>
                                        <option value="2013年">2013年</option>
                                        <option value="2014年">2014年</option>
                                        <option value="2015年">2015年</option>
                                        <option value="2016年" selected="selected">2016年</option>
                                        <option value="2017年">2017年</option>
                                        <option value="2018年">2018年</option>
                                        <option value="2019年">2019年</option>
                                        <option value="2020年">2020年</option>
                                        <option value="2021年">2021年</option>
                                        <option value="2022年">2022年</option>
                                    </select>
                                </td>
                                <td style="height: 20px; width: 150px; text-align: right">
                                    <label class="sr-only" for="PlanTrainingTime">计划参训时限</label><span style="color: #ff0000">*</span></td>
                                <td style="height: 20px; width: 100px;">
                                    <select id="PlanTrainingTime" name="PlanTrainingTime" style="width: 100px">
                                        <option value="1年">1年</option>
                                        <option value="2年" selected="selected">2年</option>
                                        <option value="3年">3年</option>
                                        <option value="4年">4年</option>
                                        <option value="5年">5年</option>
                                        <option value="6年">6年</option>
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

           </table>
               <div>
                   <input type="button" id="SaveUpdate" name="SaveUpdate" class="btn btn-success" value="保存" onclick="saveAndUpdate()" />
               </div>

           </div>

    </form>
</body>
</html>
