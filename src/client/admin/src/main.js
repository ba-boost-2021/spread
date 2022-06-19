import { createApp } from "vue";
import AppWrapper from "./AppWrapper.vue";
import Extensions from "./main.extension";
import router from "./router";
import ajax from "../src/helpers/ajax.js";
import store from "./store";

const app = createApp(AppWrapper);
Extensions();
app.use(router);
app.use(ajax);
app.use(store);
app.mount("#app");
