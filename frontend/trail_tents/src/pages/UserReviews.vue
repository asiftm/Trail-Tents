<template>
  <div>
    <UserHeader />
    <USerReview />
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import USerReview from "../components/UserReview.vue"

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