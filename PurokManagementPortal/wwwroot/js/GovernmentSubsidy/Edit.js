$(function () {

    var editForm = $("#editForm");
    $(editForm).submit(function (e) { //listen for submit event
        e.preventDefault();
        var json = formSubmitHandler($(this));
        if (json.success) {
            displaySuccessMessage(editForm, "Successfully Update.");
            SubsidyDT.draw();
            setTimeout(function () {
                $('#GenericModal').modal('hide');
            }, 2000);
        }
        else if (json.error) {
            displayErrorMessage(editForm, json.error);
        }
    });

});


