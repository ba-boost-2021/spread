<template>
  <Login v-if="isLogin" />
  <App v-else-if="isReady" />
</template>
<script>
import App from "./App.vue";
import Login from "./pages/Login.vue";
export default {
  name: "AppWrapper",
  components: {
    App,
    Login,
  },
  data: () => {
    return {
      isReady: false,
    };
  },
  beforeMount() {
    setTimeout(() => {
      this.isReady = true;
    }, 200);
  },
  computed: {
    isLogin() {
      return this.$route.path === "/login";
    },
  },
};
</script>
