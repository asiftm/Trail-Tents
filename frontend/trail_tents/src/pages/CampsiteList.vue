<template>
  <div>
    <UserHeader />
    <div class="campsite-container">
      <CampsiteCard v-for="campsite in campsites" :key="campsite.id" :campsite="campsite" />
    </div>
    
  </div>
</template>

<script>
import CampsiteCard from "../components/CampsiteCard.vue";
import UserHeader from "../components/UserHeader.vue";
import axios from 'axios';

export default {
  name: "CampsiteList",
  data() {
    return {
      campsites: [],
    }
  },
  components: {
    CampsiteCard,
    UserHeader
  },
  methods: {
    async GetCampsites() {
      try {
        let result = await axios.get(`https://localhost:5272/CampingSite`);
        if (result.status == 200 && result.data != null) {
          this.campsites = result.data;
        }
      } catch (error) {
        console.log(error)
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

.campsite-container{
  display: flex;
  flex-direction: row ;
  flex-wrap: wrap;
  justify-content: space-around;
}
</style>