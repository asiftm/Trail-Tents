<template>
  <div class="header">
    <div class="left">
      <div class="logo">
        <img src="../assets/logo.png" alt="" />
      </div>
      <div class="name">
        <ButtonWhite v-on:click="AdminHome()" text="Trail Tents" />
      </div>
    </div>
    <div class="right">
      <ButtonWhite v-on:click="Logout()" text="Log Out" />
    </div>
  </div>
</template>

<script>
import ButtonWhite from "./ButtonWhite.vue"
export default {
  name: "AdminHeader",
  components: {
    ButtonWhite,
  },
  methods: {
    Logout() {
      localStorage.clear();
      this.$router.push({ name: "UserLogin" });
    },
    
    AdminHome() {
      let user = localStorage.getItem("adminInfo");
      if (user) {
        this.$router.push({ name: "AdminHome" });
      }
      else {
        this.$router.push({ name: "UserLogin" });
      }
    }
  },
  mounted() {
    let adminInfo = localStorage.getItem("adminInfo");
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo && !adminInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  }
}
</script>

<style scoped>
.header {
  height: 80px;
  display: flex;
  justify-content: space-between;
  z-index: 100;
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

.right {
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