"use strict";
var FirmTable = function () {

	var initFirm = function () {
        

		var selectedContactId = '';

		var firmtable = $('#FirmContactTable');

		// begin first table
        firmtable.DataTable({
			responsive: true,
			columnDefs: [				

			]
		});

		$("update-contact-email").click(function () {
			var contactId = $(this).data("id");
			selectedContactId = contactId;

		});

		$("update-contact-email").click(function () {
			var contactId = $(this).data("id");
			selectedContactId = contactId;
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
