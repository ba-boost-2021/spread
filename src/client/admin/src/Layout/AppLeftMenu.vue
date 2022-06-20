<template>
  <aside id="layout-menu" class="layout-menu menu-vertical menu bg-menu-theme">
    <div class="app-brand demo">
      <a href="/" class="app-brand-link">
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
      <li
        class="menu-item"
        :class="{ active: m.isActive, open: m.isOpen }"
        v-for="m in menu"
        :key="m.title"
      >
        <a class="menu-link" :class="{ 'menu-toggle': m.children?.length > 0 }">
          <i class="menu-icon tf-icons bx bx-home-circle"></i>
          <div>{{ m.title }}</div>
        </a>

        <ul class="menu-sub" v-if="m.children?.length > 0">
          <li class="menu-item" v-for="s in m.children" :key="s">
            <RouterLink class="menu-link" :to="s.to">
              <div>{{ s.title }}</div>
            </RouterLink>
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
        {
          key: 1,
          title: "Karşılama Ekranı",
          to: "/",
          isActive: false,
          isOpen: false,
        },
        {
          key: 2,
          title: "Yönetim",
          isActive: false,
          isOpen: false,
          children: [
            {
              title: "Metaveri Başlıkları",
              to: "/manage/titles",
              parent: 2,
            },
            {
              title: "Metaveri Tanımları",
              to: "/manage/lookups",
              parent: 2,
            },
            {
              title: "Metaveri Tanımları",
              to: "/manage/lookupTypes",
              parent: 2,
            },
            {
              title: "Sistem Parametreleri",
              to: "/manage/params",
              parent: 2,
            },
          ],
        },
        {
          key: 3,
          title: "Kullanıcı",
          isActive: false,
          isOpen: false,
          children: [
            { title: "Kullanıcı Yönetimi", to: "/user/list", parent: 3 },
            { title: "Yorumlar", to: "/user/comments", parent: 3 },
            { title: "Davet Linkleri", to: "/user/invites", parent: 3 },
            { title: "Hesap Kurtarma", to: "/user/recover", parent: 3 },
          ],
        },
        {
          key: 4,
          title: "Şikayetler",
          to: "/abuse-reports",
          isActive: false,
          isOpen: false,
        },
      ],
    };
  },
  methods: {
    isCurrentPath(s) {
      //TODO: Show current menu on refresh
      const isCurrent = s.to === this.$route.path;
      this.menu.forEach((f) => {
        f.isActive = false;
        f.isOpen = false;
      });
      if (isCurrent) {
        const parent = this.menu.find((f) => f.key === s.parent);
        parent.isActive = true;
        parent.isOpen = true;
      }
      return isCurrent;
    },
  },
};
</script>
