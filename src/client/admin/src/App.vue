<template>
  <div class="layout-wrapper layout-content-navbar">
    <div class="layout-container">
      <AppLeftMenu />
      <div class="layout-page">
        <AppHeader />
        <div class="content-wrapper">
          <div class="container-xxl flex-grow-1 container-p-y">
            <RouterView />
          </div>
        </div>
        <AppFooter />
        <div class="content-backdrop fade"></div>
      </div>
    </div>
  </div>
  <div class="layout-overlay layout-menu-toggle"></div>
</template>

<script>
import AppHeader from "./Layout/AppHeader.vue";
import AppFooter from "./Layout/AppFooter.vue";
import AppLeftMenu from "./Layout/AppLeftMenu.vue";
export default {
  name: "App",
  components: {
    AppHeader,
    AppLeftMenu,
    AppFooter,
  },
};
</script>