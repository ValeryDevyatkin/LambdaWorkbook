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
  background-color: #3a9555;
  border-radius: 10px;
  padding: 15px 0;
  margin-top: 10px;
  margin-bottom: 10px;
  color: black;
  text-decoration: none;
  text-align: center;

  outline: 1px solid #114d17;
  border: 1px solid transparent;
  transition: all 0.4s ease-in-out;
}

.nav-list a:hover {
  outline: 0px solid transparent;
  border: 1px solid #114d17;
  box-shadow: 0 0 10px green;
  transition: all 0.4s ease-in-out;
}

.nav-list :first-child {
  margin-top: 20px;
}
</style>
