<template>
  <div>
    <UserHeader />
    <h1>hello</h1>
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
      confirmPassword: ""
    }
  },
  components:{
    UserHeader,
  },
  mounted(){
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin"});
    }
    else{
      const user = JSON.parse(userInfo);
      this.firstname = user.firstname;
      this.lastname = user.lastname;
      this.dateOfBirth = user.dateOfBirth;
      this.email = user.email;
      this.address = user.address;
      this.contactNumber = user.contactNumber;
      this.password = user.password;
    }
  }
}
</script>