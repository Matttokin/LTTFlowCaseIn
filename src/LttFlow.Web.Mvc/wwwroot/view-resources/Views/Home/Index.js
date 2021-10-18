function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}

$(function () {

    'use strict';

    var _meterReadingService = abp.services.app.meterReading;

    var arrayfil = [];

    for (var i = 0; i < 10; i++) {
        var fiel = {
            groupName: 'Регион №' + getRandomInt(100),
            value: i + getRandomInt(700),
            date: i + ' октября',
        };
        arrayfil.push(fiel);
    }

    // 

    /* ChartJS
     * -------
     * Here we will create a few charts using ChartJS
     */

    //-----------------------
    //- MONTHLY SALES CHART -
    //-----------------------

    // Get context with jQuery - using jQuery's .get() method.
    var salesChartCanvas = $('#salesChart').get(0).getContext('2d');
    // This will get the first returned node in the jQuery collection.

    var salesChartData = {
        labels: [],
        datasets: []
    };

    var dataset = {
        label: 'Приборы учета',
        backgroundColor: [],
        borderColor: [],
        spanGaps: true,
        data: []
    };

    //arrayfil.forEach(datas => {
    //    var color = 'rgba(' + getRandomInt(255) + ', ' + getRandomInt(255) + ', ' + getRandomInt(255) + ', 1)';
    //    dataset.backgroundColor.push(color);
    //    dataset.borderColor.push(color);
    //    dataset.data.push(datas.value);
    //    salesChartData.labels.push(datas.groupName);
    //});

    _meterReadingService.getChartData().done(function (result) {
        var salesChartData = {
            labels: [],
            datasets: []
        };

        result.forEach(das => {
            var color = 'rgba(' + getRandomInt(255) + ', ' + getRandomInt(255) + ', ' + getRandomInt(255) + ', 1)';
            var dataset = {
                label: das.groupName,
                backgroundColor: color,
                borderColor: color,
                spanGaps: true,
                data: [{ x: das.date, y: das.value }]
            };
            salesChartData.labels.push(das.date);
            salesChartData.datasets.push(dataset);
        });

        var salesChartOptions = {
            //Boolean - If we should show the scale at all
            showScale: true,
            //Boolean - Whether grid lines are shown across the chart
            scaleShowGridLines: false,
            //String - Colour of the grid lines
            scaleGridLineColor: 'rgba(0,0,0,.05)',
            //Number - Width of the grid lines
            scaleGridLineWidth: 1,
            //Boolean - Whether to show horizontal lines (except X axis)
            scaleShowHorizontalLines: true,
            //Boolean - Whether to show vertical lines (except Y axis)
            scaleShowVerticalLines: true,
            //Boolean - Whether the line is curved between points
            bezierCurve: true,
            //Number - Tension of the bezier curve between points
            bezierCurveTension: 0.3,
            //Boolean - Whether to show a dot for each point
            pointDot: false,
            //Number - Radius of each point dot in pixels
            pointDotRadius: 4,
            //Number - Pixel width of point dot stroke
            pointDotStrokeWidth: 1,
            //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
            pointHitDetectionRadius: 20,
            //Boolean - Whether to show a stroke for datasets
            datasetStroke: true,
            //Number - Pixel width of dataset stroke
            datasetStrokeWidth: 2,
            //Boolean - Whether to fill the dataset with a color
            datasetFill: true,
            //String - A legend template
            legendTemplate: '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].lineColor%>"></span><%=datasets[i].label%></li><%}%></ul>',
            //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
            maintainAspectRatio: false,
            //Boolean - whether to make the chart responsive to window resizing
            responsive: true
        };

        var salesChart = new Chart(salesChartCanvas, {
            type: 'bar',
            data: salesChartData,
            options: salesChartOptions
        });
    });;


    //Create the line chart
    
    //---------------------------
    //- END MONTHLY SALES CHART -
    //---------------------------
});
