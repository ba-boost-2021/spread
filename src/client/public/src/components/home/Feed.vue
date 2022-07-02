<template>
  <div v-for="feed in feeds" :key="feed.id" class="loadMore">
    <div class="central-meta item">
      <div class="user-post">
        <div class="friend-info">
          <figure>
            <img src="images/user.png" alt="" />
          </figure>
          <div class="friend-name">
            <ins
              ><a href="time-line.html" title="">{{ feed.ownerName }}</a></ins
            >
            <span>published: {{ feed.publishDate }}</span>
          </div>
          <div class="post-meta">
            <img :src="feed.fileUrl" alt="" />
            <div class="we-video-info">
              <ul>
                <li>
                  <span class="comment" data-toggle="tooltip" title="Comments">
                    <i class="fa fa-comments-o"></i>
                    <ins>{{ feed.commentCount }}</ins>
                  </span>
                </li>
                <li>
                  <span class="like" data-toggle="tooltip" title="like">
                    <i class="ti-heart"></i>
                    <ins>{{ feed.likeCount }}</ins>
                  </span>
                </li>
                <li class="social-media">
                  <div class="menu">
                    <div class="btn trigger">
                      <i class="fa fa-share-alt"></i>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-html5"></i></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-facebook"></i></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""
                          ><i class="fa fa-google-plus"></i
                        ></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-twitter"></i></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-css3"></i></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-instagram"></i></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-dribbble"></i></a>
                      </div>
                    </div>
                    <div class="rotater">
                      <div class="btn btn-icon">
                        <a href="#" title=""><i class="fa fa-pinterest"></i></a>
                      </div>
                    </div>
                  </div>
                </li>
              </ul>
            </div>
            <div class="description">
              <p>
                {{ feed.content }}
              </p>
            </div>
          </div>
        </div>
        <div class="coment-area">
          <ul class="we-comet">
            <li>
              <div class="comet-avatar">
                <img src="images/resources/side-friend1.jpg" alt="" />
              </div>
              <div class="we-comment">
                <div class="coment-head">
                  <h5>
                    <a href="time-line.html" title="">Jason borne</a>
                  </h5>
                  <span>1 year ago</span>
                  <a class="we-reply" href="#" title="Reply"
                    ><i class="fa fa-reply"></i
                  ></a>
                </div>
                <p>
                  we are working for the dance and sing songs. this car is very
                  awesome for the youngster. please vote this car and like our
                  post
                </p>
              </div>
            </li>
            <li>
              <div class="comet-avatar">
                <img src="images/resources/side-friend1.jpg" alt="" />
              </div>
              <div class="we-comment">
                <div class="coment-head">
                  <h5>
                    <a href="time-line.html" title="">Donald Trump</a>
                  </h5>
                  <span>1 week ago</span>
                  <a class="we-reply" href="#" title="Reply"
                    ><i class="fa fa-reply"></i
                  ></a>
                </div>
                <p>
                  we are working for the dance and sing songs. this video is
                  very awesome for the youngster. please vote this video and
                  like our channel
                  <i class="em em-smiley"></i>
                </p>
              </div>
            </li>
            <li>
              <a href="#" title="" class="showmore underline">more comments</a>
            </li>
            <li class="post-comment">
              <div class="comet-avatar">
                <img src="images/resources/side-friend1.jpg" alt="" />
              </div>
              <div class="post-comt-box">
                <form method="post">
                  <textarea placeholder="Post your comment"></textarea>
                  <div class="add-smiles">
                    <span class="em em-expressionless" title="add icon"></span>
                  </div>
                  <div class="smiles-bunch">
                    <i class="em em---1"></i>
                    <i class="em em-smiley"></i>
                    <i class="em em-anguished"></i>
                    <i class="em em-laughing"></i>
                    <i class="em em-angry"></i>
                    <i class="em em-astonished"></i>
                    <i class="em em-blush"></i>
                    <i class="em em-disappointed"></i>
                    <i class="em em-worried"></i>
                    <i class="em em-kissing_heart"></i>
                    <i class="em em-rage"></i>
                    <i class="em em-stuck_out_tongue"></i>
                  </div>
                  <button type="submit"></button>
                </form>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Feed",
  data() {
    return {
      feeds: [],
    };
  },
  mounted() {
    this.load();
  },
  methods: {
    load() {
      this.$ajax.get("api/public/post/list").then((response) => {
        this.feeds = response.data;
        console.log(this.feeds);
      });
    },
  },
};
</script>
