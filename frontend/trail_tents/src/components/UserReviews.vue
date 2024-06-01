<template>
  <div>
    <UserHeader />
    <USerReview />
  </div>
</template>

<script>
//import axios from "axios";
import UserHeader from "./UserHeader.vue";
import USerReview from "./UserReview.vue"

export default{
  name:"UserReviews",
  components:{
    UserHeader,
    USerReview
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
}
</script>