"use strict";

// ProjectLineStatusEnum values for better maintainability
const ProjectLineStatus = {
    NotStarted: 1,
    InProgress: 2,
    WaitingApproval: 3,
    Cancelled: 4,
    Completed: 5
};

// ProjectLineWorkStatusEnum values
const ProjectLineWorkStatus = {
    NotStarted: 1,
    InProgress: 2,
    WaitingApproval: 3,
    Rejected: 4,
    Cancelled: 5,
    Completed: 6
};

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
            changeProjectLineStatus(id, ProjectLineStatus.InProgress);
        });

        // Tamamla butonu
        $(document).on("click", ".btn-complete-phase", function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            changeProjectLineStatus(id, ProjectLineStatus.Completed);
        });

        // Güncelleme modal'ı - Kaydet butonu
        $(document).on("click", "#edit_project_line_save_bt", function (e) {
            e.preventDefault();
            updateProjectLine();
        });

        // Notlar butonu
        $(document).on("click", ".btn-notes-phase", function (e) {
            e.preventDefault();
            var lineId = $(this).data("id");
            var lineTitle = $(this).data("title");
            openNotesModal(lineId, lineTitle);
        });

        // İşler butonu
        $(document).on("click", ".btn-works-phase", function (e) {
            e.preventDefault();
            var lineId = $(this).data("id");
            var lineTitle = $(this).data("title");
            openWorksModal(lineId, lineTitle);
        });

        // Dosya Ekle butonu
        $(document).on("click", "#open-add-project-file-modal", function (e) {
            e.preventDefault();
            $("#add-project-file-modal").modal('show');
        });

        // Dosya Kaydet butonu
        $(document).on("click", "#add_project_file_save_bt", function (e) {
            e.preventDefault();
            saveProjectFile();
        });

        // Dosya Sil butonu
        $(document).on("click", ".btn-delete-file", function (e) {
            e.preventDefault();
            var fileId = $(this).data("id");
            deleteProjectFile(fileId);
        });

        // Not Ekle butonu (modal içinden)
        $(document).on("click", "#open-add-note-from-list", function (e) {
            e.preventDefault();
            var lineId = $("#notes_line_id").val();
            $("#project-line-notes-modal").modal('hide');
            setTimeout(function () {
                $("#note_ProjectLineId").val(lineId);
                $("#add-project-line-note-modal").modal('show');
            }, 300);
        });

        // Not Kaydet butonu
        $(document).on("click", "#add_project_line_note_save_bt", function (e) {
            e.preventDefault();
            saveProjectLineNote();
        });

        // Not Düzenle butonu
        $(document).on("click", "#edit_project_line_note_save_bt", function (e) {
            e.preventDefault();
            updateProjectLineNote();
        });

        // Not Sil butonu
        $(document).on("click", ".btn-delete-note", function (e) {
            e.preventDefault();
            var noteId = $(this).data("id");
            deleteProjectLineNote(noteId);
        });

        // İş Ekle butonu (modal içinden)
        $(document).on("click", "#open-add-work-from-list", function (e) {
            e.preventDefault();
            var lineId = $("#works_line_id").val();
            $("#project-line-works-modal").modal('hide');
            setTimeout(function () {
                $("#work_LineId").val(lineId);
                $("#add-project-line-work-modal").modal('show');
            }, 300);
        });

        // İş Kaydet butonu
        $(document).on("click", "#add_project_line_work_save_bt", function (e) {
            e.preventDefault();
            saveProjectLineWork();
        });

        // İş Düzenle butonu
        $(document).on("click", "#edit_project_line_work_save_bt", function (e) {
            e.preventDefault();
            updateProjectLineWork();
        });

        // İş Sil butonu
        $(document).on("click", ".btn-delete-work", function (e) {
            e.preventDefault();
            var workId = $(this).attr("data-id");
            deleteProjectLineWork(workId);
        });

        // İş Tamamla butonu (modal içinden liste)
        $(document).on("click", ".btn-work-complete-from-list", function (e) {
            e.preventDefault();
            var workId = $(this).attr("data-id");
            var status = $(this).attr("data-status");
            console.log("Tamamla butonu tıklandı - WorkId:", workId, "Status:", status);
            changeProjectLineWorkStatus(workId, parseInt(status));
        });

        // İş Düzenle butonu (modal içinden liste)
        $(document).on("click", ".btn-edit-work-from-list", function (e) {
            e.preventDefault();
            var workId = $(this).attr("data-id");
            var $row = $(this).closest("tr");

            // Önce iş detaylarını API'den al
            $.get("/Project/GetProjectLineWorkDetail", { id: workId }).done(function (response) {
                if (response.isSuccess && response.data) {
                    // Veriyi global değişkende sakla, modal açıldığında kullanılacak
                    window.pendingEditWorkData = response.data;

                    // Modal kapandıktan sonra düzenleme modal'ını aç
                    $("#project-line-works-modal").one('hidden.bs.modal', function () {
                        // Modal tamamen kapandıktan sonra backdrop'ı temizle
                        $('.modal-backdrop').remove();
                        $('body').removeClass('modal-open').css('overflow', '');

                        $("#edit-project-line-work-modal").modal('show');
                    }).modal('hide');
                }
            });
        });

        // İş Başla butonu (modal içinden liste)
        $(document).on("click", ".btn-work-start-from-list", function (e) {
            e.preventDefault();
            var workId = $(this).attr("data-id");
            var status = $(this).attr("data-status");
            console.log("Başla butonu tıklandı - WorkId:", workId, "Status:", status);
            changeProjectLineWorkStatus(workId, parseInt(status));
        });

        // İş Düzenle butonu (tüm işler sekmesinden)
        $(document).on("click", ".btn-edit-work-from-all", function (e) {
            e.preventDefault();
            var workId = $(this).data("id");
            // API'den iş detaylarını al ve modal'ı aç
            $.get("/Project/GetProjectLineWorkDetail", { id: workId }).done(function (response) {
                if (response.isSuccess && response.data) {
                    // Veriyi global değişkende sakla
                    window.pendingEditWorkData = response.data;
                    $("#edit-project-line-work-modal").modal('show');
                }
            });
        });

        // İş Durumu Değiştir butonları
        $(document).on("click", ".btn-work-start", function (e) {
            e.preventDefault();
            var workId = $(this).data("id");
            changeProjectLineWorkStatus(workId, ProjectLineWorkStatus.InProgress);
        });

        $(document).on("click", ".btn-work-complete", function (e) {
            e.preventDefault();
            var workId = $(this).data("id");
            changeProjectLineWorkStatus(workId, ProjectLineWorkStatus.Completed);
        });

        // Modal initialization handlers
        $('#add-project-line-note-modal').on('shown.bs.modal', function () {
            $('#note_Date_container').datetimepicker({
                locale: 'tr',
                format: 'DD-MM-YYYY',
                showMeridian: false,
                autoclose: true
            });
        });

        $('#edit-project-line-note-modal').on('shown.bs.modal', function () {
            $('#edit_note_Date_container').datetimepicker({
                locale: 'tr',
                format: 'DD-MM-YYYY',
                showMeridian: false,
                autoclose: true
            });
        });

        $('#add-project-line-work-modal').on('shown.bs.modal', function () {
            $('#work_Department').select2({
                placeholder: 'Departman Seçiniz',
                language: "tr",
                dropdownParent: $('#add-project-line-work-modal'),
                width: '100%'
            });
            $('#work_AssignedTo').select2({
                placeholder: 'Önce Departman Seçiniz',
                language: "tr",
                dropdownParent: $('#add-project-line-work-modal'),
                width: '100%'
            });
            $('#work_LineFirmOfficialId').select2({
                placeholder: 'Firma Yetkilisi Seçiniz',
                language: "tr",
                dropdownParent: $('#add-project-line-work-modal'),
                width: '100%'
            });
            $('#work_Priority').select2({
                placeholder: 'Önceliği Seçiniz',
                language: "tr",
                dropdownParent: $('#add-project-line-work-modal'),
                width: '100%'
            });
        });

        // Departman değişince kullanıcı listesini yenile
        $('#work_Department').on('change', function () {
            var departmentOid = $(this).val();
            var $userSelect = $('#work_AssignedTo');

            console.log("Departman değişti, OID:", departmentOid);

            if (!departmentOid) {
                $userSelect.empty().append('<option value="">Önce Departman Seçiniz</option>');
                $userSelect.trigger('change');
                return;
            }

            // Kullanıcıları AJAX ile getir
            $.ajax({
                url: '/Support/GetCreateSupportDepartmentUsers',
                type: 'GET',
                data: { departmentOid: departmentOid },
                beforeSend: function () {
                    console.log("Kullanıcılar getiriliyor, departmentOid:", departmentOid);
                },
                success: function (response) {
                    console.log("Response:", response);
                    $userSelect.empty().append('<option value="">Personel Seçiniz</option>');
                    // Response wrapper kontrolü
                    if (response && response.isSuccess && response.data && response.data.length > 0) {
                        response.data.forEach(function (user) {
                            console.log("Kullanıcı:", user);
                            $userSelect.append('<option value="' + user.value + '">' + user.text + '</option>');
                        });
                    } else {
                        console.log("Kullanıcı bulunamadı veya response formatı yanlış");
                    }
                    $userSelect.trigger('change');
                },
                error: function (xhr) {
                    console.error('Departman kullanıcıları hatası:', xhr.responseText);
                    console.error('Status:', xhr.status);
                    toastr.error('Departman kullanıcıları getirilemedi', 'Hata');
                }
            });
        });

        $('#edit-project-line-work-modal').on('shown.bs.modal', function () {
            // Select2 bileşenlerini sadece ilk kez başlat (zaten başlatılmadıysa)
            if (!$('#edit_work_LineFirmOfficialId').data('select2')) {
                $('#edit_work_LineFirmOfficialId').select2({
                    placeholder: 'Firma Yetkilisi Seçiniz',
                    language: "tr",
                    dropdownParent: $('#edit-project-line-work-modal'),
                    width: '100%'
                });
            }
            if (!$('#edit_work_Priority').data('select2')) {
                $('#edit_work_Priority').select2({
                    placeholder: 'Önceliği Seçiniz',
                    language: "tr",
                    dropdownParent: $('#edit-project-line-work-modal'),
                    width: '100%'
                });
            }

            // Bekleyen iş verisi varsa formu doldur
            if (window.pendingEditWorkData) {
                populateEditWorkModal(window.pendingEditWorkData);
                window.pendingEditWorkData = null; // Temizle
            }
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

        // ===== Phase 2: Tab and Bulk Operations =====

        // Tab switching - load content when tab is shown
        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            var target = $(e.target).attr("href");
            if (target === "#tab-works") {
                loadAllWorks();
            } else if (target === "#tab-notes") {
                loadAllNotes();
            }
        });

        // File upload modal trigger from Files tab
        $(document).on("click", "#open-add-project-file-modal-tab", function (e) {
            e.preventDefault();
            $("#add-project-file-modal").modal('show');
        });

        // Select all checkbox
        $(document).on("change", "#selectAllLines", function () {
            $(".line-checkbox").prop('checked', $(this).prop('checked'));
        });

        // Deselect select all if any individual checkbox is unchecked
        $(document).on("change", ".line-checkbox", function () {
            if ($(this).prop('checked') === false) {
                $("#selectAllLines").prop('checked', false);
            }
            // Check if all are checked
            var allChecked = $(".line-checkbox").length === $(".line-checkbox:checked").length;
            $("#selectAllLines").prop('checked', allChecked);
        });

        // Bulk status change
        $(document).on("click", "#bulkApplyStatus", function (e) {
            e.preventDefault();
            var selectedIds = $(".line-checkbox:checked").map(function () {
                return $(this).data("id");
            }).get();

            if (selectedIds.length === 0) {
                toastr.warning("Lütfen en az bir faz seçin!", "Uyarı");
                return;
            }

            var status = $("#bulkStatusSelect").val();
            if (!status) {
                toastr.warning("Lütfen bir durum seçin!", "Uyarı");
                return;
            }

            var statusText = $("#bulkStatusSelect option:selected").text();
            if (!confirm("Seçili " + selectedIds.length + " fazın durumunu '" + statusText + "' olarak değiştirmek istediğinize emin misiniz?")) {
                return;
            }

            bulkChangeProjectLineStatus(selectedIds, parseInt(status));
        });

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
            rowOrder: $("#edit_RowOrder").val() ? parseInt($("#edit_RowOrder").val()) : null,
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
            rowOrder: model.rowOrder
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

    // ===== FILE FUNCTIONS =====

    var saveProjectFile = function () {
        var formData = new FormData();
        formData.append("ProjectId", $("#file_ProjectId").val());
        formData.append("Name", $("#file_Name").val());
        formData.append("Description", $("#file_Description").val());

        var fileInput = $("#file_File")[0];
        if (fileInput.files.length > 0) {
            formData.append("File", fileInput.files[0]);
        } else {
            toastr.warning("Lütfen bir dosya seçin!", "Uyarı");
            return;
        }

        $("#add_project_file_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Yükleniyor...');

        $.ajax({
            url: "/Project/AddProjectFile",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Dosya başarıyla yüklendi!", "Başarılı");
                    $("#add-project-file-modal").modal('hide');
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    toastr.error(response.message || "Dosya yüklenirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            },
            complete: function () {
                $("#add_project_file_save_bt").prop("disabled", false).text("Yükle");
            }
        });
    };

    var deleteProjectFile = function (fileId) {
        if (!confirm("Bu dosyayı silmek istediğinize emin misiniz?")) {
            return;
        }

        $.ajax({
            url: "/Project/DeleteProjectFile",
            type: "POST",
            data: { fileId: fileId },
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Dosya başarıyla silindi!", "Başarılı");
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    toastr.error(response.message || "Dosya silinirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    // ===== NOTE FUNCTIONS =====

    var openNotesModal = function (lineId, lineTitle) {
        $("#notes_line_id").val(lineId);
        $("#project-line-notes-modal .modal-title").text("Faz Notları - " + lineTitle);
        $("#project-line-notes-modal").modal('show');
        loadNotes(lineId);
    };

    var loadNotes = function (lineId) {
        $("#notes-list-container").html('<div class="text-center py-5"><span class="text-muted">Yükleniyor...</span></div>');

        $.get("/Project/GetProjectLineNotes", { projectLineId: lineId }).done(function (response) {
            if (response.isSuccess) {
                renderNotesList(response.data);
            } else {
                $("#notes-list-container").html('<div class="text-center py-5"><span class="text-danger">Notlar yüklenirken hata oluştu!</span></div>');
            }
        }).fail(function () {
            $("#notes-list-container").html('<div class="text-center py-5"><span class="text-danger">Notlar yüklenirken hata oluştu!</span></div>');
        });
    };

    var renderNotesList = function (notes) {
        if (!notes || notes.length === 0) {
            $("#notes-list-container").html('<div class="text-center py-5"><span class="text-muted">Henüz not bulunmamaktadır.</span></div>');
            return;
        }

        var html = '<div class="timeline timeline-5 mt-3">';
        $.each(notes, function (index, note) {
            html += '<div class="timeline-item align-items-start" data-note-id="' + note.id + '">' +
                '<div class="timeline-label">' +
                (note.date || '') +
                '</div>' +
                '<div class="timeline-badge">' +
                '<i class="flaticon2-paper text-success"></i>' +
                '</div>' +
                '<div class="timeline-content d-flex justify-content-between">' +
                '<div style="flex: 1;">' +
                (note.title ? '<span class="font-weight-bold">' + note.title + '</span><br>' : '') +
                '<span class="text-muted">' + (note.note || '') + '</span>' +
                (note.reportNote ? '<br><small class="text-info">Rapor: ' + note.reportNote + '</small>' : '') +
                '<br><small class="text-muted">Oluşturan: ' + (note.userFullName || '') + '</small>' +
                '</div>' +
                '<div class="ml-3">' +
                '<button type="button" class="btn btn-icon btn-sm btn-warning btn-edit-note-from-list" data-id="' + note.id + '" title="Düzenle"><i class="flaticon2-pen"></i></button>' +
                '<button type="button" class="btn btn-icon btn-sm btn-danger btn-delete-note" data-id="' + note.id + '" title="Sil"><i class="flaticon2-trash"></i></button>' +
                '</div>' +
                '</div>' +
                '</div>';
        });
        html += '</div>';
        $("#notes-list-container").html(html);
    };

    var saveProjectLineNote = function () {
        var model = {
            projectLineId: $("#note_ProjectLineId").val(),
            title: $("#note_Title").val(),
            reportNote: $("#note_ReportNote").val(),
            note: $("#note_Note").val(),
            date: $("#note_Date").val() || null
        };

        $("#add_project_line_note_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Kaydediliyor...');

        $.ajax({
            url: "/Project/AddProjectLineNote",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Not başarıyla eklendi!", "Başarılı");
                    $("#add-project-line-note-modal").modal('hide');
                    // Reload notes list
                    setTimeout(function () {
                        loadNotes($("#note_ProjectLineId").val());
                        $("#note_Title").val('');
                        $("#note_ReportNote").val('');
                        $("#note_Note").val('');
                        $("#note_Date").val('');
                    }, 500);
                } else {
                    toastr.error(response.message || "Not eklenirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            },
            complete: function () {
                $("#add_project_line_note_save_bt").prop("disabled", false).text("Ekle");
            }
        });
    };

    var updateProjectLineNote = function () {
        var model = {
            id: $("#edit_note_Id").val(),
            projectLineId: $("#edit_note_ProjectLineId").val(),
            title: $("#edit_note_Title").val(),
            reportNote: $("#edit_note_ReportNote").val(),
            note: $("#edit_note_Note").val(),
            date: $("#edit_note_Date").val() || null
        };

        $("#edit_project_line_note_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Güncelleniyor...');

        $.ajax({
            url: "/Project/UpdateProjectLineNote",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Not başarıyla güncellendi!", "Başarılı");
                    $("#edit-project-line-note-modal").modal('hide');
                    setTimeout(function () {
                        loadNotes($("#edit_note_ProjectLineId").val());
                    }, 500);
                } else {
                    toastr.error(response.message || "Not güncellenirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            },
            complete: function () {
                $("#edit_project_line_note_save_bt").prop("disabled", false).text("Güncelle");
            }
        });
    };

    var deleteProjectLineNote = function (noteId) {
        if (!confirm("Bu notu silmek istediğinize emin misiniz?")) {
            return;
        }

        $.ajax({
            url: "/Project/DeleteProjectLineNote",
            type: "POST",
            data: { id: noteId },
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Not başarıyla silindi!", "Başarılı");
                    setTimeout(function () {
                        loadNotes($("#notes_line_id").val());
                    }, 500);
                } else {
                    toastr.error(response.message || "Not silinirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    // ===== WORK FUNCTIONS =====

    var openWorksModal = function (lineId, lineTitle) {
        $("#works_line_id").val(lineId);
        $("#project-line-works-modal .modal-title").text("Faz İşleri - " + lineTitle);
        $("#project-line-works-modal").modal('show');
        loadWorks(lineId);
    };

    var loadWorks = function (lineId) {
        $("#works-list-container").html('<div class="text-center py-5"><span class="text-muted">Yükleniyor...</span></div>');

        console.log("=== İşler Yükleniyor ===");
        console.log("LineId:", lineId);

        $.get("/Project/GetProjectLineWorkList", { projectLineId: lineId }).done(function (response) {
            console.log("İşler API Yanıtı:", response);

            if (response.isSuccess && response.data && response.data.length > 0) {
                var html = '<table class="table table-bordered table-sm"><thead><tr><th>İş Adı</th><th>Durum</th><th>Öncelik</th><th>Sıra</th><th>Tahmini Süre</th><th>Harcanan Süre</th><th>İşlemler</th></tr></thead><tbody>';
                $.each(response.data, function (i, work) {
                    // Durum badge
                    var workStatusBadge = work.workStatus === 5 ? '<span class="badge badge-success">Tamamlandı</span>' :
                                           work.workStatus === 2 ? '<span class="badge badge-info">Devam Ediyor</span>' :
                                           work.workStatus === 3 ? '<span class="badge badge-warning">Başkasını Bekliyor</span>' :
                                           work.workStatus === 4 ? '<span class="badge badge-dark">Ertelendi</span>' :
                                           work.workStatus === 6 ? '<span class="badge badge-danger">İptal Edildi</span>' :
                                           work.workStatus === 7 ? '<span class="badge badge-primary">Yeniden Açıldı</span>' :
                                           '<span class="badge badge-secondary">Başlamadı</span>';

                    // Duruma göre butonlar
                    var buttons = '';
                    var status = work.workStatus;

                    // Başla butonu - New(0), NotStarted(1), Reopened(7) durumlarında göster
                    if (status === 0 || status === 1 || status === 7) {
                        buttons += '<button type="button" class="btn btn-icon btn-sm btn-success btn-work-start-from-list" data-id="' + work.id + '" data-status="2" title="Başla" data-toggle="tooltip"><i class="fas fa-play"></i></button>';
                    }

                    // Tamamla butonu - InProgress(2) durumunda göster
                    if (status === 2) {
                        buttons += '<button type="button" class="btn btn-icon btn-sm btn-baby-blue btn-work-complete-from-list" data-id="' + work.id + '" data-status="5" title="Tamamla" data-toggle="tooltip"><i class="fas fa-check"></i></button>';
                    }

                    // Düzenle butonu - Completed(5) ve Canceled(6) dışında
                    if (status !== 5 && status !== 6) {
                        buttons += '<button type="button" class="btn btn-icon btn-sm btn-warning btn-edit-work-from-list" data-id="' + work.id + '" title="Düzenle"><i class="flaticon2-pen"></i></button>';
                    }

                    // Destek Ekle butonu
                    var firmOid = $("#page_FirmOid").val();
                    var projCode = $("#page_ProjectCode").text().trim();
                    buttons += '<button type="button" class="btn btn-icon btn-sm btn-info add-support" ' +
                                'data-firm="' + firmOid + '" ' +
                                'data-project="' + projCode + '" ' +
                                'data-lineid="' + lineId + '" ' +
                                'data-lineworkid="' + work.id + '" ' +
                                'title="Destek Ekle" data-toggle="tooltip"><i class="flaticon2-plus"></i></button>';

                    // Sil butonu
                    buttons += '<button type="button" class="btn btn-icon btn-sm btn-danger btn-delete-work" data-id="' + work.id + '" title="Sil"><i class="flaticon2-trash"></i></button>';

                    html += '<tr data-id="' + work.id + '" data-name="' + (work.name || '') + '" data-description="' + (work.description || '') + '" data-priority="' + (work.priority || 3) + '" data-roworder="' + (work.rowOrder || 0) + '" data-linefirmofficialid="' + (work.lineFirmOfficialId || '') + '">' +
                        '<td>' + (work.name || '') + '</td>' +
                        '<td>' + workStatusBadge + '</td>' +
                        '<td>' + (work.priority || 3) + '</td>' +
                        '<td>' + (work.rowOrder || 0) + '</td>' +
                        '<td>' + formatMinutes(work.estimatedTime) + '</td>' +
                        '<td>' + formatMinutes(work.timeSpend) + '</td>' +
                        '<td>' + buttons + '</td></tr>';
                });
                html += '</tbody></table>';
                $("#works-list-container").html(html);
            } else {
                console.log("İş bulunamadı veya hata:", response);
                $("#works-list-container").html('<div class="text-center py-5"><span class="text-muted">Bu faz için iş bulunmamaktadır.</span></div>');
            }
        }).fail(function (xhr, status, error) {
            console.error("=== İşler Yükleme Hatası ===");
            console.error("Status:", status);
            console.error("Error:", error);
            console.error("Response:", xhr.responseText);
            $("#works-list-container").html('<div class="text-center py-5"><span class="text-danger">İşler yüklenirken hata oluştu!</span></div>');
        });
    };

    var saveProjectLineWork = function () {
        var departmentOid = $("#work_Department").val();
        var assignedTo = $("#work_AssignedTo").val();
        var createSupportTicket = $("#work_CreateSupportTicket").is(":checked");
        var lineId = $("#work_LineId").val();

        console.log("=== İş Kaydetme ===");
        console.log("LineId:", lineId);
        console.log("CreateSupportTicket:", createSupportTicket);
        console.log("AssignedTo:", assignedTo);

        // LineId kontrolü
        if (!lineId || lineId.trim() === "") {
            toastr.error("Faz bilgisi bulunamadı! Lütfen sayfayı yenileyip tekrar deneyin.", "Hata");
            return;
        }

        // Personel seçili değil ve destek kaydı oluşturulacaksa uyarı ver
        if (createSupportTicket && !assignedTo) {
            toastr.warning("Destek kaydı oluşturmak için personel seçimi zorunludur!", "Uyarı");
            return;
        }

        var model = {
            lineId: lineId,
            name: $("#work_Name").val(),
            description: $("#work_Description").val(),
            reportDescription: $("#work_ReportDescription").val(),
            assignedTo: assignedTo || null,
            departmentOid: departmentOid || null,
            lineFirmOfficialId: $("#work_LineFirmOfficialId").val() || null,
            priority: parseInt($("#work_Priority").val() || "3"),
            rowOrder: parseInt($("#work_RowOrder").val() || "0"),
            estimatedTime: calculateTotalMinutes(
                parseInt($("#work_EstimatedDays").val() || "0"),
                parseInt($("#work_EstimatedHours").val() || "0"),
                parseInt($("#work_EstimatedMinutes").val() || "0")
            ),
            letTimeDeduct: $("#work_LetTimeDeduct").is(":checked"),
            createSupportTicket: createSupportTicket,
            workPersons: null,
            releatedSupport: null
        };

        console.log("Gönderilecek Model:", JSON.stringify(model, null, 2));

        if (!model.name || model.name.trim() === "") {
            toastr.warning("İş Adı zorunludur!", "Uyarı");
            return;
        }

        $("#add_project_line_work_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Ekleniyor...');

        $.ajax({
            url: "/Project/AddProjectLineWork",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "İş başarıyla eklendi!", "Başarılı");
                    $("#add-project-line-work-modal").modal('hide');
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    // Faz tamamlanmış mı kontrol et
                    if (response.requireReopen) {
                        toastr.warning(response.message, "Uyarı");
                        // Kullanıcıya fazı yeniden açma seçeneği sun
                        if (confirm("Fazı yeniden açmak istiyor musunuz?")) {
                            reopenProjectLine(response.lineId);
                        }
                    } else {
                        toastr.error(response.message || "İş eklenirken bir hata oluştu!", "Hata");
                    }
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            },
            complete: function () {
                $("#add_project_line_work_save_bt").prop("disabled", false).text("Ekle");
            }
        });
    };

    // Fazı yeniden açma fonksiyonu
    var reopenProjectLine = function (lineId) {
        $.ajax({
            url: "/Project/ChangeProjectLineStatus",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ id: lineId, status: 2 }), // 2 = InProgress (Devam Ediyor)
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success("Faz yeniden açıldı, şimdi iş ekleyebilirsiniz!", "Başarılı");
                    // İş ekle modal'ını tekrar aç
                    setTimeout(function () {
                        $("#work_LineId").val(lineId);
                        $("#add-project-line-work-modal").modal('show');
                    }, 500);
                } else {
                    toastr.error(response.message || "Faz yeniden açılırken hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    // İş detaylarını düzenleme modal'ına yerleştir
    // Not: Modal'ı açma işlemi çağıran fonksiyon tarafından yapılmalıdır
    var populateEditWorkModal = function (work) {
        console.log("İş detayları:", work);

        $("#edit_work_Id").val(work.Id);
        $("#edit_work_Name").val(work.Name);
        $("#edit_work_Description").val(work.Description);

        // Select2 elemanları için değer ata ve trigger('change') çağır
        $("#edit_work_Priority").val(work.Priority).trigger('change');
        $("#edit_work_LineFirmOfficialId").val(work.LineFirmOfficialId).trigger('change');

        $("#edit_work_RowOrder").val(work.RowOrder);
        $("#edit_work_Status").val(work.WorkStatus);

        // İptal açıklamasını göster/gizle
        $("#edit_work_CancelDescriptionRow").toggle(work.WorkStatus === 6); // 6 = Canceled
        if (work.CancelDescription) {
            $("#edit_work_CancelDescription").val(work.CancelDescription);
        }

        // Durum değişikliği kontrolü
        $("#edit_work_Status").off("change").on("change", function () {
            var newStatus = parseInt($(this).val());
            $("#edit_work_CancelDescriptionRow").toggle(newStatus === 6);
        });

        // Tahmini süre
        if (work.EstimatedTime) {
            var totalMins = work.EstimatedTime;
            $("#edit_work_EstimatedDays").val(Math.floor(totalMins / (24 * 60)));
            $("#edit_work_EstimatedHours").val(Math.floor((totalMins % (24 * 60)) / 60));
            $("#edit_work_EstimatedMinutes").val(totalMins % 60);
        } else {
            $("#edit_work_EstimatedDays").val(0);
            $("#edit_work_EstimatedHours").val(0);
            $("#edit_work_EstimatedMinutes").val(0);
        }

        // Harcanan süre
        if (work.TimeSpend) {
            var totalMins = work.TimeSpend;
            $("#edit_work_TimeSpendDays").val(Math.floor(totalMins / (24 * 60)));
            $("#edit_work_TimeSpendHours").val(Math.floor((totalMins % (24 * 60)) / 60));
            $("#edit_work_TimeSpendMinutes").val(totalMins % 60);
        } else {
            $("#edit_work_TimeSpendDays").val(0);
            $("#edit_work_TimeSpendHours").val(0);
            $("#edit_work_TimeSpendMinutes").val(0);
        }

        // Modal'ı açma işlemi çağıran fonksiyon tarafından yapılır
        // Bu, modal geçiş sorunlarını önlemek için gereklidir
    };

    // Dakika hesaplama yardımcı fonksiyonu
    var calculateTotalMinutes = function (days, hours, minutes) {
        return (days * 24 * 60) + (hours * 60) + minutes;
    };

    // Dakikayı Gün-Saat-Dakika formatına çeviren yardımcı fonksiyon
    var formatMinutes = function (totalMinutes) {
        if (!totalMinutes || totalMinutes === 0) return "0 dk";

        const days = Math.floor(totalMinutes / (24 * 60));
        const hours = Math.floor((totalMinutes % (24 * 60)) / 60);
        const mins = totalMinutes % 60;

        var result = [];
        if (days > 0) result.push(days + " gün");
        if (hours > 0) result.push(hours + " saat");
        if (mins > 0) result.push(mins + " dk");
        if (result.length === 0) return "0 dk";

        return result.join(" ");
    };

    var updateProjectLineWork = function () {
        var status = parseInt($("#edit_work_Status").val() || 0);

        // İptal ediliyorsa açıklama zorunlu
        if (status === 6 && !$("#edit_work_CancelDescription").val().trim()) {
            toastr.warning("İptal edilmesi için iptal sebebi girilmelidir!", "Uyarı");
            return;
        }

        var model = {
            id: $("#edit_work_Id").val(),
            name: $("#edit_work_Name").val(),
            description: $("#edit_work_Description").val(),
            lineFirmOfficialId: $("#edit_work_LineFirmOfficialId").val() || null,
            priority: parseInt($("#edit_work_Priority").val() || "3"),
            rowOrder: parseInt($("#edit_work_RowOrder").val() || "0"),
            estimatedTime: calculateTotalMinutes(
                parseInt($("#edit_work_EstimatedDays").val() || "0"),
                parseInt($("#edit_work_EstimatedHours").val() || "0"),
                parseInt($("#edit_work_EstimatedMinutes").val() || "0")
            ),
            timeSpend: calculateTotalMinutes(
                parseInt($("#edit_work_TimeSpendDays").val() || "0"),
                parseInt($("#edit_work_TimeSpendHours").val() || "0"),
                parseInt($("#edit_work_TimeSpendMinutes").val() || "0")
            ),
            letTimeDeduct: $("#edit_work_LetTimeDeduct").is(":checked"),
            workStatus: status,
            cancelDescription: status === 6 ? $("#edit_work_CancelDescription").val() : null
        };

        console.log("Güncellenecek İş:", model);

        $("#edit_project_line_work_save_bt").prop("disabled", true).html('<i class="fa fa-spinner fa-spin"></i> Güncelleniyor...');

        $.ajax({
            url: "/Project/UpdateProjectLineWork",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "İş başarıyla güncellendi!", "Başarılı");
                    $("#edit-project-line-work-modal").modal('hide');
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    toastr.error(response.message || "İş güncellenirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            },
            complete: function () {
                $("#edit_project_line_work_save_bt").prop("disabled", false).text("Güncelle");
            }
        });
    };

    var deleteProjectLineWork = function (workId) {
        if (!confirm("Bu işi silmek istediğinize emin misiniz?")) {
            return;
        }

        $.ajax({
            url: "/Project/DeleteProjectLineWork",
            type: "POST",
            data: { id: workId },
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "İş başarıyla silindi!", "Başarılı");
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    toastr.error(response.message || "İş silinirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    var changeProjectLineWorkStatus = function (workId, status) {
        var model = {
            Id: workId,
            WorkStatus: status
        };

        console.log("=== İş Durumu Değiştiriliyor ===");
        console.log("WorkId:", workId, "Status:", status);

        $.ajax({
            url: "/Project/ChangeProjectLineWorkStatus",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(model),
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success("İş durumu başarıyla değiştirildi!", "Başarılı");
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    toastr.error(response.message || "İş durumu değiştirilirken bir hata oluştu!", "Hata");
                }
            },
            error: function (xhr) {
                console.error("Hata:", xhr.responseText);
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    // ===== Phase 2: Additional Functions =====

    // Bulk status change function
    var bulkChangeProjectLineStatus = function (lineIds, status) {


        

        $.ajax({
            url: "/Project/BulkChangeProjectLineStatus",
            type: "POST",
            data: { lineIds: lineIds, status: status },
            success: function (response) {
                if (response.isSuccess) {
                    toastr.success(response.message || "Faz durumu başarıyla değiştirildi!", "Başarılı");
                    setTimeout(function () { location.reload(); }, 1000);
                } else {
                    toastr.error(response.message || "Faz durumu değiştirilirken bir hata oluştu!", "Hata");
                }
            },
            error: function () {
                toastr.error("İşlem sırasında bir hata oluştu!", "Hata");
            }
        });
    };

    // Load all works from all lines
    var loadAllWorks = function () {
        $("#all-works-container").html('<div class="text-center py-5"><span class="text-muted">Yükleniyor...</span></div>');

        // Get all line IDs from the table
        var lineIds = [];
        $("#ProjectLineTable tbody tr").each(function () {
            var lineId = $(this).data("id");
            if (lineId) {
                lineIds.push(lineId);
            }
        });

        if (lineIds.length === 0) {
            $("#all-works-container").html('<div class="text-center py-5"><span class="text-muted">Faz bulunmamaktadır.</span></div>');
            return;
        }

        // Load works for each line (simplified - in real implementation, you'd have a consolidated API)
        var html = '<div class="accordion accordion-solid accordion-toggle-arrow" id="works-accordion">';
        var count = 0;

        $("#ProjectLineTable tbody tr").each(function () {
            var lineId = $(this).data("id");
            var lineTitle = $(this).find("td").eq(1).text();
            var lineStatus = $(this).find("td").eq(2).html();

            html += '<div class="card">' +
                '<div class="card-header">' +
                '<div class="card-title collapsed" data-toggle="collapse" data-target="#works-' + lineId + '">' +
                '<i class="flaticon-list-1"></i> ' + lineTitle + ' <span class="ml-2">' + lineStatus + '</span>' +
                '</div>' +
                '</div>' +
                '<div id="works-' + lineId + '" class="collapse" data-parent="#works-accordion">' +
                '<div class="card-body">' +
                '<div class="text-center py-3"><button type="button" class="btn btn-sm btn-primary btn-load-works" data-id="' + lineId + '">İşleri Yükle</button></div>' +
                '</div>' +
                '</div>' +
                '</div>';
            count++;
        });

        html += '</div>';
        $("#all-works-container").html(html);
    };

    // Load works for a specific line in the all-works tab
    $(document).on("click", ".btn-load-works", function () {
        var lineId = $(this).data("id");
        var $container = $(this).closest(".card-body");

        $container.html('<div class="text-center py-3"><span class="spinner-border"></span></div>');

        $.get("/Project/GetProjectLineWorkList", { projectLineId: lineId }).done(function (response) {
            if (response.isSuccess && response.data && response.data.length > 0) {
                var html = '<table class="table table-bordered table-sm"><thead><tr><th>İş Adı</th><th>Durum</th><th>Öncelik</th><th>Sıra</th><th>İşlemler</th></tr></thead><tbody>';
                $.each(response.data, function (i, work) {
                    var workStatusBadge = work.stateStatus === 6 ? '<span class="badge badge-success">Tamamlandı</span>' :
                                           work.stateStatus === 2 ? '<span class="badge badge-info">Devam Ediyor</span>' :
                                           '<span class="badge badge-secondary">Başlamadı</span>';

                    html += '<tr><td>' + work.name + '</td><td>' + workStatusBadge + '</td><td>' + work.priority + '</td><td>' + work.rowOrder + '</td>' +
                        '<td><button type="button" class="btn btn-icon btn-sm btn-warning btn-edit-work-from-all" data-id="' + work.id + '"><i class="flaticon2-pen"></i></button></td></tr>';
                });
                html += '</tbody></table>';
                $container.html(html);
            } else {
                $container.html('<div class="text-center py-3"><span class="text-muted">Bu faz için iş bulunmamaktadır.</span></div>');
            }
        }).fail(function () {
            $container.html('<div class="text-center py-3"><span class="text-danger">İşler yüklenirken hata oluştu!</span></div>');
        });
    });

    // Load all notes from all lines
    var loadAllNotes = function () {
        $("#all-notes-container").html('<div class="text-center py-5"><span class="text-muted">Yükleniyor...</span></div>');

        var html = '<div class="timeline timeline-5 mt-3">';
        var count = 0;

        $("#ProjectLineTable tbody tr").each(function () {
            var lineId = $(this).data("id");
            var lineTitle = $(this).find("td").eq(1).text();

            // Load notes for this line
            $.get("/Project/GetProjectLineNotes", { projectLineId: lineId }).done(function (response) {
                if (response.isSuccess && response.data && response.data.length > 0) {
                    $.each(response.data, function (i, note) {
                        html += '<div class="timeline-item align-items-start">' +
                            '<div class="timeline-label">' + (note.date || '') + '</div>' +
                            '<div class="timeline-badge"><i class="flaticon2-paper text-success"></i></div>' +
                            '<div class="timeline-content d-flex justify-content-between">' +
                            '<div style="flex: 1;">' +
                            '<span class="font-weight-bold">' + (note.title || 'Not') + '</span>' +
                            '<br><small class="text-muted">Faz: ' + lineTitle + '</small>' +
                            '<br><span class="text-muted">' + (note.note || '') + '</span>' +
                            '</div>' +
                            '</div>' +
                            '</div>';
                    });
                }

                count++;
                // Check if all lines processed
                if (count === $("#ProjectLineTable tbody tr").length) {
                    html += '</div>';
                    $("#all-notes-container").html(html);
                }
            }).fail(function () {
                $("#all-notes-container").html('<div class="text-center py-5"><span class="text-danger">Notlar yüklenirken hata oluştu!</span></div>');
            });
        });

        // If no lines, show empty message
        if ($("#ProjectLineTable tbody tr").length === 0) {
            $("#all-notes-container").html('<div class="text-center py-5"><span class="text-muted">Faz bulunmamaktadır.</span></div>');
        }
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
