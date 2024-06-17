<template>
  <div id="main">
    <div class="container">
      <form @submit.prevent="AddCampsite()">
        <div>
          <label for="name">Name:</label>
          <input type="text" id="name" v-model="form.name" required>
        </div>
        <div>
          <label for="location">Location:</label>
          <input type="text" id="location" v-model="form.location" required>
        </div>
        <div>
          <label for="description">Description:</label>
          <input type="text" id="description" v-model="form.description" required>
        </div>
        <div>
          <label for="pricePerDay">Price Per Day:</label>
          <input type="number" id="pricePerDay" v-model.number="form.pricePerDay" required>
        </div>
        <div>
          <label for="rating">Rating:</label>
          <input type="number" id="rate" v-model.number="form.rating" required>
        </div>
        <div>
          <label for="displayImage">Display Image URL:</label>
          <input type="url" id="displayImage" v-model="form.displayImage">
        </div>
        <ButtonWhite type="submit" text = "Submit" />
      </form>
    </div>
    <ButtonWhite v-on:click="Close()" class="close-btn" text="Close" />
  </div>
</template>



<script>
import ButtonWhite from './ButtonWhite.vue';
import axios from 'axios';

export default {
  name: "BookingProcess",
  data() {
    return {
      form: {
        name: '',
        location: '',
        description: '',
        pricePerDay: 0,
        rating: 0,
        displayImage: ''
      }
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
    Close() {
      this.$emit('closeOverlay', false)
    },
    async AddCampsite() {
      try {
        const response = await axios.post('https://localhost:5272/CampingSite', this.form);
        console.log('Response:', response.data);
        this.Close();
        this.$emit('reload');
      } catch (error) {
        console.error('There was an error!', error);
      }
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
#main {
  padding: 10px;
  background-color: #eaf7df;
  border-radius: 20px;
  border: 2px solid #c2cbc9;
}

.container {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-items: center;
}

form{
  text-align: center;
}

form div{
  font-size: 26px;
  font-weight: 500;
  margin: 20px;
  text-align: left;
}

label{
  padding: 10px;
}


.close-btn {
  position: absolute;
  top: 0;
  right: 0;
}
</style>
