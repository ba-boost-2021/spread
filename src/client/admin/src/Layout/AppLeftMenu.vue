<template>
  <aside id="layout-menu" class="layout-menu menu-vertical menu bg-menu-theme">
    <div class="app-brand demo">
      <a href="index.html" class="app-brand-link">
        <span class="app-brand-logo demo">
          <img src="/img/logo.svg" />
        </span>
        <span class="app-brand-text demo menu-text fw-bolder ms-2">Spread</span>
      </a>

      <a
        href="javascript:void(0);"
        class="layout-menu-toggle menu-link text-large ms-auto d-block d-xl-none"
      >
        <i class="bx bx-chevron-left bx-sm align-middle"></i>
      </a>
    </div>

    <div class="menu-inner-shadow"></div>

    <ul class="menu-inner py-1">
      <li class="menu-item" :class="{ 'active' : m.isActive }" v-for="m in menu" :key="m.title">
        <a class="menu-link" :class="{ 'menu-toggle': m.children?.length > 0 }">
          <i class="menu-icon tf-icons bx bx-home-circle"></i>
          <div>{{ m.title }}</div>
        </a>

        <ul class="menu-sub" v-if="m.children?.length > 0">
          <li class="menu-item" v-for="s in m.children">
            <a class="menu-link">
              <div>{{ s.title }}</div>
            </a>
          </li>
        </ul>
      </li>
    </ul>
  </aside>
</template>
<script>
export default {
  name: "AppLeftMenu",
  data: () => {
    return {
      menu: [
        { title: "Karşılama Ekranı", to: "/", isActive: true },
        {
          title: "Yönetim",
          isActive: false,
          children: [
            { title: "Metaveri Başlıkları", to: "/manage/titles", isActive: false },
            { title: "Metaveri Tanımları", to: "/manage/lookups", isActive: false },
            { title: "Sistem Parametreleri", to: "/manage/params", isActive: false },
          ],
        },
        {
          title: "Kullanıcı",
          isActive: false,
          children: [
            { title: "Kullanıcı Yönetimi", to: "/user/list", isActive: false },
            { title: "Yorumlar", to: "/user/comments", isActive: false },
            { title: "Davet Linkleri", to: "/user/invites", isActive: false },
            { title: "Hesap Kurtarma", to: "/user/recover", isActive: false },
          ],
        },
        { title: "Şikayetler", to: "/abuse-reports", isActive: false },
      ],
    };
  },
};
</script>
