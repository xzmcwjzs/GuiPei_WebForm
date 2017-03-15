<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="QuestionBank_List" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>题库训练</title>
    <script src="../js/jquery-1.7.2.js"></script>
    <script src="../js/global.js"></script>
    <link href="../css/global.css" rel="stylesheet" />
    <script src="../js/bootstrap-2.3.3/js/bootstrap.min.js"></script>
    <link href="../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/jquery.jqprint-0.3.js"></script>
    <script type="text/javascript">
        $(function () {
            //禁用鼠标右键，文档选择，复制
            $("body").bind("contextmenu", function (event) {
                return false;
            });
            $("body").bind("selectstart", function () { return false; });
            //禁用键盘相关操作
            $("body").bind("keydown", function (e) {
                e = window.event || e;
                //屏蔽F5刷新键 
                if (event.keyCode == 116) {
                    e.keyCode = false;
                    return false;
                }
                //屏蔽 Alt+ 方向键 ← 
                //屏蔽 Alt+ 方向键 →
                if ((event.altKey) && ((event.keyCode == 37) || (event.keyCode == 39))) {
                    event.returnValue = false;
                    return false;
                }
                //屏蔽退格删除键 
                if (event.keyCode == 8) {
                    return false;
                }

                //屏蔽ctrl+R 
                if ((event.ctrlKey) && (event.keyCode == 82)) {
                    e.keyCode = 0;
                    return false;
                }
                if (event.keyCode == 122) { event.keyCode = 0; event.returnValue = false; }    //屏蔽F11   
                if (event.ctrlKey && event.keyCode == 78) event.returnValue = false;      //屏蔽Ctrl+n   
                if (event.shiftKey && event.keyCode == 121) event.returnValue = false;    //屏蔽shift+F10   
                if (window.event.srcElement.tagName == "A" && window.event.shiftKey)
                    window.event.returnValue = false;       //屏蔽shift加鼠标左键新开一网页   
                if ((window.event.altKey) && (window.event.keyCode == 115)) {             //屏蔽Alt+F4    
                    window.showModelessDialog("about:blank", "", "dialogWidth:1px;dialogheight:1px");
                    return false;
                }
            });
        });
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img  height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />题库训练                    
                </td>
             </tr>
        </table>
    </div>
    
   <div class="panel panel-default" id="tiku" style="margin-bottom:100px;width:80%;margin-left:10%;">
   </div>
 
<!-- 模态框（Modal） -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
   <div class="modal-dialog">
      <div class="modal-content">
         <div class="modal-header">
           <h4 class="modal-title" id="myModalLabel">
               题库训练须知
            </h4>
         </div>
         <div class="modal-body">
             一、该题库训练为50道单选题，满分100，题目范围为所培训的专业<br />
             二、请在规定时间内完成，可提前交卷，否则将强制交卷<br />
             三、系统将自动阅卷、评分，并显示正确答案<br />
             四、若中途有事，可进行暂停稍后作答<br />
             五、祝愿每位学员取得优异成绩<br />
         </div>
         <div class="modal-footer" style="text-align:center">
             <select class="btn btn-default"  id="ProfessionalBaseCode" name="ProfessionalBaseCode">
                 <option value="0100">内科</option>
                 <option value="0900">外科</option>
             </select>
            <input class="btn btn-default"  type="button" id="close" name="close"/>
         </div>
      </div><!-- /.modal-content -->
