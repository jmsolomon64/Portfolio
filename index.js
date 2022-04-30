const cvs = document.getElementById("myCanvas");
const context = cvs.getContext("2d");
let divider = 0.1; 
let color =  "Lavender"; //color of the circles in animation
let rotateAngle = .005;

cvs.width = cvs.height = 800 //sets both width and heigthth to 800
cvs.style.display = "block";
cvs.style.margin = "0 auto";


function circle(radius, distanceFromCenter, angle) { //this function takes three parameters to draw a circle
    let x = cvs.width/2 + distanceFromCenter * Math.sin(angle);
    let y = cvs.height / 2 + distanceFromCenter * Math.cos(angle);

    context.beginPath();
    context.arc(x, y, radius, 0, 2 * Math.PI);
    context.stroke();
    context.strokeStyle = color;
    context.closePath();

    if(angle > 2*Math.PI) return;

    circle(200, 200, angle + Math.PI/divider);
}

function main() {
    context.clearRect(0, 0, cvs.width, cvs.height); //clears the canvas at start of main function
    circle(200, 0, 0); //invokes circle function with arguements
    if(divider < 11.9)
        divider += 0.1; //incriments divider by 0.1 everytime this code is ran
    requestAnimationFrame(main);
}

function rotate() {
    let centerX = cvs.width / 2;
    let centerY = cvs.height / 2;
    context.translate(centerX, centerY);
    context.rotate(rotateAngle);
}



main();

