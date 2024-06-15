<template>
  <div class="booking-container">
    <div class="section" id="campsite">
      <div>
        <h1 id="name" v-on:click="OpenCampsite(campsite.id)">Campsite Name: {{ campsite.name }}</h1>
      </div>
      <div>
        <h1 id="location">Location: {{ campsite.location }}</h1>
      </div>
    </div>
    <div class="section" id="booking">
      <div>
        <h1 class="date" id="startdate">From: {{ booking.bookingStartDate }}</h1>
      </div>
      <div>
        <div>
          <h1 class="date" id="enddate">To: {{ booking.bookingEndDate }}</h1>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BookingCard",
  props: {
    booking: {
      type: Object,
      required: true,
    },
    campsite: {
      type: Object,
      required: true,
    }
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
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
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

.booking-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin: 15px;
  width: 1000px;
  border: 2px solid #c2cbc9;
  border-radius: 10px;
}

.section {
  padding: 0px 30px;
}

#name {
  font-size: 34px;
  font-weight: 600;
  transition: 1s;
}

#name:hover {
  cursor: pointer;
}

#location,
#startdate,
#enddate {
  font-size: 24px;
}

.add-btn {
  position: absolute;
}
</style>
