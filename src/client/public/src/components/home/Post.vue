<template>
  <div class="central-meta">
    <div class="new-postbox">
      <figure>
        <img src="images/user.png" alt="" />
      </figure>
      <div class="newpst-input">
        <Message
          title="Gönderi paylaşıldı."
          severity="success"
          v-if="postSucceed"
        />
        <div>
          <div style="display: flex; justify-content: center">
            <img
              :src="imageUrl"
              style="border-radius: 2px; padding-bottom: 5px"
            />
          </div>
          <textarea
            rows="2"
            placeholder="write something"
            v-model="content"
          ></textarea>
          <div class="attachments">
            <ul>
              <li>
                <i class="fa fa-music"></i>
                <label class="fileContainer">
                  <input type="file" />
                </label>
              </li>
              <li>
                <i class="fa fa-image"></i>
                <label class="fileContainer">
                  <input type="file" @change="imageSelected" />
                </label>
              </li>
              <li>
                <i class="fa fa-video-camera"></i>
                <label class="fileContainer">
                  <input type="file" />
                </label>
              </li>
              <li>
                <i class="fa fa-camera"></i>
                <label class="fileContainer">
                  <input type="file" />
                </label>
              </li>
              <li>
                <button @click="post">Post</button>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Message from "../../components/Message.vue";
export default {
  name: "Post",
  components: {
    Message,
  },
  data() {
    return {
      imageUrl: null,
      file: null,
      content: null,
      postSucceed: false,
    };
  },
  methods: {
    imageSelected(event) {
      const [file] = event.target.files;
      this.file = file;
      // const file = event.target.files[0];
      if (file) {
        this.imageUrl = URL.createObjectURL(file);
      }
    },
    post() {
      let formData = new FormData();
      formData.append("File", this.file);
      formData.append("Content", this.content);
      this.$ajax
        .post("api/public/post/post", formData, "multipart/form-data")
        .then((response) => {
          if (response.data) {
            this.postSucceed = true;
            setTimeout(() => {
              this.postSucceed = false;
            }, 5000);
          }
        });
    },
  },
};
</script>