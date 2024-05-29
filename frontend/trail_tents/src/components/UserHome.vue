<template>
  <div>
    <div v-bind:class="{ 'sidebar': true, 'sidebar-open': isSidebarOpen }">
      <!-- <button v-on:click="ToggleSidebar()" class="close-btn">Close</button> -->
      <p id="username">{{username}}</p>
      <ul class="menu-options">
        <li v-on:click="UserProfile()">Edit Profile</li>
        <li v-on:click="UserBookings()">My Bookings</li>
        <li v-on:click="UserReviews()">My Reviews</li>
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
    <div class="section">
      <div id="campsite-area">
        <div class="campsite-container">
          <div class="site-photo">

          </div>
          <div class="book-container">
            <button class="book-btn">Book</button>
          </div>
        </div>
        <div class="campsite-container">
          <div class="site-photo">

          </div>
          <div class="book-container">
            <button class="book-btn">Book</button>
          </div>
        </div>
        <div class="campsite-container">
          <div class="site-photo">

          </div>
          <div class="book-container">
            <button class="book-btn">Book</button>
          </div>
        </div>
        <div class="campsite-container">
          <div class="site-photo">

          </div>
          <div class="book-container">
            <button class="book-btn">Book</button>
          </div>
        </div>
        <div class="campsite-container">
          <div class="site-photo">

          </div>
          <div class="book-container">
            <button class="book-btn">Book</button>
          </div>
        </div>
        <div class="campsite-container">
          <div class="site-photo">
              
          </div>
          <div class="book-container">
            <button class="book-btn">Book</button>
          </div>
        </div>
      </div>
      <div id="more-btn-area">
        <button id="more-btn">
            See More
          </button>
      </div>
      <div id="search-area">
        <div id="search-box-container">
          <input id="search-box" type="text" placeholder="Campsite name">
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
    </div>
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
    },
    UserProfile(){
      this.$router.push({name:"UserProfile"})
    },
    UserBookings(){
      this.$router.push({name:"UserBookings"})
    },
    UserReviews(){
      this.$router.push({name:"UserReviews"})
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
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
  font-size: 16px;
}
.header {
  height: 80px;
  display: flex;
  justify-content: space-between;
  z-index: 100;
  color: #313638;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  border-radius: 10px;
}

.left{
  display: flex;
  flex-direction: row;
  align-items: center;
  margin-left: 20px;
}

.logo img {
  height: 60px;
}

.left p {
  margin: 7px 0 10px 5px;
  font-family: "Stick", sans-serif;
}

.right{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: end;
  margin-right: 20px;
}

.right button{
  padding: 5px 8px;
  margin: 0 3px;
  border: none;
  border-radius: 20px;
  background-color: #F3CA52;
  transition: 0.3s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}

.right button, .close-btn, .menu-options li:hover {
  transform: scale(1.05);
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
  top: 10px;
  bottom: 10px;
  right: -400px;
  width: 300px;
  background-color: #F3CA52;
  box-shadow: -2px 0 5px rgba(0, 0, 0, 0.5);
  transition: right 0.5s;
  z-index: 300;
  display: flex;
  flex-direction: column;
  padding: 20px;
  border-radius: 10px;
}

.sidebar-open {
  right: 0;
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
  background-color: #F6E9B2;
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

#logout-btn{
  margin-top: auto;
  border-radius: 5px;
  border: none;
  padding: 10px;
  transition: 0.3s;
  background-color: #0A6847;
  color: #fff;
}
#logout-btn:hover{
  cursor: pointer;
  background-color: #006653;
  transform: scale(1.05);
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

#campsite-area{
  margin-top: 30px;
  padding: 10px 30px;
  height: 240px;
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.campsite-container{
  height: 220px;
  width: 220px;
  background-color: greenyellow;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  position: relative;
}

.book-container{
  position: absolute;
  top: 210px;
  left: 190px;
}

.book-btn{
  background-color: #F3CA52;
  border: none;
  border-radius: 50px;
  padding: 2px 5px;
}

#more-btn-area {
  margin-top: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  align-items:center;
}

#search-area {
  margin-top: 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  align-items:center;
}

#search-box-container{
  margin-right: 10px;
}

#search-box {
  height: 46px;
  width: 400px;
  max-width: 400px;
  border-radius: 20px;
  border: none;
  background-color: #F3CA52;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  outline: none;
  padding: 0px 12px;
}

#search-btn,#more-btn {
  height: 46px;
  width: 100%;
  max-width: 200px;
  border-radius: 20px;
  border: none;
  background-color:#F3CA52;
  padding: 0px 10px 5px 10px;
  font-size:25px;
  transition: 0.2s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}

#search-btn:hover{
  transform: scale(1.1);
  cursor: pointer;
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
  width: 180px;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.picker-heading{
  font-size: 24px;
  padding-bottom: 10px;
  margin: 0;
}

.datepicker {
  width: 100%;
  max-width: 170px;
  background-color: #F3CA52;
  border: none;
  border-radius: 3px;
  padding: 5px 15px;
  transition: 0.2s;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}

input[type="date"]::-webkit-calendar-picker-indicator {
  background-color: #F3CA52;
}

input[type="date"]::-webkit-calendar-picker-indicator:hover {
  cursor: pointer;
  transform: scale(1.1);
}

</style>