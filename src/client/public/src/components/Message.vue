<template>
  <div class="message">
    {{ title }}
  </div>
</template>
<script>
export default {
  name: "Message",
  props: {
    title: String,
    severity: {
      type: String,
      validator: (val) => ["error", "success", "info", "warning"].includes(val),
    },
  },
  mounted() {
    switch (this.severity) {
        case "error":
            this.bgColor = "#dc3545";
            this.color = "#fff";
            break;
            case "info":
            this.bgColor = "#17a2b8";
            this.color = "#fff";
            break;
            case "success":
            this.bgColor = "#28a745";
            this.color = "#fff";
            break;
            case "warning":
            this.bgColor = "#ffc107";
            this.color = "#333";
            break;
    
        default:
            this.bgColor = "#17a2b8";
            this.color = "#fff";
            break;
    }
  },
  data: () => {
    return {
      bgColor: null,
      color: null
    };
  },
};
</script>
<style scoped>
.message {
  padding: 10px;
  margin: 10px;
  font-size: 1.2em;
  background-color: v-bind(bgColor);
  color: v-bind(color)
}
</style>
