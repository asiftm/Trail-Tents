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
  name: "UserHeader",
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
      this.$router.push({ name: "BookingsPage" });
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
  /* background-color: #b3eda9; */
  /* background-color: #105d5e; */
  /* background-color: #009a6e; */
  /* background-color: #ebfadb; */
  /* background-color: #293e33; */
  /* background-color: #767f7d; */
  /* background-color: #c2cbc9; */
  /* background-color: #e8e300; */
  /* background-color: #4d7111; */
  /* background-color: #c3e956; */
  /* background-color: #91eaaf; */
  background-color: #eaf7df;
  border-radius: 10px;
  margin: 15px;
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