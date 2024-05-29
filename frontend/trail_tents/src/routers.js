import UserLogin from "./components/UserLogin.vue";
import UserSignup from "./components/UserSignup.vue";
import UserHome from "./components/UserHome.vue";
import UserProifle from "./components/UserProfile.vue";
import UserBookings from "./components/UserBookings.vue";
import UserReviews from "./components/UserReviews.vue";

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
  {
    name: "UserProfile",
    component: UserProifle,
    path: "/profile",
  },
  {
    name: "UserBookings",
    component: UserBookings,
    path: "/bookings",
  },
  {
    name: "UserReviews",
    component: UserReviews,
    path: "/reviews",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
