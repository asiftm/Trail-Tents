<template>
  <div class="campsite-container">
    <CampsiteCard
      v-for="campsite in campsites"
      :key="campsite.id"
      :campsite="campsite"
    />
  </div>
</template>

<script>
import axios from "axios";
import CampsiteCard from "../components/CampsiteCard.vue";

export default {
  name: "CampsiteList",
  data() {
    return {
      campsites: [],
      dataLength: -1,
    };
  },
  props: {
    numOfCampsiteToShow: {
      type: Number,
      default: -1,
    }
  },
  components: {
    CampsiteCard,
  },
  computed: {
    computedCampsiteLimit() {
      return this.numOfCampsiteToShow > 0 ? this.numOfCampsiteToShow : this.dataLength;
    }
  },
  methods: {
    async GetCampsites() {
      try {
        let result = await axios.get(`https://localhost:5272/CampingSite`);
        if (result.status == 200 && result.data != null) {
          this.dataLength = result.data.length;
          this.campsites = result.data.slice(0, this.computedCampsiteLimit);
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    } else {
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

.campsite-container {
  margin-top: 10px;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: space-around;
}
</style>