"use strict";

// Class definition
var KoalaSupportKpi = function () {
    //-----------------------------------------------------------
    // Mixed widgets
    var initSupportKpiData=function(){
   
        $.get("/Dashboard/GetDashboarChartData").done(function (result) {
            if (!result.errors) {

                var element = document.getElementById("st_weekly_total");
                var height = parseInt(KTUtil.css(element, 'height'));
                $("#st_open_sp").text(result.data.waitingSupportCount);
                $("#st_wait_on_logo").text(result.data.waitOnLogoSupportCount);
                $("#st_web_user").text(result.data.waitWebUserSupportCount);
                $("#st_wait_answer").text(result.data.waitOnWaitingForAccess);

                
               var sum = 0;
               $.each(result.data.weeklyIcomplatedSupports, function() { sum += parseFloat(this) || 0; });
               
               $("#st_complated_from_me").text(sum);
//--------------------------------------------------------------------
               var st_total_closed = 0;
               $.each(result.data.weeklyComplatedSupports,
                   function() { st_total_closed += parseFloat(this) || 0; });
               
               $("#st_total_closed").text(st_total_closed);
//---------------------------------------------------------------------
               var st_total_opened = 0;
               $.each(result.data.weeklyTotalOpenedSupports,
                   function() { st_total_opened += parseFloat(this) || 0; });
               
               $("#st_total_opened").text(st_total_opened);
//------------------------------------------------------------------------------
                var st_opened_for_me = 0;
                $.each(result.data.weeklyOpenedForMeSupports,
                    function() { st_opened_for_me += parseFloat(this) || 0; });
               
                $("#st_opened_for_me").text(st_opened_for_me);

               //st_opened_for_me


                if (!element) {
                    return;
                }



                var strokeColor = '#D13647';

                var options = {
                    series: [ {
                        name: 'Gelen Destek Kaydı',
                        data: result.data.weeklyTotalOpenedSupports //Son yedi günde açılan kayıt sayısını al
                    } ],
                    chart: {
                        type: 'area',
                        height: height,
                        toolbar: {
                            show: false
                        },
                        zoom: {
                            enabled: false
                        },
                        sparkline: {
                            enabled: true
                        },
                        dropShadow: {
                            enabled: true,
                            enabledOnSeries: undefined,
                            top: 5,
                            left: 0,
                            blur: 3,
                            color: strokeColor,
                            opacity: 0.5
                        }
                    },
                    plotOptions: {},
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 0
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [ strokeColor ]
                    },
                    xaxis: {
                        categories: result.data.dates,//[ 'Pzt', 'Sal', 'Çrs', 'Prs', 'Cum', 'Cmt', 'Pzr' ],
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        },
                        crosshairs: {
                            show: false,
                            position: 'front',
                            stroke: {
                                color: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-300' ],
                                width: 1,
                                dashArray: 3
                            }
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 80,
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px',
                            fontFamily: KTApp.getSettings()[ 'font-family' ]
                        },
                        y: {
                            formatter: function (val) {
                                return val + " Talep";
                            }
                        },
                        marker: {
                            show: false
                        }
                    },
                    colors: [ 'transparent' ],
                    markers: {
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ 'danger' ] ],
                        strokeColor: [ strokeColor ],
                        strokeWidth: 3
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();





                var element = document.getElementById("st_complated_from_me_chart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var color = KTUtil.hasAttr(element, 'data-color') ? KTUtil.attr(element, 'data-color') : 'success';

                if (!element) {
                    return;
                }

                var options = {
                    series: [ {
                        name: 'Açılan ',
                        data: result.data.weeklyIcomplatedSupports//[ 40, 40, 30, 30, 35, 35, 50 ]
                    } ],
                    chart: {
                        type: 'area',
                        height: 150,
                        toolbar: {
                            show: false
                        },
                        zoom: {
                            enabled: false
                        },
                        sparkline: {
                            enabled: true
                        }
                    },
                    plotOptions: {},
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 1
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ]
                    },
                    xaxis: {
                        categories: result.data.dates,//[ 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Aug', 'Sep' ],
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        },
                        crosshairs: {
                            show: false,
                            position: 'front',
                            stroke: {
                                color: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-300' ],
                                width: 1,
                                dashArray: 3
                            }
                        },
                        tooltip: {
                            enabled: false,
                            formatter: undefined,
                            offsetY: 0,
                            style: {
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 55,
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px',
                            fontFamily: KTApp.getSettings()[ 'font-family' ]
                        },
                        y: {
                            formatter: function (val) {
                                return val + " kayıt";
                            }
                        }
                    },
                    colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                    markers: {
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                        strokeColor: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ],
                        strokeWidth: 3
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();


                //-------------------------------------------------------------------
                
                var element = document.getElementById("st_total_closed_chart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var color = KTUtil.hasAttr(element, 'data-color') ? KTUtil.attr(element, 'data-color') : 'success';

                if (!element) {
                    return;
                }

                var options = {
                    series: [ {
                        name: 'Açılan ',
                        data: result.data.weeklyComplatedSupports//[ 40, 40, 30, 30, 35, 35, 50 ]
                    } ],
                    chart: {
                        type: 'area',
                        height: 150,
                        toolbar: {
                            show: false
                        },
                        zoom: {
                            enabled: false
                        },
                        sparkline: {
                            enabled: true
                        }
                    },
                    plotOptions: {},
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 1
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ]
                    },
                    xaxis: {
                        categories: result.data.dates,//[ 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Aug', 'Sep' ],
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        },
                        crosshairs: {
                            show: false,
                            position: 'front',
                            stroke: {
                                color: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-300' ],
                                width: 1,
                                dashArray: 3
                            }
                        },
                        tooltip: {
                            enabled: false,
                            formatter: undefined,
                            offsetY: 0,
                            style: {
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 55,
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px',
                            fontFamily: KTApp.getSettings()[ 'font-family' ]
                        },
                        y: {
                            formatter: function (val) {
                                return val + " kayıt";
                            }
                        }
                    },
                    colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                    markers: {
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                        strokeColor: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ],
                        strokeWidth: 3
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();

                
                //-------------------------------------------------------------------
                
                var element = document.getElementById("st_opened_for_me_chart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var color = KTUtil.hasAttr(element, 'data-color') ? KTUtil.attr(element, 'data-color') : 'success';

                if (!element) {
                    return;
                }

                var options = {
                    series: [ {
                        name: 'Açılan ',
                        data: result.data.weeklyOpenedForMeSupports//[ 40, 40, 30, 30, 35, 35, 50 ]
                    } ],
                    chart: {
                        type: 'area',
                        height: 150,
                        toolbar: {
                            show: false
                        },
                        zoom: {
                            enabled: false
                        },
                        sparkline: {
                            enabled: true
                        }
                    },
                    plotOptions: {},
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 1
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ]
                    },
                    xaxis: {
                        categories: result.data.dates,//[ 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Aug', 'Sep' ],
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        },
                        crosshairs: {
                            show: false,
                            position: 'front',
                            stroke: {
                                color: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-300' ],
                                width: 1,
                                dashArray: 3
                            }
                        },
                        tooltip: {
                            enabled: false,
                            formatter: undefined,
                            offsetY: 0,
                            style: {
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 55,
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px',
                            fontFamily: KTApp.getSettings()[ 'font-family' ]
                        },
                        y: {
                            formatter: function (val) {
                                return val + " kayıt";
                            }
                        }
                    },
                    colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                    markers: {
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                        strokeColor: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ],
                        strokeWidth: 3
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
                   
                //-------------------------------------------------------------------
                
                var element = document.getElementById("st_total_opened_chart");

                var height = parseInt(KTUtil.css(element, 'height'));
                var color = KTUtil.hasAttr(element, 'data-color') ? KTUtil.attr(element, 'data-color') : 'success';

                if (!element) {
                    return;
                }

                var options = {
                    series: [ {
                        name: 'Açılan ',
                        data: result.data.weeklyTotalOpenedSupports//[ 40, 40, 30, 30, 35, 35, 50 ]
                    } ],
                    chart: {
                        type: 'area',
                        height: 150,
                        toolbar: {
                            show: false
                        },
                        zoom: {
                            enabled: false
                        },
                        sparkline: {
                            enabled: true
                        }
                    },
                    plotOptions: {},
                    legend: {
                        show: false
                    },
                    dataLabels: {
                        enabled: false
                    },
                    fill: {
                        type: 'solid',
                        opacity: 1
                    },
                    stroke: {
                        curve: 'smooth',
                        show: true,
                        width: 3,
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ]
                    },
                    xaxis: {
                        categories: result.data.dates,//[ 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Aug', 'Sep' ],
                        axisBorder: {
                            show: false,
                        },
                        axisTicks: {
                            show: false
                        },
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        },
                        crosshairs: {
                            show: false,
                            position: 'front',
                            stroke: {
                                color: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-300' ],
                                width: 1,
                                dashArray: 3
                            }
                        },
                        tooltip: {
                            enabled: false,
                            formatter: undefined,
                            offsetY: 0,
                            style: {
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    yaxis: {
                        min: 0,
                        max: 55,
                        labels: {
                            show: false,
                            style: {
                                colors: KTApp.getSettings()[ 'colors' ][ 'gray' ][ 'gray-500' ],
                                fontSize: '12px',
                                fontFamily: KTApp.getSettings()[ 'font-family' ]
                            }
                        }
                    },
                    states: {
                        normal: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        hover: {
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        },
                        active: {
                            allowMultipleDataPointsSelection: false,
                            filter: {
                                type: 'none',
                                value: 0
                            }
                        }
                    },
                    tooltip: {
                        style: {
                            fontSize: '12px',
                            fontFamily: KTApp.getSettings()[ 'font-family' ]
                        },
                        y: {
                            formatter: function (val) {
                                return val + " kayıt";
                            }
                        }
                    },
                    colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                    markers: {
                        colors: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'light' ][ color ] ],
                        strokeColor: [ KTApp.getSettings()[ 'colors' ][ 'theme' ][ 'base' ][ color ] ],
                        strokeWidth: 3
                    }
                };

                var chart = new ApexCharts(element, options);
                chart.render();
               
            } else {
                return false;
            }
        });
    };
    
    //----------------------------------------------------------

    // Public methods
    return {
        _initSupportKpiData: function () {
            initSupportKpiData();



        }
    }
}();

// Webpack support
if (typeof module !== 'undefined') {
    module.exports = KoalaSupportKpi;
}

jQuery(document).ready(function () {
    KoalaSupportKpi._initSupportKpiData();
});
