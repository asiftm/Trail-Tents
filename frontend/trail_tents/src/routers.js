import UserLogin from "./components/UserLogin.vue";
import UserSignup from "./components/UserSignup.vue";
import UserHome from "./components/UserHome.vue";

import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    name: "UserLogin",
    component: UserLogin,
    path: "/",
  },
  {
    name: "UserSignup",
    component: UserSignup,
    path: "/signUp",
  },
  {
    name: "UserHome",
    component: UserHome,
    path: "/home",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
