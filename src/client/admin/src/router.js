import { createRouter, createWebHistory } from "vue-router";
import store from "./store";
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  linkActiveClass: "active",
  routes: [
    {
      path: "/",
      name: "home",
      meta: { title: "Karşılama Ekranı" },
      component: () => import("../src/pages/HomePage.vue"),
    },
    {
      path: "/manage/lookups",
      name: "Lookups",
      meta: { title: "Metaveriler" },
      component: () => import("../src/pages/LookupPage.vue"),
    },
  ],
});
router.beforeEach((to, from, next) => {
  store.commit("title/set", to.meta.title ?? "Spread - Sayfa Başlığı");
  return next();
});
export default router;
