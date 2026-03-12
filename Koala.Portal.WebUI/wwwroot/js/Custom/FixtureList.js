"use strict";
var TicketReportTable = function () {

	var initTable = function () {
		var table = $('#TicketReportTable');

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
	TicketReportTable.init();
});
