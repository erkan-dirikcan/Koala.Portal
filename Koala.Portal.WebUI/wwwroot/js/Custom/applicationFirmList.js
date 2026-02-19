"use strict";
var ApplicationFirmTable = function () {

    var initTable = function () {
        var table = $('#applicationFirmTable');
        var selectedApplicationId = "";
        var selectedFirmId = "";
        var selectedLineId = "";

        $(".create-firm-code").click(function () {
            var applicationId = $(this).attr('data-applicationId');
            var firmId = $(this).attr('data-FirmId');
            var id = $(this).data("id");

            selectedApplicationId = applicationId;
            selectedFirmId = firmId;
            $("#add-application-firm-Code-modal").modal();
        });

        $(".update-firm-exp-date").click(function () {
            var applicationId = $(this).attr('data-applicationId');
            var firmId = $(this).attr('data-FirmId');
            var id = $(this).data("id");

            selectedApplicationId = applicationId;
            selectedFirmId = firmId;
            selectedLineId = id;
            $("#update-application-firm-exp-date-modal").modal();
        });

      
        $("#update-exp_date-bt").click(function () {
            var model = {
                Id: selectedLineId,
                ApplicationId: selectedApplicationId,
                FirmId: selectedFirmId,
                ExpDate: $("#ExpDate_date").find("input").val()
            }
            $.post("/Applications/UpdateFirmExpDate", {model:model}).done(function (result) {
                if (result.isSuccess) {
                    toastr.success(result.message, "Başarılı");
                } else {
                    toastr.error(result.message, "Bir Hata Oluştu");
                }
            });
        });

        $("#add-application-firm-bt").click(function () {
            var applicationId = $(this).data("id");
            selectedApplicationId = applicationId;
            $("#add-application-firm-modal").modal();
        });

        $("#GetCode").click(function () {

            $.get("/Applications/GetFirmCode?FirmId=" + selectedFirmId).done(function (result) {
                if (result.isSuccess) {
                    $("#firm-code-tb").val(result.data);
                    toastr.success(result.message, "Başarılı");

                } else {
                    toastr.error(result.message, "Bir Hata Oluştu");
                }
            });
        });

        $("#CopyCode").click(function () {

            var copyText = document.getElementById("firm-code-tb");
            copyText.select();
            copyText.setSelectionRange(0, 99999);
            navigator.clipboard.writeText(copyText.value);
            toastr.warning("Firma Kodu Başarıyla Kopyalandı", "Kopyalandı");
        });

        $('#add-application-firm-modal').on('shown.bs.modal', function () {


            $('#selected-application-firm-sl').select2({
                placeholder: "Destek Firması Seçin",
                language: "tr"
            });
        });

        $('#update-application-firm-exp-date-modal').on('shown.bs.modal', function () {

            $('#ExpDate_date').datetimepicker({
                locale: 'tr',
                format: 'DD-MM-YYYY'
            });
        });


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
    ApplicationFirmTable.init();
});
