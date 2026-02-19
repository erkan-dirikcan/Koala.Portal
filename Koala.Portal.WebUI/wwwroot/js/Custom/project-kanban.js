"use strict";

// Class definition

var KTKanbanBoardDemo = function() {
    // Private functions
    var _demo1 = function() {
        var kanban = new jKanban({
            element: '#ProjeKanban',
            gutter: '0',
            widthBoard: '350px',
            click: function(el,source) {
                alert(el.dataset.eid); 
            },
            boards: [{
                    'id': '_inprocess',
                    'title': 'İşlemler',
                    'class': 'light-dark',
                    'item': [{
                            "id"    : "item-id-1",
                            'title': '<span class="font-weight-bold">Üretim Adımları Planlaması</span>',
                            'class': 'primary'
                        },
                        {
                            "id"    : "item-id-2",
                            'title': '<span class="font-weight-bold">E-Devlet Entegrasyonu</span>',
                            'class': 'primary'
                        },
                        {
                            "id"    : "item-id-3",
                            'title': '<span class="font-weight-bold">Fatura Tasarımlarının Yapılması</span>',
                            'class': 'primary'
                        },
                        {
                            "id"    : "item-id-4",
                            'title': '<span class="font-weight-bold">Eğitim</span>',
                            'class': 'primary'
                        }
                    ]
                }, {
                    'id': '_working',
                    'title': 'Yapılıyor',
                    'class': 'light-primary',
                    'item': [{
                            'title': '<span class="font-weight-bold">Eski ERP Datalarının Taşınması</span>',
                            'class': 'primary'
                        },
                        {
                            'title': '<span class="font-weight-bold">Tiger Firma ve Kullanıcı Tanımları</span>',
                            'class': 'primary'
                        }
                    ]
                }, {
                    'id': '_done',
                    'title': 'Tamamlandı',
                    'class': 'light-success',
                    'item': [{
                            'title': '<span class="font-weight-bold">Logo Tiger Lisans İşlemleri</span>',
                            'class': 'primary'
                        },
                        {
                            'title': '<span class="font-weight-bold">Logo Tiger Kurulumu</span>',
                            'class': 'primary'
                        }
                    ]
                }
            ]
        });
    }


    // Public functions
    return {
        init: function() {
            _demo1();
         
        }
    };
}();

jQuery(document).ready(function() {
    KTKanbanBoardDemo.init();
});
