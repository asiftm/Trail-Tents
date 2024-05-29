<template>
  <div class="container">
    <div class="registration form">
      <header>Signup</header>
      <form class="form">
        <input type="text" placeholder="Enter your Firstname" v-model="firstname" /> 
        <input type="text" placeholder="Enter your Lastname" v-model="lastname" />
        <input id="datepicker" type="date" placeholder="Enter your Date of birth" v-model="dateOfBirth" />
        <input type="text" placeholder="Enter your Email" v-model="email" />
        <input type="text" placeholder="Enter your Address" v-model="address" />
        <input type="text" placeholder="Enter your Contact Number" v-model="contactNumber" />
        <input type="password" placeholder="Create a password" v-model="password" />
        <input type="password" placeholder="Confirm your password" v-model="confirmPassword" />
        <p class = "message" >{{ message }}</p>
        <button class="button" v-on:click.prevent="CheckFields()">Signup</button>
      </form>
      <div class="signup">
        <span class="signup"
          >Already have an account?
          <label for="check" v-on:click="LoadLoginPage()">Login</label>
        </span>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "UserSignup",
  data(){
    return{
      firstname: "",
      lastname: "",
      dateOfBirth: "",
      email: "",
      address: "",
      contactNumber: "",
      password: "",
      confirmPassword: "",
      message: ""
    }
  },
  methods: {
    CheckFields(){
      if(this.firstname.length > 0 && this.lastname.length > 0 && this.email.length > 0 && this.address.length > 0 && this.contactNumber.length > 0 && this.password.length > 0)
      {
        if(this.password == this.confirmPassword)
        {
          if(this.UniqueEmail() == true)
          {
            this.SignUp();
          }
          else
          {
            this.message = "Use unique password";
          }
        }
        else{
          this.message = "Passwords are not same";
        }
      }
      else{
        this.message ="Fill all fields";
      }
    }
    ,
    async UniqueEmail(){
      let decision = await axios.get(`https://localhost:5272/User/${this.email}/UniqueEmail`);
      console.log(decision.data)
      if(decision.data.value == true) return true;
      return false;
    }
    ,
    async SignUp(){
      let result = await axios.post("https://localhost:5272/User", {
        firstname: this.firstname,
        lastname: this.lastname,
        dateOfBirth: this.dateOfBirth,
        email: this.email,
        address: this.address,
        contactNumber: this.contactNumber,
        password: this.password
      });
      console.log(result)
      if(result.status == 200){
        this.$router.push({name:"UserLogin"});
      }
    },
    LoadLoginPage(){
      this.$router.push({name:"UserLogin"});
    }
  },
  mounted(){
    let user = localStorage.getItem("userInfo");
    if(user){
      this.$router.push({name:"UserHome"})
    }
  }
};
</script>

<style scoped>
/* Import Google font - Poppins */
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Poppins", sans-serif;
}
.container {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  max-width: 430px;
  width: 100%;
  background: #fff;
  border-radius: 7px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}
.container .form {
  padding: 2rem;
}
.form header {
  font-size: 2rem;
  font-weight: 500;
  text-align: center;
}
.form input,
button {
  height: 40px;
  width: 100%;
  padding: 0 15px;
  font-size: 14px;
  margin-bottom: 1rem;
  border: 1px solid #ddd;
  border-radius: 6px;
  outline: none;
}
.form input:focus {
  box-shadow: 0 1px 0 rgba(0, 0, 0, 0.2);
}
.form a {
  font-size: 16px;
  color: #009579;
  text-decoration: none;
}
.form a:hover {
  text-decoration: underline;
}

.button {
  color: #fff;
  background: #009579;
  font-size: 1.2rem;
  font-weight: 500;
  letter-spacing: 1px;
  margin-top: .5rem;
  cursor: pointer;
  transition: 0.4s;
  margin-bottom: 0rem;
}
.button:hover {
  background: #006653;
}

.message{
  color: red;
}

.signup, .message {
  font-size: 15px;
  text-align: center;
}
.signup label {
  color: #009579;
  cursor: pointer;
}
.signup label:hover {
  text-decoration: underline;
}
</style>
