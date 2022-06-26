<template>
  <div class="topbar stick">
    <div class="logo">
      <a title="spread" class="logo" href="newsfeed.html"
        ><img src="/images/logo.svg" alt=""
      /></a>
      spread
    </div>

    <div class="top-area">
      <div class="login-form">
        <input type="text" placeholder="User Name" />
        <input type="password" placeholder="Passoword" />
        <button type="submit">Giriş Yap</button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "LoginHeader",
  data: () => {
    return {
      username: null,
      password: null,
    };
  },
};
</script>
<style scoped>
.logo {
  font-size: 18px;
  font-weight: bold;
}
</style>
