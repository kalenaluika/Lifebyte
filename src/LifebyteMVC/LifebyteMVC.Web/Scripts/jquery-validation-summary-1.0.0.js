/*
Modifies the MVC Validation Summary Errors control to use jQuery UI error styles.
Each error will have the icon defined in the jQuery UI stylesheet.
*/

(function ($) {
    $(document).ready(function () {
        $(".validation-summary-errors")
            .addClass("ui-state-error ui-corner-all")
            .hide()
            .slideDown("slow");

        $(".validation-summary-errors ul li")
            .prepend("<span class=\"ui-icon ui-icon-alert\" style=\"float:left; margin: 8px 5px 0 0;\"></span>");

        $(".field-validation-error").addClass("ui-state-error");

        $(".input-validation-error").addClass("ui-state-error");
    });
})(jQuery);
