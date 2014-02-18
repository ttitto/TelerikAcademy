/// <reference path="js-console.js" />
function multipliedBy5() {
    var arr = new Array(20);
    var i;
    for (i = 0; i < arr.length; i++) {
        arr[i] = i * 5;
        jsConsole.write(arr[i] + " ");
    }
}
jsConsole.writeLine("Task1: ");
multipliedBy5();
jsConsole.writeLine();

function compareCharArrays(first, second) {
    var len = first.length;
    var indx;
    if (first.length > second.length) {
        jsConsole.writeLine("The second array is lexicographically earlier.");
    } else if (first.length < second.length) {
        jsConsole.writeLine("The first array is lexicographically earlier.");
    } else {
        for (indx = 0; indx < len; indx++) {
            if (first[indx] > second[indx]) {
                jsConsole.writeLine("The second array is lexicographically earlier.");
                return;
            } else if (first[indx] < second[indx]) {
                jsConsole.writeLine("The first array is lexicographically earlier.");
                return;
            }
        }
        jsConsole.writeLine("Both arrays are equal.");
    }
}
jsConsole.writeLine("Task2: ");
var arr1 = new Array('a', 'v', 'f', 'g', 'r');
var arr2 = new Array('a', 'v', 'f', 'g', 'r');
var arr3 = new Array('a', 'g', 'v', 'f', 'r');

compareCharArrays(arr1, arr2);
compareCharArrays(arr1, arr3);
compareCharArrays(arr3, arr2);