<script setup lang="ts">
import CustomTooltip from '@/components/CustomTooltip.vue'
import { useAuthStore } from '@/store/auth-store'
import { RouterLink } from 'vue-router'

const authStore = useAuthStore()
</script>

<template>
  <div>
    <h1>Навигация</h1>
    <nav class="nav-list">
      <div>
        <RouterLink to="/page1">Первая страница</RouterLink>
      </div>

      <div>
        <RouterLink to="/page2">Вторая страница</RouterLink>
      </div>

      <div>
        <RouterLink to="/page3">Третья страница</RouterLink>
      </div>

      <div>
        <RouterLink to="/page4">Не поверите, но ...</RouterLink>
      </div>

      <CustomTooltip text="Войдите, чтобы просмотреть" :is-disabled="authStore.isAuthorized">
        <RouterLink to="/notes" :class="{ disabled: !authStore.isAuthorized }">Заметки</RouterLink>
      </CustomTooltip>
    </nav>
  </div>
</template>

<style scoped>
.nav-list div {
  margin: 10px 0;
}

.nav-list a {
  display: block;
  font-weight: bold;
  font-size: large;
  padding: 15px 5px;
  border-radius: var(--border-radius);
}

.nav-list div:first-child {
  margin-top: 20px;
}
</style>
