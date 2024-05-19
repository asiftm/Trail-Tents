<template>
  <div>
    <div v-bind:class="{ 'sidebar': true, 'sidebar-open': isSidebarOpen }">
      <button v-on:click="ToggleSidebar()" class="close-btn">Close</button>
      <p id="username">{{username}}</p>
      <ul class="menu-options">
        <li>Edit Profile</li>
        <li>My Bookings</li>
        <li>My Reviews</li>
      </ul>
      <button v-on:click="Logout()" id="logout-btn">Log Out</button>
    </div>
    <div class="overlay" v-if="isSidebarOpen" v-on:click="ToggleSidebar()"></div>
    <div class="header">
      <div class="left">
        <div class="logo">
          <img src="../assets/logo.png" alt="" />
        </div>
        <div class="name">
          <p>Trail Tents</p>
        </div>
      </div>
      <div class="right">
        <button v-on:click="ToggleSidebar()">Menu</button>
      </div>
    </div>
    <!-- <div class="main" id="main">
    <div class="section" id="welcome-section">
      <div class="heading" id="welcome-txt">
        Welcome to 
        <p id="main-title">Trail Tents</p>
        <p id="welcome-moto">Explore. Equip. Embrace the Outdoors.</p>
      </div>
      <div id="search-area">
        <div id="search-box-container">
          <input id="search-box" type="text">
        </div>
        <div id="search-btn-container">
          <button id="search-btn">
            Search
          </button>
        </div>
      </div>
      <div id="filter-area">
        <div class="picker">
          <p class="picker-heading">Check-in date</p>
          <input type="date" name="booking-start-date" class="datepicker" id="datepicker-start">
        </div>
        <div class="picker">
          <p class="picker-heading">Check-out date</p>
          <input type="date" name="booking-end-date" class="datepicker" id="datepicker-end">
        </div>
        <div class="picker">
          <p class="picker-heading">Price</p>
          <input type="date" name="booking-end-date" class="datepicker" id="datepicker-end">
        </div>
      </div>
      <div id="welcome-paragraph-container">
        <p id="welcome-paragraph">Escape to nature and explore the great outdoors with us!</p>
      </div>
    </div>
  </div> -->
  </div>
</template>

<script>
export default {
  name: "UserHome",
  data(){
    return{
      username: "",
      isSidebarOpen: false,
    }
  },
  methods:{
    ToggleSidebar() {
      if(this.isSidebarOpen){
        this.isSidebarOpen = false;
      }
      else{
        this.isSidebarOpen = true;
      }
    },
    Logout(){
      localStorage.clear();
      this.$router.push({name:"UserLogin"});
    }
  },
  mounted(){
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin"});
    }
    else{
      const user = JSON.parse(userInfo);
      this.username = `${user.firstname} ${user.lastname}`;
    }
  }
};
</script>


<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Poppins", sans-serif;
}
.header {
  height: 60px;
  display: flex;
  justify-content: space-between;
  font-size: 14px;
  font-weight: bolder;
  z-index: 100;
  background-color: #D7E4C0;
  color: #313638;
}

.left{
  display: flex;
  flex-direction: row;
  align-items: center;
}

.logo img {
  height: 40px;
}

.left p {
  margin: 7px 0 10px 5px;
}

.right{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: end;
}

.right button{
  padding: 5px 8px;
  margin: 0 3px;
  border: none;
  border-radius: 20px;
  background-color: #19747E;
  color: #D7E4C0;
  font-weight: 500;
  transition: 0.3s;
}

.right button, .close-btn, .menu-options li:hover {
  transition: transform 0.2s;
  transform: scale(1.1);
  cursor: pointer;
}

.menu-overlay{
  z-index: 100;
  position: absolute;
  justify-content: end;
  width: 20%;
  height: 100%;
  background-color: rgba(0,0,0,0.77);
}

.sidebar {
  position: fixed;
  top: 0;
  right: -400px;
  width: 300px;
  height: 100%;
  background-color: #D7E4C0;
  box-shadow: -2px 0 5px rgba(0, 0, 0, 0.5);
  transition: right 0.5s;
  z-index: 300;
  display: flex;
  flex-direction: column;
  padding: 20px;
}

.sidebar-open {
  right: 0;
}

.close-btn {
  padding: 5px;
  align-self: flex-start;
  border: none;
  border-radius: 30px;
  background-color: #135D66;
  color: #D7E4C0;
  font-weight: 500;
  transition: 0.3s;
  font-size: 10px;
  height: 30px;
}

#username{
  align-self: flex-end;
}

.menu-options {
  list-style: none;
  padding: 0;
  margin: 20px 0 0 0;
}

.menu-options li {
  margin: 10px 0;
  padding: 10px;
  background-color: #fff;
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

#logout-btn{
  margin-top: auto;
  border-radius: 5px;
  border: none;
  padding: 10px;
  font-weight: 500;
  transition: 0.3s;
  background-color: #003C43;
  color: #D7E4C0;
}
#logout-btn:hover{
  transition: transform 0.2s;
  transform: scale(1.05);
  cursor: pointer;
}

.overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 250;
}
</style>