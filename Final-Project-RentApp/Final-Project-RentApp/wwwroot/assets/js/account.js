"use strict";

// let userIcon = document.querySelector("#navbar .icons :nth-child(3)");

// userIcon.addEventListener("mouseover", function () {

//   document.querySelector(".login-register").classList.remove("d-none");

//   let regDiv = document.querySelector(".login-register");

//   regDiv.addEventListener("mouseover", function () {

//     this.classList.remove("d-none");

//   });

// });


// userIcon.addEventListener("mouseout", function () {

//   document.querySelector(".login-register").classList.add("d-none");

//   let regDiv = document.querySelector(".login-register");

//   regDiv.addEventListener("mouseout", function () {

//     this.classList.add("d-none");

//   });

// })



let userIcon = document.querySelector("#navbar .icons .user");

userIcon.addEventListener("click", function () {

  let regDiv = document.querySelector(".login-register");

  if (regDiv.classList.contains("d-none")) {

    regDiv.classList.remove("d-none");
  }
  else {
    regDiv.classList.add("d-none");
  }

});


let searchIcon = document.querySelector("#navbar .search .open-close");

searchIcon.addEventListener("click", function () {
  

  if (document.querySelector("#navbar .search .search-input").style.opacity == 0) {
    document.querySelector("#navbar .search .search-input").style.opacity = 1;
    document.querySelector("#navbar .search .search-input").style.pointerEvents = "unset";
    
  }else{
    document.querySelector("#navbar .search .search-input").style.opacity = 0;
    document.querySelector("#navbar .search .search-input").style.pointerEvents = "none";
  }


})

document.addEventListener("click", function (event) {
  let target = event.target;
  let searchInputParent = document.querySelector("#navbar .search");

  let searchInput = document.querySelector("#navbar .search-input");

  if (target !== searchInput && !searchInputParent.contains(target)) {
    document.querySelector("#navbar .search .search-input").style.opacity = 0;
    document.querySelector("#navbar .search .search-input").style.pointerEvents = "none";
  }


})
