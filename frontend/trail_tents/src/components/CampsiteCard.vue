<template>
  <div class="campsite-card" v-on:click = "OpenCampsite(campsite.id)">
    <p id="name">{{ campsite.name }}</p>
    <div class="campsite-img">
      <img :src="campsite.displayImage" alt="Display Image">
      <RatingStars :rating= "campsite.rating" />
    </div>
    <p>{{campsite.pricePerDay}} euro/day</p>
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
  components:{
    RatingStars
  },
  methods: {
    OpenCampsite(campsiteID) {
      let userInfo = localStorage.getItem("userInfo");
      if (!userInfo) {
        this.$router.push({ name: "UserLogin" });
      } else {
        this.$router.push({ name: 'CampsiteView', params: { id: campsiteID } });
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
  font-size: 16px;
}

.campsite-card {
  height: 340px;
  width: 300px;
  margin: 20px;
  border-radius: 5px;
  background-color: rgb(255, 255, 255);
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  transition: 0.3s;
}

.campsite-card:hover{
  cursor: pointer;
  transform: scale(1.05);
}

.campsite-card p{
  margin: 10px 0px;

}

#name{  
  font-size: 24px;
}

.campsite-img {
  height: 285px;
  width: 285px;
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

#rating{
  position: absolute;
  top: -10px;
  right: -1px;

}

</style>