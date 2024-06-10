<template>
  <div class="main">
    <p>
      My Reviews (Total : {{ reviewList.length }})
    </p>
    <div class="review-container">
      <div class="review" v-for="(item, index) in reviewList" :key="index">
        <div class="review-item" id="campsiteName">
          <button v-on:click="OpenCampsite(item.campsiteID)">{{ item.campsiteName }}</button>
        </div>
        <div class="review-item" id="comment">
          {{ item.comment }}
        </div>
        <div class="review-item" id="rating">
          <div class="rating-star-container" v-for="(i, index) in 5 - item.rating" :key="index">
            <img src="../assets/review_star_white.png" alt="">
          </div>
          <div class="rating-star-container" v-for="(i, index) in item.rating" :key="index">
            <img src="../assets/review_star_yellow.png" alt="">
          </div>
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
      reviewList: []
    }
  },
  methods: {
    async GetUserReviews() {
      try {
        let result = await axios.get(`https://localhost:5272/User/${this.user_id}/Reviews`);
        if (result.status == 200 && result.data != null) {
          for (let i = 0; i < result.data.length; i++) {
            let campsitedata = await this.GetCampsite(result.data[i].campsiteID)
            let dataDict = {
              comment: result.data[i].comment,
              rating: result.data[i].rating,
              campsiteID: result.data[i].campsiteID,
              campsiteName: campsitedata.name
            }
            this.reviewList.push(dataDict);
            console.log(typeof (dataDict.rating))
          }
        }
      } catch (error) {
        console.log(error)
      }
    },
    async GetCampsite(id) {
      try {
        let result = await axios.get(`https://localhost:5272/CampingSite/${id}`);
        if (result.status == 200 && result.data != null) {
          return result.data
        }
      } catch (error) {
        console.log(error)
      }
    },
    OpenCampsite(campsiteID) {
      let userInfo = localStorage.getItem("userInfo");
      if (!userInfo) {
        this.$router.push({ name: "UserLogin" });
      } else {
        this.$router.push({ name: 'CampsiteView', params: { id: campsiteID } });
      }
    }
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

<style scoped>
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

.main button {
  font-family: "Ysabeau Infant", sans-serif;
  font-size: 20px;
  font-weight: 600;
  background: none;
  padding-bottom: 5px;
  box-shadow: none;
  border: none;
}

.main button:hover {
  cursor: pointer;
}

.review {
  height: auto;
  width: 600px;
  border-radius: 4px;
  margin-bottom: 30px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  background-color: #f0f0f0;
  position: relative;
}

.review-item {
  padding: 5px;
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
  margin: 2px;
}

#campsiteName {
  font-size: 20px;
  font-weight: 600;
}
</style>