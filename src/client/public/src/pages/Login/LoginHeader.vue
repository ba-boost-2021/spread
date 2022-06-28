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
        <input
          type="text"
          :class="{ invalid: usernameInvalid }"
          placeholder="kullanıcı adı"
          v-model="username"
        />
        <input
          type="password"
          :class="{ invalid: passwordInvalid }"
          placeholder="şifre"
          v-model="password"
        />
        <button @click="login">Giriş Yap</button>
        <div class="invalid-login" v-if="hasError">
          <Message title="Giriş Başarısız" severity="error"></Message>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Message from "../../components/Message.vue";
export default {
  name: "LoginHeader",
  components: {
    Message,
  },
  data: () => {
    return {
      username: null,
      password: null,
      usernameInvalid: false,
      passwordInvalid: false,
      hasError: false,
    };
  },
  methods: {
    login() {
      this.hasError = false;
      if (this.isInvalid()) {
        return;
      }
      const data = {
        username: this.username,
        password: this.password,
      };
      this.$ajax
        .post("api/authentication/login", data)
        .then((response) => {
          this.$store.commit("session/setToken", response.data.token);
          this.$store.commit("session/setDisplayName", response.data.displayName);
          this.$router.push("/");
        })
        .catch(() => {
          this.hasError = true;
        });
    },
    isInvalid() {
      this.usernameInvalid = false;
      this.passwordInvalid = false;
      if (!this.username) {
        this.usernameInvalid = true;
      }
      if (!this.password) {
        this.passwordInvalid = true;
      }
      return this.usernameInvalid || this.passwordInvalid;
    },
  },
};
</script>
<style scoped>
.logo {
  font-size: 18px;
  font-weight: bold;
}
.invalid {
  border-bottom: 1px solid var(--danger);
}
.invalid-login {
    position: absolute;
    right: 55px;
    width: 560px;
}
</style>
