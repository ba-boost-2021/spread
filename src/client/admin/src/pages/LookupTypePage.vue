<template>
  <div>
    <div v-if="isFailed" class="alert alert-warning">işlem Başarısız</div>
    <div class="card">
      <div class="table-responsive text-nowrap">
        <table class="table">
          <thead>
            <tr>
              <th>Adı</th>
              <th>Durumu</th>
            </tr>
          </thead>
          <tbody class="table-border-bottom-0">
            <tr v-for="l in lookupTypes" :key="l.id">
              <td>
                <strong>{{ l.name }}</strong>
              </td>
              <td>
                <span v-if="l.isActive" class="badge bg-label-success me-1"
                  >Aktif</span
                >
                <span v-if="!l.isActive" class="badge bg-label-danger me-1"
                  >Pasif</span
                >
              </td>
              <td>
                <div class="dropdown">
                  <button
                    type="button"
                    class="btn p-0 dropdown-toggle hide-arrow"
                    data-bs-toggle="dropdown"
                  >
                    <i class="bx bx-dots-vertical-rounded"></i>
                  </button>
                  <div class="dropdown-menu">
                    <a class="dropdown-item" href="javascript:void(0);"
                      ><i class="bx bx-edit-alt me-1"></i> Düzenle</a
                    >
                    <a class="dropdown-item" @click="remove(l.id)"
                      ><i class="bx bx-trash me-1"></i> Sil</a
                    >
                  </div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
  <DeleteModal ref="deleteModal" @on-confirm="loadData" />
</template>
<script>
import DeleteModal from "../components/modals/LookupTypeDeleteConfirm.vue";
export default {
  name: "LookupTypePage",
  data() {
    return {
      lookupTypes: [],
      isFailed: false,
    };
  },
  components: {
    DeleteModal,
  },
  mounted() {
    this.loadData();
  },
  methods: {
    remove(id) {
      this.$refs.deleteModal.open(id);
    },
    loadData() {
      this.$ajax
        .get("api/management/lookupType/list")
        .then((response) => {
          if (response.data) {
            this.lookupTypes = response.data;
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
