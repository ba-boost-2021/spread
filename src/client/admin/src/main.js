import { createApp } from "vue";
import App from "./App.vue";
import Extensions from "./main.extension";

Extensions();
createApp(App).mount("#app");
