 var timer= setInterval(message(), 7000);

function reload() {
    timer
    window.location.reload(true);
}
function message(){
    alert('some seconds passed!');
}
