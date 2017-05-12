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

//e18740bcc3127f4195fb1ce07644c8480ce94ae9 portfolio

//083a431b2e212e15bb31ff3f7c9ee4ca00527a9f Portfolio API