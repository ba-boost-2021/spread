<template>
  <section>
    <div class="gap100 gray-bg">
      <div class="container">
        <div class="row">
          <div class="col-lg-12">
          <div v-if="hasError">
            <Message title="Kayıt işleminde bir sorun yaşandı" severity="error"></Message>
          </div>
          <div v-if="registered">
            <Message title="Kayıt Başarılı! Şimdi giriş yapabilirsiniz" severity="success"></Message>
          </div>
            <div class="logout-meta" v-else>
              <h2>Spread</h2>
              <span>Hesabınız yok mu?</span>
              <div class="central-meta">
                <div class="editing-info">
                  <div class="form-group half">
                    <input type="text" v-model="fullname" />
                    <label class="control-label">Adı Soyadı</label
                    ><i class="mtrl-select"></i>
                  </div>
                  <div class="form-group half">
                    <input type="text" v-model="username" />
                    <label class="control-label">Kullanıcı Adı</label
                    ><i class="mtrl-select"></i>
                  </div>
                  <div class="form-group">
                    <input type="text" v-model="email" />
                    <label class="control-label">E-posta Adresi</label
                    ><i class="mtrl-select"></i>
                  </div>

                  <div class="form-group half">
                    <input type="password" v-model="password" />
                    <label class="control-label">Parola</label><i class="mtrl-select"></i>
                  </div>

                  <div class="form-group half">
                    <input type="password" v-model="passwordRepeat" />
                    <label class="control-label">Parola Tekrar</label
                    ><i class="mtrl-select"></i>
                    <em class="password-error" v-if="passwordMatchError"
                      >Parola eşleşmiyor</em
                    >
                  </div>

                  <div class="submit-btns">
                    <button type="button" class="mtr-btn" @click="register" :disabled="isInvalid">
                      <span>Kayıt Ol</span>
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
import Message from '../../components/Message.vue';
const mailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
export default {
    name: "Register",
    data: () => {
        return {
            fullname: null,
            username: null,
            email: null,
            password: null,
            passwordRepeat: null,
            registered: false,
            hasError: false
        };
    },
    methods: {
        register() {
            this.hasError = false;
            const data = {
                username: this.username,
                email: this.email,
                fullname: this.fullname,
                password: this.password
            };
            this.$ajax.post("api/authentication/register", data).then(response => {
                if (response.data) {
                    this.registered = true;
                }
            }).catch(() => {
                this.hasError = true;
            });
        },
    },
    computed: {
        passwordMatchError() {
            return this.password?.length >= 6 && this.password !== this.passwordRepeat;
        },
        isInvalid() {
            let isInvalid = (!this.fullname || this.fullname.length < 5) ||
                (!this.username || this.username.length < 3) ||
                (!this.email || !this.email.match(mailRegex)) ||
                this.passwordMatchError;
            return isInvalid;
        },
    },
    components: { Message }
};
</script>
<style scoped>
.password-error {
  display: block;
  text-align: left;
  font-size: 0.7em;
  color: #e35555;
}
</style>
