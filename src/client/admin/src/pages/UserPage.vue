<template>
  <div class="card">
    <div class="table-responsive text-nowrap">
      <table class="table">
        <thead>
          <tr>
            <th>Kullanıcı Adı</th>
            <th>E-Mail Adresi</th>
            <th>Oluşturulma Zamanı</th>
          </tr>
        </thead>
        <tbody class="table-border-bottom-0">
          <tr v-for="u in userList" :key="u.id">
            <td>
              <strong>{{ u.userName }}</strong>
            </td>

            <td>
              {{ u.eMail }}
            </td>
            <td>
              {{ u.createdAt }}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      userName: null,
      eMail: null,
      createdAt: null,
      userList: [],
      isFailed: false,
    };
  },
  mounted() {
    this.loadData();
  },
  methods: {
    loadData() {
      this.$ajax
        .get("api/management/user/list")
        .then((response) => {
          if (response.data) {
            this.userList = response.data;
          }
        })
        .catch((error) => {
          if (error) {
            this.isFailed = true;
          }
        });
    },
  },
};
</script>
<style></style>
