<template>
  <div class="theme-layout">
    <Header />
    <Register />
    <Footer />
  </div>
</template>
<script>
import Register from "./Login/Register.vue";
import Header from "./Login/LoginHeader.vue";
import Footer from "../components/Footer.vue";
export default {
  name: "Login",
  components: {
    Register,
    Header,
    Footer
  },
};
</script>