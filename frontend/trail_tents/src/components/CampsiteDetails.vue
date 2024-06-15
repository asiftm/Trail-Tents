<template>
  <div class="vertical-container">
    <div id="campsite-name">
      <p>{{ this.campsite.name }}</p>
    </div>
    <div class="campsiteContainer">
      <div class="left-right-container" id="left-container">
        <div id="img-container">
          <img :src="this.campsite.displayImage" alt="" />
          <ButtonWhite v-on:click="ShowBookingOverlay(true)" text="Book Now!" />
        </div>
      </div>
      <div class="left-right-container" id="right-container">
        <div class="campsite_details">
          <label> Rating </label>
          <div id="rating-star-container">
            <RatingStars :rating="campsite.rating" />
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
          <div id="review-box">
            <label> Reviews (Total: {{ totalReview }}) </label>
            <ButtonWhite v-on:click="ShowReviewOverlay(true)" text="Add Review!" />
          </div>
          <CampsiteReviewCard @totalReview="ShowTotalReview($event)" />
        </div>
      </div>
    </div>
    <div v-if="bookingOverlay" class="bookingOverlay">
      <BookingProcess :campsite="campsite" @closeBookingOverlay="ShowBookingOverlay()" />
    </div>
    <div v-if="reviewOverlay" class="reviewOverlay">
      <AddReview :campsite_id="campsite.id" @closeReviewOverlay="ShowReviewOverlay()" />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import CampsiteReviewCard from "../components/CampsiteReviewCard.vue"
import ButtonWhite from "../components/ButtonWhite.vue"
import RatingStars from "../components/RatingStars.vue";
import BookingProcess from "../components/BookingProcess.vue";
import AddReview from "../components/AddReview.vue";

export default {
  name: "CampsiteContainer",
  components: {
    CampsiteReviewCard,
    ButtonWhite,
    RatingStars,
    BookingProcess,
    AddReview
  },
  data() {
    return {
      campsite: {
        id: null,
        name: "",
        location: "",
        description: "",
        pricePerDay: null,
        rating: null,
        displayImage: "",
      },
      bookingOverlay: false,
      reviewOverlay: false,
      totalReview: null,
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
    ShowBookingOverlay(value) {
      this.bookingOverlay = value;
      if (value) {
        this.reviewOverlay = false;
      }
    },
    ShowReviewOverlay(value) {
      this.reviewOverlay = value;
      if (value) {
        this.bookingOverlay = false;
      }
    },
    ShowTotalReview(total) {
      this.totalReview = total;
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
  position: relative;
}

#campsite-name {
  font-size: 34px;
  font-weight: 600;
}

#campsite-name p {
  text-align: center;
  margin: 10px;
}

.campsiteContainer {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

#left-container {
  width: 590px;
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
  width: 890px;
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

#rating-star-container {}

.rating-stars img {
  height: 20px;
  width: 20px;
  padding: 0px;
  margin: 0px 2px;
}

#description {
  width: 90%;
}

.bookingOverlay {
  padding: 10px;
  width: 1000px;
  position: absolute;
  top: 100px;
}

#review-box {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.reviewOverlay {
  padding: 10px;
  width: 700px;
  position: absolute;
  top: 100px;
}
</style>