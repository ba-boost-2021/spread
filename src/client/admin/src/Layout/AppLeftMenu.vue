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
        :class="{ active: isCurrentPathOnRootMenu(m), open: m.isOpen }"
        v-for="m in menu"
        :key="m.title"
      >
        <a class="menu-link menu-toggle" v-if="m.children?.length > 0">
          <i class="menu-icon tf-icons bx bx-home-circle"></i>
          <div>{{ m.title }}</div>
        </a>

        <RouterLink :to="m.to" class="menu-link" v-else>
          <i class="menu-icon tf-icons bx bx-home-circle"></i>
          <div>{{ m.title }}</div>
        </RouterLink>

        <ul class="menu-sub" v-if="m.children?.length > 0">
          <li class="menu-item" :class="{ 'active' : isCurrentPath(s)}" v-for="s in m.children" :key="s">
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
              to: "/manage/lookupTypes",
              parent: 2,
            },
            {
              title: "Metaveri Tanımları",
              to: "/manage/lookups",
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
      const isCurrent = s.to === this.$route.path;
      if (isCurrent) {
        const parent = this.menu.find((f) => f.key === s.parent);
        const others = this.menu.filter((f) => f.key !== s.parent);
        parent.isActive = true;
        parent.isOpen = true;
        others.forEach(m => {
          m.isActive = false;
          m.isOpen = false;
        });
      }
      return isCurrent;
    },
    isCurrentPathOnRootMenu(m) {
      if (m.children?.length > 0) {
        let isActive = m.children.some(s => s.to === this.$route.path);
        if (isActive) {
          return true;
        }
      }
      const isCurrent = m.to && m.to === this.$route.path;
      return isCurrent;
    }
  },
};
</script>
