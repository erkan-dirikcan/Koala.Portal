"use strict";
var UserTable = function () {

	var initTable = function () {
		var table = $('#CategoryTable');

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
	UserTable.init();
});
