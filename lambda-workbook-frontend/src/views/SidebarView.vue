<script setup lang="ts">
import { useAuthStore } from '@/store/auth-store'
import { RouterLink } from 'vue-router'

const authStore = useAuthStore()
</script>

<template>
  <div>
    <h1>Навигация</h1>
    <nav class="nav-list">
      <RouterLink to="/page1">Первая страница</RouterLink>
      <RouterLink to="/page2">Вторая страница</RouterLink>
      <RouterLink to="/page3">Третья страница</RouterLink>
      <RouterLink to="/page4">Не поверите, но ...</RouterLink>
      <RouterLink to="/notes" :class="{ disabled: !authStore.isAuthorized }">Заметки</RouterLink>
    </nav>
  </div>
</template>

<style scoped>
.nav-list a {
  display: block;
  font-weight: bold;
  font-size: large;
  border-radius: 10px;
  padding: 15px 5px;
  margin: 10px 0;
}

.nav-list :first-child {
  margin-top: 20px;
}
</style>
