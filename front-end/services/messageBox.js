import dom from "./dom.js";
export default {
  showError(idComponent, message) {
    var error = dom.get(idComponent);
    error.innerHTML = "";
    error.classList.remove("hide");
    error.classList.remove("success-box");
    error.classList.remove("error-box");
    error.classList.add("error-box");
    error.classList.add("show");

    let h2 = document.createElement("h2");
    h2.innerText = "Error!";
    error.appendChild(h2);

    let p = document.createElement("p");
    p.innerHTML = message;
    error.appendChild(p);
  },

  showSuccess(idComponent, message) {
    var error = dom.get(idComponent);
    error.classList.remove("hide");
    error.classList.remove("error-box");
    error.classList.remove("success-box");
    error.classList.add("success-box");
    error.classList.add("show");
    error.innerHTML = "";

    let h2 = document.createElement("h2");
    h2.innerText = "Success!";
    error.appendChild(h2);

    let p = document.createElement("p");
    p.innerHTML = message;
    error.appendChild(p);
  },

  showFromResponse(idComponent, response) {
    if (response.target.status != 200) {
      this.showError(idComponent, response.target.responseText);
    } else {
      this.showSuccess(idComponent, response.target.responseText);
    }
  },

  hide(idComponent) {
    var error = dom.get(idComponent);
    error.innerHTML = "";
    error.classList.remove("hide");
    error.classList.remove("success-box");
    error.classList.remove("error-box");
    error.classList.remove("show");
    error.classList.add("hide");
  },
};
