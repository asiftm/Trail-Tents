<template>
  <div>
    <div>
      <UserHeader />
      <WelcomeText />
      <CampsiteList :numOfCampsiteToShow = 6 />
      <ButtonWhite v-on:click="CampsiteList()" text="See More" id="more-btn" />
      <div id="search-area">
        <div id="search-box-container">
          <input id="search-box" type="text" placeholder="Campsite name" />
        </div>
        <div id="search-btn-container">
          <ButtonWhite v-on:click="Search()" text="Search" />
        </div>
      </div>
      <div id="filter-area">
        <div class="picker">
          <p class="picker-heading">Check-in date</p>
          <input type="date" name="booking-start-date" class="filter" id="datepicker-start" />
        </div>
        <div class="picker">
          <p class="picker-heading">Check-out date</p>
          <input type="date" name="booking-end-date" class="filter" id="datepicker-end" />
        </div>
        <div class="picker">
          <p class="picker-heading">Price</p>
          <div id="priceranges">
            <input v-model="priceFrom" type="number" placeholder="From" name="pricerange" class="filter"
              id="pricerange">
            <input v-model="priceTo" type="number" placeholder="To" name="pricerange" class="filter" id="pricerange">
          </div>
        </div>
        <div class="picker">
          <p class="picker-heading">Location</p>
          <input list="options" placeholder="Select location" name="location" class="filter" id="location" />
          <datalist id="options">
            <option value="Option 1"></option>
            <option value="Option 2"></option>
            <option value="Option 3"></option>
            <option value="Option 4"></option>
          </datalist>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import ButtonWhite from "../components/ButtonWhite.vue";
import WelcomeText from "../components/WelcomeText.vue";
import CampsiteList from "../components/CampsiteList.vue";

export default {
  name: "UserHome",
  components: {
    UserHeader,
    ButtonWhite,
    WelcomeText,
    CampsiteList
  },
  data() {
    return {
      priceFrom: null,
      priceTo: null,
    };
  },
  methods: {
    CampsiteList() {
      let user = localStorage.getItem("userInfo");
      if (user) {
        this.$router.push({ name: "CampsitesPage" });
      }
      else {
        this.$router.push({ name: "UserLogin" });
      }
    },
    Search() {
      console.log(this.priceFrom)
      console.log(this.priceTo)
    }
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
};
</script>

<style scoped>
* {
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
  font-size: 16px;
  text-align: center;
}

#more-btn {
  margin-top: 60px;
}

#search-area {
  margin-top: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  align-items: center;
}

#search-box-container {
  margin-right: 10px;
}

#search-box {
  height: 46px;
  width: 400px;
  max-width: 400px;
  border-radius: 20px;
  border: none;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  outline: none;
  padding: 0px 12px;
  text-align: start;
}

.section button {
  height: 46px;
  width: 100%;
  max-width: 200px;
  font-size: 25px;
}

#filter-area {
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  gap: 20px;
  margin-top: 20px;
}

.picker {
  height: auto;
  width: 200px;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.picker-heading {
  font-size: 24px;
  padding-bottom: 10px;
  margin: 0;
}

.filter {
  width: 100%;
  max-width: 170px;
  border: none;
  border-radius: 3px;
  padding: 5px 15px;
  transition: 0.2s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}

input[type="date"]::-webkit-calendar-picker-indicator:hover {
  cursor: pointer;
  transform: scale(1.1);
}

#priceranges {
  display: flex;
  flex-direction: row;
}

#priceranges .filter {
  margin: 5px;
}
</style>
