import { createApp } from "vue";
import App from "./App.vue";
import Extensions from "./main.extension";
import router from "./router";
import ajax from "../src/helpers/ajax.js";

const app = createApp(App);
Extensions();
app.use(router);
app.use(ajax);
app.mount("#app");
