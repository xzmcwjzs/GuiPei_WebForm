<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="managers_AdviceFeedback_List" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>意见反馈</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <style type="text/css">
        .button {
            width: 200px;
            height: 20px;
            border: #002D96 1px solid;
            padding: 2px;
            filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#FFFFFF, EndColorStr=#9DBCEA);
            cursor: pointer;
            color: black;
        }

        .tbmover {
            border: #336699 1px solid;
            padding-right: 2px;
            padding-left: 2px;
            cursor: pointer;
        }

        .tbmout {
            padding-right: 3px;
            padding-left: 3px;
        }
    </style>
    <script type="text/javascript">

        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var StudentsRealName = "<%=StudentsRealName%>";
        var ProfessionalBaseName = "<%=ProfessionalBaseName%>";

        var DeptName = "<%=DeptName%>";
        var ManagerHandle = "<%=ManagerHandle%>";
        var RegisterDate = "<%=RegisterDate%>";
        $(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("ashx/List.ashx", {
                "pi": pi, "TrainingBaseCode": TrainingBaseCode, "StudentsRealName": StudentsRealName, "ProfessionalBaseName": ProfessionalBaseName, "DeptName": DeptName,
                "ManagerHandle": ManagerHandle, "RegisterDate": RegisterDate
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
                trHTML += "<td style='height:25px'>" + jsonArr[i].StudentsRealName + "</td>";
                trHTML += "<td>" + jsonArr[i].ProfessionalBaseName + "</td>";
                trHTML += "<td>" + jsonArr[i].DeptName + "</td>";
                trHTML += "<td style='width:30%;'>" + jsonArr[i].FeedbackInformation + "</td>";
                if (jsonArr[i].ManagerReply == "") {
                    trHTML += "<td style='width:10%;'>无</td>";
                } else {
                    trHTML += "<td style='width:10%;'>" + jsonArr[i].ManagerReply + "</td>";
                }
                trHTML += "<td style='color:red;'>" + jsonArr[i].ManagerHandle + "</td>";
                //trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].Id + "&tag=view',600,450);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                trHTML += "<td><a onclick=\"check('" + jsonArr[i].ManagerHandle + "','" + jsonArr[i].Id + "','" + pi + "');\" href='#'><img alt='回复该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
                //trHTML += "<td><a onclick=\"del('" + jsonArr[i].ManagerHandle + "','" + jsonArr[i].Id + "','" + pi + "');\" href='#'><img alt='删除该记录' src='../../images/imgs/icon_del.gif'/></a></td>";
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
        function check(ManagerHandle, id, pi) {
            if (ManagerHandle == "已处理") {
                alert("反馈信息已处理，无法进行回复");
                return;
            } else {
                OpenTopWindow("Manage.aspx?id=" + id + "&pi=" + pi + "&tag=manage", 600, 470);
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
                        <img height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />意见反馈查询结果                  
                    </td>

                </tr>
            </table>
            <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
                <tr id="tr0" class="listTableTitleRow">
                    <td>姓名</td>
                    <td>专业基地</td>
                    <td>轮转科室</td>
                    <td>反馈信息</td>
                    <td>管理员回复</td>
                    <td>状态</td>
                    <td>回复</td>
                </tr>

            </table>
            <div id="PageList" style="text-align: center; vertical-align: middle; margin-top: 10px;">
            </div>

        </div>

    </form>

</body>

</html>


