$(function () {

    var createForm = $("#createForm");
    $(createForm).submit(function (e) { //listen for submit event
        e.preventDefault();
        var json = formSubmitHandler($(this));
        if (json.success) {
            displaySuccessMessage(createForm, "Successfully Created.");
            ReligionDT.draw();
            setTimeout(function () {
                $('#GenericModal').modal('hide');
            }, 2000);
        }
        else if (json.error) {
            displayErrorMessage(createForm, json.error);
        }
    });

});


