<template>
  <div id="main">
    <div class="container">
      <div class="left-right-container" id="left-container">
        <p>This campsite is booked on these dates:</p>
        <div class="bookings" v-for="booking in bookings" :key="booking.id">
          <ul>
            <li>
              {{ booking.bookingStartDate }} - {{ booking.bookingEndDate }}
            </li>
          </ul>
        </div>
      </div>
      <div class="left-right-container" id="right-container">
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
    </div>
    <ButtonWhite v-on:click = "Close()" class="close-btn" text="Close" />
  </div>
</template>

<script>
import axios from 'axios';
import ButtonWhite from './ButtonWhite.vue';

export default {
  name: "BookingProcess",
  data() {
    return {
      user_id: null,
      bookings: [],
      bookingStartDate: "",
      bookingEndDate: ""
    }
  },
  components: {
    ButtonWhite,
  },
  props: {
    campsite: {
      type: Object,
      required: true
    }
  },
  methods: {
    async GetCampsiteBookings() {
      let result = await axios.get(`https://localhost:5272/CampingSite/${this.campsite.id}/Bookings`);
      if (result.status == 200 && result.data != null) {
        this.bookings = result.data;
        console.log(this.bookings)
      }
    },
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
    formatDate(dateStr) {
      let formattedDate;
      if (dateStr.includes('/')) {
        // Input format: dd/mm/yyyy
        const [day, month, year] = dateStr.split('/');
        formattedDate = `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`;
      } else if (dateStr.includes('-')) {
        // Input format: yyyy-mm-dd
        const [year, month, day] = dateStr.split('-');
        formattedDate = `${day.padStart(2, '0')}/${month.padStart(2, '0')}/${year}`;
      } else {
        // Handle unsupported input format
        throw new Error('Unsupported date format');
      }
      return formattedDate;
    },
    Close() {
      this.$emit('closeBookingOverlay', false);
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
      this.GetCampsiteBookings()
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

#left-container {

}

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

.close-btn{
  position: absolute;
  top: 0;
  right: 0;
}

</style>
