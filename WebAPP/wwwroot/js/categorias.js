﻿var dataTable;

$(document).ready(function () {
    cargarDataTable();
});


function cargarDataTable() {

    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/Admin/Categorias/GetAll",
            "type": "GET",
            "datatype": "json",
        },

        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "50%" },
            { "data": "orden", "width": "20%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                             <a href='/Admin/Categorias/Edit/${data}' class='btn btn-success text-whiter' style='cursor:pointer; width:100px;'>
                             <i clas='fas fa-edit'></i> Editar
                             </a>
                        
                             &nbsp;
                             <a onclick=Delete("/Admin/Categorias/Delete/${data}") class='btn btn-danger text-whiter' style='cursor:pointer; width:100px;'>
                             <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                     
                         `;
                }, "width": "30%"

            }
        ],
        "language":
        {
            "emptyTable": "No Hay Registro"
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "Esta Seguro De Borrar",
        text: "Este Contenido no se puede recuperar",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Borrar",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();

                }
                else {
                    toastr.error(data.message)

                }
            }

        });
    });


}
