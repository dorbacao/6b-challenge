export default {
  save(user) {
    localStorage.setItem("user", JSON.stringify(user));
  },
  get() {
    var user = localStorage.getItem("user");
    if (!user) return null;
    return JSON.parse(user);
  },
  remove() {
    localStorage.removeItem("user");
  },
  redirectWhenUnauthenticated() {
    if (!this.get()) window.location = "login.html";
  },
  redirectToHomeWhenAuthenticated() {
    if (this.get()) {
      window.location = "booking.html";
    }
  },
  signout() {
    this.remove();
    window.location = "login.html";
  },
};
