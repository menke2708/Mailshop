
var divxPos = 0;
window.onload = function () {
    runCode();
};
function runCode() {
    var test = document.getElementById("testElement");
    test.style.left = divxPos++ + 'px';
    setTimeout(() => runCode(), 50);
};