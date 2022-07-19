var expanded = false;

function showCheckboxes(thisElement) {
    var parentGetElement = thisElement.parentElement;
    if (parentGetElement !== null) {
        var checkboxes = parentGetElement.querySelector(".checkboxes");


        if (!expanded) {
            checkboxes.style.display = "block";
            expanded = true;
        } else {
            checkboxes.style.display = "none";
            expanded = false;
        }

    }

}