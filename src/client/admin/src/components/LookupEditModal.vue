<template>
  <div>
    <div
      class="modal fade"
      id="LookupEditModal"
      tabindex="-1"
      aria-hidden="true"
    >
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
                <label for="name" class="form-label">Name</label>
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
                <label for="TypeName" class="form-label">TypeName</label>
                <input
                v-model="typeName"
                  type="text"
                  id="TypeName"
                  class="form-control"
                />
              </div>
              <div class="row g-2">
                <label for="Status" class="form-label">Status</label>
                <input
                v-model="isActive"
                  type="text"
                  id="Status"
                  class="form-control"
                />
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-label-secondary"
              data-bs-dismiss="modal"
            >
              Kapat
            </button>
            <button type="button" class="btn btn-primary" @click="edit">Güncelle</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { bootstrap } from "../helpers/root/bootstrap";
export default {
  emits: ["yes"],
  name: "Update",
  data() {
    return {
      instance: null,
      selectedId: null,
      notSuccess: false,
      name:null,
      typeName:null,
      isActive:false,
    };
  },
  mounted() {
    this.instance = new bootstrap.Modal(
      document.getElementById("LookupEditModal")
    );
  },
  methods: {
    edit() {
      let content = {
        name:this.name,
        isActive:this.isActive,
        typeName:this.typeName,
      };
      this.$ajax
        .put(`api/management/lookup/edit/${this.selectedId}`, content)
        .then((response) => {
          if (response.data) {
            this.$emit("yes");
            this.instance.hide();
          }
        })
        .catch((error) => {
          if (error) {
            this.notSuccess = true;
          }
        });
    },

    open(id) {
      this.selectedId = id;
      this.$ajax.get(`api/management/lookup/get/${id}`).then((response) => {
        if (response.data) {
        this.name=response.data.name;
        this.typeName=response.data.typeName;
        this.isActive=response.data.isActive;
        }
      });
      this.instance.show();
    },
  },
};
</script>
