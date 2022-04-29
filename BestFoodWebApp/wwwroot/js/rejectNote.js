let input = document.querySelector(".RejectOrderNote");
let button = document.querySelector(".reject-button");
button.disabled = true;

input.addEventListener("input", stateHandle);

function stateHandle() {
    if (document.querySelector(".RejectOrderNote").value.length<5) {
        button.disabled = true;
    } else {
        button.disabled = false;
    }
}


