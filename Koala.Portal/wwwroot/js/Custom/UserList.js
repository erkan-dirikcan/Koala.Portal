"use strict";
var UserTable = function () {

	var initTable = function () {
		var table = $('#UserTable');

		// begin first table
		table.DataTable({
			responsive: true,
			columnDefs: [				
				{
					width: '75px',
					targets: 4,
					render: function (data, type, full, meta) {
						var status = {
							1: { 'title': 'Pending', 'class': 'label-light-success' },
							2: { 'title': 'Delivered', 'class': ' label-light-danger' },
							3: { 'title': 'Canceled', 'class': ' label-light-primary' },
							4: { 'title': 'Success', 'class': ' label-light-success' }
						};
						if (typeof status[ data ] === 'undefined') {
							return data;
						}
						return '<span class="label label-lg font-weight-bold ' + status[ data ].class + ' label-inline">' + status[ data ].title + '</span>';
					}
				}
			]
		});

	};

	return {

		//main function to initiate the module
		init: function () {
			initTable();
		}

	};

}();

jQuery(document).ready(function () {
	UserTable.init();
});
