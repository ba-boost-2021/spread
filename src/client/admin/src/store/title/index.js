export default {
  namespaced: true,
  state: () => ({
    title: "Spread - Karşılama Ekranı",
  }),
  mutations: {
    set(state, value) {
      state.title = value;
    },
  },
};
