
var stdInput = document.getElementById("StdId");
var coursesArea = document.getElementById("coursesArea");
var crsInput = document.getElementById("CrsId");
var gradeArea = document.getElementById("gradeArea");



stdInput.addEventListener("change", async () => {
    var coursesResult = await fetch("http://localhost:5118/stdcrs/EditStdGrade_std/" + stdInput.value)
    courseList = await coursesResult.text();
    console.log(courseList);
    console.log(crsInput);

    coursesArea.innerHTML = courseList;
    crsInput = document.getElementById("CrsId");
    gradeArea = document.getElementById("gradeArea");
    crsInput.addEventListener("change", async () => {
        var gradeResult = await fetch("http://localhost:5118/stdcrs/EditStdGrade_stdCrs/" + stdInput.value + "?crsId=" + crsInput.value);
        grade = await gradeResult.text();
        gradeArea.innerHTML = grade;
    });
});