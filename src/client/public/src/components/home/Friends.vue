<template>
  <div class="widget friend-list stick-widget">
    <h4 class="widget-title">Arkadaşlar</h4>
    <div id="searchDir"></div>
    <ul id="people-list" class="friendz-list">
      <li v-for="user in users" :key="user.userName">
        <figure>
          <img src="images/resources/side-friend4.jpg" alt="" />
          <span class="status f-online"></span>
        </figure>
        <div class="friendz-meta">
          <a href="time-line.html">{{user.name}}</a>
          <i
            ><a
              href="https://wpkixx.com/cdn-cgi/l/email-protection"
              class="__cf_email__"
              data-cfemail="f2859b9c869780819d9e969780b2959f939b9edc919d9f"
              >@{{user.userName}}</a
            ></i
          >
        </div>
      </li>
    </ul>
  </div>
</template>
<script>
export default {
  name: "Friends",
  data: () => {
    return {
      users: [],
    };
  },
  mounted() {
    this.$ajax.get("api/public/follower/followers").then((response) => {
      this.users = response.data;
    });
  },
};
</script>
