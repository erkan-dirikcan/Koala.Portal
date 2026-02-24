"use strict";
var ProjectLineTable = function () {

    var initTable = function () {
        console.log("ProjectDetailPage initTable başlatılıyor...");

        var projectId = window.location.pathname.substring(window.location.pathname.lastIndexOf("/") + 1);
        console.log("Project ID:", projectId);

        // Event delegation ile Faz Ekle butonu (modal dinamik olduğu için)
        $(document).on("click", "#open-add-project-line-modal", function (e) {
            e.preventDefault();
            console.log("Faz Ekle butonuna tıklandı");

            // Modal'ın varlığını kontrol et
            var $modal = $("#add-project-line-modal");
            if ($modal.length === 0) {
                console.error("Modal elementi bulunamadı!");
                return;
            }

            console.log("Modal açılıyor...");
            $modal.modal('show');
        });

        // Event delegation ile Kaydet butonu
        $(document).on("click", "#add_project_line_save_bt", function (e) {
            e.preventDefault();
            console.log("Faz Kaydet butonuna tıklandı");
            saveProjectLine();
        });

        // Modal kapatıldığında formu temizle
        $('#add-project-line-modal').on('hidden.bs.modal', function () {
            clearForm();
        });

        $('#add-project-line-modal').on('shown.bs.modal',
            function () {
                console.log("Modal açıldı, Select2 initializing...");

                $('#add_LineFirmOfficial').select2({
                    placeholder: 'Firma Yetkilisi Seçiniz',
                    language: "tr",
                    dropdownParent: $('#add-project-line-modal'),
                    width: '100%'
                });
                $('#add_LineOfficialId').select2({
                    placeholder: 'Faz Yöneticisi Seçiniz',
                    language: "tr",
                    dropdownParent: $('#add-project-line-modal'),
                    width: '100%'
                });
                $('#add_LinePriority').select2({
                    placeholder: 'Önceliği Seçiniz',
                    language: "tr",
                    dropdownParent: $('#add-project-line-modal'),
                    width: '100%'
                });
                $('#add_DueDate').datetimepicker({
                    locale: 'tr',
                    format: 'DD-MM-YYYY',
                    showMeridian: false,
                    autoclose: true
                });
            });

        // Düzenle butonu
        $(document).on("click", ".btn-edit-phase", function (e) {
            e.preventDefault();
            var row = $(this).closest("tr");
            openEditModal(row);
        });

        // Sil butonu
        $(document).on("click", ".btn-delete-phase", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            deleteProjectLine(id);
        });

        // Faza Başla butonu
        $(document).on("click", ".btn-start-phase", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            changeProjectLineStatus(id, 2); // 2 = InProgress (Devam Ediyor)
        });

        // Tamamla butonu
        $(document).on("click", ".btn-complete-phase", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            changeProjectLineStatus(id, 5); // 5 = Completed (Tamamlandı)
        });

        // Güncelleme modal'ı - Kaydet butonu
        $(document).on("click", "#edit_project_line_save_bt", function (e) {
            e.preventDefault();
            updateProjectLine();
        });

        // Güncelleme modal'ı açıldığında
        $('#edit-project-line-modal').on('shown.bs.modal', function () {
            $('#edit_LineOfficialId').select2({
                placeholder: 'Faz Yöneticisi Seçiniz',
                language: "tr",
                dropdownParent: $('#edit-project-line-modal'),
                width: '100%'
            });
            $('#edit_LineFirmOfficialId').select2({
                placeholder: 'Firma Yetkilisi Seçiniz',
                language: "tr",
                dropdownParent: $('#edit-project-line-modal'),
                width: '100%'
            });
            $('#edit_Priority').select2({
                placeholder: 'Önceliği Seçiniz',
                language: "tr",
                dropdownParent: $('#edit-project-line-modal'),
                width: '100%'
            });
            $('#edit_DueDate').datetimepicker({
                locale: 'tr',
                format: 'DD-MM-YYYY',
                showMeridian: false,
                autoclose: true
            });
        });

        var table = $('#ProjectLineTable');

        // begin first table
        table.DataTable({
            responsive: true,
            ordering: false,
            language: {
                url: "//cdn.datatables.net/plug-ins/1.13.6/i18n/tr.json"
            }
        });

    };

    // Formu temizleme
    var clearForm = function () {
        $("#add_LineTitle").val('');
        $("#add_LineRowNumber").val('');
        $("#add_LineDescription").val('');
        $("#add_DueDate_tb").val('');

        // Select2 dropdownlarını temizle
        $('#add_LineOfficialId').val(null).trigger('change');
        $('#add_LineFirmOfficial').val(null).trigger('change');
        $('#add_LinePriority').val(null).trigger('change');
    };

    // Faz Kaydetme Metodu
    var saveProjectLine = function () {
        console.log("=== Faz kaydetme başlatılıyor ===");

        // Form verilerini al
        var projectId = $("#add_ProjectId").val();
        var title = $("#add_LineTitle").val();
        var rowOrder = $("#add_LineRowNumber").val();
        var lineOfficialId = $("#add_LineOfficialId").val();
        var lineFirmOfficialId = $("#add_LineFirmOfficial").val();
        var priority = $("#add_LinePriority").val();
        var dueDate = $("#add_DueDate_tb").val();
        var description = $("#add_LineDescription").val();

        console.log("Alınan değerler:");
        console.log("  projectId:", projectId);
        console.log("  title:", title);
        console.log("  rowOrder:", rowOrder);
        console.log("  lineOfficialId:", lineOfficialId);
        console.log("  lineFirmOfficialId:", lineFirmOfficialId);
        console.log("  priority:", priority, "tip:", typeof priority);
        console.log("  dueDate:", dueDate);
        console.log("  description:", description);

        // Validasyon
        if (!title || title.trim() === "") {
            toastr.warning("Faz Adı zorunludur!", "Uyarı");
            return;
        }
        if (!projectId) {
            toastr.error("Proje ID bulunamadı!", "Hata");
            return;
        }

        // Priority enum değerini al (varsayılan 3 = Normal)
        var priorityValue = priority ? parseInt(priority) : 3;

        // ViewModel oluştur - Property isimleri CAMEL CASE formatında (ASP.NET Core standardı)
        var model = {
            projectId: projectId,
            lineOfficialId: lineOfficialId || null,
            lineFirmOfficialId: lineFirmOfficialId || null,
            title: title,
            description: description || "",
            dueDate: dueDate || null,
            priority: priorityValue,
            rowOrder: rowOrder ? parseInt(rowOrder) : null
        };

        console.log("=== Gönderilecek JSON ===");
        console.log(JSON.stringify(model, null, 2));

        // Butonu disable et
        $("#add_project_line_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Kaydediliyor...');

        $.post("/Project/AddProjectLine", { model: model }).done(function (result) {
            $("#add_project_line_save_bt").prop("disabled", false).text("Faz Ekle");
            if (result.isSuccess) {
                $('#FirmPersonId').val(null).trigger('change');
                $("#FirmPersonId").empty();
                $.each(result.data, function (i, val) {
                    var opt = new Option(val.text, val.value, false, false);
                    $("#FirmPersonId").append(opt).trigger('change');
                });
                setTimeout(function () {
                    location.reload();
                }, 1000);
            } else {

                toastr.error("Bir Hata Oluştu", result.message);
            }
        });
        // AJAX isteği
        //$.ajax({
        //    url: "/Project/AddProjectLine",
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    data: JSON.stringify(model),
        //    beforeSend: function(xhr) {
        //        console.log("AJAX isteği gönderiliyor...");
        //    },
        //    success: function (response) {
        //        console.log("Başarılı yanıt:", response);
        //        if (response.isSuccess) {
        //            toastr.success(response.message || "Faz başarıyla eklendi!", "Başarılı");
        //            $("#add-project-line-modal").modal('hide');
        //            // Sayfayı yenile
        //            setTimeout(function () {
        //                location.reload();
        //            }, 1000);
        //        } else {
        //            toastr.error(response.message || "Faz eklenirken bir hata oluştu!", "Hata");
        //        }
        //    },
        //    error: function (xhr, status, error) {
        //        console.error("=== AJAX Hatası ===");
        //        console.error("Status:", status);
        //        console.error("Error:", error);
        //        console.error("StatusCode:", xhr.status);
        //        console.error("ResponseText:", xhr.responseText);
        //        toastr.error("İşlem sırasında bir hata oluştu! Detay için konsolu kontrol edin.", "Hata");
        //    },
        //    complete: function () {
        //        // Butonu enable et
        //        $("#add_project_line_save_bt").prop("disabled", false).text("Faz Ekle");
        //    }
        //});
    };

    // Düzenleme modal'ını aç
    var openEditModal = function (row) {
        var id = row.data("id");
        var title = row.data("title");
        var officialId = row.data("official-id");
        var firmOfficialId = row.data("firm-official-id");
        var priority = row.data("priority");
        var rowOrder = row.data("roworder");
        var description = row.data("description");
        var dueDate = row.data("duedate");

        $("#edit_Id").val(id);
        $("#edit_Title").val(title);
        $("#edit_RowOrder").val(rowOrder);
        $("#edit_Description").val(description);
        $("#edit_DueDate_tb").val(dueDate);

        // Select2 değerlerini ayarla (modal açıldıktan sonra)
        $("#edit-project-line-modal").modal('show').one('shown.bs.modal', function () {
            $("#edit_Priority").val(priority).trigger('change');
            if (officialId) $("#edit_LineOfficialId").val(officialId).trigger('change');
            if (firmOfficialId) $("#edit_LineFirmOfficialId").val(firmOfficialId).trigger('change');
        });
    };

    // Faz Güncelleme
    var updateProjectLine = function () {
        var model = {
            id: $("#edit_Id").val(),
            title: $("#edit_Title").val(),
            rowOrdwer: $("#edit_RowOrder").val() ? parseInt($("#edit_RowOrder").val()) : null,
            description: $("#edit_Description").val() || "",
            dueDate: $("#edit_DueDate_tb").val() || null,
            priority: parseInt($("#edit_Priority").val() || "3"),
            lineOfficialId: $("#edit_LineOfficialId").val() || null,
            lineFirmOfficialId: $("#edit_LineFirmOfficialId").val() || null
        };

        console.log("Gönderilecek güncelleme verisi:", JSON.stringify(model, null, 2));

        // ASP.NET Core camelCase bekler, C# property isimleriyle eşleşmesi için camelCase kullan
        var payload = {
            id: model.id,
            lineOfficialId: model.lineOfficialId,
            lineFirmOfficialId: model.lineFirmOfficialId,
            title: model.title,
            description: model.description,
            dueDate: model.dueDate,
            priority: model.priority,
            rowOrdwer: model.rowOrdwer
        };

        $("#edit_project_line_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Güncelleniyor...');

        $.ajax({
            url: "/Project/UpdateProjectLine",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(payload),
            url: "/Project/UpdateProjectLine",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Faz başarıyla güncellendi!", "Başarılı");
                    $("#edit-project-line-modal").modal('hide');
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    toastr.error(response.message || "Faz güncellenirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            },
            complete: function () {
                $("#edit_project_line_save_bt").prop("disabled", false).text("Güncelle");
            }
        });
    };

    // Faz Silme
    var deleteProjectLine = function (id) {
        if (!confirm("Bu fazı silmek istediğinize emin misiniz?")) {
            return;
        }

        $.ajax({
            url: "/Project/DeleteProjectLine",
            type: "POST",
            data: { id: id },
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Faz başarıyla silindi!", "Başarılı");
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    toastr.error(response.message || "Faz silinirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    // Faz Durumu Değiştirme
    var changeProjectLineStatus = function (id, status) {
        var statusTextMap = {
            1: "Başlamadı",
            2: "Devam Ediyor",
            3: "Başkasını Bekliyor",
            4: "Ertelendi",
            5: "Tamamlandı",
            6: "İptal Edildi"
        };
        var statusText = statusTextMap[status] || "Değiştirildi";

        if (!confirm("Faz durumunu '" + statusText + "' olarak değiştirmek istediğinize emin misiniz?")) {
            return;
        }

        var model = {
            id: id,
            status: status  // C# tarafında Status property'si (PascalCase)
        };

        console.log("Durum değiştirme isteği:", JSON.stringify(model, null, 2));

        // ASP.NET Core camelCase bekler
        var payload = {
            id: model.id,
            status: model.status
        };

        $.ajax({
            url: "/Project/ChangeProjectLineStatus",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(payload),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Faz durumu başarıyla değiştirildi!", "Başarılı");
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    toastr.error(response.message || "Faz durumu değiştirilirken bir hata oluştu!", "Hata");
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
    console.log("Document ready, ProjectDetailPage init çağrılıyor...");
    ProjectLineTable.init();
});
