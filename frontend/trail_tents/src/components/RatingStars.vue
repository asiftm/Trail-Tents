<template>
  <div id="rating">
    <div class="rating-star-container">
      <img v-for="i in 5" :key="i" :src="getImagePath(i)" alt="">
    </div>
  </div>
</template>

<script>
export default {
  name: "RatingStars",
  props: {
    rating: {
      type: Number,
      required: true
    }
  },
  methods: {
    getImagePath(index) {
      return index <= this.rating ? require(`../assets/review_star_yellow.png`) : require(`../assets/review_star_white.png`);
    }
  }
}
</script>

<style>
#rating {
  background-color: #ffffff;
  border-radius: 5px;
  padding: 0;
  display: flex;
  flex-direction: row;
  top: -15px;
  right: 0;
}

.rating-star-container img {
  height: 20px;
  width: 20px;
  padding: 0px;
  margin: 2px;
}
</style>