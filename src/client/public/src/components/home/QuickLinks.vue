<template>
  <div class="widget">
    <h4 style="padding: 10px; padding-left: 25px">
      <img src="/images/logo.svg" alt="" />spread
    </h4>
    <ul class="naves">
      <li>
        <i class="ti-clipboard"></i>
        <a href="newsfeed.html" title="">News feed</a>
      </li>
      <li>
        <i class="ti-mouse-alt"></i>
        <a href="inbox.html" title="">Inbox</a>
      </li>
      <li>
        <i class="ti-power-off"></i>
        <a @click="logOut" title="">Çıkış Yap</a>
      </li>
    </ul>
  </div>
</template>
<script>
export default {
  name: "QuickLinks",
  methods: {
    logOut() {
      this.$store.commit("session/logOut");
      this.$router.push("/login");
    }
  }
};
</script>
