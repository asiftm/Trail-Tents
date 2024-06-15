<template>
  <div class="campsite-card">
    <div class="campsite-img">
      <img :src="campsite.displayImage" alt="Display Image">
    </div>
    <div class="campsite-name" v-on:click="OpenCampsite(campsite.id)">
      {{ campsite.name }}
    </div>
    <div class="price-rating-container">
      <div class="campsite-price">
        {{ campsite.pricePerDay }}€
      </div>
      <div class="campsite-rating">
        <RatingStars :rating="campsite.rating" />
      </div>
    </div>
  </div>

</template>

<script>
import RatingStars from "./RatingStars.vue"

export default {
  name: "CampsiteCard",
  props: {
    campsite: {
      type: Object,
      required: true
    }
  },
  components: {
    RatingStars
  },
  methods: {
    OpenCampsite(campsiteID) {
      let userInfo = localStorage.getItem("userInfo");
      if (!userInfo) {
        this.$router.push({ name: "UserLogin" });
      } else {
        this.$router.push({ name: 'CampsitePage', params: { id: campsiteID } });
      }
    }
  }
}
</script>

<style scoped>
* {
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
}

.campsite-card {
  padding: 10px;
  margin: 7px 10px;
  width: 220px;
  height: 300px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  border-radius: 5%;
  transition: .8s;
  border: 2px solid #c2cbc9;
}

.campsite-card:hover {
  cursor: pointer;
  transform: scale(1.1);
  z-index: 100;
}


.campsite-name {
  font-size: 24px;
}

.campsite-img {
  height: 200px;
  width: 200px;
  position: relative;
}

.campsite-img img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  position: absolute;
  top: 0;
  left: 0;
  border-radius: 4%;
}

.price-rating-container {
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: flex-start;
  margin: 0;
  padding: 5px;
}

.campsite-price {
  font-size: 15px;
}

.campsite-rating {
  height: 10px;
}
</style>
