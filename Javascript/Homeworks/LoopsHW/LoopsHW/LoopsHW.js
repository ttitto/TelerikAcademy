/// <reference path="js-console.js" />

function Print1toN(n) {
    var indx;
    for (indx = 1; indx <= n; indx++) {
        jsConsole.write(indx + " ");
    }
}
jsConsole.writeLine("Task1: ");
Print1toN(5)
jsConsole.writeLine();

function PrintDivisibleBy3And7(n) {
    var indx;
    for (indx = 1; indx <= n; indx++) {
        if (indx % 3 != 0 || indx % 7 != 0) {
            jsConsole.write(indx + " ");
        }
    }
}
jsConsole.writeLine("Task2: ");
PrintDivisibleBy3And7(25);
jsConsole.writeLine();

var nums = new Array(2, 4, 69, 11, 62);
function findMinMax(numbers) {

    var min = numbers[0];
    var max = numbers[0];
    for (var i in numbers) {
        if (numbers[i] > max) {
            max = numbers[i];
        }
        if (numbers[i] < min) {
            min = numbers[i];
        }
    }
    jsConsole.writeLine("Min: " + min);
    jsConsole.writeLine("Max: " + max);
}
jsConsole.writeLine("Task3: ");
findMinMax(nums);
