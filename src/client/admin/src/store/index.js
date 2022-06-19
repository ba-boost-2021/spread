import { createStore } from "vuex";
import createPersistedState from "vuex-persistedstate";
import titleStore from "./title";
import sessionStore from "./session";

const store = createStore({
  plugins: [createPersistedState({ key: "persisted" })],
  modules: {
    title: titleStore,
    session: sessionStore,
  },
});
export default store;
