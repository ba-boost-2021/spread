<template>
  <div class="widget stick-widget">
    <h4 class="widget-title">Takip İstekleri</h4>
    <ul class="followers">
      <li v-for="user in users" :key="user.userName">
        <figure>
          <img src="images/resources/side-friend8.jpg" alt="" />
        </figure>
        <div class="friend-meta">
          <h4>
            <a href="time-line.html" title="">{{user.name}}</a>
          </h4>
          <a @click="accept(user.userName)" title="" class="underline">Kabul Et</a>
        </div>
      </li>
    </ul>
  </div>
</template>
<script>
export default {
  name: "Followers",
  data: () => {
    return {
      users: [],
    };
  },
  mounted() {
    this.$ajax.get("api/public/follower/requests").then((response) => {
      this.users = response.data;
    });
  },
  methods: {
    accept(userName) {
      alert(userName);
    }
  }
};
</script>
