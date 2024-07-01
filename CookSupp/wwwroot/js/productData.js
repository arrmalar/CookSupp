$(document).ready(function () {
    $.ajax({
        url: '/admin/product/getall',
        type: 'GET',
        success: function (data) {
            new MultiSelect(document.getElementById('productSelect'), {
                data: data.data.map(el => ({
                    value: el.name,
                    text: el.name
                })),
                placeholder: 'Select options',
                search: true,
                onChange: function (value, text, element) {

                },
                onSelect: function (value, text, element) {
                    
                },
                onUnselect: function (value, text, element) {
                    
                }
            });
        },
        error: function (xhr, status, error) {
            console.error("An error occurred: " + status + " " + error);
        }
    });
});