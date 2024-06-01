<template>
  <div>
    <UserHeader />
    <div class="profile-container">
      <div class="left-right-container" id="left-container">
        <div class="left-container-item" id="profile-photo-container">
          <img :src="profilePicture" alt="">
          <button>Upload Photo</button>
        </div>
        <div class="left-container-item" id="username-container">
          <p>{{ firstname + " " + lastname }}</p>
        </div>
      </div>
      <div class="left-right-container" id="right-container">
        <p id="my-details-lbl">My Details</p>
        <div class="right-details-container">
          <div class="details-container">
            <div class="details-lbl"><p>Firstname</p></div>
            <div class="details-input-container"><input type="text" class="userinput" v-model="firstname"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Lastname</p></div>
            <div class="details-input-container"><input type="text" class="userinput" v-model="lastname"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Date of Birth</p></div>
            <div class="details-input-container"><input type="text" class="userinput" v-model="dateOfBirth"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Email</p></div>
            <div class="details-input-container"><input type="text" class="userinput" v-model="email"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Address</p></div>
            <div class="details-input-container"><input type="text" class="userinput" v-model="address"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Contact Number</p></div>
            <div class="details-input-container"><input type="text" class="userinput" v-model="contactNumber"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Password</p></div>
            <div class="details-input-container"><input type="password" class="userinput" v-model="password"></div>
          </div>
          <div class="details-container">
            <div class="details-lbl"><p>Confirm Password</p></div>
            <div class="details-input-container"><input type="password" class="userinput" v-model="confirmPassword"></div>
          </div>
        </div>
        <div id="right-button-container">
          <button>Reset</button>
          <button>Save</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
//import axios from "axios";
import UserHeader from "./UserHeader.vue";
export default{
  name: "UserProfile",
  data(){
    return{
      firstname: "",
      lastname: "",
      dateOfBirth: "",
      email: "",
      address: "",
      contactNumber: "",
      password: "",
      profilePicture: "",
    }
  },
  components:{
    UserHeader,
  },
  methods: { 
    
  },
  mounted(){
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin"});
    }
    else{
      const user = JSON.parse(userInfo);
      console.log(user)
      this.firstname = user.firstname;
      this.lastname = user.lastname;
      this.dateOfBirth = user.dateOfBirth;
      this.email = user.email;
      this.address = user.address;
      this.contactNumber = user.contactNumber;
      this.password = user.password;
      this.profilePicture = user.profilePicture;
    }
  }
}
</script>

<style>
* {
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
}

.profile-container{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 5px;
}

.left-right-container{
  height: 100%;
  margin: 5px;
}

#left-container{
  width: 30%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.left-container-item{
  height: 45%;
  width: 95%;
  margin: 5px;
  text-align: center;
}

#profile-photo-container{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

#profile-photo-container img{
  width: 250px;
  height: 250px;
  object-fit: cover;
  margin-bottom: 20px;
}

#username-container{
  font-size: 34px;
  font-weight: 600;
}

#right-container{
  width: 70%;
  font-size: 18px;
}

.right-details-container{
  display: grid;
  grid-template-columns: repeat(2, 1fr);
}

#my-details-lbl{
  font-size: 44px;
  font-weight: 600;
  margin: 10px;
}

.details-container{
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  justify-content: center;
  align-items: center;
  margin: 0px 15px;
}

.details-lbl{
  font-size: 24px;
}

.details-input-container input{
  width: 100%;
  height: 45px;
  border-radius: 5px;
  border: none;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  padding: 2px;
  font-size: 20px;
  font-weight: 600;
}

#right-button-container{
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
}

#right-button-container button{
  height: 50px;
  width: 100px;
  margin: 30px 50px 0px 0px;
}

</style>