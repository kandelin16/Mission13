// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function expandRow(id) {
    document.getElementById("hiddenRow" + id).hidden = false;
}

function collapseRow(id) {
    document.getElementById("hiddenRow" + id).hidden = true;
}

function submitUpdateForm(id) {
    document.getElementById("bowlerUpdateForm" + id).submit();
}

function revealBowlerForm() {
    document.getElementById("bowlerForm").hidden = false;
}

function hideBowlerForm() {
    document.getElementById("bowlerForm").hidden = true;
}