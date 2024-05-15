<template>  
  <div class="content">
  <div class="text">
    Login Form
  </div>
  <form action="#">
    <div class="field">
      <input type="text" required>
      <label>Email or Phone</label>
    </div>
    <div class="field">
      <input type="password" required>
      <span class="fas fa-lock"></span>
      <label>Password</label>
    </div>
    <div class="forgot-pass">
      <a href="#">Forgot Password?</a>
    </div>
    <button>Sign in</button>
    <div class="sign-up">
      Not a member?
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
