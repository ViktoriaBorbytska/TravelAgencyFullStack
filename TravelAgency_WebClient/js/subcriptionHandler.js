$(document).ready(function () {
    $('.subscription-button').click(submitSubcriptionForm);
});

function getEmail(){
    return $('.subscription-form').serializeArray()[0].value;
}

function createPopupContent(result) {
    $("#subscription-dialog .ajax-loader").remove();
    generateContainer("<h4>", "", result.isSuccessful ? "Horray!" : "Sorry").appendTo($("#subscription-dialog"));
    generateContainer("<p>", "", result.message).appendTo($("#subscription-dialog"));
}

function emptyDialog(){
    $("#subscription-dialog h4").remove();
    $("#subscription-dialog p").remove();
}

function submitSubcriptionForm(event) {
    event.preventDefault();
    let email = getEmail();
    console.log(email);
    emptyDialog();
    generateImg("images\\loader.gif", "loader", "ajax-loader").appendTo($("#subscription-dialog"));
    fetch(config.apiDomain + "/api/subscription/add", {
        method: "post",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(email)
    })
        .then(res => res.json())
        .then(res => {
            createPopupContent(res);
        })
        .catch(() => {
            createPopupContent({ isSuccessful: false, message: "Could not connect to the server." });
        });
}