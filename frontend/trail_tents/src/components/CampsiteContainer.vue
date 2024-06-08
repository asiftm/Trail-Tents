<template>
  <div class="vertical-container">
    <div>
      <div id="campsite-name">
        <p>{{ this.campsite.name }}</p>
      </div>
      <div class="campsiteContainer">
        <div class="left-right-container" id="left-container">
          <div id="img-container">
            <img :src="this.campsite.displayImage" alt="" />
            <ButtonWhite v-on:click="UploadPhoto()" text="Upload Photo" />
          </div>
        </div>
        <div class="left-right-container" id="right-container">
          <div class="campsite_details">
            <label> Rating </label>
            <div id="rating-star-container">
              <div class="rating-stars" v-for="(i, index) in 5 - this.campsite.rating" :key="index">
                <img src="../assets/review_star_white.png" alt="" />
              </div>
              <div class="rating-stars" v-for="(i, index) in this.campsite.rating" :key="index">
                <img src="../assets/review_star_yellow.png" alt="" />
              </div>
            </div>
          </div>
          <div class="campsite_details" id="location">
            <label> Location </label>
            <p>{{ this.campsite.location }}</p>
          </div>
          <div class="campsite_details" id="priceperday">
            <label> Price </label>
            <p>{{ this.campsite.pricePerDay }} euro / day</p>
          </div>
          <div class="campsite_details" id="description">
            <label> Description </label>
            <p>{{ this.campsite.description }}</p>
          </div>
          <div class="campsite_details" id="reviews">
            <CampsiteReviewCard />
          </div>
        </div>
      </div>

    </div>

  </div>
</template>

<script>
import axios from "axios";
import CampsiteReviewCard from "../components/CampsiteReviewCard.vue"
import ButtonWhite from "../components/ButtonWhite.vue"

export default {
  name: "CampsiteContainer",
  components: {
    CampsiteReviewCard,
    ButtonWhite,
  },
  data() {
    return {
      campsite: {
        id: null,
        name: "",
        location: "",
        description: "",
        pricePerDay: 12,
        rating: 0,
        displayImage: "",
      },
    };
  },
  methods: {
    async GetCampsiteDetails() {
      try {
        let result = await axios.get(
          `https://localhost:5272/CampingSite/${this.campsite.id}`
        );
        if (result.status == 200 && result.data != null) {
          this.campsite = result.data;
        }
      } catch (error) {
        console.log(error);
      }
    },
    UploadPhoto(){
      console.log("adfs")
    }
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    } else {
      this.campsite.id = this.$route.params.id;
      this.GetCampsiteDetails();
    }
  },
};
</script>

<style scoped>
.vertical-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

#campsite-name{
  font-size: 34px;
  font-weight: 600;
}
#campsite-name p{
  text-align: center;
  margin: 10px;
}

.campsiteContainer {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

#left-container {
  width: 40%;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
}

#img-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

#img-container img {
  height: 400px;
  width: 400px;
  margin: 20px;
  border-radius: 8px;
}

#right-container {
  width: 60%;
  margin-right: 30px;
}

.campsite_details {
  margin: 10px 0px;
}

.campsite_details p {
  margin: 10px 0px;
}

.campsite_details label {
  font-weight: 600;
  font-size: 22px;
}

#rating-star-container {
  margin: 10px -1px;
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  align-items: center;
}

.rating-stars img {
  height: 20px;
  width: 20px;
  padding: 0px;
  margin: 0px 2px;
}

#description {
  width: 90%;
}
</style>