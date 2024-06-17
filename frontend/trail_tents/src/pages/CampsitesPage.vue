<template>
  <div>
    <UserHeader v-if="isUser" />
    <CampsiteList />
  </div>
</template>

<script>
import CampsiteList from "../components/CampsiteList.vue";
import UserHeader from "../components/UserHeader.vue";

export default {
  name: "CampsitePage",
  data() {
    return {
      isUser: false,
    }
  },
  components: {
    UserHeader,
    CampsiteList
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
    }
  },
}
</script>

<style scoped>
* {
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
  font-size: 16px;
}
</style>