<template>
  <div class="header">
    <div class="left">
      <div class="logo">
        <img src="../assets/logo.png" alt="" />
      </div>
      <div class="name">
        <button v-on:click="UserHome()">Trail Tents</button>
      </div>
    </div>
    <div class="middle">
      <button v-on:click="UserHome()">Home</button>
      <button v-on:click="UserBookings()">My Bookings</button>
      <button v-on:click="UserReviews()">My Reviews</button>
      <button v-on:click="UserProfile()">My Profile</button>
    </div>
    <div class="right">
      <button v-on:click="Logout()">Log Out</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "USerHeader",
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

<style>
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

button {
  font-size: 18px;
  font-weight: 600;
  padding: 5px 10px;
  margin: 0 10px;
  border: none;
  border-radius: 20px;
  transition: 0.3s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  font-family: "Ysabeau Infant", sans-serif;
}

.left button {
  margin: 7px 0 10px 5px;
  font-family: "Stick", sans-serif;
  font-weight: 600;
  border: none;
  box-shadow: none;
  background-color: transparent;
}

button:hover {
  cursor: pointer;
  transform: scale(1.05);
}
</style>