<template>
  <div class="widget">
    <div class="your-page">
      <figure>
        <a href="#" title=""><img src="images/user.png" alt="" /></a>
      </figure>
      <div class="page-meta">
        <a href="#" title="" class="underline">{{$store.state.session.displayName}}</a>
        <span
          ><i class="ti-comment"></i
          ><a href="insight.html" title="">Messages <em>9</em></a></span
        >
        <span
          ><i class="ti-bell"></i
          ><a href="insight.html" title="">Notifications <em>2</em></a></span
        >
      </div>
      <div class="page-likes">
        <ul class="nav nav-tabs likes-btn">
          <li class="nav-item">
            <a class="active" href="#link1" data-toggle="tab">likes</a>
          </li>
          <li class="nav-item">
            <a class="" href="#link2" data-toggle="tab">views</a>
          </li>
        </ul>
        <!-- Tab panes -->
        <div class="tab-content">
          <div class="tab-pane active fade show" id="link1">
            <span><i class="ti-heart"></i>884</span>
            <a href="#" title="weekly-likes">35 new likes this week</a>
            <div class="users-thumb-list">
              <a href="#" title="Anderw" data-toggle="tooltip">
                <img src="images/resources/side-friend1.jpg" alt="" />
              </a>
              <a href="#" title="frank" data-toggle="tooltip">
                <img src="images/resources/side-friend2.jpg" alt="" />
              </a>
              <a href="#" title="Sara" data-toggle="tooltip">
                <img src="images/resources/side-friend3.jpg" alt="" />
              </a>
              <a href="#" title="Amy" data-toggle="tooltip">
                <img src="images/resources/side-friend4.jpg" alt="" />
              </a>
              <a href="#" title="Ema" data-toggle="tooltip">
                <img src="images/resources/side-friend5.jpg" alt="" />
              </a>
              <a href="#" title="Sophie" data-toggle="tooltip">
                <img src="images/resources/side-friend6.jpg" alt="" />
              </a>
              <a href="#" title="Maria" data-toggle="tooltip">
                <img src="images/resources/side-friend7.jpg" alt="" />
              </a>
            </div>
          </div>
          <div class="tab-pane fade" id="link2">
            <span><i class="ti-eye"></i>440</span>
            <a href="#" title="weekly-likes">440 new views this week</a>
            <div class="users-thumb-list">
              <a href="#" title="Anderw" data-toggle="tooltip">
                <img src="images/resources/side-friend1.jpg" alt="" />
              </a>
              <a href="#" title="frank" data-toggle="tooltip">
                <img src="images/resources/side-friend2.jpg" alt="" />
              </a>
              <a href="#" title="Sara" data-toggle="tooltip">
                <img src="images/resources/side-friend3.jpg" alt="" />
              </a>
              <a href="#" title="Amy" data-toggle="tooltip">
                <img src="images/resources/side-friend4.jpg" alt="" />
              </a>
              <a href="#" title="Ema" data-toggle="tooltip">
                <img src="images/resources/side-friend5.jpg" alt="" />
              </a>
              <a href="#" title="Sophie" data-toggle="tooltip">
                <img src="images/resources/side-friend6.jpg" alt="" />
              </a>
              <a href="#" title="Maria" data-toggle="tooltip">
                <img src="images/resources/side-friend7.jpg" alt="" />
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Profile",
};
</script>
<style scoped>
.widget{
  padding-top: 10px;
}
</style>
