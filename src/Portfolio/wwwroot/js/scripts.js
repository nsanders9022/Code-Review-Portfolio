$(document).ready(function () {
    console.log("inside scripts");
    $.ajax({
        type: 'GET',
        dataType: 'json',
        data: $(this).serialize(),
        url: 'Projects/GetProjects',
        success: function (result) {
            console.log("success");
            for (var i = 0; i < result.length; i++) {
                $('#result').append('<p>' + result[i].url + '<p>');
            }
        }
    });
});


//3e765e54f6c06bc73d85f4fdc7139abfcc1004e7