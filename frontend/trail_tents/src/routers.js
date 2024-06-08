import UserLogin from "./pages/UserLogin.vue";
import UserSignup from "./pages/UserSignup.vue";
import UserHome from "./pages/UserHome.vue";
import UserProifle from "./pages/UserProfile.vue";
import UserBookings from "./pages/UserBookings.vue";
import UserReviews from "./pages/UserReviews.vue";
import CampsiteView from "./pages/CampsiteView.vue";

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
  {
    name: "CampsiteView",
    component: CampsiteView,
    path: "/campsite/:id",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
