<template>
  <div>
    <div v-if="hasError" class="alert alert-warning">işlem Başarısız</div>
    <div
      class="modal fade"
      id="lookupTypeDeleteModal"
      aria-labelledby="modalToggleLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modalToggleLabel">Silme Onayı</h5>
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div class="modal-body">
           Bu Metaveri Başlığını silmek istiyor musunuz ?
          </div>
          <div class="modal-footer">
            <button
              class="btn btn-primary"
              data-bs-target="#modalToggle2"
              data-bs-toggle="modal"
              data-bs-dismiss="modal"
              @click="confirm"
            >
              Evet
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { bootstrap } from "../../helpers/root/bootstrap";

export default {
  emits: ["onConfirm"],
  name: "DeleteLookup",
  data() {
    return {
      modal: null,
      selectedId: null,
      hasError: false,
    };
  },
  mounted() {
    this.modal = new bootstrap.Modal(
      document.getElementById("lookupTypeDeleteModal")
    );
  },
  methods: {
    confirm() {
      this.$ajax
        .delete(`api/management/lookupType/delete/${this.selectedId}`)
        .then((response) => {
          if (response.data) {
            this.$emit("onConfirm");
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
      this.modal.show();
      this.selectedId = id;
    },
  },
};
</script>