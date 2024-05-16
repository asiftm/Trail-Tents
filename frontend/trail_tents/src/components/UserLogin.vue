<template>
  <div class="container">
    <div class="login form">
      <header>Login</header>
      <form>
        <input type="text" placeholder="Enter your email" />
        <input type="password" placeholder="Enter your password" />
        <button class="button">Login</button>
      </form>
      <div class="signup">
        <span class="signup">
          Don't have an account?
          <label>Signup</label>
        </span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "UserLogin",
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
body {
  min-height: 100vh;
  width: 100%;
  background: #009579;
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
  margin-bottom: 1rem;
}
.form input, button {
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
}
.form .button:hover {
  background: #006653;
}
.signup {
  font-size: 17px;
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
