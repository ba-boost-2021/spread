import axios from "axios";
export default {
  install: (app) => {
    const instance = axios.create({
      baseURL: "https://localhost:15000",
    });
    let ajax = {
      get: function (url) {
        return instance.get(url);
      },
    };
    app.config.globalProperties.$ajax = ajax;
  },
};
