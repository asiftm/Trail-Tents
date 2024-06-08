<template>
  <div>
    <UserHeader />
    <h1>Bookings</h1>
  </div>
</template>
<script>
//import axios from "axios";
import UserHeader from "../components/UserHeader.vue";
export default{
  name:"UserBookings",
  components:{
    UserHeader,
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
}
</script>