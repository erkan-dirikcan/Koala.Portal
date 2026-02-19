"use strict";
var UserTable = function () {

	var initTable = function () {
		var table = $('#ClaimDetailTable');

	

		// begin first table
		table.DataTable({
			responsive: true,
			columnDefs: [

			]
		});

	};
	var modalMethods = function () {
		var selectedClaimId = "";
		$(".DeleteClaim").click(function () {
			var claimId = $(this).data("id");
			selectedClaimId = claimId;
			var claimName = $(this).attr('data-name');
			$("#delete_claim_title").text(claimName + 'Yetkisini Sil')
			$("#delete_claim_content").text(claimName + ' İsimli yetkiyi sildiğinizde bu yetki atanmış tüm kullanıcılardan kaldırılacaktır.')
			$("#DeleteClaimModal").modal();
		});
		$("#delete_claim").click(function () {
			$.post("/Module/DeleteModuleClaim/" + selectedClaimId).done(function (result) {
				if (result.isSuccess) {
					setTimeout(function () {
						window.location.reload();
					}, 3000);
					toastr.success("Yetki Başarıyla Silindi", result.message);

				} else {
					toastr.error("Bir Hata Oluştu", result.message);
				}
			});
		});
	};
	return {


		init: function () {
			initTable();
			modalMethods();
		}

	};

}();

jQuery(document).ready(function () {
	UserTable.init();
});
