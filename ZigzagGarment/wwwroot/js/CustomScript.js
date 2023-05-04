function confirmDelete(isDeleteClicked) {
    var deleteSpan = 'deleteSpan_';
    var confirmDeleteSpan = 'confirmDeleteSpan_';

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}