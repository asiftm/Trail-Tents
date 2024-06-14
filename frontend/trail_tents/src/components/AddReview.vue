<template>
  <div id="main">
    <div id="right-container">
      <p>Select Available Dates and Book Now!</p>
      <div id="datepickiers-container">
        <div class="datepicker">
          <label>From: </label>
          <input type="date" id="dateFrom" v-model="bookingStartDate">
        </div>
        <div class="datepicker">
          <label>To: </label>
          <input type="date" id="dateTo" v-model="bookingEndDate">
        </div>
      </div>
      <div>
        <ButtonWhite v-on:click="Booking()" text="Book" />
      </div>
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
      campsiteID: null,
      userID: null,
      rating: null,
      comment: "",
      username: ""
    }
  },
  components: {
    ButtonWhite,
  },
  methods: {
    async Booking() {
      if (this.bookingStartDate != "" && this.bookingEndDate != "") {
        try {
          let result = await axios.post("https://localhost:5272/Booking", {
            campsiteID: this.campsite.id,
            userID: this.user_id,
            bookingStartDate: this.formatDate(this.bookingStartDate),
            bookingEndDate: this.formatDate(this.bookingEndDate)
          });
          if (result.status == 200) {
            this.$router.push({ name: "CampsitesPage" });
          }
        }
        catch {
          confirm("Change your booking dates please.")
        }
      }
      else {
        confirm("Select your booking dates please.")
      }
    },
    Close() {
      this.$emit('closeOverlay', false)
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
      console.log("hello")
    }
  },
}

</script>


<style scoped>
#main {
  padding: 10px;
  background-color: rgb(255, 255, 255);
  border-radius: 20px;
  border: 5px solid gray;
}

.container {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-items: center;
}

#left-container p {
  font-size: 24px;
  font-weight: 600;
}

#left-container {}

#right-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  font-size: 24px;
}

#datepickiers-container {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  margin: 20px;
}

.datepicker {
  padding: 20px;
}

.bookings {
  margin: 20px;
}

.close-btn {
  position: absolute;
  top: 0;
  right: 0;
}
</style>