</div><!-- /.modal -->
</div>

  <div id="footer" style="position:fixed; bottom:0;left:0;height:40px;width:100%;background-color:#2d832c;text-align:center;">
      <div style="position:fixed; bottom:10px;left:100px;">
          <a href="#top" style="text-decoration:none;color:white;font-size:20px;">返回顶部</a>
       </div>
        <div style="position:fixed; bottom:10px;left:200px;">
            <span style="color:white;font-size:20px;">剩余</span>
        </div> 
      <div style="position:fixed; bottom:7px;left:250px;">
            <span style="color:white;"><label id="endTime"></label></span>
      </div> 
      <div style="position:fixed; bottom:7px;left:350px;">
            <input type="button" id="operate" name="operate" class="btn btn-default"  value="暂停"/>
      </div> 
      <div style="position:fixed; bottom:10px;left:420px;">
            <span style="color:white;font-size:20px;">共50道单选题</span>
        </div> 
      <div style="position:fixed; bottom:7px;left:600px;">
         <input type="button" id="endExam" name="endExam" class="btn btn-default"  value="交卷" onclick="examEnd('1');"/>
      </div> 
      <div style="position:fixed; bottom:7px;left:700px;">
         <input type="button" id="print" name="print" class="btn btn-default"  value="打印" onclick="tkPrint();"/>
      </div> 
  </div>

   </form>
  
   <script>
       var time = 5;
       var endTime;
       var oTime;
       var StudentsName = "<%=StudentsName%>";
       var StudentsRealName = "<%=StudentsRealName%>";
       var TrainingBaseCode = "<%=TrainingBaseCode%>";
       var TrainingBaseName = "<%=TrainingBaseName%>";
       var RegisterDate = "<%=Common.CommonFunc.SafeGetMyDateTimeStringFromObjectByFormat(DateTime.Now.ToString(),"yyyy-MM-dd hh:mm")%>";
       
       $(function () {
           $('#myModal').modal({
               keyboard: false,
               backdrop: 'static',
               show: true
           });
           $("#close").attr("disabled", true);
          
           $("#close").val(("" + (time) + "秒后可进行题库训练"));
           setInterval(function () {
               if (time <= 0) {
                   $("#close").val("我已认真阅读题库训练须知");
                   $("#close").removeAttr("disabled");
               }
               else {
                   $("#close").attr({ "disabled": "disabled" });
                   $("#close").val("" + (time--) + "秒后可进行题库训练");
               }
           }, 1000);

           
           function setTime(countdown) {
                endTime=setInterval(function () {
                   
                    if (countdown < 0) {
                        alert("考试时间到");
                       examEnd("0");
                       return;
                   } else {
                       var second = countdown % 60;
                       var minute = parseInt(countdown / 60) % 60;
                       var hour = parseInt(parseInt(countdown / 60) / 60);

                       if (hour < 10)
                           hour = "0" + hour.toString();
                       if (second < 10)
                           second = "0" + second.toString();
                       if (minute < 10)
                           minute = "0" + minute.toString();

                       $("#endTime").text(hour + "时" + minute + "分" + second + "秒");
                       countdown--;
                       oTime = countdown;
                   }

               }, 1000);
           }
           $("#operate").click(function () {
               if ($(this).val() == "暂停") {
                   clearInterval(endTime);
                   $(this).attr("value","开始");
               } else {
                   setTime(oTime);
                   $(this).attr("value", "暂停");
               }
           });
        
           
           $("#close").click(function () {
               $('#myModal').modal('hide');
               var ProfessionalBaseCode = $("#ProfessionalBaseCode").val();
               $.ajax({
                   cache: false,
                   type: "get",
                   url: "ashx/Load.ashx",
                   dataType: "text",
                   data: { code: ProfessionalBaseCode },
                   success: function (data) {
                       var jsonArr = eval("(" + data + ")");
                       var j = 1;
                       for (i = 0; i < jsonArr.length; i++) {
                           var strHtml = "<div class='panel-heading'><h5 class='panel-title'>" +
                                           j + jsonArr[i].Question.substr(jsonArr[i].Question.indexOf("."), jsonArr[i].Question.length - 1) +
                                           "</h5></div>";
                           strHtml += "<table class='table table-condensed'>" +
                               "<tr><td><label><input type='radio' id='queA" + j + "' name='que" + j + "' value='A' style='width:20px;'/>" +
                               "A" + jsonArr[i].OptionA + "</label></td></tr>" +
                               "<tr><td><label><input type='radio' id='queB" + j + "' name='que" + j + "' value='B' style='width:20px;'/>" +
                               "B" + jsonArr[i].OptionB + "</label></td></tr>" +
                               "<tr><td><label><input type='radio' id='queC" + j + "' name='que" + j + "' value='C' style='width:20px;'/>" +
                               "C" + jsonArr[i].OptionC + "</label></td></tr>" +
                               "<tr><td><label><input type='radio' id='queD" + j + "' name='que" + j + "' value='D' style='width:20px;'/>" +
                               "D" + jsonArr[i].OptionD + "</label></td></tr>" +
                               "<tr><td><label><input type='radio' id='queE" + j + "' name='que" + j + "' value='E' style='width:20px;'/>" +
                               "E" + jsonArr[i].OptionE + "</label></td></tr></table>";

                           strHtml += "<div id='corAnswer"+j+"' class='panel-footer' STYLE='display:none'>"+
                               "<span id='Tip" + j + "'></span>" +
                               "<a style='padding-left:3em;'></a>正确答案为："+
                               "<span id='Answer" + j + "' style='color:red;'>" + jsonArr[i].CorrectAnswer + "</span></div>";
                           j++;
                           $("#tiku").append(strHtml);
                       }
                   },
                   error: function () {
                       alert("系统繁忙，请联系管理员");
                   }
               });
               setTime(1800);

               
           });

       });
       function examEnd(type) {
           if (type == "1") {
               if (confirm("确定现在交卷吗")) {
                   SubmitResult();
               }
           } else {
               SubmitResult();
           }
           
           
       }
       function SubmitResult() {
           clearInterval(endTime);
           var i;
           var n1 = 0, n2 = 0, n3 = 0;
           for (i = 1; i <= 50; i++) {
               $("#corAnswer" + i).css("display", "block");
               var optAsw = $("input[type='radio'][name='que" + i + "']:checked").val();
               var corAsw = $("#Answer" + i).text();

               if (optAsw == "" || optAsw == null) {
                   $("#Tip" + i).text("该题未作答").css({ color: "red" });
                   n3++;
               } else {
                   if (optAsw == corAsw) {
                       $("#Tip" + i).text("回答正确").css({ color: "green" });
                       n1++;
                   } else {
                       $("#Tip" + i).text("回答错误").css({ color: "red" });
                       n2++;
                   }
               }
           }

           $.ajax({
               cache: false,
               type: "post",
               url: "ashx/Add.ashx",
               dataType: "text",
               data: {
                   StudentsName: StudentsName, StudentsRealName: StudentsRealName, TrainingBaseCode: TrainingBaseCode,
                   TrainingBaseName: TrainingBaseName, SubjectName: $("#ProfessionalBaseCode").find("option:selected").text(),
                   SubjectCode: $("#ProfessionalBaseCode").val(), TotalScore: (parseInt(n1) * 2), TotalNum: 50,
                   UndoNum: n3, CorrectNum: n1, ErrorNum: n2, RegisterDate: RegisterDate
                },
               success: function (data) {
                   if (data == "addSuccess") {
                       alert("题库训练信息已保存\r\n回答正确题数：" + n1 + "  回答错误题数：" + n2 + "  未作答题数：" + n3+"\r\n总分为："+2*n1+"分");
                   } else {
                       alert("题库训练信息保存失败");
                   }
                  
               },
               error: function () {
                   alert("系统繁忙，请联系管理员");
               }
           });
       }

       function tkPrint() {
           $("#tiku").jqprint();
       }
   </script>
</body>
</html>
