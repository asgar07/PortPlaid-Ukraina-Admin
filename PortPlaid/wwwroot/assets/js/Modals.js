// Get the modal
var modal = document.getElementById("ConfirmModal");

// Get the button that opens the modal
var btn = document.getElementById("confirmbutton");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("confirmclose")[0];

// When the user clicks the button, open the modal 
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}







// Get the modal
var modal = document.getElementById("ProblemModal");

// Get the button that opens the modal
var btn = document.getElementById("ProblemOpenModal");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("problemclose")[0];

// When the user clicks the button, open the modal
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}