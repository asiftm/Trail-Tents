<template>
  <div class="reviews-container">
    <label> Reviews (Total: {{ reviewList.length }}) </label>
    <div class="review" v-for="(i, index) in this.reviewList" :key="index">
        <div class="review-item" id="username">
          <p>{{ i.username }}</p>
        </div>
        <div class="review-item" id="comment">
          <p>{{ i.comment }}</p>
        </div>
        <div class="review-item" id="rating">
          <div class="rating-star-container" v-for="(i, index) in 5-i.rating" :key="index">
            <img src="../assets/review_star_white.png" alt="">
          </div>
          <div class="rating-star-container" v-for="(i, index) in i.rating" :key="index">
            <img src="../assets/review_star_yellow.png" alt="">
          </div>
        </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "CampsiteContainer",
  data() {
    return {
      campsite_id: null,
      reviewList: [],
    }
  },
  methods: {
    async GetCampsiteReviews() {
      try {
        let result = await axios.get(
          `https://localhost:5272/CampingSite/${this.campsite_id}/Reviews`
        );
        if (result.status == 200 && result.data != null) {
          this.reviewList = result.data;
          console.log(this.reviewList);
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    } else {
      this.campsite_id = this.$route.params.id;
      this.GetCampsiteReviews();
    }
  },
}
</script>

<style scoped>
label{
  font-weight: 600;
  font-size: 22px;
}

.review {
  width: 90%;
  border-radius: 4px;
  margin: 30px 0px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  background-color: #f0f0f0;
  position: relative;
}

#username p{
  font-size: 24px;
  padding: 3px 0px 10px 10px;
  margin: 0;

}

#comment p{
  padding: 0px 10px 10px 10px;
  margin: 0;
}

#rating {
  padding: 0;
  display: flex;
  flex-direction: row;
  position: absolute;
  top: -15px;
  right: 0;
}

.rating-star-container {
  display: flex;
}

.rating-star-container img {
  height: 20px;
  width: 20px;
  padding: 0px;
  margin:2px;
}
</style>