"use strict";

window.addEventListener("scroll", function(){
    let scrollPosition = window.pageYOffset;

    if (scrollPosition > 1000) {
        document.getElementById("up").style.opacity = 1;
        document.getElementById("up").style.pointerEvents = "unset";
    }
    else{
        document.getElementById("up").style.opacity = 0;
        document.getElementById("up").style.pointerEvents = "none";
    }
})

document.getElementById("up").addEventListener("click", function(){
    window.scrollTo({top:0, behavior:"smooth"});
})