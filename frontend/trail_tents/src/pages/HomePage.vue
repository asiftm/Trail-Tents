<template>
  <div>
    <div>
      <UserHeader />
      <WelcomeText />
      <CampsiteList :numOfCampsiteToShow = 6 :searchBox = false />
      <ButtonWhite v-on:click="CampsiteList()" text="See More Campsites" id="more-btn" />
      <UserFooter id="footer" />
    </div>
  </div>
</template>

<script>
import UserHeader from "../components/UserHeader.vue";
import ButtonWhite from "../components/ButtonWhite.vue";
import WelcomeText from "../components/WelcomeText.vue";
import CampsiteList from "../components/CampsiteList.vue";
import UserFooter from "../components/UserFooter.vue";

export default {
  name: "UserHome",
  components: {
    UserHeader,
    ButtonWhite,
    WelcomeText,
    CampsiteList,
    UserFooter
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
  background-color: #eaf7df;
}

#more-btn {
  margin-top: 20px;
}
#footer{
  margin-top: 100px;
}

</style>
