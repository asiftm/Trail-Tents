import UserLogin from "./pages/LoginPage.vue";
import UserSignup from "./pages/SignupPage.vue";
import UserHome from "./pages/HomePage.vue";
import UserProifle from "./pages/ProfilePage.vue";
import UserBookings from "./pages/BookingsPage.vue";
import UserReviews from "./pages/ReviewsPage.vue";
import CampsitePage from "./pages/CampsitePage.vue";
import CampsitesPage from "./pages/CampsitesPage.vue"

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
    name: "CampsitePage",
    component: CampsitePage,
    path: "/campsite/:id",
  },
  {
    name: "CampsitesPage",
    component: CampsitesPage,
    path: "/campsites",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
