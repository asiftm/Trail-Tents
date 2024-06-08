<template>
  <div class="header">
    <div class="left">
      <div class="logo">
        <img src="../assets/logo.png" alt="" />
      </div>
      <div class="name">
        <ButtonWhite v-on:click="UserHome()" text="Trail Tents" />
      </div>
    </div>
    <div class="middle">
      <ButtonWhite v-on:click="UserHome()" text="Home" />
      <ButtonWhite v-on:click="UserBookings()" text="My Bookings" />
      <ButtonWhite v-on:click="UserReviews()" text="My Reviews" />
      <ButtonWhite v-on:click="UserProfile()" text="My Profile" />
    </div>
    <div class="right">
      <ButtonWhite v-on:click="Logout()" text="Log Out" />
    </div>
  </div>
</template>

<script>
import ButtonWhite from "./ButtonWhite.vue"
export default {
  name: "USerHeader",
  components: {
    ButtonWhite,
  },
  methods: {
    Logout() {
      localStorage.clear();
      this.$router.push({ name: "UserLogin" });
    },
    UserProfile() {
      let user = localStorage.getItem("userInfo");
      if (user) {
      this.$router.push({ name: "UserProfile" });
      }
      else{
        this.$router.push({ name: "UserLogin" });
      }
    },
    UserBookings() {
      let user = localStorage.getItem("userInfo");
      if (user) {
      this.$router.push({ name: "UserBookings" });
      }
      else{
        this.$router.push({ name: "UserLogin" });
      }
    },
    UserReviews() {
      let user = localStorage.getItem("userInfo");
      if (user) {
      this.$router.push({ name: "UserReviews" });
      }
      else{
        this.$router.push({ name: "UserLogin" });
      }
    },
    UserHome() {
      let user = localStorage.getItem("userInfo");
      if (user) {
        this.$router.push({ name: "UserHome" });
      }
      else{
        this.$router.push({ name: "UserLogin" });
      }
    }
  },
}
</script>

<style scoped>
.header {
  height: 80px;
  display: flex;
  justify-content: space-between;
  z-index: 100;
  color: #313638;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  border-radius: 10px;
}

.left {
  display: flex;
  flex-direction: row;
  align-items: center;
  margin-left: 20px;
}

.logo img {
  height: 60px;
}

.right,
.middle {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  margin-right: 20px;
}

.left button {
  margin: 7px 0 10px 5px;
  font-family: "Stick", sans-serif;
  font-weight: 600;
  border: none;
  box-shadow: none;
  background-color: transparent;
}
</style>