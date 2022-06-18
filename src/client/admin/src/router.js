import { createRouter, createWebHistory } from 'vue-router'
const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    linkActiveClass: 'active',
    routes: [
        {
            path: '/',
            name: 'home',
            component: () => import('../src/pages/HomePage.vue')
        },
        {
            path: '/manage/lookups',
            name: 'Lookups',
            component: () => import('../src/pages/LookupPage.vue')
        }
    ]
})
// router.beforeEach((to, from, next,) => {
//     if (to.name == "login") {
//         //TODO: login sayfasına gidememeli!
//         // if (session.isAuthenticated()) {
//         //   router.back();
//         // }
//         return next();
//     }
//     if (!session.isAuthenticated()) {
//         session.clear();
//         router.push("/login");
//     } else {
//         return next();
//     }

// })
export default router