"use strict";
var ApplicationTable = function () {

    var initTable = function () {
        var table = $('#applicationTable');
        var selectedApplicationId = "";
        $(".create-firm-code-bt").click(function () {
            var applicationId = $(this).data("id");
            selectedApplicationId = applicationId;
            $("#CreateCode").modal();
        });

        $(".add-firm-bt").click(function () {
            var applicationId = $(this).data("id");
            selectedApplicationId = applicationId;
            $("#add-application-firm-modal").modal();
        });


        $("#add-firm-to-application-bt").click(function () {
            var model = {
                ApplicationId: selectedApplicationId,
                FirmId: $('#selected-application-firm-sl').val()
                //DateTime: null
            }
            $.post("/Applications/AddFirmToApplication", { model: model }).done(function (result) {
                if (result.isSuccess) {
                    setTimeout(function () {
                        window.location.reload();
                    }, 3000);
                    toastr.success("Destek Kaydı Başarıyla Oluşturuldu", result.message);

                } else {
                    $("#crt_sup_save_bt").removeAttr("hidden");
                    toastr.error("Bir Hata Oluştu", result.message);
                }
            });
        });

        $('#add-application-firm-modal').on('shown.bs.modal', function () {


            $('#selected-application-firm-sl').select2({
                placeholder: "Destek Firması Seçin",
                language: "tr"
            });
        });

        // begin first table
        table.DataTable({
            responsive: true,
            columnDefs: [
                {
                    width: '125px',
                    targets: 5,
                }
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
    ApplicationTable.init();
});
