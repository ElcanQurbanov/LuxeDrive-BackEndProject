$('.slider').slick({
  dots: false,
  infinite: true,
  speed: 500,
  fade: true,
  cssEase: 'linear',
  autoplay: true,
  arrows: false
});

$(".slider").on("click", function () {
  $(".slider").slick("slickPlay");
})

$(".slider").on("mouseover", function () {
  $(".slider").slick("slickPlay");
})


window.addEventListener("scroll", function () {
  let scrollPosition = window.pageYOffset;

  if (scrollPosition > 800) {

    document.getElementById("navbar").style.backgroundColor = "black";

  }
  else {
    document.getElementById("navbar").style.backgroundColor = "transparent";
  }

})


window.addEventListener("scroll", function () {
  let scrollposition = window.pageYOffset;

  if (scrollposition > 2875) {
    let carImages = document.querySelectorAll("#guarantee .car-img");

    for (const carImage of carImages) {
      carImage.style.height = "541.96px";
    }
  }
});

document.querySelector("#guarantee .car-img").parentNode.parentNode.children[0].children[0].classList.add("left");
document.querySelector("#guarantee .car-img").parentNode.parentNode.children[1].children[0].classList.add("right");

document.querySelector("#premium-rental .rental-img").parentNode.parentNode.children[0].children[0].classList.add("img");
document.querySelector("#premium-rental .rental-img").parentNode.parentNode.children[1].children[0].classList.add("img2");

window.addEventListener("scroll", function () {
  let scrollposition = window.pageYOffset;

  if (scrollposition > 5000) {
    let rentalImages = document.querySelectorAll("#premium-rental .rental-img");

      for (const rentalImage of rentalImages) {
          rentalImage.style.height = "448.56px";
      }
  }
});