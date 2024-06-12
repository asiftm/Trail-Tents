<template>
  <div>
    <UserHeader />
    <CampsiteList />
  </div>
</template>

<script>
import CampsiteList from "../components/CampsiteList.vue";
import UserHeader from "../components/UserHeader.vue";

export default {
  name: "CampsitePage",
  components: {
    UserHeader,
    CampsiteList
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
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