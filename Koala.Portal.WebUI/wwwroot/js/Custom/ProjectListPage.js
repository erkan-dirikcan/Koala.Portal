"use strict";
var ProjectTable = function () {

    var initTable = function () {

        var table = $('#ProjectTable');

        // begin first table
        table.DataTable({
            responsive: true,
            ordering: false,
            language: {
                url: "//cdn.datatables.net/plug-ins/1.13.6/i18n/tr.json"
            },
            columnDefs: [

            ]
        });

        // Delete project button handler
        $(document).on("click", ".btn-delete-project", function (e) {
            e.preventDefault();
            var projectId = $(this).data("id");
            var projectName = $(this).data("name");

            if (confirm("'" + projectName + "' isimli projeyi silmek istediğinize emin misiniz?")) {
                deleteProject(projectId);
            }
        });
    };

    var deleteProject = function (projectId) {
        $.ajax({
            url: "/Project/DeleteProject",
            type: "POST",
            data: { id: projectId },
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Proje başarıyla silindi!", "Başarılı");
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    toastr.error(response.message || "Proje silinirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    return {
        init: function () {
            initTable();
        }
    };

}();

jQuery(document).ready(function () {
    ProjectTable.init();
});
