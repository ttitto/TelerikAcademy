/// <reference path="js-console.js" />
function ExchangeSmaller(first, second) {
    if (first > second) {
        var temp = first;
        first = second;
        second = temp;
    }
    jsConsole.writeLine("The smaller number is: " + first);
}
jsConsole.writeLine("Task1: ");
ExchangeSmaller(43, 34);
ExchangeSmaller(-54, -32);
jsConsole.writeLine();

function ProductSign(first, second, third) {
    var negativeCount = 0;
    if (first < 0) {
        negativeCount++;
    }
    if (second < 0) {
        negativeCount++;
    }
    if (third < 0) {
        negativeCount++;
    }
    if (negativeCount % 2 == 0) {
        jsConsole.writeLine("The sign of the product is '+'");
    }
    else {
        jsConsole.writeLine("The sign of the product is '-'");
    }
}
jsConsole.writeLine("Task2: ");
ProductSign(-12, 23, -45);
ProductSign(-12, -23, -45);
ProductSign(12, -23, -45);
ProductSign(12, 23, 45);
jsConsole.writeLine();

function biggestOfThree(first, second, third) {
    if (first < second) {
        if (second < third) {
            jsConsole.writeLine("The biggest is " + third);
        }
        else {
            jsConsole.writeLine("The biggest is " + second);
        }
    }
    else if (first > second) {
        if (first > third) {
            jsConsole.writeLine("The biggest is " + first);
        }
        else {
            jsConsole.writeLine("The biggest is " + third);
        }
    }
}
jsConsole.writeLine("Task3: ");
biggestOfThree(45, 65, 87);
biggestOfThree(45, 98, 87);
biggestOfThree(45, 65, -87);
biggestOfThree(128, 65, 87);
jsConsole.writeLine();

function sortThreeNumbers(first, second, third) {
    if (first < second) {
        //swap
        first += second;
        second = first - second;
        first = first - second;
    }
    if (second < third) {
        //swap
        third += second;
        second = third - second;
        third = third - second;
    }
    if (first < second) {
        //swap
        first += second;
        second = first - second;
        first = first - second;
    }
    jsConsole.writeLine(first + ">" + second + ">" + third);
}
jsConsole.writeLine("Task4: ");
sortThreeNumbers(34, 32, 56);
sortThreeNumbers(45, 65, 87);
sortThreeNumbers(45, 98, 87);
sortThreeNumbers(45, 65, -87);
sortThreeNumbers(128, 65, 87);
jsConsole.writeLine();

function digitsWithWords(digit) {
    switch (digit) {
        case 1:
            jsConsole.writeLine("one");
            break;
        case 2:
            jsConsole.writeLine("two");
            break;
        case 3:
            jsConsole.writeLine("three");
            break;
        case 4:
            jsConsole.writeLine("four");
            break;
        case 5:
            jsConsole.writeLine("five");
            break;
        case 6:
            jsConsole.writeLine("six");
            break;
        case 7:
            jsConsole.writeLine("seven");
            break;
        case 8:
            jsConsole.writeLine("eight");
            break;
        case 9:
            jsConsole.writeLine("nine");
            break;
        case 0:
            jsConsole.writeLine("zero");
            break;

        default: jsConsole.writeLine("Invalid digit!");
            break;
    }
}
jsConsole.writeLine("Task5: ");
digitsWithWords(9);
digitsWithWords(1);
digitsWithWords(6);
digitsWithWords(3);
jsConsole.writeLine();

function quadraticEquation(a, b, c) {
    var root1 = (-b + Math.sqrt(b * b - 4 * a * c)) / (2 * a);
    var root2 = (-b - Math.sqrt(b * b - 4 * a * c)) / (2 * a);

    jsConsole.writeLine("The solution is: " + root1 + "," + root2);
}
jsConsole.writeLine("Task6: ");
quadraticEquation(2, 4, -4);
quadraticEquation(3, 4, -4);
quadraticEquation(4, 2, 4);
quadraticEquation(8, 4, 4);
jsConsole.writeLine();

