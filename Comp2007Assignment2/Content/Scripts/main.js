var hdfDdl = null; // Save city dropdownlist selected option
var ddlCity = null;

// Restore the selected option in city dropdownlist when page is rendering
window.onload = function () {
    hdfDdl = document.getElementById('hdfDdlCitySelectIndex');
    ddlCity = document.getElementById('ddlCity');
    ddlCity.selectedIndex = hdfDdl.value;
    EnableOrDisableButton(false);
}

// Save city dropdownlist selected option when selected option is changed in city dropdownlist
function onChange() {
    hdfDdl.value = ddlCity.selectedIndex;
}

// Enable or diasble submit button
function EnableOrDisableButton(ToF) {
    document.getElementById('btnSubmit').disabled = ToF;
}