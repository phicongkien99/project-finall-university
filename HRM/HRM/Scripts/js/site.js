// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// This function format DateTime(yyyy-MM-dd T HH:MM:SS) to Date(dd/MM/yyyy)
const formatDateTimeToDate = function (dateTime) {
    try {
        if (dateTime != '0001-01-01T00:00:00') {
            var date = new Date(dateTime);
            return date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear();
        }
        else {
            return '';
        }
    }
    catch {
        return '';
    }
}

// Check valid email
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

// Check message
function isMessageSuccess(data) {
    if (data.ErrorCode == 0) {
        return toastr.success(data.ErrorMessage);
    }
    return toastr.error(data.ErrorMessage);
}
