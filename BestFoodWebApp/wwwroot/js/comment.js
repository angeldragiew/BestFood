let input = document.querySelector(".commentInput");
let button = document.querySelector(".commentButton");
button.disabled = true;

input.addEventListener("input", stateHandle);

function stateHandle() {
    if (document.querySelector(".commentInput").value === "") {
        button.disabled = true;
    } else {
        button.disabled = false;
    }
}