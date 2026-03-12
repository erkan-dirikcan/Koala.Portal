
"use strict";
var TicketReport = function () {
    var filteredData = [];
    var categoryChart, monthChart, personnelChart;

    var initTable = function () {
        $('.select2').select2({
            placeholder: 'Seçiniz...',
            width: '100%',
            language: 'tr'
        });
     


        var table = $('#TicketReportTable');
        table.DataTable({
            responsive: true,
            columnDefs: [

            ]
        });

    };
    function bindFilterEvents () {
        $('#filterStartDate').on('change', applyFilters);
        $('#filterEndDate').on('change', applyFilters);
        $('#filterFirm').on('change', applyFilters);
        $('#filterPerson').on('change', applyFilters);
        $('#filterStatus').on('change', applyFilters);
    }

    function applyFilters () {
        var startDate = $('#filterStartDate').val();
        var endDate = $('#filterEndDate').val();
        var firms = $('#filterFirm').val() || [];
        var persons = $('#filterPerson').val() || [];
        var statuses = $('#filterStatus').val() || [];

        filteredData = allData.filter(function (d) {
            // Tarih filtre
            if (startDate) {
                var dDate = d.startDate ? new Date(d.startDate) : null;
                var sDate = new Date(startDate);
                if (dDate && dDate < sDate) return false;
            }
            if (endDate) {
                var dDate = d.startDate ? new Date(d.startDate) : null;
                var eDate = new Date(endDate + 'T23:59:59');
                if (dDate && dDate > eDate) return false;
            }

            // Firma filtre (multi-select)
            if (firms.length > 0 && !firms.includes(d.firmName)) return false;

            // Personel filtre (multi-select)
            if (persons.length > 0 && !persons.includes(d.activeUser)) return false;

            // Durum filtre (multi-select)
            if (statuses.length > 0 && !statuses.includes(d.status)) return false;

            return true;
        });

        updateStats();
        renderCharts();
        renderTable();
    }

    function updateStats () {
        var total = filteredData.length;
        var completed = filteredData.filter(function (d) { return d.isCompleted; }).length;
        var pending = total - completed;
        var avgDuration = total > 0 ? filteredData.reduce(function (sum, d) { return sum + d.durationDays; }, 0) / total : 0;

        $('#statTotal').text(total);
        $('#statCompleted').text(completed);
        $('#statPending').text(pending);
        $('#statAvgDuration').text(avgDuration.toFixed(1) + ' gün');
        $('#tableCount').text(total);
    }
    function renderCharts () {
        renderCategoryChart();
        renderMonthChart();
        renderPersonnelChart();
    }
    function renderCategoryChart () {
        var categoryCounts = {};
        filteredData.forEach(function (d) {
            var cat = d.subCategory || 'Diğer';
            categoryCounts[ cat ] = (categoryCounts[ cat ] || 0) + 1;
        });

        // Sort by count and take top 10
        var sorted = Object.entries(categoryCounts).sort(function (a, b) { return b[ 1 ] - a[ 1 ]; }).slice(0, 10);
        var labels = sorted.map(function (x) { return x[ 0 ]; });
        var series = sorted.map(function (x) { return x[ 1 ]; });

        // Different colors for each bar
        var colors = [ '#6993FF', '#1BC5BD', '#FFA800', '#F64E60', '#8950FC', '#3699FF', '#008080', '#FF6B6B', '#4ECDC4', '#45B7D1' ];

        var options = {
            series: [ { name: 'Ticket', data: series } ],
            chart: { type: 'bar', height: 250 },
            plotOptions: { bar: { borderRadius: 4, columnWidth: '60%' } },
            xaxis: { categories: labels },
            colors: colors,
            dataLabels: { enabled: true, position: 'top' }
        };

        if (categoryChart) categoryChart.destroy();
        categoryChart = new ApexCharts(document.querySelector('#categoryChart'), options);
        categoryChart.render();
    }

    function renderMonthChart () {
        var monthCounts = {};
        var months = [ 'Oca', 'Şub', 'Mar', 'Nis', 'May', 'Haz', 'Tem', 'Ağu', 'Eyl', 'Eki', 'Kas', 'Ara' ];

        for (var i = 0; i < 12; i++) {
            monthCounts[ months[ i ] ] = 0;
        }

        filteredData.forEach(function (d) {
            if (d.month >= 1 && d.month <= 12) {
                monthCounts[ months[ d.month - 1 ] ]++;
            }
        });

        var options = {
            series: [ { name: 'Ticket', data: Object.values(monthCounts) } ],
            chart: { type: 'bar', height: 250 },
            plotOptions: { bar: { borderRadius: 4, columnWidth: '60%' } },
            xaxis: { categories: months },
            colors: [ '#6993FF' ],
            dataLabels: { enabled: false }
        };

        if (monthChart) monthChart.destroy();
        monthChart = new ApexCharts(document.querySelector('#monthChart'), options);
        monthChart.render();
    }

    function renderPersonnelChart () {
        var personCounts = {};
        filteredData.forEach(function (d) {
            if (d.activeUser) {
                personCounts[ d.activeUser ] = (personCounts[ d.activeUser ] || 0) + 1;
            }
        });

        // Sort by count and take top 5
        var sorted = Object.entries(personCounts).sort(function (a, b) { return b[ 1 ] - a[ 1 ]; }).slice(0, 5);
        var labels = sorted.map(function (x) { return x[ 0 ]; });
        var series = sorted.map(function (x) { return x[ 1 ]; });

        var options = {
            series: [ { name: 'Ticket', data: series } ],
            chart: {
                type: 'bar',
                height: 250,
                events: {
                    dataPointSelection: function (event, chartContext, config) {
                        var personName = config.w.config.xaxis.categories[config.dataPointIndex];
                        var personData = filteredData.filter(function (d) { return d.activeUser === personName; });
                        showPersonnelModal(personName, personData);
                    }
                }
            },
            plotOptions: {
                bar: { borderRadius: 4, horizontal: true },
                cursor: 'pointer'
            },
            xaxis: { categories: labels },
            colors: [ '#1BC5BD' ],
            dataLabels: { enabled: true, position: 'right' }
        };

        if (personnelChart) personnelChart.destroy();
        personnelChart = new ApexCharts(document.querySelector('#personnelChart'), options);
        personnelChart.render();
    }

    var currentPersonData = [];

    function showPersonnelModal (personName, personData) {
        currentPersonData = personData;

        $('#modalPersonName').text(personName);
        $('#modalTotalTickets').text(personData.length);

        var tbody = $('#modalTableBody');
        tbody.empty();

        personData.forEach(function (d) {
            var row = '<tr>' +
                '<td>' + (d.ticketId || '-') + '</td>' +
                '<td>' + (d.firmName || '-') + '</td>' +
                '<td>' + (d.contactName || '-') + '</td>' +
                '<td>' + formatDate(d.callDate) + '</td>' +
                '<td>' + formatDate(d.completeDate) + '</td>' +
                '<td>' + (d.status || '-') + '</td>' +
                '</tr>';
            tbody.append(row);
        });

        $('#personnelDetailModal').modal('show');
    }

    function exportPersonnelExcel () {
        if (currentPersonData.length === 0) return;

        $.ajax({
            url: '/Report/ExportPersonnelExcel',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ personName: $('#modalPersonName').text() }),
            xhrFields: { responseType: 'blob' },
            success: function (data, status, xhr) {
                var filename = 'Personel_Detay_' + new Date().getTime() + '.xlsx';
                var blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = filename;
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            },
            error: function () {
                alert('Excel dosyası oluşturulurken hata oluştu.');
            }
        });
    }

    function exportFullReport () {
        var request = {
            startDate: $('#filterStartDate').val() ? new Date($('#filterStartDate').val()) : null,
            endDate: $('#filterEndDate').val() ? new Date($('#filterEndDate').val()) : null,
            firms: $('#filterFirm').val() || [],
            persons: $('#filterPerson').val() || [],
            statuses: $('#filterStatus').val() || []
        };

        $.ajax({
            url: '/Report/ExportTicketReportExcel',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(request),
            xhrFields: { responseType: 'blob' },
            success: function (data, status, xhr) {
                var filename = 'Ticket_Rapor_' + new Date().getTime() + '.xlsx';
                var blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = filename;
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            },
            error: function () {
                alert('Excel dosyası oluşturulurken hata oluştu.');
            }
        });
    }

    function renderTable () {
        var table = $('#TicketReportTable');
        table.DataTable().clear();
        table.DataTable().rows.add(filteredData.map(function (d) {
            return [
                d.ticketId || '-',           // 1. Destek Numarası
                d.firmCode || '-',            // 2. Firma Kodu
                d.contactName || '-',          // 3. Yetkili
                d.department || '-',           // 4. Departman
                d.assignedTo || '-',           // 5. Atanan
                d.activeUser || '-',           // 6. Aktif Kullanıcı
                formatDate(d.callDate),       // 7. Arama Zamanı
                d.firmName || '-',            // 8. Firma Adı
                d.customerRequest || '-',      // 9. Müşteri Talebi
                d.mainCategory || '-',        // 10. Kategori
                d.subCategory || '-',         // 11. Alt Kategori
                d.type || '-',                // 12. Destek Türü
                d.status || '-',              // 13. Durum
                formatDate(d.startDate),      // 14. Başlama Zamanı
                formatDate(d.completeDate),    // 15. Bitiş Zamanı
                d.priority || '-',             // 16. Öncelik
                d.isCompleted ? 'Evet' : 'Hayır', // 17. Tamamlandı
                d.isContinuing ? 'Evet' : 'Hayır', // 18. Devam Ediyor
                d.price || '-'                // 19. Alınan Ücret
            ];
        }));
        table.DataTable().draw();
    }

    function formatDate (dateVal) {
        if (!dateVal) return '-';
        var d = new Date(dateVal);
        return d.toLocaleDateString('tr-TR');
    }

    return {


        init: function () {
            initTable();
            bindFilterEvents();
            applyFilters();
        },
        exportFullReport: exportFullReport,
        exportPersonnelExcel: exportPersonnelExcel

    };

}();

jQuery(document).ready(function () {
    TicketReport.init();
});
