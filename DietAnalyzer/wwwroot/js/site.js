
function addNewRow(urlString, tableId) {
    let rowIndex = $(tableId + ">tbody>tr").length;
    $.ajax({
        url: urlString + rowIndex,
        success: function (data) {
            $(tableId + '>tbody').append(data);
        },
        error: function (result) {
            console.log("addNewRow - error: " + result);
            //JL().fatal("addNewRow - error: " + result);
        }
    });
}

// there probably exists a better way to do that... I'm just not very good at JS
function deleteRowUpdateHTML(button, stringCode, tableId) {
    let row = button.parentNode.parentNode;
    let rowIndex = row.rowIndex;
    row.remove();
    let table = document.getElementById(tableId);
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