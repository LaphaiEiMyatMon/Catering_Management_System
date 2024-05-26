// Delete Confirmation
window.deleteConfirm = function (event, deleteUrl) {
    event.preventDefault();

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            
            Swal.fire({             
                icon: "success",
                title: "Successfully Deleted!",
                showConfirmButton: false,
                timer: 1000
            });
            setTimeout(function () {
                // Submit the form after the confirmation
                window.location.href = deleteUrl;
            }, 1000);
        }
    });
};




// Document ready
$(document).ready(function () {
    // Save Confirmation
    $('#Save').on('click', function (event) {
        var form = $('#CreateForm')[0]; // Get the form element
        if (form.checkValidity()) { // Check HTML validation
            event.preventDefault(); // Prevent default behavior
            Swal.fire({
                title: "Do you want to save?",
                showDenyButton: false,
                showCancelButton: true,
                confirmButtonText: "Save",
                denyButtonText: `Don't save`
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire({
                        icon: "success",
                        title: "Successfully Saved!",
                        showConfirmButton: false,
                    });

                    setTimeout(function () {
                        // Submit the form after the confirmation
                        $('#CreateForm').submit();
                    }, 1000);
                } else if (result.isDenied) {
                    Swal.fire("Not saved", "", "info");
                }
            });
        }
    });

    // Update Confirmation
    $('#Update').on('click', function (event) {
        var form = $('#EditForm')[0]; // Get the form element
        if (form.checkValidity()) { // Check HTML validation
            event.preventDefault(); // Prevent default behavior
            Swal.fire({
                title: "Do you want to save the changes?",
                showDenyButton: true,
                showCancelButton: true,
                confirmButtonText: "Save",
                denyButtonText: `Don't save`
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire({
                        icon: "success",
                        title: "Successfully Updated!",
                        showConfirmButton: false,
                        timer: 1500
                    });
                    setTimeout(function () {
                        // Submit the form after the confirmation
                        $('#EditForm').submit();
                    }, 1000);
                } else if (result.isDenied) {
                    Swal.fire("Changes are not saved", "", "info");
                }
            });
        }
    });

});