function maxOfFive(first, second, third, fourth, fifth) {
    var max = first;

    if (second > max) {
        max = second;
    }
    if (third > max) {
        max = third;
    }
    if (fourth > max) {
        max = fourth;
    }
    if (fifth > max) {
        max = fifth;
    }
    jsConsole.writeLine(max);
}

jsConsole.writeLine("Task7: ");
maxOfFive(2, 8, 34, 23, 12);
maxOfFive(2, 8, 34, 323, 12);
maxOfFive(2, 8, -34, 23, 12);
jsConsole.writeLine();

function convertNumber(input) {

    var result = "";

    // if number is negative
    if (input < 0) {
        input = input * (-1);
    }
    if (input > 999) {
        jsConsole.writeLine("Enter a number between 0 and 999!");
    }

    if (input >= 0 && input <= 19) {
        GetDigits(input);
        jsConsole.writeLine(result);
    }
    else if (input > 19 && input <= 99) {
        var firstDigit = GetTens(input);
        var secondDigit = GetDigits(input);
        if (secondDigit == "zero") {
            jsConsole.writeLine(firstDigit);
        }
        else {
            jsConsole.writeLine(firstDigit + " " + secondDigit);
        }
    }
    else if (input > 99 && input <= 999) {
        var firstDigit = Gethundreds(input);
        var secondDigit = GetTens(input);
        var thirtDigit = GetDigits(input);
        if (thirtDigit == "zero") {
            if (secondDigit == "") {
                jsConsole.writeLine(firstDigit);
            }
            else {
                jsConsole.writeLine(firstDigit + " and " + secondDigit);
            }

        }
        else {
            jsConsole.writeLine(firstDigit + " and " + secondDigit + " " + thirtDigit);
        }
    }

    function GetDigits(digits) {
        digits = digits % 10;
        switch (digits) {
            case 0: result = "zero"; break;
            case 1: result = "one"; break;
            case 2: result = "two"; break;
            case 3: result = "three"; break;
            case 4: result = "four"; break;
            case 5: result = "five"; break;
            case 6: result = "six"; break;
            case 7: result = "seven"; break;
            case 8: result = "eight"; break;
            case 9: result = "nine"; break;
            case 10: result = "ten"; break;
            case 11: result = "eleven"; break;
            case 12: result = "twelve"; break;
            case 13: result = "thirteen"; break;
            case 14: result = "fourteen"; break;
            case 15: result = "fifteen"; break;
            case 16: result = "sixteen"; break;
            case 17: result = "seventeen"; break;
            case 18: result = "eighteen"; break;
            case 19: result = "nineteen"; break;
            default:
        }
        return result;
    }

    function GetTens(digits) {
        digits = Math.floor(digits / 10);
        if (digits >= 10) {
            digits = digits % 10;
        }
        switch (digits) {
            case 0: result = ""; break;
            case 2: result = "twenty"; break;
            case 3: result = "thirty"; break;
            case 4: result = "fourty"; break;
            case 5: result = "fifty"; break;
            case 6: result = "sixty"; break;
            case 7: result = "seventy"; break;
            case 8: result = "eighty"; break;
            case 9: result = "ninety"; break;
            default:
        }
        return result;
    }

    function Gethundreds(digits) {
        digits = Math.floor(digits / 100);
        switch (digits) {
            case 1: result = "one hundred"; break;
            case 2: result = "two hundred"; break;
            case 3: result = "three hundred"; break;
            case 4: result = "four hundred"; break;
            case 5: result = "five hundred"; break;
            case 6: result = "six hundred"; break;
            case 7: result = "seven hundred"; break;
            case 8: result = "eight hundred"; break;
            case 9: result = "nine hundred"; break;
            default:
        }
        return result;
    }
}
jsConsole.writeLine("Task8: ");
convertNumber(123);
convertNumber(1000);
convertNumber(799);
convertNumber(23);
jsConsole.writeLine();