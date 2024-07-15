$(document).ready(function () {
    $("#driver").click(function (event) {

        $.getJSON('/jquery/result.json', function (jd) {
            $('#stage').html('<p> Name: ' + jd.name + '</p>');
            $('#stage').append('<p>Age : ' + jd.age + '</p>');
            $('#stage').append('<p> Sex: ' + jd.sex + '</p>');
        });

    });
});