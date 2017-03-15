<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="zzzzzz_Echarts_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../echarts-2.2.7/build/dist/echarts-all.js"></script>
</head>
<body>
    <div id="main" style="width: 600px;height:400px;"></div>
    <script type="text/javascript">
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('main'));

        // 指定图表的配置项和数据
        option = {
            title: {
                text: '时间坐标折线图',
                subtext: 'dataZoom支持'
            },
            tooltip: {
                trigger: 'item',
                formatter: function (params) {
                    var date = new Date(params.value[0]);
                    data = date.getFullYear() + '-'
                           + (date.getMonth() + 1) + '-'
                           + date.getDate() + ' '
                           + date.getHours() + ':'
                           + date.getMinutes();
                    return data + '<br/>'
                           + params.value[1] + ', '
                           + params.value[2];
                }
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
                start: 70
            },
            legend: {
                data: ['series1']
            },
            grid: {
                y2: 80
            },
            xAxis: [
                {
                    type: 'time',
                    splitNumber: 10
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series: [
                {
                    name: 'series1',
                    type: 'line',
                    showAllSymbol: true,
                    symbolSize: function (value) {
                        return Math.round(value[2] / 10) + 2;
                    },
                    data: (function () {
                        var d = [];
                        var len = 0;
                        var now = new Date();
                        var value;
                        while (len++ < 200) {
                            d.push([
                                new Date(2014, 9, 1, 0, len * 10000),
                                (Math.random() * 30).toFixed(2) - 0,
                                (Math.random() * 100).toFixed(2) - 0
                            ]);
                        }
                        return d;
                    })()
                }
            ]
        };


        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
    </script>
</body>
</html>
