<template>
  <div>
  
    <div class="modal fade" id="LookupEditModal" tabindex="-1" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel1">Meta Veri Güncelleme</h5>
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div class="modal-body">
            <div class="row g-2">
              <div class="col mb-3">
                <label for="name" class="form-label">Adı</label>
                <input
                  v-model="name"
                  type="lookupName"
                  id="lookupName"
                  class="form-control"
                />
              </div>
            </div>
            <div class="row g-2">
              <div class="col mb-0">
                <label for="TypeName" class="form-label">Tipi</label>
                <input
                  v-model="typeName"
                  type="text"
                  id="TypeName"
                  class="form-control"
                />
              </div>

              <div class="row g-2">
                <div class="form-check">
                  <input
                    v-model="isActive"
                    class="form-check-input"
                    type="checkbox"
                    value=""
                    id="IsActive"
                  />
                  <label class="form-check-label" for="IsActive"> Durumu </label>
                </div>
              </div>
            </div>
            <div v-if="hasError" class="alert alert-warning">işlem Başarısız</div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-label-secondary" data-bs-dismiss="modal">
              Kapat
            </button>
            <button type="button" class="btn btn-primary" @click="update">Güncelle</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { bootstrap } from "../../helpers/root/bootstrap";
export default {
  emits: ["onUpdate"],
  name: "UpdateLookup",
  data() {
    return {
      modal: null,
      selectedId: null,
      hasError: false,
      name: null,
      typeName: null,
      isActive: false,
    };
  },
  mounted() {
    this.modal = new bootstrap.Modal(document.getElementById("LookupEditModal"));
  },
  methods: {
    update() {
      this.hasError = false;
      let content = {
        id: this.selectedId,
        name: this.name,
        isActive: this.isActive
      };
      this.$ajax
        .put(`api/management/lookup/update`, content)
        .then((response) => {
          if (response.data) {
            this.$emit("onUpdate");
            this.modal.hide();
          }
        })
        .catch((error) => {
          if (error) {
            this.hasError = true;
          }
        });
    },

    open(id) {
      this.selectedId = id;
      this.$ajax.get(`api/management/lookup/get/${id}`).then((response) => {
        if (response.data) {
          this.name = response.data.name;
          this.typeName = response.data.typeName;
          this.isActive = response.data.isActive;
        }
      });
      this.modal.show();
    },
  },
};
</script>
