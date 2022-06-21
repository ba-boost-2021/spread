import axios from "axios";
import store from "../store";
export default {
  install: (app) => {
    const instance = axios.create({
      baseURL: "http://localhost:15001",
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
      delete: function (url) {
        return instance.delete(url, addHeader());
      },
    };
    app.config.globalProperties.$ajax = ajax;
  },
};
