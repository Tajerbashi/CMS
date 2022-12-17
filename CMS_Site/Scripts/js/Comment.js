var capshapRef = document.getElementById("refresh");
var capchapShow = document.getElementById("capchapShow");
var capchapInput = document.getElementById("capchapInput");

var submit = document.getElementById("submit");

var name = document.getElementById("name");
var email = document.getElementById("email");
var comment = document.getElementById("comment");

function newCode() {
    var code = Math.round(Math.random() * 100000);
    capchapShow.setAttribute("placeholder", code);
}

newCode();

capshapRef.addEventListener("click", () => {
    newCode();
});

function addComment(id) {
    $.ajax({
        url: "/News/AddComment/" + id,
        type: "GET",
        data: { name: $("#name").val(), email: $("#email").val(), comment: $("#comment").val() }
    }).done(function (res) {
        $("#CommentList").html(res);
        $("#name").val("");
        $("#email").val("");
        $("#comment").val("");
        $("#capchapInput").val("");
        newCode();
});
}

submit.addEventListener('click', () => {
    console.log($("#name").val());
    console.log($("#email").val());
    console.log($("#comment").val());
    var id = $("#PageID").val();
    addComment(id);
});