<template>
  <div>
    <UserHeader v-if="isUser" />
    <AdminHeader v-if="isAdmin" />
    <CampsiteContainer />
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import AdminHeader from "../components/AdminHeader.vue";
import CampsiteContainer from "../components/CampsiteDetails.vue";

export default {
  name: "CampsiteView",
  data() {
    return {
      isUser: false,
      isAdmin: false
    }
  },
  components: {
    UserHeader,
    AdminHeader,
    CampsiteContainer,
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    let adminInfo = localStorage.getItem("adminInfo");
    if (!userInfo && !adminInfo) {
      this.$router.push({ name: "UserLogin" });
    }
    else{
      if(userInfo){
        this.isUser = true;
      }
      else{
        this.isAdmin = true;
      }
    }
  }
}
</script>

<style scoped>
* {
  font-family: "Ysabeau Infant", sans-serif;
  ;
}
</style>