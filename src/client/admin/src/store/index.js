import { createStore } from "vuex";
import titleStore from "./title"

const store = createStore({
    modules: {
      title: titleStore,
    }
  });
 export default store;