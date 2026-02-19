"use strict";
var WaitingLicanceTable = function () {

    var initTable = function () {
        var table = $('#waitingLicanceTable');
        $('#accept-licance-bt').click(function () {

            var licanceId = $(this).data("id");
            var maxUserCount = $(this).data("maxuser");
            var activeUserCount = $(this).data("activeuser");
            /*
             data-id="@item.Id" data-maxuser="@item.MaxUserCount" data-activeuser="@item.ActiveUserCount"
             */
            //$.get('/Applications/GetApplicationLicanceCount')
            if (activeUserCount >= maxUserCount && maxUserCount > 0) {
                Swal.fire({
                    title: 'Lisansı Onaylamak İstediğinize Eminmisiniz?',
                    text: "Uygulama aktif lisans sayısı en fazla lisans sayısına ulaşmış durumda",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Evet Onayla!',
                    cancelButtonText: 'Hayır Vazgeç!',
                    reverseButtons: true
                }).then(function (result) {
                    if (result.value) {
                        $.get("/Applications/LiceceAcceptConfirm/" + licanceId + "?status=" + "1").done(function(result) {
                            if (result.isSuccess) {
                                setTimeout(function () {
                                    window.location.reload();
                                }, 3000);
                                toastr.success("Lisans Başarıyla Onaylandı", result.message);
                            } else {
                                toastr.error("Bir Hata Oluştu", result.message);
                            }
                        });
                       
                        // result.dismiss can be 'cancel', 'overlay',
                        // 'close', and 'timer'
                    } else if (result.dismiss === 'cancel') {
                        toastr.success("Kabul Edilmedi", result.message);
                    }
                });
            } else {
                $.get("/Applications/LiceceAcceptConfirm/" + licanceId + "?status=" + 1).done(function (result) {
                    if (result.isSuccess) {
                        setTimeout(function () {
                            window.location.reload();
                        }, 3000);
                        toastr.success("Lisans Başarıyla Onaylandı", result.message);
                    } else {
                        toastr.error("Bir Hata Oluştu", result.message);
                    }
                });
            }

        });
        $('#reject-licance-bt').click(function() {
            var licanceId = $(this).data("id");
            $.get("/Applications/LiceceAcceptConfirm/" + licanceId + "?status=" + 3).done(function(result) {
                if (result.isSuccess) {
                    setTimeout(function() {
                            window.location.reload();
                        },
                        3000);
                    toastr.success("Lisans Başarıyla Reddedildi", result.message);
                } else {
                    toastr.error("Bir Hata Oluştu", result.message);
                }
            });
        });
        // begin first table
        table.DataTable({
            responsive: true,
            columnDefs: [

            ]
        });

    };

    return {


        init: function () {
            initTable();
        }

    };

}();

jQuery(document).ready(function () {
    WaitingLicanceTable.init();
});
