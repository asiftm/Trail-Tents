<template>
  <div id="main">
    <div id="container">
      <P>Rate this campsite and leave a comment</P>
      <div class="item" id="review">
        <label>Rating (out of 5): </label>
        <input type="number" max="5" min="1" v-model="rating">
      </div>
      <div class="item" id="comment">
        <label>Review: </label>
        <textarea placeholder="Write your comment here" v-model="comment"></textarea>
      </div>
      <ButtonWhite v-on:click="AddReview()" class="save-btn" text="Save Review" />
    </div>
    <ButtonWhite v-on:click="Close()" class="close-btn" text="Close" />
  </div>
</template>

<script>
import axios from 'axios';
import ButtonWhite from './ButtonWhite.vue';

export default {
  name: "AddReview",
  data() {
    return {
      user_id: null,
      user_name: "",
      campsiteID: this.campsite_id,
      userID: null,
      rating: null,
      comment: "",
      username: ""
    }
  },
  props:{
    campsite_id: {
      type: Number,
      required: true
    }
  },
  components: {
    ButtonWhite,
  },
methods: {
    async AddReview() {
    if (this.rating != null && this.comment != "") {
      try {
        let result = await axios.post("https://localhost:5272/Review", {
          campsiteID: this.campsiteID,
          userID: this.user_id,
          rating: this.rating,
          comment: this.comment,
          username: this.user_name,
          });
        if (result.status == 200) {
          window.location.reload();
        }
      }
      catch {
        confirm("Try again please.")
      }
    }
    else {
      confirm("Write a comment and rate the campsite please.")
    }
  },
  Close() {
    this.$emit('closeReviewOverlay', false)
  }
},
mounted() {
  let userInfo = localStorage.getItem("userInfo");
  if (!userInfo) {
    this.$router.push({ name: "UserLogin" });
  }
  else {
    const user = JSON.parse(userInfo);
    this.user_id = user.id;
    this.user_name = user.firstname+ " " + user.lastname;
    console.log("hello")
  }
},
}

</script>


<style scoped>
#main {
  padding: 20px;
  background-color: #eaf7df;
  border-radius: 20px;
  border: 2px solid gray;
}

.save-btn{
  margin-top: 20px;
}

p{
  font-size: 28px;
  text-align: center;
}

label{
  font-size: 24px;
}

input{
  width: 40px;
}

#comment textarea{
  height: 200px;
  width: 90%;
  max-width: 600px;
  padding: 10px;
  font-size: 16px;
  line-height: 1.5;
  border: 1px solid #ccc;
  border-radius: 4px;
  resize: vertical;
}

.close-btn {
  position: absolute;
  top: 0;
  right: 0;
}
</style>
