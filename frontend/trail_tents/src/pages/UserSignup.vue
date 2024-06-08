<template>
  <div>
    <div :class="{ 'blur-background': isSuccessfull }">
      <div class="main">
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
              <p class="message">{{ message }}</p>
              <button class="button" v-on:click.prevent="CheckFields()">Signup</button>
            </form>
            <div class="signup">
              <span class="signup">Already have an account?
                <label for="check" v-on:click="LoadLoginPage()">Login</label>
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div id="success-container" v-if="isSuccessfull">
      <p id="success-txt">SignUp Successfull</p>
      <button id="success-login-btn" v-on:click="LoadLoginPage()">Go to Login</button>
    </div>
  </div>
</template>''

<script>
import axios from "axios";
export default {
  name: "UserSignup",
  data() {
    return {
      firstname: "",
      lastname: "",
      dateOfBirth: "",
      email: "",
      address: "",
      contactNumber: "",
      password: "",
      confirmPassword: "",
      message: "",
      isSuccessfull: true,
    }
  },
  methods: {
    async CheckFields() {
      if (this.firstname.length > 0 && this.lastname.length > 0 && this.email.length > 0 && this.address.length > 0 && this.contactNumber.length > 0 && this.password.length > 0) {
        if (this.password == this.confirmPassword) {
          if (await this.UniqueEmail()) {
            await this.SignUp();
          }
          else {
            this.message = "Use unique Email";
          }
        }
        else {
          this.message = "Passwords are not same";
        }
      }
      else {
        this.message = "Fill all fields";
      }
    }
    ,
    async UniqueEmail() {
      let decision = await axios.get(`https://localhost:5272/User/${this.email}/UniqueEmail`);
      return decision.data;
    }
    ,
    async SignUp() {
      let result = await axios.post("https://localhost:5272/User", {
        firstname: this.firstname,
        lastname: this.lastname,
        dateOfBirth: this.dateOfBirth,
        email: this.email,
        address: this.address,
        contactNumber: this.contactNumber,
        password: this.password,
        profilePicture: "",
      });
      if (result.status == 200) {
        this.isSuccessfull = true;
      }
    },
    LoadLoginPage() {
      this.$router.push({ name: "UserLogin" });
    }
  },
  mounted() {
    let user = localStorage.getItem("userInfo");
    if (user) {
      this.$router.push({ name: "UserHome" })
    }
  }
};
</script>

<style scoped>
/* Import Google font - Poppins */
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
}

.main {
  display: flex;
  justify-content: center;
  align-items: center;
}

.container {
  max-width: 530px;
  width: 100%;
  background: #fff;
  border-radius: 7px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
}

.container .form {
  padding: 1rem 2rem;
}

.form header {
  font-size: 2rem;
  font-weight: 600;
  text-align: center;
}

.form input,
button {
  height: 44px;
  width: 100%;
  padding: 0 15px;
  margin: 7px 0px;
  font-size: 18px;
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
  font-size: 24px;
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

.message {
  color: red;
}

.signup,
.message {
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

#success-container {
  position: fixed;
  top: 30%;
  left:37%;
  background-color: #ffffff;
  height: 200px;
  width: 400px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  padding: 20px;
  border: solid gray 2px;
  border-radius: 10px;
  z-index: 1000;
}

#success-txt {
  font-size: 24px;
  font-weight: 600;
}

#success-login-btn {
  width: 150px;
  margin-top: 30px;
  background-color: #009579;
  color: white;
  border: none;
}

#success-login-btn:hover {
  background: #006653;
}

.blur-background {
  filter:opacity(30%);
  pointer-events: none;
}
</style>
