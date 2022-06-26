import { createRouter, createWebHistory } from "vue-router";
import store from "./store";
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  linkActiveClass: "active",
  routes: [
    {
      path: "/login",
      name: "login",
      component: () => import("../src/pages/Login.vue"),
    },
    {
      path: "/",
      name: "home",
      meta: { title: "Karşılama Ekranı" },
      component: () => import("../src/pages/Home.vue"),
    }
  ],
});
router.beforeEach((to, from, next) => {
  if (!store.state.session.token) {
    if (to.path !== "/login") {
      router.push("/login");
    }
  }
  
  return next();
});
export default router;
