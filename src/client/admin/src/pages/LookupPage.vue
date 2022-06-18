<template>
  <div>
    <div v-if="isFailed" class="alert alert-warning">işlem Başarısız</div>
    <div class="card">
      <h5 class="card-header">Meta Veriler</h5>
      <div class="table-responsive text-nowrap">
        <table class="table table-dark">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody class="table-border-bottom-0">
            <tr v-for="l in lookups" :key="l.id">
              <td>
                <i class="fab fa-angular fa-lg text-danger me-3"></i>
                <strong>{{ l.id }}</strong>
              </td>
              <td>{{ l.name }}</td>
              <td>
                <span class="badge bg-label-primary me-1">{{
                  l.isActive
                }}</span>
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
                      ><i class="bx bx-edit-alt me-1"></i> Edit</a
                    >
                    <a class="dropdown-item" href="javascript:void(0);"
                      ><i class="bx bx-trash me-1"></i> Delete</a
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
</template>
<script>
export default {
  name: "LookupPage",
  data() {
    return {
      lookups: [],
      isFailed: false,
    };
  },
  mounted() {
    this.$ajax
      .get("api/management/lookup/list")
      .then((response) => {
        if (response.data) {
          this.lookups = response.data;
        }
      })
      .catch((error) => {
        this.isFailed = true;
      });
  },
};
</script>
<style></style>
