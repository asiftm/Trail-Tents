<template>
  <div>
    <h1>Hello</h1>
  </div>
</template>

<script>

export default{
  name: "AdminHome",
  mounted() {
    let adminInfo = localStorage.getItem("adminInfo");
    if (!adminInfo) {
      this.$router.push({ name: "UserLogin" });
    }
  },
}

</script>