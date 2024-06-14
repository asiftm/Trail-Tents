<template>
  <div>
    <UserHeader />
    <div class="main">
      <UserReview />
    </div>
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import UserReview from "../components/UserReview.vue";

export default {
  name: "UserReviews",
  data() {
    return {
      reviewOverlay: false,
    }
  },
  components: {
    UserHeader,
    UserReview,
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
}
</script>