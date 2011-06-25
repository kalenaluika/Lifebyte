// UI Hints in MVC change the name of the input field.
// Instead of "State" it's "State_StateDropdownList".
// So, I'm using jQuery to change the name and ID back to just "State" so that
// default model binding works.
// I'm also using jQuery to select the option from the model.
// If I find a way in MVC, I will remove this HACK.
function choose(dropdownListId, id, selectedValue) {
    $("#" + dropdownListId)
        .attr("name", id)
        .attr("id", id)
        .val(selectedValue);
}