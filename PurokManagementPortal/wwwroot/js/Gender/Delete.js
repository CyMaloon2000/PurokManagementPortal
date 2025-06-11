$(function () {

    var deleteForm = $("#deleteForm");
    $(deleteForm).submit(function (e) { //listen for submit event
        e.preventDefault();
        var json = formSubmitHandler($(this));
        if (json.success) {
            displaySuccessMessage(deleteForm, "Successfully Deleted.");
            GenderDT.draw();
            setTimeout(function () {
                $('#GenericModal').modal('hide');
            }, 2000);
        }
        else if (json.error) {
            displayErrorMessage(deleteForm, json.error);
        }
    });

});


