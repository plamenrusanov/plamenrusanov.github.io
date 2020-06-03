var dropdown = document.getElementsByClassName("dropdown-btn");
var i;

for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var dropdownContent = document.getElementsByClassName("dropdown-container");
        if (dropdownContent[0].style.display === "block") {
            dropdownContent[0].style.display = "none";
        } else {
            dropdownContent[0].style.display = "block";
        }
    });
}