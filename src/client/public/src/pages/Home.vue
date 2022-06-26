<template>
  <div class="theme-layout">
    <section>
      <div class="gap gray-bg">
        <div class="container-fluid">
          <div class="row">
            <div class="col-lg-12">
              <div class="row" id="page-contents">
                <div class="col-lg-3">
                  <aside class="sidebar static">
                    <QuickLinks />
                    <RecentActivities />
                    <Followers />
                  </aside>
                </div>

                <div class="col-lg-6">
                  <Post />
                  <Feed />
                </div>
                <div class="col-lg-3">
                  <aside class="sidebar static">
                    <Profile />
                    <Friends />
                  </aside>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <Footer />
  </div>
</template>
<script>
import Post from "../components/home/Post.vue";
import Friends from "../components/home/Friends.vue";
import Profile from "../components/home/Profile.vue";
import Feed from "../components/home/Feed.vue";
import Followers from "../components/home/Followers.vue";
import RecentActivities from "../components/home/RecentActivities.vue";
import QuickLinks from "../components/home/QuickLinks.vue";
import Footer from "../components/Footer.vue";
export default {
  name: "Home",
  components: {
    Post,
    Friends,
    Profile,
    Feed,
    Followers,
    RecentActivities,
    QuickLinks,
    Footer,
  },
};
</script>
