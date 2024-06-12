<template>
  <div>
    <UserHeader />
    <CampsiteContainer />
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import CampsiteContainer from "../components/CampsiteDetails.vue";

export default {
  name: "CampsiteView",
  components: {
    UserHeader,
    CampsiteContainer,
  },
}
</script>

<style scoped>
*{
  font-family: "Ysabeau Infant", sans-serif;;
}
</style>