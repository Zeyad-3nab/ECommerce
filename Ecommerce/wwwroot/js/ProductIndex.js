// Get the modal
var modal = document.getElementById("deleteModal");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// Get the confirmation and cancel buttons
var confirmDelete = document.getElementById("confirmDelete");
var cancelDelete = document.getElementById("cancelDelete");

// Variable to store the doctor id to delete
var doctorIdToDelete = null;

// When the user clicks on a delete button, open the modal
document.querySelectorAll('.delete-button').forEach(button => {
    button.addEventListener('click', function () {
        doctorIdToDelete = this.getAttribute('data-product-id');
        modal.style.display = "block";
    });
});

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks on "No", close the modal
cancelDelete.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks on "Yes", delete the doctor and close the modal
confirmDelete.onclick = function () {
    window.location.href = "/product/Delete?id=" + doctorIdToDelete;
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
