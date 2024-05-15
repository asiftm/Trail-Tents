<template>  
  <div class="content">
  <div class="text">
    Signup Form
  </div>
  <form action="#">
    <div class="field">
      <input type="text" required>
      <span class="fas fa-user"></span>
      <label>Firstname</label>
    </div>
    <div class="field">
      <input type="text" required>
      <span class="fas fa-user"></span>
      <label>Lastname</label>
    </div>
    <div class="field">
      <input type="text" required>
      <span class="fas fa-user"></span>
      <label>Date Of Birth</label>
    </div>
    <div class="field">
      <input type="text" required>
      <span class="fas fa-user"></span>
      <label>Email</label>
    </div>
    <div class="field">
      <input type="text" required>
      <span class="fas fa-user"></span>
      <label>Address</label>
    </div>
    <div class="field">
      <input type="text" required>
      <span class="fas fa-user"></span>
      <label>Contact Number</label>
    </div>
    <div class="field">
      <input type="password" required>
      <span class="fas fa-lock"></span>
      <label>Password</label>
    </div>
    <div class="field">
      <input type="password" required>
      <span class="fas fa-lock"></span>
      <label>Password</label>
    </div>
    <button>Sign in</button>
    <div class="sign-up">
      Already a member?
      <a href="#">signup now</a>
    </div>
  </form>
</div>
</template>
<script>
import '../assets/login.css';
export default {
  name: 'Login'
}
</script>
