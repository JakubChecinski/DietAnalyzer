function addNewRow(urlString) {
    var rowIndex = $("#Table>tbody>tr").length;
    $.ajax({
        url: urlString + rowIndex,
        success: function (data) {
            $('#Table > tbody').append(data);
        },
        error: function (a, b, c) {
            console.log(a, b, c);
        }
    });
}


// there probably exists a better way to do that... I'm just not very good at JS
function deleteRowUpdateHTML(button, stringCode) {
    var row = button.parentNode.parentNode;
    var rowIndex = row.rowIndex;
    document.getElementById("PositionsToDelete").value =
        document.getElementById("PositionsToDelete").value.concat(row.rowIndex, ",");
    row.remove();
    var table = document.getElementById("Table");
    for (var i = 0, tableRow; tableRow = table.rows[i]; i++) {
        tableRow.innerHTML = incrementStringPartsAfterCode(stringCode, tableRow.innerHTML, tableRow.rowIndex);
    }
}

function incrementStringPartsAfterCode(code, str, rowIndex) {
    var regex = new RegExp(code , "g"), result, indices = [];
    while ((result = regex.exec(str))) {
        indices.push(result.index);
    }
    for (var i = 0; i < indices.length; i++) {
        if (indices[i] < str.length - code.length - 1) {
            str = replaceAt(str, indices[i] + code.length + 1, rowIndex);
        }
    }
    return str;
}

function replaceAt(str, index, newSubStr) {
    return str.substring(0, index) + newSubStr + str.substring(index + 1);
}