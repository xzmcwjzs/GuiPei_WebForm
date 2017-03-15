<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="bases_StudentsDiseaseRegister_List" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>病种登记</title>
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
        var StudentsRealName = "<%=StudentsRealName%>";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var ProfessionalBaseCode = "<%=ProfessionalBaseCode%>";
        var DeptCode = "";
        var TeachersName = "";
        var DiseaseName = "<%=DiseaseName%>";
        var RequiredNum = "<%=RequiredNum%>";
        var MasterDegree = "<%=MasterDegree%>";

        var DeptName = "<%=DeptName%>";
        var TeachersRealName = "<%=TeachersRealName%>";

        $(window).load(function () {

            loadPageList(1);
        });

        function loadPageList(pi) {
            $.post("../../ASHX/CommonList/DiseaseRegister2List.ashx", {
                "pi": pi,"StudentsRealName":StudentsRealName, "TrainingBaseCode": TrainingBaseCode, "ProfessionalBaseCode": ProfessionalBaseCode, "DeptCode": DeptCode,"TeachersName":TeachersName,
                "DiseaseName": DiseaseName, "RequiredNum": RequiredNum, "MasterDegree": MasterDegree,
                "DeptName": DeptName, "TeachersRealName": TeachersRealName
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
                var temp = jsonArr[i].disease_name;
                var k = 0;
                for (j = 0; j < jsonArr.length; j++) {
                    if (jsonArr[j].disease_name == temp) {
                        k++;
                        arr[i] = k;
                    }
                }

            }
            for (i = 0; i < jsonArr.length; i++) {
                var trHTML = "<tr class='listTableContentRow'>";
                trHTML += "<td style='height:25px'>" + jsonArr[i].students_real_name + "</td>";
                trHTML += "<td>" + jsonArr[i].professional_base_name + "</td>";
                trHTML += "<td>" + jsonArr[i].dept_name + "</td>";
                trHTML += "<td>" + jsonArr[i].disease_name + "</td>";
                if (jsonArr[i].required_num == "" || jsonArr[i].required_num == null) {
                    trHTML += "<td>" + '无' + "</td>";
                } else {
                    trHTML += "<td>" + jsonArr[i].required_num + "</td>";
                }
                trHTML += "<td>" + arr[i] + "</td>";

                if (jsonArr[i].master_degree == "" || jsonArr[i].master_degree == null) {
                    trHTML += "<td>" + '无' + "</td>";
                } else {
                    trHTML += "<td>" + jsonArr[i].master_degree + "</td>";
                }
                trHTML += "<td style='color:red;'>" + jsonArr[i].teacher_check + "</td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].id + "',500,530);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                //trHTML += "<td><a onclick=\"check('" + jsonArr[i].teacher_check + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";

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
                type: "get",
                url: "ashx/Handle.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: { id: id, check: check },
                success: function (data) {
                    if (data == "checkSuccess") {
                        loadPageList(pi);
                        return;
                    } else {
                        alert("审核操作失败");
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
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img  height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />学员病种信息查询结果                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>专业基地</td> 
                <td>轮转科室</td>                                           
                <td>病种名称</td>
                <td>要求例数</td>
                <td>已完成例数</td>
                <td>掌握程度</td>
                <td>审核</td> 
                <td>查看</td>
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
       
    </form>
   
</body>
    
</html>
