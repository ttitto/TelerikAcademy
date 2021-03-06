﻿/// <reference path="js-console.js" />
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

function findMaximalSequence(arr) {
    var num = arr[0];
    var cnt = 1;
    var maxCnt = 1;
    var indx, i, maxNum;
    for (indx = 1; indx < arr.length; indx++) {
        if (num === arr[indx]) {
            cnt++;
        } else {
            num = arr[indx];
            cnt = 1;
        }
        if (cnt > maxCnt) {
            maxCnt = cnt;
            maxNum = num;
        }
    }
    jsConsole.write("The longest sequence is: ");
    for (i = 0; i < maxCnt; i++) {
        jsConsole.write(maxNum + " ");
    }
    jsConsole.writeLine();
}
jsConsole.writeLine("Task3: ");
var arr1 = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
var arr2 = [2, 1, 1, 2, 3, 3, 3, 3, 2, 2, 2, 1];
findMaximalSequence(arr1);
findMaximalSequence(arr2);

