$(document).ready(function () {
    console.log("inside scripts");
    $.ajax({
        type: 'GET',
        dataType: 'json',
        data: $(this).serialize(),
        url: 'Projects/GetProjects',
        success: function (result) {
            console.log("success");
            for (var i = 0; i < 3; i++) {
                //$('#result').append('<li><a href="github.com/nsanders9022/' + result[i].name + '">' + result[i].name + '</a></li>');
                $('#result').append('<li><a href="' + result[i].html_url + '">' + result[i].name + '</a></li>');

            }
        }
    });
});