<template>
  <div class="main">
    <p>
      My Reviews
    </p>
    <div class="review-container">
      <div class="review" v-for="(item, index) in reviewList" :key="index">
        <div id="comment">
          {{ item.comment }}
        </div>
        <div id="rating">
          {{ item.rating }}
        </div>
        <div id="campsiteName">
          {{ item.campsiteName }}
        </div>
        <div id="campsiteName">
          {{ item.campsiteID }}
        </div>
        <div id="campsiteName">
          {{ item.campsiteName }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "UserReview",
  data() {
    return {
      user_id: null,
      reviewList: [],
      campsite_name: "gh",
      campsite_id: 0
    }
  },
  methods: {
    async GetUserReviews() {
      try {
        let result = await axios.get(`https://localhost:5272/User/${this.user_id}/Reviews`);
        if (result.status == 200 && result.data != null) {
          for (let i = 0; i < result.data.length; i++) {
            this.campsite_id = result.data[i].campsiteID
            await this.GetCampsite()
            let dataDict = {
              comment: result.data[i].comment,
              rating: result.data[i].rating,
              campsiteID: result.data[i].campsiteID,
              campsiteName: this.campsite_name
            }
            this.reviewList.push(dataDict);
          }
        }
      } catch (error) {
        console.log(error)
      }
    },
    async GetCampsite() {
      try {
        let result = await axios.get(`https://localhost:5272/CampingSite/${this.campsite_id}`);
        if (result.status == 200 && result.data != null) {
          this.campsite_name = result.data.name
        }
      } catch (error) {
        console.log(error)
      }
    },
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    } else {
      const user = JSON.parse(userInfo);
      this.user_id = user.id;
      this.GetUserReviews(this.user_id);
    }
  },
}
</script>

<style>
.main {
  font-family: "Ysabeau Infant", sans-serif;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.main p {
  font-size: 28px;
  font-weight: 600;
}

.review-container {}

.review {
  height: auto;
  width: 600px;
  border-radius: 4px;
  margin-top: 20px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  background-color: #f0f0f0;
}
</style>