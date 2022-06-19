import axios from "axios";
import store from "../store";
export default {
  install: (app) => {
    const instance = axios.create({
      baseURL: "https://localhost:15000",
    });

    const addHeader = () => {
      let config = {
        headers: {},
      };
      const token = store.state.session.token;
      if (token) {
        config.headers["Authorization"] = "Bearer " + token;
      }
      return config;
    };

    let ajax = {
      get: function (url) {
        return instance.get(url, addHeader());
      },
      post: function (url, data) {
        return instance.post(url, data, addHeader());
      },
    };
    app.config.globalProperties.$ajax = ajax;
  },
};
