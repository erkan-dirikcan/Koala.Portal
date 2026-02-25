"use strict";

var ProjectDashboard = function () {

    var initCharts = function () {
        // Data is passed via window.projectDashboardData from the view
        if (!window.projectDashboardData) {
            console.warn('Dashboard data not found');
            return;
        }

        var statusData = window.projectDashboardData.projectsByStatus || [];
        var managerData = window.projectDashboardData.projectsByManager || [];

        // Status Distribution Chart (Doughnut)
        var statusCtx = document.getElementById('statusChart');
        if (statusCtx && statusData.length > 0) {
            var statusLabels = statusData.map(function (item) {
                return item.status;
            });
            var statusCounts = statusData.map(function (item) {
                return item.count;
            });

            var statusColors = {
                'Creating': '#6c757d',
                'Created': '#007bff',
                'Started': '#17a2b8',
                'Testing': '#ffc107',
                'Finished': '#28a745',
                'Canceled': '#dc3545',
                'Failed': '#343a40'
            };

            var backgroundColors = statusLabels.map(function (label) {
                return statusColors[label] || '#6c757d';
            });

            new Chart(statusCtx, {
                type: 'doughnut',
                data: {
                    labels: statusLabels,
                    datasets: [{
                        data: statusCounts,
                        backgroundColor: backgroundColors,
                        borderWidth: 2
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            position: 'bottom'
                        }
                    }
                }
            });
        }

        // Manager Distribution Chart (Bar)
        var managerCtx = document.getElementById('managerChart');
        if (managerCtx && managerData.length > 0) {
            var managerLabels = managerData.map(function (item) {
                return item.manager || 'Atanmamış';
            });
            var managerCounts = managerData.map(function (item) {
                return item.count;
            });

            new Chart(managerCtx, {
                type: 'bar',
                data: {
                    labels: managerLabels,
                    datasets: [{
                        label: 'Proje Sayısı',
                        data: managerCounts,
                        backgroundColor: 'rgba(54, 162, 235, 0.8)',
                        borderColor: 'rgba(54, 162, 235, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        y: {
                            beginAtZero: true,
                            ticks: {
                                stepSize: 1
                            }
                        }
                    },
                    plugins: {
                        legend: {
                            display: false
                        }
                    }
                }
            });
        }
    };

    return {
        init: function () {
            initCharts();
        }
    };

}();

jQuery(document).ready(function () {
    ProjectDashboard.init();
});
