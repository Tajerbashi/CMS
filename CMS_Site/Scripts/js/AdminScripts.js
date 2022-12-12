$("#open-model").click(() => {
    console.log("Create-Page");

});
$("#Personal").click(() => {
    $("#show-data").addClass("d-none");
});
$("#Group").click((event) => {
    event.preventDefault();
    $("#show-data").removeClass("d-none");
    $("#tHead").html("<tr><th>Groups</th><th>Remotes</th></tr>");

});
$("#Page").click(() => {
    $("#show-data").removeClass("d-none");
});
$("#Comment").click(() => {
    $("#show-data").removeClass("d-none");
});

$("#Open-Modal").click(function () {
    console.log("Click Modla");
    $("#myModal").addClass("show").addClass("d-block");
});
