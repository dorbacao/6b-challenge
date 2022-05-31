const url = "http://localhost:5256/";
import auth from "./auth.js";

export default {
  async getAsync(route) {
    return new Promise(function (resolve, reject) {
      var xhr = new XMLHttpRequest();
      xhr.open("GET", url + route);

      var user = auth.get();
      if (user) xhr.setRequestHeader("Authorization", "Bearer " + user.token);

      xhr.onload = (e) => {
        resolve(e);
      };
      xhr.onerror = reject;
      xhr.send();
    });
  },

  async postAsync(route, object) {
    return new Promise(function (resolve, reject) {
      var xhr = new XMLHttpRequest();
      xhr.open("POST", url + route);
      xhr.setRequestHeader("Content-Type", "application/json");

      
      var user = auth.get();
      if (user) xhr.setRequestHeader("Authorization", "Bearer " + user.token);


      xhr.onload = (e) => {
        resolve(e);
      };
      xhr.onerror = reject;
      xhr.send(JSON.stringify(object));
    });
  },

  
  async deleteAsync(route) {
    return new Promise(function (resolve, reject) {
      var xhr = new XMLHttpRequest();
      xhr.open("DELETE", url + route);
      xhr.setRequestHeader("Content-Type", "application/json");

      
      var user = auth.get();
      if (user) xhr.setRequestHeader("Authorization", "Bearer " + user.token);


      xhr.onload = (e) => {
        resolve(e);
      };
      xhr.onerror = reject;
      xhr.send();
    });
  },

  async putAsync(route) {
    return new Promise(function (resolve, reject) {
      var xhr = new XMLHttpRequest();
      xhr.open("PUT", url + route);
      xhr.setRequestHeader("Content-Type", "application/json");

      
      var user = auth.get();
      if (user) xhr.setRequestHeader("Authorization", "Bearer " + user.token);


      xhr.onload = (e) => {
        resolve(e);
      };
      xhr.onerror = reject;
      xhr.send();
    });
  },
};
