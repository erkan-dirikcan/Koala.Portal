"use strict";
var ApplicationTable = function () {

	var initTable = function () {
		var table = $('#vacation-table');

		// begin first table
		table.DataTable({
			responsive: true,
			columnDefs: [				
				{
					width: '75px',
					targets: 2,
					className: "text-center",
					render: function (data, type, full, meta) {
						var status = {
							1: { 'title': 'Aktif', 'class': 'label-light-success' },
							2: { 'title': 'Pasif', 'class': ' label-light-warning' },
							3: { 'title': 'Silinmiş', 'class': ' label-light-danger' },
							4: { 'title': 'Bloke Edilmiş', 'class': ' label-light-warning' }
						};
						if (typeof status[ data ] === 'undefined') {
							return data;
						}
						return '<span class="label label-lg font-weight-bold ' + status[ data ].class + ' label-inline">' + status[ data ].title + '</span>';
					}
				},
				{
					width: '50px',
					targets: 3				
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
