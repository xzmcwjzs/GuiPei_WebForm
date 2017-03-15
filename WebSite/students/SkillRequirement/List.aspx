<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="students_SkillRequire_List"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>技能要求</title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
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
        var StudentsName = "<%=StudentsName%>";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var DeptName = "<%=DeptName%>";
        var SkillName = "<%=SkillName%>";
        var RequiredNum = "<%=RequiredNum%>";
        var MasterDegree = "<%=MasterDegree%>";

        $(window).load(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("ashx/List.ashx", {
                "pi": pi, "StudentsName": StudentsName, "TrainingBaseCode": TrainingBaseCode, "DeptName": DeptName,
                "SkillName": SkillName, "RequiredNum": RequiredNum, "MasterDegree": MasterDegree
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
            var arr = new Array();
            for (i = 0; i < jsonArr.length; i++) {
                var temp = jsonArr[i].SkillName;
                var k = 0;
                for (j = 0; j < jsonArr.length; j++) {
                    if (jsonArr[j].SkillName == temp) {
                        k++;
                        arr[i] = k;
                    }
                }

            }
            for (i = 0; i < jsonArr.length; i++) {
                var trHTML = "<tr class='listTableContentRow'>";
                trHTML += "<td>" + jsonArr[i].StudentsRealName + "</td>";
                trHTML += "<td>" + jsonArr[i].ProfessionalBaseName + "</td>";
                trHTML += "<td>" + jsonArr[i].DeptName + "</td>";
                trHTML += "<td>" + jsonArr[i].TeacherName + "</td>";
                trHTML += "<td>" + jsonArr[i].SkillName + "</td>";
                if (jsonArr[i].RequiredNum == "" || jsonArr[i].RequiredNum == null) {
                    trHTML += "<td>" + '无' + "</td>";
                } else {
                    trHTML += "<td>" + jsonArr[i].RequiredNum + "</td>";
                }
                trHTML += "<td>" + arr[i] + "</td>";

                if (jsonArr[i].MasterDegree == "" || jsonArr[i].MasterDegree == null) {
                    trHTML += "<td>" + '无' + "</td>";
                } else {
                    trHTML += "<td>" + jsonArr[i].MasterDegree + "</td>";
                }
                trHTML += "<td><font color='red'>" + jsonArr[i].TeacherCheck + "</font></td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('Register.aspx?id=" + jsonArr[i].Id + "&tag=view',520,250);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                trHTML += "<td><a onclick=\"check('" + jsonArr[i].TeacherCheck + "','" + jsonArr[i].Id + "','" + pi + "');\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";

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
        function check(teacher_check, id, pi) {
            if (teacher_check == "已通过") {
                alert("审核已通过，无法进行修改");
                return;
            } else {
                OpenTopWindow("Register.aspx?id=" + id + "&pi=" + pi + "&tag=manage", 520, 250);
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img  height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />技能信息查询结果                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>专业基地</td> 
                <td>轮转科室</td> 
                <td>指导医师</td>                                          
                <td>技能名称</td>
                <td>要求例数</td>
                <td>已完成例数</td>
                <td>掌握程度</td>
                <td>审核</td> 
                <td>查看</td>
                <td>修改</td>
               
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
       
    </form>
   
</body>
    
</html>
