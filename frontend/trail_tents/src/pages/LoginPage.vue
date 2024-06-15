<template>
  <div class="main">
    <WelcomeText />
    <div class="container">
      <div class="login form">
        <header>Login</header>
        <form>
          <input type="text" placeholder="Enter your email" v-model="email" />
          <input type="password" placeholder="Enter your password" v-model="password" />
          <p>{{ errorMessage }}</p>
          <button class="button" v-on:click.prevent="LoginRequirements()">
            Login
          </button>
        </form>
        <div class="forgetPassword">
          <label v-on:click="LoadSignUpPage()">Forget Password?</label>
        </div>
        <div class="signup">
          <span class="signup">
            Don't have an account?
            <label v-on:click="LoadSignUpPage()">Signup</label>
          </span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import WelcomeText from '../components/WelcomeText.vue';
export default {
  name: "UserLogin",
  data() {
    return {
      email: "a@admin",
      password: "a",
      errorMessage: "",
    };
  },

  components: {
    WelcomeText,
  },
  methods: {
    LoadSignUpPage() {
      this.$router.push({ name: "UserSignup" });
    },
    async AdminLogin(email) {
      try {
        let result = await axios.get(
          `https://localhost:5272/Admin/Verification?email=${email}&password=${this.password}`
        );
        if (result.status == 200 && result.data != null) {
          localStorage.setItem("adminInfo", JSON.stringify(result.data));
          this.$router.push({ name: "AdminHome" });
        } else {
          this.errorMessage = "Wrong email or password!";
        }
      }catch (error) {
        this.errorMessage = "An error occurred. Please try again.";
      }
    }
    ,
    async Login() {
      try {
        let result = await axios.get(
          `https://localhost:5272/User/Verification?email=${this.email}&password=${this.password}`
        );

        if (result.status == 200 && result.data != null) {
          localStorage.setItem("userInfo", JSON.stringify(result.data));
          this.$router.push({ name: "UserHome" });
        } else {
          this.errorMessage = "Wrong email or password!";
        }
      } catch (error) {
        this.errorMessage("An error occurred. Please try again.");
      }
    },
    LoginRequirements() {
      if (this.email.length > 0 && this.password.length > 0) {
        if (!this.email.includes("@admin")) {
          this.Login();
        }
        else {
          this.AdminLogin(this.email.replace("@admin", ""));
        }
      } else {
        this.errorMessage = "Fill email and password!";
      }
    },
  },
  mounted() {
    let user = localStorage.getItem("userInfo");
    if (user) {
      this.$router.push({ name: "UserHome" });
    }
  },
};
</script>

<style scoped>
/* Import Google font - Poppins */
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
@import url('https://fonts.googleapis.com/css2?family=Stick&family=Tienne:wght@400;700;900&family=Fira+Code:wght@300..700&family=Ysabeau+Infant:ital,wght@0,1..1000;1,1..1000&display=swap');

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Poppins", sans-serif;
  overflow: hidden;
}

.main {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-items: center;
}

.heading {
  text-align: center;
}

#welcome-txt {
  font-size: 50px;
  font-family: "Ysabeau Infant", sans-serif;
  font-weight: 600;
  color: black;
}

#main-title {
  font-size: 80px;
  font-family: "Stick", sans-serif;
}

#welcome-moto {
  font-size: 30px;
  font-weight: 400;
}

.container {
  max-width: 430px;
  width: 100%;
  background-color: #ffffff;
  border-radius: 7px;
  margin-left: -260px;
  margin-top: 130px;
}

.container .form {
  padding: 2rem;
}

.form header {
  font-size: 2rem;
  font-weight: 500;
  text-align: center;
  margin-bottom: 1rem;
}

.form input,
button {
  height: 50px;
  width: 100%;
  padding: 0 15px;
  font-size: 17px;
  margin-bottom: 1rem;
  border: 1px solid #ddd;
  border-radius: 6px;
  outline: none;
}

.form input:focus {
  box-shadow: 0 1px 0 rgba(0, 0, 0, 0.2);
}

.form .button {
  color: #fff;
  background: #009579;
  font-size: 1.2rem;
  font-weight: 500;
  letter-spacing: 1px;
  margin-top: 1.7rem;
  cursor: pointer;
  transition: 0.4s;
  border-radius: 10px;
  padding: 10px;
}

.form p {
  margin-bottom: -10px;
  color: red;
}

.form .button:hover {
  background: #006653;
  cursor: pointer;
  transform: scale(1.1);
}

.signup,
p,
.forgetPassword {
  font-size: 17px;
  text-align: center;
}

.signup label,
.forgetPassword label {
  color: #009579;
  cursor: pointer;
}

.signup label:hover,
.forgetPassword label:hover {
  text-decoration: underline;
}

#circle1 {
  position: absolute;
  z-index: -10;
  height: 2000px;
  width: 2000px;
  border-radius: 50%;
  background-color: #163020;
  left: 80%;
}

#circle2 {
  position: absolute;
  z-index: -20;
  height: 2000px;
  width: 2000px;
  border-radius: 50%;
  background-color: #304D30;
  left: 60%;
}

#circle3 {
  position: absolute;
  z-index: -30;
  height: 2000px;
  width: 2000px;
  border-radius: 50%;
  background-color: #B6C4B6;
  left: 40%;
}

#circle4 {
  position: absolute;
  z-index: -40;
  height: 2000px;
  width: 2000px;
  border-radius: 50%;
  background-color: #EEF0E5;
  left: 20%;
}
</style>
