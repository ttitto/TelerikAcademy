/// <reference path="js-console.js" />
jsConsole.writeLine("Task1:");
function oddEven() {
    var firstNum = 8;
    var secNum = 15;
    var thirdNum = 0;
    var negNum = -36;
    var isEven = (firstNum % 2) === 0;
    jsConsole.writeLine(isEven);
    var isEven = (secNum % 2) === 0;
    jsConsole.writeLine(isEven);
    var isEven = (thirdNum % 2) === 0;
    jsConsole.writeLine(isEven);
    var isEven = (negNum % 2) === 0;
    jsConsole.writeLine(isEven);
}
oddEven();

function dividedBy7and5(num) {
    var CanBeDivided = (num % 7 == 0 && num % 5 == 0);
    jsConsole.writeLine(CanBeDivided);
}
jsConsole.writeLine();
jsConsole.writeLine("Task2: ");
dividedBy7and5(8);
dividedBy7and5(35);
dividedBy7and5(42);
dividedBy7and5(0);
dividedBy7and5(-36);

function rectArea(width, height) {
    var area = width * height;
    jsConsole.writeLine(area);
}
jsConsole.writeLine();
jsConsole.writeLine("Task3: ");
rectArea(3.4, 6);
rectArea(4, 34);

function thirdDigit(num) {
    var isThirdDigit7 = (Math.floor(num / 100) % 10) == 7;
    jsConsole.writeLine(isThirdDigit7);
}
jsConsole.writeLine();
jsConsole.writeLine("Task4: ");
thirdDigit(1723);
thirdDigit(123754);
thirdDigit(32536574);

function thirdBit(num) {
    var isThirdBit1 = ((1 << 2) & num) >> 2 == 1;
    jsConsole.writeLine(isThirdBit1);
}
jsConsole.writeLine();
jsConsole.writeLine("Task5: ");
thirdBit(4);
thirdBit(8);
thirdBit(534);

function insideCircle(x, y) {
    var isInsideCircle = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2)) <= 5;
    jsConsole.writeLine(isInsideCircle);
}
jsConsole.writeLine();
jsConsole.writeLine("Task6: ");
insideCircle(3.5, 3.5);
insideCircle(2, 5);
insideCircle(4, 3);
insideCircle(4, 4);

function isPrimeNumber(myInt) {
    var isPrime = (myInt <= 2 ? true : myInt % 2 !== 0) &&
                (myInt <= 3 ? true : myInt % 3 !== 0) &&
                (myInt <= 4 ? true : myInt % 4 !== 0) &&
                (myInt <= 5 ? true : myInt % 5 !== 0) &&
                (myInt <= 6 ? true : myInt % 6 !== 0) &&
                (myInt <= 7 ? true : myInt % 7 !== 0) &&
                (myInt <= 8 ? true : myInt % 8 !== 0) &&
                (myInt <= 9 ? true : myInt % 9 !== 0) &&
                (myInt <= 10 ? true : myInt % 10 !== 0);
    jsConsole.writeLine(isPrime);
}
jsConsole.writeLine();
jsConsole.writeLine("Task7: ");
isPrimeNumber(37);
isPrimeNumber(11);
isPrimeNumber(13);
isPrimeNumber(15);
isPrimeNumber(39);
isPrimeNumber(21);

function trapezoidArea(sideA, sideB, height) {
    var area = (sideA + sideB) * height / 2;
    jsConsole.writeLine(area);
}
jsConsole.writeLine();
jsConsole.writeLine("Task8: ");
trapezoidArea(4, 5, 6.7);

function InsideCircleOutsideRectangle(x, y) {
    var isInsideCircle = Math.sqrt(Math.pow(x - 1, 2) + Math.pow(y - 1, 2)) <= 3;
    var isOutsideRectangle = (x < -1 & x > 5) & (y < -1 & y > 1);
    var InsideOutside = ((x > -1 && x < 5) && (y > -1 && y < 1))==false && (Math.sqrt(Math.pow(x - 1, 2) + Math.pow(y - 1, 2)) <= 3);
    jsConsole.writeLine(InsideOutside);
}
jsConsole.writeLine();
jsConsole.writeLine("Task9: ");
InsideCircleOutsideRectangle(2, 3.8);