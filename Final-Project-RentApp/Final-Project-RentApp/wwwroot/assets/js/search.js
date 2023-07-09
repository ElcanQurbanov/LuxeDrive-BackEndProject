"use strict";

document.querySelector("header #navbar .search .search-input i").addEventListener("click", function () {
    if (document.querySelector("header #navbar .search .search-input input").value.trim() != "") {
        let searchText = document.querySelector("header #navbar .search .search-input input").value;
        let url = `/Search/SearchByCars?searchText=${searchText}`;

        window.location.assign(url);
        
    }
});

//enter
document.querySelector("header #navbar .search .search-input input").addEventListener("keydown", function (event) {
    if (event.keyCode === 13) {
        if (document.querySelector("header #navbar .search .search-input input").value.trim() != "") {
            let searchText = document.querySelector("header #navbar .search .search-input input").value;
            let url = `/Search/SearchByCars?searchText=${searchText}`;

            window.location.assign(url);

        }
    }
});