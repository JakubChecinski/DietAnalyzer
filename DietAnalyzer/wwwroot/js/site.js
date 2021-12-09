
function addNewRow(urlString, tableId) {
    let rowIndex = $(('#' + tableId + '>tbody>tr')).length;
    $.ajax({
        url: urlString + rowIndex,
        success: function (data) {
            $(('#' + tableId + '>tbody')).append(data);
        },
        error: function (result) {
            console.log("addNewRow - error: " + result);
            //JL().fatal("addNewRow - error: " + result);
        }
    });
}

// there probably exists a better way to do that... I'm just not very good at JS
function deleteRowUpdateHTML(button, stringCode, tableId) {
    let rowToRemove = button.parentNode.parentNode;
    let removedCode = extractCodeValue(stringCode, rowToRemove.innerHTML);
    rowToRemove.remove();
    let table = document.getElementById(tableId);
    for (let i = 0, tableRow; tableRow = table.rows[i]; i++) {
        tableRow.innerHTML = decrementStringPartsAfterCode(stringCode, tableRow.innerHTML, removedCode);
    }
}

function extractCodeValue(code, str) {
    let regex = new RegExp(code, "g"), result, indices = [];
    while ((result = regex.exec(str)) && indices.length == 0) {
        indices.push(result.index);
    }
    return parseInt(str.substr(indices[0] + code.length + 1));
}

function decrementStringPartsAfterCode(code, str, rowIndex) {
    let regex = new RegExp(code , "g"), result, indices = [];
    while ((result = regex.exec(str))) {
        indices.push(result.index);
    }
    // -1 because the last index is for delete button
    for (let i = 0; i < indices.length - 1; i++) {
        if (indices[i] < str.length - code.length - 1) {
            let currentNumber = parseInt(str.substr(indices[i] + code.length + 1));
            if (currentNumber < rowIndex) continue;
            let lengthOfCurrentNumber = currentNumber.toString().length;
            str = replaceAt(str, indices[i] + code.length + 1, lengthOfCurrentNumber, currentNumber - 1);
        }
    }
    return str;
}

function replaceAt(str, index, length, newSubStr) {
    return str.substring(0, index) + newSubStr + str.substring(index + length);
}