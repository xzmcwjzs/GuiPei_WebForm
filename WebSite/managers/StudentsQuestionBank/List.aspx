<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="managers_StudentsQuestionBank_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="
    text/html; charset=utf-8" />
    <title>题库训练统计图</title>
    <script src="../../js/jquery-1.7.2.js"></script>
</head>
<body style="text-align:center;">
    <div id="condition" style="width: 800px; height: 100px;margin:auto;">
        <select id="SubjectCode" name="SubjectCode" style="margin-top:40px;">
            <option value="0100" selected="selected">内科</option>
            <option value="0900">外科</option>
        </select>
    </div>
    <div id="main" style="width: 800px; height: 400px;margin:auto;"></div>

    <script src="../../echarts-2.2.7/build/dist/echarts.js"></script>
    <script type="text/javascript">
        var dataX = [''];
        var dataS = [];
        var StudentsName = "fywangj";
        var TrainingBaseCode = "<%=TrainingBaseCode%>";
        var myChart;
        lineChart();
        $("#SubjectCode").change(function () {
            dataX = [''];
            dataS = [];
            lineChart();
        });
        function lineChart() {
            require.config({
                paths: {
                    'echarts': '../../echarts-2.2.7/build/dist'
                }
            });

            require(
             [
                 'echarts',
                 'echarts/chart/line'   // 按需加载所需图表，如需动态类型切换功能，别忘了同时加载相应图表
             ],
             function (ec) {
                 myChart = ec.init(document.getElementById('main'), 'macarons');
                 myChart.showLoading({ text: '数据读取中...' });

                 myChart.hideLoading();//隐藏loading

                 option = {
                     title: {
                         text: '题库训练分数折线图',
                         subtext: '近10次训练分数'
                     },
                     tooltip: {
                         trigger: 'axis'
                     },
                     toolbox: {
                         show: true,
                         feature: {
                             mark: { show: true },
                             dataView: { show: true, readOnly: false },
                             restore: { show: true },
                             saveAsImage: { show: true }
                         }
                     },
                     dataZoom: {
                         show: true,
                         start: 0
                     },
                     legend: {
                         data: ['题库训练分数']
                     },
                     grid: {
                         y2: 80
                     },
                     xAxis: [
                        {
                            type: 'category',
                            boundaryGap: true,
                            data: dataX
                        }
                     ],
                     yAxis: [
                         {
                             type: 'value',
                             axisLabel: {
                                 formatter: '{value} 分'
                             },
                             min: 0,
                             max: 100,
                             splitNumber: 10
                         }
                     ],
                     series: [
                          {
                              name: '题库训练分数',
                              type: 'line',
                              data: dataS,
                              markPoint: {
                                  data: [
                                      { type: 'max', name: '最高分' },
                                      { type: 'min', name: '最低分' }
                                  ]
                              },
                              markLine: {
                                  data: [
                                  { type: 'average', name: '平均分' }
                                  ]
                              }
                          }
                     ]
                 };

                 myChart.setOption(option);
                 myChart.hideLoading();
                 getLineData();
             }
         );

        }

        function getLineData() {
            var options = myChart.getOption();

            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/Load.ashx",
                dataType: "text",
                data: { SubjectCode: $("#SubjectCode").val(), StudentsName: StudentsName, TrainingBaseCode: TrainingBaseCode },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    if (jsonArr == null) {
                        dataX = [''];
                        dataS = [];
                    } else {
                        $.each(jsonArr, function (i, val) {
                            dataX[i] = val['RegisterDate'];
                            dataS[i] = parseInt(val['TotalScore']);
                        });
                    }

                    options.xAxis[0].data = dataX;
                    options.series[0].data = dataS;

                    myChart.hideLoading();
                    myChart.setOption(options);

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }

    </script>

</body>
</html>
