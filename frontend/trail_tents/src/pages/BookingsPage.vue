<template>
  <div class="main">
    <UserHeader />
    <div id="container">
      <h1 class="heading">My Bookings</h1>
      <div v-if="bookings.length && campsites.length">
        <div v-for="booking in bookings" :key="booking.id">
          <BookingCard v-if="FindCampsiteById(booking.campsiteID)" :booking="booking" :campsite="FindCampsiteById(booking.campsiteID)" />
        </div>
      </div>
      <div v-else>
        <p>Loading bookings and campsites...</p>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios"
import UserHeader from "../components/UserHeader.vue";
import BookingCard from "../components/BookingCard.vue";
export default {
  name: "BookingsPage",
  data() {
    return {
      user_id: null,
      bookings: [],
      campsites: [],
    }
  },
  components: {
    UserHeader,
    BookingCard,
  },

  methods: {
    async GetUserBookings() {
      try {
        let result = await axios.get(
          `https://localhost:5272/User/${this.user_id}/Bookings`
        );
        if (result.status == 200 && result.data != null) {
          this.bookings = result.data;
          console.log(this.bookings)
        }
      } catch (error) {
        console.log(error);
      }
    },
    async GetCampsites() {
      try {
        let result = await axios.get(`https://localhost:5272/CampingSite`);
        if (result.status == 200 && result.data != null) {
          this.campsites = result.data;
          console.log(this.campsites)
        }
      } catch (error) {
        console.log(error);
      }
    },
    FindCampsiteById(campsiteID) {
      return this.campsites.find(campsite => campsite.id === campsiteID);
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
      this.GetUserBookings();
      this.GetCampsites();
    }
  },
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

.main {
  display: flex;
  flex-direction: column;
}

#container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.heading {
  font-size: 28px;
  font-weight: 600;
  margin-top: 10px;
}
</style>
