var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    var authenticated = $('#recipeTblData').data('authenticated');
    var area = $('#recipeTblData').attr('area');
    var paging = $('#recipeTblData').attr('paging');
    var searching = $('#recipeTblData').attr('searching');

    console.log(authenticated);

    dataTable = $('#recipeTblData').DataTable(
        {
            "searching": searching == "true",
            "scrollY": 500,
            "paging": paging == "true",
            "ajax": { url: `/${area}/recipe/getAll` },
            "columns": [
                { data: 'title', "width": "15%" },
                { data: 'description', "width": "25%" },
                {
                    data: 'recipeProducts',
                    "render": function (data) {
                        var output = `<div class="w-100 btn-group" role="group">`;
                        output += `</div >`

                        return output
                    },
                    "width": "30%"
                },
                {
                    data: 'id',
                    "render": function (data) {

                        var output = `<div class="w-100 btn-group" role="group">`;

                        output += `<a href="/${area}/recipe/edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Details</a>`

                        if (authenticated === 'True')
                        {
                            output += `<a href="/${area}/recipe/addFavourite?id=${data}" class="btn btn-successjo mx-2"> <i class="bi bi-star"> Add To Favorite</i></a>`
                        }

                        if (authenticated === 'True') {

                            output += `<a onClick=Delete('/${area}/recipe/delete/${data}') class="btn btn-danger mx-2" > <i class="bi bi-trash-fill"></i> Delete</a >`
                        }

                        output += `</div>`

                        return output
                    },
                    "width": "30%"
                }
            ]
        });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}