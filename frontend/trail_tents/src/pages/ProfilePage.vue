<template>
  <div>
    <UserHeader />
    <UserProfileDetails />
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import UserProfileDetails from '../components/UserProfileDetails.vue';
export default {
  
  name: "UserProfile",
  components: {
    UserProfileDetails,
    UserHeader
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
}
</script>