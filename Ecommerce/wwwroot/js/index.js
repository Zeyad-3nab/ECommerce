const spinner = document.querySelector(".spinner");
const loadingPage = document.querySelector(".loading-page");

window.addEventListener("DOMContentLoaded", () => {
    setTimeout(() => {
        spinner.style.opacity = "0";
        spinner.style.display = "none";
    }, 2000);
    setTimeout(() => {
        loadingPage.style.opacity = "0";
        loadingPage.remove();
    }, 2500);
});