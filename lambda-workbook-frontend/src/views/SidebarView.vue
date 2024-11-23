<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <div>
    <h1>Навигация</h1>
    <nav class="nav-list">
      <RouterLink to="/page1">Химические реакции</RouterLink>
      <RouterLink to="/page2">Качественные реакции</RouterLink>
      <RouterLink to="/page3">Тривиальные названия</RouterLink>
      <RouterLink to="/page4">Индикаторы</RouterLink>
      <RouterLink to="/page5">Химическое равновесие</RouterLink>
      <RouterLink to="/page6">Справочник</RouterLink>
      <RouterLink to="/page7">Использование таблиц</RouterLink>
    </nav>
  </div>
</template>

<style scoped>
.nav-list a {
  display: block;
  font-weight: bold;
  font-size: large;
  padding: 10px;
  margin: 10px 0;

  border-radius: var(--border-radius);
}

.nav-list a:first-child {
  margin-top: var(--outter-padding);
}

.nav-list a:last-child {
  margin-bottom: 0;
}
</style>
