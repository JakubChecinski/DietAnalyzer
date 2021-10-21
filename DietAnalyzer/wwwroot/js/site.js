function addNewRow(urlString) {
    let rowIndex = $("#Table>tbody>tr").length;
    $.ajax({
        url: urlString + rowIndex,
        success: function (data) {
            $('#Table > tbody').append(data);
        },
        error: function (result) {
            JL().fatal("addNewRow - error: " + result);
        }
    });
}


// there probably exists a better way to do that... I'm just not very good at JS
function deleteRowUpdateHTML(button, stringCode) {
    let row = button.parentNode.parentNode;
    let rowIndex = row.rowIndex;
    row.remove();
    let table = document.getElementById("Table");
    for (let i = rowIndex, tableRow; tableRow = table.rows[i]; i++) {
        tableRow.innerHTML = incrementStringPartsAfterCode(stringCode, tableRow.innerHTML, tableRow.rowIndex);
    }
}

function incrementStringPartsAfterCode(code, str, rowIndex) {
    let regex = new RegExp(code , "g"), result, indices = [];
    while ((result = regex.exec(str))) {
        indices.push(result.index);
    }
    // -1 because the last index is for delete button
    for (let i = 0; i < indices.length - 1; i++) {
        if (indices[i] < str.length - code.length - 1) {
            str = replaceAt(str, indices[i] + code.length + 1, rowIndex);
        }
    }
    return str;
}

function replaceAt(str, index, newSubStr) {
    return str.substring(0, index) + newSubStr + str.substring(index + 1);
}