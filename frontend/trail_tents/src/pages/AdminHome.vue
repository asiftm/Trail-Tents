<template>
  <div class="main">
    <div>
      <AdminHeader />
      <div id="add-btn">
        <ButtonWhite v-on:click="ToggleOverlay(true)" text="Add Campsite" />
      </div>
      <CampsiteList />
    </div>
    <div v-if="isOverlay" id="addCampsiteOverlay">
      <AddCampsite @closeOverlay="ToggleOverlay()" @reload="Reload()" />
    </div>
  </div>
</template>

<script>
import AdminHeader from '../components/AdminHeader.vue';
import CampsiteList from "../components/CampsiteList.vue";
import ButtonWhite from '../components/ButtonWhite.vue';
import AddCampsite from '../components/AddCampsite.vue';

export default {
  name: "AdminHome",
  data() {
    return {
      isAdmin: true,
      isOverlay: false,
    }
  },
  components: {
    AdminHeader,
    CampsiteList,
    ButtonWhite,
    AddCampsite
  },
  methods: {
    ToggleOverlay(value) {
      this.isOverlay = value;
    },
    Reload(){
      window.location.reload();
    }
  },
  mounted() {
    let adminInfo = localStorage.getItem("adminInfo");
    if (!adminInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
}

</script>

<style scoped>
#add-btn {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#addCampsiteOverlay {
  padding: 10px;
  width: 1000px;
  position: absolute;
  top: 100px;
  left:250px;
}
</style>