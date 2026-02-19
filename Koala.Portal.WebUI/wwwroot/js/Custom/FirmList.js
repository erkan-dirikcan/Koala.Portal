"use strict";
var FirmTable = function () {

	var initFirm = function () {
        

		var firmtable = $('#FirmTable');

		// begin first table
        firmtable.DataTable({
			responsive: true,
			columnDefs: [				

			]
		});
		$(".firm-update-bt").click(function () {
			var itemId = $(this).data("id")
			$.get("/Firm/GetFirmDetail/" + itemId).done(function(result) {
				if (result.isSuccess) {

            }else {

            }
			});
		});
		

	};

    
	return {


		initFirmTable: function () {
            initFirm();
		}

	};

}();

jQuery(document).ready(function () {
    FirmTable.initFirmTable();




});
