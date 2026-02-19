"use strict";
const primary = '#6993FF';
const success = '#1BC5BD';
const info = '#8950FC';
const warning = '#FFA800';
const danger = '#F64E60';
const orange = '#fa8d00';
const haki = '#8a9f00';
const navi = '#003c79';

var SupportChart = function () {
    var _demo12 = function () {
        const apexChart = "#chart_12";
        var s = $.parseJSON($("#series").val());
        var l = $.parseJSON($("#labels").val());
        var options = {
            series: s,
            chart: {
                width: 380,
                type: 'pie',
            },
            labels: l,
            responsive: [ {
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            } ],
            colors: [ warning, primary, success, navi, danger, info, haki, orange ]
        };

        var chart = new ApexCharts(document.querySelector(apexChart), options);
        chart.render();
    }

    var _demo13 = function () {
        const apexChart2 = "#chart_13";
        var s1 = $.parseJSON($("#seriesOpen").val());
        var l1 = $.parseJSON($("#labelsOpen").val());
        var options1 = {
            series: s1,
            chart: {
                width: 380,
                type: 'pie',
            },
            labels: l1,
            responsive: [ {
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            } ],
            colors: [ warning, primary, success, navi, danger, info, haki, orange ]
        };

        var chart1 = new ApexCharts(document.querySelector(apexChart2), options1);
        chart1.render();
    }

    return {
        // public functions
        init: function () {

            _demo12();
            _demo13();
        }
    };
}();
jQuery(document).ready(function () {
    SupportChart.init();
});