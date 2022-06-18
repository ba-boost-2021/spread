import { createApp } from "vue";
import App from "./App.vue";
import Extensions from "./main.extension";
import router from './router'

const app = createApp(App)
Extensions();
app.use(router)
app.mount("#app");
