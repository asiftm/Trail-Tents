<template>
  <div>
    <div>
      <UserHeader />
      <div id="campsite-area">
        <div class="campsite-container" v-for="(item, index) in dataList" :key="index" v-on:click="OpenCampsite(item.id)">
          <div class="campsite-img">
            <img :src="item.displayImage" alt="Display Image">
          </div>
          <div class="campsite-name">
            {{ item.name }}
          </div>
        </div>
      </div>
      <div id="more-btn-area">
        <ButtonWhite v-on:click = "CampsiteList()"  text="See More" />
      </div>
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
import axios from "axios";
import UserHeader from "../components/UserHeader.vue";
import ButtonWhite from "../components/ButtonWhite.vue";

export default {
  name: "UserHome",
  components: {
    UserHeader,
    ButtonWhite,
  },
  data() {
    return {
      username: "",
      dataList: [],
      priceFrom: null,
      priceTo: null,
    };
  },
  methods: {
    async GetCampsites() {
      try {
        let result = await axios.get(`https://localhost:5272/CampingSite`);
        if (result.status == 200 && result.data != null) {
          for (let i = 0; i < 5 && i < result.data.length; i++) {
            let dataDict = {
              id: result.data[i].id,
              name: result.data[i].name,
              displayImage: result.data[i].displayImage
            }
            this.dataList.push(dataDict);
          }
        }
      } catch (error) {
        console.log(error)
      }
    },
    OpenCampsite(campsiteID) {
      this.$router.push({ name: 'CampsiteView', params: { id: campsiteID } });
    },
    CampsiteList() {
      let user = localStorage.getItem("userInfo");
      if (user) {
      this.$router.push({ name: "CampsiteList" });
      }
      else{
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
    } else {
      const user = JSON.parse(userInfo);
      this.username = `${user.firstname} ${user.lastname}`;
      this.GetCampsites();
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
}

#campsite-area {
  margin-top: 30px;
  padding: 10px 30px;
  height: 240px;
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.campsite-container {
  margin: 0;
  padding: 0;
  height: 250px;
  width: 250px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  position: relative;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  border-radius: 5%;
  transition: 0.4s;
}

.campsite-container:hover {
  cursor: pointer;
  transform: scale(1.05);
}
.campsite-name {
  height: 35px;
  padding: 0;
  margin: 0;
}

.campsite-img {
  height: 200px;
  width: 220px;
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

#more-btn-area {
  margin-top: 60px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
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
