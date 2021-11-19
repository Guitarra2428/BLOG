var dataTable;

$(document).ready(function () {
    cargarDataTable();
});


function cargarDataTable() {

    dataTable = $("#tblEmail").DataTable({
        "ajax": {
            "url": "/Cliente/Emails/GetAll",
            "type": "GET",
            "datatype": "json",
        },

        "columns": [
            { "data": "nombre", "width": "10%" },
            { "data": "apellido", "width": "10%" },
           { "data": "mensag", "width": "25%" },
           { "data": "gmail", "width": "20%" },

           {
                "data": "Id",
                "render": function (data) {
                    return `<div class="text-center"> 
                             <a href='/Admin/Emails/Detalle/${data}' class='btn btn-success text-whiter' style='Cursor:pointer; width:100px;'>
                             <i clas='fas fa-edit'></i> Editar
                             </a>
                        
                             &nbsp;
                             <a onclick=Delete("/Admin/Emails/Delete/${data}") class='btn btn-danger text-whiter' style='Cursor:pointer; width:100px;'>
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
        type: "Warning",
        showCancelarButton: true,
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
