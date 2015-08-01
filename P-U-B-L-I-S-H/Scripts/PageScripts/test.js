$(document).ready(function () {

});

$.ajax({
    type: "POST",
    url: "",
    contentType: "application/json",
    dataType: "json",
    data: JSON.stringify({
        first_name: $("#namec").val(),
        last_name: $("#surnamec").val(),
        email: $("#emailc").val(),
        mobile: $("#numberc").val(),
        password: $("#passwordc").val()
    }),
    success: function (response) {
        console.log(response);
    },
    error: function (response) {
        console.log(response);
    }
});