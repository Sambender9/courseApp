

var deleteCourse = function(id){
    $.ajax({
        url: "api/Courses/" + id,
        type: "DELETE"
    }).done(redraw());

}

var redraw = function ()
{
    $.getJSON("/api/Courses", function (data) {
        loopThrough(data);
    });
};

var loopThrough = function (data) {
    document.getElementById("tableBody").innerHTML = " ";
    for (var i in data) {
        var andre = "<tr><td>"
                    + data[i].Name
                    + "</td>"
                    + '<td><button type="button" class="btn btn-danger" onclick="deleteCourse('
                    + data[i].Id
                    + ')">Delete</button> '
                    + "</td></tr>";
       document.getElementById("tableBody").innerHTML += andre;
    };
    
}

redraw();

var create = function () {
    var button = document.getElementById("create");
    var data = document.getElementById("Name").value;

    $.ajax({
        url: "api/Courses",
        type: "POST",
        data: data
    }).done(redraw());
};


