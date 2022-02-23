function replaceAll(string, substr, newstr) {
    var strReplaceAll = string;

    while (strReplaceAll.indexOf(substr) != -1) {
        strReplaceAll = strReplaceAll.replace(substr, newstr)
    }

    return strReplaceAll;
}

function repeat(string, count) {
    return new Array(count + 1).join(string);
}

function addCharToLeft(string, char, count) {
    return completeStringWith(string, char, count, 'left');
}

function addCharToRight(string, char, count) {
    return completeStringWith(string, char, count, 'right');
}

function completeStringWith(string, char, count, side) {
    if (side == 'left') {
        return repeat(string, count).concat(string);
    }
    else if (side == 'right') {
        return string.concat(char.repeat(string, count));
    }

    return string;
}

function left(string, count) {
    return string.substring(0, count);
}

function right(string, count) {
    return string.substring(string.length - count);
}

function trim(string) {
    return string.replace(/^\s+|\s+$/g, '');
}

function ltrim(string) {
    return string.replace(/^\s+/, '');
}

function rtrim(string) {
    return string.replace(/\s+$/, '');
}

function isEmpty(string) {
    return string == undefined || string == '';
}